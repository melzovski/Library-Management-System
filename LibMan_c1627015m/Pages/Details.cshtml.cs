using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LibMan_c1627015m.Models.DB;

namespace LibMan_c1627015m.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        public DetailsModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.UsernameNavigation).FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
