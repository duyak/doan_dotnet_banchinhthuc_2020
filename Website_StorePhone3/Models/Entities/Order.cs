using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
using System.ComponentModel.DataAnnotations;

namespace Website_StorePhone3.Models.Entities
{
    public class Order
    {
        public Order()
        {

        }

        public Order(order order)
        {
            this.id = order.id;
          
            this.name = order.name;
            this.phoneNumber = order.phoneNumber;
            this.address = order.address;
            this.payment = order.payment;
            this.quantity = order.quantity;
            this.amount = order.amount;
            this.status = order.status;
            this.activeFlag = (int)order.activeFlag;
            this.createDate = (DateTime)order.createDate;
            this.updateDate = (DateTime)order.updateDate;
            List<OrderDetail> list = new List<OrderDetail>();
            foreach (orderdetail od in order.orderdetails)
            {
                list.Add(new OrderDetail(od));
            }

            this.orderdetails = list;

            

        }
        public int id { get; set; }
        public int userId { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập họ tên")]
        [Display(Name = "Họ tên")]
        public string name { get; set; }
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại")]
        [Display(Name = "Số điện thoại")]
        public string phoneNumber { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ")]
        [Display(Name = "Địa chỉ")]
        public string address { get; set; }
        [Required(ErrorMessage = "Bạn chưa chọn hình thức thanh toán")]
        [Display(Name = "Hình thức thanh toán")]
        public int payment { get; set; }
        public int quantity { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<int> status { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }

        public virtual user user { get; set; }
        public virtual ICollection<OrderDetail> orderdetails { get; set; }
    }


}