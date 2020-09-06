using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models.Order;

namespace Website_StorePhone3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        // GET: Admin/Order
        public ActionResult Index()
        { 
            return View();
        }
        public ActionResult SearchOrder(string key, string phoneNumber,DateTime? date,int? status,int? page)
        {
            OrderModel orderModel = new OrderModel();
            ViewBag.key = key;
            ViewBag.date = date;
            ViewBag.status = status;
            ViewBag.phoneNumber = phoneNumber;
            return OrderPagination(orderModel.SearchOrder(key, phoneNumber, date, status), page, null);
 
        }
        public ActionResult OrderPagination(IQueryable<order> lst , int? page,int? pagesize)
        {
            int pageSize = (pagesize ?? 3);
            int pageNumber = (page ?? 1);
            return PartialView("PartialOrder", lst.OrderBy(m => m.status).ToPagedList(pageNumber, pageSize));
        }
        //get don hang
        public ActionResult OrderDetail(int orderid)
        {
            OrderModel orderModel = new OrderModel();
            return PartialView("OrderDetail", orderModel.orderdetail(orderid));
        }
        

    }
}