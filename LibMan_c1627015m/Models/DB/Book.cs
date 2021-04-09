using System;
using System.Collections.Generic;

namespace LibMan_c1627015m.Models.DB
{
    public partial class Book
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Tittle { get; set; }
        public string Author { get; set; }
        public string Translator { get; set; }
        public string Publisher { get; set; }
        public string BookDescription { get; set; }
        public string BookCover { get; set; }
        public string Categories { get; set; }
        public string ReadingStatus { get; set; }

        public virtual User UsernameNavigation { get; set; }
    }
}
