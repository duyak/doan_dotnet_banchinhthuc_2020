using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.DAO;
namespace Website_StorePhone3.Areas.Admin.Controllers.Rest
{
    public class RestVoucherController : Controller
    {
        ProductDAO productDAO = new ProductDAO();
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();


        private int ktTrungSP(int pDId, int voucherId)
        {
            List<Product> products = Session["productVoucher" + voucherId] as List<Product>;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].id == pDId)
                {
                    return i;
                }
            }

            return -1;
        }
        // GET: Admin/RestVoucher
        public JsonResult loadProduct()
        {
            int voucherId = int.Parse(Request.QueryString["voucherId"]);
            voucher voucher = db.vouchers.Find(voucherId);
            List<product> products = new List<product>();
            foreach (product p in voucher.products)
            {
                products.Add(new product(p.id, p.name));

            }



            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getListProductByCategoryId()
        {
            int categoryId = int.Parse(Request.QueryString["categoryId"]);
            List<product> products = this.productDAO.getProductByCategoryId(categoryId);
            List<product> list = new List<product>();
            foreach (product pro in products)
            {
                list.Add(new product(pro.id, pro.name));
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult findVoucherById()
        {
            int vouId = int.Parse(Request.QueryString["voucherId"]);
            voucher voucher = db.vouchers.Find(vouId);
            String startDate = Convert.ToDateTime(voucher.startDate).ToString("yyyy-MM-dd");
            String endDate = Convert.ToDateTime(voucher.endDate).ToString("yyyy-MM-dd");

            Voucher v = new Voucher(voucher.id, voucher.name, voucher.productId, voucher.price, voucher.status, voucher.activeFlag, startDate, endDate, new product(voucher.product.id, voucher.product.name));

            return Json(v, JsonRequestBehavior.AllowGet);

        }



        public JsonResult selectedProductVoucher()
        {
            int productId = int.Parse(Request.QueryString["productId"]);
            int voucherId = int.Parse(Request.QueryString["voucherId"]);
            if (Session["productVoucher" + voucherId] == null)
            {
                Product product = this.productDAO.findProductById(productId);
                List<Product> list = new List<Product>();
                list.Add(product);
                Session["productVoucher" + voucherId] = list;
            }
            else
            {
                List<Product> list1 = Session["productVoucher" + voucherId] as List<Product>;
                int index = this.ktTrungSP(productId, voucherId);
                if (index == -1)
                {
                    Product product = this.productDAO.findProductById(productId);
                    list1.Add(product);
                    Session["productVoucher" + voucherId] = list1;
                }


            }
            List<Product> products = Session["productVoucher" + voucherId] as List<Product>;
            List<Product> listProduct = new List<Product>();
            foreach (Product p in products)
            {
                listProduct.Add(new Product(p.id, p.name));
            }

            return Json(listProduct, JsonRequestBehavior.AllowGet);
        }
        public JsonResult chooseProductVoucher()
        {
            int productId = int.Parse(Request.QueryString["productId"]);
            Product product = this.productDAO.findProductById(productId);
            Product pro = new Product(product.id, product.name);
            return Json(pro, JsonRequestBehavior.AllowGet);

        }

        private JsonResult deleteProductVoucherInCart()
        {
            int proId = int.Parse(Request.QueryString["productId"]);
            int vouId = int.Parse(Request.QueryString["voucherId"]);

            if (Session["productVoucher" + vouId] != null)
            {
                List<Product> listP = Session["productVoucher" + vouId] as List<Product>;

                int index1 = this.ktTrungSP(proId, vouId);
                if (index1 != -1)
                {
                    listP.RemoveAt(index1);
                }
            }
            List<Product> listPro = new List<Product>();
            List<Product> products = Session["productVoucher" + vouId] as List<Product>;
            if (products != null)
            {

                foreach (Product p in products)
                {
                    listPro.Add(new Product(p.id, p.name));
                }


            }
            return Json(listPro, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult addVoucher(VoucherForm voucherForm)
        {

            System.Diagnostics.Debug.WriteLine("name " + voucherForm.Name);
            System.Diagnostics.Debug.WriteLine("product id " + voucherForm.ProductId);
            System.Diagnostics.Debug.WriteLine("voucher id " + voucherForm.VoucherId);
            System.Diagnostics.Debug.WriteLine("price " + voucherForm.Price);
            System.Diagnostics.Debug.WriteLine("start " + voucherForm.StartDate);
            System.Diagnostics.Debug.WriteLine("end " + voucherForm.EndDate);
            string message = "";


            //update
            if (voucherForm.VoucherId != 0)
            {
                voucher v = db.vouchers.Find(voucherForm.VoucherId);
                DateTime startDate = DateTime.Parse(voucherForm.StartDate);

                DateTime endDate = DateTime.Parse(voucherForm.EndDate);
                v.startDate = startDate;
                v.endDate = endDate;
                v.name = voucherForm.Name;
                v.product = db.products.Find(voucherForm.ProductId);
                v.price = voucherForm.Price;

                db.Entry(v).State = System.Data.EntityState.Modified;
                db.SaveChanges();

            }
            else
            {


                voucher v = new voucher();
                v.name = voucherForm.Name;
                v.price = voucherForm.Price;
                v.product = db.products.Find(voucherForm.ProductId);
                DateTime startDate = DateTime.Parse(voucherForm.StartDate);

                DateTime endDate = DateTime.Parse(voucherForm.EndDate);
                v.startDate = startDate;
                v.endDate = endDate;
                v.createDate = DateTime.Now;
                v.updateDate = DateTime.Now;
                v.activeFlag = 1;
                v.status = 1;

                this.db.vouchers.Add(v);
                this.db.SaveChanges();

                message = "SUCCESS";
            }




            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult deleteVoucher(VoucherForm voucherForm)
        {
            string message = "";
            System.Diagnostics.Debug.WriteLine("voucher id " + voucherForm.VoucherId);
            if (voucherForm.VoucherId != 0)
            {
                try
                {
                    voucher v = db.vouchers.Find(voucherForm.VoucherId);
                    v.activeFlag = 0;
                    db.Entry(v).State = System.Data.EntityState.Modified;
                    db.SaveChanges();
                    message = "SUCCESS";

                }
                catch (Exception e)
                {
                    message = "FAIL";
                }


            }

            return Json(new { Message = message }, JsonRequestBehavior.AllowGet);
        }





    }




}