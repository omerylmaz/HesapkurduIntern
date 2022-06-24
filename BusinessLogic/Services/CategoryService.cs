using BusinessLogic.Base;
using DataAccess;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private IData<Category> _categoryData;
        public CategoryService(IData<Category> categoryData)
        {
            _categoryData = categoryData;
        }
        public void AddCategory(Category category)
        {
            _categoryData.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            return _categoryData.GetAll();
        }

        public Category GetCategory(int id)
        {
            return _categoryData.GetItemById(id);
        }

        public void RemoveCategory(Category category)
        {
            _categoryData.Remove(category);
        }

        public void RemoveCategoryItemById(int id)
        {
            _categoryData.RemoveItemById(id);
        }

        public void Update(Category category)
        {
            _categoryData.Update(category);
        }
    }
}
