using BusinessLogic.Base;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }
        public void AddCategory(Category category)
        {
            _categoryRepo.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryRepo.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _categoryRepo.GetItemById(id);
        }

        public void RemoveCategory(Category category)
        {
            _categoryRepo.Remove(category);
        }

        public Category RemoveCategoryById(int id)
        {
            Category c = _categoryRepo.RemoveItemById(id);
            return c;
        }

        public void Update(Category category)
        {
            _categoryRepo.Update(category);
        }
    }
}
