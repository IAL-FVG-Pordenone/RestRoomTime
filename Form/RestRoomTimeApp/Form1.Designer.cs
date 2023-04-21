namespace RestRoomTimeApp
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
            label1 = new Label();
            textBoxCerca = new TextBox();
            listBoxClassi = new ListBox();
            comboBoxAlunni = new ComboBox();
            dataGridView1 = new DataGridView();
            labelDebug = new Label();
            buttonAggiorna = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 0;
            label1.Text = "Cerca";
            // 
            // textBoxCerca
            // 
            textBoxCerca.Location = new Point(12, 32);
            textBoxCerca.Name = "textBoxCerca";
            textBoxCerca.Size = new Size(200, 27);
            textBoxCerca.TabIndex = 1;
            textBoxCerca.TextChanged += textBoxCerca_TextChanged;
            // 
            // listBoxClassi
            // 
            listBoxClassi.FormattingEnabled = true;
            listBoxClassi.ItemHeight = 20;
            listBoxClassi.Location = new Point(12, 65);
            listBoxClassi.Name = "listBoxClassi";
            listBoxClassi.Size = new Size(200, 484);
            listBoxClassi.TabIndex = 2;
            listBoxClassi.SelectedIndexChanged += listBoxClassi_SelectedIndexChanged;
            // 
            // comboBoxAlunni
            // 
            comboBoxAlunni.FormattingEnabled = true;
            comboBoxAlunni.Location = new Point(218, 32);
            comboBoxAlunni.Name = "comboBoxAlunni";
            comboBoxAlunni.Size = new Size(200, 28);
            comboBoxAlunni.TabIndex = 3;
            comboBoxAlunni.SelectedIndexChanged += comboBoxAlunni_SelectedIndexChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(218, 66);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(800, 483);
            dataGridView1.TabIndex = 4;
            // 
            // labelDebug
            // 
            labelDebug.AutoSize = true;
            labelDebug.Location = new Point(424, 40);
            labelDebug.Name = "labelDebug";
            labelDebug.Size = new Size(0, 20);
            labelDebug.TabIndex = 5;
            // 
            // buttonAggiorna
            // 
            buttonAggiorna.Location = new Point(924, 30);
            buttonAggiorna.Name = "buttonAggiorna";
            buttonAggiorna.Size = new Size(94, 29);
            buttonAggiorna.TabIndex = 6;
            buttonAggiorna.Text = "Aggiorna";
            buttonAggiorna.UseVisualStyleBackColor = true;
            buttonAggiorna.Click += buttonAggiorna_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 603);
            Controls.Add(buttonAggiorna);
            Controls.Add(labelDebug);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxAlunni);
            Controls.Add(listBoxClassi);
            Controls.Add(textBoxCerca);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxCerca;
        private ListBox listBoxClassi;
        private ComboBox comboBoxAlunni;
        private DataGridView dataGridView1;
        private Label labelDebug;
        private Button buttonAggiorna;
    }
}