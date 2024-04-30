using Bid501_Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bid501_Client
{
    public delegate void PlaceBidDEL(double price);
    public delegate void FetchBidDEL(Product product);


    public partial class ClientBidView : Form
    {
        public PlaceBidDEL placeBid;

        public ProductProxy product;

        public IDB database;

        public ClientBidView()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double bid = Convert.ToDouble(Bid.Text);
            placeBid(bid);
        }

        public void handleEvents(BidState state)
        {
            switch (state)
            {
                case BidState.NEWPRODUCT:

                    product = 
                    
                    break;
                
                default:
                    break;
            }
        }




        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Grabs the product that user selected on this list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0 && database != null)
            {
                int selectedIndex = listView1.SelectedIndices[0];

                
                if (selectedIndex >= 0 && selectedIndex < database.Products.Count)
                {
                    Product selectedProduct = database.Products[selectedIndex];
                   
                }
            }
        }
    }
}