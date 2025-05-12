namespace Lift_2024_A
{
	partial class Display
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
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.tbx_Sum = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.tbx_Ele = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.tbx_Leave = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.trackBar1.BackColor = System.Drawing.SystemColors.Control;
			this.trackBar1.Location = new System.Drawing.Point(12, 12);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(45, 403);
			this.trackBar1.TabIndex = 0;
			this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// tbx_Sum
			// 
			this.tbx_Sum.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Sum.Location = new System.Drawing.Point(282, 24);
			this.tbx_Sum.Name = "tbx_Sum";
			this.tbx_Sum.Size = new System.Drawing.Size(100, 27);
			this.tbx_Sum.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(148, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(115, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "Összes személy:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label2.Location = new System.Drawing.Point(148, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "Liftben:";
			// 
			// tbx_Ele
			// 
			this.tbx_Ele.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Ele.Location = new System.Drawing.Point(282, 70);
			this.tbx_Ele.Name = "tbx_Ele";
			this.tbx_Ele.Size = new System.Drawing.Size(100, 27);
			this.tbx_Ele.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label3.Location = new System.Drawing.Point(148, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(67, 19);
			this.label3.TabIndex = 6;
			this.label3.Text = "Távozott:";
			// 
			// tbx_Leave
			// 
			this.tbx_Leave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.tbx_Leave.Location = new System.Drawing.Point(282, 115);
			this.tbx_Leave.Name = "tbx_Leave";
			this.tbx_Leave.Size = new System.Drawing.Size(100, 27);
			this.tbx_Leave.TabIndex = 5;
			// 
			// Display
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 427);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbx_Leave);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tbx_Ele);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.tbx_Sum);
			this.Controls.Add(this.trackBar1);
			this.Name = "Display";
			this.Text = "Display";
			this.Load += new System.EventHandler(this.Display_Load);
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TextBox tbx_Sum;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbx_Ele;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbx_Leave;
	}
}