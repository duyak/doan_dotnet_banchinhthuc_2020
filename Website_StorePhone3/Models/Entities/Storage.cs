using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{


    public class Storage
    {
        public Storage(storage storage)
        {
            this.id = storage.id;
            this.quantity = storage.quantity;
            this.productdetail = storage.productdetail;
        }


        public int id { get; set; }
        public int productDetailId { get; set; }
        public int quantity { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
        public virtual productdetail productdetail { get; set; }

    }
}