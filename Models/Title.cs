using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTitle.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Type { get; set; }

        [StringLength(30)]
        public string ReleaseDate { get; set; }

        public string Genre { get; set; }

        public string Cast { get; set; }

        public string Description { get; set; }

        public IList<TitleUser> TitleUsers { get; set; }
    }
}
