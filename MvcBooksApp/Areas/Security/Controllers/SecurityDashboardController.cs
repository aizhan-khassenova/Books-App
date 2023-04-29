using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBooksApp.Areas.Security.Controllers
{
    [RouteArea("Security")]
    public class SecurityDashboardController : Controller
    {
        // GET: Security/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}