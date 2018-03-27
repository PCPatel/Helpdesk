using Helpdesk.Models;
using Helpdesk.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Helpdesk.Controllers
{
    public class MyAccountController : Controller
    {
        HelpdeskDbContext context;
        public MyAccountController(HelpdeskDbContext _context)
        {
            context = _context;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login, string ReturnUrl = "")
        {
            //if (ModelState.IsValid)
            //{
            //    var user = context.Users.Where(x => x.UserName.Equals(login.Username) && x.Password.Equals(login.Password)).FirstOrDefault();
            //    if (user != null)
            //    {
            //        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        return RedirectToAction("Index", "Home");
            //    }
            //    ModelState.AddModelError("", "Username / Password doesnot match.");
            //}
            ////////////////////////////////
            //if (ModelState.IsValid)
            //{
            //    var isValidUser = Membership.ValidateUser(login.Username, login.Password);
            //    if (isValidUser)
            //    {
            //        FormsAuthentication.SetAuthCookie(login.Username, login.RememberMe);
            //        if (Url.IsLocalUrl(ReturnUrl))
            //        {
            //            return Redirect(ReturnUrl);
            //        }
            //        return RedirectToAction("Index", "Home");
            //    }
            //}
            ////////////////////////////////
            if (ModelState.IsValid)
            {
                bool isValidUser = Membership.ValidateUser(login.Username, login.Password);
                if (isValidUser)
                {
                    User user = null;
                    user = context.Users.Where(a => a.UserName.Equals(login.Username)).FirstOrDefault();

                    if (user != null)
                    {
                        JavaScriptSerializer js = new JavaScriptSerializer();
                        string data = js.Serialize(user);
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), login.RememberMe, data);
                        string encToken = FormsAuthentication.Encrypt(ticket);
                        HttpCookie authoCookies = new HttpCookie(FormsAuthentication.FormsCookieName, encToken);
                        Response.Cookies.Add(authoCookies);
                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.Remove("Password");

            return View();
        }

        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "MyAccount");
        }
    }
}