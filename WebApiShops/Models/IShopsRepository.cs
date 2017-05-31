using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiShops.Models
{
    public interface IShopsRepository
    {
        void Add(Shop item);
        List<Shop> GetAll(int limit, int offset);
        List<Shop> GetShopByOwner(string owner);
        Shop Find(int Id);
        Shop Remove(int Id);
        void Update(Shop item);
    }
}
