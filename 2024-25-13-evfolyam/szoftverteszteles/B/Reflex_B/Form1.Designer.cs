namespace Reflex_B
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.pnl_Game = new System.Windows.Forms.Panel();
			this.pnl_Controls = new System.Windows.Forms.Panel();
			this.btn_Start = new System.Windows.Forms.Button();
			this.btn_Click = new System.Windows.Forms.Button();
			this.lbx_Results = new System.Windows.Forms.ListBox();
			this.pnl_Game.SuspendLayout();
			this.pnl_Controls.SuspendLayout();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// pnl_Game
			// 
			this.pnl_Game.BackColor = System.Drawing.SystemColors.ControlLight;
			this.pnl_Game.Controls.Add(this.btn_Click);
			this.pnl_Game.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnl_Game.Location = new System.Drawing.Point(0, 0);
			this.pnl_Game.Name = "pnl_Game";
			this.pnl_Game.Size = new System.Drawing.Size(612, 390);
			this.pnl_Game.TabIndex = 0;
			this.pnl_Game.MouseEnter += new System.EventHandler(this.pnl_Game_MouseEnter);
			this.pnl_Game.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnl_Game_MouseMove);
			// 
			// pnl_Controls
			// 
			this.pnl_Controls.Controls.Add(this.lbx_Results);
			this.pnl_Controls.Controls.Add(this.btn_Start);
			this.pnl_Controls.Dock = System.Windows.Forms.DockStyle.Right;
			this.pnl_Controls.Location = new System.Drawing.Point(612, 0);
			this.pnl_Controls.Name = "pnl_Controls";
			this.pnl_Controls.Size = new System.Drawing.Size(145, 390);
			this.pnl_Controls.TabIndex = 1;
			// 
			// btn_Start
			// 
			this.btn_Start.Location = new System.Drawing.Point(36, 16);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(75, 23);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "Start";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// btn_Click
			// 
			this.btn_Click.BackColor = System.Drawing.Color.Red;
			this.btn_Click.FlatAppearance.BorderSize = 0;
			this.btn_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Click.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Click.Location = new System.Drawing.Point(241, 158);
			this.btn_Click.Name = "btn_Click";
			this.btn_Click.Size = new System.Drawing.Size(70, 70);
			this.btn_Click.TabIndex = 0;
			this.btn_Click.Text = "Click";
			this.btn_Click.UseVisualStyleBackColor = false;
			this.btn_Click.Visible = false;
			this.btn_Click.Click += new System.EventHandler(this.btn_Click_Click);
			// 
			// lbx_Results
			// 
			this.lbx_Results.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
			this.lbx_Results.FormattingEnabled = true;
			this.lbx_Results.Location = new System.Drawing.Point(13, 55);
			this.lbx_Results.Name = "lbx_Results";
			this.lbx_Results.Size = new System.Drawing.Size(120, 316);
			this.lbx_Results.TabIndex = 1;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(757, 390);
			this.Controls.Add(this.pnl_Game);
			this.Controls.Add(this.pnl_Controls);
			this.Name = "Form1";
			this.Text = "Form1";
			this.pnl_Game.ResumeLayout(false);
			this.pnl_Controls.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Panel pnl_Game;
		private System.Windows.Forms.Panel pnl_Controls;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Button btn_Click;
		private System.Windows.Forms.ListBox lbx_Results;
	}
}

