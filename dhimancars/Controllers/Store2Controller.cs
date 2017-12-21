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
    public class Store2Controller : Controller
    {
        private StoreModel db = new StoreModel();

        // GET: Car2
        public ActionResult Index()
        {
            return View(db.Store2.ToList());
        }

        // GET: Car2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store2 store2 = db.Store2.Find(id);
            if (store2 == null)
            {
                return HttpNotFound();
            }
            return View(store2);
        }

        // GET: Car2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,Colour,Wheels,Model")] Store2 store2)
        {
            if (ModelState.IsValid)
            {
                db.Store2.Add(store2);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(store2);
        }

        // GET: Car2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store2 store2 = db.Store2.Find(id);
            if (store2 == null)
            {
                return HttpNotFound();
            }
            return View(store2);
        }

        // POST: Car2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,Colour,Wheels,Model")] Store2 store2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(store2);
        }

        // GET: Car2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Store2 store2 = db.Store2.Find(id);
            if (store2 == null)
            {
                return HttpNotFound();
            }
            return View(store2);
        }

        // POST: Car2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Store2 store2 = db.Store2.Find(id);
            db.Store2.Remove(store2);
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
