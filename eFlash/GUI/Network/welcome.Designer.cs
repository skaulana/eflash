namespace eFlash.GUI.Network
{
    partial class welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(welcome));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.switchProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadDecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadDecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rankDecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Download = new System.Windows.Forms.Button();
            this.Upload = new System.Windows.Forms.Button();
            this.Rank = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(433, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchProfileToolStripMenuItem,
            this.signOffToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(35, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // switchProfileToolStripMenuItem
            // 
            this.switchProfileToolStripMenuItem.Name = "switchProfileToolStripMenuItem";
            this.switchProfileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.switchProfileToolStripMenuItem.Text = "Switch Profile";
            this.switchProfileToolStripMenuItem.Click += new System.EventHandler(this.switchProfileToolStripMenuItem_Click);
            // 
            // signOffToolStripMenuItem
            // 
            this.signOffToolStripMenuItem.Name = "signOffToolStripMenuItem";
            this.signOffToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.signOffToolStripMenuItem.Text = "Sign Off";
            this.signOffToolStripMenuItem.Click += new System.EventHandler(this.signOffToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadDecksToolStripMenuItem,
            this.uploadDecksToolStripMenuItem,
            this.rankDecksToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            this.optionToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionToolStripMenuItem.Text = "Options";
            // 
            // downloadDecksToolStripMenuItem
            // 
            this.downloadDecksToolStripMenuItem.Name = "downloadDecksToolStripMenuItem";
            this.downloadDecksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.downloadDecksToolStripMenuItem.Text = "Download Decks";
            this.downloadDecksToolStripMenuItem.Click += new System.EventHandler(this.downloadDecksToolStripMenuItem_Click);
            // 
            // uploadDecksToolStripMenuItem
            // 
            this.uploadDecksToolStripMenuItem.Name = "uploadDecksToolStripMenuItem";
            this.uploadDecksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.uploadDecksToolStripMenuItem.Text = "Upload Decks";
            this.uploadDecksToolStripMenuItem.Click += new System.EventHandler(this.uploadDecksToolStripMenuItem_Click);
            // 
            // rankDecksToolStripMenuItem
            // 
            this.rankDecksToolStripMenuItem.Name = "rankDecksToolStripMenuItem";
            this.rankDecksToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.rankDecksToolStripMenuItem.Text = "Rank Decks";
            this.rankDecksToolStripMenuItem.Click += new System.EventHandler(this.rankDecksToolStripMenuItem_Click);
            // 
            // Download
            // 
            this.Download.Image = global::eFlash.Properties.Resources.window_nofullscreen;
            this.Download.Location = new System.Drawing.Point(167, 68);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(186, 135);
            this.Download.TabIndex = 8;
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // Upload
            // 
            this.Upload.Image = global::eFlash.Properties.Resources.window_fullscreen;
            this.Upload.Location = new System.Drawing.Point(167, 209);
            this.Upload.Name = "Upload";
            this.Upload.Size = new System.Drawing.Size(186, 135);
            this.Upload.TabIndex = 9;
            this.Upload.UseVisualStyleBackColor = true;
            this.Upload.Click += new System.EventHandler(this.Upload_Click);
            // 
            // Rank
            // 
            this.Rank.Image = global::eFlash.Properties.Resources.quick_restart;
            this.Rank.Location = new System.Drawing.Point(167, 350);
            this.Rank.Name = "Rank";
            this.Rank.Size = new System.Drawing.Size(186, 135);
            this.Rank.TabIndex = 10;
            this.Rank.UseVisualStyleBackColor = true;
            this.Rank.Click += new System.EventHandler(this.Rank_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Download Decks";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Upload Decks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(59, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Rank Decks";
            // 
            // welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 594);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Rank);
            this.Controls.Add(this.Upload);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "welcome";
            this.Text = "Welcome to the eFlash Network";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.welcome_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem switchProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionToolStripMenuItem;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Button Upload;
        private System.Windows.Forms.Button Rank;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem downloadDecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadDecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rankDecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}