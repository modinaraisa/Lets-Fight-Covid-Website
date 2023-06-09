﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LetsFightCovid.Models;

namespace LetsFightCovid.Controllers
{
    public class ShoppingCartController : Controller
    {
        private LetsFightCovidEntities1 de = new LetsFightCovidEntities1();
        // GET: ShoppingCart

        #region Is product in the cart Method
        private int isExisting(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"]; // Put all the items from the "Session["cart"] into the list cart

            for (int i = 0; i < cart.Count; i++)

                if (cart[i].Product.pid == id) // If the cart contains the product those ID is provided 

                    return i; // Then return the number of Products in the cart

            return -1; // Else return -1
        }
        #endregion


        public ActionResult Delete(int id)
        {
            int index = isExisting(id); // index = Product ID from in the Cart only

            List<Item> cart = (List<Item>)Session["cart"];

            cart.RemoveAt(index); // Remove product based on the Product ID provided.


            Session["cart"] = cart; // Update Session["cart"]

            return View("Cart");
        }

        #region Order Now Action
        public ActionResult OrderNow(int id)
        {

            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();

                cart.Add(new Item(de.Products.Find(id), 1)); // Add 1 Product based on id provided

                Session["cart"] = cart; // Update Session["cart"]
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];

                int index = isExisting(id); // index = Product ID from in the Cart only

                if (index == -1) // If the product to be order is not already in the cart

                    cart.Add(new Item(de.Products.Find(id), 1)); // Add 1 Product based on id provided

                else // if product already exists in the cart

                    cart[index].Quantity++; // increase the quantity of the product based on the ID provided

                Session["cart"] = cart; // Update Session["cart"]
            }

            return View("Cart");
        }
        #endregion
    }
}
