using Bid501_Shared;
using Bid501_Shared.dto;
using Bid501_Shared;
using Bid501_Shared.dto;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;


namespace Bid501_Server
{ 
    /// <summary>
    /// Handles the communication incoming from websocket
    /// </summary>
    public class ServerCommCtrl : WebSocketBehavior
    {
        public LoginAttemptDEL loginAttempt { get; set; }

        public NewBidDEL newBid { get; set; }

        public GetIDFromUsername GetId;

        /// <summary>
        /// ServerCommCtrl constructor
        /// </summary>
        public ServerCommCtrl(LoginAttemptDEL loginAttempt, NewBidDEL newBid)
        {
            this.loginAttempt = loginAttempt;
            this.newBid = newBid;
        }

        /// <summary>
        /// Receive message event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(e.Data);
            switch(response["Type"])
            {
                case PlaceBidDTO.Type:
                    var bidData = PlaceBidDTO.Deserialize(e.Data);
                    newBid(bidData.Bid, bidData.Id, ID);
                    break;
                case LoginDTO.Type:
                    var loginData = LoginDTO.Deserialize(e.Data);
                    loginAttempt(loginData.Username, loginData.Password, ID);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles when a bid expires
        /// </summary>
        /// <param name="p"></param>
        public void HandleExpiringBid(IProduct p)
        {
            string clientId = GetId(((Product)p).User);
            BidExpiredDTO dto = new BidExpiredDTO();
            dto.Id = p.Id;
            dto.IsWinning = true;
            dto.Bid = p.MinBid;
            Sessions.SendTo(dto.Serialize(), clientId);

            dto.IsWinning = false;
            string serialized = dto.Serialize();
            foreach (string id in Sessions.IDs)
            {
                if (id != clientId)
                {
                    Sessions.SendTo(serialized, id);
                }
            }
            
        }

        /// <summary>
        /// Handles the bid getting updated
        /// </summary>
        /// <param name="bid"></param>
        /// <param name="productID"></param>
        /// <param name="clientID"></param>
        public void HandleBidUpdated(decimal bid, string productID, string clientID)
        {
            BidResponseDTO dto = new BidResponseDTO();
            dto.Bid = bid;
            dto.Id = productID;
            dto.IsWinning = true;
            Sessions.SendTo(dto.Serialize(), clientID);

            dto.IsWinning = false;
            string serialized = dto.Serialize();
            foreach(string id in Sessions.IDs)
            {
                if(id != clientID)
                {
                    Sessions.SendTo(serialized, id);
                }
            }
        }

        /// <summary>
        /// Handles the case when the login attempt is processed
        /// </summary>
        /// <param name="isGood"></param>
        public void HandleLoginAttempt(bool isGood, string clientID, List<IProduct> db)
        {
            if(isGood)
            {
                IDB dto = new IDB();
                List<Bid501_Shared.Product> products = new List<Bid501_Shared.Product>();
                foreach(Product p in db)
                {
                    products.Add(new Bid501_Shared.Product
                        { Id = p.Id, BidCount = p.BidCount, IsExpired = p.IsExpired, MinBid = p.MinBid, Name = p.Name}
                    );
                }
                dto.Products = products;
                Sessions.SendTo(dto.Serialize(), clientID);
            } else
            {
                Sessions.SendTo("Unauthorized", clientID);
            }
        }

        /// <summary>
        /// Sends a new product to all connected clients
        /// </summary>
        /// <param name="product"></param>
        public void SendProduct(IProduct product)
        {
            Bid501_Shared.Product dto = (Bid501_Shared.Product)product;
            Sessions.Broadcast(dto.Serialize());
        }
    }
}
