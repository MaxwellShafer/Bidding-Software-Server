﻿using System;
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
    public partial class ServerLoginView : Form
    {
        /// <summary>
        /// The current State of the Login View
        /// </summary>
        public LoginState state { get; set; }

        /// <summary>
        /// A property to hold each login attempt
        /// </summary>
        public LogInAttempt logInAttempt { get; set; }



        public ServerLoginView()
        {
            InitializeComponent();
        }
    }
}
