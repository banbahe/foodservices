using System.Collections.Generic;
using System.Threading.Tasks;

namespace fooddal.Orders
{
    public interface IOrderDal
    {
        Task<IEnumerable<storage.Orders>> CustomSearch(int? all,  int? currentStatus, int idOrder = 0);
        Task Update(storage.Orders values);
        Task Delete(storage.Orders values);
        int Next();
        Task<storage.Orders> Create(storage.Orders values);
        
        //Task<IEnumerable<service.Storage.Sales>> CustomSearch(int idCompany, string ObjectId = "", int idSale = 0, string maker = "", int currentStatus = 0);
        


    }
}
