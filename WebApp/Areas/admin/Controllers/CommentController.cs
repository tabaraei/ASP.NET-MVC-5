using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Areas.admin.Controllers
{
    [RouteArea("admin", AreaPrefix = "")]
    [RoutePrefix("admin")]
    [Route("Comment/{action}/{id?}")]
    [Authorize]
    public class CommentController : Controller
    {
        DatabaseRepository<Comment> commentTable = new DatabaseRepository<Comment>(new DB());

        #region Comment Details
        [Route("~/admin/{Type:regex(Comment):maxlength(7)}/{id?}")]
        public ActionResult CommentDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["CommentID"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Comment record, string st, string oldUrl)
        {
            // status
            record.status = (st == "on") ? true : false;

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
                    commentTable.Create(record);
                    commentTable.Save();
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
                        if(record.imageUrl != "" && oldUrl != "")
                        {
                            System.IO.File.Delete(Server.MapPath(oldUrl));
                        }

                        // save new image
                        image.SaveAs(Server.MapPath(url));
                        record.imageUrl = url;

                        // submit
                        commentTable.Update(record);
                        commentTable.Save();
                    }
                }
                else
                {
                    // old image
                    record.imageUrl = oldUrl;
                    commentTable.Update(record);
                    commentTable.Save();
                }
            }

            return Redirect("/admin/Comment");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete image
            System.IO.File.Delete(Server.MapPath(commentTable.Read(id).imageUrl));
            // delete table
            commentTable.Delete(id);
            commentTable.Save();

            return Redirect("/admin/Comment");
        }
        #endregion
    }
}