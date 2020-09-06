using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{
    public class OrderDetail
    {
        public OrderDetail(orderdetail orderdetail)
        {
            this.orderId = orderdetail.orderId;
            this.productDetailId = orderdetail.productDetailId;
            this.quanlity = orderdetail.quanlity;
            this.price = orderdetail.price;
            this.productdetail = orderdetail.productdetail;

        }

        public int orderId { get; set; }
        public int productDetailId { get; set; }
        public int quanlity { get; set; }
        public decimal price { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public virtual productdetail productdetail { get; set; }
    }
}