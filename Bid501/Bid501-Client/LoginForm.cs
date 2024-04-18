using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace Bid501_Client
{

    public enum LoginState
    {
        NOTINIT = -1,
        START = 0,
        GOTUSERNAME,
        GOTPASSWORD,
        SUCCESS,
        DECLINED,
        EXIT
    }

    public delegate void LoginClickDEL(LoginState state, string args);

    public partial class LoginForm : Form
    {
        public LoginClickDEL loginClick;

        public LoginForm(LoginClickDEL del)
        {
            loginClick = del;

            InitializeComponent();

        }



        /// <summary>
        /// THis method keepts the GUI controlls enabled/disabled, displaying the
        /// right information based on the App's satate.
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(LoginState state)
        {
            switch (state)
            {
                case LoginState.START:
                    lbStateMessage.Text = "Please Enter Username";
                    tbPassword.Enabled = false;
                    uxLoginBtn.Enabled = false;
                    break;
                case LoginState.GOTUSERNAME:
                    lbStateMessage.Text = "Please Enter Password";
                    tbPassword.Enabled = true;
                    break;
                case LoginState.GOTPASSWORD:
                    lbStateMessage.Text = "Validating Credentials...";

                    break;
                case LoginState.DECLINED:
                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        tbUserName.Text = "";
                        tbPassword.Text = "";
                        lbStateMessage.Text = "Sorry, Invalid Credentials";
                    }));
                    break;
                case LoginState.SUCCESS:

                    //Invoke this code since it will only ever be run on a separate thread.
                    this.Invoke(new Action(() =>
                    {
                        tbUserName.Text = "";
                        tbPassword.Text = "";
                        lbStateMessage.Text = "Congrats! You are Loggedin";
                    }));
                    break;
                default:
                    lbStateMessage.Text = "Invalid State";
                    break;

            }
        }

        /// <summary>
        /// Listener to the Login button. It takes the user's input
        /// for the username and password and pass the values to the
        /// Controller along with the state the view is in.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxLoginBtn_Click(object sender, EventArgs e)
        {
            String un = tbUserName.Text;
            String up = tbPassword.Text;
            //Console.WriteLine(un + " " + up);
            loginClick(LoginState.GOTPASSWORD, un + ":" + up);
            //controller.Login(un, up);

        }
        
        /*/// <summary>
        /// Links the View to the controller.
        /// </summary>
        /// <param name="c">The App's main controller object. Later
        /// this shold be a delegate.</param>
        public void SetController(ClientCommCtrl c)
        {
            controller = c;
        }*/
        

        /// <summary>
        /// TO synch the View and the Controller objects.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            loginClick(LoginState.START, "");
        }

        /// <summary>
        /// This method helps avoid some user input propblems, and helps 
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUserName_TextChanged(object sender, EventArgs e)
        {
            loginClick(LoginState.GOTUSERNAME, "");
        }


        /// <summary>
        /// This method helps avoid some user input propblems, and helps
        /// keep the GUI in the right state.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            uxLoginBtn.Enabled = true;
        }

    }
}

