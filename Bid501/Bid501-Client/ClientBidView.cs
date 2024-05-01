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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Bid501_Client
{
    public delegate void PlaceBidDEL(decimal price);
    public delegate void ChangeProdDEL(ProductProxy product);


    public partial class ClientBidView : Form
    {
        public PlaceBidDEL placeBid;

        public ProductProxy product;

        public ProductDBProxy database;

        public decimal MinimumBid;

        public decimal currentBid;

        public ChangeProdDEL changeproduct;
        

        public ClientBidView(ChangeProdDEL cpd)
        {
            changeproduct = cpd;
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
            currentBid = Convert.ToDecimal(Bid.Text);

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
                case BidState.CHANGEPRODUCT:

                    RefreshList();
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
            MinBid.Text = "Minimum bid: $" + product.MinBid.ToString();
            MinimumBid = product.MinBid;
            NumBids.Text = $"({product.BidCount})";
            if (product.IsExpired)
            {
                if (product.Winning)
                {
                    Status.Text = "won";
                }
                else
                {
                    Status.Text = "lost";
                }
            }
            else
            {
                Status.Text = "Open";
            }
            
            name.Text = product.Name;
        }


        public void RefreshList()
        {
            productList.Items.Clear();

            // Iterate through the list of products
            foreach (Product product in database.Products)
            {
                
                ListViewItem item = new ListViewItem(product.Name); 

                productList.Items.Add(item);
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
        private void NewProductClick(object sender, EventArgs e)
        {
            



            if (productList.SelectedItems.Count > 0 && database != null)
            {
                int selectedIndex = productList.SelectedIndices[0];

                if (selectedIndex >= 0 && selectedIndex < database.Products.Count)
                {
                    ProductProxy selectedProduct = database.Products[selectedIndex];
                    
                    changeproduct(selectedProduct);
                }
            }









        }
    }
}