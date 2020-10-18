using System.IO;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using MvcTitle.Data;
using MvcTitle.Models;

namespace MvcTitle.Services
{
    public interface ICsvImporter
    {
        public void ImportTitles(MvcTitleContext context);
    }

    public class CsvImporter : ICsvImporter
    {
        public void ImportTitles(MvcTitleContext context)
        {
            using (var reader = new StreamReader(@"C:\Users\Ryan\source\repos\MvcTitle\Models\netflix_titles.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
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

    public class TitleMap : ClassMap<Title>
    {
        public TitleMap()
        {
            Map(m => m.Name).Name("title");
            Map(m => m.Type).Name("type");
            Map(m => m.ReleaseDate).Name("release_year");
            Map(m => m.Genre).Name("listed_in");
            Map(m => m.Cast).Name("cast");
            Map(m => m.Description).Name("description");
        }
    }
}
