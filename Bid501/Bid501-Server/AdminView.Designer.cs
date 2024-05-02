namespace Bid501_Server
{
    partial class AdminView
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
            this.uxTabCtrl = new System.Windows.Forms.TabControl();
            this.uxHomeTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.uxCurrentProductsList = new System.Windows.Forms.ListBox();
            this.uxConnectedClientsList = new System.Windows.Forms.ListBox();
            this.uxExpireBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.uxAddThing = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.uxNewProductsList = new System.Windows.Forms.ListBox();
            this.uxAddBtn = new System.Windows.Forms.Button();
            this.uxTabCtrl.SuspendLayout();
            this.uxHomeTab.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.uxAddThing.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxTabCtrl
            // 
            this.uxTabCtrl.Controls.Add(this.uxHomeTab);
            this.uxTabCtrl.Controls.Add(this.uxAddThing);
            this.uxTabCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTabCtrl.ItemSize = new System.Drawing.Size(71, 21);
            this.uxTabCtrl.Location = new System.Drawing.Point(0, 0);
            this.uxTabCtrl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxTabCtrl.Name = "uxTabCtrl";
            this.uxTabCtrl.SelectedIndex = 0;
            this.uxTabCtrl.Size = new System.Drawing.Size(600, 366);
            this.uxTabCtrl.TabIndex = 0;
            // 
            // uxHomeTab
            // 
            this.uxHomeTab.Controls.Add(this.tableLayoutPanel2);
            this.uxHomeTab.Controls.Add(this.tableLayoutPanel1);
            this.uxHomeTab.Location = new System.Drawing.Point(4, 25);
            this.uxHomeTab.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxHomeTab.Name = "uxHomeTab";
            this.uxHomeTab.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxHomeTab.Size = new System.Drawing.Size(592, 337);
            this.uxHomeTab.TabIndex = 0;
            this.uxHomeTab.Text = "Home";
            this.uxHomeTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.uxCurrentProductsList, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.uxConnectedClientsList, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.uxExpireBtn, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 63);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(588, 272);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // uxCurrentProductsList
            // 
            this.uxCurrentProductsList.DisplayMember = "ToString();";
            this.uxCurrentProductsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxCurrentProductsList.FormattingEnabled = true;
            this.uxCurrentProductsList.Location = new System.Drawing.Point(2, 2);
            this.uxCurrentProductsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxCurrentProductsList.Name = "uxCurrentProductsList";
            this.uxCurrentProductsList.Size = new System.Drawing.Size(290, 236);
            this.uxCurrentProductsList.TabIndex = 0;
            this.uxCurrentProductsList.SelectedIndexChanged += new System.EventHandler(this.uxCurrentProductsList_SelectedIndexChanged);
            // 
            // uxConnectedClientsList
            // 
            this.uxConnectedClientsList.DisplayMember = "ToString();";
            this.uxConnectedClientsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxConnectedClientsList.FormattingEnabled = true;
            this.uxConnectedClientsList.Location = new System.Drawing.Point(296, 2);
            this.uxConnectedClientsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxConnectedClientsList.Name = "uxConnectedClientsList";
            this.uxConnectedClientsList.Size = new System.Drawing.Size(290, 236);
            this.uxConnectedClientsList.TabIndex = 1;
            // 
            // uxExpireBtn
            // 
            this.uxExpireBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uxExpireBtn.Location = new System.Drawing.Point(72, 242);
            this.uxExpireBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxExpireBtn.MinimumSize = new System.Drawing.Size(150, 24);
            this.uxExpireBtn.Name = "uxExpireBtn";
            this.uxExpireBtn.Size = new System.Drawing.Size(150, 27);
            this.uxExpireBtn.TabIndex = 2;
            this.uxExpireBtn.Text = "Expire Selected Bid";
            this.uxExpireBtn.UseVisualStyleBackColor = true;
            this.uxExpireBtn.Click += new System.EventHandler(this.uxExpireBtn_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(588, 61);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 61);
            this.label2.TabIndex = 1;
            this.label2.Text = "Connected Clients";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(290, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Items";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxAddThing
            // 
            this.uxAddThing.Controls.Add(this.tableLayoutPanel3);
            this.uxAddThing.Location = new System.Drawing.Point(4, 25);
            this.uxAddThing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAddThing.Name = "uxAddThing";
            this.uxAddThing.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAddThing.Size = new System.Drawing.Size(592, 337);
            this.uxAddThing.TabIndex = 1;
            this.uxAddThing.Text = "Add Product";
            this.uxAddThing.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.uxNewProductsList, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.uxAddBtn, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(588, 333);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // uxNewProductsList
            // 
            this.uxNewProductsList.DisplayMember = "NewStrDisplay";
            this.uxNewProductsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxNewProductsList.FormattingEnabled = true;
            this.uxNewProductsList.Location = new System.Drawing.Point(2, 2);
            this.uxNewProductsList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxNewProductsList.Name = "uxNewProductsList";
            this.uxNewProductsList.Size = new System.Drawing.Size(290, 329);
            this.uxNewProductsList.TabIndex = 0;
            this.uxNewProductsList.SelectedIndexChanged += new System.EventHandler(this.uxNewProductsList_SelectedIndexChanged);
            // 
            // uxAddBtn
            // 
            this.uxAddBtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.uxAddBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddBtn.Location = new System.Drawing.Point(366, 126);
            this.uxAddBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.uxAddBtn.MaximumSize = new System.Drawing.Size(150, 81);
            this.uxAddBtn.Name = "uxAddBtn";
            this.uxAddBtn.Size = new System.Drawing.Size(150, 81);
            this.uxAddBtn.TabIndex = 1;
            this.uxAddBtn.Text = "Add";
            this.uxAddBtn.UseVisualStyleBackColor = true;
            this.uxAddBtn.Click += new System.EventHandler(this.uxAddBtn_Click);
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.uxTabCtrl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AdminView";
            this.Text = "Admin Panel";
            this.uxTabCtrl.ResumeLayout(false);
            this.uxHomeTab.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.uxAddThing.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uxTabCtrl;
        private System.Windows.Forms.TabPage uxHomeTab;
        private System.Windows.Forms.TabPage uxAddThing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ListBox uxCurrentProductsList;
        private System.Windows.Forms.ListBox uxConnectedClientsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ListBox uxNewProductsList;
        private System.Windows.Forms.Button uxAddBtn;
        private System.Windows.Forms.Button uxExpireBtn;
    }
}