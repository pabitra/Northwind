using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Api.DataAccess;
using Northwind.Api.Domain;
using Northwind.Api.Request;
using Northwind.Api.ViewModels;
using AutoMapper.QueryableExtensions;

namespace Northwind.Api.Handlers
{
    public class ProductByIdHandler: IRequestHandler<GetProductById, ProductViewModel>
    {
        private NorthwindDbContext dbContext;

        public ProductByIdHandler(NorthwindDbContext northwindDbContext)
        {
            dbContext = northwindDbContext;
        }

        public  async Task<ProductViewModel> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            var productQuery = dbContext.Products.AsNoTracking().AsQueryable();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName))
                    .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(src => src.Supplier.CompanyName));

            });

            return await productQuery.ProjectTo<ProductViewModel>(config).FirstOrDefaultAsync().ConfigureAwait(false);
        }
    }
}
