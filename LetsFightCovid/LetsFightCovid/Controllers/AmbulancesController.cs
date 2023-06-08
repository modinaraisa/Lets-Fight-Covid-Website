﻿using System;
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
    public class AmbulancesController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: Ambulances
        public ActionResult IndexAmb()
        {
            return View(db.Ambulances.ToList());
        }

        // GET: Ambulances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulance ambulance = db.Ambulances.Find(id);
            if (ambulance == null)
            {
                return HttpNotFound();
            }
            return View(ambulance);
        }

        // GET: Ambulances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ambulances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ambulance_ID,ambulance_availability,ambulance_contact,ambulance_rent,hospital_ID")] Ambulance ambulance)
        {
            if (ModelState.IsValid)
            {
                db.Ambulances.Add(ambulance);
                db.SaveChanges();
                return RedirectToAction("IndexAmb");
            }

            return View(ambulance);
        }

        // GET: Ambulances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulance ambulance = db.Ambulances.Find(id);
            if (ambulance == null)
            {
                return HttpNotFound();
            }
            return View(ambulance);
        }

        // POST: Ambulances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ambulance_ID,ambulance_availability,ambulance_contact,ambulance_rent,hospital_ID")] Ambulance ambulance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ambulance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexAmb");
            }
            return View(ambulance);
        }

        // GET: Ambulances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ambulance ambulance = db.Ambulances.Find(id);
            if (ambulance == null)
            {
                return HttpNotFound();
            }
            return View(ambulance);
        }

        // POST: Ambulances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ambulance ambulance = db.Ambulances.Find(id);
            db.Ambulances.Remove(ambulance);
            db.SaveChanges();
            return RedirectToAction("IndexAmb");
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
