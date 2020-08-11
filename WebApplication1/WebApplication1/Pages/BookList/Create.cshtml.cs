﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Model;

namespace WebApplication1.Pages.BookList
{
    public class CreateModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext bd)
        {
            _db = bd;
        }

        [BindProperty]
        public Book book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Books.AddAsync(book);
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