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
    public class IndexModel : PageModel
    {
        private readonly LibMan_c1627015m.Models.DB.libContext _context;

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public string Msg { get; set; }

        public IndexModel(LibMan_c1627015m.Models.DB.libContext context)
        {
            _context = context;
        }

        public IList<User> User { get; set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
        private bool UserExists(string Username, string password)
        {
            bool usern = false, pass = false;
            usern = _context.User.Any(e => e.Username == Username);
            pass = _context.User.Any(e => e.Password == password);
            if (usern == true && pass == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IActionResult OnPost()
        {
            if (UserExists(Username, Password))
            {
                //HttpContext.Session.SetString("username", Username);
                var user = _context.User.Single(a => a.Username == Username);
                HttpContext.Session.SetString("Username", user.Username);
                // return RedirectToPage("Welcome");
                return RedirectToPage("Welcome");
            }
            else
            {
                Msg = "Invalid";
                return Page();
            }
        }

    }
}


