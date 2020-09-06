using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        // GET: Admin/Product
        public ActionResult Index()
        {
            List<product> products = db.products.ToList();

            ViewBag.products = products;
            return View();
        }
        public ActionResult Add()
        {
            // Lấy data category
            // Lấy toàn bộ thể loại:
            List<category> cate = db.categories.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "id", "name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;

            // Lấy data brand
            // Lấy toàn bộ thể loại
            List<brand> brand = db.brands.ToList();

            //Tạo SelectList
            SelectList brandList = new SelectList(brand, "id", "name");

            //Set vào ViewBag
            ViewBag.BrandList = brandList;


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Add([Bind(Include = "id,activeFlag,createDate,updateDate")] product product2, int catagoryId, int brandId, string name, HttpPostedFileBase imgMain, string code, string description)
        {
            string fileName = System.IO.Path.GetFileName(imgMain.FileName);
          




            string urlImage = Server.MapPath("~/Content/client/img/product/" + fileName);
            imgMain.SaveAs(urlImage);
            product2.imgMain = fileName;


            product2.brandId = brandId;
            product2.categoryId = catagoryId;
            product2.name = name;
            product2.code = code;
            product2.description = description;
            product2.activeFlag = 1;
            product2.createDate = DateTime.Now;
            product2.updateDate = DateTime.Now;
            db.products.Add(product2);
            db.SaveChanges();
            return RedirectToAction("Index");
            /*            try
                        {
                            string fileName = System.IO.Path.GetFileName(imgMain.FileName);
                            string urlImage = Se00rver.MapPath("~/Image/product/" + fileName);
                            imgMain.SaveAs(urlImage);
                            product.brandId = brandId;
                            product.catagoryId = catagoryId;
                            product.code = code;
                            product.description = description;
                            product.activeFlag = 1;
                            product.createDate = DateTime.Now;
                            product.updateDate = DateTime.Now;
                            db.products.Add(product);
                            db.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        catch (DbEntityValidationException dbEx)
                        {
                            foreach (var validationErrors in dbEx.EntityValidationErrors)
                            {
                                foreach (var validationError in validationErrors.ValidationErrors)
                                {
                                    System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                                }
                            }
                        }
                        return RedirectToAction("Add");
            */
        }
        //GET: Product/Edit/5
        public ActionResult Edit(int? id)
        {
            // Lấy data category
            // Lấy toàn bộ thể loại:
            List<category> cate = db.categories.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "id", "name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;

            // Lấy data brand
            // Lấy toàn bộ thể loại
            List<brand> brand = db.brands.ToList();

            //Tạo SelectList
            SelectList brandList = new SelectList(brand, "id", "name");

            //Set vào ViewBag
            ViewBag.BrandList = brandList;
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            }

            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,activeLag,createDate,updateDate")] product product2, int catagoryId, int brandId, string name, HttpPostedFileBase imgMain, string code, string description)
        {
            if (ModelState.IsValid)
            {
                product modifyproduct = db.products.Find(product2.id);
                if (modifyproduct != null)
                {
                    if (imgMain != null && imgMain.ContentLength > 0)
                    {
                        string fileName = System.IO.Path.GetFileName(imgMain.FileName);
                        string urlImage = Server.MapPath("~/Image/product/" + fileName);
                        imgMain.SaveAs(urlImage);
                        modifyproduct.imgMain = "Image/product/" + fileName;
                        modifyproduct.brandId = brandId;
                        modifyproduct.categoryId = catagoryId;
                        modifyproduct.name = name;
                        modifyproduct.code = code;
                        modifyproduct.description = description;
                        modifyproduct.updateDate = DateTime.Now;

                    }
                    if (name != null)
                    {
                        modifyproduct.name = name;
                        modifyproduct.updateDate = DateTime.Now;

                    }
                    if (catagoryId != 0)
                    {
                        modifyproduct.categoryId = catagoryId;
                        modifyproduct.updateDate = DateTime.Now;

                    }
                    if (brandId != 0 && catagoryId != 0)
                    {
                        modifyproduct.brandId = brandId;
                        modifyproduct.categoryId = catagoryId;
                        modifyproduct.updateDate = DateTime.Now;

                    }


                }
                db.Entry(modifyproduct).State = System.Data.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product2);

        }
        // GET :Product/Delete
        public ActionResult Delete(int id)
        {
            product modifyProduct = db.products.Find(id);
            if (modifyProduct == null)
            {
                return HttpNotFound();
            }
            modifyProduct.activeFlag = 0;
            db.Entry(modifyProduct).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}