using KindergartenSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Concurrent;
using static KindergartenSystem.Common.GeneralApplicationConstants;



namespace KindergartenSystem.Web.Infrastructure.Middlewares
{
    public class OnlineUsersMiddleware
    {
        private readonly RequestDelegate _requestDelegate;
        private readonly string _cookie;
        private readonly int _lastActivityMins;

        private static readonly ConcurrentDictionary<string, bool> AllKeys =
           new ConcurrentDictionary<string, bool>();
        public OnlineUsersMiddleware(RequestDelegate requestDelegate, string cookie = CookieName, int lastActivityMins = MinsBeforeGoOffline)
        {
            _requestDelegate = requestDelegate;
            _cookie = cookie;
            _lastActivityMins = lastActivityMins;

        }

        public Task InvokeAsync(HttpContext httpContext, IMemoryCache memoryCache)
        {
            if (httpContext.User.Identity?.IsAuthenticated ?? false)
            {
                if (!httpContext.Request.Cookies.TryGetValue(_cookie, out string userId))
                {
                    // First login after being offline
                    userId = httpContext.User.GetId()!;

                    httpContext.Response.Cookies.Append(_cookie, userId, new CookieOptions() { HttpOnly = true, MaxAge = TimeSpan.FromDays(30) });
                }
                memoryCache.GetOrCreate(userId, cacheEntry =>
                {
                    if (!AllKeys.TryAdd(userId, true))
                    {
                        // Adding key failed to the concurrent dictionary so we have an error
                        cacheEntry.AbsoluteExpiration = DateTimeOffset.MinValue;
                    }
                    else
                    {
                        cacheEntry.SlidingExpiration = TimeSpan.FromMinutes(_lastActivityMins);
                        cacheEntry.RegisterPostEvictionCallback(RemoveKeyWhenExpired);
                    }

                    return string.Empty;
                });
            }
            else
            {
                // User has just logged out
                if (httpContext.Request.Cookies.TryGetValue(_cookie, out string userId))
                {
                    if (!AllKeys.TryRemove(userId, out _))
                    {
                        AllKeys.TryUpdate(userId, false, true);
                    }

                    httpContext.Response.Cookies.Delete(_cookie);
                }
            }
            return _requestDelegate(httpContext);
        }
        private void RemoveKeyWhenExpired(object key, object value, EvictionReason reason, object state)
        {
            string keyStr = (string)key;

            if (!AllKeys.TryRemove(keyStr, out _))
            {
                AllKeys.TryUpdate(keyStr, false, true);
            }
        }
        public static bool CheckIfUserIsOnline(string userId)
        {
            
            bool valueTaken = AllKeys.TryGetValue(userId.ToLower(), out bool success);

            return success && valueTaken;
        }

    }
}
