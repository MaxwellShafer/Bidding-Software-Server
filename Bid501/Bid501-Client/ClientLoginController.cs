using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public delegate void CheckLoginDEL(string loginModel);
    public delegate void FetchStateDEL(LoginState LoginDEL);



    public class ClientLoginController
    {
        public ClientLoginModel loginAttempt;

        public ClientLoginController(ClientLoginModel loginAttempt)
        {
            this.loginAttempt = loginAttempt;
        }

        public void handleEvents(LoginState state)
        {

        }

    }
}
