using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClassLibrary_Byggemarked;
using WebApplication_Byggemarked.PrisBeregner;

namespace WebApplication_Byggemarked.Controllers
{
    public class BookingSetsController : Controller
    {
        private ByggemarkedRigtigEntities db = new ByggemarkedRigtigEntities();

        // GET: BookingSets
        public ActionResult Index(string email)
        {
            ViewBag.Email = email;
            if (email == null)
            {
                return View(db.BookingSet.Include(b => b.KundeSet).Include(b => b.VærktøjskatalogSet));
            } else
            
                return View(db.KundeSet.Find(email).BookingSet.ToList());
        }

        // GET: BookingSets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSet.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // GET: BookingSets/Create
        public ActionResult Create(string email)
        {
            ViewBag.Email = email;
          
            ViewBag.Kunde_Email = new SelectList(db.KundeSet, "Email", "Adresse");
            ViewBag.Værktøjskatalog_Navn = new SelectList(db.VærktøjskatalogSet, "Navn", "Navn");
            return View();
        }

        // POST: BookingSets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartBooking,SlutBooking,Status,Kunde_Email,Værktøjskatalog_Navn")] BookingSet bookingSet)
        {
            if (ModelState.IsValid)
            {
                db.BookingSet.Add(bookingSet);
                Totalpris pris = new Totalpris();
                double Tpris = pris.Udregner(bookingSet);
                bookingSet.TotalPris = Tpris;
                db.SaveChanges();
                return RedirectToAction("Index", new { email = bookingSet.Kunde_Email});
            }

            ViewBag.Kunde_Email = new SelectList(db.KundeSet, "Email", "Adresse", bookingSet.Kunde_Email);
            ViewBag.Værktøjskatalog_Navn = new SelectList(db.VærktøjskatalogSet, "Navn", "Navn", bookingSet.Værktøjskatalog_Navn);
            return View(bookingSet);
        }

        // GET: BookingSets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSet.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kunde_Email = new SelectList(db.KundeSet, "Email", "Adresse", bookingSet.Kunde_Email);
            ViewBag.Værktøjskatalog_Navn = new SelectList(db.VærktøjskatalogSet, "Navn", "Beskrivelse", bookingSet.Værktøjskatalog_Navn);
            return View(bookingSet);
        }

        // POST: BookingSets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartBooking,SlutBooking,Status,Kunde_Email,Værktøjskatalog_Navn")] BookingSet bookingSet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kunde_Email = new SelectList(db.KundeSet, "Email", "Adresse", bookingSet.Kunde_Email);
            ViewBag.Værktøjskatalog_Navn = new SelectList(db.VærktøjskatalogSet, "Navn", "Beskrivelse", bookingSet.Værktøjskatalog_Navn);
            return View(bookingSet);
        }

        // GET: BookingSets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSet bookingSet = db.BookingSet.Find(id);
            if (bookingSet == null)
            {
                return HttpNotFound();
            }
            return View(bookingSet);
        }

        // POST: BookingSets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSet bookingSet = db.BookingSet.Find(id);
            db.BookingSet.Remove(bookingSet);
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
