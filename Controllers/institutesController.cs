using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplicationDatabaseProject;

namespace WebApplicationDatabaseProject.Controllers
{
    public class institutesController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: institutes
      

        public ActionResult Index(string searchString)
        {
            var institutes = from i in db.institute.Include(i => i.university)
                             select i;

            if (!String.IsNullOrEmpty(searchString))
            {
                institutes = institutes.Where(i => i.institute_name.Contains(searchString) ||
                                                   i.university.university_name.Contains(searchString));
            }

            return View(institutes.ToList());
        }


        // GET: institutes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institute institute = db.institute.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // GET: institutes/Create
        public ActionResult Create()
        {
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name");
            return View();
        }

        // POST: institutes/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "institute_id,institute_name,university_id")] institute institute)
        {
            if (ModelState.IsValid)
            {
                db.institute.Add(institute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", institute.university_id);
            return View(institute);
        }

        // GET: institutes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institute institute = db.institute.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", institute.university_id);
            return View(institute);
        }

        // POST: institutes/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "institute_id,institute_name,university_id")] institute institute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(institute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", institute.university_id);
            return View(institute);
        }

        // GET: institutes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            institute institute = db.institute.Find(id);
            if (institute == null)
            {
                return HttpNotFound();
            }
            return View(institute);
        }

        // POST: institutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            institute institute = db.institute.Find(id);
            db.institute.Remove(institute);
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
