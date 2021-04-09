using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Newtonsoft.Json.Linq;
using LibMan_c1627015m.Models.DB;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Formatters;
using LibMan_c1627015m.Models;

namespace LibMan_c1627015m.Pages
{
    public class JSONModel : PageModel
    {

        private readonly LibMan_c1627015m.Models.DB.libContext _context;
        private IWebHostEnvironment _environment;

        public JSONModel(LibMan_c1627015m.Models.DB.libContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public Book Book { get; set; }
        public string Username { get; set; }

        [BindProperty]
        public IFormFile File { get; set; }

        public IList<Book> Bookk { get; set; }

        public void OnGet()
        {

        }


        public void OnPostImport()
        {
            var path = Path.Combine(_environment.WebRootPath, "Upload", File.FileName);

            using (var f_stream = new FileStream(path, FileMode.Create))
            {
                f_stream.Position = 0;
                f_stream.Flush();
                File.CopyTo(f_stream);

            }

            using (StreamReader new_stream = new StreamReader(path))
            {
                string json = new_stream.ReadToEnd();
                JObject obj = JObject.Parse(json);
                JArray arr = (JArray)obj["Book"];
                IList<Book> books = arr.ToObject<IList<Book>>();
                string username = HttpContext.Session.GetString("Username");
                var userr = _context.User.Single(a => a.Username == username);
                foreach (var item in books)
                {
                    var book = new Book()
                    {
                       
                        Tittle = item.Tittle,
                        Author = item.Author,
                        Translator = item.Translator,
                        Publisher = item.Publisher,
                        BookDescription = item.BookDescription,
                        BookCover = item.BookCover,
                        Categories = item.Categories,
                        ReadingStatus = item.ReadingStatus,
                        Username = item.Username
                    };
                    _context.Book.Add(book);
                    _context.SaveChanges();
                }
            }
        }

        public void OnPostExport()
        {
            string name_of_file = Request.Form["File_Name"];
            string format = ".json";
            var path = Path.Combine(@"C:\Users\yildi\OneDrive\Masaüstü\export", name_of_file);
            var final_path = String.Concat(path, format);
            Username = HttpContext.Session.GetString("Username");
            Bookk = _context.Book.Where(b => b.Username == Username).ToList();
            string json = JsonConvert.SerializeObject(Bookk, Formatting.Indented);
            System.IO.File.WriteAllText(final_path, json);
        }
    }
}