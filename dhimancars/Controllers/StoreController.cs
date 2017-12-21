using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using dhimancars.Models;

namespace dhimancars.Controllers
{
    public class StoreController : Controller
    {
        // db connection moved to Models/EFStore.cs
        //private StoreModel db = new StoreModel();
        private IIStore db;

            public StoreController()
        {
            this.db = new EFStore();
        }

            public StoreController(IIStore db)
        {
            this.db = db;
        }

        // GET: Car
        public ViewResult Index()
        {
            return View(db.Store.ToList());
        }

        // GET: Car/Details/5
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Store store = db.Store.FirstOrDefault(a => a.CarID == id);
            if (store == null)
            {
                return View("Error"); 
            }
            return View(store);
        }

        //// GET: Car/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Car/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CarID,CarModel,CarYear,Price")] Store store)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Stores.Add(store);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(store);
        //}

        //// GET: Car/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Store store = db.Stores.Find(id);
        //    if (store == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(store);
        //}

        //// POST: Car/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "CarID,CarModel,CarYear,Price")] Store store)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(store).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(store);
        //}

        //// GET: Car/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Store store = db.Stores.Find(id);
        //    if (store == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(store);
        //}

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Store store = db.Store.FirstOrDefault(a => a.CarID == id);

            if (store == null)
            {
                return View("Error");
            }
            db.Delete(store);
            return NewMethod();
        }

        private ViewResult NewMethod()
        {
            return View("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
