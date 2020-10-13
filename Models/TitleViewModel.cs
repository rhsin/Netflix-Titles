﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcTitle.Models
{
    public class TitleViewModel
    {
        public List<Title> Titles { get; set; }
        public SelectList Types { get; set; }
        public SelectList Genres { get; set; }
        public string TitleType { get; set; }
        public string TitleGenre { get; set; }
        public string SearchString { get; set; }
        public string CastString { get; set; }
    }
}