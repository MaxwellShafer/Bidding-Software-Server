using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// The model class, build to hold the information of one bidding item
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Eye-Dentifyer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the listed product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The minimum bid for the product
        /// </summary>
        public decimal MinBid { get; set; }

        /// <summary>
        /// The number of bids made
        /// </summary>
        public int BidCount { get; set; }

        /// <summary>
        /// A property to indicate if the product has expired
        /// </summary>
        public bool IsExpired { get; set; }

    }
}
