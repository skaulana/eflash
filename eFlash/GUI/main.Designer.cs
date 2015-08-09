namespace eFlash.GUI
{
    partial class main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.switchProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDeckWithCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importDeckFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDeckToPowerPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quizOnDeckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView_localdecks = new System.Windows.Forms.TreeView();
            this.button_net = new System.Windows.Forms.Button();
            this.label_selectdeck = new System.Windows.Forms.Label();
            this.label_welcome = new System.Windows.Forms.Label();
            this.button_create = new System.Windows.Forms.Button();
            this.button_edit = new System.Windows.Forms.Button();
            this.button_view = new System.Windows.Forms.Button();
            this.button_quiz = new System.Windows.Forms.Button();
            this.button_export = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listSet = new eFlash.GUI.ListSet();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.createToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.learnToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(694, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.switchProfileToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // switchProfileToolStripMenuItem
            // 
            this.switchProfileToolStripMenuItem.Name = "switchProfileToolStripMenuItem";
            this.switchProfileToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.switchProfileToolStripMenuItem.Text = "&Switch Profile";
            this.switchProfileToolStripMenuItem.Click += new System.EventHandler(this.switchProfileToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.exitToolStripMenuItem.Text = "E&xit eFlash";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDeckWithCreatorToolStripMenuItem,
            this.importDeckFromFileToolStripMenuItem,
            this.exportDeckToPowerPointToolStripMenuItem});
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.createToolStripMenuItem.Text = "&Create";
            // 
            // newDeckWithCreatorToolStripMenuItem
            // 
            this.newDeckWithCreatorToolStripMenuItem.Name = "newDeckWithCreatorToolStripMenuItem";
            this.newDeckWithCreatorToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newDeckWithCreatorToolStripMenuItem.Text = "&New Deck using Creator";
            this.newDeckWithCreatorToolStripMenuItem.Click += new System.EventHandler(this.newDeckWithCreatorToolStripMenuItem_Click);
            // 
            // importDeckFromFileToolStripMenuItem
            // 
            this.importDeckFromFileToolStripMenuItem.Name = "importDeckFromFileToolStripMenuItem";
            this.importDeckFromFileToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.importDeckFromFileToolStripMenuItem.Text = "&Import Deck from File...";
            this.importDeckFromFileToolStripMenuItem.Click += new System.EventHandler(this.importDeckFromFileToolStripMenuItem_Click);
            // 
            // exportDeckToPowerPointToolStripMenuItem
            // 
            this.exportDeckToPowerPointToolStripMenuItem.Name = "exportDeckToPowerPointToolStripMenuItem";
            this.exportDeckToPowerPointToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.exportDeckToPowerPointToolStripMenuItem.Text = "&Export Deck to PowerPoint...";
            this.exportDeckToPowerPointToolStripMenuItem.Click += new System.EventHandler(this.exportDeckToPowerPointToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editDeckToolStripMenuItem,
            this.deleteDeckToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.manageToolStripMenuItem.Text = "&Manage";
            // 
            // editDeckToolStripMenuItem
            // 
            this.editDeckToolStripMenuItem.Name = "editDeckToolStripMenuItem";
            this.editDeckToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.editDeckToolStripMenuItem.Text = "&Edit Selected Deck";
            this.editDeckToolStripMenuItem.Click += new System.EventHandler(this.editDeckToolStripMenuItem_Click);
            // 
            // deleteDeckToolStripMenuItem
            // 
            this.deleteDeckToolStripMenuItem.Name = "deleteDeckToolStripMenuItem";
            this.deleteDeckToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.deleteDeckToolStripMenuItem.Text = "&Delete Selected Deck";
            this.deleteDeckToolStripMenuItem.Click += new System.EventHandler(this.deleteDeckToolStripMenuItem_Click);
            // 
            // learnToolStripMenuItem
            // 
            this.learnToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.quizOnDeckToolStripMenuItem});
            this.learnToolStripMenuItem.Name = "learnToolStripMenuItem";
            this.learnToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.learnToolStripMenuItem.Text = "&Learn";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.viewToolStripMenuItem.Text = "&View Selected Deck";
            // 
            // quizOnDeckToolStripMenuItem
            // 
            this.quizOnDeckToolStripMenuItem.Name = "quizOnDeckToolStripMenuItem";
            this.quizOnDeckToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.quizOnDeckToolStripMenuItem.Text = "&Quiz on Selected Deck";
            this.quizOnDeckToolStripMenuItem.Click += new System.EventHandler(this.quizOnDeckToolStripMenuItem_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem});
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.networkToolStripMenuItem.Text = "Co&nnect";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.connectToolStripMenuItem.Text = "&Log in to eFlash Network...";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuHelpToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // mainMenuHelpToolStripMenuItem
            // 
            this.mainMenuHelpToolStripMenuItem.Name = "mainMenuHelpToolStripMenuItem";
            this.mainMenuHelpToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.mainMenuHelpToolStripMenuItem.Text = "&How to use the main menu";
            this.mainMenuHelpToolStripMenuItem.Click += new System.EventHandler(this.mainMenuHelpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.aboutToolStripMenuItem.Text = "&About eFlash";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // treeView_localdecks
            // 
            this.treeView_localdecks.Location = new System.Drawing.Point(15, 82);
            this.treeView_localdecks.Name = "treeView_localdecks";
            this.treeView_localdecks.Size = new System.Drawing.Size(455, 431);
            this.treeView_localdecks.TabIndex = 1;
            this.toolTip1.SetToolTip(this.treeView_localdecks, "Select a Deck");
            this.treeView_localdecks.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_localdecks_AfterSelect);
            // 
            // button_net
            // 
            this.button_net.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_net.Image = global::eFlash.Properties.Resources.Menu_connect;
            this.button_net.Location = new System.Drawing.Point(476, 413);
            this.button_net.Name = "button_net";
            this.button_net.Size = new System.Drawing.Size(100, 100);
            this.button_net.TabIndex = 8;
            this.toolTip1.SetToolTip(this.button_net, "Connect to eFlash Network");
            this.button_net.UseVisualStyleBackColor = true;
            this.button_net.Click += new System.EventHandler(this.button_net_Click);
            // 
            // label_selectdeck
            // 
            this.label_selectdeck.AutoSize = true;
            this.label_selectdeck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_selectdeck.Location = new System.Drawing.Point(12, 66);
            this.label_selectdeck.Name = "label_selectdeck";
            this.label_selectdeck.Size = new System.Drawing.Size(159, 13);
            this.label_selectdeck.TabIndex = 12;
            this.label_selectdeck.Text = "Select decks from the list below:";
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.Location = new System.Drawing.Point(12, 39);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(236, 13);
            this.label_welcome.TabIndex = 11;
            this.label_welcome.Text = "Welcome, .  What would you like to learn today?";
            // 
            // button_create
            // 
            this.button_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.Image = global::eFlash.Properties.Resources.Menu_create;
            this.button_create.Location = new System.Drawing.Point(476, 95);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(100, 100);
            this.button_create.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button_create, "Create New Deck");
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_edit
            // 
            this.button_edit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_edit.Image = global::eFlash.Properties.Resources.Menu_edit;
            this.button_edit.Location = new System.Drawing.Point(582, 95);
            this.button_edit.Name = "button_edit";
            this.button_edit.Size = new System.Drawing.Size(100, 100);
            this.button_edit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.button_edit, "Edit Selected Deck");
            this.button_edit.UseVisualStyleBackColor = true;
            this.button_edit.Click += new System.EventHandler(this.button_edit_Click);
            // 
            // button_view
            // 
            this.button_view.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_view.Image = global::eFlash.Properties.Resources.Menu_view;
            this.button_view.Location = new System.Drawing.Point(582, 202);
            this.button_view.Name = "button_view";
            this.button_view.Size = new System.Drawing.Size(100, 100);
            this.button_view.TabIndex = 5;
            this.toolTip1.SetToolTip(this.button_view, "View Selected Deck");
            this.button_view.UseVisualStyleBackColor = true;
            this.button_view.Click += new System.EventHandler(this.button_view_Click);
            // 
            // button_quiz
            // 
            this.button_quiz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_quiz.Image = global::eFlash.Properties.Resources.Menu_quiz;
            this.button_quiz.Location = new System.Drawing.Point(582, 307);
            this.button_quiz.Name = "button_quiz";
            this.button_quiz.Size = new System.Drawing.Size(100, 100);
            this.button_quiz.TabIndex = 7;
            this.toolTip1.SetToolTip(this.button_quiz, "Quiz on Selected Deck");
            this.button_quiz.UseVisualStyleBackColor = true;
            this.button_quiz.Click += new System.EventHandler(this.button_quiz_Click);
            // 
            // button_export
            // 
            this.button_export.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_export.Image = global::eFlash.Properties.Resources.Menu_export;
            this.button_export.Location = new System.Drawing.Point(476, 307);
            this.button_export.Name = "button_export";
            this.button_export.Size = new System.Drawing.Size(100, 100);
            this.button_export.TabIndex = 6;
            this.toolTip1.SetToolTip(this.button_export, "Export Deck to PowerPoint");
            this.button_export.UseVisualStyleBackColor = true;
            this.button_export.Click += new System.EventHandler(this.button_export_Click);
            // 
            // button_del
            // 
            this.button_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_del.Image = global::eFlash.Properties.Resources.Menu_delete;
            this.button_del.Location = new System.Drawing.Point(582, 413);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(100, 100);
            this.button_del.TabIndex = 9;
            this.toolTip1.SetToolTip(this.button_del, "Delete Selected Deck");
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // button_import
            // 
            this.button_import.Image = global::eFlash.Properties.Resources.Menu_import;
            this.button_import.Location = new System.Drawing.Point(476, 202);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(100, 100);
            this.button_import.TabIndex = 4;
            this.toolTip1.SetToolTip(this.button_import, "Import Deck from File");
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // listSet
            // 
            this.listSet.Location = new System.Drawing.Point(356, 82);
            this.listSet.Name = "listSet";
            this.listSet.Size = new System.Drawing.Size(90, 30);
            this.listSet.TabIndex = 13;
            this.listSet.vmode = eFlash.GUI.ListSet.ViewMode.Cat;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 525);
            this.Controls.Add(this.listSet);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_export);
            this.Controls.Add(this.button_quiz);
            this.Controls.Add(this.button_view);
            this.Controls.Add(this.button_edit);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.label_selectdeck);
            this.Controls.Add(this.button_net);
            this.Controls.Add(this.treeView_localdecks);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "eFlash Multimedia Flash Card Suite";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.main_FormClosed);
            this.VisibleChanged += new System.EventHandler(this.main_VisibleChanged);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem switchProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView_localdecks;
        private System.Windows.Forms.Button button_net;
        private System.Windows.Forms.Label label_selectdeck;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_edit;
        private System.Windows.Forms.Button button_view;
        private System.Windows.Forms.Button button_quiz;
        private System.Windows.Forms.Button button_export;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDeckWithCreatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importDeckFromFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem learnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quizOnDeckToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mainMenuHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip1;
        private ListSet listSet;
        private System.Windows.Forms.ToolStripMenuItem exportDeckToPowerPointToolStripMenuItem;
    }
}
