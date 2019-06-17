using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Api.Domain
{
    public class Product : IEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        [Column("id")]
        public int Id { get; set; }

        public int supplier_ids { get; set; }

        [StringLength(25, MinimumLength = 5)]
        public string Product_code { get; set; }

        [StringLength(25)]
        public string product_name { get; set; }

        public string description { get; set; }

        public decimal standard_cost { get; set; }

        public decimal list_price { get; set; }

        public int reorder_level { get; set; }

        public int target_level { get; set; }

        public string quantity_per_unit { get; set; }

        public int discontinued { get; set; }

        public int minimum_reorder_quantity { get; set; }

        public string category { get; set; }

        public string attachments { get; set; }

        public Supplier Supplier { get; set; }
    }
}
