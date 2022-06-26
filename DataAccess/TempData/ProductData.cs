using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
//bu dal classlarında hep aynı işlevi gören metotlar yazıyorum ama bunun yerine abstract generic temel bir class kullanılsa ve IData yerine o abstract classtan inherit olunsa nasıl olur?
namespace DataAccess.TempData
{
    public class ProductData:IProductData
    {
        private List<Product> _products;
        private List<Seller> _sellers;

        public ProductData()
        {
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

        public void Add(Product item)
        {
            _products.Add(item);
        }

        public List<Product> GetAll()
        {
            return _products;
        }
        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> predicate)
        {
            return _products.AsQueryable().Where(predicate);
        }

        public Product GetItemById(int id)
        {
            return _products.Find(x => x.Id == id);
        }

        public void Remove(Product item)
        {
            _products.Remove(item);
        }

        public void RemoveItemById(int id)
        {
            Product c = GetItemById(id);
            _products.Remove(c);
        }

        public void Update(Product item)
        {
            Product p;
            try
            {
            p = GetItemById(item.Id);//update iteminin id si listedekinden farklı çıkarsa patlayabilir
            }
            catch (IndexOutOfRangeException e)
            {
                throw (Exception)e.Data;
            }
            int index = _products.IndexOf(p);
            _products[index].Name = item.Name ?? _products[index].Name;
            _products[index].Amount = item.Amount > 0 ? item.Amount : _products[index].Amount;
            _products[index].Price = item.Price > 0 ? item.Price : _products[index].Amount;
            _products[index].Rating = item.Rating > 0 ? item.Rating : _products[index].Rating;
            _products[index].CategoryId = item.CategoryId > 0 ? item.CategoryId : _products[index].CategoryId;
            _products[index].SellerId = item.SellerId > 0 ? item.SellerId : _products[index].SellerId;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
            return _products.FindAll(x => x.CategoryId == categoryId);
        }

    }
}
