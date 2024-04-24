using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// A Data class to format and hold the information for each log in.
    /// </summary>
    public class LoginAttempt
    {
        /// <summary>
        /// Property for the username 
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Property for the password
        /// </summary>
        public string Password { get; private set; }

    }
}
