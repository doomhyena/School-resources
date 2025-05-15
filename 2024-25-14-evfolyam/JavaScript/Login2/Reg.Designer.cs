namespace Login2
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
            this.btnReg = new System.Windows.Forms.Button();
            this.btnLoginra = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbJSZ = new System.Windows.Forms.TextBox();
            this.tbFN = new System.Windows.Forms.TextBox();
            this.tbMeger = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(117, 154);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(137, 23);
            this.btnReg.TabIndex = 0;
            this.btnReg.Text = "Regisztráció";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnLoginra
            // 
            this.btnLoginra.Location = new System.Drawing.Point(25, 193);
            this.btnLoginra.Name = "btnLoginra";
            this.btnLoginra.Size = new System.Drawing.Size(229, 23);
            this.btnLoginra.TabIndex = 1;
            this.btnLoginra.Text = "Ugrás a bejelentkezésre";
            this.btnLoginra.UseVisualStyleBackColor = true;
            this.btnLoginra.Click += new System.EventHandler(this.btnLoginra_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Felhasználónév:";
            // 
            // tbJSZ
            // 
            this.tbJSZ.Location = new System.Drawing.Point(154, 69);
            this.tbJSZ.Name = "tbJSZ";
            this.tbJSZ.Size = new System.Drawing.Size(100, 22);
            this.tbJSZ.TabIndex = 3;
            // 
            // tbFN
            // 
            this.tbFN.Location = new System.Drawing.Point(154, 23);
            this.tbFN.Name = "tbFN";
            this.tbFN.Size = new System.Drawing.Size(100, 22);
            this.tbFN.TabIndex = 4;
            // 
            // tbMeger
            // 
            this.tbMeger.Location = new System.Drawing.Point(154, 113);
            this.tbMeger.Name = "tbMeger";
            this.tbMeger.Size = new System.Drawing.Size(100, 22);
            this.tbMeger.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Jelszó megerősítése:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Jelszó:";
            // 
            // Reg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 252);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbMeger);
            this.Controls.Add(this.tbFN);
            this.Controls.Add(this.tbJSZ);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoginra);
            this.Controls.Add(this.btnReg);
            this.Name = "Reg";
            this.Text = "Regisztráció";
            this.Load += new System.EventHandler(this.Reg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnLoginra;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbJSZ;
        private System.Windows.Forms.TextBox tbFN;
        private System.Windows.Forms.TextBox tbMeger;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

