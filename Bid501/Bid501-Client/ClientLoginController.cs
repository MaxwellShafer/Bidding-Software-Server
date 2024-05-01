using System;
using Bid501_Shared;

namespace Bid501_Client
{
    public delegate void FetchStateDEL(LoginState loginDel);

    public delegate void CheckLoginDEL(LoginDTO loginAttempt);

    public delegate void LaunchBidViewDEL(IDB idb);


    public class ClientLoginController
    {
        private readonly LoginDTO _loginAttempt;
        private FetchStateDEL _fetchState;
        private CheckLoginDEL _checkLogin;
        private LaunchBidViewDEL _launchBidView;

        public ClientLoginController(LoginDTO loginAttempt)
        {
            this._loginAttempt = loginAttempt;
        }

        public void SetupDels(FetchStateDEL fs, CheckLoginDEL cl, LaunchBidViewDEL launch)
        {
            _fetchState = fs;
            _checkLogin = cl;
            _launchBidView = launch;
        }

        public void HandleEvents(LoginState state, string email, String password)
        {
            switch (state)
            {
                case LoginState.START:
                    _fetchState(LoginState.START);
                    break;
                case LoginState.GOTUSERNAME:
                    _fetchState(LoginState.GOTUSERNAME);
                    _loginAttempt.Username = email;
                    break;
                case LoginState.GOTPASSWORD:
                    _fetchState(LoginState.GOTPASSWORD);

                    if (password != null)
                    {
                        _loginAttempt.Username = email;
                        _loginAttempt.Password = password;
                    }
                    _checkLogin(_loginAttempt);
                    break;
            }
        }

        public void HandleLoginReturn(IDB idb)
        {
            _launchBidView(idb);
        }
    }
}