﻿using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.TempData
{
    public class SellerData:ISellerData
    {
        List<Seller> _sellers;
        public SellerData()
        {
            _sellers = new List<Seller> { 
                new Seller { Id = 1, Name = "tecnokurdu", Rating = 10 }, 
                new Seller { Id = 2, Name = "lipton", Rating = 3 }, 
                new Seller { Id = 3, Name = "everything", Rating = 5 } };
        }

        public List<Seller> GetAll()
        {
            return _sellers;
        }

        public Seller GetItemById(int id)
        {
            return _sellers.Find(x => x.Id == id);
        }

        public void Add(Seller item)
        {
            _sellers.Add(item);
        }

        public void Remove(Seller item)
        {
            _sellers.Remove(item);
        }

        public void RemoveItemById(int id)
        {
            Seller c = GetItemById(id);
            _sellers.Remove(c);
        }

        public void Update(Seller item)
        {
            Seller c = GetItemById(item.Id);
            int index = _sellers.IndexOf(c);
            _sellers[index] = item;
        }

        public List<Seller> GetAllByAny(Func<object, bool> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Seller> GetAll(Expression<Func<Seller, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
