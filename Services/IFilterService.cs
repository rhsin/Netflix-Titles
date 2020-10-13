using MvcTitle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcTitle.Services
{
    public interface IFilterService
    {
        public IQueryable<Title> FilterBy(IQueryable<Title> titles, string titleType,
            string titleGenre, string searchString, string castString);
    }
}
