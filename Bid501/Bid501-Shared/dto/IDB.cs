using System.Collections.Generic;

namespace Bid501_Shared
{
    public class IDB : DTO<IDB>
    {
        public const string SerializeType = "IDB";
        /// <summary>
        /// The type string for data processing
        /// </summary>
        public string Type => SerializeType;

        public List<Product> Products { get; set; }
    }
}