using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationDatabaseProject.Controllers
{
    public class HomeController : Controller
    {
        Thesis_SystemsEntities ls = new Thesis_SystemsEntities();
        
        public ActionResult Author()
        {
            var a = ls.author.ToList();
            return View(a);
        }

        public ActionResult Theses()
        {
            var Theses = ls.thesis.ToList();
            return View(Theses);
        }
        public ActionResult Institute()
        {
            var Institute = ls.institute.ToList();
            return View(Institute);
        }
        public ActionResult University()
        {
            var University = ls.university.ToList();
            return View(University);
        }
        public ActionResult Topic()
        {
            var Topic = ls.topics.ToList();
            return View(Topic);
        }
        public ActionResult Language()
        {
            var Language = ls.language.ToList();
            return View(Language);
        }
        public ActionResult Supervisor()
        {
            var Supervisior= ls.supervisors.ToList();
            return View(Supervisior);
        }

        public ActionResult Keyword()
        {
            var Keyword = ls.keyword.ToList();
            return View(Keyword);
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
    }
}