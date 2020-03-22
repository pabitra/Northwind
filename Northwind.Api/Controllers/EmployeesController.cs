using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;



namespace Northwind.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : BaseNorthwindController
    {

        public EmployeesController(IMediator mediator) : base(mediator)
        {
        }

        
    }
}
