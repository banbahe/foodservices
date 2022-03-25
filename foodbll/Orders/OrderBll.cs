using foodbll.AutoMappers;
using foodbll.Helpers;
using fooddal.Orders;
using fooddal.Products;
using fooddtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foodbll.Orders
{
    public class OrderBll : IOrderBll
    {
        private readonly MainMapper _mainMapper;
        private readonly IProductDal _dalProduct;
        private readonly IOrderDal _dal;
        private ResponseModel _rm;

        public OrderBll(MainMapper mainMapper, IProductDal dalProduct, IOrderDal dal, ResponseModel rm)
        {
            this._mainMapper = mainMapper;
            this._dalProduct = dalProduct;
            this._dal = dal;
            this._rm = rm;
        }
        public async Task<ResponseModel> GetCustom(int? all, int? currentStatus, int idOrder = 0)
        {
            try
            {
                var result = await _dal.CustomSearch(all, currentStatus, idOrder);
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
        public async Task<ResponseModel> Delete(int id)
        {
            try
            {
                var tmpObject = await _dal.CustomSearch(null, id);
                if (tmpObject != null)
                {
                    var orderObject = tmpObject.FirstOrDefault();
                    orderObject.currentStatus = (int)CSTATUS.Canceled;
                    await _dal.Update(orderObject);
                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Message = "*successful";
                }
                else
                {
                    _rm.Flag = (int)CSTATUS.Error;
                    _rm.Message = "*item cannot be canceled";
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
        public async Task<ResponseModel> Set(OrderDto item)
        {
            try
            {
                var tmpObject = await _dal.CustomSearch(null, item.IdOrder);
                if (tmpObject != null)
                {
                    var mapped_object = _mainMapper.Mapper.Map<storage.Orders>(item);
                    mapped_object.Id = tmpObject.FirstOrDefault().Id;
                    await _dal.Update(mapped_object);
                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Message = "*successful";
                }
                else
                {
                    _rm.Flag = (int)CSTATUS.Null_Empty_NoFound;
                    _rm.Message = "*item no found";
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
        public async Task<ResponseModel> SetStatus(int id, int estatus)
        {
            try
            {
                var tmpObject = await _dal.CustomSearch(null, null, idOrder: id);
                if (tmpObject != null)
                {
                    var foundItem = tmpObject.FirstOrDefault();
                    foundItem.currentStatus = estatus;
                    await _dal.Update(foundItem);
                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Message = "*successful";
                }
                else
                {
                    _rm.Flag = (int)CSTATUS.Null_Empty_NoFound;
                    _rm.Message = "*item no found";
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

        public async Task<ResponseModel> Add(OrderDto item)
        {
            try
            {
                item.IdOrder = _dal.Next();
                item.CurrentStatus = (int)CSTATUS.Pending;
                item.DateEntry = DateTimeHelper.CurrentTimestamp();

                var mapped_object = _mainMapper.Mapper.Map<storage.Orders>(item);
                var result = await _dal.Create(mapped_object);

                if (!string.IsNullOrEmpty(result.Id))
                {
                    // SKU Stock Keeping Unit 
                    foreach (var itemProduct in item.Details)
                    {
                        // search product
                        var findProduct = await _dalProduct.CustomSearch(null, null, idProduct: itemProduct.IdProduct);
                        var tmpProduct = findProduct.FirstOrDefault();

                        // substract amount
                        var subTotalStock = tmpProduct.existence - itemProduct.Amount;

                        // check if quantity is greater than zero
                        if (subTotalStock > 0)
                        {
                            //    therefore => save product
                            tmpProduct.existence = subTotalStock;

                            // todo validar resultados
                            await _dalProduct.Update(tmpProduct);
                        }
                        else
                        {
                            await _dal.Delete(result);
                            throw new Exception($"* insufficient inventary {tmpProduct.name}");
                        }
                    }
                    // endly
                    _rm.Flag = (int)CSTATUS.Ok;
                    _rm.Datums = result.Id;
                    _rm.Message = "*successful";
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
