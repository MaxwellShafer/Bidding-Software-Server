using Bid501_Shared;
using Bid501_Shared.dto;

namespace Bid501_Client
{
    public enum BidState
    {
        Wait,
        NewProduct,
        ChangeProduct,
        PriceUpdated,
        GoodBid,
        BadBid,
        Win,
        Lose,
        Exit
    }

    public delegate void UpdateBidStateDEL(BidState state);

    public delegate void SendBidDEL(string id, decimal price);


    public class BidClientController
    {
        private readonly ProductDbProxy _productDb;
        private UpdateBidStateDEL _updateBidStateDel;
        private SendBidDEL _sendBidDel;


        public void BidUpdated(BidResponseDTO bidResponse)
        {
            _productDb.HandleProductUpdated(bidResponse);
            _updateBidStateDel(BidState.PriceUpdated);
        }

        public void PlaceBid(string id, decimal price)
        {
            if (price <= _productDb.SelectedProduct.MinBid)
            {
                _updateBidStateDel(BidState.BadBid);
            }
            else
            {
                _sendBidDel(id, price);
                _updateBidStateDel(BidState.GoodBid);
            }
        }

        public void NewProduct(Product product)
        {
            _productDb.HandleNewProduct(product);
            _updateBidStateDel(BidState.NewProduct);
        }

        public void BidExpired(BidExpiredDTO bidExpired)
        {
            _productDb.HandleProductExpired(bidExpired);
            _updateBidStateDel(bidExpired.IsWinning ? BidState.Win : BidState.Lose);
        }

        public BidClientController(ProductDbProxy db, SendBidDEL sendBid)
        {
            _productDb = db;
            _sendBidDel = sendBid;
        }

        public void SetProxy(UpdateBidStateDEL del)
        {
            _updateBidStateDel = del;
        }

        public void FetchNewProduct(ProductProxy p)
        {
            _productDb.SelectProduct(p);
        }
    }
}