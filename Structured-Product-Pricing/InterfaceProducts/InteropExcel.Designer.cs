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
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
            button1 = new Button();
            label1 = new Label();
            browseFolder = new FolderBrowserDialog();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Moccasin;
            panel1.Controls.Add(checkBox2);
            panel1.Controls.Add(checkBox1);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(144, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(1185, 568);
            panel1.TabIndex = 0;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(480, 305);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(183, 41);
            checkBox2.TabIndex = 3;
            checkBox2.Text = "Select a file";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(337, 225);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(517, 41);
            checkBox1.TabIndex = 2;
            checkBox1.Text = "Use default file (Recommended for test)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.AllowDrop = true;
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.Gold;
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(392, 413);
            button1.Name = "button1";
            button1.Size = new Size(353, 85);
            button1.TabIndex = 1;
            button1.Text = "Price batch";
            button1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            label1.Location = new Point(337, 41);
            label1.Name = "label1";
            label1.Size = new Size(537, 96);
            label1.TabIndex = 0;
            label1.Text = "Excel Interface";
            // 
            // InteropExcel
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 668);
            Controls.Add(panel1);
            Name = "InteropExcel";
            Text = "InteropExcel";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private CheckBox checkBox2;
        private CheckBox checkBox1;
        private Button button1;
        private FolderBrowserDialog browseFolder;
    }
}