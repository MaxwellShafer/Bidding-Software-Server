using Bid501_Shared;
using Bid501_Shared.dto;
using Bid501_Shared;
using Bid501_Shared.dto;
using Newtonsoft.Json;
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
                    newBid(bidData.Bid, bidData.Id);
                    break;
                case LoginDTO.Type:
                    var loginData = LoginDTO.Deserialize(e.Data);
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

        //Takes from admin controller
        /// <summary>
        /// 
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
            foreach(string id in Sessions.IDs)
            {
                if(id != clientId)
                {
                    Sessions.SendTo(serialized, id);
                }
            }
        }
    }
}
