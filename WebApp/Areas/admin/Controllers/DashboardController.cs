using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.admin.Controllers
{
    [RouteArea("admin", AreaPrefix = "")]
    [RoutePrefix("admin")]
    [Route("Dashboard/{action}")]
    [Authorize]
    public class DashboardController : Controller
    {
        #region Dashboard
        [Route("~/admin/{Type:regex(Dashboard):maxlength(9)?}/{id?}")]
        public ActionResult Dashboard1()
        {
            return View();
        }
        public ActionResult Dashboard2()
        {
            return View();
        }
        public ActionResult Dashboard3()
        {
            return View();
        }
        #endregion

        #region Forms
        public ActionResult GeneralForm()
        {
            return View();
        }
        public ActionResult AdvancedComponents()
        {
            return View();
        }
        public ActionResult FormValidation()
        {
            return View();
        }
        public ActionResult FormWizard()
        {
            return View();
        }
        public ActionResult FormUpload()
        {
            return View();
        }
        public ActionResult FormButtons()
        {
            return View();
        }
        #endregion

        #region UI elements
        public ActionResult GeneralElements()
        {
            return View();
        }
        public ActionResult MediaGallery()
        {
            return View();
        }
        public ActionResult Typography()
        {
            return View();
        }
        public ActionResult Icons()
        {
            return View();
        }
        public ActionResult Glyphicons()
        {
            return View();
        }
        public ActionResult Widgets()
        {
            return View();
        }
        public ActionResult Invoice()
        {
            return View();
        }
        public ActionResult Inbox()
        {
            return View();
        }
        public ActionResult Calendar()
        {
            return View();
        }
        #endregion

        #region Tables
        public ActionResult Tables()
        {
            return View();
        }
        public ActionResult TableDynamic()
        {
            return View();
        }
        #endregion

        #region Data Presentation
        public ActionResult ChartJS()
        {
            return View();
        }
        public ActionResult ChartJS2()
        {
            return View();
        }
        public ActionResult MorisJS()
        {
            return View();
        }
        public ActionResult ECharts()
        {
            return View();
        }
        public ActionResult OtherCharts()
        {
            return View();
        }
        #endregion

        #region Layouts
        public ActionResult FixedSideBar()
        {
            return View();
        }
        public ActionResult FixedFooter()
        {
            return View();
        }
        #endregion

        #region Additional Pages
        public ActionResult Ecommerce()
        {
            return View();
        }
        public ActionResult Projects()
        {
            return View();
        }
        public ActionResult ProjectDetails()
        {
            return View();
        }
        public ActionResult Contacts()
        {
            return View();
        }
        public ActionResult Profiles()
        {
            return View();
        }
        #endregion

        #region Extras
        public ActionResult Error403()
        {
            return View();
        }
        public ActionResult Error404()
        {
            return View();
        }
        public ActionResult Error500()
        {
            return View();
        }
        public ActionResult PlainPage()
        {
            return View();
        }
        public ActionResult LoginPage()
        {
            return View();
        }
        public ActionResult PricingTables()
        {
            return View();
        }
        #endregion
    }
}