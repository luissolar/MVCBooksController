using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Pages.BookList
{
    public class IndexModel : PageModel
    {
        //1
        private readonly ApplicationDbContext _db;

        //2
        public IndexModel(ApplicationDbContext bd)
        {
            _db = bd;
        }

        //3
        public IEnumerable<Book> books { get; set; }

        //4
        public async Task OnGet()
        {
            books = await _db.Books.ToListAsync();
        }


        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookfromDB = await _db.Books.FindAsync(id);
            if(BookfromDB == null)
            {
                return NotFound();

            }
            else
            {
                _db.Books.Remove(BookfromDB);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
        }

    }
}