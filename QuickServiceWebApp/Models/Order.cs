using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickServiceWebApp.Models
{
    public class Order
    {
        [Display(Name = "Order Id")]
        public string RowKey { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Purchased Date")]
        public DateTime PurchasedDate { get; set; }

        [Display(Name = "Customer Id")]
        public string CustomerId { get; set; }
    }
}