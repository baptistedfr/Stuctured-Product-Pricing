namespace InterfaceProducts
{
    partial class Menu
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
            buttonPricing = new Button();
            buttonExcel = new Button();
            SuspendLayout();
            // 
            // buttonPricing
            // 
            buttonPricing.BackColor = Color.LightCoral;
            buttonPricing.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPricing.Location = new Point(90, 137);
            buttonPricing.Name = "buttonPricing";
            buttonPricing.Size = new Size(243, 157);
            buttonPricing.TabIndex = 0;
            buttonPricing.Text = "Price Products";
            buttonPricing.UseVisualStyleBackColor = false;
            buttonPricing.Click += buttonPricing_Click;
            // 
            // buttonExcel
            // 
            buttonExcel.BackColor = Color.LightGreen;
            buttonExcel.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonExcel.Location = new Point(422, 137);
            buttonExcel.Name = "buttonExcel";
            buttonExcel.Size = new Size(243, 157);
            buttonExcel.TabIndex = 1;
            buttonExcel.Text = "Price Excel";
            buttonExcel.UseVisualStyleBackColor = false;
            buttonExcel.Click += buttonExcel_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonExcel);
            Controls.Add(buttonPricing);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonPricing;
        private Button buttonExcel;
    }
}