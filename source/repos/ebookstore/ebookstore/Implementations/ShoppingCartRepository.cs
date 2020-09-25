using ebookstore.Data;
using ebookstore.Migrations.Models;
using ebookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ebookstore.Implementations
{


}
  /*  public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ebookDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public string ShoppingCartId { get; set; }
        public ShoppingCartRepository(ebookDbContext context)
        {
            _db = context;
          
        }
  

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public   ShoppingCartItem FindCartItems(Books book, string ShoppingCartId)
        
        {
        
            return   _db.ShoppingCartItems.SingleOrDefault(
                 s => s.Book.Id == book.Id && s.ShoppingCartId == ShoppingCartId);
        }
        public void Add(ShoppingCartItem item)
        {
            _db.ShoppingCartItems.Add(item);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
        public void Remove(ShoppingCartItem item)
        {
            _db.ShoppingCartItems.Remove(item);
        }
        public List<ShoppingCartItem> GetCartItem(string ShoppingCartId)
        {
            //var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return ShoppingCartItems ??(ShoppingCartItems =
               _db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)//.Where(c=>c.userId==userId)
                                   .Include(s => s.Book)
                                   .ToList());
        }
        public List<ShoppingCartItem> GetByCartId(string shoppingCartID)
        {
            return _db.ShoppingCartItems
                        .Where(cart => cart.ShoppingCartId == shoppingCartID).ToList();
        }
        public void RemoveRange(List<ShoppingCartItem> cartItems)
        {
            _db.ShoppingCartItems.RemoveRange(cartItems);
        }
      public   decimal GetShoppingCartTotal(string shoppingCartId)
        {
       return      _db.ShoppingCartItems.Where(c => c.ShoppingCartId == shoppingCartId)
                    .Select(c => c.Book.Price * c.Amount).Sum();
        }
    }
}
*/