using ebookstore.Implementations;
using ebookstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ebookstore.Services
{
    public class CategoryService : ICategoryService
    {

        ICategoryRepository repository;

        public CategoryService(ICategoryRepository categ)
        {
            this.repository = categ;
        }


        public IEnumerable<Categories> Categories => repository.Categories; //include here



    
        public async Task<Categories> SearchCategoryName(string categoryName)
        {

            return await repository.searchCategory(categoryName);
        }
        public void Add(Categories category)
        {
            repository.Add(category);
        }

        public IEnumerable<Categories> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Categories GetById(int? id)
        {
            return repository.GetById(id);
        }

        public async Task<Categories> GetByIdAsync(int? id)
        {
            return await repository.GetByIdAsync(id);
        }

        public bool Exists(int id)
        {
            return repository.Exists(id);
        }

        public void Remove(Categories category)
        {
            repository.Remove(category);
        }

        public void SaveChanges()
        {
            repository.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await repository.SaveChangesAsync();
        }

        public void Update(Categories category)
        {
            repository.Update(category);
        }

        public bool ExistsCategory(string categoryName)
        {
             return  repository.ExistsCategory(categoryName);
        }

    } 
    
}

