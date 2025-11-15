namespace Login1
{
    partial class Reg
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
            this.btnReg = new System.Windows.Forms.Button();
            this.tbVez = new System.Windows.Forms.TextBox();
            this.tbKer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFelh = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFogl = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbJsz = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vezetéknév:";
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(91, 129);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(100, 23);
            this.btnReg.TabIndex = 1;
            this.btnReg.Text = "Regisztráció";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tbVez
            // 
            this.tbVez.Location = new System.Drawing.Point(91, 2);
            this.tbVez.Name = "tbVez";
            this.tbVez.Size = new System.Drawing.Size(100, 20);
            this.tbVez.TabIndex = 2;
            // 
            // tbKer
            // 
            this.tbKer.Location = new System.Drawing.Point(91, 25);
            this.tbKer.Name = "tbKer";
            this.tbKer.Size = new System.Drawing.Size(100, 20);
            this.tbKer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Keresztnév:";
            // 
            // tbFelh
            // 
            this.tbFelh.Location = new System.Drawing.Point(91, 51);
            this.tbFelh.Name = "tbFelh";
            this.tbFelh.Size = new System.Drawing.Size(100, 20);
            this.tbFelh.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Felhasználónév:";
            // 
            // tbFogl
            // 
            this.tbFogl.Location = new System.Drawing.Point(91, 77);
            this.tbFogl.Name = "tbFogl";
            this.tbFogl.Size = new System.Drawing.Size(100, 20);
            this.tbFogl.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Foglalkozás:";
            // 
            // tbJsz
            // 
            this.tbJsz.Location = new System.Drawing.Point(91, 103);
            this.tbJsz.Name = "tbJsz";
            this.tbJsz.Size = new System.Drawing.Size(100, 20);
            this.tbJsz.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Jelszó:";
            // 
            // btnAt
            // 
            this.btnAt.Location = new System.Drawing.Point(11, 158);
            this.btnAt.Name = "btnAt";
            this.btnAt.Size = new System.Drawing.Size(180, 23);
            this.btnAt.TabIndex = 11;
            this.btnAt.Text = "Át a bejelentkezéshez";
            this.btnAt.UseVisualStyleBackColor = true;
            this.btnAt.Click += new System.EventHandler(this.btnAt_Click);
            // 
            // Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 198);
            this.Controls.Add(this.btnAt);
            this.Controls.Add(this.tbJsz);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbFogl);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbFelh);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbKer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbVez);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.label1);
            this.Name = "Reg";
            this.Text = "Regisztráció";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TextBox tbVez;
        private System.Windows.Forms.TextBox tbKer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFelh;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFogl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbJsz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAt;
    }
}

