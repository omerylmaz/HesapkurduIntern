using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.TempData
{
    public class CategoryData:ICategoryData
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
            //Category c = _categories.FirstOrDefault(x => x.Id == id);
            //if (c == null) throw new KeyNotFoundException();
            return _categories.FirstOrDefault(x => x.Id == id); ;
        }

        public void Add(Category item)
        {
            Category c = GetItemById(item.Id);
            if (c == null) _categories.Add(item);
            else
            {
                throw new Exception("This id exists");
            }
        }

        public void Remove(Category item)
        {
            _categories.Remove(item);
        }

        public Category RemoveItemById(int id)
        {
            Category c = GetItemById(id);
            if (c == null)
                throw new KeyNotFoundException();

            _categories.Remove(c);
            return c;
        }

        public void Update(Category item)
        {
            Category c;
            try
            {
                c = GetItemById(item.Id);//update iteminin id si listedekinden farklı çıkarsa patlayabilir
            }
            catch (IndexOutOfRangeException e)
            {
                throw (Exception)e.Data;
            }
            int index = _categories.IndexOf(c);
            _categories[index] = item;
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> predicate)
        {
            return _categories.AsQueryable().Where(predicate);
        }
    }
}
