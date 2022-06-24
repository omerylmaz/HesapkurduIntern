using BusinessLogic.Base;
using DataAccess;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class ProductService : IProductService
    {
        private IData<Product> _productData;
        public ProductService(IData<Product> productData)
        {
            _productData = productData;
        }
        public void AddProduct(Product product)
        {
            _productData.Add(product);
        }

        public List<Product> GetAllProducts()
        {
            return _productData.GetAll();
        }

        public Product GetProduct(int id)
        {
            return _productData.GetItemById(id);
        }

        public void RemoveProduct(Product product)
        {
            _productData.Remove(product);
        }

        public void RemoveProductItemById(int id)
        {
            _productData.RemoveItemById(id);
        }

        public void Update(Product product)
        {
            _productData.Update(product);
        }
    }
}
