using Microsoft.EntityFrameworkCore;
using PruebasCore.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyecci�n de dependencias - - - - - - - - - - - - - - - - - - - - 
builder.Services.AddDbContext<Modelo>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NewContext"))
);
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
