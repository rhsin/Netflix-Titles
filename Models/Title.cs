using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTitle.Models
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Cast { get; set; }
        public string Description { get; set; }
    }
}
