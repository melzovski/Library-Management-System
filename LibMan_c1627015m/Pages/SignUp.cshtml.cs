using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibMan_c1627015m.Models.DB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibMan_c1627015m.Pages
{
    public class SignUpModel : PageModel
    {
        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        public SignUpModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.User.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}