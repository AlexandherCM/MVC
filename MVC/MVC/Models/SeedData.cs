using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<MVCContext>>()))
            {
                // Look for any movies.
                if (context.Pelicula.Any())
                {
                    return;   // DB ha sido sembrada
                }
                context.Pelicula.AddRange(
                    new Pelicula
                    {
                        Titulo      = "When Harry Met Sally",
                        Lanzamiento = DateTime.Parse("1989-2-12"),
                        Genero      = "Romantic Comedy",
                        Precio      = 7.99M
                    },
                    new Pelicula
                    {
                        Titulo      = "Ghostbusters ",
                        Lanzamiento = DateTime.Parse("1984-3-13"),
                        Genero      = "Comedy",
                        Precio      = 8.99M
                    },
                    new Pelicula
                    {
                        Titulo      = "Ghostbusters 2",
                        Lanzamiento = DateTime.Parse("1986-2-23"),
                        Genero      = "Comedy",
                        Precio      = 9.99M
                    },
                    new Pelicula
                    {
                        Titulo       = "Rio Bravo",
                        Lanzamiento  = DateTime.Parse("1959-4-15"),
                        Genero       = "Western",
                        Precio       = 3.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
