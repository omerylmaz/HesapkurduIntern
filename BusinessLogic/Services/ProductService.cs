using BusinessLogic.Base;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        public void AddProduct(Product product)
        {
            _productRepo.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _productRepo.GetItemById(id);
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productRepo.GetAll(p => p.CategoryId == categoryId);
        }

        public void RemoveProduct(Product product)
        {
            _productRepo.Remove(product);
        }

        public Product RemoveProductById(int id)
        {
            Product p = _productRepo.RemoveItemById(id);
            return p;
        }

        public void Update(Product product)
        {
            _productRepo.Update(product);
        }
    }
}
