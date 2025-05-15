namespace Uszoda
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
			this.personGenTimer = new System.Windows.Forms.Timer(this.components);
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Stop = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.tbx_People = new System.Windows.Forms.TextBox();
			this.tbx_Box = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_Cabine = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tbx_Fail = new System.Windows.Forms.TextBox();
			this.tbx_Cassa = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.tbx_Discount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pnl_Box = new System.Windows.Forms.FlowLayoutPanel();
			this.pnl_Cabine = new System.Windows.Forms.FlowLayoutPanel();
			this.tmr_UseAutomata = new System.Windows.Forms.Timer(this.components);
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbx_CoinsSum = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.tbx_Coin_100 = new System.Windows.Forms.TextBox();
			this.lbl_100 = new System.Windows.Forms.Label();
			this.tbx_Coin_50 = new System.Windows.Forms.TextBox();
			this.lbl_10 = new System.Windows.Forms.Label();
			this.tbx_Coin_200 = new System.Windows.Forms.TextBox();
			this.lblb_200 = new System.Windows.Forms.Label();
			this.tbx_Coin_20 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.tbx_Coin_10 = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.lbx_Products = new System.Windows.Forms.ListBox();
			this.tbx_Coin_5 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// personGenTimer
			// 
			this.personGenTimer.Interval = 1000;
			this.personGenTimer.Tick += new System.EventHandler(this.personGenTimer_Tick);
			// 
			// btn_Start
			// 
			this.btn_Start.FlatAppearance.BorderSize = 0;
			this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Start.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Start.ForeColor = System.Drawing.Color.SeaGreen;
			this.btn_Start.Location = new System.Drawing.Point(13, 3);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(163, 50);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "START";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// btn_Stop
			// 
			this.btn_Stop.FlatAppearance.BorderSize = 0;
			this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Stop.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Stop.ForeColor = System.Drawing.Color.Red;
			this.btn_Stop.Location = new System.Drawing.Point(264, 3);
			this.btn_Stop.Name = "btn_Stop";
			this.btn_Stop.Size = new System.Drawing.Size(163, 50);
			this.btn_Stop.TabIndex = 1;
			this.btn_Stop.Text = "STOP";
			this.btn_Stop.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.panel1.Controls.Add(this.btn_Start);
			this.panel1.Controls.Add(this.btn_Stop);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 334);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(873, 55);
			this.panel1.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(9, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(67, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "People:";
			// 
			// tbx_People
			// 
			this.tbx_People.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_People.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_People.Location = new System.Drawing.Point(127, 19);
			this.tbx_People.Name = "tbx_People";
			this.tbx_People.Size = new System.Drawing.Size(68, 24);
			this.tbx_People.TabIndex = 4;
			this.tbx_People.Text = "0";
			this.tbx_People.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbx_Box
			// 
			this.tbx_Box.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Box.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Box.Location = new System.Drawing.Point(145, 49);
			this.tbx_Box.Name = "tbx_Box";
			this.tbx_Box.Size = new System.Drawing.Size(68, 24);
			this.tbx_Box.TabIndex = 6;
			this.tbx_Box.Text = "0";
			this.tbx_Box.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(27, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "Box:";
			// 
			// tbx_Cabine
			// 
			this.tbx_Cabine.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Cabine.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Cabine.Location = new System.Drawing.Point(145, 79);
			this.tbx_Cabine.Name = "tbx_Cabine";
			this.tbx_Cabine.Size = new System.Drawing.Size(68, 24);
			this.tbx_Cabine.TabIndex = 8;
			this.tbx_Cabine.Text = "0";
			this.tbx_Cabine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(27, 79);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Cabine:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label4.Location = new System.Drawing.Point(9, 114);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(40, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "Fail:";
			// 
			// tbx_Fail
			// 
			this.tbx_Fail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Fail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Fail.Location = new System.Drawing.Point(127, 114);
			this.tbx_Fail.Name = "tbx_Fail";
			this.tbx_Fail.Size = new System.Drawing.Size(68, 24);
			this.tbx_Fail.TabIndex = 10;
			this.tbx_Fail.Text = "0";
			this.tbx_Fail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tbx_Cassa
			// 
			this.tbx_Cassa.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Cassa.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Cassa.Location = new System.Drawing.Point(127, 144);
			this.tbx_Cassa.Name = "tbx_Cassa";
			this.tbx_Cassa.Size = new System.Drawing.Size(68, 24);
			this.tbx_Cassa.TabIndex = 12;
			this.tbx_Cassa.Text = "0";
			this.tbx_Cassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label5.Location = new System.Drawing.Point(9, 144);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(59, 23);
			this.label5.TabIndex = 11;
			this.label5.Text = "Cassa:";
			// 
			// tbx_Discount
			// 
			this.tbx_Discount.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Discount.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Discount.Location = new System.Drawing.Point(127, 177);
			this.tbx_Discount.Name = "tbx_Discount";
			this.tbx_Discount.Size = new System.Drawing.Size(68, 24);
			this.tbx_Discount.TabIndex = 14;
			this.tbx_Discount.Text = "0";
			this.tbx_Discount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label6.Location = new System.Drawing.Point(9, 177);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(83, 23);
			this.label6.TabIndex = 13;
			this.label6.Text = "Discount:";
			// 
			// pnl_Box
			// 
			this.pnl_Box.AutoScroll = true;
			this.pnl_Box.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnl_Box.Location = new System.Drawing.Point(223, 19);
			this.pnl_Box.Name = "pnl_Box";
			this.pnl_Box.Size = new System.Drawing.Size(232, 118);
			this.pnl_Box.TabIndex = 15;
			// 
			// pnl_Cabine
			// 
			this.pnl_Cabine.AutoScroll = true;
			this.pnl_Cabine.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pnl_Cabine.Location = new System.Drawing.Point(223, 144);
			this.pnl_Cabine.Name = "pnl_Cabine";
			this.pnl_Cabine.Size = new System.Drawing.Size(232, 118);
			this.pnl_Cabine.TabIndex = 16;
			// 
			// tmr_UseAutomata
			// 
			this.tmr_UseAutomata.Interval = 2000;
			this.tmr_UseAutomata.Tick += new System.EventHandler(this.tmr_UseAutomata_Tick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbx_CoinsSum);
			this.groupBox1.Controls.Add(this.label10);
			this.groupBox1.Controls.Add(this.tbx_Coin_100);
			this.groupBox1.Controls.Add(this.lbl_100);
			this.groupBox1.Controls.Add(this.tbx_Coin_50);
			this.groupBox1.Controls.Add(this.lbl_10);
			this.groupBox1.Controls.Add(this.tbx_Coin_200);
			this.groupBox1.Controls.Add(this.lblb_200);
			this.groupBox1.Controls.Add(this.tbx_Coin_20);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tbx_Coin_10);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.lbx_Products);
			this.groupBox1.Controls.Add(this.tbx_Coin_5);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.groupBox1.Location = new System.Drawing.Point(546, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(315, 324);
			this.groupBox1.TabIndex = 17;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Automata";
			// 
			// tbx_CoinsSum
			// 
			this.tbx_CoinsSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_CoinsSum.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_CoinsSum.Location = new System.Drawing.Point(164, 298);
			this.tbx_CoinsSum.Name = "tbx_CoinsSum";
			this.tbx_CoinsSum.Size = new System.Drawing.Size(100, 24);
			this.tbx_CoinsSum.TabIndex = 19;
			this.tbx_CoinsSum.Text = "0";
			this.tbx_CoinsSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label10.Location = new System.Drawing.Point(59, 298);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(89, 23);
			this.label10.TabIndex = 18;
			this.label10.Text = "Summary:";
			// 
			// tbx_Coin_100
			// 
			this.tbx_Coin_100.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_100.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_100.Location = new System.Drawing.Point(258, 229);
			this.tbx_Coin_100.Name = "tbx_Coin_100";
			this.tbx_Coin_100.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_100.TabIndex = 17;
			this.tbx_Coin_100.Text = "0";
			this.tbx_Coin_100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_100
			// 
			this.lbl_100.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_100.Location = new System.Drawing.Point(205, 229);
			this.lbl_100.Name = "lbl_100";
			this.lbl_100.Size = new System.Drawing.Size(47, 23);
			this.lbl_100.TabIndex = 16;
			this.lbl_100.Text = "100:";
			this.lbl_100.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbx_Coin_50
			// 
			this.tbx_Coin_50.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_50.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_50.Location = new System.Drawing.Point(258, 198);
			this.tbx_Coin_50.Name = "tbx_Coin_50";
			this.tbx_Coin_50.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_50.TabIndex = 15;
			this.tbx_Coin_50.Text = "0";
			this.tbx_Coin_50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_10
			// 
			this.lbl_10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_10.Location = new System.Drawing.Point(209, 197);
			this.lbl_10.Name = "lbl_10";
			this.lbl_10.Size = new System.Drawing.Size(43, 23);
			this.lbl_10.TabIndex = 14;
			this.lbl_10.Text = "50:";
			this.lbl_10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbx_Coin_200
			// 
			this.tbx_Coin_200.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_200.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_200.Location = new System.Drawing.Point(258, 258);
			this.tbx_Coin_200.Name = "tbx_Coin_200";
			this.tbx_Coin_200.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_200.TabIndex = 13;
			this.tbx_Coin_200.Text = "0";
			this.tbx_Coin_200.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblb_200
			// 
			this.lblb_200.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lblb_200.Location = new System.Drawing.Point(205, 258);
			this.lblb_200.Name = "lblb_200";
			this.lblb_200.Size = new System.Drawing.Size(47, 23);
			this.lblb_200.TabIndex = 12;
			this.lblb_200.Text = "200:";
			this.lblb_200.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbx_Coin_20
			// 
			this.tbx_Coin_20.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_20.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_20.Location = new System.Drawing.Point(47, 259);
			this.tbx_Coin_20.Name = "tbx_Coin_20";
			this.tbx_Coin_20.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_20.TabIndex = 11;
			this.tbx_Coin_20.Text = "0";
			this.tbx_Coin_20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label9
			// 
			this.label9.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label9.Location = new System.Drawing.Point(6, 259);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 23);
			this.label9.TabIndex = 10;
			this.label9.Text = "20:";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbx_Coin_10
			// 
			this.tbx_Coin_10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_10.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_10.Location = new System.Drawing.Point(47, 229);
			this.tbx_Coin_10.Name = "tbx_Coin_10";
			this.tbx_Coin_10.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_10.TabIndex = 9;
			this.tbx_Coin_10.Text = "0";
			this.tbx_Coin_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label8
			// 
			this.label8.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label8.Location = new System.Drawing.Point(6, 229);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(35, 23);
			this.label8.TabIndex = 8;
			this.label8.Text = "10:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lbx_Products
			// 
			this.lbx_Products.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbx_Products.FormattingEnabled = true;
			this.lbx_Products.Location = new System.Drawing.Point(39, 32);
			this.lbx_Products.Name = "lbx_Products";
			this.lbx_Products.Size = new System.Drawing.Size(248, 160);
			this.lbx_Products.TabIndex = 7;
			// 
			// tbx_Coin_5
			// 
			this.tbx_Coin_5.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbx_Coin_5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Coin_5.Location = new System.Drawing.Point(47, 199);
			this.tbx_Coin_5.Name = "tbx_Coin_5";
			this.tbx_Coin_5.Size = new System.Drawing.Size(51, 24);
			this.tbx_Coin_5.TabIndex = 6;
			this.tbx_Coin_5.Text = "0";
			this.tbx_Coin_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label7
			// 
			this.label7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label7.Location = new System.Drawing.Point(6, 199);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 23);
			this.label7.TabIndex = 5;
			this.label7.Text = " 5:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(873, 389);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.pnl_Cabine);
			this.Controls.Add(this.pnl_Box);
			this.Controls.Add(this.tbx_Discount);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.tbx_Cassa);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.tbx_Fail);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.tbx_Cabine);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbx_Box);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbx_People);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Timer personGenTimer;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Stop;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbx_People;
		private System.Windows.Forms.TextBox tbx_Box;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbx_Cabine;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbx_Fail;
		private System.Windows.Forms.TextBox tbx_Cassa;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox tbx_Discount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.FlowLayoutPanel pnl_Box;
		private System.Windows.Forms.FlowLayoutPanel pnl_Cabine;
		private System.Windows.Forms.Timer tmr_UseAutomata;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox tbx_Coin_5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ListBox lbx_Products;
		private System.Windows.Forms.TextBox tbx_Coin_100;
		private System.Windows.Forms.Label lbl_100;
		private System.Windows.Forms.TextBox tbx_Coin_50;
		private System.Windows.Forms.Label lbl_10;
		private System.Windows.Forms.TextBox tbx_Coin_200;
		private System.Windows.Forms.Label lblb_200;
		private System.Windows.Forms.TextBox tbx_Coin_20;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbx_Coin_10;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbx_CoinsSum;
		private System.Windows.Forms.Label label10;
	}
}

