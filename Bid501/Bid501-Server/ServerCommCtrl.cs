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
            MessageBox.Show(e.Data);
            Send($"The following message was receieved: {e.Data}");
            Sessions.Broadcast($"Session call: {e.Data}");
        }
    }
}
