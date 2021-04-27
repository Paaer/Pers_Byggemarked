using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary_Byggemarked;

namespace WebApplication_Byggemarked.Controllers
{
    public class VærktøjskatalogSetController : Controller
    {
        private ByggemarkedRigtigEntities db = new ByggemarkedRigtigEntities();

        // GET: VærktøjskatalogSet
        public ActionResult Index()
        {
            return View(db.VærktøjskatalogSet.ToList());
        }

        // GET: VærktøjskatalogSet/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VærktøjskatalogSet værktøjskatalogSet = db.VærktøjskatalogSet.Find(id);
            if (værktøjskatalogSet == null)
            {
                return HttpNotFound();
            }
            return View(værktøjskatalogSet);
        }

        // GET: VærktøjskatalogSet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VærktøjskatalogSet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Navn,Beskrivelse,Depositum,Døgnpris")] VærktøjskatalogSet værktøjskatalogSet)
        {
            if (ModelState.IsValid)
            {
                db.VærktøjskatalogSet.Add(værktøjskatalogSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(værktøjskatalogSet);
        }

        // GET: VærktøjskatalogSet/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VærktøjskatalogSet værktøjskatalogSet = db.VærktøjskatalogSet.Find(id);
            if (værktøjskatalogSet == null)
            {
                return HttpNotFound();
            }
            return View(værktøjskatalogSet);
        }

        // POST: VærktøjskatalogSet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Navn,Beskrivelse,Depositum,Døgnpris")] VærktøjskatalogSet værktøjskatalogSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(værktøjskatalogSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(værktøjskatalogSet);
        }

        // GET: VærktøjskatalogSet/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VærktøjskatalogSet værktøjskatalogSet = db.VærktøjskatalogSet.Find(id);
            if (værktøjskatalogSet == null)
            {
                return HttpNotFound();
            }
            return View(værktøjskatalogSet);
        }

        // POST: VærktøjskatalogSet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VærktøjskatalogSet værktøjskatalogSet = db.VærktøjskatalogSet.Find(id);
            db.VærktøjskatalogSet.Remove(værktøjskatalogSet);
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
