namespace NorthwindWinForms
{
    partial class Form1
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
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.lblProducts = new System.Windows.Forms.Label();
            this.cmbCustomers = new System.Windows.Forms.ComboBox();
            this.lblCustomers = new System.Windows.Forms.Label();
            this.cmbOrders = new System.Windows.Forms.ComboBox();
            this.lblOrders = new System.Windows.Forms.Label();
            this.lstOrderLines = new System.Windows.Forms.ListBox();
            this.lblTotalCaption = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbProducts
            // 
            this.cmbProducts.AllowDrop = true;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(12, 39);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(300, 24);
            this.cmbProducts.TabIndex = 0;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged);
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Location = new System.Drawing.Point(13, 13);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(57, 16);
            this.lblProducts.TabIndex = 1;
            this.lblProducts.Text = "Termék:";
            // 
            // cmbCustomers
            // 
            this.cmbCustomers.FormattingEnabled = true;
            this.cmbCustomers.Location = new System.Drawing.Point(12, 108);
            this.cmbCustomers.Name = "cmbCustomers";
            this.cmbCustomers.Size = new System.Drawing.Size(300, 24);
            this.cmbCustomers.TabIndex = 2;
            // 
            // lblCustomers
            // 
            this.lblCustomers.AutoSize = true;
            this.lblCustomers.Location = new System.Drawing.Point(13, 79);
            this.lblCustomers.Name = "lblCustomers";
            this.lblCustomers.Size = new System.Drawing.Size(88, 16);
            this.lblCustomers.TabIndex = 3;
            this.lblCustomers.Text = "Cég (vásárló)";
            // 
            // cmbOrders
            // 
            this.cmbOrders.FormattingEnabled = true;
            this.cmbOrders.Location = new System.Drawing.Point(12, 183);
            this.cmbOrders.Name = "cmbOrders";
            this.cmbOrders.Size = new System.Drawing.Size(300, 24);
            this.cmbOrders.TabIndex = 4;
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(13, 151);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(124, 16);
            this.lblOrders.TabIndex = 5;
            this.lblOrders.Text = "Rendelés (OrderID)";
            // 
            // lstOrderLines
            // 
            this.lstOrderLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lstOrderLines.FormattingEnabled = true;
            this.lstOrderLines.HorizontalScrollbar = true;
            this.lstOrderLines.ItemHeight = 17;
            this.lstOrderLines.Location = new System.Drawing.Point(556, 203);
            this.lstOrderLines.Name = "lstOrderLines";
            this.lstOrderLines.Size = new System.Drawing.Size(220, 208);
            this.lstOrderLines.TabIndex = 6;
            // 
            // lblTotalCaption
            // 
            this.lblTotalCaption.AutoSize = true;
            this.lblTotalCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblTotalCaption.Location = new System.Drawing.Point(553, 172);
            this.lblTotalCaption.Name = "lblTotalCaption";
            this.lblTotalCaption.Size = new System.Drawing.Size(144, 17);
            this.lblTotalCaption.TabIndex = 7;
            this.lblTotalCaption.Text = "Rendelés végösszeg:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(703, 172);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(11, 16);
            this.lblTotal.TabIndex = 8;
            this.lblTotal.Text = "-";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblTotalCaption);
            this.Controls.Add(this.lstOrderLines);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.cmbOrders);
            this.Controls.Add(this.lblCustomers);
            this.Controls.Add(this.cmbCustomers);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.cmbProducts);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.ComboBox cmbCustomers;
        private System.Windows.Forms.Label lblCustomers;
        private System.Windows.Forms.ComboBox cmbOrders;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.ListBox lstOrderLines;
        private System.Windows.Forms.Label lblTotalCaption;
        private System.Windows.Forms.Label lblTotal;
    }
}

