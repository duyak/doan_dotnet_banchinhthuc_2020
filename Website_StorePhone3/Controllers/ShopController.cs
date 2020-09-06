using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.DAO;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        private ProductDAO productDAO = new ProductDAO();
        public ActionResult List()
        {
            using (dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1())
            {
                List<product> products = productDAO.getListProduct(0);
                List<product> productsAll = productDAO.getAllListProduct();
                double pagging = (double)productsAll.Count() / 3;
                double tongsopage = Math.Ceiling(pagging);

                ViewBag.ListPro = products;
                ViewBag.tongsopage = tongsopage;

            }

            return View();
        }
    }
}