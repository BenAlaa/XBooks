using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using XBooks.Models;

namespace XBooks
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public Book Book { get; set; }
        public void OnGet()
        {

        }
    }
}