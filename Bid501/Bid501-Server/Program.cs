﻿using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;
using Newtonsoft.Json;
using System.IO;

namespace Bid501_Server
{
    /// <summary>
    /// Delegate for when the bid is being updated
    /// </summary>
    /// <param name="bid">The amount being bid</param>
    /// <param name="id">The id of the bid being updated</param>
    public delegate void BidUpdateDEL(decimal bid, string productID, string clientID);

    /// <summary>
    /// Delegate for when a new bid arrives to the server.
    /// </summary>
    /// <param name="bid">The amount being bid</param>
    /// <param name="id">The id of the product</param>
    public delegate void NewBidDEL(decimal bid, string id, string clientID);

    /// <summary>
    /// Delegate for when the login is returned to the client
    /// </summary>
    /// <param name="status">Whether or not the client successfully logged in</param>
    public delegate void LoginReturnDEL(bool status, string clientID, List<IProduct> products);

    /// <summary>
    /// Delegate for receiving a login attempt from the client
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    public delegate void LoginAttemptDEL(string user, string password, string clientID);

    /// <summary>
    /// Sends a product to the clients
    /// </summary>
    /// <param name="product">The product being sent</param>
    public delegate void SendProductDEL(IProduct product);

    /// <summary>
    /// Updates the state of the admin view
    /// </summary>
    /// <param name="state">The AdminState</param>
    public delegate void UpdateStateDEL(AdminState state, ProductDB productDB, string client);

    /// <summary>
    /// Add a product to the database
    /// </summary>
    /// <param name="product">The product to be added</param>
    public delegate void AddProductDEL(IProduct product);

    /// <summary>
    /// Delegate for when the login display needs to be updated
    /// </summary>
    /// <param name="state">The current state of the login system</param>
    public delegate void FetchStateDEL(LoginState state);

    /// <summary>
    /// Handles the admin login attempt
    /// </summary>
    /// <param name="un">The username</param>
    /// <param name="pw">The password</param>
    public delegate void LoginClickDEL(string un, string pw);

    /// <summary>
    /// Handles the expiring of a bid from the admin view system
    /// </summary>
    /// <param name="product">The product to be expired</param>
    public delegate void ExpireBidDEL(IProduct product);

    /// <summary>
    /// Gets the client id for web socket handling from server controller
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public delegate string GetIDFromUsername(string username);

    /// <summary>
    /// Sends the expired product to comm ctrl for notifications
    /// </summary>
    /// <param name="product"></param>
    /// <param name="username"></param>
    public delegate void ExpireBidCommDEL(IProduct product);

    /// <summary>
    /// Delegate to be called siginifing a successfull login from server login view
    /// </summary>
    public delegate void LoginSuccessDEL();

    /// <summary>
    /// a delegate to get the current connected clients
    /// </summary>
    /// <returns></returns>
    public delegate List<string> GetClientDEL();

    /// <summary>
    /// Program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            List<Product> readInProducts = JsonConvert.DeserializeObject<List<Product>>(File.ReadAllText("../../PreloadBids.txt"));

            List<IProduct> database = new List<IProduct>();
            foreach(Product product in readInProducts)
            {
                database.Add(product);
            }
            ProductDB productDB = new ProductDB(database);
            ServerController serverController = new ServerController(productDB); //Call to ServerController()

            

            //Application.Run(new AdminView(new ProductDB(), new List<string> { "Client 1", "Client 2", "Client 3"}, new List<Product> { new Product("12345", "beans", 20.0m, 0, false) }));
            
        }
    }
}
