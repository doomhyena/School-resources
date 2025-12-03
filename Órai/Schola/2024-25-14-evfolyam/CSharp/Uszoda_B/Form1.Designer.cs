namespace Uszoda_B
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
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btn_Stop = new System.Windows.Forms.Button();
			this.btn_Start = new System.Windows.Forms.Button();
			this.tmr_CreatePerson = new System.Windows.Forms.Timer(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.tbx_People = new System.Windows.Forms.TextBox();
			this.tbx_Box = new System.Windows.Forms.TextBox();
			this.tbx_Cabine = new System.Windows.Forms.TextBox();
			this.tbx_Leave = new System.Windows.Forms.TextBox();
			this.tbx_Fail = new System.Windows.Forms.TextBox();
			this.tbx_Tickets = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.flp_Box = new System.Windows.Forms.FlowLayoutPanel();
			this.flp_Cabine = new System.Windows.Forms.FlowLayoutPanel();
			this.tmr_useAutomata = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lbx_Products = new System.Windows.Forms.ListBox();
			this.lbx_Coins = new System.Windows.Forms.ListBox();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel1.Controls.Add(this.btn_Stop);
			this.panel1.Controls.Add(this.btn_Start);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(200, 335);
			this.panel1.TabIndex = 0;
			// 
			// btn_Stop
			// 
			this.btn_Stop.BackColor = System.Drawing.Color.LimeGreen;
			this.btn_Stop.FlatAppearance.BorderSize = 0;
			this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Stop.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Stop.Location = new System.Drawing.Point(31, 213);
			this.btn_Stop.Name = "btn_Stop";
			this.btn_Stop.Size = new System.Drawing.Size(117, 43);
			this.btn_Stop.TabIndex = 1;
			this.btn_Stop.Text = "STOP";
			this.btn_Stop.UseVisualStyleBackColor = false;
			this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
			// 
			// btn_Start
			// 
			this.btn_Start.BackColor = System.Drawing.Color.LimeGreen;
			this.btn_Start.FlatAppearance.BorderSize = 0;
			this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Start.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Start.Location = new System.Drawing.Point(31, 70);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(117, 43);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "START";
			this.btn_Start.UseVisualStyleBackColor = false;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// tmr_CreatePerson
			// 
			this.tmr_CreatePerson.Tick += new System.EventHandler(this.tmr_CreatePerson_Tick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(221, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(126, 25);
			this.label1.TabIndex = 1;
			this.label1.Text = "People count:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(221, 70);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 25);
			this.label2.TabIndex = 2;
			this.label2.Text = "Box count:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(221, 117);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 25);
			this.label3.TabIndex = 3;
			this.label3.Text = "Cabine count:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(221, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(117, 25);
			this.label4.TabIndex = 4;
			this.label4.Text = "Leave count:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(221, 213);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(97, 25);
			this.label5.TabIndex = 5;
			this.label5.Text = "Fail count:";
			// 
			// tbx_People
			// 
			this.tbx_People.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_People.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_People.Location = new System.Drawing.Point(363, 20);
			this.tbx_People.Name = "tbx_People";
			this.tbx_People.Size = new System.Drawing.Size(100, 26);
			this.tbx_People.TabIndex = 6;
			this.tbx_People.Text = "0";
			this.tbx_People.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx_Box
			// 
			this.tbx_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Box.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Box.Location = new System.Drawing.Point(363, 68);
			this.tbx_Box.Name = "tbx_Box";
			this.tbx_Box.Size = new System.Drawing.Size(100, 26);
			this.tbx_Box.TabIndex = 7;
			this.tbx_Box.Text = "0";
			this.tbx_Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx_Cabine
			// 
			this.tbx_Cabine.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Cabine.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Cabine.Location = new System.Drawing.Point(363, 116);
			this.tbx_Cabine.Name = "tbx_Cabine";
			this.tbx_Cabine.Size = new System.Drawing.Size(100, 26);
			this.tbx_Cabine.TabIndex = 8;
			this.tbx_Cabine.Text = "0";
			this.tbx_Cabine.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx_Leave
			// 
			this.tbx_Leave.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Leave.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Leave.Location = new System.Drawing.Point(363, 161);
			this.tbx_Leave.Name = "tbx_Leave";
			this.tbx_Leave.Size = new System.Drawing.Size(100, 26);
			this.tbx_Leave.TabIndex = 9;
			this.tbx_Leave.Text = "0";
			this.tbx_Leave.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx_Fail
			// 
			this.tbx_Fail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Fail.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Fail.Location = new System.Drawing.Point(363, 211);
			this.tbx_Fail.Name = "tbx_Fail";
			this.tbx_Fail.Size = new System.Drawing.Size(100, 26);
			this.tbx_Fail.TabIndex = 10;
			this.tbx_Fail.Text = "0";
			this.tbx_Fail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// tbx_Tickets
			// 
			this.tbx_Tickets.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Tickets.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Tickets.Location = new System.Drawing.Point(363, 253);
			this.tbx_Tickets.Name = "tbx_Tickets";
			this.tbx_Tickets.Size = new System.Drawing.Size(100, 26);
			this.tbx_Tickets.TabIndex = 12;
			this.tbx_Tickets.Text = "0";
			this.tbx_Tickets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.Location = new System.Drawing.Point(221, 254);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(129, 25);
			this.label6.TabIndex = 11;
			this.label6.Text = "Tickets Count:";
			// 
			// flp_Box
			// 
			this.flp_Box.AutoScroll = true;
			this.flp_Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flp_Box.Location = new System.Drawing.Point(487, 28);
			this.flp_Box.Name = "flp_Box";
			this.flp_Box.Size = new System.Drawing.Size(243, 114);
			this.flp_Box.TabIndex = 13;
			// 
			// flp_Cabine
			// 
			this.flp_Cabine.AutoScroll = true;
			this.flp_Cabine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.flp_Cabine.Location = new System.Drawing.Point(487, 165);
			this.flp_Cabine.Name = "flp_Cabine";
			this.flp_Cabine.Size = new System.Drawing.Size(243, 114);
			this.flp_Cabine.TabIndex = 14;
			// 
			// tmr_useAutomata
			// 
			this.tmr_useAutomata.Tick += new System.EventHandler(this.tmr_useAutomata_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.AntiqueWhite;
			this.groupBox1.Controls.Add(this.lbx_Coins);
			this.groupBox1.Controls.Add(this.lbx_Products);
			this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.groupBox1.Location = new System.Drawing.Point(832, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(347, 252);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "MyAutomata";
			// 
			// lbx_Products
			// 
			this.lbx_Products.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbx_Products.FormattingEnabled = true;
			this.lbx_Products.ItemHeight = 18;
			this.lbx_Products.Location = new System.Drawing.Point(6, 20);
			this.lbx_Products.Name = "lbx_Products";
			this.lbx_Products.Size = new System.Drawing.Size(161, 220);
			this.lbx_Products.TabIndex = 0;
			// 
			// lbx_Coins
			// 
			this.lbx_Coins.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbx_Coins.FormattingEnabled = true;
			this.lbx_Coins.ItemHeight = 18;
			this.lbx_Coins.Location = new System.Drawing.Point(180, 19);
			this.lbx_Coins.Name = "lbx_Coins";
			this.lbx_Coins.Size = new System.Drawing.Size(161, 220);
			this.lbx_Coins.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.NavajoWhite;
			this.ClientSize = new System.Drawing.Size(1202, 335);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.flp_Cabine);
			this.Controls.Add(this.flp_Box);
			this.Controls.Add(this.tbx_Tickets);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbx_Fail);
			this.Controls.Add(this.tbx_Leave);
			this.Controls.Add(this.tbx_Cabine);
			this.Controls.Add(this.tbx_Box);
			this.Controls.Add(this.tbx_People);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Stop;
		private System.Windows.Forms.Timer tmr_CreatePerson;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbx_People;
		private System.Windows.Forms.TextBox tbx_Box;
		private System.Windows.Forms.TextBox tbx_Cabine;
		private System.Windows.Forms.TextBox tbx_Leave;
		private System.Windows.Forms.TextBox tbx_Fail;
		private System.Windows.Forms.TextBox tbx_Tickets;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.FlowLayoutPanel flp_Box;
		private System.Windows.Forms.FlowLayoutPanel flp_Cabine;
		private System.Windows.Forms.Timer tmr_useAutomata;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListBox lbx_Products;
		private System.Windows.Forms.ListBox lbx_Coins;
	}
}

