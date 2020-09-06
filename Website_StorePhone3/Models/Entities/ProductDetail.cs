using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{
    public class ProductDetail
    {

        public ProductDetail()
        {
            this.storages = new HashSet<Storage>();
            this.hasSale = true;
        }

        public ProductDetail(productdetail productdetail)
        {
            this.id = productdetail.id;
            this.spec = new Spec(productdetail.spec);
            this.color = new Color(productdetail.color);
            this.price = productdetail.price;
            this.imgUrl = productdetail.imgUrl;

            this.product = productdetail.product;
            this.hasSale = true;

        }
        public ProductDetail(int id, Spec spec, Color color, decimal price, string imgUrl, int status)
        {
            this.id = id;
            this.spec = spec;
            this.color = color;
            this.price = price;
            this.imgUrl = imgUrl;
            this.Status = status;

        }
        public int id { get; set; }
        public int productId { get; set; }
        public int specId { get; set; }
        public int colorId { get; set; }
        public decimal price { get; set; }
        public string imgUrl { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public int status;
        private Boolean hasSale;
        private decimal afterPrice;
        public virtual Color color { get; set; }
        public virtual product product { get; set; }
        public virtual ICollection<Storage> storages { get; set; }
        public virtual Spec spec { get; set; }
        public int Status { get => status; set => status = value; }
        public bool HasSale { get => hasSale; set => hasSale = value; }
        public decimal AfterPrice { get => afterPrice; set => afterPrice = value; }
    }
}