using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QuickServiceWebApp.Repository;
using QuickServiceDAL;
using System.Net.Http;

namespace QuickServiceWebApp.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AllStaffMembers()
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage resp = serviceObj.GetResponse("api/Staff/GetAllStaffMemberDetails/");
            resp.EnsureSuccessStatusCode();
            var lstStaffMod = resp.Content.ReadAsAsync<IEnumerable<Models.StaffDetail>>().Result;
            return View(lstStaffMod);
        }
    }
}