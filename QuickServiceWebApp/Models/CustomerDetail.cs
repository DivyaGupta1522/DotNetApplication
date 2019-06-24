using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickServiceWebApp.Models
{
    public class CustomerDetail
    {
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerEmailId { get; set; }
    }
}