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
    public class UserIcusController : Controller
    {
        private LetsFightCovidEntities db = new LetsFightCovidEntities();

        // GET: UserIcus
        public ActionResult IndexIcu1()
        {
            return View(db.Icus.ToList());
        }

        // GET: UserIcus/Details/5
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
