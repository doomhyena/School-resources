namespace _20250331___Winforms
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.lbx_Categories = new System.Windows.Forms.ListBox();
			this.flp_Products = new System.Windows.Forms.FlowLayoutPanel();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(820, 71);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.LightCoral;
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Location = new System.Drawing.Point(0, 375);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(820, 45);
			this.panel2.TabIndex = 1;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.Khaki;
			this.panel3.Controls.Add(this.lbx_Categories);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel3.Location = new System.Drawing.Point(0, 71);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(132, 304);
			this.panel3.TabIndex = 2;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.panel4.Controls.Add(this.flp_Products);
			this.panel4.Controls.Add(this.panel5);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel4.Location = new System.Drawing.Point(132, 71);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(688, 304);
			this.panel4.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.OldLace;
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(0, 268);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(688, 36);
			this.panel5.TabIndex = 0;
			// 
			// lbx_Categories
			// 
			this.lbx_Categories.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lbx_Categories.FormattingEnabled = true;
			this.lbx_Categories.Location = new System.Drawing.Point(0, 0);
			this.lbx_Categories.Name = "lbx_Categories";
			this.lbx_Categories.ScrollAlwaysVisible = true;
			this.lbx_Categories.Size = new System.Drawing.Size(132, 304);
			this.lbx_Categories.TabIndex = 0;
			this.lbx_Categories.SelectedIndexChanged += new System.EventHandler(this.lbx_Categories_SelectedIndexChanged);
			// 
			// flp_Products
			// 
			this.flp_Products.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flp_Products.Location = new System.Drawing.Point(0, 0);
			this.flp_Products.Name = "flp_Products";
			this.flp_Products.Size = new System.Drawing.Size(688, 268);
			this.flp_Products.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(820, 420);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ListBox lbx_Categories;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.FlowLayoutPanel flp_Products;
	}
}

