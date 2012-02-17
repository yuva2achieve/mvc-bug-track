using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcBugTrack.Models;

namespace MvcBugTrack.Controllers
{
    public class CategoryController : Controller
    {
        private BugTrackContext _db = new BugTrackContext();


        //
        // GET: /Status/

        public ActionResult Index()
        {
            var model = _db.Categories.ToList();
            return View(model);
        }



        // Create actions
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category newCategory)
        {
            try
            {
                _db.Categories.Add(newCategory);
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
            return View(_db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                _db.Entry(category).State = System.Data.EntityState.Modified;
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
            return View(_db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                _db.Entry(category).State = System.Data.EntityState.Deleted;
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
