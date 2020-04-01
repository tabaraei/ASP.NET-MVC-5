using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [RoutePrefix("Account")]
    [Route("{action}")]
    public class AccountController : Controller
    {
        // GET: Account
        DatabaseRepository<User> userTable = new DatabaseRepository<User>(new DB());

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password, string remember)
        {
            // hash
            HashAlgorithm hash = new SHA1CryptoServiceProvider();
            string hashedPassword = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(password)));

            // authenticate
            DB entity = new DB();
            if(entity.Users.Any(item=> item.username == username && item.password == hashedPassword))
            {
                FormsAuthentication.SetAuthCookie(username, (remember == "on" ? true : false));
                return Redirect("/admin");
            }
            else
            {
                ViewData["errorMessage"] = "Invalid Username or Password";
                return View();
            }
        }

        [HttpPost]
        public ActionResult Signin(User record)
        {
            // hash
            HashAlgorithm hash = new SHA1CryptoServiceProvider();
            record.password = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(record.password)));

            // role
            record.roleId = 2;

            userTable.Create(record);
            userTable.Save();
            return Redirect("/");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}