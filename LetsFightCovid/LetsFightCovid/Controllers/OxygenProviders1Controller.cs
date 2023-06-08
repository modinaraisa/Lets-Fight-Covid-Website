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
    public class OxygenProviders1Controller : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: OxygenProviders1
        public ActionResult IndexOx1()
        {
            return View(db.OxygenProviders.ToList());
        }

        // GET: OxygenProviders1/Details/5
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
