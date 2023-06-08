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
    public class PlasmasController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: Plasmas
        public ActionResult IndexPlas()
        {
            return View(db.Plasmas.ToList());
        }

        // GET: Plasmas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plasma plasma = db.Plasmas.Find(id);
            if (plasma == null)
            {
                return HttpNotFound();
            }
            return View(plasma);
        }

        // GET: Plasmas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plasmas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "plasma_ID,donor_name,donor_address,blood_group,donor_contact,plasma_availability")] Plasma plasma)
        {
            if (ModelState.IsValid)
            {
                db.Plasmas.Add(plasma);
                db.SaveChanges();
                return RedirectToAction("IndexPlas");
            }

            return View(plasma);
        }

        // GET: Plasmas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plasma plasma = db.Plasmas.Find(id);
            if (plasma == null)
            {
                return HttpNotFound();
            }
            return View(plasma);
        }

        // POST: Plasmas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "plasma_ID,donor_name,donor_address,blood_group,donor_contact,plasma_availability")] Plasma plasma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plasma).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexPlas");
            }
            return View(plasma);
        }

        // GET: Plasmas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plasma plasma = db.Plasmas.Find(id);
            if (plasma == null)
            {
                return HttpNotFound();
            }
            return View(plasma);
        }

        // POST: Plasmas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plasma plasma = db.Plasmas.Find(id);
            db.Plasmas.Remove(plasma);
            db.SaveChanges();
            return RedirectToAction("IndexPlas");
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
