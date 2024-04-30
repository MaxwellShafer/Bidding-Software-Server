using Bid501_Shared;
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
            switch(state)
            {
                case AdminState.START:
                    break;
                case AdminState.EXPIRE:
                    break;
                case AdminState.WAIT:
                    break;
                case AdminState.ADDPRODUCT:
                    break;
                case AdminState.EXIT:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles add button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxAddBtn_Click(object sender, EventArgs e)
        {
            if (uxNewProductsList.SelectedItem is IProduct p) {
                AddProduct(p);
            } else
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
