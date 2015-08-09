namespace eFlash.GUI.Network
{
    partial class UploadBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadBrowser));
            this.localTree = new System.Windows.Forms.TreeView();
            this.UploadDeck = new System.Windows.Forms.Button();
            this.remoteTree = new System.Windows.Forms.TreeView();
            this.RemoveRemoteDeck = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BackToMenu = new System.Windows.Forms.Button();
            this.BackToNetwork = new System.Windows.Forms.Button();
            this.RemoveLocalDeck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Preview = new System.Windows.Forms.Button();
            this.RefreshButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // localTree
            // 
            this.localTree.Location = new System.Drawing.Point(43, 53);
            this.localTree.Name = "localTree";
            this.localTree.Size = new System.Drawing.Size(196, 237);
            this.localTree.TabIndex = 0;
            // 
            // UploadDeck
            // 
            this.UploadDeck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.UploadDeck.Image = global::eFlash.Properties.Resources.upload;
            this.UploadDeck.Location = new System.Drawing.Point(272, 108);
            this.UploadDeck.Name = "UploadDeck";
            this.UploadDeck.Size = new System.Drawing.Size(105, 55);
            this.UploadDeck.TabIndex = 2;
            this.UploadDeck.Text = "Upload";
            this.UploadDeck.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.UploadDeck.UseVisualStyleBackColor = false;
            this.UploadDeck.Click += new System.EventHandler(this.UploadDeck_Click);
            // 
            // remoteTree
            // 
            this.remoteTree.Location = new System.Drawing.Point(416, 53);
            this.remoteTree.Name = "remoteTree";
            this.remoteTree.Size = new System.Drawing.Size(196, 237);
            this.remoteTree.TabIndex = 3;
            // 
            // RemoveRemoteDeck
            // 
            this.RemoveRemoteDeck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RemoveRemoteDeck.Location = new System.Drawing.Point(415, 296);
            this.RemoveRemoteDeck.Name = "RemoveRemoteDeck";
            this.RemoveRemoteDeck.Size = new System.Drawing.Size(197, 20);
            this.RemoveRemoteDeck.TabIndex = 4;
            this.RemoveRemoteDeck.Text = "Remove Selected Deck";
            this.RemoveRemoteDeck.UseVisualStyleBackColor = false;
            this.RemoveRemoteDeck.Click += new System.EventHandler(this.RemoveRemoteDeck_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Remote Uploaded  Decks:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(234, 341);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 414);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Sub-Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 341);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Category:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Title:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(315, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Selected Deck Information:";
            // 
            // BackToMenu
            // 
            this.BackToMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackToMenu.Image = global::eFlash.Properties.Resources.home;
            this.BackToMenu.Location = new System.Drawing.Point(581, 431);
            this.BackToMenu.Name = "BackToMenu";
            this.BackToMenu.Size = new System.Drawing.Size(97, 51);
            this.BackToMenu.TabIndex = 21;
            this.BackToMenu.Text = "eFlash Menu";
            this.BackToMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackToMenu.UseVisualStyleBackColor = false;
            this.BackToMenu.Click += new System.EventHandler(this.BackToMenu_Click);
            // 
            // BackToNetwork
            // 
            this.BackToNetwork.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackToNetwork.Image = global::eFlash.Properties.Resources.welcome;
            this.BackToNetwork.Location = new System.Drawing.Point(581, 363);
            this.BackToNetwork.Name = "BackToNetwork";
            this.BackToNetwork.Size = new System.Drawing.Size(97, 51);
            this.BackToNetwork.TabIndex = 22;
            this.BackToNetwork.Text = "Network Menu";
            this.BackToNetwork.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BackToNetwork.UseVisualStyleBackColor = false;
            this.BackToNetwork.Click += new System.EventHandler(this.BackToNetwork_Click);
            // 
            // RemoveLocalDeck
            // 
            this.RemoveLocalDeck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RemoveLocalDeck.Location = new System.Drawing.Point(42, 296);
            this.RemoveLocalDeck.Name = "RemoveLocalDeck";
            this.RemoveLocalDeck.Size = new System.Drawing.Size(197, 20);
            this.RemoveLocalDeck.TabIndex = 23;
            this.RemoveLocalDeck.Text = "Remove Selected Deck";
            this.RemoveLocalDeck.UseVisualStyleBackColor = false;
            this.RemoveLocalDeck.Click += new System.EventHandler(this.RemoveLocalDeck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Local Decks:";
            // 
            // Preview
            // 
            this.Preview.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Preview.ForeColor = System.Drawing.Color.Black;
            this.Preview.Image = global::eFlash.Properties.Resources.kview;
            this.Preview.Location = new System.Drawing.Point(5, 454);
            this.Preview.Name = "Preview";
            this.Preview.Size = new System.Drawing.Size(81, 53);
            this.Preview.TabIndex = 24;
            this.Preview.Text = "Preview";
            this.Preview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Preview.UseVisualStyleBackColor = false;
            this.Preview.Click += new System.EventHandler(this.Preview_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.RefreshButton.Image = global::eFlash.Properties.Resources.refresh;
            this.RefreshButton.Location = new System.Drawing.Point(272, 220);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(105, 56);
            this.RefreshButton.TabIndex = 25;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RefreshButton.UseVisualStyleBackColor = false;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // UploadBrowser
            // 
            this.ClientSize = new System.Drawing.Size(690, 519);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.Preview);
            this.Controls.Add(this.RemoveLocalDeck);
            this.Controls.Add(this.BackToNetwork);
            this.Controls.Add(this.BackToMenu);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RemoveRemoteDeck);
            this.Controls.Add(this.remoteTree);
            this.Controls.Add(this.UploadDeck);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.localTree);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UploadBrowser";
            this.Text = "Network Upload Browser";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UploadBrowser_FormClosed);
            this.Load += new System.EventHandler(this.browser_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView localTree;
        private System.Windows.Forms.Button UploadDeck;
        private System.Windows.Forms.TreeView remoteTree;
        private System.Windows.Forms.Button RemoveRemoteDeck;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button BackToMenu;
        private System.Windows.Forms.Button BackToNetwork;
        private System.Windows.Forms.Button RemoveLocalDeck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Preview;
        private System.Windows.Forms.Button RefreshButton;




    }
}