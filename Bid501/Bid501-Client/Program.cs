using System;
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
            

            ClientCommCtrl clientCommCtrl = new ClientCommCtrl(loginController.HandleLoginReturn);
            loginController.SetupDels(view.DisplayState, clientCommCtrl.SendLoginInfo, (idb) =>
            {
                var productsProxy = new ProductDbProxy(idb.Products);
                var controller = new BidClientController(productsProxy, clientCommCtrl.SendBid);
                clientCommCtrl.SetBidUpdated(controller.BidUpdated);
                clientCommCtrl.SetNewProduct(controller.NewProduct);
                clientCommCtrl.SetBidExpired(controller.BidExpired);
                var bidView = new ClientBidView(controller.FetchNewProduct,productsProxy);
                controller.SetProxy(bidView.handleEvents);
                bidView.setPlaceBid(controller.PlaceBid);
                Application.Run(bidView);
                // maybe use this instead...
                bidView.Show();
            });
            Application.Run(view);
        }
    }
}