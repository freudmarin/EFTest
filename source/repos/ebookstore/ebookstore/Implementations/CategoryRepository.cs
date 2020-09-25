using ebookstore.Data;
using ebookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Implementations
{
    public class CategoryRepository : ICategoryRepository
    { 
        private readonly ebookDbContext _context;

        public CategoryRepository(ebookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categories> Categories => _context.Categories.Include(x => x.Books); //include here

        public void Add(Categories category)
        {
            _context.Categories.Add(category);
        }

        public IEnumerable<Categories> GetAll()
        {
            return _context.Categories.ToList();
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Categories GetById(int? id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Categories> GetByIdAsync(int? id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Categories.Any(p => p.Id == id);
        }
      
        public Task<Categories> searchCategory(string categoryName)
        {
       return  _context.Categories.FirstOrDefaultAsync(c => c.Name == categoryName);
        }
        public void Remove(Categories category)
        {
            _context.Remove(category);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Categories category)
        {
            _context.Update(category);
        }
        public bool ExistsCategory(string categoryName)
        {
         return   _context.Categories.Any(c => c.Name == categoryName);
        }
    }
}
