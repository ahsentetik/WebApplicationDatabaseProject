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
    public class languagesController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: languages
        public ActionResult Index(string searchString)
        {
            var languages = from l in db.language
                            select l;

            if (!String.IsNullOrEmpty(searchString))
            {
                languages = languages.Where(l => l.language1.Contains(searchString));
            }

            return View(languages.ToList());
        }


        // GET: languages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            language language = db.language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // GET: languages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: languages/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "language_id,language1")] language language)
        {
            if (ModelState.IsValid)
            {
                db.language.Add(language);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(language);
        }

        // GET: languages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            language language = db.language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: languages/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "language_id,language1")] language language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        // GET: languages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            language language = db.language.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            language language = db.language.Find(id);
            db.language.Remove(language);
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
