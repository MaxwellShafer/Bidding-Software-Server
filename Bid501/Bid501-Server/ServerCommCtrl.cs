using Bid501_Shared;
using Bid501_Shared.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
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
        public GetIDFromUsername GetId;

        /// <summary>
        /// ServerCommCtrl constructor
        /// </summary>
        public ServerCommCtrl()
        {

        }

        /// <summary>
        /// Receive message event handler
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMessage(MessageEventArgs e)
        {
            
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
