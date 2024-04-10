using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KindergartenSystem.Data;
using KindergartenSystem.Services.Data.Interfaces;
using KindergartenSystem.Services.Data;
using KindergartenSystem.Web.Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using KindergartenSystem.Data.Models;


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
    .AddEntityFrameworkStores<KindergartenDbContext>();

builder.Services.AddApplicationServices(typeof(IKindergartenService));

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options => 
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });


var app = builder.Build();

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


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "ProtectingUrlPattern",
        pattern: "/{controller}/{action}/{id}/{information}",
        defaults: new { Controller = "ClassGroup", Action = "Details" });
    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});


app.Run();
