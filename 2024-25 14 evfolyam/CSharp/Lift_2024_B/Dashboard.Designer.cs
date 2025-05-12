namespace Lift_2024_B
{
	partial class Dashboard
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
			this.trb_Levels = new System.Windows.Forms.TrackBar();
			this.lbl_State = new System.Windows.Forms.Label();
			this.lbx_People = new System.Windows.Forms.ListBox();
			((System.ComponentModel.ISupportInitialize)(this.trb_Levels)).BeginInit();
			this.SuspendLayout();
			// 
			// trb_Levels
			// 
			this.trb_Levels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.trb_Levels.Location = new System.Drawing.Point(29, 44);
			this.trb_Levels.Name = "trb_Levels";
			this.trb_Levels.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trb_Levels.Size = new System.Drawing.Size(45, 394);
			this.trb_Levels.TabIndex = 0;
			this.trb_Levels.TickStyle = System.Windows.Forms.TickStyle.Both;
			// 
			// lbl_State
			// 
			this.lbl_State.AutoSize = true;
			this.lbl_State.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.lbl_State.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbl_State.Location = new System.Drawing.Point(8, 14);
			this.lbl_State.Name = "lbl_State";
			this.lbl_State.Size = new System.Drawing.Size(88, 23);
			this.lbl_State.TabIndex = 1;
			this.lbl_State.Text = "-- | 00 | --";
			// 
			// lbx_People
			// 
			this.lbx_People.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.lbx_People.FormattingEnabled = true;
			this.lbx_People.ItemHeight = 36;
			this.lbx_People.Location = new System.Drawing.Point(100, 39);
			this.lbx_People.Name = "lbx_People";
			this.lbx_People.Size = new System.Drawing.Size(246, 400);
			this.lbx_People.TabIndex = 2;
			// 
			// Dashboard
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.lbx_People);
			this.Controls.Add(this.lbl_State);
			this.Controls.Add(this.trb_Levels);
			this.Name = "Dashboard";
			this.Text = "Dashboard";
			((System.ComponentModel.ISupportInitialize)(this.trb_Levels)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TrackBar trb_Levels;
		private System.Windows.Forms.Label lbl_State;
		private System.Windows.Forms.ListBox lbx_People;
	}
}