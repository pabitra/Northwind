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
    public class ProductsQueryHandler : IRequestHandler<GetAllProduct, List<Product>>
    {
        private NorthwindDbContext dbContext;

        public ProductsQueryHandler()
        {
            dbContext = new NorthwindDbContext();
        }

        public async Task<List<Product>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            return await dbContext.Products.ToListAsync();
        }
    }
}
