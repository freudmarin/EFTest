using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Implementations
{
    public interface IBookRepository
    {
        IEnumerable<Books> Books { get; }
      

        Books GetById(int? id);
        Task<Books> GetByIdAsync(int? id);

        Books GetByIdIncluded(int? id);
        Task<Books> GetByIdIncludedAsync(int? id);

        bool Exists(int id);

        IEnumerable<Books> GetAll();
        Task<IEnumerable<Books>> GetAllAsync();

        IEnumerable<Books> GetAllIncluded();
        Task<IEnumerable<Books>> GetAllIncludedAsync();

      Task <bool> booksInCategory(Categories categoryName);
        List<Books> GetByCategoryIncluded(string categoryName);
        void Add(Books book);
        void Update(Books book);
        void Remove(Books book);
        List<Books> BookSearch(string userInput);
        void SaveChanges();
        Task SaveChangesAsync();
        bool ExistsCategory(string categoryName);
    }
}
