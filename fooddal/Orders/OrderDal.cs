using fooddtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fooddal.Orders
{
    public class OrderDal : IOrderDal
    {
        private readonly MongoDbContext _context = null;
        private readonly IOptions<FoodSettings> _mongosettings;

        public OrderDal(IOptions<FoodSettings> settings, MongoDbContext context)
        {
            _mongosettings = settings;
            _context = context;
        }

        public async Task<IEnumerable<storage.Orders>> CustomSearch(int? all, int? currentStatus, int idOrder = 0)
        {
            if (idOrder > 0)
                return await _context.Orders.Find(x => x.idorder == idOrder).ToListAsync();

            if (all != null)
                return await _context.Orders.Find(_ => true).ToListAsync();

            if (currentStatus != null)
                return await _context.Orders.Find(x => x.currentStatus == currentStatus).ToListAsync();

            return null;
        }
        public async Task Update(storage.Orders values)
        {
            var update = Builders<storage.Orders>.Update
            .Set(x => x.idorder, values.idorder)
            .Set(x => x.currentStatus, values.currentStatus)
            .Set(x => x.total, values.total)
            .Set(x => x.folio, values.folio)
            .Set(x => x.clientname, values.clientname)
            .Set(x => x.details, values.details);

            FilterDefinition<storage.Orders> filter = Builders<storage.Orders>.Filter.Eq(s => s.Id, values.Id);

            await _context.Orders.UpdateOneAsync(filter, update);
        }
        public async Task Delete(storage.Orders values)
        {
            FilterDefinition<storage.Orders> filter = Builders<storage.Orders>.Filter.Eq(s => s.Id, values.Id);
            await _context.Orders.DeleteOneAsync(filter);
        }

        public async Task<storage.Orders> Create(storage.Orders values)
        {
            await _context.Orders.InsertOneAsync(values);
            return values;
        }

        public int Next()
        {
            return _context.OrdersNext();
        }
    }
}
