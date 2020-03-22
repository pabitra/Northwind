using System;
using MediatR;
using Northwind.Api.Response;

namespace Northwind.Api.Request
{
    public class CreateProductCommand: IRequest<ApiResponse<string>>
    {
        
        public int? Id { get; set; }
        public int supplier_ids { get; set; }
        public string Product_code { get; set; }
        public string product_name { get; set; }
        public string description { get; set; }
        public decimal standard_cost { get; set; }

        public decimal list_price { get; set; }

        public int reorder_level { get; set; }

        public int Target_level { get; set; }

        public string quantity_per_unit { get; set; }

        public int discontinued { get; set; }

        public int minimum_reorder_quantity { get; set; }

        public string category { get; set; }

        public string attachments { get; set; }
    }
}
