using Bid501_Shared;
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
            var response = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(e.Data);
            switch(response["Type"])
            {
                case PlaceBidDTO.Type:
                    var bidData = PlaceBidDTO.Deserialize(e.Data);

                    break;
                case LoginDTO.Type:
                    var loginData = LoginDTO.Deserialize(e.Data);
                    break;
                default:
                    break;
            }
        }
    }
}
