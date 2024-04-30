using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bid501_Shared;
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


            LoginDTO login = new LoginDTO();
            ClientLoginController loginController = new ClientLoginController(login);
            LoginForm view = new LoginForm(loginController.HandleEvents);

            WebSocketServer wss = new WebSocketServer(8001);

            wss.AddWebSocketService<ClientCommCtrl>("/client", () =>
            {
                ClientCommCtrl clientCommCtrl = new ClientCommCtrl(loginController.HandleLoginReturn);
                loginController.SetupDels(view.DisplayState, clientCommCtrl.SendLoginInfo, clientCommCtrl.SetBidUpdated,
                    clientCommCtrl.SetNewProduct);
                return clientCommCtrl;
            });
            wss.Start();

            Application.Run(view);
            wss.Stop();
        }
    }
}