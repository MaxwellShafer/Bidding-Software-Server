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
    public delegate void FetchBidDEL(ProductProxy product);


    public partial class ClientBidView : Form
    {
        public PlaceBidDEL placeBid;

        public ProductProxy product;

        public ProductDBProxy database;

        public double MinimumBid;

        public double currentBid;
        

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

        private void PlaceBidClick(object sender, EventArgs e)
        {
            currentBid = Convert.ToDouble(Bid.Text);

            if(currentBid > MinimumBid)
            {

                handleEvents(BidState.GOODBID);
            }
            else
            {
                handleEvents(BidState.BADBID);
            }
        }

        public void handleEvents(BidState state)
        {
            switch (state)
            {
                case BidState.NEWPRODUCT:

                    RefreshDisplay();
                    
                    break;


                case BidState.PRICEUPDATED:

                    RefreshDisplay();
                    break;

                case BidState.GOODBID:

                    placeBid(currentBid);
                    break;


                case BidState.BADBID:

                   
                    break;
                
                default:
                    break;
            }
        }




        /// <summary>
        /// This class will refresh the display with the product
        /// </summary>
        public void RefreshDisplay()
        {
           /* MinBid.Text = "Minimum bid: $" + product.minbid.ToString();
            MinimumBid = product.minbid;
            NumBids.Text = $"({product.numbid})";
            Status.Text = "Status: " +  ;
            name.Text = product.name;*/


        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Grabs the product that user selected on this list view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewProductClick(object sender, EventArgs e)
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