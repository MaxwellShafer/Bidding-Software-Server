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

        private List<string> _clients;

        public AddProductDEL AddProduct;

        private List<Product> _newItems;

        public AdminView(ProductDB db, List<string> clients, List<Product> newItems)
        {
            InitializeComponent();
            _newItems = newItems;
            _database = db;
            _clients = clients;
            DisplayState(AdminState.START);
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
                    foreach(Product p in _database.Products)
                    {
                        uxCurrentProductsList.Items.Add(p.ToString());
                    }
                    foreach(string client in _clients)
                    {
                        uxConnectedClientsList.Items.Add(client);
                    }
                    foreach(Product item in _newItems)
                    {
                        uxNewProductsList.Items.Add(item.ToString());
                    }
                    uxNewProductsList.SelectedIndex = -1;
                    uxAddBtn.Enabled = false;
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
