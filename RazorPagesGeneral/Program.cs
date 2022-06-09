using RazorPagesLearning.Services;
using RazorPagesLearning.Services.EventRepository;
using RazorPagesLearning.Services.LocationRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

//builder.Services.AddDbContext<AppDBContext>(options => { options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;DataBase=loqaciadb;Trusted_Connection=True"); });
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IEventRepository, MockEventRepository>();
builder.Services.AddSingleton<ILocationRepository, MockLocationRepository>();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
