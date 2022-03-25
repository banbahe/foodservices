//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Options;
using fooddtos;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
//using MongoDB.Driver;
// using service.Bll.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storage
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _db = null;
        private readonly IOptions<FoodSettings> _mongosettings;
        public MongoClient client { get; set; }

        public MongoDbContext(IOptions<FoodSettings> settings)
        {
            _mongosettings = settings;

            this.client = new MongoClient(_mongosettings.Value.ConnectionString);
            if (client != null)
                _db = client.GetDatabase(_mongosettings.Value.DatabaseName);
        }

        public IMongoCollection<Orders> Orders
        {
            get
            {
                return _db.GetCollection<Orders>("orders");
            }
        }
        public int OrdersNext()
        {
            int result = 0;
            try
            {
                var collection = _db.GetCollection<Orders>("orders");
                result = (from c in collection.AsQueryable<Orders>()
                          select c.idorder).Max();
                return ++result;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return ++result;
                else
                    throw ex;
            }
        }

        public IMongoCollection<Products> Products
        {
            get
            {
                return _db.GetCollection<Products>("products");
            }
        }
        public int ProductsNext()
        {
            int result = 0;
            try
            {
                var collection = _db.GetCollection<Products>("products");
                result = (from c in collection.AsQueryable<Products>()
                          select c.idproduct).Max();
                return ++result;
            }
            catch (Exception ex)
            {
                if (ex.Message == "Sequence contains no elements")
                    return ++result;
                else
                    throw ex;
            }
        }
    }
}
