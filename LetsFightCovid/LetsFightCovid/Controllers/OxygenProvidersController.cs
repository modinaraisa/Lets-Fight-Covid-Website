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
    public class OxygenProvidersController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: OxygenProviders
        public ActionResult IndexOx()
        {
            return View(db.OxygenProviders.ToList());
        }

        // GET: OxygenProviders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OxygenProvider oxygenProvider = db.OxygenProviders.Find(id);
            if (oxygenProvider == null)
            {
                return HttpNotFound();
            }
            return View(oxygenProvider);
        }

        // GET: OxygenProviders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OxygenProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "provider_ID,provider_address,provider_contact,available_stock,price_per_cylinder")] OxygenProvider oxygenProvider)
        {
            if (ModelState.IsValid)
            {
                db.OxygenProviders.Add(oxygenProvider);
                db.SaveChanges();
                return RedirectToAction("IndexOx");
            }

            return View(oxygenProvider);
        }

        // GET: OxygenProviders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OxygenProvider oxygenProvider = db.OxygenProviders.Find(id);
            if (oxygenProvider == null)
            {
                return HttpNotFound();
            }
            return View(oxygenProvider);
        }

        // POST: OxygenProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "provider_ID,provider_address,provider_contact,available_stock,price_per_cylinder")] OxygenProvider oxygenProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oxygenProvider).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexOx");
            }
            return View(oxygenProvider);
        }

        // GET: OxygenProviders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OxygenProvider oxygenProvider = db.OxygenProviders.Find(id);
            if (oxygenProvider == null)
            {
                return HttpNotFound();
            }
            return View(oxygenProvider);
        }

        // POST: OxygenProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OxygenProvider oxygenProvider = db.OxygenProviders.Find(id);
            db.OxygenProviders.Remove(oxygenProvider);
            db.SaveChanges();
            return RedirectToAction("IndexOx");
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
