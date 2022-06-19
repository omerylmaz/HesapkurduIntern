using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.TempData
{
    public class ProductData
    {
        private List<Product> _products;
        //private List<Category> _categories;
        private List<Seller> _sellers;

        public ProductData()
        {
            //CategoryData cd = new CategoryData();
            //_categories = cd._categories;
            _products = new List<Product> {
                new Product { Id = 1, Name = "Macbook", Amount =20, CategoryId=1,Price=1200,Rating=8.6,SellerId=1},
                new Product { Id = 2, Name = "Asus", Amount =40, CategoryId=1,Price=1000,Rating=7.6,SellerId=1},
                new Product { Id = 3, Name = "Lenovo", Amount =200, CategoryId=1,Price=800,Rating=6.6,SellerId=1},
                new Product { Id = 4, Name = "1984", Amount =2000, CategoryId=6,Price=12,Rating=8.8,SellerId=3},
                new Product { Id = 5, Name = "Ice Tea", Amount =250, CategoryId=3,Price=1.2,Rating=6.6,SellerId=2},
                new Product { Id = 6, Name = "iPhone", Amount =26, CategoryId=2,Price=900,Rating=5.6,SellerId=1},
                new Product { Id = 7, Name = "Apple", Amount =2560, CategoryId=5,Price=4.2,Rating=7.6,SellerId=3},
                new Product { Id = 8, Name = "Kerastase", Amount =200, CategoryId=4,Price=12,Rating=8.6,SellerId=3},
                new Product { Id = 9, Name = "Xiaomi", Amount =250, CategoryId=2,Price=700,Rating=8.6,SellerId=1}
            };
        }
    }
}
