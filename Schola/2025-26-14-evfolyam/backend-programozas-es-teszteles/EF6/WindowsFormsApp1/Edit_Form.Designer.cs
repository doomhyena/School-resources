namespace WindowsFormsApp1
{
	partial class Edit_Form
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
			this.btn_Cancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.cbx_AddPRoductCategories = new System.Windows.Forms.ComboBox();
			this.tbx_ProductName = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btn_Save = new System.Windows.Forms.Button();
			this.tbx_UnitPrice = new System.Windows.Forms.MaskedTextBox();
			this.cb_Disconti = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.btn_Cancel);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbx_AddPRoductCategories);
			this.panel1.Controls.Add(this.tbx_ProductName);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btn_Save);
			this.panel1.Controls.Add(this.tbx_UnitPrice);
			this.panel1.Controls.Add(this.cb_Disconti);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(345, 162);
			this.panel1.TabIndex = 15;
			// 
			// btn_Cancel
			// 
			this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_Cancel.Location = new System.Drawing.Point(176, 126);
			this.btn_Cancel.Name = "btn_Cancel";
			this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_Cancel.TabIndex = 14;
			this.btn_Cancel.Text = "Cancel";
			this.btn_Cancel.UseVisualStyleBackColor = true;
			this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(16, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(75, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Produc Name:";
			// 
			// cbx_AddPRoductCategories
			// 
			this.cbx_AddPRoductCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbx_AddPRoductCategories.FormattingEnabled = true;
			this.cbx_AddPRoductCategories.Location = new System.Drawing.Point(97, 49);
			this.cbx_AddPRoductCategories.Name = "cbx_AddPRoductCategories";
			this.cbx_AddPRoductCategories.Size = new System.Drawing.Size(203, 21);
			this.cbx_AddPRoductCategories.TabIndex = 13;
			// 
			// tbx_ProductName
			// 
			this.tbx_ProductName.Location = new System.Drawing.Point(97, 9);
			this.tbx_ProductName.MaxLength = 45;
			this.tbx_ProductName.Name = "tbx_ProductName";
			this.tbx_ProductName.Size = new System.Drawing.Size(215, 20);
			this.tbx_ProductName.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(16, 52);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Category:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(16, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Unit Price:";
			// 
			// btn_Save
			// 
			this.btn_Save.Location = new System.Drawing.Point(257, 125);
			this.btn_Save.Name = "btn_Save";
			this.btn_Save.Size = new System.Drawing.Size(75, 23);
			this.btn_Save.TabIndex = 11;
			this.btn_Save.Text = "Save";
			this.btn_Save.UseVisualStyleBackColor = true;
			this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
			// 
			// tbx_UnitPrice
			// 
			this.tbx_UnitPrice.Location = new System.Drawing.Point(97, 83);
			this.tbx_UnitPrice.Name = "tbx_UnitPrice";
			this.tbx_UnitPrice.Size = new System.Drawing.Size(143, 20);
			this.tbx_UnitPrice.TabIndex = 8;
			// 
			// cb_Disconti
			// 
			this.cb_Disconti.AutoSize = true;
			this.cb_Disconti.Location = new System.Drawing.Point(97, 125);
			this.cb_Disconti.Name = "cb_Disconti";
			this.cb_Disconti.Size = new System.Drawing.Size(15, 14);
			this.cb_Disconti.TabIndex = 10;
			this.cb_Disconti.UseVisualStyleBackColor = true;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(16, 125);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Discontinued:";
			// 
			// Edit_Form
			// 
			this.AcceptButton = this.btn_Save;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_Cancel;
			this.ClientSize = new System.Drawing.Size(345, 162);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Edit_Form";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit_Form";
			this.Load += new System.EventHandler(this.Edit_Form_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbx_AddPRoductCategories;
		private System.Windows.Forms.TextBox tbx_ProductName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btn_Save;
		private System.Windows.Forms.MaskedTextBox tbx_UnitPrice;
		private System.Windows.Forms.CheckBox cb_Disconti;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btn_Cancel;
	}
}