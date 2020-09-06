using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.DAO;

namespace Website_StorePhone3.Controllers
{
    public class ProductDetailController : Controller
    {
        private ProductDAO productDAO = new ProductDAO();
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();

        [NonAction]
        public int checkProductInStorage(int productDetailId)
        {

            String sql = "select * from storage s where s.quantity>0 and s.productDetailId=" + productDetailId;
            List<storage> storages = db.storages.SqlQuery(sql).ToList<storage>();
            return storages.Count;
        }

        [NonAction]
        public decimal getMinValue(int specID)
        {

            String sql = "select MIN(price) from productdetail where specId=" + specID;



            decimal minPrice = db.Database.SqlQuery<decimal>(sql).FirstOrDefault();
            return minPrice;


        }
        // GET: ProductDetail
        public ActionResult ProductDetail(int id)
        {
            product product = db.products.Find(id);
            if (product != null)
            {
                ICollection<productdetail> productdetails = product.productdetails;
                List<productdetail> listProductDetail = new List<productdetail>();
                List<voucher> listVoucher = product.vouchers1.ToList();
                ViewBag.listVoucher = listVoucher;

                if (product.category.parentId == 1)
                {

                    HashSet<spec> specs = new HashSet<spec>();
                    HashSet<spec> got = new HashSet<spec>();


                    foreach (productdetail pd in productdetails)
                    {

                        Console.WriteLine("PD: " + pd.color.name + " " + pd.price);
                        if (!got.Contains(pd.spec))
                        {

                            pd.spec.getValueByName("Bộ nhớ trong");
                            pd.spec.GotPriceMin = this.getMinValue(pd.spec.id);
                            Console.WriteLine("Capa" + pd.spec.GotValue);
                            specs.Add(pd.spec);

                        }
                        got.Add(pd.spec);
                        listProductDetail.Add(pd);
                    }

                    //lay spec cua capacity nho nhat
                    spec spec = listProductDetail[0].spec;
                    for (int i = 1; i < listProductDetail.Count; i++)
                    {
                        if (int.Parse(spec.GotValue) > int.Parse(listProductDetail[i].spec.GotValue))
                        {
                            spec = listProductDetail[i].spec;
                        }
                    }

                    // lay tat ca product detail theo cai spec do
                    List<productdetail> productdetailsBySpec = new List<productdetail>();
                    foreach (productdetail pd in listProductDetail)
                    {
                        if (pd.spec.id == spec.id)
                        {
                            productdetailsBySpec.Add(pd);
                        }
                    }

                    // ban đầu khi hiển thị trang detail, sẽ chọn Product detail có capacity nhỏ nhất đầu tiên(phải còn hàng)
                    int firstPDId = 0;
                    foreach (productdetail pd in productdetailsBySpec)
                    {
                        if (checkProductInStorage(pd.id) > 0)
                        {
                            firstPDId = pd.id;
                            break;
                        }
                    }



                    ViewBag.firstPDId = firstPDId;
                    ViewBag.firstSpecId = spec.id;
                    List<spec> listSpec = specs.ToList();
                    listSpec.Sort();
                    ViewBag.specs = listSpec;
                    ViewBag.productdetails = productdetails.ToList();
                    ViewBag.product = product;
                    ViewBag.Comment = productDAO.comments();


                    System.Diagnostics.Debug.WriteLine("ccc");
                    foreach (voucher v in listVoucher)
                    {
                        System.Diagnostics.Debug.WriteLine("kkk" + v.name);
                    }
                    return PartialView("~/Views/ProductDetail/ProductDetail.cshtml");

                }
                else
                {

                    int firstPDId = 0;
                    int status = 0;
                    foreach (productdetail pd in productdetails)
                    {
                        if (checkProductInStorage(pd.id) > 0)
                        {
                            status = 1;
                            pd.status = status;
                            firstPDId = pd.id;
                            break;
                        }
                    }
                    ViewBag.productdetails = productdetails.ToList();
                    ViewBag.product = product;
                    ViewBag.firstPDId = firstPDId;

                    return PartialView("~/Views/ProductDetail/AccessoryDetail.cshtml");
                }



            }




            return PartialView("~/Views/ProductDetail/AccessoryDetail.cshtml");
        }
    }
}