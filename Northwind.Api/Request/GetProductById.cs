using System;
using MediatR;
using Northwind.Api.Domain;

namespace Northwind.Api.Request
{
    public class GetProductById : IRequest<Product>
    {
       public int ProductId { get; set; }
    }
}
