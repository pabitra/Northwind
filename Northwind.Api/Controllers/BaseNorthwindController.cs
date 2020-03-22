using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Northwind.Api.Controllers
{
    public class BaseNorthwindController : Controller
    {
        protected IMediator _mediator;

        public BaseNorthwindController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
