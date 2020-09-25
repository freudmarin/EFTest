using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Data;
using ebookstore.Implementations;

using ebookstore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ebookstore.Services;

namespace ebookstore.Controllers
{
    public class BooksController : Controller
    {
  

        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;


        public BooksController( IBookService bookService, ICategoryService categoryService)
        {
            
       
            _bookService = bookService;
            _categoryService = categoryService;

          

        }
        public async Task<IActionResult> Index()
        {
            return View(await _bookService.GetAllIncludedAsync());
        }
        [HttpGet]


        public async Task<IActionResult> AddOrEdit(int id)
        {

            if (id == 0)
            {
                //duhet shtuar dhe ketu ViewData 
                //duhej krijuar objekt i ri
                Books books = new Books();

                ViewData["CategoriesId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", books.CategoriesId);
                return View(books);
            }
            else
            {
                var books = await _bookService.GetByIdAsync(id);
                if (books == null)
                {
                    return NotFound();
                }
                ViewData["CategoriesId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", books.CategoriesId);
                return View(books);
            }
        }

        //  [Authorize]
        [HttpPost]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(int id, [Bind("Id,Name,Image,image,Author,Description,Price,CategoriesId")] Books books)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {

                    string fileName = null;
                    if (books.Image != null)
                    {

                        string uploadsFolder = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "images");
                        fileName = Guid.NewGuid().ToString() + "_" + books.Image.FileName;
                        string filePath = Path.Combine(uploadsFolder, fileName);
                        books.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                        books.image = fileName;
                    }

                    ViewData["CategoriesId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", books.CategoriesId);

                    _bookService.Add(books);
                    await _bookService.SaveChangesAsync();
                }
                else
                {
                    ViewData["CategoriesId"] = new SelectList(_categoryService.GetAll(), "Id", "Name", books.CategoriesId);
                    try
                    {


                        _bookService.Update(books);

                        await _bookService.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!BooksExists(books.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "ViewAll", _bookService.Books.ToList()) });




            }
            //this -> per controllerin

            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", books) });
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var books = await _bookService.GetByIdIncludedAsync(id);

            if (books == null)
            {
                return NotFound();
            }

            return View(books);
        }


        [HttpPost, ActionName("Delete")]

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var books = await _bookService.GetByIdAsync(id);
            _bookService.Remove(books);
            await _bookService.SaveChangesAsync();


            return Json(new { html = Helper.RenderRazorViewToString(this, "ViewAll", _bookService.Books.ToList()) });
        }
        private bool BooksExists(int id)
        {
            return _bookService.Exists(id);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ListCategory(string categoryName)
        {



          
            
            bool categoryExtist = _categoryService.ExistsCategory(categoryName); 
            if (!categoryExtist)
            {
                return NotFound();
            }

            Categories   category = await _categoryService.SearchCategoryName(categoryName);

            if (category == null)
            {
                return NotFound();
            }

            bool anyBooks = await _bookService.booksInCategory(category);
            if (!anyBooks)
            {
                return NotFound($"Nuk u gjeten libra ne kategorine : {categoryName}");
            }

            var books = _bookService.GetByCategoryIncluded(category.Name);

            ViewBag.CurrentCategory = category;
            return View(books);
        }
    }
}
