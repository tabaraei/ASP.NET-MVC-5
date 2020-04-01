using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [Route("About")]
        public ActionResult About()
        {
            return View();
        }

        [Route("Agent")]
        public ActionResult Agent()
        {
            return View();
        }

        [Route("Service")]
        public ActionResult Service()
        {
            return View();
        }

        [Route("Property")]
        public ActionResult Property()
        {
            return View();
        }

        [Route("Blog/{id?}")]
        public ActionResult Blog(int? id)
        {
            ViewData["pageIndex"] = (id == null) ? 1 : id.Value;
            return View();
        }

        [Route("BlogDetails/{id}")]
        public ActionResult BlogDetails(int id)
        {
            ViewData["SelectedBlog"] = id;
            return View();
        }

        [Route("Gallery/{id?}")]
        public ActionResult Gallery(int? id)
        {
            ViewData["GalleryIndex"] = (id == null) ? 1 : id.Value;
            return View();
        }

        [HttpGet]
        [Route("Contact")]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [Route("Contact")]
        public ActionResult Contact(string subject, string email, string message)
        {
            // read admin email
            DatabaseRepository<User> userTable = new DatabaseRepository<User>(new DB());
            string adminEmail = userTable.Read(1).email, adminPassword = "Gixub7787";
            
            // Mail theme
            StreamReader emailTemplate = new StreamReader(Server.MapPath("~/Views/EmailTemplate.html"));
            string mailtheme = emailTemplate.ReadToEnd();
            mailtheme = mailtheme.Replace("@from", email).Replace("@subject", subject).Replace("@body", message);


            #region Send Email
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(adminEmail, adminPassword);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email);
            mail.To.Add(adminEmail);
            mail.IsBodyHtml = true;
            mail.Body = mailtheme;
            mail.BodyEncoding = Encoding.UTF8;
            mail.Subject = "Author: " + subject;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Priority = MailPriority.High;

            // smtp.UseDefaultCredentials = true;
            //try
            //{
            smtp.Send(mail);
            // ViewBag.msg = "OK";
            //}
            //catch
            //{
            //    ViewBag.msg = "NOK!";
            //}

            #endregion
            return View();
        }
    }
}