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
    public partial class AdminView : Form
    {
        private ProductDB _database;

        public AddProductDEL AddProduct;

        public AdminView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Updates the AdminView based on the state given
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(AdminState state)
        {

        }

        /// <summary>
        /// Handles add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            //if()
        }
    }
}
