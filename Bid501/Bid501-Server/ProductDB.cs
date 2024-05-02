using Bid501_Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Server
{
    public class ProductDB
    {
        /// <summary>
        /// The database of products
        /// </summary>
        public List<IProduct> Products { get; set; }

        /// <summary>
        /// Creates the product database
        /// </summary>
        public ProductDB() 
        {
            Products = new List<IProduct>();
            Products.Add(new Product("unga bunga", "bana", 1.0m, 10, false));
            //Load these from an external file
        }
    }
}
