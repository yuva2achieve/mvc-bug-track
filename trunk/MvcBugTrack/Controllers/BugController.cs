using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBugTrack.Models;

namespace MvcBugTrack.Controllers
{
    public class BugController : Controller
    {
        private BugTrackContext _db = new BugTrackContext();

        // Index action
        public ActionResult Index()
        {
            var model = _db.Bugs.ToList();
            return View(model);
        }

        

        // Create actions
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Bug newBug)
        {
            try
            {
                _db.Bugs.Add(newBug);
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
            return View(_db.Bugs.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Bug bug)
        {
            try
            {
                _db.Entry(bug).State = System.Data.EntityState.Modified;
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
            return View(_db.Bugs.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Bug bug)
        {
            try
            {
                _db.Entry(bug).State = System.Data.EntityState.Deleted;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                // TODO Add error display logic here eventually.
                return View();
            }
        }



        // Details actions
        public ActionResult Details(int id)
        {
            return View(_db.Bugs.Find(id));
        }
    }
}
