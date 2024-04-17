using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Client
{
    public class ClientLoginModel
    {
        public string username; 
        private string password;

        public ClientLoginModel()
        {
            
        }

        public void newLoginInAttempt(string un, string pw)
        {
            username = un; 
            password = pw; 
        }
    }
}
