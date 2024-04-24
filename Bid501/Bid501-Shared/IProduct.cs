using Json.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared
{
    /// <summary>
    /// IProduct interface
    /// </summary>
    public interface IProduct
    {
        /// <summary>
        /// The name of the product
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The minimum bid of the product
        /// </summary>
        decimal MinBid { get; set; }

        /// <summary>
        /// The unique identified of the product
        /// </summary>
        string Id { get; set; }

        /// <summary>
        /// The number of times the product has been bid on
        /// </summary>
        int BidCount { get; set; }

        /// <summary>
        /// Whether or not the bid window has expired
        /// </summary>
        bool IsExpired { get; set; }
    }
}
