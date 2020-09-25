using ebookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ebookstore.Services
{
    public interface IBookService
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

        void Add(Books book);
        void Update(Books book);
        void Remove(Books book);

        Task<bool> booksInCategory(Categories category);
        
        
        
        List<Books> BookSearch(string userInput);


        List<Books> GetByCategoryIncluded(string categoryName); 
        void SaveChanges();
        Task SaveChangesAsync();
    }
}