using BusinessLogic.Base;
using BusinessLogic.Caching;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Caching.Distributed;

namespace BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        ICacheRepo<Category> _cache;
        private ICategoryRepo _categoryRepo;
        private const string categoriesCache = "CategoryList";
        public CategoryService(ICategoryRepo categoryRepo, ICacheRepo<Category> cache)
        {
            _categoryRepo = categoryRepo;
            _cache = cache;
        }
        public void AddCategory(Category category)
        {
            _categoryRepo.Add(category);

            _cache.Add(category);
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = _cache.GetAll(categoriesCache);
            if (categories == null)
            {
                var datas = _categoryRepo.GetAll();
                _cache.AddAll(categoriesCache, datas);
                return datas;
            }
            return categories;
        }

        public Category GetCategory(int id)
        {
            Category cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                return cachedData;
            }
            else
            {
                Category c = _categoryRepo.GetItemById(id);
                if (c != null) { _cache.Add(c); }
                return c;
            }
        }

        public void RemoveCategory(Category category)
        {
            Category cachedData = _cache.Get(category.Id);
            if (cachedData != null)
            {
                _cache.Remove(cachedData.Id.ToString());
            }
            _categoryRepo.Remove(category);
        }

        public Category RemoveCategoryById(int id)
        {
            Category cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                _cache.Remove(id.ToString());
            }
            Category c = _categoryRepo.RemoveItemById(id);
            return c;
        }

        public void Update(Category category)
        {
            _cache.Update(category);
            _categoryRepo.Update(category);
        }
    }
}
