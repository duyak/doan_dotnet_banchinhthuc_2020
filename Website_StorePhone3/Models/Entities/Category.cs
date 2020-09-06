using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Models.Entities
{
    public class Category
    {

        public Category(category category)
        {
            this.id = category.id;
            this.name = category.name;
            this.code = category.code;
            this.description = category.description;
            this.parentId = category.parentId;
            this.activeFlag = category.activeFlag;
            this.createDate = category.createDate;
            this.updateDate = category.updateDate;
        }
        public Category(int id, string name)
        {
            this.id = id;
            this.name = name;

        }
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string description { get; set; }
        public int activeFlag { get; set; }
        public Nullable<int> parentId { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

       
    }
}