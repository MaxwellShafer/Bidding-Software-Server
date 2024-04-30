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
        CHANGEPRODUCT,
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
        public UpdateBidState updatebidState;

        public void BidUpdated(decimal price, string id, bool winning)
        {
            productDB.handleProductUpdated(price, id, winning);
            updatebidState(BidState.PRICEUPDATED);
        }
        
        public void NewProduct(Product product)
        {
            productDB.handleNewProduct(product);
            updatebidState(BidState.NEWPRODUCT);

            
        }
        
        public BidClientController(ProductDBProxy db)
        {
            this.productDB = db;
        }

        public void SetProxy(UpdateBidState del)
        {
            updatebidState = del;
        }
        
    }
}