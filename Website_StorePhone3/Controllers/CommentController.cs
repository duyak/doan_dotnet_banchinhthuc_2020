using System;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;

namespace Website_StorePhone3.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int productId, String fullname,String email,String content)
        {
            if (ModelState.IsValid)
            {
                comment comment = new comment();
                comment.activeFlag = 1;
                comment.createDate = DateTime.Now;
                comment.updateDate = DateTime.Now;
                comment.productId = productId;
                comment.fullname = fullname;
                comment.email = email;
                comment.content = content;
                using (dotnetstorephoneEntities1 dt = new dotnetstorephoneEntities1())
                {
                    dt.comments.Add(comment);
                    dt.SaveChanges();
                    System.Diagnostics.Debug.WriteLine("gggg" + comment.content + comment.productId);
                }
            }
           
            return Redirect("/chitiet/ProductDetail/" + productId);
        }
    }
}