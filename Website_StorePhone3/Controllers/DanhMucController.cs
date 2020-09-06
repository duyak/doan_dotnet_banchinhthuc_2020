using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.DAO;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Controllers
{
    public class DanhMucController : Controller
    {
        private ProductDAO productDAO = new ProductDAO();
        // GET: DanhMuc
        public ActionResult Apple()
        {
            List<product> listApple = productDAO.Apple();
            ViewBag.ListApple = listApple;
            return View();
        }


        public ActionResult SamSung()
        {
            List<product> listSamSung = productDAO.SamSung();
            ViewBag.ListSamSung = listSamSung;
            return View();
        }


        public ActionResult PhuKien()
        {
            List<product> listPhuKien = productDAO.PhuKien();
            ViewBag.listPhuKien = listPhuKien;
            return View();
        }
    }
}