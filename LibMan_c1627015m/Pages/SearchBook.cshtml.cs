using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMan_c1627015m.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace LibMan_c1627015m.Pages
{
    public class SearchBookModel : PageModel
    {

        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        public string Tittle { get; set; }

        public SearchBookModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public string Username { get; set; }

        public async Task OnGetAsync()
        {

            Username = HttpContext.Session.GetString("Username");
            var books = from b in _context.Book
                         select b;
            if (!string.IsNullOrEmpty(SearchString))
            {
                books = books.Where(s => s.Tittle.Contains(SearchString));
            }
            Book = await books.ToListAsync();
        }

        

      
    }
}