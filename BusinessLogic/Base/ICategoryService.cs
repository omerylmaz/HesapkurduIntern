using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void RemoveCategoryItemById(int id);
        void Update(Category category);
    }
}
