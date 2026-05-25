namespace CustomerOrders
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
			this.cbx_Orders = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbx_Customers = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// cbx_Orders
			// 
			this.cbx_Orders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbx_Orders.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cbx_Orders.FormattingEnabled = true;
			this.cbx_Orders.Location = new System.Drawing.Point(12, 122);
			this.cbx_Orders.Name = "cbx_Orders";
			this.cbx_Orders.Size = new System.Drawing.Size(341, 31);
			this.cbx_Orders.TabIndex = 7;
			this.cbx_Orders.Text = "-- Válassz --";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(8, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 23);
			this.label2.TabIndex = 6;
			this.label2.Text = "Orders:";
			// 
			// cbx_Customers
			// 
			this.cbx_Customers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbx_Customers.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cbx_Customers.FormattingEnabled = true;
			this.cbx_Customers.Location = new System.Drawing.Point(12, 41);
			this.cbx_Customers.Name = "cbx_Customers";
			this.cbx_Customers.Size = new System.Drawing.Size(341, 31);
			this.cbx_Customers.TabIndex = 5;
			this.cbx_Customers.Text = "-- Válassz --";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(8, 15);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 4;
			this.label1.Text = "Customers:";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.cbx_Orders);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbx_Customers);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbx_Orders;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbx_Customers;
		private System.Windows.Forms.Label label1;
	}
}

