using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBugTrack.Models;

namespace MvcBugTrack.Controllers
{
    public class PriorityController : Controller
    {
        private BugTrackContext _db = new BugTrackContext();


        //
        // GET: /Priority/

        public ActionResult Index()
        {
            var model = _db.Priorities.ToList();
            return View(model);
        }



        // Create actions
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Priority newPriority)
        {
            try
            {
                _db.Priorities.Add(newPriority);
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
            return View(_db.Priorities.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Priority priority)
        {
            try
            {
                _db.Entry(priority).State = System.Data.EntityState.Modified;
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
            return View(_db.Priorities.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Priority priority)
        {
            try
            {
                _db.Entry(priority).State = System.Data.EntityState.Deleted;
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
