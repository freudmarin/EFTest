using ebookstore.Implementations;
using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Services
{
    public class BookService : IBookService 
    {
        IBookRepository repository;

        public BookService(IBookRepository r)
        {
            this.repository = r;
        }

        public IEnumerable<Books> Books => repository.Books; //include here



        // public IEnumerable<Books> Books => throw new NotImplementedException();

        // public IEnumerable<Books> BooksOfTheWeek => throw new NotImplementedException();

        public void Add(Books book)
        {
           
            repository.Add(book);
        }

        public IEnumerable<Books> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<IEnumerable<Books>> GetAllAsync()
        {
            return await GetAllAsync();
        }

        public async Task<IEnumerable<Books>> GetAllIncludedAsync()
        {
            return await repository.GetAllIncludedAsync();
        }

        public IEnumerable<Books> GetAllIncluded()
        {
            return repository.GetAllIncluded();
        }

        public Books GetById(int? id)
        {
            return repository.GetById(id);
        }

     

        public Books GetByIdIncluded(int? id)
        {
            return repository.GetByIdIncluded(id);
        }
     public    Task<Books> GetByIdAsync(int? id)
        {
            return repository.GetByIdAsync(id);
        }
        public async Task<Books> GetByIdIncludedAsync(int? id)
        {
            return await repository.GetByIdIncludedAsync(id);
        }
        public bool Exists(int id)
        {
                return repository.Exists(id);
        }

      public   List<Books> GetByCategoryIncluded(string categoryName)

        {
            return repository.GetByCategoryIncluded(categoryName);
        }
     public    List<Books> BookSearch(string userInput)
        {
            return repository.BookSearch(userInput);
        }
        public async Task<bool> booksInCategory(Categories category)
        {
            return await repository.booksInCategory(category);
        }
        public void Remove(Books book)
        {
            repository.Remove(book);
        }

        public async Task SaveChangesAsync()
        {
            await repository.SaveChangesAsync();
        }
     

        public void SaveChanges()
        {
            repository.SaveChanges();
        }

        public void Update(Books book)
        {
            repository.Update(book);
        }


    }
}

