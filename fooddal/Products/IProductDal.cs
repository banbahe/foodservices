using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
namespace fooddal.Products
{
    public interface IProductDal
    {
        Task Delete(storage.Products product);
        Task Update(storage.Products product);
        Task<storage.Products> Create(storage.Products product);
        Task<IEnumerable<storage.Products>> CustomSearch(int? all, int? currentStatus, int idProduct = 0, string SKU = "");
        int Next();
    }
}
