using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XBooks.Models;

namespace XBooks
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public Book Book { get; set; }
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }

        

        public async Task OnGet(int id)
        {
            this.Book = await _db.Book.FindAsync(id);
        }

        public async Task<IActionResult> OnPost(Book book)
        {
            if (ModelState.IsValid)
            {
                var bookFromDB = await _db.Book.FindAsync(book.Id);
                bookFromDB.Name = book.Name;
                bookFromDB.Author = book.Author;
                bookFromDB.ISBN = book.ISBN;

                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}