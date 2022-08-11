using BusinessLogic.Base;
using BusinessLogic.Caching;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    //productın cache te kalma durumu
    public class ProductService : IProductService
    {
        ICacheRepo<Product> _cache;
        private IProductRepo _productRepo;
        private const string productsCache = "ProductList";
        public ProductService(IProductRepo productRepo, ICacheRepo<Product> cache)
        {
            _productRepo = productRepo;
            _cache = cache;
        }
        public void AddProduct(Product product)
        {
            _productRepo.Add(product);

            _cache.Add(product, 0, CacheTypes.None);
        }

        public List<Product> GetAllProducts()
        {
            List<Product> products = _cache.GetAll(productsCache);
            if (products == null)
            {
                var datas = _productRepo.GetAll();
                _cache.AddAll(productsCache, datas, 0, CacheTypes.None);
                return datas;
            }
            return products;
        }

        public Product GetProduct(int id)
        {
            Product cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                return cachedData;
            }
            else
            {
                Product c = _productRepo.GetItemById(id);
                if (c != null) { _cache.Add(c, 0, CacheTypes.None); }
                return c;
            }
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId) // burayıda yap
        {
            return _productRepo.GetAll(p => p.CategoryId == categoryId);
        }

        public void RemoveProduct(Product product)
        {
            Product cachedData = _cache.Get(product.Id);
            if (cachedData != null)
            {
                _cache.Remove(cachedData.Id.ToString());
            }
            _productRepo.Remove(product);
        }

        public Product RemoveProductById(int id)
        {
            Product cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                _cache.Remove(id.ToString());
            }
            Product c = _productRepo.RemoveItemById(id);
            return c;
        }

        public void Update(Product product)
        {
            //_cache.Update(product);
            _productRepo.Update(product);
        }
    }
}
