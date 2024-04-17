
using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public delegate bool Message(string message);

    public class ClientCommCtrl : WebSocketBehavior
    {
        private WebSocket ws;
        LoginForm view;

        // Event for when a message is received from the server
        public event Message MessageReceived;

        public ClientCommCtrl(LoginForm v)
        { // Connects to the server
            view = v;
            ws = new WebSocket("ws://127.0.0.1:8001/server");
            //ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.OnMessage += OnMessage;
            ws.Connect();
        }

        public void Login(String username, String password)
        {
            string tosend = username + password;
            ws.Send(tosend);
        }

        public void OnMessage(object sender, MessageEventArgs e)
        {
            view.DisplayState(Bid501_Client.State.SUCCESS);
        }
    }
}