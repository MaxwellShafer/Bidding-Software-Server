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
    }
}