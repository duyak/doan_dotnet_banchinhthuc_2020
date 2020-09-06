using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.DAO
{
    public class VoucherDAO
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        public List<voucher> getListVoucher()
        {
            String sql = "SELECT* FROM `voucher` WHERE voucher.activeFlag = 1";

            List<voucher> vouchers = db.vouchers.SqlQuery(sql).ToList<voucher>();

            return vouchers;
        }

    }
}