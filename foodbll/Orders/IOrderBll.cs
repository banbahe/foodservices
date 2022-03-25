using fooddtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace foodbll.Orders
{
    public interface IOrderBll
    {
        //Get Custom
        Task<ResponseModel> GetCustom(int? all, int? currentStatus, int idOrder = 0);

        // Delete
        Task<ResponseModel> Delete(int id);
        // Update
        Task<ResponseModel> Set(OrderDto values);
        Task<ResponseModel> SetStatus(int id, int estatus);

        // Create
        Task<ResponseModel> Add(OrderDto values);


    }
}
