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


    public class ClientLoginController
    {
        public LoginDTO loginAttempt;
        public FetchStateDEL fetchState;
        public CheckLoginDEL checkLogin;

        public ClientLoginController(LoginDTO loginAttempt)
        {
            this.loginAttempt = loginAttempt;
        }

        public void SetupDels(FetchStateDEL fs, CheckLoginDEL cl)
        {
            fetchState = fs;
            checkLogin = cl;
        }

        public void handleEvents(LoginState state, string email, String password)
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

       public void handleLoginReturn(IDB idb)
       {
            var bidView = new ClientBidView();
            var controller = new BidClientController(idb,  ,bidView.handleEvents);
           
           Application.Run(bidView);
           // maybe use this instead...
           //bidView.Show();
       }
    }
}
