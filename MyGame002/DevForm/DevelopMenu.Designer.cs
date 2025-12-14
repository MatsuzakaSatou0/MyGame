namespace MyGame002
{
    partial class DevelopMenu
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
            label1 = new System.Windows.Forms.Label();
            windowSizeNum = new System.Windows.Forms.NumericUpDown();
            CompressButton = new System.Windows.Forms.Button();
            CompressFileInput = new System.Windows.Forms.TextBox();
            textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)windowSizeNum).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(12, 13);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(71, 15);
            label1.TabIndex = 1;
            label1.Text = "WindowSize";
            // 
            // windowSizeNum
            // 
            windowSizeNum.DecimalPlaces = 1;
            windowSizeNum.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            windowSizeNum.Location = new System.Drawing.Point(89, 9);
            windowSizeNum.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            windowSizeNum.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
            windowSizeNum.Name = "windowSizeNum";
            windowSizeNum.Size = new System.Drawing.Size(120, 23);
            windowSizeNum.TabIndex = 2;
            windowSizeNum.Value = new decimal(new int[] { 1, 0, 0, 0 });
            windowSizeNum.ValueChanged += windowSizeNum_ValueChanged;
            // 
            // CompressButton
            // 
            CompressButton.Location = new System.Drawing.Point(12, 47);
            CompressButton.Name = "CompressButton";
            CompressButton.Size = new System.Drawing.Size(197, 23);
            CompressButton.TabIndex = 3;
            CompressButton.Text = "CompressFile";
            CompressButton.UseVisualStyleBackColor = true;
            CompressButton.Click += CompressButton_Click;
            // 
            // CompressFileInput
            // 
            CompressFileInput.Location = new System.Drawing.Point(12, 76);
            CompressFileInput.Name = "CompressFileInput";
            CompressFileInput.Size = new System.Drawing.Size(195, 23);
            CompressFileInput.TabIndex = 4;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 105);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(195, 23);
            textBox1.TabIndex = 5;
            // 
            // DevelopMenu
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(219, 134);
            Controls.Add(textBox1);
            Controls.Add(CompressFileInput);
            Controls.Add(CompressButton);
            Controls.Add(windowSizeNum);
            Controls.Add(label1);
            Name = "DevelopMenu";
            Text = "DevelopMenu";
            ((System.ComponentModel.ISupportInitialize)windowSizeNum).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown windowSizeNum;
        private System.Windows.Forms.Button CompressButton;
        private System.Windows.Forms.TextBox CompressFileInput;
        private System.Windows.Forms.TextBox textBox1;
    }
}