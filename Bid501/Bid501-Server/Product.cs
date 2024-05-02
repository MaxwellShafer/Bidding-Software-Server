using Bid501_Shared;
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
    public class Product : IProduct
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

        /// <summary>
        /// The current winning user
        /// </summary>
        public string User { get; set; }

        public string NewStrDisplay => $"{Name} - ${String.Format("{0:0.00}", MinBid)}";

        /// <summary>
        /// Creates the Product object
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="minBid"></param>
        /// <param name="bidCount"></param>
        /// <param name="isExpired"></param>
        public Product(string id, string name, decimal minBid, int bidCount, bool isExpired)
        {
            Id = id;
            Name = name;
            MinBid = minBid;
            BidCount = bidCount;
            IsExpired = isExpired;
            User = "";
        }

        /// <summary>
        /// String summary for list viewing
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (BidCount == 1)
                if (IsExpired)
                    return $"Expired: {BidCount} bid on {Name} - ${String.Format("{0:0.00}", MinBid)}";
                else
                    return $"Active: {BidCount} bid on {Name} - ${String.Format("{0:0.00}", MinBid)}";
            else
                if (IsExpired)
                    return $"Expired: {BidCount} bids on {Name} - ${String.Format("{0:0.00}", MinBid)}";
                else
                    return $"Active: {BidCount} bids on {Name} - ${String.Format("{0:0.00}", MinBid)}";
        }
    }
}
