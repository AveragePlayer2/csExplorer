namespace csharpExplorer
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.filePanel = new System.Windows.Forms.Panel();
            this.currentPath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.BackColor = System.Drawing.Color.Silver;
            this.filePanel.Location = new System.Drawing.Point(12, 38);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(776, 400);
            this.filePanel.TabIndex = 0;
            // 
            // currentPath
            // 
            this.currentPath.Location = new System.Drawing.Point(12, 12);
            this.currentPath.Name = "currentPath";
            this.currentPath.Size = new System.Drawing.Size(776, 20);
            this.currentPath.TabIndex = 1;
            this.currentPath.Text = "C:\\";
            this.currentPath.TextChanged += new System.EventHandler(this.currentPath_TextChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentPath);
            this.Controls.Add(this.filePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "csharpExplorer";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.TextBox currentPath;
    }
}

