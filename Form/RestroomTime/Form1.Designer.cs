namespace RestroomTime
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
            listBoxClassi = new ListBox();
            textBoxCerca = new TextBox();
            label1 = new Label();
            comboBoxAllievi = new ComboBox();
            label2 = new Label();
            labelDebug = new Label();
            SuspendLayout();
            // 
            // listBoxClassi
            // 
            listBoxClassi.FormattingEnabled = true;
            listBoxClassi.ItemHeight = 15;
            listBoxClassi.Location = new Point(12, 56);
            listBoxClassi.Name = "listBoxClassi";
            listBoxClassi.Size = new Size(202, 379);
            listBoxClassi.TabIndex = 0;
            listBoxClassi.SelectedIndexChanged += listBoxClassi_SelectedIndexChanged;
            // 
            // textBoxCerca
            // 
            textBoxCerca.Location = new Point(12, 27);
            textBoxCerca.Name = "textBoxCerca";
            textBoxCerca.Size = new Size(202, 23);
            textBoxCerca.TabIndex = 1;
            textBoxCerca.TextChanged += textBoxCerca_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 2;
            label1.Text = "Cerca Classe";
            // 
            // comboBoxAllievi
            // 
            comboBoxAllievi.FormattingEnabled = true;
            comboBoxAllievi.Location = new Point(220, 27);
            comboBoxAllievi.Name = "comboBoxAllievi";
            comboBoxAllievi.Size = new Size(221, 23);
            comboBoxAllievi.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(220, 9);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 4;
            label2.Text = "Allievo";
            // 
            // labelDebug
            // 
            labelDebug.AutoSize = true;
            labelDebug.Location = new Point(540, 308);
            labelDebug.Name = "labelDebug";
            labelDebug.Size = new Size(38, 15);
            labelDebug.TabIndex = 5;
            labelDebug.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelDebug);
            Controls.Add(label2);
            Controls.Add(comboBoxAllievi);
            Controls.Add(label1);
            Controls.Add(textBoxCerca);
            Controls.Add(listBoxClassi);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxClassi;
        private TextBox textBoxCerca;
        private Label label1;
        private ComboBox comboBoxAllievi;
        private Label label2;
        private Label labelDebug;
    }
}