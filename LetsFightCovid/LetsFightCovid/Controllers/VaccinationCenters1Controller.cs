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
    public class VaccinationCenters1Controller : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: VaccinationCenters1
        public ActionResult IndexVac1()
        {
            return View(db.VaccinationCenters.ToList());
        }

        // GET: VaccinationCenters1/Details/5
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
