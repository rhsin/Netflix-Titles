using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcTitle.Models
{
    public class Title
    {
        public int Id { get; set; }

        [Required, StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, StringLength(30)]
        public string Type { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [StringLength(50)]
        public string Genre { get; set; }

        public string Cast { get; set; }

        public string Description { get; set; }
    }
}
