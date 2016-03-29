using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RRHH.Models;
using RRHH.DAL;
using PagedList;

namespace RRHH.Controllers
{
    public class EmployeesController : BaseController
    {
        private IGenericRepository<Employee> eRepository;
        private IGenericRepository<City> cRepository;
        private IGenericRepository<Department> dRepository;
        private IGenericRepository<JobPosition> jRepository;
        private IGenericRepository<Shift> sRepository;
        private IGenericRepository<Country> coRepository;

        public EmployeesController()
        {
            TimeSheetContext context = new TimeSheetContext();
            eRepository = new GenericRepository<Employee>(context);
            cRepository = new GenericRepository<City>(context);
            dRepository = new GenericRepository<Department>(context);
            jRepository = new GenericRepository<JobPosition>(context);
            sRepository = new GenericRepository<Shift>(context);
            coRepository = new GenericRepository<Country>(context);
        }

        // GET: Employees
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var employees = eRepository.GetDbSet().Include(e => e.City).Include(e => e.Country).Include(e => e.Department).Include(e => e.JobPosition).Include(e => e.Shift);

            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.FirstName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.EmployeeCode.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    employees = employees.OrderBy(s => s.HireDate);
                    break;
                case "date_desc":
                    employees = employees.OrderByDescending(s => s.HireDate);
                    break;
                default:
                    employees = employees.OrderBy(s => s.FirstName);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(employees.ToPagedList(pageNumber, pageSize));
        }

        //GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = eRepository.SelectById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cRepository.GetAll(), "CityId", "Name");
            ViewBag.CountryId = new SelectList(coRepository.GetAll(), "CountryId", "Name");
            ViewBag.DepartmentId = new SelectList(dRepository.GetAll(), "DepartmentId", "Name");
            ViewBag.JobPositionId = new SelectList(jRepository.GetAll(), "JobId", "JobTitle");
            ViewBag.ShiftId = new SelectList(sRepository.GetAll(), "ShiftId", "Name");
            return View();
        }

        //POST: Employees/Create
        //To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeCode,NationalCardId,FirstName,LastName,Address,Bithdate,Gender,PhoneNumber,ProfileUrl,HireDate,DepartmentId,ShiftId,JobPositionId,CountryId,CityId,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                eRepository.Insert(employee);
                eRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(cRepository.GetAll(), "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(coRepository.GetAll(), "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(dRepository.GetAll(), "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobPositionId = new SelectList(jRepository.GetAll(), "JobPositionId", "JobTitle", employee.JobPositionId);
            ViewBag.ShiftId = new SelectList(sRepository.GetAll(), "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        //GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = eRepository.SelectById(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cRepository.GetAll(), "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(coRepository.GetAll(), "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(dRepository.GetAll(), "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobPositionId = new SelectList(jRepository.GetAll(), "JobPositionId", "JobTitle", employee.JobPositionId);
            ViewBag.ShiftId = new SelectList(sRepository.GetAll(), "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        //POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeCode,NationalCardId,FirstName,LastName,Address,Bithdate,Gender,PhoneNumber,ProfileUrl,HireDate,DepartmentId,ShiftId,JobPositionId,CountryId,CityId,IsActive")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                eRepository.Update(employee);
                eRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cRepository.GetAll(), "CityId", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(coRepository.GetAll(), "CountryId", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(dRepository.GetAll(), "DepartmentId", "Name", employee.DepartmentId);
            ViewBag.JobPositionId = new SelectList(jRepository.GetAll(), "JobPositionId", "JobTitle", employee.JobPositionId);
            ViewBag.ShiftId = new SelectList(sRepository.GetAll(), "ShiftId", "Name", employee.ShiftId);
            return View(employee);
        }

        //GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = eRepository.SelectById(id);
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
            eRepository.Delete(id);
            eRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
