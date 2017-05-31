using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApiShops.Models;

namespace WebApiShops
{
    public class ShopsRepository : IShopsRepository
    {
        private static List<Shop> _shops;

        public ShopsRepository()
        {
            if (_shops == null)
            {
                _shops = new List<Shop>();
                Add(new Shop { Name = "Юлмарт", Owner = "Ivanov" });
                Add(new Shop { Name = "Ситилинк", Owner = "Petrov" });
                Add(new Shop { Name = "Евросеть", Owner = "Petrov" });
                Add(new Shop { Name = "Связной", Owner = "Petrov" });
                Add(new Shop { Name = "Shop-5", Owner = "Ivanov" });
                Add(new Shop { Name = "Shop-6", Owner = "Sidorov" });
                Add(new Shop { Name = "Shop-7" });
                Add(new Shop { Name = "Shop-8" });
                Add(new Shop { Name = "Shop-9" });
                Add(new Shop { Name = "Shop-10" });
                Add(new Shop { Name = "Shop-11" });
                Add(new Shop { Name = "Shop-12" });
            }
        }

        public List<Shop> GetAll(int limit, int offset)
        {
            return _shops.Skip(offset).Take(limit).ToList();
        }

        public void Add(Shop item)
        {
            item.Id = _shops.OrderByDescending(i => i.Id).Select(i => i.Id).FirstOrDefault() + 1;
            _shops.Add(item);
        }

        public Shop Find(int Id)
        {
            return _shops.Find(i => i.Id == Id);
        }

        public Shop Remove(int Id)
        {
            var shop = _shops.Where(i => i.Id == Id).FirstOrDefault();
            if (shop != null)
            {
                _shops.Remove(shop);
            }
            return shop;
        }

        public void Update(Shop item)
        {
            var shop = _shops.Where(i => i.Id == item.Id).FirstOrDefault();
            if (shop != null)
            {
                shop.Name = item.Name;
            }
        }

        public List<Shop> GetShopByOwner(string owner)
        {
            return _shops.Where(i => owner == null || (i.Owner != null && i.Owner.ToLower() == owner.ToLower())).ToList();
        }
    }
}