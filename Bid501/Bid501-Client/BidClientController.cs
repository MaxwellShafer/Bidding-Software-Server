using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bid501_Shared;

namespace Bid501_Client
{
    public enum BidState
    {
        WAIT,
        NEWPRODUCT,
        PRICEUPDATED,
        GOODBID,
        BADBID,
        WIN,
        LOSE,
        EXIT
    }


    public class BidClientController
    {
        private ProductDBProxy productDB;
        private ProductProxy selectedProxy;

        public BidClientController(ProductDBProxy db, ProductProxy selectedProxy)
        {
            this.productDB = db;
            this.selectedProxy = selectedProxy;
        }
    }
}