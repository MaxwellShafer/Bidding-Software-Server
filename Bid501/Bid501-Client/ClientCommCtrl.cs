using System;
using System.Collections.Generic;
using WebSocketSharp;
using System.Text.Json;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    public delegate void CheckLoginDEL(LoginDTO model);

    public delegate void NewBidDEL(decimal price, string id);

    public class ClientCommCtrl : WebSocketBehavior
    {
        private WebSocket ws;

        // Event for when a message is received from the server

        public ClientCommCtrl(LoginForm v)
        {
            // Connects to the server
            //view = v;
            ws = new WebSocket("ws://192.168.0.108:8002/server");
            //ws.OnMessage += (sender, e) => { if (MessageReceived != null) MessageReceived(e.Data); };
            ws.OnMessage += OnMessage;
            ws.Connect();
        }

        [Obsolete("Use SendLoginInfo instead of Login.")]
        public void Login(String username, String password)
        {
            string tosend = username + password;
            ws.Send(tosend);
        }

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