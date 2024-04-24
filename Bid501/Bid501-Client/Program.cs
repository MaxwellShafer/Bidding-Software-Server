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
            LoginForm view = new LoginForm(loginController.handleEvents);
            

            ClientCommCtrl commCtrl = new ClientCommCtrl(loginController.handleLoginReturn);
            loginController.SetupDels(view.DisplayState , commCtrl.SendLoginInfo);
            

            WebSocketServer wss = new WebSocketServer(8001);

            wss.AddWebSocketService<ClientCommCtrl>("/client", () => {
                ClientCommCtrl clientCommCtrl = new ClientCommCtrl(loginController.handleLoginReturn);
                loginController.SetupDels(view.DisplayState, clientCommCtrl.SendLoginInfo);
                return clientCommCtrl;
            });
            wss.Start();

            Application.Run(view);
            wss.Stop();
        }
    }
}