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
    public class supervisorsController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: supervisors
        public ActionResult Index(string searchString)
        {
            var supervisors = from s in db.supervisors
                              select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                supervisors = supervisors.Where(s => s.supervisor_name.Contains(searchString) ||
                                                     s.supervisor_email.Contains(searchString));
            }

            return View(supervisors.ToList());
        }


        // GET: supervisors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supervisors supervisors = db.supervisors.Find(id);
            if (supervisors == null)
            {
                return HttpNotFound();
            }
            return View(supervisors);
        }

        // GET: supervisors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: supervisors/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "supervisor_id,supervisor_name,supervisor_email")] supervisors supervisors)
        {
            if (ModelState.IsValid)
            {
                db.supervisors.Add(supervisors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supervisors);
        }

        // GET: supervisors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supervisors supervisors = db.supervisors.Find(id);
            if (supervisors == null)
            {
                return HttpNotFound();
            }
            return View(supervisors);
        }

        // POST: supervisors/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "supervisor_id,supervisor_name,supervisor_email")] supervisors supervisors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervisors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supervisors);
        }

        // GET: supervisors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supervisors supervisors = db.supervisors.Find(id);
            if (supervisors == null)
            {
                return HttpNotFound();
            }
            return View(supervisors);
        }

        // POST: supervisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            supervisors supervisors = db.supervisors.Find(id);
            db.supervisors.Remove(supervisors);
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
