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
    public class VaccinationCentersController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: VaccinationCenters
        public ActionResult IndexVac()
        {
            return View(db.VaccinationCenters.ToList());
        }

        // GET: VaccinationCenters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VaccinationCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "center_ID,hospital_name,center_location,available_vaccine")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.VaccinationCenters.Add(vaccinationCenter);
                db.SaveChanges();
                return RedirectToAction("IndexVac");
            }

            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "center_ID,hospital_name,center_location,available_vaccine")] VaccinationCenter vaccinationCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vaccinationCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexVac");
            }
            return View(vaccinationCenter);
        }

        // GET: VaccinationCenters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            if (vaccinationCenter == null)
            {
                return HttpNotFound();
            }
            return View(vaccinationCenter);
        }

        // POST: VaccinationCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VaccinationCenter vaccinationCenter = db.VaccinationCenters.Find(id);
            db.VaccinationCenters.Remove(vaccinationCenter);
            db.SaveChanges();
            return RedirectToAction("IndexVac");
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
