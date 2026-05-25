namespace WindowsFormsApp1
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
			this.label1 = new System.Windows.Forms.Label();
			this.cbx_Categories = new System.Windows.Forms.ComboBox();
			this.cbx_Products = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dgw_ProductDetails = new System.Windows.Forms.DataGridView();
			this.Property = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label3 = new System.Windows.Forms.Label();
			this.tbx_ProductName = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tbx_UnitPrice = new System.Windows.Forms.MaskedTextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cb_Disconti = new System.Windows.Forms.CheckBox();
			this.btn_Create = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.cbx_AddPRoductCategories = new System.Windows.Forms.ComboBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Edit = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgw_ProductDetails)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(8, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Kategóriák:";
			// 
			// cbx_Categories
			// 
			this.cbx_Categories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbx_Categories.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cbx_Categories.FormattingEnabled = true;
			this.cbx_Categories.Location = new System.Drawing.Point(12, 87);
			this.cbx_Categories.Name = "cbx_Categories";
			this.cbx_Categories.Size = new System.Drawing.Size(341, 31);
			this.cbx_Categories.TabIndex = 1;
			this.cbx_Categories.Text = "-- Válassz --";
			this.cbx_Categories.SelectionChangeCommitted += new System.EventHandler(this.cbx_Categories_SelectionChangeCommitted);
			// 
			// cbx_Products
			// 
			this.cbx_Products.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cbx_Products.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.cbx_Products.FormattingEnabled = true;
			this.cbx_Products.Location = new System.Drawing.Point(12, 168);
			this.cbx_Products.Name = "cbx_Products";
			this.cbx_Products.Size = new System.Drawing.Size(341, 31);
			this.cbx_Products.TabIndex = 3;
			this.cbx_Products.Text = "-- Válassz --";
			this.cbx_Products.SelectionChangeCommitted += new System.EventHandler(this.cbx_Products_SelectionChangeCommitted);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(8, 142);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Termékek:";
			// 
			// dgw_ProductDetails
			// 
			this.dgw_ProductDetails.AllowUserToAddRows = false;
			this.dgw_ProductDetails.AllowUserToDeleteRows = false;
			this.dgw_ProductDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgw_ProductDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Property,
            this.Value});
			this.dgw_ProductDetails.Location = new System.Drawing.Point(446, 31);
			this.dgw_ProductDetails.MultiSelect = false;
			this.dgw_ProductDetails.Name = "dgw_ProductDetails";
			this.dgw_ProductDetails.RowHeadersVisible = false;
			this.dgw_ProductDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgw_ProductDetails.Size = new System.Drawing.Size(262, 178);
			this.dgw_ProductDetails.TabIndex = 4;
			// 
			// Property
			// 
			this.Property.DataPropertyName = "Property";
			this.Property.HeaderText = "Tulajdonság";
			this.Property.Name = "Property";
			this.Property.ReadOnly = true;
			// 
			// Value
			// 
			this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.Value.DataPropertyName = "Value";
			this.Value.HeaderText = "Érték";
			this.Value.Name = "Value";
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
			// tbx_ProductName
			// 
			this.tbx_ProductName.Location = new System.Drawing.Point(97, 9);
			this.tbx_ProductName.MaxLength = 40;
			this.tbx_ProductName.Name = "tbx_ProductName";
			this.tbx_ProductName.Size = new System.Drawing.Size(215, 20);
			this.tbx_ProductName.TabIndex = 6;
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
			// tbx_UnitPrice
			// 
			this.tbx_UnitPrice.Location = new System.Drawing.Point(97, 83);
			this.tbx_UnitPrice.Name = "tbx_UnitPrice";
			this.tbx_UnitPrice.Size = new System.Drawing.Size(143, 20);
			this.tbx_UnitPrice.TabIndex = 8;
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
			// cb_Disconti
			// 
			this.cb_Disconti.AutoSize = true;
			this.cb_Disconti.Location = new System.Drawing.Point(97, 125);
			this.cb_Disconti.Name = "cb_Disconti";
			this.cb_Disconti.Size = new System.Drawing.Size(15, 14);
			this.cb_Disconti.TabIndex = 10;
			this.cb_Disconti.UseVisualStyleBackColor = true;
			// 
			// btn_Create
			// 
			this.btn_Create.Location = new System.Drawing.Point(237, 151);
			this.btn_Create.Name = "btn_Create";
			this.btn_Create.Size = new System.Drawing.Size(75, 23);
			this.btn_Create.TabIndex = 11;
			this.btn_Create.Text = "Add Product";
			this.btn_Create.UseVisualStyleBackColor = true;
			this.btn_Create.Click += new System.EventHandler(this.Create_Click);
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
			// cbx_AddPRoductCategories
			// 
			this.cbx_AddPRoductCategories.FormattingEnabled = true;
			this.cbx_AddPRoductCategories.Location = new System.Drawing.Point(97, 49);
			this.cbx_AddPRoductCategories.Name = "cbx_AddPRoductCategories";
			this.cbx_AddPRoductCategories.Size = new System.Drawing.Size(203, 21);
			this.cbx_AddPRoductCategories.TabIndex = 13;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.cbx_AddPRoductCategories);
			this.panel1.Controls.Add(this.tbx_ProductName);
			this.panel1.Controls.Add(this.label6);
			this.panel1.Controls.Add(this.label4);
			this.panel1.Controls.Add(this.btn_Create);
			this.panel1.Controls.Add(this.tbx_UnitPrice);
			this.panel1.Controls.Add(this.cb_Disconti);
			this.panel1.Controls.Add(this.label5);
			this.panel1.Location = new System.Drawing.Point(12, 252);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(327, 186);
			this.panel1.TabIndex = 14;
			// 
			// btn_Edit
			// 
			this.btn_Edit.Location = new System.Drawing.Point(633, 215);
			this.btn_Edit.Name = "btn_Edit";
			this.btn_Edit.Size = new System.Drawing.Size(75, 23);
			this.btn_Edit.TabIndex = 15;
			this.btn_Edit.Text = "Edit Product";
			this.btn_Edit.UseVisualStyleBackColor = true;
			this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(737, 483);
			this.Controls.Add(this.btn_Edit);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.dgw_ProductDetails);
			this.Controls.Add(this.cbx_Products);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbx_Categories);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dgw_ProductDetails)).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbx_Categories;
		private System.Windows.Forms.ComboBox cbx_Products;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgw_ProductDetails;
		private System.Windows.Forms.DataGridViewTextBoxColumn Property;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbx_ProductName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.MaskedTextBox tbx_UnitPrice;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox cb_Disconti;
		private System.Windows.Forms.Button btn_Create;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox cbx_AddPRoductCategories;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_Edit;
	}
}

