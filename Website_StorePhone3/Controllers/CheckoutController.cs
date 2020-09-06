using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Controllers
{
    public class CheckoutController : Controller
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        // GET: Checkout
        public ActionResult Checkout()
        {

            List<Cart> carts = Session["cart"] as List<Cart>;
            int quanTotal = 0;
            decimal totalPrice = 0;
            if (carts != null || carts.Count != 0)
            {
                foreach (Cart c in carts)
                {
                    totalPrice += c.TotalPrice;
                    quanTotal += c.Quantity;
                }

                ViewBag.totalPrice = totalPrice;
                ViewBag.carts = carts;

            }
            var order = new Order();
            return View(order);
        }

        [HttpPost]
        public ActionResult Checkout(Order order)
        {
            List<Cart> carts = Session["cart"] as List<Cart>;
            int quanTotal = 0;
            decimal totalPrice = 0;
            if (carts != null || carts.Count != 0)
            {
                foreach (Cart c in carts)
                {
                    totalPrice += c.TotalPrice;
                    quanTotal += c.Quantity;
                }
            }

            if (ModelState.IsValid)
            {
                order or = new order();
              
                or.name = order.name;
                or.phoneNumber = order.phoneNumber;
                or.address = order.address;
                or.payment = (int)order.payment;
                or.quantity = quanTotal;
                or.amount = totalPrice;
                or.status = 0;
                or.activeFlag = 1;
              
                or.createDate = DateTime.Now;
                or.updateDate = DateTime.Now;

                this.db.orders.Add(or);
                this.db.SaveChanges();

               

                foreach (Cart c in carts)
                {
                    orderdetail od = new orderdetail();
                    od.orderId = or.id;
                    od.productDetailId = c.ProductDetail.id;
                    od.quanlity = c.Quantity;
                    od.price = c.TotalPrice;
                    od.activeFlag = 1;
                    od.createDate = DateTime.Now; 
                    od.updateDate = DateTime.Now; 

                    this.db.orderdetails.Add(od);
                    this.db.SaveChanges();

                    Session.Remove("cart");
                    Session["order"] = or;
                }
                return RedirectToAction("orderReceived", "Checkout");
            }



            ViewBag.totalPrice = totalPrice;
            ViewBag.carts = carts;

            return View(order);

        }

        public ActionResult orderReceived()
        {
            order or = Session["order"] as order;
            order or1 = db.orders.Find(or.id);
            Order order = new Order(or1);

            ICollection<OrderDetail> orderdetails = order.orderdetails;
            productdetail pd;
            foreach (OrderDetail od in orderdetails)
            {
                od.productdetail.spec.getValueByName("Bộ nhớ trong");
            }
            ViewBag.order = order;
            ViewBag.orderDetail = orderdetails;


            return View();
        }
    }
}