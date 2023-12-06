using Microsoft.EntityFrameworkCore;
using CRUD_Projekt.Data;

namespace CRUD_Projekt.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CRUD_ProjektContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CRUD_ProjektContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }
                if (context.Movie.Any())
                {
                    return;
                }
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Forrest Gump",
                        ReleaseDate = DateTime.Parse("1994-7-6"),
                        Genre = "Drama",
                        Director = "Robert Zemeckis",
                        Language = "English",
                        Duration = 142,
                        Rating = 8.8M
                    },
                    new Movie
                    {
                        Title = "Parasite",
                        ReleaseDate = DateTime.Parse("2019-5-30"),
                        Genre = "Thriller",
                        Director = "Bong Joon-ho",
                        Language = "Korean",
                        Duration = 132,
                        Rating = 8.6M
                    },
                    new Movie
                    {
                        Title = "The Shawshank Redemption",
                        ReleaseDate = DateTime.Parse("1994-9-23"),
                        Genre = "Drama",
                        Director = "Frank Darabont",
                        Language = "English",
                        Duration = 142,
                        Rating = 9.3M
                    },
                    new Movie
                    {
                        Title = "The Godfather",
                        ReleaseDate = DateTime.Parse("1972-3-24"),
                        Genre = "Crime",
                        Director = "Francis Ford Coppola",
                        Language = "English",
                        Duration = 175,
                        Rating = 9.2M
                    },
                    new Movie
                    {
                        Title = "Pulp Fiction",
                        ReleaseDate = DateTime.Parse("1994-10-14"),
                        Genre = "Crime",
                        Director = "Quentin Tarantino",
                        Language = "English",
                        Duration = 154,
                        Rating = 8.9M
                    },
                    new Movie
                    {
                        Title = "Schindler's List",
                        ReleaseDate = DateTime.Parse("1993-12-15"),
                        Genre = "Historical Drama",
                        Director = "Steven Spielberg",
                        Language = "English",
                        Duration = 195,
                        Rating = 8.9M
                    },
                    new Movie
                    {
                        Title = "Interstellar",
                        ReleaseDate = DateTime.Parse("2014-11-7"),
                        Genre = "Science Fiction",
                        Director = "Christopher Nolan",
                        Language = "English",
                        Duration = 169,
                        Rating = 8.6M
                    },
                    new Movie
                    {
                        Title = "The Dark Knight",
                        ReleaseDate = DateTime.Parse("2008-7-18"),
                        Genre = "Action",
                        Director = "Christopher Nolan",
                        Language = "English",
                        Duration = 152,
                        Rating = 9.0M
                    },
                    new Movie
                    {
                        Title = "Fight Club",
                        ReleaseDate = DateTime.Parse("1999-10-15"),
                        Genre = "Drama",
                        Director = "David Fincher",
                        Language = "English",
                        Duration = 139,
                        Rating = 8.8M
                    },
                    new Movie
                    {
                        Title = "The Lord of the Rings: The Return of the King",
                        ReleaseDate = DateTime.Parse("2003-12-17"),
                        Genre = "Fantasy",
                        Director = "Peter Jackson",
                        Language = "English",
                        Duration = 201,
                        Rating = 8.9M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
