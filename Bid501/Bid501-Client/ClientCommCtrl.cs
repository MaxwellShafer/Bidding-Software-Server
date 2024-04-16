
using System;
using System.Runtime.InteropServices;
using WebSocketSharp;

namespace Bid501_Client
{
    public delegate bool Message(string message);

    public class ClientCommCtrl
    {
        private WebSocket ws;
        
        // Event for when a message is received from the server
        public event Message MessageReceived;

        public ClientCommCtrl()
        { // Connects to the server
            ws = new WebSocket("ws://127.0.0.1:8001/server");
            ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.Connect();
        }

        public bool Login(String username, String password)
        {
            return true;
        }
    }
}