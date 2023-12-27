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
    public class thesesController : Controller
    {
        private Thesis_SystemsEntities db = new Thesis_SystemsEntities();

        // GET: theses
    


        public ActionResult Index(string searchString)
        {
            var theses = from t in db.thesis.Include(t => t.author)
                                            .Include(t => t.institute)
                                            .Include(t => t.language)
                                            .Include(t => t.supervisors)
                                            .Include(t => t.topics)
                                            .Include(t => t.university)
                         select t;

            if (!String.IsNullOrEmpty(searchString))
            {
                theses = theses.Where(t => t.title.Contains(searchString) ||
                                           t.@abstract.Contains(searchString) ||
                                   t.type.Contains(searchString) ||
                                   t.author.author_name.Contains(searchString) ||
                                   t.institute.institute_name.Contains(searchString) ||
                                   t.language.language1.Contains(searchString) ||
                                   t.supervisors.supervisor_name.Contains(searchString) ||
                                   t.topics.topic_name.Contains(searchString) ||
                                   t.university.university_name.Contains(searchString));
    }

    return View(theses.ToList());
}
       

// GET: theses/Details/5
public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thesis thesis = db.thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        // GET: theses/Create
        public ActionResult Create()
        {
            ViewBag.author_id = new SelectList(db.author, "author_id", "author_name");
            ViewBag.institute_id = new SelectList(db.institute, "institute_id", "institute_name");
            ViewBag.language_id = new SelectList(db.language, "language_id", "language1");
            ViewBag.supervisor_id = new SelectList(db.supervisors, "supervisor_id", "supervisor_name");
            ViewBag.topic_id = new SelectList(db.topics, "topic_id", "topic_name");
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name");
            return View();
        }

        // POST: theses/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "thesis_id,title,abstract,author_id,university_id,institute_id,topic_id,type,year,pages,language_id,submission_date,supervisor_id")] thesis thesis)
        {
            if (ModelState.IsValid)
            {
                db.thesis.Add(thesis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.author_id = new SelectList(db.author, "author_id", "author_name", thesis.author_id);
            ViewBag.institute_id = new SelectList(db.institute, "institute_id", "institute_name", thesis.institute_id);
            ViewBag.language_id = new SelectList(db.language, "language_id", "language1", thesis.language_id);
            ViewBag.supervisor_id = new SelectList(db.supervisors, "supervisor_id", "supervisor_name", thesis.supervisor_id);
            ViewBag.topic_id = new SelectList(db.topics, "topic_id", "topic_name", thesis.topic_id);
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", thesis.university_id);
            return View(thesis);
        }

        // GET: theses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thesis thesis = db.thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            ViewBag.author_id = new SelectList(db.author, "author_id", "author_name", thesis.author_id);
            ViewBag.institute_id = new SelectList(db.institute, "institute_id", "institute_name", thesis.institute_id);
            ViewBag.language_id = new SelectList(db.language, "language_id", "language1", thesis.language_id);
            ViewBag.supervisor_id = new SelectList(db.supervisors, "supervisor_id", "supervisor_name", thesis.supervisor_id);
            ViewBag.topic_id = new SelectList(db.topics, "topic_id", "topic_name", thesis.topic_id);
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", thesis.university_id);
            return View(thesis);
        }
        

        // POST: theses/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "thesis_id,title,abstract,author_id,university_id,institute_id,topic_id,type,year,pages,language_id,submission_date,supervisor_id")] thesis thesis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thesis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.author_id = new SelectList(db.author, "author_id", "author_name", thesis.author_id);
            ViewBag.institute_id = new SelectList(db.institute, "institute_id", "institute_name", thesis.institute_id);
            ViewBag.language_id = new SelectList(db.language, "language_id", "language1", thesis.language_id);
            ViewBag.supervisor_id = new SelectList(db.supervisors, "supervisor_id", "supervisor_name", thesis.supervisor_id);
            ViewBag.topic_id = new SelectList(db.topics, "topic_id", "topic_name", thesis.topic_id);
            ViewBag.university_id = new SelectList(db.university, "university_id", "university_name", thesis.university_id);
            return View(thesis);
        }

        // GET: theses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            thesis thesis = db.thesis.Find(id);
            if (thesis == null)
            {
                return HttpNotFound();
            }
            return View(thesis);
        }

        // POST: theses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            thesis thesis = db.thesis.Find(id);
            db.thesis.Remove(thesis);
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
