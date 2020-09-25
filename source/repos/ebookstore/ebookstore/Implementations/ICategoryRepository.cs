using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Implementations
{
    public interface  ICategoryRepository
    {
        IEnumerable<Categories> Categories { get; }

        Categories GetById(int? id);
        Task<Categories> GetByIdAsync(int? id);
       /// bool ExistsCategory(string categoryName);


        Task<Categories> searchCategory(string categoryName);


        bool Exists(int id);

        IEnumerable<Categories> GetAll();
        Task<IEnumerable<Categories>> GetAllAsync();

        void Add(Categories category);
        void Update(Categories category);
        void Remove(Categories category);
        bool ExistsCategory(string categoryName);
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
