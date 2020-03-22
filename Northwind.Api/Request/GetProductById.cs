using MediatR;
using Northwind.Api.ViewModels;

namespace Northwind.Api.Request
{
    public class GetProductById : IRequest<ProductViewModel>
    {
       public int ProductId { get; set; }
    }
}
