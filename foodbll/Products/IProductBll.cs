using fooddtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace foodbll.Products
{
    public interface IProductBll
    {
        //Task<ResponseModel> GetCustom(int? all, int? currentStatus, int idOrder = 0);
        Task<ResponseModel> GetCustom(int? all, int? currentStatus, int idproduct = 0, string sku = "");

        Task<ResponseModel> Create(ProductDto item);
    }
}
