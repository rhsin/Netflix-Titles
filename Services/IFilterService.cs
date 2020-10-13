﻿using MvcTitle.Models;
using System.Linq;

namespace MvcTitle.Services
{
    public interface IFilterService
    {
        public IQueryable<Title> FilterByOption(IQueryable<Title> titles, string titleType, string titleGenre);

        public IQueryable<Title> FilterByText(IQueryable<Title> titles, string searchString, string castString);
    }
}
