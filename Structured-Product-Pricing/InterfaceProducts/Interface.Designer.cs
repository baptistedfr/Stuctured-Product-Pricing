namespace InterfaceProducts
{
    partial class Interface
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
            price = new Button();
            comboBoxOptions = new ComboBox();
            label1 = new Label();
            textBoxVolatility = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBoxSpot = new TextBox();
            textBoxRf = new TextBox();
            textBoxStrike1 = new TextBox();
            textBoxStrike3 = new TextBox();
            textBoxStrike4 = new TextBox();
            textBoxStrike2 = new TextBox();
            labelStrike1 = new Label();
            labelStrike2 = new Label();
            labelStrike3 = new Label();
            labelStrike4 = new Label();
            textBoxMaturity = new TextBox();
            labelMaturity = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // price
            // 
            price.BackColor = SystemColors.Info;
            price.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.Location = new Point(23, 350);
            price.Name = "price";
            price.Size = new Size(173, 51);
            price.TabIndex = 0;
            price.Text = "Price";
            price.UseVisualStyleBackColor = false;
            price.Click += price_Click;
            // 
            // comboBoxOptions
            // 
            comboBoxOptions.AccessibleRole = AccessibleRole.ScrollBar;
            comboBoxOptions.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxOptions.BackColor = Color.Moccasin;
            comboBoxOptions.ForeColor = Color.Black;
            comboBoxOptions.FormattingEnabled = true;
            comboBoxOptions.Items.AddRange(new object[] { "Call Option", "Put Option", "Call Spread", "Put Spread", "Butterfly Spread", "Condor Spread", "Straddle", "Stangle", "Strip", "Strap" });
            comboBoxOptions.Location = new Point(234, 20);
            comboBoxOptions.Name = "comboBoxOptions";
            comboBoxOptions.Size = new Size(253, 31);
            comboBoxOptions.TabIndex = 1;
            comboBoxOptions.Text = "Call Option";
            comboBoxOptions.SelectedIndexChanged += comboBoxOptions_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(572, 9);
            label1.Name = "label1";
            label1.Size = new Size(137, 48);
            label1.TabIndex = 3;
            label1.Text = "Market";
            // 
            // textBoxVolatility
            // 
            textBoxVolatility.Location = new Point(925, 53);
            textBoxVolatility.Name = "textBoxVolatility";
            textBoxVolatility.Size = new Size(125, 30);
            textBoxVolatility.TabIndex = 4;
            textBoxVolatility.Text = "20,5";
            textBoxVolatility.TextAlign = HorizontalAlignment.Center;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(944, 9);
            label2.Name = "label2";
            label2.Size = new Size(101, 23);
            label2.TabIndex = 5;
            label2.Text = "Volatilté (%)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(1101, 9);
            label3.Name = "label3";
            label3.Size = new Size(162, 23);
            label3.TabIndex = 6;
            label3.Text = "Taux sans risque (%)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(792, 9);
            label4.Name = "label4";
            label4.Size = new Size(45, 23);
            label4.TabIndex = 7;
            label4.Text = "Spot";
            // 
            // textBoxSpot
            // 
            textBoxSpot.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxSpot.Location = new Point(757, 53);
            textBoxSpot.Name = "textBoxSpot";
            textBoxSpot.Size = new Size(125, 31);
            textBoxSpot.TabIndex = 8;
            textBoxSpot.Text = "100";
            textBoxSpot.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxRf
            // 
            textBoxRf.Location = new Point(1113, 53);
            textBoxRf.Name = "textBoxRf";
            textBoxRf.Size = new Size(125, 30);
            textBoxRf.TabIndex = 9;
            textBoxRf.Text = "5,0";
            textBoxRf.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxStrike1
            // 
            textBoxStrike1.Location = new Point(25, 102);
            textBoxStrike1.Name = "textBoxStrike1";
            textBoxStrike1.Size = new Size(93, 30);
            textBoxStrike1.TabIndex = 10;
            textBoxStrike1.Visible = false;
            // 
            // textBoxStrike3
            // 
            textBoxStrike3.Location = new Point(279, 102);
            textBoxStrike3.Name = "textBoxStrike3";
            textBoxStrike3.Size = new Size(93, 30);
            textBoxStrike3.TabIndex = 11;
            textBoxStrike3.Visible = false;
            // 
            // textBoxStrike4
            // 
            textBoxStrike4.Location = new Point(414, 102);
            textBoxStrike4.Name = "textBoxStrike4";
            textBoxStrike4.Size = new Size(92, 30);
            textBoxStrike4.TabIndex = 12;
            textBoxStrike4.Visible = false;
            // 
            // textBoxStrike2
            // 
            textBoxStrike2.Location = new Point(156, 102);
            textBoxStrike2.Name = "textBoxStrike2";
            textBoxStrike2.Size = new Size(93, 30);
            textBoxStrike2.TabIndex = 13;
            textBoxStrike2.Visible = false;
            // 
            // labelStrike1
            // 
            labelStrike1.AutoSize = true;
            labelStrike1.Location = new Point(45, 76);
            labelStrike1.Name = "labelStrike1";
            labelStrike1.Size = new Size(65, 23);
            labelStrike1.TabIndex = 14;
            labelStrike1.Text = "Strike 1";
            labelStrike1.TextAlign = ContentAlignment.MiddleCenter;
            labelStrike1.Visible = false;
            // 
            // labelStrike2
            // 
            labelStrike2.AutoSize = true;
            labelStrike2.Location = new Point(175, 76);
            labelStrike2.Name = "labelStrike2";
            labelStrike2.Size = new Size(65, 23);
            labelStrike2.TabIndex = 15;
            labelStrike2.Text = "Strike 2";
            labelStrike2.Visible = false;
            // 
            // labelStrike3
            // 
            labelStrike3.AutoSize = true;
            labelStrike3.Location = new Point(292, 76);
            labelStrike3.Name = "labelStrike3";
            labelStrike3.Size = new Size(65, 23);
            labelStrike3.TabIndex = 16;
            labelStrike3.Text = "Strike 3";
            labelStrike3.Visible = false;
            // 
            // labelStrike4
            // 
            labelStrike4.AutoSize = true;
            labelStrike4.Location = new Point(428, 76);
            labelStrike4.Name = "labelStrike4";
            labelStrike4.Size = new Size(65, 23);
            labelStrike4.TabIndex = 17;
            labelStrike4.Text = "Strike 4";
            labelStrike4.Visible = false;
            // 
            // textBoxMaturity
            // 
            textBoxMaturity.Location = new Point(23, 183);
            textBoxMaturity.Name = "textBoxMaturity";
            textBoxMaturity.Size = new Size(95, 30);
            textBoxMaturity.TabIndex = 18;
            // 
            // labelMaturity
            // 
            labelMaturity.AutoSize = true;
            labelMaturity.Location = new Point(35, 157);
            labelMaturity.Name = "labelMaturity";
            labelMaturity.Size = new Size(75, 23);
            labelMaturity.TabIndex = 19;
            labelMaturity.Text = "Maturité";
            labelMaturity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(38, 9);
            label5.Name = "label5";
            label5.Size = new Size(143, 48);
            label5.TabIndex = 20;
            label5.Text = "Produit";
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(1504, 835);
            Controls.Add(label5);
            Controls.Add(labelMaturity);
            Controls.Add(textBoxMaturity);
            Controls.Add(labelStrike4);
            Controls.Add(labelStrike3);
            Controls.Add(labelStrike2);
            Controls.Add(labelStrike1);
            Controls.Add(textBoxStrike2);
            Controls.Add(textBoxStrike4);
            Controls.Add(textBoxStrike3);
            Controls.Add(textBoxStrike1);
            Controls.Add(textBoxRf);
            Controls.Add(textBoxSpot);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBoxVolatility);
            Controls.Add(label1);
            Controls.Add(comboBoxOptions);
            Controls.Add(price);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Interface";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button price;
        private ComboBox comboBoxOptions;
        private Label label1;
        private TextBox textBoxVolatility;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBoxSpot;
        private TextBox textBoxRf;
        private TextBox textBoxStrike1;
        private TextBox textBoxStrike3;
        private TextBox textBoxStrike4;
        private TextBox textBoxStrike2;
        private Label labelStrike1;
        private Label labelStrike2;
        private Label labelStrike3;
        private Label labelStrike4;
        private TextBox textBoxMaturity;
        private Label labelMaturity;
        private Label label5;
    }
}
