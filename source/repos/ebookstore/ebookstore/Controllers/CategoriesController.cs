using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Data;
using ebookstore.Implementations;
using ebookstore.Models;
using ebookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ebookstore.Controllers
{
    public class CategoriesController : Controller
    {




        private readonly ICategoryService _categoryService;

        public CategoriesController( ICategoryService categoryservice)
        {
         
            _categoryService = categoryservice;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            return  View(await _categoryService.GetAllAsync());
        }


        // GET: Categories/Details/5

       
            // GET: Employee/Create
            public IActionResult AddOrEdit(int id = 0)
            {
                if (id == 0)
                    return View(new Categories());
                else
                    return View( _categoryService.GetById(id));
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> AddOrEdit([Bind("Id,Name,Description")] Categories category)
            {
                if (ModelState.IsValid)
                {
                    if (category.Id == 0)
                        _categoryService.Add(category);
                    else
                        _categoryService.Update(category);
                    await _categoryService.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(category);
            }

            // GET: Employee/Delete/5
            public async Task<IActionResult> Delete(int? id)
            {
            var categories = await _categoryService.GetByIdAsync(id);
         _categoryService.Remove(categories);
                await _categoryService.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
  
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categories = await _categoryService.GetByIdAsync(id);
            _categoryService.Remove(categories);
            await _categoryService.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        private bool CategoriesExists(int id)
        {
            return _categoryService.Exists(id);
        }
    }
}
