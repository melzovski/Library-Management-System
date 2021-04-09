using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibMan_c1627015m.Pages
{

    public class WelcomeModel : PageModel
    {
        public string Username { get; set; }
        public string UserId;

        public void OnGet()
        {
            // UserId = User.FindFirst(ClaimTypes.Name).Value;
            Username = HttpContext.Session.GetString("Username");
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("Username");

            return RedirectToPage("Index");
        }
    }

}