﻿using Bid501_Shared;
using Bid501_Shared.dto;
using Bid501_Shared;
using Bid501_Shared.dto;
//using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public LoginAttemptDEL LoginAttemptDel { get; set; }

        public NewBidDEL NewBid { get; set; }

        public GetIDFromUsername GetId;

        /// <summary>
        /// ServerCommCtrl constructor
        /// </summary>
        public ServerCommCtrl(LoginAttemptDEL loginAttempt, NewBidDEL newBid, GetIDFromUsername getId)
        {
            this.LoginAttemptDel = loginAttempt;
            this.NewBid = newBid;
            this.GetId = getId;
        }

        /// <summary>
        /// Receive message event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(e.Data);
            var type = response["Type"].ToString();
            switch(type)
            {
                case PlaceBidDTO.SerializeType:
                    var bidData = PlaceBidDTO.Deserialize(e.Data);
                    NewBid(bidData.Bid, bidData.Id, ID);
                    break;
                case LoginDTO.SerializeType:
                    var loginData = LoginDTO.Deserialize(e.Data);
                    LoginAttemptDel(loginData.Username, loginData.Password, ID);
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
            string clientId = ((Product)p).User;
            BidExpiredDTO dto = new BidExpiredDTO();
            dto.Id = p.Id;
            dto.IsWinning = true;
            dto.Bid = p.MinBid;
            Console.WriteLine("Sessions: " + Sessions.Sessions);
            if (clientId != null)
            {
                Sessions.SendTo(dto.Serialize(), clientId);
            }
            dto.IsWinning = false;
            string serialized = dto.Serialize();
            if(Sessions != null)
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
            BidResponseDTO dto = new BidResponseDTO
            {
                Bid = bid,
                Id = productID,
                IsWinning = true
            };
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
                List<Bid501_Shared.ProductDTO> products = new List<Bid501_Shared.ProductDTO>();
                foreach(Product p in db)
                {
                    products.Add(new Bid501_Shared.ProductDTO
                        { Id = p.Id, BidCount = p.BidCount, IsExpired = p.IsExpired, MinBid = p.MinBid, Name = p.Name}
                    );
                }
                dto.Products = products;
                var serialized = dto.Serialize();
                Sessions.SendTo(serialized, clientID);
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
            Bid501_Shared.ProductDTO dto = new Bid501_Shared.ProductDTO { Id = product.Id, BidCount = product.BidCount, IsExpired = product.IsExpired, MinBid = product.MinBid, Name = product.Name };
            if(Sessions != null)
                Sessions.Broadcast(dto.Serialize());
        }

        /// <summary>
        /// a methid to return the client id list
        /// </summary>
        /// <returns>the client id list, empyt list if null</returns>
        public List<string> GetClientIds()
        {
            try
            {
                return (List<string>)Sessions.IDs;
                
            }
            catch
            {
                return new List<string>();
            }
            
        }
    }
}
