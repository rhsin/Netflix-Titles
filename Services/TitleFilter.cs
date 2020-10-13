using MvcTitle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTitle.Services
{
    public class TitleFilter : IFilterService
    {
        public IQueryable<Title> FilterBy(IQueryable<Title> titles, string titleType,
            string titleGenre, string searchString, string castString)
        {
            if (!String.IsNullOrEmpty(titleType))
            {
                titles = titles.Where(t => t.Type == titleType);
            }

            if (!String.IsNullOrEmpty(titleGenre))
            {
                titles = titles.Where(t => t.Genre == titleGenre);
            }

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
