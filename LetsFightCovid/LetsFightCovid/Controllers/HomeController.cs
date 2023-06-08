using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsFightCovid.Models;

namespace LetsFightCovid.Controllers
{
    public class HomeController : Controller
    {
        LetsFightCovidEntities db = new LetsFightCovidEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(User user)
        {
            if (db.Users.Any(x => x.userName == user.userName))
            {
                ViewBag.Notification = "This UserName already Exists";
                return View();
            }
            else {
                db.Users.Add(user);
                db.SaveChanges();

                Session["ID"] = user.users_ID.ToString();
                Session["Full Name"] = user.full_name.ToString();
                Session["Age"] = user.age.ToString();
                Session["Contact No"] = user.contact.ToString();
                Session["Email"] = user.email.ToString();
                Session["Address"] = user.full_address.ToString();
                Session["Username"] = user.userName.ToString();
                return RedirectToAction("Index", "Home");
                
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login","Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var checklogin = db.Users.Where(x => x.userName.Equals(user.userName) && x.passwords.Equals(user.passwords)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["ID"] = user.users_ID.ToString();
                Session["Username"] = user.userName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else {
                ViewBag.Notification = "Invalid Username or password!";

            }
            return View();
        }

        [HttpGet]
        public ActionResult adminLogin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult adminLogin(AdminMember adminmember)
        {
            var checklogin = db.AdminMembers.Where(x => x.admin_userName.Equals(adminmember.admin_userName) && x.passwords.Equals(adminmember.passwords)).FirstOrDefault();
            if (checklogin != null)
            {
                Session["ID"] = adminmember.admin_ID.ToString();
                Session["adminUsername"] = adminmember.admin_userName.ToString();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Notification = "Invalid Credentials For admin Login!";

            }
            return View();
        }
    }
}