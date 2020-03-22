using System;
using System.Collections.Generic;
using MediatR;
using Northwind.Api.Domain;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Request
{
    public class GetPagedProduct:  IRequest<List<ProductViewModel>>
    {
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string OrderBy { get; set; }

        public GetPagedProduct()
        {
        }
    }
}
