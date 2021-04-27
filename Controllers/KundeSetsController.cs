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
    public class KundeSetsController : Controller
    {
        private ByggemarkedRigtigEntities db = new ByggemarkedRigtigEntities();

        // GET: KundeSets
        public ActionResult Index()
        {
            return View(db.KundeSet.ToList());
        }

        // GET: KundeSets/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundeSet kundeSet = db.KundeSet.Find(id);
            if (kundeSet == null)
            {
                return HttpNotFound();
            }
            return View(kundeSet);
        }

        // GET: KundeSets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KundeSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Adresse,Navn,Password")] KundeSet kundeSet)
        {
            if (ModelState.IsValid)
            {
                db.KundeSet.Add(kundeSet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kundeSet);
        }

        // GET: KundeSets/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundeSet kundeSet = db.KundeSet.Find(id);
            if (kundeSet == null)
            {
                return HttpNotFound();
            }
            return View(kundeSet);
        }

        // POST: KundeSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Adresse,Navn,Password")] KundeSet kundeSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kundeSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kundeSet);
        }

        // GET: KundeSets/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KundeSet kundeSet = db.KundeSet.Find(id);
            if (kundeSet == null)
            {
                return HttpNotFound();
            }
            return View(kundeSet);
        }

        // POST: KundeSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KundeSet kundeSet = db.KundeSet.Find(id);
            db.KundeSet.Remove(kundeSet);
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
