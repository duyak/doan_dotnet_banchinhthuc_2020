using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{
    public class Spec : IComparable<Spec>
    {

        public int CompareTo(Spec that)
        {
            if (that == null) return 1;
            if (int.Parse(this.GotValue) > int.Parse(that.GotValue)) return 1;
            if (int.Parse(this.GotValue) < int.Parse(that.GotValue)) return -1;
            return 0;
        }


        public int id { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual ICollection<SpecDetail> specdetails { get; set; }
        public string GotValue { get; set; }
        public decimal GotPriceMin { get; set; }



        public Spec(int id, HashSet<SpecDetail> specdetails)
        {
            this.id = id;
            this.specdetails = specdetails;

        }

        public Spec(spec spec)
        {
            this.id = spec.id;
            List<SpecDetail> sd = new List<SpecDetail>();
            foreach (specdetail sds in spec.specdetails)

            {
                sd.Add(new SpecDetail(sds));
            }

            this.specdetails = sd;


        }


        public void getValueByName(String name)
        {
            ICollection<SpecDetail> list = this.specdetails;
            foreach (SpecDetail sp in list)
            {
                if (sp.name.Equals(name))
                {
                    this.GotValue = sp.value;
                }
            }
        }

    }
}
