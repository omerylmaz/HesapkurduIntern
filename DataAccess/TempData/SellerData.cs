using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.TempData
{
    public class SellerData:ISellerRepo
    {
        List<Seller> _sellers;
        public SellerData()
        {
            _sellers = new List<Seller> { 
                new Seller { Id = 1, Name = "tecnokurdu", Rating = 10, Email = "tecnokurdu.gmail.com" , PhoneNumber="5522338071"}, 
                new Seller { Id = 2, Name = "lipton", Rating = 3, Email = "lipton.gmail.com" , PhoneNumber="5522338571" }, 
                new Seller { Id = 3, Name = "everything", Rating = 5, Email = "everything.gmail.com" , PhoneNumber="5578338071" },
                new Seller { Id = 4, Name = "migros", Rating = 7, Email = "migros.gmail.com" , PhoneNumber="5578334875" } };
        }

        public List<Seller> GetAll()
        {
            return _sellers;
        }
        public IEnumerable<Seller> GetAll(Expression<Func<Seller, bool>> predicate)
        {
            return _sellers.AsQueryable().Where(predicate);
        }

        public Seller GetItemById(int id)
        {
            //Seller s = _sellers.FirstOrDefault(x => x.Id == id);
            //if (s == null) throw new KeyNotFoundException();
            return _sellers.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Seller item)
        {
            Seller s = GetItemById(item.Id);
            if (s == null) _sellers.Add(item);
            else
            {
                throw new Exception("This id exists");
            }
        }

        public void Remove(Seller item)
        {
            _sellers.Remove(item);
        }

        public Seller RemoveItemById(int id)
        {
            Seller s = GetItemById(id);
            if (s == null)
                throw new KeyNotFoundException();
            _sellers.Remove(s);
            return s;
        }

        public void Update(Seller item)
        {
            Seller s;
            try
            {
                s = GetItemById(item.Id);//update iteminin id si listedekinden farklı çıkarsa patlayabilir
            }
            catch (IndexOutOfRangeException e)
            {
                throw (Exception)e.Data;
            }
            int index = _sellers.IndexOf(s);
            _sellers[index].Name = item.Name ?? _sellers[index].Name;
            _sellers[index].Email = item.Email ?? _sellers[index].Email;
            _sellers[index].PhoneNumber = item.PhoneNumber ?? _sellers[index].PhoneNumber;
            _sellers[index].Rating = item.Rating > 0 ? item.Rating : _sellers[index].Rating;
        }

    }
}
