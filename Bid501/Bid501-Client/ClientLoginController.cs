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

        public void handleEvents(LoginState state , string args)
        {
            switch (state)
            {
                case LoginState.START:

                    fetchState(LoginState.START);
                    break;
                case LoginState.GOTUSERNAME:
                    fetchState(LoginState.GOTUSERNAME);
                    loginAttempt.Username = args;
                    break;
                case LoginState.GOTPASSWORD:
                    fetchState(LoginState.GOTPASSWORD);
                    
                    string[] parts = args.Split(':');

                    if (parts.Length == 2)
                    {
                        loginAttempt.Username = parts[0];
                        loginAttempt.Password = parts[1];

                    }
                    checkLogin(loginAttempt);
                    break;
                default:
                    break;
            }
        }

       public void handleLoginReturn (IDB idb)
        {
        }

    }
}
