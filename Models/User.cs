using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcTitle.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string Role { get; set; }

        public IList<TitleUser> TitleUsers { get; set; }
    }
}
