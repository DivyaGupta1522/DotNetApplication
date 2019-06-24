using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace QuickServiceWebApp.Models
{
    public class Request
    {
        [Display(Name = "Problem Description")]
        [Required(ErrorMessage = "Mandatory")]
        public string ProblemStatement { get; set; }

        [Display(Name = "Order Id")]
        [Required(ErrorMessage = "Mandatory")]
        public string OrderId { get; set; }

        [Display(Name = "Assignee Id")]
        public string AssigneeId { get; set; }

        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }

        [Display(Name = "Time When Request Was Raised")]
        public DateTime TimeRequestRaised { get; set; }

        [Display(Name = "Time When Request Was Acknowledged")]
        public DateTime TimeRequestAssigned { get; set; }

        [Display(Name = "Time When Request Was Closed")]
        public DateTime TimeRequestClosed { get; set; }

        [Display(Name = "Request Id")]
        public string RowKey { get; set; }
    }
}