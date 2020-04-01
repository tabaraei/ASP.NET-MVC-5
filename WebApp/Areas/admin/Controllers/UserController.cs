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
    [Route("User/{action}/{id?}")]
    [Authorize]
    public class UserController : Controller
    {
        DatabaseRepository<User> userTable = new DatabaseRepository<User>(new DB());

        #region User Details
        [Route("~/admin/{Type:regex(User):maxlength(4)}/{id?}")]
        public ActionResult UserDetails()
        {
            return View();
        }
        #endregion

        #region Create / Edit
        [HttpGet]
        public ActionResult CreateRecord(int? id)
        {
            ViewData["UserId"] = (id == null) ? id : id.Value;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRecord(User record)

        {
            // status
            // record.status = (st == "on") ? true : false;

            if (record.Id == 0)
            {
                // Create mode

                // submit
                userTable.Create(record);
                userTable.Save();
            }


            else
            {
                // Edit mode

                // submit
                userTable.Update(record);
                userTable.Save();
            }

            return Redirect("/admin/User");
        }
        #endregion

        #region Delete
        public ActionResult DeleteRecord(int id)
        {
            // delete table
            userTable.Delete(id);
            userTable.Save();

            return Redirect("/admin/User");
        }
        #endregion
    }
}