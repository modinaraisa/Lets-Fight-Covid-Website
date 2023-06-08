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
    public class CustomerReviewsController : Controller
    {
        private LetsFightCovidEntities2 db = new LetsFightCovidEntities2();

        // GET: CustomerReviews
        public ActionResult Index()
        {
            return View(db.CustomerReviews.ToList());
        }

        // GET: CustomerReviews/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerReview customerReview = db.CustomerReviews.Find(id);
            if (customerReview == null)
            {
                return HttpNotFound();
            }
            return View(customerReview);
        }

        // GET: CustomerReviews/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerReviews/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "customer_ID,customer_name,customer_address,customer_email,customer_review")] CustomerReview customerReview)
        {
            if (ModelState.IsValid)
            {
                db.CustomerReviews.Add(customerReview);
                db.SaveChanges();
                return RedirectToAction("Create");
            }
            ViewBag.Notification = "Successfully Entered";

            return View(customerReview);
        }

        // GET: CustomerReviews/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerReview customerReview = db.CustomerReviews.Find(id);
            if (customerReview == null)
            {
                return HttpNotFound();
            }
            return View(customerReview);
        }

        // POST: CustomerReviews/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "customer_ID,customer_name,customer_address,customer_email,customer_review")] CustomerReview customerReview)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerReview).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerReview);
        }

        // GET: CustomerReviews/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerReview customerReview = db.CustomerReviews.Find(id);
            if (customerReview == null)
            {
                return HttpNotFound();
            }
            return View(customerReview);
        }

        // POST: CustomerReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerReview customerReview = db.CustomerReviews.Find(id);
            db.CustomerReviews.Remove(customerReview);
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
