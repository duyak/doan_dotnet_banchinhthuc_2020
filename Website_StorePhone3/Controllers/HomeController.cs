using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.DAO;

namespace Website_StorePhone3.Controllers
{
    [Authorize(Roles = "User")]
    public class HomeController : Controller
    {
        private ProductDAO productDAO = new ProductDAO();
        [AllowAnonymous]
        [Authorize(Roles = "User")]
        public ActionResult Index()
        {
            List<product> products = productDAO.getListProduct(0);
            List<product> productsAll = productDAO.getAllListProduct();
            double pagging = (double)productsAll.Count() / 3;
            double tongsopage = Math.Ceiling(pagging);

            ViewBag.ListPro = products;
            ViewBag.tongsopage = tongsopage;
            return View();

        }
        [Authorize]
        public ActionResult Blog()
        {
            return View();

        }
        [Authorize]
        public ActionResult Cart()
        {
            return View();
        }
        [Authorize]
        public ActionResult ListProduct()
        {
            return View();
        }
        [Authorize]
        public ActionResult Contact()
        {
            return View();
        }
        [Authorize]
        public ActionResult CheckOut()
        {
            return View();
        }


    }
}