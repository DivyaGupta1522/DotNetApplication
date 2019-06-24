using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickServiceWebAPI.Models
{
    public class StaffDetail
    {
        public string StaffId { get; set; }
        public string StaffName { get; set; }
        public string StaffPassword { get; set; }
        public string JobAssigned { get; set; }
    }
}