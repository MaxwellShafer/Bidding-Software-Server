using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductDB
    {
        /// <summary>
        /// The database of products
        /// </summary>
        public List<Product> Products { get; set; }

        /// <summary>
        /// Creates the product database
        /// </summary>
        public ProductDB() 
        {
            Products = new List<Product>();
            Products.Add(new Product("unga bunga", "bana", 1.0m, 10, false));
        }
    }
}
