using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RRHH.Models;

namespace RRHH.Controllers
{
    public class EmployeesController : BaseController
    {
        private TimeSheetContext db = new TimeSheetContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.City).Include(e => e.Country).Include(e => e.Department).Include(e => e.Job).Include(e => e.Shift);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name");
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobTitle");
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeCode,NationalCardId,FirstName,LastName,Address,Bithdate,Gender,PhoneNumber,ProfileUrl,HireDate,DepartmentId,ShiftId,JobId,CountryId,CityId,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobTitle", employee.JobId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobTitle", employee.JobId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeCode,NationalCardId,FirstName,LastName,Address,Bithdate,Gender,PhoneNumber,ProfileUrl,HireDate,DepartmentId,ShiftId,JobId,CountryId,CityId,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(db.Cities, "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobId = new SelectList(db.Jobs, "JobId", "JobTitle", employee.JobId);
            ViewBag.ShiftId = new SelectList(db.Shifts, "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
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
