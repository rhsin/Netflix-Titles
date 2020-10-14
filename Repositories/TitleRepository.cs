using MvcTitle.Models;
using System;
using System.Linq;

namespace MvcTitle.Repositories
{
    public interface ITitleRepository
    {
        public IQueryable<Title> FilterByOption(IQueryable<Title> titles, string titleType,
            string titleGenre, string titleDate);

        public IQueryable<Title> FilterByText(IQueryable<Title> titles, string searchString,
            string castString, string descString);
    }

    public class TitleRepository : ITitleRepository
    {
        public IQueryable<Title> FilterByOption(IQueryable<Title> titles, string titleType, string titleGenre, string titleDate)
        {
            if (!String.IsNullOrEmpty(titleType))
            {
                titles = titles.Where(t => t.Type == titleType);
            }

            if (!String.IsNullOrEmpty(titleGenre))
            {
                titles = titles.Where(t => t.Genre == titleGenre);
            }

            if (!String.IsNullOrEmpty(titleDate))
            {
                titles = titles.Where(t => t.ReleaseDate == titleDate);
            }

            return titles;
        }

        public IQueryable<Title> FilterByText(IQueryable<Title> titles, string searchString, string castString, string descString)
        {
            if (!String.IsNullOrEmpty(searchString))
            {
                titles = titles.Where(t => t.Name.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(castString))
            {
                titles = titles.Where(t => t.Cast.Contains(castString));
            }

            if (!String.IsNullOrEmpty(descString))
            {
                titles = titles.Where(t => t.Description.Contains(descString));
            }

            return titles;
        }
    }
}
