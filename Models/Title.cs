using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
