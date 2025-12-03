namespace Porject_13
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            username = new TextBox();
            loginbtn = new Button();
            pass = new TextBox();
            regfrom = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // username
            // 
            username.Location = new Point(12, 41);
            username.Name = "username";
            username.Size = new Size(125, 27);
            username.TabIndex = 0;
            username.Text = "Felhasználónév";
            username.TextChanged += textBox1_TextChanged;
            // 
            // loginbtn
            // 
            loginbtn.Location = new Point(12, 134);
            loginbtn.Name = "loginbtn";
            loginbtn.Size = new Size(125, 29);
            loginbtn.TabIndex = 1;
            loginbtn.Text = "Bejelentkezés";
            loginbtn.UseVisualStyleBackColor = true;
            // 
            // pass
            // 
            pass.Location = new Point(12, 74);
            pass.Name = "pass";
            pass.Size = new Size(125, 27);
            pass.TabIndex = 2;
            pass.Text = "Jelszó";
            // 
            // regfrom
            // 
            regfrom.Location = new Point(12, 169);
            regfrom.Name = "regfrom";
            regfrom.Size = new Size(125, 29);
            regfrom.TabIndex = 3;
            regfrom.Text = "Regisztáció";
            regfrom.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 9);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 4;
            label1.Text = "Bejelentkezés";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(regfrom);
            Controls.Add(pass);
            Controls.Add(loginbtn);
            Controls.Add(username);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox username;
        private Button loginbtn;
        private TextBox pass;
        private Button regfrom;
        private Label label1;
    }
}
