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
    public delegate void PlaceBidDEL(string id, decimal price);
    public delegate void ChangeProdDEL(ProductProxy product);


    public partial class ClientBidView : Form
    {
        public PlaceBidDEL placeBid;
        
        public ProductDbProxy database;

        public decimal MinimumBid;

        public decimal currentBid;

        public ChangeProdDEL changeproduct;
        

        public ClientBidView(ChangeProdDEL cpd , ProductDbProxy db)
        {
            changeproduct = cpd;
            database = db;
            

            InitializeComponent();

            RefreshDisplay();
            RefreshList();

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
                placeBid(database.SelectedProduct.Id, currentBid);
                handleEvents(BidState.GoodBid);
            }
            else
            {
                handleEvents(BidState.BadBid);
            }
        }

        public void handleEvents(BidState state)
        {
            switch (state)
            {
                case BidState.ChangeProduct:

                    RefreshList();
                    RefreshDisplay();

                    break;


                case BidState.PriceUpdated:

                    RefreshDisplay();
                    break;

                case BidState.GoodBid:
                    RefreshDisplay();
                    break;
                case BidState.Win:
                            Status.Text = "won";

                    break;

                case BidState.Lose:

                    Status.Text = "lost";
                    break;





                case BidState.BadBid:
                    MessageBox.Show("Bad bid.");
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
            MinBid.Text = "Minimum bid: $" + database.SelectedProduct.MinBid;
            MinimumBid = database.SelectedProduct.MinBid;
            NumBids.Text = $"({database.SelectedProduct.BidCount})";
            
                Status.Text = "Open";
            
            
            name.Text = database.SelectedProduct.Name;
        }


        public void RefreshList()
        {
            listBox.Items.Clear();

            // Iterate through the list of products
            foreach (ProductProxy product in database.Products)
            {
                
                ListViewItem item = new ListViewItem(product.Name);

                listBox.Items.Add(item);
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
            



            if (listBox.SelectedItems.Count > 0 && database != null)
            {
                int selectedIndex = listBox.SelectedIndices[0];

                if (selectedIndex >= 0 && selectedIndex < database.Products.Count)
                {
                    ProductProxy selectedProduct = database.Products[selectedIndex];
                    
                    changeproduct(selectedProduct);
                }
            }
        }


        public void setPlaceBid(PlaceBidDEL del)
        {
            placeBid = del;
        }
    }
}