using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using UDFirstTask.Authorization;
using UDFirstTask.Data;
using UDFirstTask.Models;
using UDFirstTask.Repositories;
using UDFirstTask.Repositories.Interfaces;
using UDFirstTask.Service;

var builder = WebApplication.CreateBuilder(args); 
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInformationRepository, InformationRepository>();
builder.Services.AddScoped<AuthService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
})
.AddCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath  = "/Error/Auth";
});

builder.Services.AddAuthorization((Action<AuthorizationOptions>)(options =>
{
    options.AddPolicy("UserTypePolicy", (Action<AuthorizationPolicyBuilder>)(policy =>
    {
        policy.Requirements.Add(new UserTypeRequirement("Admin", "Client"));
    }));
}));

builder.Services.AddSingleton<IAuthorizationHandler, UserTypeAuthorizationHandler>();
builder.Services.AddHttpContextAccessor();
builder.Services
    .AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI().AddDefaultTokenProviders();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{

    app.UseExceptionHandler("/Error/ErrorHandler"); 
    app.UseStatusCodePagesWithReExecute("/Error/ErrorHandler/{0}"); 
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
