using ebookstore.Data;
using ebookstore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly ebookDbContext _context;

        public BookRepository(ebookDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Books> Books => _context.Books.Include(p => p.Category); //include here



        // public IEnumerable<Books> Books => throw new NotImplementedException();

        // public IEnumerable<Books> BooksOfTheWeek => throw new NotImplementedException();

        public void Add(Books book)
        {
            _context.Add(book);
        }

        public IEnumerable<Books> GetAll()
        {
            return _context.Books.ToList();
        }

        public async Task<IEnumerable<Books>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Books>> GetAllIncludedAsync()
        {
            return await _context.Books.Include(p => p.Category).ToListAsync();
        }

        public IEnumerable<Books> GetAllIncluded()
        {
            return _context.Books.Include(p => p.Category).ToList();
        }

        public Books GetById(int? id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Books> GetByIdAsync(int? id)
        {
            return await _context.Books.FirstOrDefaultAsync(p => p.Id == id);
        }

        public Books GetByIdIncluded(int? id)
        {
            return _context.Books.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }
        public List<Books> GetByCategoryIncluded(string categoryName)

        {
            return _context.Books.Include(c => c.Category).Where(c => c.Category.Name == categoryName).ToList();
        }
        public List<Books>  BookSearch(string userInput)

        {
         return    _context.Books.Include(p => p.Category)
                                .Where(p => p.Name.ToLower().Contains(userInput)).ToList();
        }
        public async Task<Books> GetByIdIncludedAsync(int? id)
        {
            return await _context.Books.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
        }

        public bool Exists(int id)
        {
            return _context.Books.Any(p => p.Id == id);
        }
        public bool ExistsCategory(string categoryName)
        {
            return _context.Books.Any(c => c.Category.Name == categoryName);
        }
        public void Remove(Books book)
        {
            _context.Remove(book);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Books book)
        {
            _context.Update(book);
        }

  
        
        
        public Task<bool> booksInCategory(Categories category)
        {
            return _context.Books.AnyAsync(x => x.Category == category);
        }

      
    }
}