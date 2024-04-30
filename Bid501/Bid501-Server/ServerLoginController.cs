using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid501_Server
{
    /// <summary>
    /// The controller that handles the LogIn
    /// </summary>
    internal class ServerLoginController
    {
        /// <summary>
        /// a private field to hold a logInAttempt
        /// </summary>
        private LoginAttempt LoginAttempt;

        /// <summary>
        /// A delegate that is called in the controller to invoke the method to update the state in the view
        /// </summary>
        public FetchStateDEL fetchStateDEL { get; set; }

    }
}
