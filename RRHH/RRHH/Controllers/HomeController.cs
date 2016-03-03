using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RRHH.Models;
using RRHH.DAL;
using RRHH.BLL;

namespace RRHH.Controllers
{
    public class HomeController : BaseController
    {
        private TimeSheetContext db = new TimeSheetContext();

        //public JsonResult GetEmployees()
        //{
        //    var employees = from e in db.Employees.ToList()
        //                    select new { Id = e.EmployeeId, e.EmployeeCode, Department = e.DepartmentId, FirstName = e.FirstName, LastName = e.LastName, ShiftId = e.ShiftId };

        //    return Json(employees, JsonRequestBehavior.AllowGet);
        //}

        [HttpGet]
        public JsonResult GetEmployees(int? page, int? limit,
            string sortBy, string direction, string searchString = null)
        {
            int total;
            var records = from e in db.Employees.ToList()
                            select new { Id = e.EmployeeId, e.EmployeeCode, Department = e.DepartmentId, FirstName = e.FirstName, LastName = e.LastName, ShiftId = e.ShiftId };

            total = records.Count();
            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {

            DateTime date = new DateTime(2016, 02, 23);
            DailyProcess process = new DailyProcess();
            process.GenerateEmployeeTimeSheetByDate(date);

            //timesheetRepository.InsertRange(timesheets);
            //timesheetRepository.Save();

            int a = 1;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}