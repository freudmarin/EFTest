using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ebookstore.Models;
using ebookstore.Data;

namespace ebookstore.Controllers
{
    public class HomeController : Controller
    {

        private readonly ebookDbContext _context;
        public HomeController(ebookDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            List<Books> listOfBooks = _context.Books.ToList();

            return View(listOfBooks);
        }

       

  
    }
}
