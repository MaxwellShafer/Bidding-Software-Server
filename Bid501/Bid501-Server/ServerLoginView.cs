using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Server
{
    /// <summary>
    /// The backing class for the Server Login View
    /// </summary>
    public partial class ServerLoginView : Form
    {
        /// <summary>
        /// The current State of the Login View
        /// </summary>
        internal LoginState State { get; set; }

        /// <summary>
        /// A property to hold each login attempt
        /// </summary>
        public LoginAttempt LoginAttempt { get; set; }

        /// <summary>
        /// A delgate that is called when the user attempts to log in
        /// </summary>
        internal LoginClickDEL LoginClickDEL { get; set; }

        /// <summary>
        /// Constructor for the LoginView
        /// </summary>
        public ServerLoginView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// A method to be called when the state of the display need to be changed
        /// </summary>
        /// <param name="state"> The state the view will update to</param>
        internal void DisplayState(LoginState state)
        {
            switch(state)
            {
                case LoginState.START:
                    break;
                case LoginState.GOTUSERNAME:
                    break;
                case LoginState.GOTPASSWORD:
                    break;
                case LoginState.SUCCESS:
                    break;
                case LoginState.DECLINED:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles the Login button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxLoginBtn_Click(object sender, EventArgs e)
        {
            //maybe have another loginstate for waiting on a response here? That way if the server took a really long time for some reason, it would disable the button or something
        }

        /// <summary>
        /// Handles the username having changed text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxUsernameEntry_TextChanged(object sender, EventArgs e)
        {
            DisplayState(LoginState.GOTUSERNAME);
        }

        /// <summary>
        /// Handles the password having changed text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxPasswordEntry_TextChanged(object sender, EventArgs e)
        {
            DisplayState(LoginState.GOTPASSWORD);
        }
    }
}
