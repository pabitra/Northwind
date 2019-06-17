using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Api.Domain
{
    public class Supplier : IEntity
    {

        public Supplier()
        {
            Products = new List<Product>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        [Column("id")]
        public int Id { get; set; }

        public string company { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string email_address { get; set; }
        public string job_title { get; set; }
        public string business_phone { get; set; }
        public string home_phone { get; set; }
        public string mobile_phone { get; set; }
        public string fax_number { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state_province { get; set; }
        public string zip_postal_code { get; set; }
        public string country_region { get; set; }
        public string web_page { get; set; }
        public string notes { get; set; }
        public string attachments { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
