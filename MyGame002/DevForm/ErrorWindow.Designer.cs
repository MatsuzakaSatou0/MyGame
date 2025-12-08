namespace MyGame002
{
    partial class ErrorWindow
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
            errorLogBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // errorLogBox
            // 
            errorLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            errorLogBox.Location = new System.Drawing.Point(0, 0);
            errorLogBox.Name = "errorLogBox";
            errorLogBox.Size = new System.Drawing.Size(533, 370);
            errorLogBox.TabIndex = 3;
            errorLogBox.Text = "";
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 370);
            this.Controls.Add(errorLogBox);
            this.Name = "ErrorWindow";
            this.Text = "ErrorWindow";
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.RichTextBox errorLogBox;
    }
}