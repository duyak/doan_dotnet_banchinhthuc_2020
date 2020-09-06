using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Models.Entities
{
    public class User
    {

        public User(user user)
        {
            this.id = user.id;
            this.username = user.username;
            this.password = user.password;
            this.email = user.email;
            this.activeFlag = user.activeFlag;
            this.createDate = user.createDate;
            this.updateDate = user.updateDate;

        }
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public int activeFlag { get; set; }
        public System.DateTime createDate { get; set; }
        public System.DateTime updateDate { get; set; }
    }
}