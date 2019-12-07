using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using XBooks.Models;

namespace XBooks
{
    public class UpsertModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Book Book { get; set; }
        public UpsertModel(ApplicationDBContext db)
        {
            _db = db;
        }



        public async Task<IActionResult> OnGet(int? id)
        {
            this.Book = new Book();
            if (id == null)
            {
                // Create
                return Page();
            }

            // Update
            this.Book = await _db.Book.FirstOrDefaultAsync(b => b.Id == id);
            if (this.Book == null)
            {
                return NotFound();
            }
            return Page();
            
            this.Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                if (book.Id == 0)
                {
                    _db.Book.Add(book);
                }
                else
                {
                    _db.Book.Update(book);
                }

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}