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
            this.back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // filePanel
            // 
            this.filePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filePanel.AutoScroll = true;
            this.filePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.filePanel.Location = new System.Drawing.Point(12, 38);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(776, 400);
            this.filePanel.TabIndex = 0;
            // 
            // currentPath
            // 
            this.currentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.currentPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentPath.ForeColor = System.Drawing.Color.White;
            this.currentPath.Location = new System.Drawing.Point(12, 12);
            this.currentPath.Name = "currentPath";
            this.currentPath.Size = new System.Drawing.Size(739, 13);
            this.currentPath.TabIndex = 1;
            this.currentPath.Text = "C:\\";
            this.currentPath.TextChanged += new System.EventHandler(this.currentPath_TextChanged);
            // 
            // back
            // 
            this.back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.back.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back.ForeColor = System.Drawing.Color.White;
            this.back.Location = new System.Drawing.Point(757, 7);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(31, 20);
            this.back.TabIndex = 2;
            this.back.Text = "<";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.back);
            this.Controls.Add(this.currentPath);
            this.Controls.Add(this.filePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "csharpExplorer";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox currentPath;
        public System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.Button back;
    }
}

