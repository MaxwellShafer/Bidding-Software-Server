using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;
using Bid501_Shared;

namespace Bid501_Server
{
    /// <summary>
    /// Delegate for when the bid is being updated
    /// </summary>
    /// <param name="bid">The amount being bid</param>
    /// <param name="id">The id of the bid being updated</param>
    public delegate void BidUpdateDEL(double bid, string id);

    /// <summary>
    /// Delegate for when a new bid arrives to the server.
    /// </summary>
    /// <param name="bid">The amount being bid</param>
    /// <param name="id">The id of the product</param>
    public delegate void NewBidDEL(double bid, string id);

    /// <summary>
    /// Delegate for when the login is returned to the client
    /// </summary>
    /// <param name="status">Whether or not the client successfully logged in</param>
    public delegate void LoginReturnDEL(bool status);

    /// <summary>
    /// Delegate for receiving a login attempt from the client
    /// </summary>
    /// <param name="user"></param>
    /// <param name="password"></param>
    public delegate void LoginAttemptDEL(string user, string password);

    /// <summary>
    /// Sends a product to the clients
    /// </summary>
    /// <param name="product">The product being sent</param>
    public delegate void SendProductDEL(IProduct product);

    /// <summary>
    /// Updates the state of the admin view
    /// </summary>
    /// <param name="state">The AdminState</param>
    public delegate void UpdateStateDEL(AdminState state);

    /// <summary>
    /// Add a product to the database
    /// </summary>
    /// <param name="product">The product to be added</param>
    public delegate void AddProductDEL(IProduct product);

    /// <summary>
    /// Delegate for when the login display needs to be updated
    /// </summary>
    /// <param name="state">The current state of the login system</param>
    internal delegate void FetchStateDEL(LoginState state);

    /// <summary>
    /// Handles the admin login attempt
    /// </summary>
    /// <param name="un">The username</param>
    /// <param name="pw">The password</param>
    internal delegate void LoginClickDEL(string un, string pw);

    /// <summary>
    /// Program class
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WebSocketServer socket = new WebSocketServer(8002);
            socket.AddWebSocketService<ServerCommCtrl>("/server", () => new ServerCommCtrl());
            socket.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AdminView(new ProductDB(), new List<string> { "Client 1", "Client 2", "Client 3"}, new List<Product> { new Product("12345", "beans", 20.0m, 0, false) }));
            socket.Stop();
        }
    }
}
