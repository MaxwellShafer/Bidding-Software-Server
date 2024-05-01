namespace Bid501_Client
{
    partial class ClientBidView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.productList = new System.Windows.Forms.ListView();
            this.Bid = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.MinBid = new System.Windows.Forms.Label();
            this.NumBids = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.Label();
            this.TimeLeft = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(453, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Products";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // productList
            // 
            this.productList.HideSelection = false;
            this.productList.Location = new System.Drawing.Point(402, 108);
            this.productList.Name = "productList";
            this.productList.Size = new System.Drawing.Size(190, 330);
            this.productList.TabIndex = 1;
            this.productList.UseCompatibleStateImageBehavior = false;
            this.productList.SelectedIndexChanged += new System.EventHandler(this.NewProductClick);
            // 
            // Bid
            // 
            this.Bid.Location = new System.Drawing.Point(102, 276);
            this.Bid.Name = "Bid";
            this.Bid.Size = new System.Drawing.Size(128, 22);
            this.Bid.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 36);
            this.button1.TabIndex = 3;
            this.button1.Text = "Place Bid";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.PlaceBidClick);
            // 
            // MinBid
            // 
            this.MinBid.AutoSize = true;
            this.MinBid.Location = new System.Drawing.Point(107, 318);
            this.MinBid.Name = "MinBid";
            this.MinBid.Size = new System.Drawing.Size(123, 16);
            this.MinBid.TabIndex = 4;
            this.MinBid.Text = "Minimum bid $15.00";
            this.MinBid.Click += new System.EventHandler(this.label2_Click);
            // 
            // NumBids
            // 
            this.NumBids.AutoSize = true;
            this.NumBids.Location = new System.Drawing.Point(248, 279);
            this.NumBids.Name = "NumBids";
            this.NumBids.Size = new System.Drawing.Size(51, 16);
            this.NumBids.TabIndex = 5;
            this.NumBids.Text = "(7 bids)";
            this.NumBids.Click += new System.EventHandler(this.label3_Click);
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(143, 233);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(44, 16);
            this.Status.TabIndex = 6;
            this.Status.Text = "label4";
            // 
            // TimeLeft
            // 
            this.TimeLeft.AutoSize = true;
            this.TimeLeft.Location = new System.Drawing.Point(143, 182);
            this.TimeLeft.Name = "TimeLeft";
            this.TimeLeft.Size = new System.Drawing.Size(44, 16);
            this.TimeLeft.TabIndex = 7;
            this.TimeLeft.Text = "label5";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Location = new System.Drawing.Point(143, 125);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(44, 16);
            this.name.TabIndex = 8;
            this.name.Text = "label6";
            // 
            // ClientBidView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 450);
            this.Controls.Add(this.name);
            this.Controls.Add(this.TimeLeft);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.NumBids);
            this.Controls.Add(this.MinBid);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Bid);
            this.Controls.Add(this.productList);
            this.Controls.Add(this.label1);
            this.Name = "ClientBidView";
            this.Text = "ClientBidView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView productList;
        private System.Windows.Forms.TextBox Bid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label MinBid;
        private System.Windows.Forms.Label NumBids;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label TimeLeft;
        private System.Windows.Forms.Label name;
    }
}