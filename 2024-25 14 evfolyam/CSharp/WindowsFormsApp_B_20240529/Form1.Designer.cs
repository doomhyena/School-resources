
namespace WindowsFormsApp_B_20240529
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
			this.chk_Jol = new System.Windows.Forms.CheckBox();
			this.chk_Olcson = new System.Windows.Forms.CheckBox();
			this.chk_Gyorsan = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chk_Jol
			// 
			this.chk_Jol.AutoSize = true;
			this.chk_Jol.Location = new System.Drawing.Point(22, 12);
			this.chk_Jol.Name = "chk_Jol";
			this.chk_Jol.Size = new System.Drawing.Size(39, 17);
			this.chk_Jol.TabIndex = 0;
			this.chk_Jol.Text = "Jól";
			this.chk_Jol.UseVisualStyleBackColor = true;
			this.chk_Jol.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
			// 
			// chk_Olcson
			// 
			this.chk_Olcson.AutoSize = true;
			this.chk_Olcson.Location = new System.Drawing.Point(22, 45);
			this.chk_Olcson.Name = "chk_Olcson";
			this.chk_Olcson.Size = new System.Drawing.Size(59, 17);
			this.chk_Olcson.TabIndex = 1;
			this.chk_Olcson.Text = "Olcsón";
			this.chk_Olcson.UseVisualStyleBackColor = true;
			this.chk_Olcson.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
			// 
			// chk_Gyorsan
			// 
			this.chk_Gyorsan.AutoSize = true;
			this.chk_Gyorsan.Location = new System.Drawing.Point(22, 81);
			this.chk_Gyorsan.Name = "chk_Gyorsan";
			this.chk_Gyorsan.Size = new System.Drawing.Size(65, 17);
			this.chk_Gyorsan.TabIndex = 2;
			this.chk_Gyorsan.Text = "Gyorsan";
			this.chk_Gyorsan.UseVisualStyleBackColor = true;
			this.chk_Gyorsan.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(163, 133);
			this.Controls.Add(this.chk_Gyorsan);
			this.Controls.Add(this.chk_Olcson);
			this.Controls.Add(this.chk_Jol);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chk_Jol;
		private System.Windows.Forms.CheckBox chk_Olcson;
		private System.Windows.Forms.CheckBox chk_Gyorsan;
	}
}

