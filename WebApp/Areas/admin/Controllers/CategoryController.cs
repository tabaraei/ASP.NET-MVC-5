using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Areas.admin.Controllers
{
    [RouteArea("admin", AreaPrefix = "")]
    [RoutePrefix("admin")]
    [Route("Category/{action}/{id?}")]
    [Authorize]
    public class CategoryController : Controller
    {
        DatabaseRepository<Category> categoryTable = new DatabaseRepository<Category>(new DB());

        #region Category Details
        [Route("~/admin/{Type:regex(Category):maxlength(8)}/{id?}")]
        public ActionResult CategoryDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["CategoryId"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Category record)

        {
            // status
            // record.status = (st == "on") ? true : false;

            if (record.Id == 0)
            {
                // Create mode

                // submit
                categoryTable.Create(record);
                categoryTable.Save();
            }

        
            else
            {
                // Edit mode

                // submit
                categoryTable.Update(record);
                categoryTable.Save();
            }

            return Redirect("/admin/Category");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete table
            categoryTable.Delete(id);
            categoryTable.Save();

            return Redirect("/admin/Category");
        }
        #endregion
    }
}
