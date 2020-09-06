using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Order
{
    public class OrderModel
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();

        public order order;
        private user user;
        private String status;

        public List<OrderModel> OrderView(int userId)
        {
            List<OrderModel> orderList = new List<OrderModel>();
            db.orders.AsNoTracking();
            var list = from p in db.orders where p.userId == userId select p;
            foreach (var temp in list.ToList())
            {
                user users = (from p in db.users where p.id == userId select p).FirstOrDefault();

                orderList.Add(new OrderModel()
                {
                    order = temp,
                    user = users,
                    status = getOrderStatus(temp.status)
                });
            }
            return orderList;

        }
        private string getOrderStatus(int? nullable)
        {
            switch (nullable)
            {
                case 0:
                    {
                        return "Chưa giao";
                    }
                case 1:
                    {
                        return "Đang duyệt";
                    }
                case 2:
                    {
                        return "Đang giao hàng";
                    }
                case 3:
                    {
                        return "Đã giao";
                    }
                case 4:
                    {
                        return "Đã hủy";
                    }
            }
            return "Đang duyệt";
        }
        public bool orderCanel(int orderId)
        {
            try
            {
                string query = "update Order set status ='4' where id='" + order + "";
                db.Database.ExecuteSqlCommand(query);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        public user userProfile(int id)
        {
            user users = (from p in db.users where p.id == id select p).FirstOrDefault();
            return users;
        }
        internal IQueryable<order> SearchOrder(string key,string phoneNumber, DateTime? date, int? status)
        {
            IQueryable<order> lst = db.orders;
            if (!string.IsNullOrEmpty(key))
                lst = lst.Where(m => m.name.Contains(key));
            if (!string.IsNullOrEmpty(phoneNumber))
                lst = lst.Where(m => m.phoneNumber.Contains(phoneNumber));
            if (status != null)
                lst = lst.Where(m => m.status == status);
            if (date != null)
                lst = lst.Where(m => m.createDate.Value.Year == date.Value.Year && m.createDate.Value.Month == date.Value.Month && m.createDate.Value.Day == date.Value.Day);
            return lst;
        }
        internal IQueryable<orderdetail> orderdetail(int orderId)
        {
            return db.orderdetails.Where(m => m.orderId == orderId);
        }
      
            
        }
    }
