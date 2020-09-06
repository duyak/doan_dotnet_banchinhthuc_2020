using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;


namespace Website_StorePhone3.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();
        // GET: Admin/Category
        public ActionResult Index()
        {
            List<category> categories = db.categories.ToList();
            return View(categories);

        }
        public ActionResult AddCategory()
        {
            // Lấy data
            // Lấy toàn bộ thể loại:
            List<category> cate = db.categories.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "id", "name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory([Bind(Include = "id,activeFlag,createDate,updateDate")] category categorys, int parentId, string name, string code, string description)
        {

            categorys.parentId = parentId;
            categorys.name = name;
            categorys.code = code;
            categorys.description = description;
            categorys.activeFlag = 1;
            categorys.createDate = DateTime.Now;
            categorys.updateDate = DateTime.Now;
            db.categories.Add(categorys);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        // Get :Category/Delete
        public ActionResult Delete(int id)
        {
            try
            {


                category modifyCategory = db.categories.Find(id);
                if (modifyCategory == null)
                {
                    return HttpNotFound();
                }
                modifyCategory.activeFlag = 0;
                db.Entry(modifyCategory).State = EntityState.Modified;
                db.SaveChanges();


            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                /*    throw;*/

            }
            return RedirectToAction("Index");
        }
        // Get :Category/Edit/5
        public ActionResult Edit(int? id)
        {
            // Lấy data
            // Lấy toàn bộ thể loại:
            List<category> cate = db.categories.ToList();

            // Tạo SelectList
            SelectList cateList = new SelectList(cate, "id", "name");
            // Set vào ViewBag
            ViewBag.CategoryList = cateList;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        //POST: Category/Edit/5
        [HttpPost]

        public ActionResult Edit([Bind(Include = "id,activeFlag,createDate,updateDate")] category category, int parentId, string name, string code, string description)
        {

            if (ModelState.IsValid)
            {
                category modifyCategory = db.categories.Find(category.id);
                if (modifyCategory != null)
                {
                    if (parentId != 0)
                    {
                        modifyCategory.parentId = parentId;
                        modifyCategory.name = name;
                        modifyCategory.code = code;
                        modifyCategory.description = description;
                        modifyCategory.updateDate = DateTime.Now;

                    }
                    else
                    {
                        modifyCategory.name = name;
                        modifyCategory.updateDate = DateTime.Now;

                    }
                }
                db.Entry(modifyCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);

        }
    }




}