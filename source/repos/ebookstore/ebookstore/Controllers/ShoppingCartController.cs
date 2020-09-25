﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ebookstore.Data;
using ebookstore.Implementations;
using ebookstore.Migrations.Models;
using ebookstore.Models;
using ebookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace ebookstore.Controllers
{


    public class ShoppingCartController : Controller
    
    
    { 


    private readonly IBookRepository _bookRepository;
    private readonly ebookDbContext _context;
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartController(IBookRepository bookRepository,
        ShoppingCart shoppingCart, ebookDbContext context)
    {
        _bookRepository = bookRepository;
        _shoppingCart = shoppingCart;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var items = await _shoppingCart.GetShoppingCartItemsAsync();
        _shoppingCart.ShoppingCartItems = items;

       
            var shoppingCartViewModel = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };

        return View(shoppingCartViewModel);
    }

    public async Task<IActionResult> AddToShoppingCart(int bookId)
    {
        var selectedBook = await _bookRepository.GetByIdAsync(bookId);

        if (selectedBook != null)
        {
            await _shoppingCart.AddToCartAsync(selectedBook, 1);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> RemoveFromShoppingCart(int bookId)
    {
        var selectedBook = await _bookRepository.GetByIdAsync(bookId);

        if (selectedBook != null)
        {
            await _shoppingCart.RemoveFromCartAsync(selectedBook);
        }
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> ClearCart()
    {
        await _shoppingCart.ClearCartAsync();

        return RedirectToAction("Index");
    }

}
    }