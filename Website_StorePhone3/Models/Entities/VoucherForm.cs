using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website_StorePhone3.Models.Entities
{
    public class VoucherForm
    {
        private int productId;
        private int voucherId;
        private String name;
        private decimal price;
        private String startDate;
        private String endDate;

        public int ProductId { get => productId; set => productId = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public string StartDate { get => startDate; set => startDate = value; }
        public string EndDate { get => endDate; set => endDate = value; }
        public int VoucherId { get => voucherId; set => voucherId = value; }
    }
}