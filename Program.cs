using ManagementSystem.Models;
using ManagementSystem.Models.DTOs;
using ManagementSystem.Repositories;
using ManagementSystem.Repositories.Interfaces;
using ManagementSystem.Services;
using ManagementSystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRepository<Footwear, FootwearGetAllDTO>, FootwearRepository>();
builder.Services.AddSingleton<IService<Footwear, FootwearGetAllDTO>, FootwearService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
