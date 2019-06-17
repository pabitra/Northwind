using System;
using System.Collections.Generic;
using MediatR;
using Northwind.Api.Domain;

namespace Northwind.Api.Request
{
    public class GetAllProduct : IRequest<List<Product>>
    {
       
    }
}
