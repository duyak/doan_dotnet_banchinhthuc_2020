using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_StorePhone3.Models.Entities
{
    public class Cart
    {
		private ProductDetail productDetail;
		private int quantity;
		private decimal totalPrice;
		private decimal totalCart;

        public ProductDetail ProductDetail { get => productDetail; set => productDetail = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public decimal TotalCart { get => totalCart; set => totalCart = value; }
    }
}