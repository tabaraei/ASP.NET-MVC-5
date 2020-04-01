using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using System.Globalization;
using WebApp.Services;

namespace WebApp.Areas.admin.Controllers
{
    [RouteArea("admin", AreaPrefix = "")]
    [RoutePrefix("admin")]
    [Route("Blog/{action}/{id?}")]
    [Authorize]
    // exception: [AllowAnonymous]
    public class BlogController : Controller
    {
        //Blog blogTable = new Blog();
        DatabaseRepository<Blog> blogTable = new DatabaseRepository<Blog>(new DB());

        #region Blog Details
        [Route("~/admin/{Type:regex(Blog):maxlength(4)}/{id?}")]
        public ActionResult BlogDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["BlogID"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Blog record, string st, string oldUrl)

        {
            // status
            record.status = (st == "on") ? true : false;

            // blogDate
            PersianCalendar date = new PersianCalendar();
            record.blogDate = date.GetYear(DateTime.Now) + "-" + date.GetMonth(DateTime.Now) + "-" + date.GetDayOfMonth(DateTime.Now);

            // Image
            var image = Request.Files["imageUrl"];
            string url = "~/images/upload/" + DateTime.Now.Millisecond + image.FileName;

            if (record.Id == 0)
            {
                // Create mode
                if (image.ContentLength <= 1000000 && image.ContentType == "image/jpg" || image.ContentType == "image/jpeg" || image.ContentType == "image/png")
                {
                    image.SaveAs(Server.MapPath(url));
                    record.imageUrl = url;

                    // submit
                    blogTable.Create(record);
                    blogTable.Save();
                }

            }
            else
            {
                // Edit mode
                if (image.FileName != "")
                {
                    if (image.ContentLength <= 1000000 && image.ContentType == "image/jpg" || image.ContentType == "image/jpeg" || image.ContentType == "image/png")
                    {
                        // delete old image
                        if(record.imageUrl != "")
                        {
                            System.IO.File.Delete(Server.MapPath(oldUrl));
                        }

                        // save new image
                        image.SaveAs(Server.MapPath(url));
                        record.imageUrl = url;

                        // submit
                        blogTable.Update(record);
                        blogTable.Save();
                    }
                }
                else
                {
                    // old image
                    record.imageUrl = oldUrl;
                    blogTable.Update(record);
                    blogTable.Save();
                }
            }

            return Redirect("/admin/Blog");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete image
            System.IO.File.Delete(Server.MapPath(blogTable.Read(id).imageUrl));
            // delete table
            blogTable.Delete(id);
            blogTable.Save();

            return Redirect("/admin/Blog");
        }
        #endregion
    }
}