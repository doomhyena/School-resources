namespace Login2
{
    partial class Bejel
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegre = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbFnev = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbJelszo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(103, 130);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(152, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Bejelentkezés";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegre
            // 
            this.btnRegre.Location = new System.Drawing.Point(103, 164);
            this.btnRegre.Name = "btnRegre";
            this.btnRegre.Size = new System.Drawing.Size(152, 23);
            this.btnRegre.TabIndex = 1;
            this.btnRegre.Text = "Vagy regisztrálj!";
            this.btnRegre.UseVisualStyleBackColor = true;
            this.btnRegre.Click += new System.EventHandler(this.btnRegre_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználónév:";
            // 
            // tbFnev
            // 
            this.tbFnev.Location = new System.Drawing.Point(155, 46);
            this.tbFnev.Name = "tbFnev";
            this.tbFnev.Size = new System.Drawing.Size(100, 22);
            this.tbFnev.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Jelszó:";
            // 
            // tbJelszo
            // 
            this.tbJelszo.Location = new System.Drawing.Point(155, 86);
            this.tbJelszo.Name = "tbJelszo";
            this.tbJelszo.Size = new System.Drawing.Size(100, 22);
            this.tbJelszo.TabIndex = 5;
            // 
            // Bejel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 235);
            this.Controls.Add(this.tbJelszo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbFnev);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRegre);
            this.Controls.Add(this.btnLogin);
            this.Name = "Bejel";
            this.Text = "Bejelentkezés";
            this.Load += new System.EventHandler(this.Bejel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnRegre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFnev;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbJelszo;
    }
}