using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Domain;
using Northwind.Api.Request;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : BaseNorthwindController
    {

        public ProductsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet("{pageSize:int}/{pageNumber:int}/{orderBy:alpha?}")]
        public async Task<ActionResult<IList<ProductViewModel>>> Get(int pageSize, int pageNumber, string orderBy = "")
        {
            var getPagesProductRequestCommand = new GetPagedProduct() { PageSize = pageSize, PageNumber = pageNumber, OrderBy = orderBy };
            return await _mediator.Send(getPagesProductRequestCommand);
        }

        // GET api/values
        [HttpGet]
        public  async Task<ActionResult<IList<ProductViewModel>>> Get()
        {
            var  getAllProduct = new GetAllProduct();
            return await _mediator.Send(getAllProduct);
        }

        // GET api/v1/products/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductViewModel>> Get(int ProductId)
        {
            var getProductById = new GetProductById { ProductId= ProductId };
            return await _mediator.Send(getProductById);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Product product)
        {

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        public void Patch()
        {

        }
    }
}
