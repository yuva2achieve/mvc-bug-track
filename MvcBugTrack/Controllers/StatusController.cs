using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBugTrack.Models;

namespace MvcBugTrack.Controllers
{
    public class StatusController : Controller
    {
        private BugTrackContext _db = new BugTrackContext();


        //
        // GET: /Status/

        public ActionResult Index()
        {
            var model = _db.Statuses.ToList();
            return View(model);
        }



        // Create actions
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Status newStatus)
        {
            try
            {
                _db.Statuses.Add(newStatus);
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
            return View(_db.Statuses.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Status status)
        {
            try
            {
                _db.Entry(status).State = System.Data.EntityState.Modified;
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
            return View(_db.Statuses.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Status status)
        {
            try
            {
                _db.Entry(status).State = System.Data.EntityState.Deleted;
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
