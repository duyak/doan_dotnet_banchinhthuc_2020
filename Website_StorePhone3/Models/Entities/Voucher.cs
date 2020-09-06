using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{
    public class Voucher
    {
        public Voucher(voucher voucher)
        {
            this.id = voucher.id;
            this.name = voucher.name;
            this.price = voucher.price;

            this.startDate = voucher.startDate;
            this.endDate = voucher.endDate;
            this.status = voucher.status;
        }

        public Voucher(int id, string name, int productId, decimal price, int status, int activeFlag, String startDate, String endDate, product product)
        {
            this.id = id;
            this.name = name;
            this.productId = productId;
            this.price = price;
            this.status = status;
            this.activeFlag = activeFlag;
            this.sDate = startDate;
            this.eDate = endDate;
            this.product = product;
        }

        public int id { get; set; }
        public string name { get; set; }

        public int productId { get; set; }
        public decimal price { get; set; }
        public int status { get; set; }
        public int activeFlag { get; set; }
        public Nullable<System.DateTime> startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }

        public String sDate { get; set; }
        public String eDate { get; set; }

        public virtual product product { get; set; }

    }
}