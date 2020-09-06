using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.DAO;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models.Entities;
namespace Website_StorePhone3.Controllers.Rest
{
    public class RestProductController : Controller
    {

        private ProductDAO productDAO = new ProductDAO();
        private ProductDetailDAO productDetailDAO = new ProductDetailDAO();
        [NonAction]
        public int checkProductInStorage(int productDetailId)
        {
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
            String sql = "select * from storage s where s.quantity>0 and s.productDetailId=" + productDetailId;
            List<storage> storages = db.storages.SqlQuery(sql).ToList<storage>();
            return storages.Count;
        }

        public JsonResult getProduct()
        {
            int proId = int.Parse(Request.QueryString["product_id"]);
            int specId = int.Parse(Request.QueryString["spec_id"]);

            List<Models.Entities.ProductDetail> productdetails = new List<Models.Entities.ProductDetail>();
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();


            Product product = productDAO.findProductById(proId);
            Product pro = new Product(product.id, product.name, product.description, product.imgMain,
                                      new Brand(product.brand.id, product.brand.name), new Category(product.category.id, product.category.name)
                );

            Models.Entities.ProductDetail productdetail;
            SpecDetail specdetail;
            Spec spec;
            HashSet<SpecDetail> specdetails = new HashSet<SpecDetail>();
            foreach (Models.Entities.ProductDetail pd in product.productdetails)
            {
                if (pd.spec.id == specId)
                {
                    foreach (SpecDetail sd in pd.spec.specdetails)
                    {
                        specdetail = new SpecDetail(sd.id, sd.name, sd.value);
                        specdetails.Add(specdetail);

                    }

                    spec = new Spec(pd.spec.id, specdetails);
                    int status = 0;

                    if (checkProductInStorage(pd.id) > 0)
                    {
                        status = 1;
                    }

                    productdetail = new Models.Entities.ProductDetail(pd.id, spec, new Color(pd.color.id, pd.color.name),
                        pd.price, pd.imgUrl, status);

                    productdetails.Add(productdetail);
                }


            }


            return Json(productdetails, JsonRequestBehavior.AllowGet);


        }
        [NonAction]
        private int ktTrungSP(int idPD)
        {
            List<Cart> carts = Session["cart"] as List<Cart>;
            for (int i = 0; i < carts.Count; i++)
            {
                if (carts[i].ProductDetail.id == idPD)
                {
                    return i;
                }
            }

            return -1;
        }
        public JsonResult getImgByColor()
        {
            int proDetailId = int.Parse(Request.QueryString["productDetailId"]);

            ProductDetail pd = this.productDetailDAO.findProductDetailById(proDetailId);

            ProductDetail productdetail;
            SpecDetail specdetail;
            Spec spec;

            HashSet<SpecDetail> specdetails = new HashSet<SpecDetail>();


            foreach (SpecDetail sd in pd.spec.specdetails)
            {
                specdetail = new SpecDetail(sd.id, sd.name, sd.value);
                specdetails.Add(specdetail);

            }

            spec = new Spec(pd.spec.id, specdetails);
            int status = 0;

            if (checkProductInStorage(pd.id) > 0)
            {
                status = 1;
            }

            productdetail = new ProductDetail(pd.id, spec, new Color(pd.color.id, pd.color.name), pd.price, pd.imgUrl, status);


            return Json(productdetail, JsonRequestBehavior.AllowGet);


        }
        public JsonResult getProductById()
        {


            int productDetailId = int.Parse(Request.QueryString["id"]);
            ProductDetail productDetail = this.productDetailDAO.findProductDetailById(productDetailId);
            productDetail.spec.getValueByName("Bộ nhớ trong");

            return Json(productDetail, JsonRequestBehavior.AllowGet);

        }
        public JsonResult searchProduct()
        {
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
            List<product> products = new List<product>();

            String keys = (Request.QueryString["keys"]);

            db.Configuration.ProxyCreationEnabled = false;

            StringBuilder sql = new StringBuilder("select * from product p WHERE p.name LIKE");

            string[] listkeys = keys.Trim().Split(' ');
            if (listkeys.Length > 1)
            {
                sql.Append("'%").Append(listkeys[0]).Append("%'");
                for (int i = 1; i < listkeys.Length; i++)
                {
                    sql.Append(" AND name LIKE " + "'%").Append(listkeys[i]).Append("%'");
                }
            }
            else
            {
                sql.Append("'%").Append(keys).Append("%'");
            }

            List<product> list = db.products.SqlQuery(sql.ToString()).ToList<product>();


            foreach (product product in list)
            {
                products.Add(product);
                System.Diagnostics.Debug.WriteLine("Tên sản phẩm có trong database :" + product.name);

            }

            System.Diagnostics.Debug.WriteLine("Số lượng :" + products.Count());
            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listProductPagging()
        {
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
            List<product> products = new List<product>();
            int limit = int.Parse(Request.QueryString["limit"]);
            System.Diagnostics.Debug.WriteLine(limit);
            db.Configuration.ProxyCreationEnabled = false;
            String sql = "SELECT * FROM product WHERE brandId=2 LIMIT " + limit + ",3";
            List<product> list = db.products.SqlQuery(sql.ToString()).ToList<product>();


            foreach (product product in list)
            {
                products.Add(product);


            }
            System.Diagnostics.Debug.WriteLine("Phân trang theo limit" + limit + " :" + products.Count());
            /*foreach(product product in list)
            {
    

                html += " < div class="+"'col-lg-3 col-md-6'"+">";
                html += " < div class='single-product'>";
                html += " < div class='product-img'>";
                html += " < img src = '~/Content/client/img/product/"+ product.imgMain + "' height='266' width='266' />";
                html += " < div class='p_icon'>";
                html += " < a href = '@Url.Action('ProductDetail','ProductDetail', new { id = "+ product.id+" })'>";
                html += " <i class='ti-eye'></i>";
                html += " </a>";
                html += " < a href = '#'>";
                html += " <i class='ti-heart'></i>";
                html += " </a>";
                html += " < a href = '#'>";
                html += " <i class='ti-shopping-cart'></i>";
                html += " </a>";
                html += "</div>";
                html += "</div>";
                html += " <div class='product-btm'>";
                html += "<a href = '#' class='d-block'>";
                html += " <h4>"+product.name+"</h4>";
                html += " </a>";
                html += "  <div class='mt-3'>";
                html += "  <span class='mr-4 tien'>"+product.code+"</span>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";


            }*/


            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public String listProductPagging2()
        {
            dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
            List<product> products = new List<product>();
            int limit = int.Parse(Request.QueryString["limit"]);
            String html = "";
            System.Diagnostics.Debug.WriteLine(limit);
            db.Configuration.ProxyCreationEnabled = false;
            String sql = "SELECT * FROM product WHERE brandId=2 LIMIT " + limit + ",3";
            List<product> list = db.products.SqlQuery(sql.ToString()).ToList<product>();


            foreach (product product in list)
            {


                html += " < div class=" + "'col-lg-3 col-md-6'" + ">";
                html += " < div class='single-product'>";
                html += " < div class='product-img'>";
                html += " < img src = '~/Content/client/img/product/" + product.imgMain + "' height='266' width='266' />";
                html += " < div class='p_icon'>";
                html += " < a href = '@Url.Action('ProductDetail','ProductDetail', new { id = " + product.id + " })'>";
                html += " <i class='ti-eye'></i>";
                html += " </a>";
                html += " < a href = '#'>";
                html += " <i class='ti-heart'></i>";
                html += " </a>";
                html += " < a href = '#'>";
                html += " <i class='ti-shopping-cart'></i>";
                html += " </a>";
                html += "</div>";
                html += "</div>";
                html += " <div class='product-btm'>";
                html += "<a href = '#' class='d-block'>";
                html += " <h4>" + product.name + "</h4>";
                html += " </a>";
                html += "  <div class='mt-3'>";
                html += "  <span class='mr-4 tien'>" + product.code + "</span>";
                html += "</div>";
                html += "</div>";
                html += "</div>";
                html += "</div>";


            }


            return html;
        }
    }

}