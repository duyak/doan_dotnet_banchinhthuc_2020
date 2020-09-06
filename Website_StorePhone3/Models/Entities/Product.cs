using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Models.Entities
{
    public class Product
    {
        public Product(int id, string name, string description, string imgMain, Brand brand1, Category category)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.imgMain = imgMain;
            this.brand = brand1;
            this.category = category;
        }

        public Product(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
        public Product(product product)
        {
            this.id = product.id;
            this.name = product.name;
            this.description = product.description;
            this.imgMain = product.imgMain;
            this.brand = new Brand(product.brand);
            this.category = new Category(product.category);

            List<ProductDetail> details = new List<ProductDetail>();
            foreach (productdetail dt in product.productdetails)
            {
                details.Add(new ProductDetail(dt));
            }

            this.productdetails = details;


            List<Voucher> voucherList = new List<Voucher>();
            foreach (voucher v in product.vouchers)
            {
                voucherList.Add(new Voucher(v));
            }

            this.vouchers = voucherList;
        }



        public int id { get; set; }
        public int itemId { get; set; }
        public int brandId { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public string imgMain { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual Brand brand { get; set; }
        public virtual Category category { get; set; }
       

        public virtual ICollection<ProductDetail> productdetails { get; set; }

        public virtual ICollection<Voucher> vouchers { get; set; }


    }

}