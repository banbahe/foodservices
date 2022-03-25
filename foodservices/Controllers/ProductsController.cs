using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Collections.Generic;
using fooddtos;
using foodbll.Products;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foodservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductBll _bllProduct;
        public ProductsController(IProductBll bll) => _bllProduct = bll;

        [HttpGet]
        public async Task<ResponseModel> Get()
        {
            return await _bllProduct.GetCustom(1, null);
        }

        [HttpGet("{id}")]
        public async Task<ResponseModel> Get(int id)
        {
            return await _bllProduct.GetCustom(null, null, id);
        }
        [HttpGet]
        [Route("{idstatus}/status")]
        public async Task<ResponseModel> GetStatus(int idstatus)
        {
            return await _bllProduct.GetCustom(null, idstatus);
        }
        [HttpGet]
        [Route("{sku}/sku")]
        public async Task<ResponseModel> GetSku(string sku)
        {
            return await _bllProduct.GetCustom(null, null, sku: sku);
        }
        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ResponseModel> Create(ProductDto item)
        {
            //return null;
            return await _bllProduct.Create(item);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
