namespace MyGame002.DevForm
{
    partial class GameFileTool
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
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 12);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(300, 23);
            button1.TabIndex = 1;
            button1.Text = "聖書から日本語のマップを作成";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // GameFileTool
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(324, 47);
            Controls.Add(button1);
            Name = "GameFileTool";
            Text = "GameFileTool";
            Load += GameFileTool_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button button1;
    }
}