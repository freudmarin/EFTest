using ebookstore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ebookstore.Services
{
    public interface ICategoryService
    {
        IEnumerable<Categories> Categories { get; }

        Categories GetById(int? id);
        Task<Categories> GetByIdAsync(int? id);

        bool Exists(int id);
 
        IEnumerable<Categories> GetAll();
        Task<IEnumerable<Categories>> GetAllAsync();
        bool ExistsCategory(string categoryName);
       
        Task<Categories> SearchCategoryName(string categoryName);
        void Add(Categories category);
        void Update(Categories category);
        void Remove(Categories category);

        void SaveChanges();
        Task SaveChangesAsync();
    }
}

   