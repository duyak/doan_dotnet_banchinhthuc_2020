using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models.Entities;
namespace Website_StorePhone3.DAO
{
    public class ProductDetailDAO
    {
        public ProductDetail findProductDetailById(int id)
        {
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();

            ProductDetail pd = new ProductDetail(db.productdetails.Find(id));
            return pd;
        }

        public decimal getMinValue(int specID)
        {

            String sql = "select MIN(price) from productdetail where specId=" + specID;
            using (dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1())
            {

                decimal minPrice = db.Database.SqlQuery<decimal>(sql).FirstOrDefault();
                return minPrice;

            }

        }
    }
}