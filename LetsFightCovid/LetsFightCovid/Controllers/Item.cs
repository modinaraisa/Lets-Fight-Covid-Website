using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LetsFightCovid.Models;
namespace LetsFightCovid.Controllers
{
    public class Item
    {
        private Product product = new Product(); // Instantiate tblProduct class object 

        #region Properties
        public Product Product
        {
            get { return product; }
            set { product = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        #endregion

        #region Constructors
        // Default constructor
        public Item()
        {

        }

        // Parameterised constructor
        public Item(Product product, int quantity)
        {
            this.product = product;
            this.quantity = quantity;
        }
        #endregion
    }
}