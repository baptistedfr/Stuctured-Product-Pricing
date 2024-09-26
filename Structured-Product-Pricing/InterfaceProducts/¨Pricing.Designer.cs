namespace InterfaceProducts
{
    partial class Pricing
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
            SuspendLayout();
            // 
            // price
            // 
            price.BackColor = SystemColors.Info;
            price.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            price.Location = new Point(58, 213);
            price.Name = "price";
            price.Size = new Size(187, 66);
            price.TabIndex = 0;
            price.Text = "Price";
            price.UseVisualStyleBackColor = false;
            price.Click += price_Click;
            // 
            // Pricing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(price);
            Name = "Pricing";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button price;
    }
}
