using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.DataAccess;
using Northwind.Api.Domain;
using Northwind.Api.Request;

namespace Northwind.Api.Handlers
{
    public class ProductByIdHandler: IRequestHandler<GetProductById, Product>
    {
        private NorthwindDbContext dbContext;

        public ProductByIdHandler()
        {
            dbContext = new NorthwindDbContext();
        }

        public  async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await dbContext.Products.FirstAsync(p => p.Id == request.ProductId);
        }
    }
}
