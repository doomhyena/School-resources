namespace Login1
{
    partial class Infok
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
            this.btnKijel = new System.Windows.Forms.Button();
            this.lVez = new System.Windows.Forms.Label();
            this.lKer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lFelh = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lFogl = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vezetélnév:";
            // 
            // btnKijel
            // 
            this.btnKijel.Location = new System.Drawing.Point(29, 125);
            this.btnKijel.Name = "btnKijel";
            this.btnKijel.Size = new System.Drawing.Size(104, 23);
            this.btnKijel.TabIndex = 1;
            this.btnKijel.Text = "Kijelentkezés";
            this.btnKijel.UseVisualStyleBackColor = true;
            this.btnKijel.Click += new System.EventHandler(this.btnKijel_Click);
            // 
            // lVez
            // 
            this.lVez.AutoSize = true;
            this.lVez.Location = new System.Drawing.Point(98, 24);
            this.lVez.Name = "lVez";
            this.lVez.Size = new System.Drawing.Size(35, 13);
            this.lVez.TabIndex = 2;
            this.lVez.Text = "label2";
            // 
            // lKer
            // 
            this.lKer.AutoSize = true;
            this.lKer.Location = new System.Drawing.Point(98, 51);
            this.lKer.Name = "lKer";
            this.lKer.Size = new System.Drawing.Size(35, 13);
            this.lKer.TabIndex = 4;
            this.lKer.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Keresztnév:";
            // 
            // lFelh
            // 
            this.lFelh.AutoSize = true;
            this.lFelh.Location = new System.Drawing.Point(98, 75);
            this.lFelh.Name = "lFelh";
            this.lFelh.Size = new System.Drawing.Size(35, 13);
            this.lFelh.TabIndex = 6;
            this.lFelh.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Felhasználónév:";
            // 
            // lFogl
            // 
            this.lFogl.AutoSize = true;
            this.lFogl.Location = new System.Drawing.Point(98, 98);
            this.lFogl.Name = "lFogl";
            this.lFogl.Size = new System.Drawing.Size(35, 13);
            this.lFogl.TabIndex = 8;
            this.lFogl.Text = "label7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Foglalkozás:";
            // 
            // Infok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 172);
            this.Controls.Add(this.lFogl);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lFelh);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lKer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lVez);
            this.Controls.Add(this.btnKijel);
            this.Controls.Add(this.label1);
            this.Name = "Infok";
            this.Text = "Infok";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnKijel;
        private System.Windows.Forms.Label lVez;
        private System.Windows.Forms.Label lKer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lFelh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lFogl;
        private System.Windows.Forms.Label label8;
    }
}