using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_StorePhone3.Models.db;
using Website_StorePhone3.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Security;

namespace Website_StorePhone3.Controllers
{
    public class MyUserController : Controller
    {
        // GET: MyUser
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin userLogin, string ReturnUrl="")
        {
            #region encode
            /* string message = "";
             if (ModelState.IsValid)
             {
                 using (phone_storeEntities ps = new phone_storeEntities())
                 {
                     string password = UtilPass.Hash(userLogin.Password);
                     var v = ps.users.Where(a => a.username.Equals(userLogin.Username) && a.password.Equals(password)&& a.activeFlag==1).FirstOrDefault();

                     if (v != null)
                     {
                         FormsAuthentication.SetAuthCookie(v.username, userLogin.RememberMe);
                         if (Url.IsLocalUrl(ReturnUrl))
                         {

                             return Redirect(ReturnUrl);
                         }
                         else
                         {
                             int timeout = userLogin.RememberMe ? 525600 : 20;
                             var ticket = new FormsAuthenticationTicket(userLogin.Username, userLogin.RememberMe, timeout);
                             string encryted = FormsAuthentication.Encrypt(ticket);
                             var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryted);
                             cookie.Expires = DateTime.Now.AddMinutes(timeout);
                             cookie.HttpOnly = true;
                             Response.Cookies.Add(cookie);
                             return RedirectToAction("Index", "Home");
                         }
                     }
                     else
                     {
                         message = "Account does not exist!";
                     }
                 }
             }
             else
             {
                 message = "Please enter username and password!";
             }
             ViewBag.Message = message;*/
            #endregion 
            string message = "";
            //aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa phân quyền
            if (ModelState.IsValid)
            {
                
                string password = UtilPass.Hash(userLogin.Password);
                var isValiUser = Membership.ValidateUser(userLogin.Username, password);
                

                dotnetstorephoneEntities1 p = new dotnetstorephoneEntities1();
                var roles = (from a in p.roles
                         join b in p.roleusers on a.id equals b.roleId
                         join c in p.users on b.userId equals c.id
                         where c.username.Equals(userLogin.Username)
                         select a.roleName).ToArray<string>();

                

                foreach (string i in roles)
                {
                    if (isValiUser)
                    {
                        FormsAuthentication.SetAuthCookie(userLogin.Username, userLogin.RememberMe);
                        
                        if (Url.IsLocalUrl(ReturnUrl))
                        {

                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            if (i.Contains("Admin"))
                            {
                                
                                return RedirectToAction("Index", "Admin/HomeAdmin");
                                
                            }
                            /*if (i.Equals("AdminProduct"))
                            {
                                return RedirectToAction("add_Product", "Admin/HomeAdmin");
                            }*/


                        }
                    }
                    else
                    {
                        message = " Invalid Request! Your account is not activated yet.Please check your Email";
                    }
                }
                if (isValiUser)
                {
                    FormsAuthentication.SetAuthCookie(userLogin.Username, userLogin.RememberMe);
                    if (Url.IsLocalUrl(ReturnUrl))
                    {

                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        
                        return RedirectToAction("Index", "Home");

                    }
                }
                else
                {
                    message = " Invalid Request! Your account is not activated yet.Please check your Email";
                }


            }

            ViewBag.Message = message;
            ModelState.Remove("password");
            return View();

        }
        //logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
          /*  Session.Clear();*/
            return RedirectToAction("Index","Home");
        }
        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Exclude = "activeFlag")]user user)
        {
            bool Status = false;
            String Message = "";
            //model validation
            if (ModelState.IsValid)
            {
                #region //email is already Exits
                var isExist = IsEmailExist(user.email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate activeFlag
                user.activeFlag = 0;

                user.createDate = DateTime.Now;
                user.updateDate = DateTime.Now;
                #endregion

                #region password hashing
                user.password = UtilPass.Hash(user.password);
                #endregion


                #region Save data database
                using (dotnetstorephoneEntities1 phone_Store = new dotnetstorephoneEntities1())
                {
                    phone_Store.users.Add(user);
                    phone_Store.SaveChanges();

                    //Send Email user
                    SendVerificationSendLinkEmail(user.email, user.id);
                    Message = "We have sent you a confirmation link at the email:" + user.email+ ".Please confirm!";
                    Status = true;
                    /*return RedirectToAction("Login", "MyUser");*/
                }
                #endregion

            }
            else
            {
                Message = "Invalid Request";
            }

            ViewBag.Message = Message;
            ViewBag.Status = Status;

            return View(user);
        }
        [HttpGet]
        public ActionResult VeryAccount(int id)
        {
            bool Status = false;
            using (dotnetstorephoneEntities1 phone = new dotnetstorephoneEntities1())
            {
                
                var v = phone.users.Where(a => a.id ==id).FirstOrDefault();
                System.Diagnostics.Debug.WriteLine("gggg"+v);
                if (v != null)
                {
                    v.activeFlag = 1;
                    v.createDate = DateTime.Now;
                    v.updateDate = DateTime.Now;
                    phone.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request!";
                    
                }
                
            }
            
            ViewBag.Status = Status;
            return View();
        }

        public ActionResult ForgotPassWord()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassWord(string email)
        {
            string message = "";
            bool status = false;
            using(dotnetstorephoneEntities1 p = new dotnetstorephoneEntities1())
            {
                var acc = p.users.Where(a => a.email == email).FirstOrDefault();
                if (acc != null)
                {

                }
                else
                {
                    message = "Account not found";
                }
            }
            return View();
        }
        public ActionResult SingleBlog()
        {
            dotnetstorephoneEntities1 phone_Store = new dotnetstorephoneEntities1();

            return View();
        }
        public ActionResult SingleProduct()
        {
            return View();
        }


        [NonAction]
        public bool IsEmailExist(string email)
        {
            using (dotnetstorephoneEntities1 phone_Store = new dotnetstorephoneEntities1())
            {
                var v = phone_Store.users.Where(a => a.email == email).FirstOrDefault();


                return v != null;
            }
        }
        [NonAction]
        public void SendVerificationSendLinkEmail(string email, int id)
        {
            var verifyUrl = "/MyUser/VeryAccount/" + id;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromemail = new MailAddress("hieulinh25102015@gmail.com", "Dương Thùy");//từ email này
            var toEmail = new MailAddress(email);//gửi nội dung đến email này
            var fromEmailPass = "nrcvabpibpjvrdtl";
            string subject = "Your account is successfully create!";
            string body = "<br/><br/> We are excited  to tell you that your dotnet Awesome Account is" +
                "successfully created. Please click on the below link to verify your account" +
                "<br/><br/><a href='" + link + "'>" + link + "</a>";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromemail.Address, fromEmailPass)
            };
            using (var Message = new MailMessage(fromemail, toEmail)
            {
                Subject = subject,
                Body=body,
                IsBodyHtml=true
            })
                smtp.Send(Message);
        }
    }
}