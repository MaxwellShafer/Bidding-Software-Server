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
        public LoginState State { get; set; }

        /// <summary>
        /// A property to hold each login attempt
        /// </summary>
        public LoginAttempt LoginAttempt { get; set; }

        /// <summary>
        /// A delgate that is called when the user attempts to log in
        /// </summary>
        public LoginClickDEL LoginClickDEL { get; set; }

        

        /// <summary>
        /// Constructor for the LoginView
        /// </summary>
        public ServerLoginView(LoginClickDEL LoginClick)
        {
            LoginClickDEL = LoginClick;
            InitializeComponent();
            uxLoginBtn.Enabled = false;
        }

        /// <summary>
        /// A method to be called when the state of the display need to be changed
        /// </summary>
        /// <param name="state"> The state the view will update to</param>
        public void DisplayState(LoginState state)
        {
            switch(state)
            {
                case LoginState.START:
                    break;
                case LoginState.GOTUSERNAME:
                case LoginState.GOTPASSWORD:
                    if (uxPasswordEntry.Text != "" && uxUsernameEntry.Text != "")
                    {
                        uxLoginBtn.Enabled = true;
                    }
                    else
                    {
                        uxLoginBtn.Enabled = false;
                    }
                    break;
                case LoginState.DECLINED:
                    uxPasswordEntry.Text = "";
                    uxLoginBtn.Enabled = false;
                    MessageBox.Show("Sorry, that wasn't quite right");
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
            LoginClickDEL(uxUsernameEntry.Text, uxPasswordEntry.Text);
            uxLoginBtn.Enabled = false;
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
