namespace eFlash.GUI.Network
{
    partial class DownloadBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DownloadBrowser));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.remoteTree = new System.Windows.Forms.TreeView();
            this.DownloadDeck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Preview = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SearchOption = new System.Windows.Forms.ComboBox();
            this.SearchBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.BackToNetwork = new System.Windows.Forms.Button();
            this.BackToMenu = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(690, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // remoteTree
            // 
            this.remoteTree.Location = new System.Drawing.Point(12, 111);
            this.remoteTree.Name = "remoteTree";
            this.remoteTree.Size = new System.Drawing.Size(275, 275);
            this.remoteTree.TabIndex = 3;
            // 
            // DownloadDeck
            // 
            this.DownloadDeck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DownloadDeck.Image = global::eFlash.Properties.Resources.download;
            this.DownloadDeck.Location = new System.Drawing.Point(163, 408);
            this.DownloadDeck.Name = "DownloadDeck";
            this.DownloadDeck.Size = new System.Drawing.Size(93, 55);
            this.DownloadDeck.TabIndex = 4;
            this.DownloadDeck.Text = "Download";
            this.DownloadDeck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DownloadDeck.UseVisualStyleBackColor = false;
            this.DownloadDeck.Click += new System.EventHandler(this.DownloadDeck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(486, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Deck Information:";
            // 
            // Preview
            // 
            this.Preview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Preview.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.Preview.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Preview.Image = global::eFlash.Properties.Resources.kview;
            this.Preview.Location = new System.Drawing.Point(290, 195);
            this.Preview.Margin = new System.Windows.Forms.Padding(0);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(96, 54);
            this.Preview.TabIndex = 6;
            this.Preview.Text = "Preview";
            this.Preview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Preview.UseVisualStyleBackColor = false;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(389, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 199);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // SearchOption
            // 
            this.SearchOption.FormattingEnabled = true;
            this.SearchOption.Items.AddRange(new object[] {
            "User Name",
            "Title",
            "Category",
            "Sub-Category"});
            this.SearchOption.Location = new System.Drawing.Point(12, 27);
            this.SearchOption.Name = "SearchOption";
            this.SearchOption.Size = new System.Drawing.Size(104, 21);
            this.SearchOption.TabIndex = 8;
            // 
            // SearchBox
            // 
            this.SearchBox.Location = new System.Drawing.Point(12, 72);
            this.SearchBox.Name = "SearchBox";
            this.SearchBox.Size = new System.Drawing.Size(179, 20);
            this.SearchBox.TabIndex = 9;
            this.SearchBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search By:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(435, 384);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Rank:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(433, 325);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Title:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(433, 343);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Category:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(433, 362);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sub-Category:";
            // 
            // BackToNetwork
            // 
            this.BackToNetwork.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackToNetwork.Image = global::eFlash.Properties.Resources.welcome;
            this.BackToNetwork.Location = new System.Drawing.Point(436, 425);
            this.BackToNetwork.Name = "BackToNetwork";
            this.BackToNetwork.Size = new System.Drawing.Size(102, 38);
            this.BackToNetwork.TabIndex = 16;
            this.BackToNetwork.Text = "Network Menu";
            this.BackToNetwork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackToNetwork.UseVisualStyleBackColor = false;
            this.BackToNetwork.Click += new System.EventHandler(this.BackToNetwork_Click);
            // 
            // BackToMenu
            // 
            this.BackToMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackToMenu.Image = global::eFlash.Properties.Resources.home;
            this.BackToMenu.Location = new System.Drawing.Point(564, 425);
            this.BackToMenu.Name = "BackToMenu";
            this.BackToMenu.Size = new System.Drawing.Size(102, 38);
            this.BackToMenu.TabIndex = 17;
            this.BackToMenu.Text = "eFlash Menu";
            this.BackToMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackToMenu.UseVisualStyleBackColor = false;
            this.BackToMenu.Click += new System.EventHandler(this.BackToMenu_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RefreshButton.Image = global::eFlash.Properties.Resources.refresh;
            this.RefreshButton.Location = new System.Drawing.Point(37, 408);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(93, 55);
            this.RefreshButton.TabIndex = 18;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // Search
            // 
            this.Search.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Search.Image = global::eFlash.Properties.Resources.find;
            this.Search.Location = new System.Drawing.Point(212, 46);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(89, 51);
            this.Search.TabIndex = 19;
            this.Search.Text = "Search";
            this.Search.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Search.UseVisualStyleBackColor = false;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // DownloadBrowser
            // 
            this.ClientSize = new System.Drawing.Size(690, 519);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.BackToMenu);
            this.Controls.Add(this.BackToNetwork);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SearchBox);
            this.Controls.Add(this.SearchOption);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DownloadDeck);
            this.Controls.Add(this.remoteTree);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "DownloadBrowser";
            this.Text = "Network Download Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DownloadBrowser_FormClosed);
            this.Load += new System.EventHandler(this.browser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.TreeView remoteTree;
        private System.Windows.Forms.Button DownloadDeck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Preview;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox SearchOption;
        private System.Windows.Forms.TextBox SearchBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BackToNetwork;
        private System.Windows.Forms.Button BackToMenu;
        private System.Windows.Forms.Button RefreshButton;
   
        private System.Windows.Forms.Button Search;
    }
}