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
    [Route("Role/{action}/{id?}")]
    [Authorize]
    public class RoleController : Controller
    {
        // GET: admin/Role
        DatabaseRepository<Role> roleTable = new DatabaseRepository<Role>(new DB());

        #region Blog Details
        [Route("~/admin/{Type:regex(Role):maxlength(4)}/{id?}")]
        public ActionResult roleDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["RoleId"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(Role record)

        {
            // status
            // record.status = (st == "on") ? true : false;

            if (record.Id == 0)
            {
                // Create mode

                // submit
                roleTable.Create(record);
                roleTable.Save();
            }


            else
            {
                // Edit mode

                // submit
                roleTable.Update(record);
                roleTable.Save();
            }

            return Redirect("/admin/Role");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete table
            roleTable.Delete(id);
            roleTable.Save();

            return Redirect("/admin/Role");
        }
        #endregion
    }
}