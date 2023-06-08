using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LetsFightCovid.Models;

namespace LetsFightCovid.Controllers
{
    public class IcusController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: Icus
        public ActionResult IndexIcu()
        {
            return View(db.Icus.ToList());
        }

        // GET: Icus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icu icu = db.Icus.Find(id);
            if (icu == null)
            {
                return HttpNotFound();
            }
            return View(icu);
        }

        // GET: Icus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Icus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "icu_ID,icu_availability,cost_per_day,hospital_ID")] Icu icu)
        {
            if (ModelState.IsValid)
            {
                db.Icus.Add(icu);
                db.SaveChanges();
                return RedirectToAction("IndexIcu");
            }

            return View(icu);
        }

        // GET: Icus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icu icu = db.Icus.Find(id);
            if (icu == null)
            {
                return HttpNotFound();
            }
            return View(icu);
        }

        // POST: Icus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "icu_ID,icu_availability,cost_per_day,hospital_ID")] Icu icu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexIcu");
            }
            return View(icu);
        }

        // GET: Icus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Icu icu = db.Icus.Find(id);
            if (icu == null)
            {
                return HttpNotFound();
            }
            return View(icu);
        }

        // POST: Icus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Icu icu = db.Icus.Find(id);
            db.Icus.Remove(icu);
            db.SaveChanges();
            return RedirectToAction("IndexIcu");
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
