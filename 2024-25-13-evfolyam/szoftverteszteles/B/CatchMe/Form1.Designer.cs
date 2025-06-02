namespace CatchMe
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
			this.btn_Start = new System.Windows.Forms.Button();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btn_Escape = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.panel1.Controls.Add(this.btn_Start);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 387);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(842, 46);
			this.panel1.TabIndex = 0;
			// 
			// btn_Start
			// 
			this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_Start.Location = new System.Drawing.Point(755, 11);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(75, 23);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "Start";
			this.btn_Start.UseVisualStyleBackColor = true;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panel2.Controls.Add(this.btn_Escape);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(842, 387);
			this.panel2.TabIndex = 1;
			this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
			// 
			// btn_Escape
			// 
			this.btn_Escape.BackColor = System.Drawing.Color.Orange;
			this.btn_Escape.FlatAppearance.BorderSize = 0;
			this.btn_Escape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Escape.Location = new System.Drawing.Point(384, 160);
			this.btn_Escape.Name = "btn_Escape";
			this.btn_Escape.Size = new System.Drawing.Size(51, 38);
			this.btn_Escape.TabIndex = 0;
			this.btn_Escape.Text = "Catch Me";
			this.btn_Escape.UseVisualStyleBackColor = false;
			this.btn_Escape.Visible = false;
			this.btn_Escape.Click += new System.EventHandler(this.btn_Escape_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(842, 433);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btn_Escape;
	}
}

