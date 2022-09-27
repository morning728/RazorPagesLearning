using RazorPagesLearning.Services;
using RazorPagesLearning.Services.EventRepository;
using RazorPagesLearning.Services.LocationRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<AppDBContext>();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IEventRepository, SQLEventRepository>();
//builder.Services.AddSingleton<IEventRepository, MockEventRepository>();
builder.Services.AddScoped<ILocationRepository, SQLLocationRepository>();
//builder.Services.AddSingleton<ILocationRepository, MockLocationRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/LoginPage");
                });

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
