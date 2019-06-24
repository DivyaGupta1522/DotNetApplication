using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QuickServiceDAL;

namespace QuickServiceWebApp.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {
            ViewBag.Msg=TempData["Msg"];
            var dalObj = new QuickServiceRepository();
            if (frm["LoginId"] != null && frm["password"] != null)
            {
                string loginId = dalObj.ValidateCredentials(frm["LoginId"], frm["password"]);
                if (loginId != null)
                {
                    if (loginId[0] == 'C')
                    {
                        Session["Role"] = "Customer";
                        Session["LoginId"] = loginId;
                        return Redirect("/Customer/CreateRequest/");
                    }
                    else if (loginId[0] == 'A')
                    {
                        Session["Role"] = "Admin";
                        Session["LoginId"] = loginId;
                        return Redirect("/Admin/AllCustomersRequests/");
                    }
                    else if (loginId[0] == 'S')
                    {
                        Session["Role"] = "Staff";
                        Session["LoginId"] = loginId;
                        return Redirect("/Staff/ViewDashboard/");
                    }
                    else
                    {
                        ViewBag.Msg = "InValid Credential. Try again later.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Msg = "InValid Credential. Try again later.";
                    return View();
                }
            }
            else if (frm["UserName"] != null && frm["UserEmailId"] != null && frm["UserPassword"] != null)
            {
                string id = dalObj.AddCustomerDetail(frm["UserName"], frm["UserEmailId"], frm["UserPassword"]);
                if (id != null)
                {
                    Session["LoginId"] = id;
                    return Redirect("/Customer/CreateRequest/");
                }
                else
                {
                    ViewBag.Msg = "Make sure all the values are provided and email id should not be used before. Try again.";
                    return View();
                }
            }
            else
            {
                ViewBag.Msg = "InValid Data Entered.";
                return View();
            }
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool CheckValidEmailId(string EmailId)
        {
            QuickServiceRepository dalObj = new QuickServiceRepository();
            return dalObj.CheckValidEmailId(EmailId);

        }
    }
}