using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Models.Entities
{
    public class SpecDetail
    {

        public SpecDetail(specdetail specdetail)
        {
            this.id = specdetail.id;

            this.name = specdetail.name;
            this.value = specdetail.value;
        }

        public SpecDetail(int id, string name, string value)
        {
            this.id = id;

            this.name = name;
            this.value = value;
        }
        public int id { get; set; }
        public int specId { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual Spec spec { get; set; }
    }
}