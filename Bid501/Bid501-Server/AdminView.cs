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

        public ExpireBidDEL ExpireProduct;

        private List<Product> _newItems;

        public AdminView(ProductDB db, List<string> clients, List<Product> newItems, AddProductDEL add, ExpireBidDEL expire)
        {
            InitializeComponent();
            _newItems = newItems;
            _database = db;
            _clients = clients;
            AddProduct = add;
            ExpireProduct = expire;
            DisplayState(AdminState.START, _database, null);
        }

        /// <summary>
        /// Updates the AdminView based on the state given
        /// </summary>
        /// <param name="state"></param>
        public void DisplayState(AdminState state, ProductDB updatedDB, string newClient)
        {
            _database = updatedDB;
            switch(state)
            {
                case AdminState.START:
                    foreach(Product p in _database.Products)
                    {
                        uxCurrentProductsList.Items.Add(p);
                    }
                    foreach(string client in _clients)
                    {
                        uxConnectedClientsList.Items.Add("Client " + client);
                    }
                    foreach(Product item in _newItems)
                    {
                        uxNewProductsList.Items.Add(item);
                    }
                    uxNewProductsList.SelectedIndex = -1;
                    uxCurrentProductsList.SelectedIndex = -1;
                    uxConnectedClientsList.Enabled = false;
                    uxAddBtn.Enabled = false;
                    uxExpireBtn.Enabled = false;
                    break;
                case AdminState.SELECTEDEXPIRED:
                    try
                    {
                        if (!((IProduct)uxCurrentProductsList.SelectedItem).IsExpired)
                        {
                            uxExpireBtn.Enabled = true;
                            uxNewProductsList.ClearSelected();
                            uxAddBtn.Enabled = false;
                        } else
                        {
                            uxExpireBtn.Enabled = false;
                        }
                    } catch { }
                    break;
                case AdminState.EXPIREDBID:
                    uxCurrentProductsList.Items.Clear();
                    foreach(Product p in _database.Products)
                    {
                        uxCurrentProductsList.Items.Add(p);
                    }
                    uxCurrentProductsList.SelectedIndex = -1;
                    uxExpireBtn.Enabled = false;
                    break;
                case AdminState.SELECTEDNEW:
                    uxAddBtn.Enabled = true;
                    uxCurrentProductsList.ClearSelected();
                    uxExpireBtn.Enabled = false;
                    break;
                case AdminState.ADDEDNEW:
                    uxCurrentProductsList.Items.Clear();
                    foreach(Product p in _database.Products)
                    {
                        uxCurrentProductsList.Items.Add(p);
                    }
                    uxCurrentProductsList.SelectedIndex = -1;
                    uxAddBtn.Enabled = false;
                    uxNewProductsList.SelectedIndex = -1;
                    break;
                case AdminState.NEWCLIENT:
                    if(newClient != null)
                    {
                        _clients.Add(newClient);
                        uxConnectedClientsList.Items.Add("Client " + newClient);
                    }
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
            } else {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Handles the expiring of a bid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxExpireBtn_Click(object sender, EventArgs e)
        {
            if (uxCurrentProductsList.SelectedItem is IProduct p)
            {
                ExpireProduct(p);
            } else
            {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Updates view info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxCurrentProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayState(AdminState.SELECTEDEXPIRED, _database, null);
        }

        /// <summary>
        /// Updates view info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxNewProductsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayState(AdminState.SELECTEDNEW, _database, null);
        }
    }
}
