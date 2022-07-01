using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Base
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
        Product GetProduct(int id);
        void AddProduct(Product product);
        void RemoveProduct(Product product);
        Product RemoveProductById(int id);
        void Update(Product product);
    }
}
