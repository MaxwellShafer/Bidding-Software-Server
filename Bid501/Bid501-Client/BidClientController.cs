﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public BidClientController(IDB idb)
        {

        }
    }
}
