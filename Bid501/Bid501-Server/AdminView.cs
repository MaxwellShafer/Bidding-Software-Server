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
        private ProductDB database;

        private AddProductDEL addProductDEL;

        public AdminView()
        {
            InitializeComponent();
        }
    }
}
