using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebSocketSharp.Server;

namespace Bid501_Client
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginForm view = new LoginForm();

            ClientCommCtrl controller = new ClientCommCtrl(view);
            view.SetController(controller);
            WebSocketServer wss = new WebSocketServer(8001);

            wss.AddWebSocketService<ClientCommCtrl>("/client", () => {
                ClientCommCtrl clientCommCtrl = new ClientCommCtrl(view);
                view.SetController(clientCommCtrl);
                return clientCommCtrl;
            });
            wss.Start();

            Application.Run(view);
            wss.Stop();
        }
    }
}
