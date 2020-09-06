using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.DAO;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductDetailController : Controller
    {
        CategoryDAO categoryDAO = new CategoryDAO();
        ColorDAO colorDAO = new ColorDAO();
        ProductDAO productDAO = new ProductDAO();

        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        public ActionResult productDetailList(int productId)
        {
            List<Color> colors = this.colorDAO.getListColor();
            List<Category> categories = this.categoryDAO.GetCategories();

            product product = db.products.Find(productId);
            List<ProductDetail> productDetails = new List<ProductDetail>();

            foreach (productdetail pd in product.productdetails)
            {
                productDetails.Add(new ProductDetail(pd));

            }

            List<String> listNames = new List<string>();
            listNames.Add("Hãng sản xuất");
            listNames.Add("Kích thước");
            listNames.Add("Trọng lượng");
            listNames.Add("Bộ nhớ đệm / Ram");
          
            listNames.Add("Bộ nhớ trong");
            listNames.Add("Loại SIM");
            listNames.Add("Loại màn hình");
            listNames.Add("Kích thước màn hình");

            listNames.Add("Độ phân giải màn hình");
            listNames.Add("Hệ điều hành");
            listNames.Add("Phiên bản hệ điều hành");
            listNames.Add("Khe cắm thẻ nhớ");
            listNames.Add("WLAN");
            listNames.Add("Bluetooth");
            listNames.Add("GPS");
            listNames.Add("NFC");
            listNames.Add("Cảm biến");
            listNames.Add("Pin");


            List<String> listNamesForFK = new List<string>();
            listNamesForFK.Add("Hãng sản xuất");
            listNamesForFK.Add("Kích thước");
            listNamesForFK.Add("Cổng sạc ra");
            listNamesForFK.Add("Pin");


            if (product.category.parentId == 1)
            {
                ViewBag.listName = listNames;

            }
            else
            {
                ViewBag.listName = listNamesForFK;
            }

            ViewBag.product = product;

            ViewBag.pds = productDetails;
            ViewBag.colors = colors;
            ViewBag.categories = categories;

            return View();
        }

        public ActionResult Add([Bind(Include = "id,activeFlag,createDate,updateDate")] productdetail productdetail, int productId, int colorId, decimal price, HttpPostedFileBase imgUrl)
        {


            string fileName = System.IO.Path.GetFileName(imgUrl.FileName);
            String date = DateTime.Now.ToString();
            System.Diagnostics.Debug.WriteLine("date " + date);
            string urlImage = Server.MapPath("~/Content/client/img/product/" + fileName);
            imgUrl.SaveAs(urlImage);
            productdetail.imgUrl =  fileName;
            int countSpec = Convert.ToInt32(Request.Form["countSpec"]);
            System.Diagnostics.Debug.WriteLine("product id " + productId);
            System.Diagnostics.Debug.WriteLine("color id " + colorId);
            System.Diagnostics.Debug.WriteLine("price " + price);
            System.Diagnostics.Debug.WriteLine("file name " + fileName);

            System.Diagnostics.Debug.WriteLine("count " + countSpec);

            spec spec = new spec();
            spec.activeFlag = 1;
            spec.createDate = DateTime.Now;
            spec.updateDate = DateTime.Now;
            db.specs.Add(spec);
            db.SaveChanges();

            for (int i = 0; i < countSpec; i++)
            {
                specdetail sd = new specdetail();
                sd.spec = db.specs.Find(spec.id);
                String paramName = "name_" + i;
                String paramValue = "value_" + i;
                String name = Convert.ToString(Request.Form[paramName]);
                String value = Convert.ToString(Request.Form[paramValue]);

                sd.name = name;
                sd.value = value;
                sd.activeFlag = 1;
                sd.createDate = DateTime.Now;
                sd.updateDate = DateTime.Now;

                db.specdetails.Add(sd);
                db.SaveChanges();



            }


            productdetail.product = db.products.Find(productId);
            productdetail.spec = db.specs.Find(spec.id);
            productdetail.color = db.colors.Find(colorId);
            productdetail.price = price;
            productdetail.activeFlag = 1;
            productdetail.createDate = DateTime.Now;
            productdetail.updateDate = DateTime.Now;

            db.productdetails.Add(productdetail);
            db.SaveChanges();


            return RedirectToAction("productDetailList", "AdminProductDetail", new { productId = productId });
        }
    }
}