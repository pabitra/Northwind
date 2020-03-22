using System.Collections.Generic;
using MediatR;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Request
{
    public class GetAllProduct : IRequest<List<ProductViewModel>>
    {
       
    }
}
