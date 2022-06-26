using BusinessLogic.Base;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class SellerService : ISellerService
    {
        private ISellerData _sellerData;
        public SellerService(ISellerData sellerData)
        {
            _sellerData = sellerData;
        }
        public void AddSeller(Seller seller)
        {
            _sellerData.Add(seller);
        }

        public List<Seller> GetAllSellers()
        {
            return _sellerData.GetAll();
        }

        public IEnumerable<Seller> GetSellersByRating(double rating)
        {
            return _sellerData.GetAll(p => p.Rating >= rating);
        }

        public Seller GetSellerById(int id)
        {
            return _sellerData.GetItemById(id);
        }

        public void RemoveSeller(Seller seller)
        {
            _sellerData.Remove(seller);
        }

        public void RemoveSellerById(int id)
        {
            _sellerData.RemoveItemById(id);
        }

        public void Update(Seller seller)
        {
            _sellerData.Update(seller);
        }
    }
}
