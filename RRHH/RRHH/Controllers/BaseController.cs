using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RRHH.Controllers
{
    public class BaseController : Controller
    {
        // this exist because we need load cross controllers information on left or top menu
        public virtual ActionResult LeftNavBar()
        {
            return PartialView("_LeftNavBar");
        }

        public virtual ActionResult TopNavBar()
        {
            return PartialView("_TopNavBar");
        }
    }
}