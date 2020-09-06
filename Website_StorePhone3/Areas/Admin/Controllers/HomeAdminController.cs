using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Website_StorePhone3.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: Admin/HomeAdmin
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }
      /*  [Authorize(Roles = "AdminAddProduct")]

        public ActionResult add_Product()
        {
            return View();
        }
        public ActionResult add_supplier()
        {
            return View();
        }
        [Authorize(Roles = "AdminAddUser")]
        public ActionResult add_user()
        {
            return View();
        }
        public ActionResult edit_supplier()
        {
            return View();
        }
        public ActionResult info_order()
        {
            return View();
        }
        [Authorize(Roles = "AdminManagerColorProduct")]
        public ActionResult manager_color()
        {
            return View();
        }
        public ActionResult manager_order()
        {
            return View();
        }
        [Authorize(Roles = "AdminManagerUser")]
        public ActionResult manager_user()
        {
            return View();
        }
        [Authorize(Roles = "AdminProfileProduct")]
        public ActionResult profile_product()
        {
            return View();
        }
        public ActionResult profile_supplier()
        {
            return View();
        }
        [Authorize(Roles = "AdminProfileUser")]
        public ActionResult profile_users()
        {
            return View();
        }*/

        //logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            /*  Session.Clear();*/

            return Redirect("/Home/Index");
        }
    }
}