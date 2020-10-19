using System;
using System.Collections.Generic;
using System.Linq;
using MvcTitle.Data;
using MvcTitle.Models;

namespace MvcTitle.Repositories
{
    public interface ITitleRepository
    {
        public List<Title> GetTitles();

        public IDictionary<string, IQueryable<string>> GetQuery();

        public IQueryable<Title> Filter(string titleType, string titleGenre, string titleDate, 
            string searchString, string castString, string descString);

        public IQueryable<Title> Order(IQueryable<Title> titles, string order);
    }

    public class TitleRepository : ITitleRepository
    {
        private readonly MvcTitleContext _context;

        public TitleRepository(MvcTitleContext context)
        {
            _context = context;
        }

        public List<Title> GetTitles()
        {
            IQueryable<Title> titles = from t in _context.Title
                                       select t;

            return titles.Take(50).ToList();
        }

        public IDictionary<string, IQueryable<string>> GetQuery()
        {
            IQueryable<string> genreQuery = from t in _context.Title
                                            orderby t.Genre
                                            select t.Genre;

            IQueryable<string> typeQuery = from t in _context.Title
                                           select t.Type;

            IQueryable<string> dateQuery = from t in _context.Title
                                           orderby t.ReleaseDate
                                           select t.ReleaseDate;

            IDictionary<string, IQueryable<string>> query = new Dictionary<string, IQueryable<string>>();

            query.Add("genre", genreQuery);
            query.Add("type", typeQuery);
            query.Add("date", dateQuery);

            return query;
        }

        public IQueryable<Title> Filter(string titleType, string titleGenre, string titleDate, 
            string searchString, string castString, string descString)
        {
            IQueryable<Title> titles = from t in _context.Title
                                       select t;

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

        public IQueryable<Title> Order(IQueryable<Title> titles, string order)
        {
            switch (order)
            {
                case "date_asc":
                    titles = titles.OrderBy(t => t.ReleaseDate);
                    break;
                case "date_desc":
                    titles = titles.OrderByDescending(t => t.ReleaseDate);
                    break;
                default:
                    break;
            }

            return titles;
        }
    }
}
