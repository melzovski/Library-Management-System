using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan_c1627015m.Models.DB;
using Microsoft.AspNetCore.Http;

namespace LibMan_c1627015m.Pages
{
    public class ListBookModel : PageModel
    {
        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        public string Username { get; set; }

        public ListBookModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book
                .Include(b => b.UsernameNavigation).ToListAsync();
            Username = HttpContext.Session.GetString("Username");
        }
    }
}