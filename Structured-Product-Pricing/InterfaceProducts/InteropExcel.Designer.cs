namespace InterfaceProducts
{
    partial class InteropExcel
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
            panel1 = new Panel();
            panel2 = new Panel();
            radioButtonFile = new RadioButton();
            labelFile = new Label();
            radioButtonDefault = new RadioButton();
            buttonPrice = new Button();
            label1 = new Label();
            browseFolder = new FolderBrowserDialog();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Moccasin;
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(buttonPrice);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(4, 1);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(784, 357);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioButtonFile);
            panel2.Controls.Add(labelFile);
            panel2.Controls.Add(radioButtonDefault);
            panel2.Location = new Point(15, 93);
            panel2.Name = "panel2";
            panel2.Size = new Size(755, 125);
            panel2.TabIndex = 5;
            // 
            // radioButtonFile
            // 
            radioButtonFile.AutoSize = true;
            radioButtonFile.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonFile.Location = new Point(68, 59);
            radioButtonFile.Name = "radioButtonFile";
            radioButtonFile.Size = new Size(131, 32);
            radioButtonFile.TabIndex = 1;
            radioButtonFile.TabStop = true;
            radioButtonFile.Text = "Select a file";
            radioButtonFile.UseVisualStyleBackColor = true;
            radioButtonFile.CheckedChanged += radioButtonFile_CheckedChanged;
            // 
            // labelFile
            // 
            labelFile.AutoSize = true;
            labelFile.BackColor = SystemColors.ButtonHighlight;
            labelFile.Enabled = false;
            labelFile.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            labelFile.Location = new Point(205, 68);
            labelFile.Name = "labelFile";
            labelFile.Size = new Size(26, 17);
            labelFile.TabIndex = 4;
            labelFile.Text = "File";
            // 
            // radioButtonDefault
            // 
            radioButtonDefault.AutoSize = true;
            radioButtonDefault.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            radioButtonDefault.Location = new Point(68, 21);
            radioButtonDefault.Name = "radioButtonDefault";
            radioButtonDefault.Size = new Size(377, 32);
            radioButtonDefault.TabIndex = 0;
            radioButtonDefault.TabStop = true;
            radioButtonDefault.Text = "Use default file (Recommended for test)";
            radioButtonDefault.UseVisualStyleBackColor = true;
            radioButtonDefault.CheckedChanged += radioButtonDefault_CheckedChanged;
            // 
            // buttonPrice
            // 
            buttonPrice.AllowDrop = true;
            buttonPrice.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            buttonPrice.BackColor = Color.Gold;
            buttonPrice.Font = new Font("Segoe UI", 15F);
            buttonPrice.Location = new Point(272, 249);
            buttonPrice.Margin = new Padding(2);
            buttonPrice.Name = "buttonPrice";
            buttonPrice.Size = new Size(188, 46);
            buttonPrice.TabIndex = 1;
            buttonPrice.Text = "Price batch";
            buttonPrice.UseVisualStyleBackColor = false;
            buttonPrice.Click += buttonPrice_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(248, 23);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(298, 54);
            label1.TabIndex = 0;
            label1.Text = "Excel Interface";
            // 
            // InteropExcel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 361);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "InteropExcel";
            Text = "InteropExcel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button buttonPrice;
        private FolderBrowserDialog browseFolder;
        private Label labelFile;
        private Panel panel2;
        private RadioButton radioButtonFile;
        private RadioButton radioButtonDefault;
    }
}