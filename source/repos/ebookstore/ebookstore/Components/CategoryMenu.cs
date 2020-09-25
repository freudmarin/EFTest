using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ebookstore.Data;
using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Components
    {
        public class CategoryMenu : ViewComponent
        {
            private readonly ebookDbContext _context;
            public CategoryMenu(ebookDbContext context)
            {
                _context = context;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(categories);
            }
        }
    }


