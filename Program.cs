
using Market.Data;
using Market.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("UsersDB");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<UserDataContext>(options => options.UseSqlite(connectionString));
builder.Services.AddSingleton<SimulatedDataProviderService>();
builder.Services.AddScoped<WebsiteAuthenticator>();
builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<WebsiteAuthenticator>());
builder.Services.AddAuthorization(config =>
{
    config.AddPolicy("CanBuyWeapon", policy =>
    {
        policy.AddRequirements(new AdultRequirement());
        policy.RequireClaim("IsPremiumMember", true.ToString());
    });

    config.AddPolicy("OverAge", policy => policy.AddRequirements(new OverAgeRequirement()));
});

builder.Services.AddSingleton<IAuthorizationHandler, AdultRequirementHandler>();
builder.Services.AddSingleton<IAuthorizationHandler, OverAgeRequirementHandler>();

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

app.UseAuthentication();
app.UseAuthorization();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
