using BusinessLogic.Base;
using DataAccess;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class SellerService : ISellerService
    {
        private IData<Seller> _sellerData;
        public SellerService(IData<Seller> sellerData)
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

        public Seller GetSeller(int id)
        {
            return _sellerData.GetItemById(id);
        }

        public void RemoveSeller(Seller seller)
        {
            _sellerData.Remove(seller);
        }

        public void RemoveSellerItemById(int id)
        {
            _sellerData.RemoveItemById(id);
        }

        public void Update(Seller seller)
        {
            _sellerData.Update(seller);
        }
    }
}
