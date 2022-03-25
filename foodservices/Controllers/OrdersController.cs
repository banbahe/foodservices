using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using fooddtos;
using foodbll.Products;
using foodbll.Orders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foodservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrderBll _bllOrder;
        public OrdersController(IOrderBll bll) => _bllOrder = bll;
        // GET: api/<OrdersController>
        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            return await _bllOrder.GetCustom(1, null);
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel> Get(int id)
        {
            return await _bllOrder.GetCustom(null, null, id);
        }
        [HttpGet]
        [Route("{idstatus}/status")]
        public async Task<ResponseModel> GetStatus(int idstatus)
        {
            return await _bllOrder.GetCustom(null, idstatus);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ResponseModel> Create(OrderDto item)
        {
            return await _bllOrder.Add(item);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<ResponseModel> Update(int id, OrderDto values)
        {
            values.IdOrder = id;
            return await _bllOrder.Set(values);
        }
        [HttpPut]
        [Route("{id}/status/{idstatus}")]
        public async Task<ResponseModel> SetStatus(int id,int idstatus)
        {
            return await _bllOrder.SetStatus(id, idstatus);
        }


        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<ResponseModel> Delete(int id)
        {
            return await _bllOrder.Delete(id);
        }
    }
}
