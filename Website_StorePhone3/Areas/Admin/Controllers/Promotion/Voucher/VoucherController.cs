using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.DAO;

namespace Website_StorePhone3.Areas.Admin.Controllers.Promotion.Voucher
{
    [Authorize(Roles = "Admin")]
    public class VoucherController : Controller
    {
        VoucherDAO voucherDAO = new VoucherDAO();
        CategoryDAO categoryDAO = new CategoryDAO();
        // GET: Admin/Voucher
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();

       
        public ActionResult voucherList()
        {
            List<voucher> list = this.voucherDAO.getListVoucher();
            List<Category> categories = this.categoryDAO.GetCategories();

            ViewBag.vouchers = list;
            ViewBag.cates = categories;

            return View();
        }

        [HttpPost]
        public ActionResult addVoucherProduct()
        {

            System.Diagnostics.Debug.WriteLine("them voucher product");
            int voucherId = Convert.ToInt32(Request.Form["voucherId"]);
            System.Diagnostics.Debug.WriteLine("voucher id"+voucherId);

            voucher v = new voucher { id = voucherId };
            db.vouchers.Add(v);
            db.vouchers.Attach(v);

            List<Product> products = Session["productVoucher" + voucherId] as List<Product>;
            product product;
            foreach (Product pro in products)
            {
                product = new product {id = pro.id };
                db.products.Add(product);
                db.products.Attach(product);
                v.products.Add(product);
                db.SaveChanges();
            }

            Session.Remove("productVoucher" + voucherId);
            return RedirectToAction("voucherList", "Voucher");


        }

        [HttpPost]
        public ActionResult deleteProductVoucher()
        {
            int productId = int.Parse(Request.QueryString["productId"]);
            System.Diagnostics.Debug.WriteLine("pro id" + productId);

            int voucherId = Convert.ToInt32(Request.Form["voucherId"]);
          
            var voucher = db.vouchers.FirstOrDefault(v => v.id == voucherId);
            var product = db.products.FirstOrDefault(p => p.id == productId);
            voucher.products.Remove(product);
            db.SaveChanges();


            return RedirectToAction("voucherList", "Admin/Voucher");

        }


    }
}