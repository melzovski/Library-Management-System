using System;
using System.Collections.Generic;

namespace LibMan_c1627015m.Models.DB
{
    public partial class User
    {
        public User()
        {
            Book = new HashSet<Book>();
        }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
