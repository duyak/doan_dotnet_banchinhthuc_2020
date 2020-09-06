using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.DAO
{
    public class ProductDAO
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        public Product findProductById(int id)
        {

            Product p = new Product(db.products.Find(id));
            return p;

        }
        public List<product> getProductByCategoryId(int cateId)
        {

            String sql = "SELECT* FROM `product` WHERE product.categoryId =" + cateId;

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }

        public List<product> getListProduct(int begin)
        {

            String sql = "SELECT * FROM product LIMIT " + begin + ",3";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }

        public List<product> getAllListProduct()
        {

            String sql = "SELECT * FROM product";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }


        public List<product> Apple()
        {

            String sql = "SELECT * FROM product WHERE categoryId=4";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }
        public List<product> SamSung()
        {

            String sql = "SELECT * FROM product WHERE categoryId=3";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }
        public List<product> PhuKien()
        {

            String sql = "SELECT * FROM product WHERE categoryId=2";

            List<product> products = db.products.SqlQuery(sql).ToList<product>();


            return products;

        }


        public List<comment> comments()
        {

            String sql = "SELECT * FROM comment";

            List<comment> comment = db.comments.SqlQuery(sql).ToList<comment>();


            return comment;

        }
    }
}