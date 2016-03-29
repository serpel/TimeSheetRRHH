using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RRHH.Models;

namespace RRHH.Controllers
{
    public class JobPositionsController : Controller
    {
        private TimeSheetContext db = new TimeSheetContext();

        // GET: JobPositions
        public ActionResult Index()
        {
            return View(db.Jobs.ToList());
        }

        // GET: JobPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosition jobPosition = db.Jobs.Find(id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }
            return View(jobPosition);
        }

        // GET: JobPositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobPositionId,JobTitle,IsActive")] JobPosition jobPosition)
        {
            if (ModelState.IsValid)
            {
                db.Jobs.Add(jobPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobPosition);
        }

        // GET: JobPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosition jobPosition = db.Jobs.Find(id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }
            return View(jobPosition);
        }

        // POST: JobPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobPositionId,JobTitle,IsActive")] JobPosition jobPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobPosition);
        }

        // GET: JobPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobPosition jobPosition = db.Jobs.Find(id);
            if (jobPosition == null)
            {
                return HttpNotFound();
            }
            return View(jobPosition);
        }

        // POST: JobPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobPosition jobPosition = db.Jobs.Find(id);
            db.Jobs.Remove(jobPosition);
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
