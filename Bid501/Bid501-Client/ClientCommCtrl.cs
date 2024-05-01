using System.Collections.Generic;
using WebSocketSharp;
using System.Text.Json;
using Bid501_Shared;
using Bid501_Shared.dto;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public delegate void LoginReturnDEL(IDB idb);

    public delegate void BidUpdateDEL(BidResponseDTO bidResponse);

    public delegate void NewProductDEL(Product p);
    
    public delegate void BidExpiredDEL(BidExpiredDTO bidExpiredDTO);

    public class ClientCommCtrl : WebSocketBehavior
    {
        private readonly WebSocket _ws;
        private readonly LoginReturnDEL _loginReturn;
        private BidUpdateDEL _bidUpdated;
        private NewProductDEL _newProductDel;
        private BidExpiredDEL _bidExpired;

        // Event for when a message is received from the server

        public ClientCommCtrl(LoginReturnDEL lr)
        {
            // Connects to the server
            _loginReturn = lr;
            _ws = new WebSocket("ws://192.168.0.108:8002/server");
            _ws.OnMessage += OnMessage;
            _ws.Connect();
        }
        
        public void SetBidUpdated(BidUpdateDEL del)
        {
            _bidUpdated = del;
        }

        public void SetNewProduct(NewProductDEL newProductDel)
        {
            _newProductDel = newProductDel;
        }
        
        public void SetBidExpired(BidExpiredDEL bidExpiredDel)
        {
            _bidExpired = bidExpiredDel;
        }

        public void SendLoginInfo(LoginDTO model)
        {
            string body = model.Serialize();
            _ws.Send(body);
        }

        public void SendBid(string id, decimal price)
        {
            var dto = new PlaceBidDTO
            {
                Bid = price,
                Id = id,
            };
            _ws.Send(dto.Serialize());
        }


        private void OnMessage(object sender, MessageEventArgs e)
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(e.Data);
            switch (response["Type"])
            {
                case IDB.Type:
                    IDB idb = IDB.Deserialize(e.Data);
                    _loginReturn(idb);
                    break;
                case Product.Type:
                    Product p = Product.Deserialize(e.Data);
                    _newProductDel(p);
                    break;
                case BidResponseDTO.Type:
                    BidResponseDTO bidResponse = BidResponseDTO.Deserialize(e.Data);
                    _bidUpdated(bidResponse);
                    break;
                case BidExpiredDTO.Type:
                    BidExpiredDTO bid = BidExpiredDTO.Deserialize(e.Data);
                    _bidExpired(bid);
                    break;
            }
        }
    }
}