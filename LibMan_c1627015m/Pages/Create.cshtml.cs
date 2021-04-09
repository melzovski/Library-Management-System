using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LibMan_c1627015m.Models.DB;

namespace LibMan_c1627015m.Pages
{
    public class CreateModel : PageModel
    {
        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        public CreateModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Username"] = new SelectList(_context.User, "Username", "Username");
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./ListBook");
        }
    }
}
