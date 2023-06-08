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
    public class Plasmas1Controller : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: Plasmas1
        public ActionResult IndexPlas1()
        {
            return View(db.Plasmas.ToList());
        }

        // GET: Plasmas1/Details/5
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
