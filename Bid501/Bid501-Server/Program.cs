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
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            WebSocketServer socket = new WebSocketServer(8001);
            socket.AddWebSocketService<ServerCommCtrl>("/server", () => new ServerCommCtrl());
            socket.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            socket.Stop();
        }
    }
}
