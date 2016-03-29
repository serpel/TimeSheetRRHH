using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RRHH.BLL;
using RRHH.Models;

namespace RRHH.Controllers
{
    public class ProcessController : BaseController
    {
        private TimeSheetContext db = new TimeSheetContext();
        // GET: Process
        public ActionResult Index()
        {
            ViewBag.company = new SelectList(db.Companies, "CompanyId", "Name");
            return View();
        }

        public JsonResult Run(string company, string date)
        {
            bool success = false;
            string message = "";

            try
            {
                DailyProcess process = new DailyProcess();
                process.GenerateEmployeeTimeSheetByDay(DateTime.Parse(date));
                success = true;
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            return Json(new { success = success, message = message });
        }
    }
}