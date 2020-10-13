using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcTitle.Data;
using MvcTitle.Mappers;
using System;
using System.IO;
using System.Globalization;
using System.Linq;
using CsvHelper;

namespace MvcTitle.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcTitleContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcTitleContext>>()))
            using (var reader = new StreamReader(@"C:\Users\Ryan\source\repos\MvcTitle\Models\netflix_titles.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Look for any titles.
                if (context.Title.Any())
                {
                    return;   // DB has been seeded
                }

                csv.Configuration.RegisterClassMap<TitleMap>();

                var titles = csv.GetRecords<Title>();

                foreach (var title in titles)
                {
                    context.Title.Add(title);
                }
                
                context.SaveChanges();
            }
        }
    }
}
