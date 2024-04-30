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

    public delegate void UpdateBidState(BidState state);


    public class BidClientController
    {
        private ProductDBProxy productDB;
        private ProductProxy selectedProxy;
        public UpdateBidState updateBidStateDEL;

        
        public void fetchNewProduct(ProductProxy product)
        {

        }
        


        public void handleNewProduct(ProductProxy p)
        {
            selectedProxy = p;
            updateBidStateDEL(BidState.NEWPRODUCT);

        }
        public BidClientController(ProductDBProxy db, ProductProxy selectedProxy, UpdateBidState updateDEL)
        {
            this.productDB = db;
            this.selectedProxy = selectedProxy;
            updateBidStateDEL = updateDEL;

        }
    }
}