using MvcTitle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTitle.Services
{
    public class TitleFilter
    {
        private IQueryable<Title> _titles;
        public TitleFilter(IQueryable<Title> titles)
        {
            _titles = titles;
        }

        public IQueryable<Title> FilterBy(string titleType, string titleGenre, string searchString, string castString)
        {
            if (!String.IsNullOrEmpty(titleType))
            {
                _titles = _titles.Where(t => t.Type == titleType);
            }

            if (!String.IsNullOrEmpty(titleGenre))
            {
                _titles = _titles.Where(t => t.Genre == titleGenre);
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                _titles = _titles.Where(t => t.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(castString))
            {
                _titles = _titles.Where(t => t.Cast.Contains(castString));
            }

            return _titles;
        }
    }
}
