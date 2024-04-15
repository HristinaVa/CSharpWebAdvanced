using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static KindergartenSystem.Common.GeneralApplicationConstants;

namespace KindergartenSystem.Web.Infrastructure.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetId(this ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        public static bool IsUserAdmin(this ClaimsPrincipal user)
        {
            return user.IsInRole(AdminRoleName);

        }
    }


}
