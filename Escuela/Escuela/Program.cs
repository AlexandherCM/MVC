using Escuela.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Inyección de dependencias - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
builder.Services.AddDbContext<MvcContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ModeloContext"));
});
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

var app = builder.Build();

// Ambito - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 
//Podemos acceder a ciertas propiedades de la aplicación
using (var scope = app.Services.CreateScope())
{
    var Context = scope.ServiceProvider.GetRequiredService<MvcContext>();
    Context.Database.Migrate();
}
// - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -

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
