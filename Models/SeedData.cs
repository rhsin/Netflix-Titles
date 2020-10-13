using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTitle.Data;
using System;
using System.Linq;

namespace MvcTitle.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTitleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTitleContext>>()))
            {
                // Look for any titles.
                if (context.Title.Any())
                {
                    context.Title.RemoveRange(context.Title);   // Remove titles if DB has been seeded
                    context.SaveChanges();
                }

                context.Title.AddRange(
                    new Title
                    {
                        Name = "When Harry Met Sally",
                        Type = "Movie",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy"
                    },

                    new Title
                    {
                        Name = "Ghostbusters ",
                        Type = "Movie",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Cast = "Bill Murray",
                        Description = "Busting Ghosts"
                    },

                    new Title
                    {
                        Name = "Ghostbusters 2",
                        Type = "Movie",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Cast = "Kirsten Wiig, Kate Mckinnon",
                        Description = "Busting Ghosts Again"
                    },

                    new Title
                    {
                        Name = "Rio Bravo",
                        Type = "Movie",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Description = "Cowboy Stuff"
                    },

                    new Title
                    {
                        Name = "The Highwaymen",
                        Type = "Movie",
                        ReleaseDate = DateTime.Parse("2019-3-15"),
                        Genre = "Action",
                        Cast = "Kevin Costner, Woody Harelson",
                        Description = "Bonnie & Clyde Hunt"
                    },

                    new Title
                    {
                        Name = "The Stranger",
                        Type = "TV Show",
                        ReleaseDate = DateTime.Parse("2020-6-15"),
                        Genre = "Thriller",
                        Cast = "Richard Armitage",
                        Description = "Mediocre Murder Mystery"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
