using foodbll.AutoMappers;
using foodbll.Helpers;
using fooddal.Products;
using fooddtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodbll.Products
{
    public class ProductBll : IProductBll
    {
        private readonly MainMapper _mainMapper;
        private readonly IProductDal _dal;
        private ResponseModel _rm;

        //public ProductBll(IConfiguration c, IRolBll rolBll, MainMapper mainMapper, ResponseModel rm, IUserDal dal)
        public ProductBll(MainMapper mainMapper, IProductDal dal, ResponseModel rm)
        {
            this._mainMapper = mainMapper;
            this._dal = dal;
            this._rm = rm;
        }

        public async Task<ResponseModel> GetCustom(int? all, int? currentStatus, int idproduct = 0, string sku = "")
        {
            try
            {
                var result = await _dal.CustomSearch(all, currentStatus, idproduct, sku);
                if (result.Count() > 0)
                {
                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Datums = result;
                    _rm.Message = "*successful";
                }
                else
                {
                    _rm.Flag = (int)CSTATUS.Null_Empty_NoFound;
                    _rm.Message = "*not rows";
                }
            }
            catch (Exception ex)
            {
                _rm.Flag = (int)CSTATUS.Error;
                _rm.Message = ex.InnerException == null ? "" : $"; {ex.InnerException.Message}.";
                _rm.Message = ex.Message + _rm.Message;
            }
            return _rm;
        }
        public async Task<ResponseModel> Create(ProductDto item)
        {
            try
            {

                item.DateEntry = DateTimeHelper.CurrentTimestamp();
                var getProduct = await _dal.CustomSearch(null, null, SKU: item.SKU);

                if (getProduct.Count() > 0)
                {
                    _rm.Flag = (int)CSTATUS.ItemExisting;
                    _rm.Message = "product already exists";
                }
                else
                {
                    item.IdProduct = _dal.Next();
                    var mapped_object = _mainMapper.Mapper.Map<storage.Products>(item);
                    var tmp = await _dal.Create(mapped_object);

                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Datums = item;
                }
            }
            catch (Exception ex)
            {
                _rm.Flag = (int)CSTATUS.Error;
                _rm.Message = ex.InnerException == null ? "" : $"; {ex.InnerException.Message}.";
                _rm.Message = ex.Message + _rm.Message;
            }
            return _rm;
        }

    }
}
