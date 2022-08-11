using BusinessLogic.Base;
using DataAccess;
using DataAccess.Base;
using Infrastructure.Models;
using Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Services
{
    public class SellerService : ISellerService
    {
        ICacheRepo<Seller> _cache;
        private ISellerRepo _sellerRepo;
        private const string sellersCache = "SellerList";
        public SellerService(ISellerRepo sellerRepo, ICacheRepo<Seller> cache)
        {
            _sellerRepo = sellerRepo;
            _cache = cache;
        }
        public void AddSeller(Seller seller)
        {
            _sellerRepo.Add(seller);

            _cache.Add(seller, 300, CacheTypes.Distributed);
        }

        public List<Seller> GetAllSellers()
        {
            List<Seller> sellers = _cache.GetAll(sellersCache);
            if (sellers == null)
            {
                var datas = _sellerRepo.GetAll();
                _cache.AddAll(sellersCache, datas, 300, CacheTypes.Distributed);
                return datas;
            }
            return sellers;
        }

        public IEnumerable<Seller> GetSellersByRating(decimal rating) // burası yapılacak
        {
            return _sellerRepo.GetAll(p => p.Rating >= rating);
        }

        public Seller GetSellerById(int id)
        {
            Seller cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                return cachedData;
            }
            else
            {
                Seller c = _sellerRepo.GetItemById(id);
                if (c != null) { _cache.Add(c, 300, CacheTypes.Distributed); }
                return c;
            }
        }

        public void RemoveSeller(Seller seller)
        {
            Seller cachedData = _cache.Get(seller.Id);
            if (cachedData != null)
            {
                _cache.Remove(cachedData.Id.ToString());
            }
            _sellerRepo.Remove(seller);
        }

        public Seller RemoveSellerById(int id)
        {
            Seller cachedData = _cache.Get(id);
            if (cachedData != null)
            {
                _cache.Remove(id.ToString());
            }
            Seller c = _sellerRepo.RemoveItemById(id);
            return c;
        }

        public void Update(Seller seller)
        {
            //_cache.Update(seller);
            _sellerRepo.Update(seller);
        }
    }
}
