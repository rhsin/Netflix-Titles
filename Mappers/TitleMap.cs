using CsvHelper.Configuration;
using MvcTitle.Models;

namespace MvcTitle.Mappers
{
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
