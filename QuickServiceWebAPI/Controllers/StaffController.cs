using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using QuickServiceDAL;
using System.Web.Http.Results;

namespace QuickServiceWebAPI.Controllers
{
    public class StaffController : ApiController
    {
        public JsonResult<List<Models.StaffDetail>> GetAllStaffMemberDetails()
        {
            QuickServiceRepository dalObj = new QuickServiceRepository();
            var lstStaffEnt = dalObj.GetAllStaffMemberDetails();
            Repository.QuickServiceMapper<StaffDetail, Models.StaffDetail> mapObj = new Repository.QuickServiceMapper<StaffDetail, Models.StaffDetail>();
            List<Models.StaffDetail> lstStaffMod = new List<Models.StaffDetail>();
            if (lstStaffEnt != null)
            {
                foreach (var item in lstStaffEnt)
                {
                    lstStaffMod.Add(mapObj.Translate(item));
                }
            }
            return Json<List<Models.StaffDetail>>(lstStaffMod);
        }
    }
}
