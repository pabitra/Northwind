using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.DataAccess;
using Northwind.Api.Domain;
using Northwind.Api.Request;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Handlers
{
    public class ProductsQueryHandler : IRequestHandler<GetAllProduct, List<ProductViewModel>>
    {
        private NorthwindDbContext dbContext;

        public ProductsQueryHandler(NorthwindDbContext northwindDbContext)
        {
            dbContext = northwindDbContext;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                    .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));

            });
            return await dbContext.Products.AsQueryable().ProjectTo<ProductViewModel>(config).ToListAsync();
        }
    }
}
