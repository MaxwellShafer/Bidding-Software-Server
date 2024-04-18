
using System;
using System.Diagnostics;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public delegate bool CheckLoginDEL(ClientLoginModel model);
    public delegate bool NewBidDEL(decimal price, string id);

    public class ClientCommCtrl : WebSocketBehavior
    {
        private WebSocket ws;
        
        // Event for when a message is received from the server

        public ClientCommCtrl(LoginForm v)
        { // Connects to the server
            //view = v;
            ws = new WebSocket("ws://192.168.0.108:8002/server");
            //ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.OnMessage += OnMessage;
            ws.Connect();
        }

        public void Login(String username, String password)
        {   
            string tosend = username + password;
            ws.Send(tosend);
        }

        public void SendLoginInfo(ClientLoginModel model)
        {
            string body = model.Serialize();
            ws.Send(body);
        }
        
        

        public void OnMessage(object sender, MessageEventArgs e)
        {
            //view.DisplayState(LoginState.SUCCESS);
        }
    }
}