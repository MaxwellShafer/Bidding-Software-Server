
using System;
using System.Collections.Generic;
using WebSocketSharp;
using System.Text.Json;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public delegate void LoginReturnDEL(string IDB);
    public delegate bool NewBidDEL(decimal price, string id);

    public class ClientCommCtrl : WebSocketBehavior
    {
        private WebSocket ws;
        public LoginReturnDEL loginReturn;
        
        // Event for when a message is received from the server

        public ClientCommCtrl(LoginReturnDEL lr)
        { // Connects to the server
            loginReturn = lr;
            ws = new WebSocket("ws://192.168.0.108:8002/server");
            //ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.OnMessage += OnMessage;
            ws.Connect();
        }

        /*public void Login(String username, String password)
        {   
            string tosend = username + password;
            ws.Send(tosend);
        }*/

        public void SendLoginInfo(LoginDTO model)
        {
            string body = model.Serialize();
            ws.Send(body);
        }

        public void SendBid(decimal price, string id)
        {
            // Currently manually creating the JSON string, if we create a model for this move that logic over
            var dto = new PlaceBidDTO
            {
                Bid = price,
                Id = id
            };
            ws.Send(dto.Serialize());
        }


        public void OnMessage(object sender, MessageEventArgs e)
        {
            var response = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(e.Data);
            switch (response["Type"])
            {
                
            }
        }
    }
}