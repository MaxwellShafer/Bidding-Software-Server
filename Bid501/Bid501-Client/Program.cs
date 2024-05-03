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
            ClientBidView bidView = null; // Initialize bidView outside the lambda expression
            bool viewShown = false; // Flag to track if the view form has been shown

            loginController.SetupDels(view.DisplayState, clientCommCtrl.SendLoginInfo, (idb) =>
            {
                var productsProxy = new ProductDbProxy(idb.Products);
                var controller = new BidClientController(productsProxy, clientCommCtrl.SendBid);
                clientCommCtrl.SetBidUpdated(controller.BidUpdated);
                clientCommCtrl.SetNewProduct(controller.NewProduct);
                clientCommCtrl.SetBidExpired(controller.BidExpired);
                bidView = new ClientBidView(controller.FetchNewProduct, productsProxy);
                controller.SetProxy(bidView.handleEvents);
                bidView.setPlaceBid(controller.PlaceBid);
                view.Close();

                // Once bidView is set up, if the view form hasn't been shown yet, show it
                
            });

            if (!viewShown)
            {
                viewShown = true;
                view.ShowDialog();
            }

            // Run the bidView form
            Application.Run(bidView);
            bidView.ShowDialog();
        }

    }
}