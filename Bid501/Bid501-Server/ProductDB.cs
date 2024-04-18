using Bid501_Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    public class ProductDB : IDB
    {
        public List<Product> Products { get; set; }

    }
}
