using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Northwind.Api.Domain;
using Northwind.Api.Request;

namespace Northwind.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET api/values
        [HttpGet]
        public  async Task<ActionResult<IList<Product>>> Get()
        {
            var  getAllProduct = new GetAllProduct();
            return await _mediator.Send(getAllProduct);
        }

        // GET api/v1/products/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int ProductId)
        {
            var getProductById = new GetProductById { ProductId= ProductId };
            return await _mediator.Send(getProductById);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
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
