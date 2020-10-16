using System;

namespace MvcTitle.Models
{
    public class TitleUser
    {
        public int TitleId { get; set; }
        public Title Title { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        //public DateTime Date { get; set; }
    }
}
