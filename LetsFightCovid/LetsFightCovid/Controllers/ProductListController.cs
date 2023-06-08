using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using LetsFightCovid.Models;

namespace LetsFightCovid.Controllers
{
    public class ProductListController : Controller
    {

        private LetsFightCovidEntities1 db = new LetsFightCovidEntities1();
        // GET: ProductList
        public ActionResult IndexProductList(int? page)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            var onePageOfProducts = db.Products.OrderBy(x => x.pid).ToPagedList(pageNumber, 15); // will only contain 5 products max because of the pageSize

            ViewBag.ListProducts = onePageOfProducts; // Store pages in ViewBag to access them on the view

            return View();
        }


        

    }
}