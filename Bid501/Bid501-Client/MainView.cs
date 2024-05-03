using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Client
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            
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
                bidView.ShowDialog();
            });
            contentPanel.Controls.Add(view);
        }

        public void SwitchToBidView()
        {
            
        }
    }
}