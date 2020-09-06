using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Cart()
        {
            List<Cart> carts = Session["cart"] as List<Cart>;
            List<voucher> vouchers = new List<voucher>();
            List<String> gotVouchers = new List<String>();
            List<product> products = new List<product>();
            List<String> gotProducts = new List<String>();

            if (carts != null)
            {
                foreach (Cart c in carts)
                {
                    if (!gotProducts.Contains(c.ProductDetail.product.name))
                    {
                        products.Add(c.ProductDetail.product);

                    }
                    gotProducts.Add(c.ProductDetail.product.name);
                }

                foreach (product p in products)
                {
                    foreach (voucher v in p.vouchers1)
                    {
                        if (!gotVouchers.Contains(v.name))
                        {
                            vouchers.Add(v);
                        }
                        gotVouchers.Add(v.name);
                    }
                }

                foreach (Cart c in carts)
                {
                    if (c.ProductDetail.HasSale)
                    {
                        c.ProductDetail.AfterPrice = c.ProductDetail.price;
                    }



                    foreach (voucher v in vouchers)
                    {
                        System.Diagnostics.Debug.WriteLine("dc ho tro voucherdfsdfsdfsdfsd");
                        System.Diagnostics.Debug.WriteLine("id product voucher" + v.product.id);
                        System.Diagnostics.Debug.WriteLine("id product" + c.ProductDetail.product.id);
                        int index = ktTrungSP(c.ProductDetail.id);
                        if (index != -1)
                        {
                            if (v.product.id == c.ProductDetail.product.id)
                            {

                                System.Diagnostics.Debug.WriteLine("dc ho tro voucher");

                                if (c.ProductDetail.HasSale)
                                {
                                    c.ProductDetail.HasSale = false;
                                    decimal total = c.TotalPrice;
                                    decimal priceVoucher = v.price;
                                    decimal priceAfter = total - priceVoucher;
                                    carts[index].ProductDetail.AfterPrice = priceAfter;
                                    carts[index].TotalPrice = priceAfter;

                                }
                            }
                        }
                    }

                }



            }

            ViewBag.vouchers = vouchers;
            ViewBag.carts = carts;
            return View();
        }

        [NonAction]
        private int ktTrungSP(int idPD)
        {
            List<Cart> carts = Session["cart"] as List<Cart>;
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].ProductDetail.id == idPD)
                {
                    return i;
                }
            }

            return -1;
        }

    }
}