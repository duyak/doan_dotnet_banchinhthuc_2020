//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Website_StorePhone3.Models.db
{
    using System;
    using System.Collections.Generic;
    public partial class spec : IComparable<spec>
    {
        public int CompareTo(spec that)
        {
            if (that == null) return 1;
            if (int.Parse(this.GotValue) > int.Parse(that.GotValue)) return 1;
            if (int.Parse(this.GotValue) < int.Parse(that.GotValue)) return -1;
            return 0;
        }
        public spec()
        {
            this.productdetails = new HashSet<productdetail>();
            this.specdetails = new HashSet<specdetail>();
        }

        public int id { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual ICollection<productdetail> productdetails { get; set; }
        public virtual ICollection<specdetail> specdetails { get; set; }


        public string GotValue { get => gotValue; set => gotValue = value; }
        public decimal GotPriceMin { get => gotPriceMin; set => gotPriceMin = value; }

        private String gotValue;
        private decimal gotPriceMin;

        public void getValueByName(String name)
        {
            ICollection<specdetail> list = this.specdetails;
            foreach (specdetail sp in list)
            {
                if (sp.name.Equals(name))
                {
                    this.GotValue = sp.value;
                }
            }
        }
    }
}
