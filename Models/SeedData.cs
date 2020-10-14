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
                // Look for any titles.
                if (context.Title.Any())
                {
                    return;   // DB has been seeded
                }

                var csvImporter = new CsvImporter();

                csvImporter.ImportTitles(context);
            }
        }
    }
}
