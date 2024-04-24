using System.Collections.Generic;

namespace Bid501_Client
{
    public class IDB : DTO<IDB>
    {
        public static string Type = "IDB";
        public List<Product> Products { get; set; }
    }
}