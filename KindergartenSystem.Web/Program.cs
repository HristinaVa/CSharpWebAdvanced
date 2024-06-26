using KindergartenSystem.Data;
using KindergartenSystem.Data.Models;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Mapping;
using KindergartenSystem.Web.Infrastructure.Extensions;
using KindergartenSystem.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static KindergartenSystem.Common.GeneralApplicationConstants;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<KindergartenDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
    options.Password.RequireLowercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    options.Password.RequireUppercase = builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequireNonAlphanumeric = builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    options.Password.RequiredLength = builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<KindergartenDbContext>();

builder.Services.AddRecaptchaService();

builder.Services.AddApplicationServices(typeof(IKindergartenService));
builder.Services.ConfigureApplicationCookie(config => 
{
    config.LoginPath = "/User/Login";
    config.AccessDeniedPath = "/Home/Error/401";
});

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options => 
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });


var app = builder.Build();

AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.EnableOnlineUsersCheck();

app.SeedAdmin(AdminEmail);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

    endpoints.MapControllerRoute(
        name: "ProtectingUrlPattern",
        pattern: "/{controller}/{action}/{id}/{information}",
        defaults: new { Controller = "ClassGroup", Action = "Details" });
   
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});


app.Run();
