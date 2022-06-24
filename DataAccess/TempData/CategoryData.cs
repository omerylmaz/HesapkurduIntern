using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TempData
{
    public class CategoryData:IData<Category>
    {
        public List<Category> _categories { get; set; }
        public CategoryData()
        {
            _categories = new List<Category> { 
                new Category { Id=1,Name="Computer"},
                new Category { Id=2, Name="Phone"},
                new Category{ Id=3, Name="Beverage"},
                new Category(){ Id=4, Name="Cosmetic"},
                new Category() { Id=5, Name="Food"},
                new Category() { Id =6, Name="Book"}
            };
        }

        public List<Category> GetAll()
        {
            return _categories;
        }

        public Category GetItemById(int id)
        {
            return _categories.Find(x => x.Id == id);
        }

        public void Add(Category item)
        {
            _categories.Add(item);
        }

        public void Remove(Category item)
        {
            _categories.Remove(item);
        }

        public void RemoveItemById(int id)
        {
            Category c = GetItemById(id);
            _categories.Remove(c);
        }

        public void Update(Category item)
        {
            Category c = GetItemById(item.Id);
            int index = _categories.IndexOf(c);
            _categories[index] = item;
        }
    }
}
