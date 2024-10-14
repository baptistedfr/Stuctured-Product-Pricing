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
            labelVol = new Label();
            labelRf = new Label();
            labelSpot = new Label();
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
            groupBoxProduit = new GroupBox();
            comboBoxFreqObservation = new ComboBox();
            labelFreqObservation = new Label();
            labelBarrierCapital = new Label();
            labelBarrierCoupon = new Label();
            textBoxBarrierCapital = new TextBox();
            textBoxBarrierCoupon = new TextBox();
            panel3 = new Panel();
            radioButtonAutocall = new RadioButton();
            radioButtonDerive = new RadioButton();
            buttonAutocall = new Button();
            labelBarrier = new Label();
            textBoxBarrier = new TextBox();
            labelBinary = new Label();
            textBoxBinary = new TextBox();
            labelPrix = new Label();
            plotView1 = new OxyPlot.WindowsForms.PlotView();
            dataGridViewGrecs = new DataGridView();
            labelCF = new Label();
            groupBoxMarket = new GroupBox();
            comboBoxTicker = new ComboBox();
            panel2 = new Panel();
            radioButtonVolSVI = new RadioButton();
            radioButtonVolSto = new RadioButton();
            radioButtonVolCste = new RadioButton();
            panel1 = new Panel();
            radioButtonManual = new RadioButton();
            radioButtonAuto = new RadioButton();
            groupBoxProduit.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrecs).BeginInit();
            groupBoxMarket.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // price
            // 
            price.BackColor = SystemColors.Info;
            price.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.Location = new Point(477, 17);
            price.Name = "price";
            price.Size = new Size(153, 51);
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
            comboBoxOptions.Location = new Point(214, 29);
            comboBoxOptions.Name = "comboBoxOptions";
            comboBoxOptions.Size = new Size(253, 31);
            comboBoxOptions.TabIndex = 1;
            comboBoxOptions.SelectedIndexChanged += comboBoxOptions_SelectedIndexChanged;
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
            // textBoxRf
            // 
            textBoxRf.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxRf.Location = new Point(391, 203);
            textBoxRf.Name = "textBoxRf";
            textBoxRf.Size = new Size(125, 34);
            textBoxRf.TabIndex = 9;
            textBoxRf.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxStrike1
            // 
            textBoxStrike1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxStrike1.Location = new Point(359, 136);
            textBoxStrike1.Name = "textBoxStrike1";
            textBoxStrike1.Size = new Size(93, 34);
            textBoxStrike1.TabIndex = 10;
            textBoxStrike1.TextAlign = HorizontalAlignment.Center;
            textBoxStrike1.Visible = false;
            // 
            // textBoxStrike3
            // 
            textBoxStrike3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxStrike3.Location = new Point(600, 136);
            textBoxStrike3.Name = "textBoxStrike3";
            textBoxStrike3.Size = new Size(93, 34);
            textBoxStrike3.TabIndex = 11;
            textBoxStrike3.TextAlign = HorizontalAlignment.Center;
            textBoxStrike3.Visible = false;
            // 
            // textBoxStrike4
            // 
            textBoxStrike4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxStrike4.Location = new Point(725, 136);
            textBoxStrike4.Name = "textBoxStrike4";
            textBoxStrike4.Size = new Size(92, 34);
            textBoxStrike4.TabIndex = 12;
            textBoxStrike4.TextAlign = HorizontalAlignment.Center;
            textBoxStrike4.Visible = false;
            // 
            // textBoxStrike2
            // 
            textBoxStrike2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxStrike2.Location = new Point(475, 136);
            textBoxStrike2.Name = "textBoxStrike2";
            textBoxStrike2.Size = new Size(93, 34);
            textBoxStrike2.TabIndex = 13;
            textBoxStrike2.TextAlign = HorizontalAlignment.Center;
            textBoxStrike2.Visible = false;
            // 
            // labelStrike1
            // 
            labelStrike1.AutoSize = true;
            labelStrike1.Location = new Point(375, 110);
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
            labelStrike2.Location = new Point(491, 110);
            labelStrike2.Name = "labelStrike2";
            labelStrike2.Size = new Size(65, 23);
            labelStrike2.TabIndex = 15;
            labelStrike2.Text = "Strike 2";
            labelStrike2.Visible = false;
            // 
            // labelStrike3
            // 
            labelStrike3.AutoSize = true;
            labelStrike3.Location = new Point(617, 110);
            labelStrike3.Name = "labelStrike3";
            labelStrike3.Size = new Size(65, 23);
            labelStrike3.TabIndex = 16;
            labelStrike3.Text = "Strike 3";
            labelStrike3.Visible = false;
            // 
            // labelStrike4
            // 
            labelStrike4.AutoSize = true;
            labelStrike4.Location = new Point(738, 110);
            labelStrike4.Name = "labelStrike4";
            labelStrike4.Size = new Size(65, 23);
            labelStrike4.TabIndex = 17;
            labelStrike4.Text = "Strike 4";
            labelStrike4.Visible = false;
            // 
            // textBoxMaturity
            // 
            textBoxMaturity.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxMaturity.Location = new Point(232, 136);
            textBoxMaturity.Name = "textBoxMaturity";
            textBoxMaturity.Size = new Size(95, 34);
            textBoxMaturity.TabIndex = 18;
            textBoxMaturity.TextAlign = HorizontalAlignment.Center;
            // 
            // labelMaturity
            // 
            labelMaturity.AutoSize = true;
            labelMaturity.Location = new Point(244, 110);
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
            label5.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(24, 17);
            label5.Name = "label5";
            label5.Size = new Size(166, 56);
            label5.TabIndex = 20;
            label5.Text = "Produit";
            // 
            // groupBoxProduit
            // 
            groupBoxProduit.BackColor = Color.AntiqueWhite;
            groupBoxProduit.Controls.Add(comboBoxFreqObservation);
            groupBoxProduit.Controls.Add(labelFreqObservation);
            groupBoxProduit.Controls.Add(labelBarrierCapital);
            groupBoxProduit.Controls.Add(labelBarrierCoupon);
            groupBoxProduit.Controls.Add(textBoxBarrierCapital);
            groupBoxProduit.Controls.Add(textBoxBarrierCoupon);
            groupBoxProduit.Controls.Add(panel3);
            groupBoxProduit.Controls.Add(buttonAutocall);
            groupBoxProduit.Controls.Add(labelBarrier);
            groupBoxProduit.Controls.Add(textBoxBarrier);
            groupBoxProduit.Controls.Add(labelBinary);
            groupBoxProduit.Controls.Add(textBoxBinary);
            groupBoxProduit.Controls.Add(labelStrike4);
            groupBoxProduit.Controls.Add(labelMaturity);
            groupBoxProduit.Controls.Add(textBoxStrike4);
            groupBoxProduit.Controls.Add(labelStrike3);
            groupBoxProduit.Controls.Add(label5);
            groupBoxProduit.Controls.Add(labelStrike2);
            groupBoxProduit.Controls.Add(textBoxStrike3);
            groupBoxProduit.Controls.Add(textBoxMaturity);
            groupBoxProduit.Controls.Add(textBoxStrike2);
            groupBoxProduit.Controls.Add(labelStrike1);
            groupBoxProduit.Controls.Add(comboBoxOptions);
            groupBoxProduit.Controls.Add(price);
            groupBoxProduit.Controls.Add(textBoxStrike1);
            groupBoxProduit.Location = new Point(629, 23);
            groupBoxProduit.Name = "groupBoxProduit";
            groupBoxProduit.Size = new Size(908, 277);
            groupBoxProduit.TabIndex = 21;
            groupBoxProduit.TabStop = false;
            // 
            // comboBoxFreqObservation
            // 
            comboBoxFreqObservation.AccessibleRole = AccessibleRole.ScrollBar;
            comboBoxFreqObservation.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxFreqObservation.BackColor = Color.Moccasin;
            comboBoxFreqObservation.ForeColor = Color.Black;
            comboBoxFreqObservation.FormattingEnabled = true;
            comboBoxFreqObservation.Items.AddRange(new object[] { "Annuelle", "Semestrielle", "Trimestrielle", "Mensuelle" });
            comboBoxFreqObservation.Location = new Point(28, 219);
            comboBoxFreqObservation.Name = "comboBoxFreqObservation";
            comboBoxFreqObservation.Size = new Size(174, 31);
            comboBoxFreqObservation.TabIndex = 34;
            comboBoxFreqObservation.Visible = false;
            // 
            // labelFreqObservation
            // 
            labelFreqObservation.AutoSize = true;
            labelFreqObservation.Location = new Point(34, 193);
            labelFreqObservation.Name = "labelFreqObservation";
            labelFreqObservation.Size = new Size(168, 23);
            labelFreqObservation.TabIndex = 33;
            labelFreqObservation.Text = "Freq observation /an";
            labelFreqObservation.TextAlign = ContentAlignment.MiddleCenter;
            labelFreqObservation.Visible = false;
            // 
            // labelBarrierCapital
            // 
            labelBarrierCapital.AutoSize = true;
            labelBarrierCapital.Location = new Point(646, 193);
            labelBarrierCapital.Name = "labelBarrierCapital";
            labelBarrierCapital.Size = new Size(127, 23);
            labelBarrierCapital.TabIndex = 31;
            labelBarrierCapital.Text = "Barrière Capital";
            labelBarrierCapital.TextAlign = ContentAlignment.MiddleCenter;
            labelBarrierCapital.Visible = false;
            // 
            // labelBarrierCoupon
            // 
            labelBarrierCoupon.AutoSize = true;
            labelBarrierCoupon.Location = new Point(495, 193);
            labelBarrierCoupon.Name = "labelBarrierCoupon";
            labelBarrierCoupon.Size = new Size(135, 23);
            labelBarrierCoupon.TabIndex = 30;
            labelBarrierCoupon.Text = "Barrière Coupon";
            labelBarrierCoupon.TextAlign = ContentAlignment.MiddleCenter;
            labelBarrierCoupon.Visible = false;
            // 
            // textBoxBarrierCapital
            // 
            textBoxBarrierCapital.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxBarrierCapital.Location = new Point(664, 219);
            textBoxBarrierCapital.Name = "textBoxBarrierCapital";
            textBoxBarrierCapital.Size = new Size(93, 34);
            textBoxBarrierCapital.TabIndex = 28;
            textBoxBarrierCapital.TextAlign = HorizontalAlignment.Center;
            textBoxBarrierCapital.Visible = false;
            // 
            // textBoxBarrierCoupon
            // 
            textBoxBarrierCoupon.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxBarrierCoupon.Location = new Point(518, 219);
            textBoxBarrierCoupon.Name = "textBoxBarrierCoupon";
            textBoxBarrierCoupon.Size = new Size(93, 34);
            textBoxBarrierCoupon.TabIndex = 27;
            textBoxBarrierCoupon.TextAlign = HorizontalAlignment.Center;
            textBoxBarrierCoupon.Visible = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(radioButtonAutocall);
            panel3.Controls.Add(radioButtonDerive);
            panel3.Location = new Point(24, 85);
            panel3.Name = "panel3";
            panel3.Size = new Size(150, 88);
            panel3.TabIndex = 26;
            // 
            // radioButtonAutocall
            // 
            radioButtonAutocall.AutoSize = true;
            radioButtonAutocall.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonAutocall.Location = new Point(10, 18);
            radioButtonAutocall.Name = "radioButtonAutocall";
            radioButtonAutocall.Size = new Size(106, 32);
            radioButtonAutocall.TabIndex = 15;
            radioButtonAutocall.TabStop = true;
            radioButtonAutocall.Text = "Autocall";
            radioButtonAutocall.UseVisualStyleBackColor = true;
            radioButtonAutocall.CheckedChanged += radioButtonAutocall_CheckedChanged;
            // 
            // radioButtonDerive
            // 
            radioButtonDerive.AutoSize = true;
            radioButtonDerive.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            radioButtonDerive.Location = new Point(10, 54);
            radioButtonDerive.Name = "radioButtonDerive";
            radioButtonDerive.Size = new Size(123, 32);
            radioButtonDerive.TabIndex = 14;
            radioButtonDerive.TabStop = true;
            radioButtonDerive.Text = "Derivative";
            radioButtonDerive.UseVisualStyleBackColor = true;
            radioButtonDerive.CheckedChanged += radioButtonDerive_CheckedChanged;
            // 
            // buttonAutocall
            // 
            buttonAutocall.BackColor = SystemColors.Info;
            buttonAutocall.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonAutocall.Location = new Point(646, 17);
            buttonAutocall.Name = "buttonAutocall";
            buttonAutocall.Size = new Size(214, 51);
            buttonAutocall.TabIndex = 25;
            buttonAutocall.Text = "Price Autocall Coupon";
            buttonAutocall.UseVisualStyleBackColor = false;
            buttonAutocall.Click += buttonAutocall_Click;
            // 
            // labelBarrier
            // 
            labelBarrier.AutoSize = true;
            labelBarrier.Location = new Point(371, 193);
            labelBarrier.Name = "labelBarrier";
            labelBarrier.Size = new Size(69, 23);
            labelBarrier.TabIndex = 24;
            labelBarrier.Text = "Barrière";
            labelBarrier.TextAlign = ContentAlignment.MiddleCenter;
            labelBarrier.Visible = false;
            // 
            // textBoxBarrier
            // 
            textBoxBarrier.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxBarrier.Location = new Point(359, 219);
            textBoxBarrier.Name = "textBoxBarrier";
            textBoxBarrier.Size = new Size(93, 34);
            textBoxBarrier.TabIndex = 23;
            textBoxBarrier.TextAlign = HorizontalAlignment.Center;
            textBoxBarrier.Visible = false;
            // 
            // labelBinary
            // 
            labelBinary.AutoSize = true;
            labelBinary.Location = new Point(244, 193);
            labelBinary.Name = "labelBinary";
            labelBinary.Size = new Size(71, 23);
            labelBinary.TabIndex = 22;
            labelBinary.Text = "Coupon";
            labelBinary.TextAlign = ContentAlignment.MiddleCenter;
            labelBinary.Visible = false;
            // 
            // textBoxBinary
            // 
            textBoxBinary.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxBinary.Location = new Point(232, 219);
            textBoxBinary.Name = "textBoxBinary";
            textBoxBinary.Size = new Size(93, 34);
            textBoxBinary.TabIndex = 21;
            textBoxBinary.TextAlign = HorizontalAlignment.Center;
            textBoxBinary.Visible = false;
            // 
            // labelPrix
            // 
            labelPrix.AutoSize = true;
            labelPrix.BackColor = Color.Red;
            labelPrix.BorderStyle = BorderStyle.FixedSingle;
            labelPrix.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrix.Location = new Point(128, 319);
            labelPrix.Name = "labelPrix";
            labelPrix.Size = new Size(143, 56);
            labelPrix.TabIndex = 22;
            labelPrix.Text = "Prix :  ";
            // 
            // plotView1
            // 
            plotView1.BackColor = Color.Snow;
            plotView1.Location = new Point(81, 428);
            plotView1.Name = "plotView1";
            plotView1.PanCursor = Cursors.Hand;
            plotView1.Size = new Size(681, 422);
            plotView1.TabIndex = 23;
            plotView1.Text = "plotViewProduct";
            plotView1.ZoomHorizontalCursor = Cursors.SizeWE;
            plotView1.ZoomRectangleCursor = Cursors.SizeNWSE;
            plotView1.ZoomVerticalCursor = Cursors.SizeNS;
            // 
            // dataGridViewGrecs
            // 
            dataGridViewGrecs.BackgroundColor = SystemColors.Info;
            dataGridViewGrecs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewGrecs.Location = new Point(887, 487);
            dataGridViewGrecs.Name = "dataGridViewGrecs";
            dataGridViewGrecs.RowHeadersWidth = 51;
            dataGridViewGrecs.Size = new Size(310, 273);
            dataGridViewGrecs.TabIndex = 24;
            // 
            // labelCF
            // 
            labelCF.AutoSize = true;
            labelCF.BackColor = Color.Tomato;
            labelCF.BorderStyle = BorderStyle.FixedSingle;
            labelCF.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCF.Location = new Point(782, 319);
            labelCF.Name = "labelCF";
            labelCF.Size = new Size(335, 56);
            labelCF.TabIndex = 25;
            labelCF.Text = "Close Formula :  ";
            // 
            // groupBoxMarket
            // 
            groupBoxMarket.BackColor = Color.AntiqueWhite;
            groupBoxMarket.Controls.Add(comboBoxTicker);
            groupBoxMarket.Controls.Add(panel2);
            groupBoxMarket.Controls.Add(panel1);
            groupBoxMarket.Controls.Add(label1);
            groupBoxMarket.Controls.Add(textBoxSpot);
            groupBoxMarket.Controls.Add(labelSpot);
            groupBoxMarket.Controls.Add(textBoxVolatility);
            groupBoxMarket.Controls.Add(labelVol);
            groupBoxMarket.Controls.Add(labelRf);
            groupBoxMarket.Controls.Add(textBoxRf);
            groupBoxMarket.Location = new Point(21, 23);
            groupBoxMarket.Name = "groupBoxMarket";
            groupBoxMarket.Size = new Size(570, 268);
            groupBoxMarket.TabIndex = 26;
            groupBoxMarket.TabStop = false;
            // 
            // comboBoxTicker
            // 
            comboBoxTicker.AccessibleRole = AccessibleRole.ScrollBar;
            comboBoxTicker.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxTicker.BackColor = Color.Moccasin;
            comboBoxTicker.ForeColor = Color.Black;
            comboBoxTicker.FormattingEnabled = true;
            comboBoxTicker.Items.AddRange(new object[] { "AAPL", "GLE.PA", "TSLA" });
            comboBoxTicker.Location = new Point(391, 37);
            comboBoxTicker.Name = "comboBoxTicker";
            comboBoxTicker.Size = new Size(152, 31);
            comboBoxTicker.TabIndex = 35;
            comboBoxTicker.Visible = false;
            comboBoxTicker.SelectedIndexChanged += comboBoxTicker_SelectedIndexChanged;
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
            radioButtonVolSVI.Size = new Size(85, 27);
            radioButtonVolSVI.TabIndex = 13;
            radioButtonVolSVI.TabStop = true;
            radioButtonVolSVI.Text = "Vol SVI";
            radioButtonVolSVI.UseVisualStyleBackColor = true;
            radioButtonVolSVI.CheckedChanged += radioButtonVolSVI_CheckedChanged;
            // 
            // radioButtonVolSto
            // 
            radioButtonVolSto.AutoSize = true;
            radioButtonVolSto.Location = new Point(338, 3);
            radioButtonVolSto.Name = "radioButtonVolSto";
            radioButtonVolSto.Size = new Size(157, 27);
            radioButtonVolSto.TabIndex = 12;
            radioButtonVolSto.TabStop = true;
            radioButtonVolSto.Text = "Vol Stochastique";
            radioButtonVolSto.UseVisualStyleBackColor = true;
            radioButtonVolSto.CheckedChanged += radioButtonVolSto_CheckedChanged;
            // 
            // radioButtonVolCste
            // 
            radioButtonVolCste.AutoSize = true;
            radioButtonVolCste.Location = new Point(14, 3);
            radioButtonVolCste.Name = "radioButtonVolCste";
            radioButtonVolCste.Size = new Size(138, 27);
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
            radioButtonManual.Size = new Size(177, 27);
            radioButtonManual.TabIndex = 1;
            radioButtonManual.Text = "Marché sur mesure";
            radioButtonManual.UseVisualStyleBackColor = true;
            radioButtonManual.CheckedChanged += radioButtonManual_CheckedChanged;
            // 
            // radioButtonAuto
            // 
            radioButtonAuto.AutoSize = true;
            radioButtonAuto.Location = new Point(14, 3);
            radioButtonAuto.Name = "radioButtonAuto";
            radioButtonAuto.Size = new Size(152, 27);
            radioButtonAuto.TabIndex = 0;
            radioButtonAuto.Text = "Marché existant";
            radioButtonAuto.UseVisualStyleBackColor = true;
            radioButtonAuto.CheckedChanged += radioButtonAuto_CheckedChanged;
            // 
            // Interface
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SeaShell;
            ClientSize = new Size(1585, 898);
            Controls.Add(groupBoxMarket);
            Controls.Add(labelCF);
            Controls.Add(dataGridViewGrecs);
            Controls.Add(plotView1);
            Controls.Add(labelPrix);
            Controls.Add(groupBoxProduit);
            Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Interface";
            Text = "Form1";
            groupBoxProduit.ResumeLayout(false);
            groupBoxProduit.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewGrecs).EndInit();
            groupBoxMarket.ResumeLayout(false);
            groupBoxMarket.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button price;
        private ComboBox comboBoxOptions;
        private Label label1;
        private TextBox textBoxVolatility;
        private Label labelVol;
        private Label labelRf;
        private Label labelSpot;
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
        private GroupBox groupBoxProduit;
        private Label labelPrix;
        private OxyPlot.WindowsForms.PlotView plotView1;
        private Label labelBinary;
        private TextBox textBoxBinary;
        private Label labelBarrier;
        private TextBox textBoxBarrier;
        private DataGridView dataGridViewGrecs;
        private Label labelCF;
        private GroupBox groupBoxMarket;
        private Panel panel1;
        private RadioButton radioButtonManual;
        private RadioButton radioButtonAuto;
        private Panel panel2;
        private RadioButton radioButtonVolCste;
        private RadioButton radioButtonVolSto;
        private RadioButton radioButtonVolSVI;
        private Panel panel3;
        private RadioButton radioButtonDerive;
        private Button buttonAutocall;
        private TextBox textBoxBarrierCapital;
        private TextBox textBoxBarrierCoupon;
        private Label labelBarrierCapital;
        private Label labelBarrierCoupon;
        private Label labelFreqObservation;
        private ComboBox comboBoxFreqObservation;
        private RadioButton radioButtonAutocall;
        private ComboBox comboBoxTicker;
    }
}
