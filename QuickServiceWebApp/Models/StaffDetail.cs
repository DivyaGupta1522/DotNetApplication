using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuickServiceWebApp.Models
{
    public class StaffDetail
    {
        [Display(Name = "Staff Id")]
        public string StaffId { get; set; }

        [Display(Name = "Staff Name")]
        public string StaffName { get; set; }

        [Display(Name = "Password")]
        public string StaffPassword { get; set; }

        [Display(Name = "Job Assigned")]
        public string JobAssigned { get; set; }
    }
}