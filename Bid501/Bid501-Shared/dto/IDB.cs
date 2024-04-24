using System.Collections.Generic;

namespace Bid501_Shared
{
    public class IDB : DTO<IDB>
    {
        public const string Type = "IDB";
        public List<Product> Products { get; set; }
    }
}