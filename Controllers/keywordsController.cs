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
    public class keywordsController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: keywords
        public ActionResult Index(string searchString)
        {
            var keywords = from k in db.keyword
                           select k;

            if (!String.IsNullOrEmpty(searchString))
            {
                keywords = keywords.Where(k => k.keyword_name.Contains(searchString));
            }

            return View(keywords.ToList());
        }


        // GET: keywords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            keyword keyword = db.keyword.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // GET: keywords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: keywords/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "keyword_id,keyword_name")] keyword keyword)
        {
            if (ModelState.IsValid)
            {
                db.keyword.Add(keyword);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(keyword);
        }

        // GET: keywords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            keyword keyword = db.keyword.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // POST: keywords/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "keyword_id,keyword_name")] keyword keyword)
        {
            if (ModelState.IsValid)
            {
                db.Entry(keyword).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(keyword);
        }

        // GET: keywords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            keyword keyword = db.keyword.Find(id);
            if (keyword == null)
            {
                return HttpNotFound();
            }
            return View(keyword);
        }

        // POST: keywords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            keyword keyword = db.keyword.Find(id);
            db.keyword.Remove(keyword);
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
