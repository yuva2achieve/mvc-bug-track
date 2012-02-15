using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBugTrack.Models;

namespace MvcBugTrack.Controllers
{
    public class ProjectController : Controller
    {
        private BugTrackContext _db = new BugTrackContext();


        //
        // GET: /Project/

        public ActionResult Index()
        {
            var model = _db.Projects.ToList();
            return View(model);
        }



        // Create actions
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Project newProject)
        {
            try
            {
                _db.Projects.Add(newProject);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add error display logic here eventually.
                return View();
            }
        }



        // Edit actions
        public ActionResult Edit(int id)
        {
            return View(_db.Projects.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Project project)
        {
            try
            {
                _db.Entry(project).State = System.Data.EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add error display logic here eventually.
                return View();
            }
        }



        // Delete actions
        public ActionResult Delete(int id)
        {
            return View(_db.Projects.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Project project)
        {
            try
            {
                _db.Entry(project).State = System.Data.EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add error display logic here eventually.
                return View();
            }
        }

    }
}
