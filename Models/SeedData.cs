using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTitle.Data;
using MvcTitle.Services;
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
                if (context.User.Any())
                {
                    return;
                }

                var user = new User
                {
                    Name = "Ryan",
                    Email = "ryan@test.com"
                };

                context.User.Add(user);

                context.SaveChanges();

                if (context.Title.Any())
                {
                    return;   
                }

                var csvImporter = new CsvImporter();

                csvImporter.ImportTitles(context);
            }
        }
    }
}
