using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Data;
using ebookstore.Implementations;
using ebookstore.Models;
using ebookstore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ebookstore.Controllers
{
    public class ShopController : Controller
    {


        private readonly IBookService _bookService;
        public ShopController(IBookService bookService)
        {

            _bookService = bookService;
        }
        /*   public async Task<IActionResult> SearchBooks()
            {
                var model = new SearchBooksViewModel()
                {
                    BookList = await _bookRepo.GetAllIncludedAsync(),
                    search = null
                };

                return View(model);
            }*/
        [AllowAnonymous]
        public async Task<IActionResult> ListAll(int PageNo,string search = " ")
        {
                

      
            List<Books> bookList = await GetBookSearchList(search);
            int NoOfRecordsPerPage = 3;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(bookList.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
           bookList = bookList.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();
            return View(bookList);
        }

        private async Task<List<Books>> GetBookSearchList(string userInput)
        {
            if (userInput != null)
            {
                string usrInput = userInput.ToLower().Trim();

                var result = _bookService.BookSearch(userInput);
                return result;

            
            }
            else
                return new List<Books>();
        }
    }
}

      /*  [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> AjaxSearchList(string search)
        {
           List<Books> bookList = await GetBookSearchList(search);

            return View(bookList);
        }
    }
}*/
