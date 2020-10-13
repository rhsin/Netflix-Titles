using MvcTitle.Models;
using System;
using System.Linq;

namespace MvcTitle.Services
{
    public class TitleFilter : IFilterService
    {
        public IQueryable<Title> FilterByOption(IQueryable<Title> titles, string titleType, string titleGenre)
        {
            if (!String.IsNullOrEmpty(titleType))
            {
                titles = titles.Where(t => t.Type == titleType);
            }

            if (!String.IsNullOrEmpty(titleGenre))
            {
                titles = titles.Where(t => t.Genre == titleGenre);
            }

            return titles;
        }

        public IQueryable<Title> FilterByText(IQueryable<Title> titles, string searchString, string castString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                titles = titles.Where(t => t.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(castString))
            {
                titles = titles.Where(t => t.Cast.Contains(castString));
            }

            return titles;
        }
    }
}
