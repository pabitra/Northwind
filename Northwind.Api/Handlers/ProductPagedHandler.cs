using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.DataAccess;
using Northwind.Api.Domain;
using Northwind.Api.Request;
using Northwind.Api.Utility;
using AutoMapper;
using Northwind.Api.ViewModels;
using AutoMapper.QueryableExtensions;

namespace Northwind.Api.Handlers
{
    public class ProductPagedHandler : IRequestHandler<GetPagedProduct, List<ProductViewModel>>
    {
        private NorthwindDbContext dbContext;

        public ProductPagedHandler(NorthwindDbContext northwindDbContext)
        {
            dbContext = northwindDbContext;
        }

        public async Task<List<ProductViewModel>> Handle(GetPagedProduct request, CancellationToken cancellationToken)
        {
            var totalCount = dbContext.Products.Count();
            var totalPages = Math.Ceiling((double)totalCount / request.PageSize);

            var productQuery = dbContext.Products.AsNoTracking().AsQueryable();

            if (Query.PropertyExists<Product>(request.OrderBy))
            {
                var orderByExpression = Query.GetPropertyExpression<Product>(request.OrderBy);
                productQuery = productQuery.OrderBy(orderByExpression);
            }
            else
            {
                productQuery = productQuery.OrderBy(c => c.ProductId);
            }

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                    .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));

            });

            var productViewModels = await productQuery.Skip((request.PageNumber - 1) * request.PageSize)
                                   .Take(request.PageSize)
                                   .ProjectTo<ProductViewModel>(config).ToListAsync().ConfigureAwait(false);

            return productViewModels;
        }
    }
}
