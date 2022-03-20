using LinkShortener.Model.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using LinkShortener.Services.Interfaces;
using LinkShortener.Services;
using LinkShortener.DTOs;

var builder = WebApplication.CreateBuilder(args);
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
builder.Services.AddRazorPages();

// Add Database Context
builder.Services.AddDbContext<LinkShortenerContext>(options =>
{
    options.UseSqlServer(config.GetRequiredSection("ConnectionStrings").Get<ConnectionStrings>().LinkShortenerCS!);
});

// Add Cookie Based Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromDays(14);
        options.AccessDeniedPath = "/Login";
    });

// IoC and shit which i don't understand
#region Inverion Of Control

builder.Services.AddTransient<ILinkService, LinkService>();
builder.Services.AddTransient<IUserService, UserService>();

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
