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

        public void BidUpdated(decimal price, string id, bool winning)
        {
            productDB.handleProductUpdated(price, id, winning);
            // todo refresh display
        }
        
        public void NewProduct(Product product)
        {
            productDB.handleNewProduct(product);
            // todo refresh display
        }
        
        public BidClientController(ProductDBProxy db)
        {
            this.productDB = db;
        }
        
    }
}