namespace csontoskincsodolgozatcsharpfroms
{
    partial class SugoForm
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
            buttonVissza = new Button();
            SuspendLayout();
            // 
            // buttonVissza
            // 
            buttonVissza.Location = new Point(13, 9);
            buttonVissza.Name = "buttonVissza";
            buttonVissza.Size = new Size(94, 29);
            buttonVissza.TabIndex = 0;
            buttonVissza.Text = "Bezárás";
            buttonVissza.UseVisualStyleBackColor = true;
            // 
            // SugoForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonVissza);
            Name = "SugoForm";
            Text = "SugoForm";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonVissza;
    }
}