namespace eFlash.GUI.Creator
{
	partial class LayoutEditor
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LayoutEditor));
			this.tsObjects = new System.Windows.Forms.ToolStrip();
			this.btnTextbox = new System.Windows.Forms.ToolStripButton();
			this.btnImage = new System.Windows.Forms.ToolStripButton();
			this.btnAudio = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.ddlFont = new System.Windows.Forms.ComboBox();
			this.contextMenuTabs = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ddlSize = new System.Windows.Forms.ComboBox();
			this.btnFont = new System.Windows.Forms.Button();
			this.btnColor = new System.Windows.Forms.Button();
			this.btnSaveAndNext = new System.Windows.Forms.Button();
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
			this.importFromFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.addNewSideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteSideToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteFlashcardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.flashcardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.howToUseTheCreatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabSides = new System.Windows.Forms.TabControl();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnPrev = new System.Windows.Forms.Button();
			this.btnFront = new System.Windows.Forms.Button();
			this.btnEnd = new System.Windows.Forms.Button();
			this.lblCardLabel = new System.Windows.Forms.Label();
			this.lblCurCard = new System.Windows.Forms.Label();
			this.btnNewCard = new System.Windows.Forms.Button();
			this.ttNavButtons = new System.Windows.Forms.ToolTip(this.components);
			this.alignmentSelector = new eFlash.GUI.Creator.AlignmentSelector();
			this.tsObjects.SuspendLayout();
			this.contextMenuTabs.SuspendLayout();
			this.menuStrip.SuspendLayout();
			this.tabSides.SuspendLayout();
			this.SuspendLayout();
			// 
			// tsObjects
			// 
			this.tsObjects.Dock = System.Windows.Forms.DockStyle.None;
			this.tsObjects.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tsObjects.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnTextbox,
            this.btnImage,
            this.btnAudio});
			this.tsObjects.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.tsObjects.Location = new System.Drawing.Point(0, 49);
			this.tsObjects.Name = "tsObjects";
			this.tsObjects.Size = new System.Drawing.Size(52, 62);
			this.tsObjects.TabIndex = 0;
			// 
			// btnTextbox
			// 
			this.btnTextbox.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnTextbox.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnTextbox.Name = "btnTextbox";
			this.btnTextbox.Size = new System.Drawing.Size(50, 17);
			this.btnTextbox.Text = "Textbox";
			this.btnTextbox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnTextbox_MouseDown);
			// 
			// btnImage
			// 
			this.btnImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnImage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnImage.Name = "btnImage";
			this.btnImage.Size = new System.Drawing.Size(50, 17);
			this.btnImage.Text = "Image";
			this.btnImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnImage_MouseDown);
			// 
			// btnAudio
			// 
			this.btnAudio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btnAudio.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnAudio.Name = "btnAudio";
			this.btnAudio.Size = new System.Drawing.Size(50, 17);
			this.btnAudio.Text = "Audio";
			this.btnAudio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnAudio_MouseDown);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(76, 13);
			this.toolStripLabel1.Text = "toolStripLabel1";
			// 
			// ddlFont
			// 
			this.ddlFont.FormattingEnabled = true;
			this.ddlFont.Location = new System.Drawing.Point(290, 27);
			this.ddlFont.Name = "ddlFont";
			this.ddlFont.Size = new System.Drawing.Size(122, 21);
			this.ddlFont.TabIndex = 110;
			this.ddlFont.Leave += new System.EventHandler(this.ddlFont_Leave);
			this.ddlFont.SelectedIndexChanged += new System.EventHandler(this.fontSelectionChanged);
			// 
			// contextMenuTabs
			// 
			this.contextMenuTabs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTabToolStripMenuItem,
            this.deleteSideToolStripMenuItem});
			this.contextMenuTabs.Name = "contextMenuStrip1";
			this.contextMenuTabs.Size = new System.Drawing.Size(128, 48);
			// 
			// newTabToolStripMenuItem
			// 
			this.newTabToolStripMenuItem.Name = "newTabToolStripMenuItem";
			this.newTabToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.newTabToolStripMenuItem.Text = "New side";
			this.newTabToolStripMenuItem.Click += new System.EventHandler(this.newTabToolStripMenuItem_Click);
			// 
			// deleteSideToolStripMenuItem
			// 
			this.deleteSideToolStripMenuItem.Name = "deleteSideToolStripMenuItem";
			this.deleteSideToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.deleteSideToolStripMenuItem.Text = "Delete side";
			this.deleteSideToolStripMenuItem.Click += new System.EventHandler(this.deleteSideToolStripMenuItem_Click);
			// 
			// ddlSize
			// 
			this.ddlSize.FormattingEnabled = true;
			this.ddlSize.Location = new System.Drawing.Point(417, 27);
			this.ddlSize.Name = "ddlSize";
			this.ddlSize.Size = new System.Drawing.Size(45, 21);
			this.ddlSize.TabIndex = 111;
			this.ddlSize.SelectedIndexChanged += new System.EventHandler(this.fontSelectionChanged);
			// 
			// btnFont
			// 
			this.btnFont.Location = new System.Drawing.Point(542, 25);
			this.btnFont.Name = "btnFont";
			this.btnFont.Size = new System.Drawing.Size(53, 23);
			this.btnFont.TabIndex = 112;
			this.btnFont.Text = "Font...";
			this.btnFont.UseVisualStyleBackColor = true;
			this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
			// 
			// btnColor
			// 
			this.btnColor.Location = new System.Drawing.Point(600, 25);
			this.btnColor.Name = "btnColor";
			this.btnColor.Size = new System.Drawing.Size(53, 23);
			this.btnColor.TabIndex = 113;
			this.btnColor.Text = "Color...";
			this.btnColor.UseVisualStyleBackColor = true;
			this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
			// 
			// btnSaveAndNext
			// 
			this.btnSaveAndNext.Location = new System.Drawing.Point(509, 481);
			this.btnSaveAndNext.Name = "btnSaveAndNext";
			this.btnSaveAndNext.Size = new System.Drawing.Size(166, 23);
			this.btnSaveAndNext.TabIndex = 50;
			this.btnSaveAndNext.Text = "Save and next";
			this.btnSaveAndNext.UseVisualStyleBackColor = true;
			this.btnSaveAndNext.Click += new System.EventHandler(this.btnSaveAndNext_Click);
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.deckToolStripMenuItem,
            this.flashcardToolStripMenuItem,
            this.helpToolStripMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(694, 24);
			this.menuStrip.TabIndex = 10;
			this.menuStrip.Text = "menuStrip1";
			// 
			// menuFile
			// 
			this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importFromFileToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.menuItemExit});
			this.menuFile.Name = "menuFile";
			this.menuFile.Size = new System.Drawing.Size(35, 20);
			this.menuFile.Text = "File";
			// 
			// importFromFileToolStripMenuItem
			// 
			this.importFromFileToolStripMenuItem.Enabled = false;
			this.importFromFileToolStripMenuItem.Name = "importFromFileToolStripMenuItem";
			this.importFromFileToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.importFromFileToolStripMenuItem.Text = "Import from file...";
			this.importFromFileToolStripMenuItem.Click += new System.EventHandler(this.importFromFileToolStripMenuItem_Click);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(160, 22);
			this.menuItemExit.Text = "Close";
			this.menuItemExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// menuEdit
			// 
			this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewSideToolStripMenuItem,
            this.deleteSideToolStripMenuItem1,
            this.deleteFlashcardToolStripMenuItem});
			this.menuEdit.Name = "menuEdit";
			this.menuEdit.Size = new System.Drawing.Size(37, 20);
			this.menuEdit.Text = "Edit";
			// 
			// addNewSideToolStripMenuItem
			// 
			this.addNewSideToolStripMenuItem.Name = "addNewSideToolStripMenuItem";
			this.addNewSideToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.addNewSideToolStripMenuItem.Text = "Add new side";
			this.addNewSideToolStripMenuItem.Click += new System.EventHandler(this.newTabToolStripMenuItem_Click);
			// 
			// deleteSideToolStripMenuItem1
			// 
			this.deleteSideToolStripMenuItem1.Name = "deleteSideToolStripMenuItem1";
			this.deleteSideToolStripMenuItem1.Size = new System.Drawing.Size(165, 22);
			this.deleteSideToolStripMenuItem1.Text = "Delete current side";
			this.deleteSideToolStripMenuItem1.Click += new System.EventHandler(this.deleteSideToolStripMenuItem_Click);
			// 
			// deleteFlashcardToolStripMenuItem
			// 
			this.deleteFlashcardToolStripMenuItem.Enabled = false;
			this.deleteFlashcardToolStripMenuItem.Name = "deleteFlashcardToolStripMenuItem";
			this.deleteFlashcardToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
			this.deleteFlashcardToolStripMenuItem.Text = "Delete flashcard";
			this.deleteFlashcardToolStripMenuItem.Click += new System.EventHandler(this.deleteFlashcardToolStripMenuItem_Click);
			// 
			// deckToolStripMenuItem
			// 
			this.deckToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editPropertiesToolStripMenuItem});
			this.deckToolStripMenuItem.Name = "deckToolStripMenuItem";
			this.deckToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
			this.deckToolStripMenuItem.Text = "Deck";
			// 
			// editPropertiesToolStripMenuItem
			// 
			this.editPropertiesToolStripMenuItem.Name = "editPropertiesToolStripMenuItem";
			this.editPropertiesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
			this.editPropertiesToolStripMenuItem.Text = "Properties...";
			this.editPropertiesToolStripMenuItem.Click += new System.EventHandler(this.editPropertiesToolStripMenuItem_Click);
			// 
			// flashcardToolStripMenuItem
			// 
			this.flashcardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tagsToolStripMenuItem});
			this.flashcardToolStripMenuItem.Name = "flashcardToolStripMenuItem";
			this.flashcardToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.flashcardToolStripMenuItem.Text = "Flashcard";
			// 
			// tagsToolStripMenuItem
			// 
			this.tagsToolStripMenuItem.Enabled = false;
			this.tagsToolStripMenuItem.Name = "tagsToolStripMenuItem";
			this.tagsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.tagsToolStripMenuItem.Text = "Tags...";
			this.tagsToolStripMenuItem.Click += new System.EventHandler(this.tagsToolStripMenuItem_Click);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseTheCreatorToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
			this.helpToolStripMenuItem.Text = "Help";
			// 
			// howToUseTheCreatorToolStripMenuItem
			// 
			this.howToUseTheCreatorToolStripMenuItem.Name = "howToUseTheCreatorToolStripMenuItem";
			this.howToUseTheCreatorToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
			this.howToUseTheCreatorToolStripMenuItem.Text = "How to use the creator";
			this.howToUseTheCreatorToolStripMenuItem.Click += new System.EventHandler(this.howToUseTheCreatorToolStripMenuItem_Click);
			// 
			// tabPage2
			// 
			this.tabPage2.AllowDrop = true;
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(600, 400);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Side 2";
			this.tabPage2.UseVisualStyleBackColor = true;
			this.tabPage2.DragOver += new System.Windows.Forms.DragEventHandler(this.canvas_DragOver);
			this.tabPage2.Click += new System.EventHandler(this.canvas_Click);
			this.tabPage2.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
			this.tabPage2.DragEnter += new System.Windows.Forms.DragEventHandler(this.canvas_DragEnter);
			this.tabPage2.DragLeave += new System.EventHandler(this.canvas_DragLeave);
			// 
			// tabPage1
			// 
			this.tabPage1.AllowDrop = true;
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(600, 400);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Side 1";
			this.tabPage1.UseVisualStyleBackColor = true;
			this.tabPage1.DragOver += new System.Windows.Forms.DragEventHandler(this.canvas_DragOver);
			this.tabPage1.Click += new System.EventHandler(this.canvas_Click);
			this.tabPage1.DragDrop += new System.Windows.Forms.DragEventHandler(this.canvas_DragDrop);
			this.tabPage1.DragEnter += new System.Windows.Forms.DragEventHandler(this.canvas_DragEnter);
			this.tabPage1.DragLeave += new System.EventHandler(this.canvas_DragLeave);
			// 
			// tabSides
			// 
			this.tabSides.Controls.Add(this.tabPage1);
			this.tabSides.Controls.Add(this.tabPage2);
			this.tabSides.Location = new System.Drawing.Point(68, 52);
			this.tabSides.Margin = new System.Windows.Forms.Padding(0);
			this.tabSides.Name = "tabSides";
			this.tabSides.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.tabSides.SelectedIndex = 0;
			this.tabSides.Size = new System.Drawing.Size(608, 426);
			this.tabSides.TabIndex = 11;
			this.tabSides.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(328, 481);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(23, 23);
			this.btnNext.TabIndex = 103;
			this.btnNext.Text = ">";
			this.ttNavButtons.SetToolTip(this.btnNext, "Next flashcard");
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnPrev
			// 
			this.btnPrev.Location = new System.Drawing.Point(299, 481);
			this.btnPrev.Name = "btnPrev";
			this.btnPrev.Size = new System.Drawing.Size(23, 23);
			this.btnPrev.TabIndex = 102;
			this.btnPrev.Text = "<";
			this.ttNavButtons.SetToolTip(this.btnPrev, "Previous flashcard");
			this.btnPrev.UseVisualStyleBackColor = true;
			this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
			// 
			// btnFront
			// 
			this.btnFront.Location = new System.Drawing.Point(263, 481);
			this.btnFront.Name = "btnFront";
			this.btnFront.Size = new System.Drawing.Size(30, 23);
			this.btnFront.TabIndex = 101;
			this.btnFront.Text = "<<";
			this.ttNavButtons.SetToolTip(this.btnFront, "Jump to beginning of deck");
			this.btnFront.UseVisualStyleBackColor = true;
			this.btnFront.Click += new System.EventHandler(this.btnFront_Click);
			// 
			// btnEnd
			// 
			this.btnEnd.Location = new System.Drawing.Point(357, 481);
			this.btnEnd.Name = "btnEnd";
			this.btnEnd.Size = new System.Drawing.Size(30, 23);
			this.btnEnd.TabIndex = 104;
			this.btnEnd.Text = ">>";
			this.ttNavButtons.SetToolTip(this.btnEnd, "Jump to end of deck");
			this.btnEnd.UseVisualStyleBackColor = true;
			this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
			// 
			// lblCardLabel
			// 
			this.lblCardLabel.AutoSize = true;
			this.lblCardLabel.Location = new System.Drawing.Point(68, 30);
			this.lblCardLabel.Name = "lblCardLabel";
			this.lblCardLabel.Size = new System.Drawing.Size(32, 13);
			this.lblCardLabel.TabIndex = 114;
			this.lblCardLabel.Text = "Card ";
			// 
			// lblCurCard
			// 
			this.lblCurCard.AutoSize = true;
			this.lblCurCard.Location = new System.Drawing.Point(95, 30);
			this.lblCurCard.Name = "lblCurCard";
			this.lblCurCard.Size = new System.Drawing.Size(24, 13);
			this.lblCurCard.TabIndex = 115;
			this.lblCurCard.Text = "5/7";
			// 
			// btnNewCard
			// 
			this.btnNewCard.Location = new System.Drawing.Point(393, 481);
			this.btnNewCard.Name = "btnNewCard";
			this.btnNewCard.Size = new System.Drawing.Size(110, 23);
			this.btnNewCard.TabIndex = 116;
			this.btnNewCard.Text = "Create new card";
			this.btnNewCard.UseVisualStyleBackColor = true;
			this.btnNewCard.Click += new System.EventHandler(this.btnNewCard_Click);
			// 
			// alignmentSelector
			// 
			this.alignmentSelector.alignment = System.Windows.Forms.HorizontalAlignment.Left;
			this.alignmentSelector.BackColor = System.Drawing.Color.Transparent;
			this.alignmentSelector.Location = new System.Drawing.Point(466, 25);
			this.alignmentSelector.Margin = new System.Windows.Forms.Padding(0);
			this.alignmentSelector.Name = "alignmentSelector";
			this.alignmentSelector.Size = new System.Drawing.Size(73, 25);
			this.alignmentSelector.TabIndex = 0;
			this.alignmentSelector.TabStop = false;
			// 
			// LayoutEditor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(694, 518);
			this.Controls.Add(this.btnNewCard);
			this.Controls.Add(this.lblCurCard);
			this.Controls.Add(this.lblCardLabel);
			this.Controls.Add(this.btnEnd);
			this.Controls.Add(this.btnFront);
			this.Controls.Add(this.btnPrev);
			this.Controls.Add(this.btnNext);
			this.Controls.Add(this.tsObjects);
			this.Controls.Add(this.alignmentSelector);
			this.Controls.Add(this.btnColor);
			this.Controls.Add(this.btnSaveAndNext);
			this.Controls.Add(this.tabSides);
			this.Controls.Add(this.btnFont);
			this.Controls.Add(this.ddlFont);
			this.Controls.Add(this.ddlSize);
			this.Controls.Add(this.menuStrip);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.Name = "LayoutEditor";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "eFlash";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LayoutEditor_FormClosed);
			this.Shown += new System.EventHandler(this.LayoutEditor_Shown);
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayoutEditor_FormClosing);
			this.tsObjects.ResumeLayout(false);
			this.tsObjects.PerformLayout();
			this.contextMenuTabs.ResumeLayout(false);
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			this.tabSides.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tsObjects;
		private System.Windows.Forms.ToolStripButton btnTextbox;
		private System.Windows.Forms.ToolStripButton btnImage;
		private System.Windows.Forms.ToolStripButton btnAudio;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ComboBox ddlFont;
		private System.Windows.Forms.ContextMenuStrip contextMenuTabs;
		private System.Windows.Forms.ComboBox ddlSize;
		private System.Windows.Forms.Button btnFont;
		private System.Windows.Forms.Button btnColor;
		private System.Windows.Forms.Button btnSaveAndNext;
		private AlignmentSelector alignmentSelector;
		private System.Windows.Forms.MenuStrip menuStrip;
		private System.Windows.Forms.ToolStripMenuItem menuFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuEdit;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabSides;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnPrev;
		private System.Windows.Forms.Button btnFront;
		private System.Windows.Forms.Button btnEnd;
		private System.Windows.Forms.ToolStripMenuItem newTabToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteSideToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewSideToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteSideToolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem deckToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editPropertiesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem flashcardToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tagsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importFromFileToolStripMenuItem;
		private System.Windows.Forms.Label lblCardLabel;
		private System.Windows.Forms.Label lblCurCard;
		private System.Windows.Forms.Button btnNewCard;
		private System.Windows.Forms.ToolTip ttNavButtons;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem howToUseTheCreatorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteFlashcardToolStripMenuItem;

	}
}