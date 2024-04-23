using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp;
using WebSocketSharp.Server;

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

    public delegate void SendProductDEL();

    public delegate void UpdateStateDEL();

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
            Application.Run(new Form1());
            socket.Stop();
        }
    }
}
