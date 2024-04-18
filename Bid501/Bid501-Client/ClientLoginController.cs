using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;
using System.Windows.Forms;

namespace Bid501_Client
{
    public delegate void FetchStateDEL(LoginState LoginDEL);



    public class ClientLoginController
    {
        public ClientLoginModel loginAttempt;
        public FetchStateDEL fetchState;
        public CheckLoginDEL checkLogin;

        public ClientLoginController(ClientLoginModel loginAttempt)
        {
            this.loginAttempt = loginAttempt;
        }

        public void SetupDels(FetchStateDEL fs)
        {
            fetchState = fs;
        }

        public void handleEvents(LoginState state , string args)
        {
            switch (state)
            {
                case LoginState.START:

                    fetchState(LoginState.START);
                    break;
                case LoginState.GOTUSERNAME:
                    fetchState(LoginState.GOTUSERNAME);
                    break;
                case LoginState.GOTPASSWORD:
                    fetchState(LoginState.GOTPASSWORD);
                    //validateCredentials(args);
                    break;
                default:
                    break;
            }
        }

        public void newLoginAttempt(string un , string pw)
        {

        }

    }
}
