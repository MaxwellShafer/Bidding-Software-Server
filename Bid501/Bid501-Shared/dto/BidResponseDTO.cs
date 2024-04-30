using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Shared.dto
{
    public class BidResponseDTO : DTO<BidResponseDTO>
    {
        /// <summary>
        /// The type string for data processing
        /// </summary>
        public const string Type = "BidResponse";

        /// <summary>
        /// The unique identifier for the product
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The amount that the new object is being bid on
        /// </summary>
        public decimal Bid { get; set; }

        /// <summary>
        /// Defines whether or not the client is winning their bid.
        /// </summary>
        public bool IsWinning { get; set; }
    }
}
