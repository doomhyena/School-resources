
namespace ClickSpeed
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
			this.panel2 = new System.Windows.Forms.Panel();
			this.btn_Start = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btn_Stop = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.btn_Start);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 379);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(792, 100);
			this.panel1.TabIndex = 0;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
			this.panel2.Controls.Add(this.btn_Stop);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(792, 379);
			this.panel2.TabIndex = 1;
			// 
			// btn_Start
			// 
			this.btn_Start.BackColor = System.Drawing.Color.ForestGreen;
			this.btn_Start.FlatAppearance.BorderSize = 0;
			this.btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Start.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Start.ForeColor = System.Drawing.SystemColors.Control;
			this.btn_Start.Location = new System.Drawing.Point(346, 6);
			this.btn_Start.Name = "btn_Start";
			this.btn_Start.Size = new System.Drawing.Size(127, 82);
			this.btn_Start.TabIndex = 0;
			this.btn_Start.Text = "START";
			this.btn_Start.UseVisualStyleBackColor = false;
			this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click);
			this.btn_Start.MouseLeave += new System.EventHandler(this.btn_Start_MouseLeave);
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.label1.Location = new System.Drawing.Point(549, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(231, 45);
			this.label1.TabIndex = 1;
			this.label1.Text = "00:00:00";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btn_Stop
			// 
			this.btn_Stop.BackColor = System.Drawing.Color.ForestGreen;
			this.btn_Stop.FlatAppearance.BorderSize = 0;
			this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_Stop.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btn_Stop.ForeColor = System.Drawing.SystemColors.Control;
			this.btn_Stop.Location = new System.Drawing.Point(333, 96);
			this.btn_Stop.Name = "btn_Stop";
			this.btn_Stop.Size = new System.Drawing.Size(127, 45);
			this.btn_Stop.TabIndex = 2;
			this.btn_Stop.Text = "CLICK";
			this.btn_Stop.UseVisualStyleBackColor = false;
			this.btn_Stop.Visible = false;
			this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(792, 479);
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
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Button btn_Start;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btn_Stop;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}

