namespace csontoskincsodolgozatcsharpfroms
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
            textBoxTantargy = new TextBox();
            textBoxTemakor = new TextBox();
            textBoxMaxPontszam = new TextBox();
            textBoxAtlag = new TextBox();
            buttonTorlodes = new Button();
            buttonSugo = new Button();
            buttonBezaro = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            listBoxFelvittAdatok = new ListBox();
            labelDatum = new Label();
            labelFelvittSorokSzama = new Label();
            SuspendLayout();
            // 
            // textBoxTantargy
            // 
            textBoxTantargy.Location = new Point(12, 32);
            textBoxTantargy.Name = "textBoxTantargy";
            textBoxTantargy.PlaceholderText = "Tantárgy neve";
            textBoxTantargy.Size = new Size(125, 27);
            textBoxTantargy.TabIndex = 0;
            // 
            // textBoxTemakor
            // 
            textBoxTemakor.Location = new Point(12, 101);
            textBoxTemakor.Name = "textBoxTemakor";
            textBoxTemakor.PlaceholderText = "Témakör neve";
            textBoxTemakor.Size = new Size(125, 27);
            textBoxTemakor.TabIndex = 1;
            // 
            // textBoxMaxPontszam
            // 
            textBoxMaxPontszam.Location = new Point(12, 168);
            textBoxMaxPontszam.Name = "textBoxMaxPontszam";
            textBoxMaxPontszam.PlaceholderText = "Max Pontszámod";
            textBoxMaxPontszam.Size = new Size(125, 27);
            textBoxMaxPontszam.TabIndex = 2;
            // 
            // textBoxAtlag
            // 
            textBoxAtlag.Location = new Point(12, 235);
            textBoxAtlag.Name = "textBoxAtlag";
            textBoxAtlag.PlaceholderText = "Átlagod";
            textBoxAtlag.Size = new Size(125, 27);
            textBoxAtlag.TabIndex = 3;
            // 
            // buttonTorlodes
            // 
            buttonTorlodes.Location = new Point(12, 281);
            buttonTorlodes.Name = "buttonTorlodes";
            buttonTorlodes.Size = new Size(94, 29);
            buttonTorlodes.TabIndex = 4;
            buttonTorlodes.Text = "Törlés";
            buttonTorlodes.UseVisualStyleBackColor = true;
            // 
            // buttonSugo
            // 
            buttonSugo.Location = new Point(131, 281);
            buttonSugo.Name = "buttonSugo";
            buttonSugo.Size = new Size(94, 29);
            buttonSugo.TabIndex = 5;
            buttonSugo.Text = "Súgó";
            buttonSugo.UseVisualStyleBackColor = true;
            // 
            // buttonBezaro
            // 
            buttonBezaro.Location = new Point(249, 281);
            buttonBezaro.Name = "buttonBezaro";
            buttonBezaro.Size = new Size(94, 29);
            buttonBezaro.TabIndex = 6;
            buttonBezaro.Text = "Törlés";
            buttonBezaro.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 7;
            label1.Text = "Tarntárgy:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 8;
            label2.Text = "Témakör: ";
            label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 145);
            label3.Name = "label3";
            label3.Size = new Size(107, 20);
            label3.TabIndex = 9;
            label3.Text = "Max Pontszám:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 212);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 10;
            label4.Text = "Átlag:";
            // 
            // listBoxFelvittAdatok
            // 
            listBoxFelvittAdatok.FormattingEnabled = true;
            listBoxFelvittAdatok.Location = new Point(163, 32);
            listBoxFelvittAdatok.Name = "listBoxFelvittAdatok";
            listBoxFelvittAdatok.Size = new Size(150, 104);
            listBoxFelvittAdatok.TabIndex = 11;
            listBoxFelvittAdatok.SelectedIndexChanged += listBoxFelvittAdatok_SelectedIndexChanged;
            // 
            // labelDatum
            // 
            labelDatum.AutoSize = true;
            labelDatum.Location = new Point(700, 9);
            labelDatum.Name = "labelDatum";
            labelDatum.Size = new Size(54, 20);
            labelDatum.TabIndex = 12;
            labelDatum.Text = "Dátum";
            // 
            // labelFelvittSorokSzama
            // 
            labelFelvittSorokSzama.AutoSize = true;
            labelFelvittSorokSzama.Location = new Point(163, 9);
            labelFelvittSorokSzama.Name = "labelFelvittSorokSzama";
            labelFelvittSorokSzama.Size = new Size(137, 20);
            labelFelvittSorokSzama.TabIndex = 13;
            labelFelvittSorokSzama.Text = "Felvitt Sorok száma";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelFelvittSorokSzama);
            Controls.Add(labelDatum);
            Controls.Add(listBoxFelvittAdatok);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonBezaro);
            Controls.Add(buttonSugo);
            Controls.Add(buttonTorlodes);
            Controls.Add(textBoxAtlag);
            Controls.Add(textBoxMaxPontszam);
            Controls.Add(textBoxTemakor);
            Controls.Add(textBoxTantargy);
            Name = "Form1";
            RightToLeftLayout = true;
            Text = "Tantárgy";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxTantargy;
        private TextBox textBoxTemakor;
        private TextBox textBoxMaxPontszam;
        private TextBox textBoxAtlag;
        private Button buttonTorlodes;
        private Button buttonSugo;
        private Button buttonBezaro;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ListBox listBoxFelvittAdatok;
        private Label labelDatum;
        private Label labelFelvittSorokSzama;
    }
}
