using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;
using Bid501_Shared;

namespace Bid501_Client
{
    public delegate void FetchStateDEL(LoginState LoginDEL);

    public delegate void CheckLoginDEL(LoginDTO loginAttempt);

    /// <summary>
    /// Delegate to connect ClientCommCtrl to ClientBidView
    /// </summary>
    public delegate void SetBidUpdated(BidUpdateDEL del);

    
    /// <summary>
    /// Delegate to connect ClientCommCtrl to ClientBidView
    /// </summary>
    public delegate void SetNewProductDEL(NewProduct del);


    public class ClientLoginController
    {
        public LoginDTO loginAttempt;
        public FetchStateDEL fetchState;
        public CheckLoginDEL checkLogin;
        public SetBidUpdated setBidUpdated;
        public SetNewProductDEL setNewProduct;

        public ClientLoginController(LoginDTO loginAttempt)
        {
            this.loginAttempt = loginAttempt;
        }

        public void SetupDels(FetchStateDEL fs, CheckLoginDEL cl, SetBidUpdated setBidUpdated,
            SetNewProductDEL setNewProductDel)
        {
            fetchState = fs;
            checkLogin = cl;
            this.setBidUpdated = setBidUpdated;
            this.setNewProduct = setNewProduct;
        }

        public void HandleEvents(LoginState state, string email, String password)
        {
            switch (state)
            {
                case LoginState.START:
                    fetchState(LoginState.START);
                    break;
                case LoginState.GOTUSERNAME:
                    fetchState(LoginState.GOTUSERNAME);
                    loginAttempt.Username = email;
                    break;
                case LoginState.GOTPASSWORD:
                    fetchState(LoginState.GOTPASSWORD);

                    if (password != null)
                    {
                        loginAttempt.Username = email;
                        loginAttempt.Password = password;
                    }

                    checkLogin(loginAttempt);
                    break;
                default:
                    break;
            }
        }

        public void HandleLoginReturn(IDB idb)
        {
            var productsProxy = new ProductDBProxy(idb.Products);
            var controller = new BidClientController(productsProxy);
            setBidUpdated(controller.BidUpdated);
            setNewProduct(controller.NewProduct);
            var bidView = new ClientBidView(controller.fetchNewProduct);
            controller.SetProxy(bidView.handleEvents);
            Application.Run(bidView);
            // maybe use this instead...
            //bidView.Show();
        }
    }
}