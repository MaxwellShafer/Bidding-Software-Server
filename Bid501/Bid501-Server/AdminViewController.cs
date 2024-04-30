using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// A class to control the admin view
    /// </summary>
    internal class AdminViewController
    {
        /// <summary>
        /// a private field to hold the database
        /// </summary>
        private ProductDB productDB;

        /// <summary>
        /// a delegate to hold the send product method
        /// </summary>
        public SendProductDEL sendProductDEL { get; set; }

        /// <summary>
        /// a delegate to hold the update state method
        /// </summary>
        public UpdateStateDEL updateStateDEL { get; set; }
        
        /// <summary>
        /// a method to handle when a product is added
        /// </summary>
        /// <param name="product">the product handled</param>
        public void handleAddProduct(IProduct product)
        {

        }
    }
}
