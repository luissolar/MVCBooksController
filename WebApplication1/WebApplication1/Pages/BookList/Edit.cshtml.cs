using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.BookList
{
    public class EditModel : PageModel
    {

        private ApplicationDbContext _db { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book book { get; set; }
        public async Task OnGet(int id)
        {
            book = await _db.Books.FindAsync(id);

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
              var BookFromDb=  await _db.Books.FindAsync(book.Id);
                BookFromDb.Name = book.Name;
                BookFromDb.ISBN = book.ISBN;
                BookFromDb.Author = book.Author;
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {

                return Page();
            }

        }
    }
}