using fooddtos;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fooddal.Products
{
    public class ProductDal : IProductDal
    {
        private readonly MongoDbContext _context = null;
        private readonly IOptions<FoodSettings> _mongosettings;

        public ProductDal(IOptions<FoodSettings> settings, MongoDbContext context)
        {
            _mongosettings = settings;
            _context = context;
        }



        public async Task Delete(storage.Products product)
        {
            FilterDefinition<storage.Products> filter = Builders<storage.Products>.Filter.Eq(s => s.Id, product.Id);
            await _context.Products.DeleteOneAsync(filter);
        }
        public async Task Update(storage.Products product)
        {
            var update = Builders<storage.Products>.Update
            .Set(x => x.name, product.name)
            .Set(x => x.sku, product.sku)
            .Set(x => x.imgPath, product.imgPath)
            .Set(x => x.currentStatus, product.currentStatus)
            .Set(x => x.unitPrice, product.unitPrice)
            .Set(x => x.existence, product.existence);

            FilterDefinition<storage.Products> filter = Builders<storage.Products>.Filter.Eq(s => s.Id, product.Id);

            await _context.Products.UpdateOneAsync(filter, update);
        }

        public async Task<storage.Products> Create(storage.Products product)
        {
            await _context.Products.InsertOneAsync(product);
            return product;
        }
        /*
         * public async Task<IEnumerable<storage.Products>> CustomSearch(int? all, int? currentStatus, int idproduct = 0)
        {
            if (idproduct > 0)
                return await _context.Products.Find(x => x.idproduct == idproduct).ToListAsync();

            if (all != null)
                return await _context.Products.Find(_ => true).ToListAsync();

            if (currentStatus != null)
                return await _context.Products.Find(x => x.currentStatus == currentStatus).ToListAsync();

            return null;
        }
         */
        public async Task<IEnumerable<storage.Products>> CustomSearch(int? all, int? currentStatus, int idProduct = 0, string SKU = "")
        {
            if (idProduct > 0)
                return await _context.Products.Find(x => x.idproduct == idProduct).ToListAsync();

            if (!string.IsNullOrEmpty(SKU))
                return await _context.Products.Find(x => x.sku == SKU).ToListAsync();
            
            if (all != null)
                return await _context.Products.Find(_ => true).ToListAsync();

            if (currentStatus != null)
                return await _context.Products.Find(x => x.currentStatus == currentStatus).ToListAsync();

            return null;
        }

        public int Next()
        {
            return _context.ProductsNext();
        }
    }
}
