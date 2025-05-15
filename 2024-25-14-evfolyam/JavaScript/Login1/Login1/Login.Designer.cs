namespace Login1
{
    partial class Login
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
            this.tbFNEV = new System.Windows.Forms.TextBox();
            this.btnBejel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRegRe = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbJSZ = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // tbFNEV
            // 
            this.tbFNEV.Location = new System.Drawing.Point(102, 21);
            this.tbFNEV.Name = "tbFNEV";
            this.tbFNEV.Size = new System.Drawing.Size(100, 20);
            this.tbFNEV.TabIndex = 0;
            // 
            // btnBejel
            // 
            this.btnBejel.Location = new System.Drawing.Point(102, 73);
            this.btnBejel.Name = "btnBejel";
            this.btnBejel.Size = new System.Drawing.Size(100, 23);
            this.btnBejel.TabIndex = 1;
            this.btnBejel.Text = "Bejelentkezés";
            this.btnBejel.UseVisualStyleBackColor = true;
            this.btnBejel.Click += new System.EventHandler(this.btnBejel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználónév:";
            // 
            // btnRegRe
            // 
            this.btnRegRe.Location = new System.Drawing.Point(15, 102);
            this.btnRegRe.Name = "btnRegRe";
            this.btnRegRe.Size = new System.Drawing.Size(187, 23);
            this.btnRegRe.TabIndex = 3;
            this.btnRegRe.Text = "Ugrás a regisztrációra";
            this.btnRegRe.UseVisualStyleBackColor = true;
            this.btnRegRe.Click += new System.EventHandler(this.btnRegRe_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Jelszó:";
            // 
            // tbJSZ
            // 
            this.tbJSZ.Location = new System.Drawing.Point(102, 47);
            this.tbJSZ.Name = "tbJSZ";
            this.tbJSZ.Size = new System.Drawing.Size(100, 20);
            this.tbJSZ.TabIndex = 6;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 151);
            this.Controls.Add(this.tbJSZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnRegRe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBejel);
            this.Controls.Add(this.tbFNEV);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFNEV;
        private System.Windows.Forms.Button btnBejel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegRe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJSZ;
    }
}