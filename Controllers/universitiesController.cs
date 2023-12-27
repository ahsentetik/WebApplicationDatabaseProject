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
    public class universitiesController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: universities

        public ActionResult Index(string searchString)
        {
            var universities = from u in db.university
                               select u;

            if (!String.IsNullOrEmpty(searchString))
            {
                universities = universities.Where(u => u.university_name.Contains(searchString));
            }

            return View(universities.ToList());
        }

   

        // GET: universities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // GET: universities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: universities/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "university_id,university_name")] university university)
        {
            if (ModelState.IsValid)
            {
                // Check if the university_id already exists
                if (db.university.Any(u => u.university_id == university.university_id))
                {
                    ModelState.AddModelError("university_id", "University ID already exists.");
                    return View(university);
                }

                db.university.Add(university);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(university);
        }

       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "university_id,university_name")] university university)
        {
            if (ModelState.IsValid)
            {
                db.university.Add(university);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(university);
        }
       */
        // GET: universities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: universities/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "university_id,university_name")] university university)
        {
            if (ModelState.IsValid)
            {
                db.Entry(university).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(university);
        }

        // GET: universities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            university university = db.university.Find(id);
            if (university == null)
            {
                return HttpNotFound();
            }
            return View(university);
        }

        // POST: universities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            university university = db.university.Find(id);
            db.university.Remove(university);
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
