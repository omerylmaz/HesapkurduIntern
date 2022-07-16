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
        private ISellerRepo _sellerRepo;
        public SellerService(ISellerRepo sellerRepo)
        {
            _sellerRepo = sellerRepo;
        }
        public void AddSeller(Seller seller)
        {
            _sellerRepo.Add(seller);
        }

        public List<Seller> GetAllSellers()
        {
            return _sellerRepo.GetAll();
        }

        public IEnumerable<Seller> GetSellersByRating(double rating)
        {
            return _sellerRepo.GetAll(p => p.Rating >= rating);
        }

        public Seller GetSellerById(int id)
        {
            return _sellerRepo.GetItemById(id);
        }

        public void RemoveSeller(Seller seller)
        {
            _sellerRepo.Remove(seller);
        }

        public Seller RemoveSellerById(int id)
        {
            Seller s = _sellerRepo.RemoveItemById(id);
            return s;
        }

        public void Update(Seller seller)
        {
            _sellerRepo.Update(seller);
        }
    }
}
