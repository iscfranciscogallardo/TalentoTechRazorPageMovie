using Microsoft.EntityFrameworkCore;
using RazorPageMovie.Data;

namespace RazorPageMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPageMovieContext(serviceProvider.GetRequiredService<DbContextOptions<RazorPageMovieContext>>()))
            {
                //en caso de un contexto nulo se regresa un error
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPageMovie");
                }

                if (context.Movie.Any())
                {
                    //La base de datos muestra lo que contiene esta clase
                    return;
                }

                context.Movie.AddRange(
                        new Movie() { Title = "When Harry met Sally", RealeaseDate = DateTime.Parse("1989-02-12"), Genre = "Romantic Comedy", Price = 7.99M, Rating= "R"}
                        , new Movie() { Title = "Ghostbusters", RealeaseDate = DateTime.Parse("1984-03-13"), Genre = "Comedy", Price = 8.99M, Rating = "G" }
                        , new Movie() { Title = "Ghostbusters 2", RealeaseDate = DateTime.Parse("1989-02-23"), Genre = "Comedy", Price = 9.99M, Rating = "G" }
                        , new Movie() { Title = "Rio Bravo", RealeaseDate = DateTime.Parse("1959-04-15"), Genre = "Western", Price = 3.99M, Rating = "NA" }
                    );
                context.SaveChanges();
            }
        }
    }
}

