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
        public IDB database;

        //public 

        public BidClientController(IDB idb)
        {
            database = idb;
        }



    }
}
