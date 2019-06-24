using QuickServiceWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QuickServiceDAL;
using QuickServiceWebApp.Repository;


namespace QuickServiceWebApp.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer/Create
        public ActionResult CreateRequest()
        {
            try
            {
                // Customer can place service requests for the existing ordered item.

                // Hardcoding the ordered items for a customer (customerId=1001) 
                var orderList = new List<Models.Order>() { new Models.Order() {RowKey="O1001", ProductName="Lenovo A7000", PurchasedDate=Convert.ToDateTime("06/23/2016"), CustomerId=Session["LoginId"].ToString() },
                 new Models.Order() { RowKey = "O1001", ProductName = "Lenovo A6000", PurchasedDate = Convert.ToDateTime("05/21/2016"), CustomerId=Session["LoginId"].ToString() } };
                // Adding each order in a list of SelectListItem for using in a drop down list.
                var orderList1 = new List<SelectListItem>();
                foreach (var item in orderList)
                {
                    // In drop down list display text is ProductName and corresponding value is OrderId. 
                    orderList1.Add(new SelectListItem { Value = item.RowKey, Text = item.ProductName });
                }
                ViewBag.OrderList = orderList1;


                //// adding the Orders to the Drop Down List

                //var objDAL = new QuickServiceRepository();
                //var orderListFromTable = objDAL.GetOrdersByCustomerId("1001");
                //var orderList2 = new List<SelectListItem>();
                //foreach (var item in orderListFromTable)
                //{
                //    // In drop down list display text is ProductName and corresponding value is OrderId. 
                //    orderList2.Add(new SelectListItem { Value = item.RowKey, Text = item.ProductName });
                //}
                //ViewBag.OrderList = orderList2;

                return View();
            }
            catch (Exception e)
            {
                ViewBag.err = e.Message;
                return View("Error");
            }
        }
    }
}