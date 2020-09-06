using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Models.Entities
{
    public class Color
    {

        public Color(color color)
        {
            this.id = color.id;
            this.name = color.name;
        }
        public Color(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public int id { get; set; }
        public string name { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual ICollection<productdetail> productdetails { get; set; }

    }
}