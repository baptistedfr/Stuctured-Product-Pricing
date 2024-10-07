namespace InterfaceProducts
{
    partial class StructuredProducts
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
            groupBoxMarket = new GroupBox();
            panel2 = new Panel();
            radioButtonVolSVI = new RadioButton();
            radioButtonVolSto = new RadioButton();
            radioButtonVolCste = new RadioButton();
            panel1 = new Panel();
            radioButtonManual = new RadioButton();
            radioButtonAuto = new RadioButton();
            label1 = new Label();
            textBoxSpot = new TextBox();
            labelSpot = new Label();
            textBoxVolatility = new TextBox();
            labelVol = new Label();
            labelRf = new Label();
            textBoxRf = new TextBox();
            groupBoxMarket.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxMarket
            // 
            groupBoxMarket.BackColor = Color.AntiqueWhite;
            groupBoxMarket.Controls.Add(panel2);
            groupBoxMarket.Controls.Add(panel1);
            groupBoxMarket.Controls.Add(label1);
            groupBoxMarket.Controls.Add(textBoxSpot);
            groupBoxMarket.Controls.Add(labelSpot);
            groupBoxMarket.Controls.Add(textBoxVolatility);
            groupBoxMarket.Controls.Add(labelVol);
            groupBoxMarket.Controls.Add(labelRf);
            groupBoxMarket.Controls.Add(textBoxRf);
            groupBoxMarket.Location = new Point(23, 12);
            groupBoxMarket.Name = "groupBoxMarket";
            groupBoxMarket.Size = new Size(570, 268);
            groupBoxMarket.TabIndex = 27;
            groupBoxMarket.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(radioButtonVolSVI);
            panel2.Controls.Add(radioButtonVolSto);
            panel2.Controls.Add(radioButtonVolCste);
            panel2.Location = new Point(14, 97);
            panel2.Name = "panel2";
            panel2.Size = new Size(502, 36);
            panel2.TabIndex = 12;
            // 
            // radioButtonVolSVI
            // 
            radioButtonVolSVI.AutoSize = true;
            radioButtonVolSVI.Location = new Point(205, 3);
            radioButtonVolSVI.Name = "radioButtonVolSVI";
            radioButtonVolSVI.Size = new Size(76, 24);
            radioButtonVolSVI.TabIndex = 13;
            radioButtonVolSVI.TabStop = true;
            radioButtonVolSVI.Text = "Vol SVI";
            radioButtonVolSVI.UseVisualStyleBackColor = true;
            // 
            // radioButtonVolSto
            // 
            radioButtonVolSto.AutoSize = true;
            radioButtonVolSto.Location = new Point(338, 3);
            radioButtonVolSto.Name = "radioButtonVolSto";
            radioButtonVolSto.Size = new Size(140, 24);
            radioButtonVolSto.TabIndex = 12;
            radioButtonVolSto.TabStop = true;
            radioButtonVolSto.Text = "Vol Stochastique";
            radioButtonVolSto.UseVisualStyleBackColor = true;
            // 
            // radioButtonVolCste
            // 
            radioButtonVolCste.AutoSize = true;
            radioButtonVolCste.Location = new Point(14, 3);
            radioButtonVolCste.Name = "radioButtonVolCste";
            radioButtonVolCste.Size = new Size(121, 24);
            radioButtonVolCste.TabIndex = 11;
            radioButtonVolCste.Text = "Vol Constante";
            radioButtonVolCste.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(radioButtonManual);
            panel1.Controls.Add(radioButtonAuto);
            panel1.Location = new Point(172, 17);
            panel1.Name = "panel1";
            panel1.Size = new Size(198, 71);
            panel1.TabIndex = 10;
            // 
            // radioButtonManual
            // 
            radioButtonManual.AutoSize = true;
            radioButtonManual.Location = new Point(14, 41);
            radioButtonManual.Name = "radioButtonManual";
            radioButtonManual.Size = new Size(154, 24);
            radioButtonManual.TabIndex = 1;
            radioButtonManual.Text = "Marché sur mesure";
            radioButtonManual.UseVisualStyleBackColor = true;
            // 
            // radioButtonAuto
            // 
            radioButtonAuto.AutoSize = true;
            radioButtonAuto.Location = new Point(14, 3);
            radioButtonAuto.Name = "radioButtonAuto";
            radioButtonAuto.Size = new Size(134, 24);
            radioButtonAuto.TabIndex = 0;
            radioButtonAuto.Text = "Marché existant";
            radioButtonAuto.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(6, 17);
            label1.Name = "label1";
            label1.Size = new Size(160, 56);
            label1.TabIndex = 3;
            label1.Text = "Market";
            // 
            // textBoxSpot
            // 
            textBoxSpot.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxSpot.Location = new Point(14, 203);
            textBoxSpot.Name = "textBoxSpot";
            textBoxSpot.Size = new Size(125, 34);
            textBoxSpot.TabIndex = 8;
            textBoxSpot.Text = "100";
            textBoxSpot.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSpot
            // 
            labelSpot.AutoSize = true;
            labelSpot.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelSpot.Location = new Point(45, 154);
            labelSpot.Name = "labelSpot";
            labelSpot.Size = new Size(61, 31);
            labelSpot.TabIndex = 7;
            labelSpot.Text = "Spot";
            // 
            // textBoxVolatility
            // 
            textBoxVolatility.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxVolatility.Location = new Point(194, 203);
            textBoxVolatility.Name = "textBoxVolatility";
            textBoxVolatility.Size = new Size(125, 34);
            textBoxVolatility.TabIndex = 4;
            textBoxVolatility.Text = "20,5";
            textBoxVolatility.TextAlign = HorizontalAlignment.Center;
            // 
            // labelVol
            // 
            labelVol.AutoSize = true;
            labelVol.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelVol.Location = new Point(194, 154);
            labelVol.Name = "labelVol";
            labelVol.Size = new Size(128, 28);
            labelVol.TabIndex = 5;
            labelVol.Text = "Volatilité (%)";
            labelVol.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelRf
            // 
            labelRf.AutoSize = true;
            labelRf.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelRf.Location = new Point(352, 154);
            labelRf.Name = "labelRf";
            labelRf.Size = new Size(218, 31);
            labelRf.TabIndex = 6;
            labelRf.Text = "Taux sans risque (%)";
            // 
            // textBoxRf
            // 
            textBoxRf.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxRf.Location = new Point(391, 203);
            textBoxRf.Name = "textBoxRf";
            textBoxRf.Size = new Size(125, 34);
            textBoxRf.TabIndex = 9;
            textBoxRf.TextAlign = HorizontalAlignment.Center;
            // 
            // StructuredProducts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1411, 624);
            Controls.Add(groupBoxMarket);
            Name = "StructuredProducts";
            Text = "StructuredProducts";
            groupBoxMarket.ResumeLayout(false);
            groupBoxMarket.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBoxMarket;
        private Panel panel2;
        private RadioButton radioButtonVolSVI;
        private RadioButton radioButtonVolSto;
        private RadioButton radioButtonVolCste;
        private Panel panel1;
        private RadioButton radioButtonManual;
        private RadioButton radioButtonAuto;
        private Label label1;
        private TextBox textBoxSpot;
        private Label labelSpot;
        private TextBox textBoxVolatility;
        private Label labelVol;
        private Label labelRf;
        private TextBox textBoxRf;
    }
}