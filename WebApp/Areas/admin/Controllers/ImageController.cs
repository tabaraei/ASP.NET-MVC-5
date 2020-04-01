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
    [Route("Image/{action}/{id?}")]
    [Authorize]
    public class ImageController : Controller
    {
        // GET: admin/Image
        DatabaseRepository<Image> imageTable = new DatabaseRepository<Image>(new DB());

        #region Image Details
        [Route("~/admin/{Type:regex(Image):maxlength(5)}/{id?}")]
        public ActionResult ImageDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["ImageId"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Image record, string st, string oldUrl)
        {
            // status
            record.status = (st == "on") ? true : false;

            // Image
            var image = Request.Files["imageUrl"];
            string url = "~/images/upload/images" + DateTime.Now.Millisecond + image.FileName;

            if (record.Id == 0)
            {
                // Create mode
                if (image.ContentLength <= 1000000 && image.ContentType == "image/jpg" || image.ContentType == "image/jpeg" || image.ContentType == "image/png")
                {
                    image.SaveAs(Server.MapPath(url));
                    record.imageUrl = url;

                    // submit
                    imageTable.Create(record);
                    imageTable.Save();
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
                        if (record.imageUrl != "")
                        {
                            System.IO.File.Delete(Server.MapPath(oldUrl));
                        }

                        // save new image
                        image.SaveAs(Server.MapPath(url));
                        record.imageUrl = url;

                        // submit
                        imageTable.Update(record);
                        imageTable.Save();
                    }
                }
                else
                {
                    // old image
                    record.imageUrl = oldUrl;
                    imageTable.Update(record);
                    imageTable.Save();
                }
            }

            return Redirect("/admin/Image");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete image
            System.IO.File.Delete(Server.MapPath(imageTable.Read(id).imageUrl));
            // delete table
            imageTable.Delete(id);
            imageTable.Save();

            return Redirect("/admin/Image");
        }
        #endregion
    }
}