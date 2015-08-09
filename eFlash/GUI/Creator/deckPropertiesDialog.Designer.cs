namespace eFlash.GUI.Creator
{
	partial class DeckPropertiesDialog
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCategory = new System.Windows.Forms.TextBox();
			this.txtSubcategory = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.grpType = new System.Windows.Forms.GroupBox();
			this.rdText = new System.Windows.Forms.RadioButton();
			this.rdImage = new System.Windows.Forms.RadioButton();
			this.rdAudio = new System.Windows.Forms.RadioButton();
			this.rdNoQuiz = new System.Windows.Forms.RadioButton();
			this.grpType.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(30, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Title:";
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(86, 10);
			this.txtTitle.MaxLength = 255;
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.Size = new System.Drawing.Size(240, 20);
			this.txtTitle.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 39);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Category:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(10, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "Subcategory;";
			// 
			// txtCategory
			// 
			this.txtCategory.Location = new System.Drawing.Point(86, 36);
			this.txtCategory.MaxLength = 255;
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Size = new System.Drawing.Size(240, 20);
			this.txtCategory.TabIndex = 4;
			// 
			// txtSubcategory
			// 
			this.txtSubcategory.Location = new System.Drawing.Point(86, 62);
			this.txtSubcategory.MaxLength = 255;
			this.txtSubcategory.Name = "txtSubcategory";
			this.txtSubcategory.Size = new System.Drawing.Size(240, 20);
			this.txtSubcategory.TabIndex = 5;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(251, 163);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(170, 163);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 7;
			this.btnOk.Text = "Save";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// grpType
			// 
			this.grpType.Controls.Add(this.rdNoQuiz);
			this.grpType.Controls.Add(this.rdAudio);
			this.grpType.Controls.Add(this.rdImage);
			this.grpType.Controls.Add(this.rdText);
			this.grpType.Location = new System.Drawing.Point(12, 88);
			this.grpType.Name = "grpType";
			this.grpType.Size = new System.Drawing.Size(314, 69);
			this.grpType.TabIndex = 8;
			this.grpType.TabStop = false;
			this.grpType.Text = "Type";
			// 
			// rdText
			// 
			this.rdText.AutoSize = true;
			this.rdText.Location = new System.Drawing.Point(14, 19);
			this.rdText.Name = "rdText";
			this.rdText.Size = new System.Drawing.Size(89, 17);
			this.rdText.TabIndex = 0;
			this.rdText.TabStop = true;
			this.rdText.Text = "Text-quizzible";
			this.rdText.UseVisualStyleBackColor = true;
			// 
			// rdImage
			// 
			this.rdImage.AutoSize = true;
			this.rdImage.Location = new System.Drawing.Point(111, 19);
			this.rdImage.Name = "rdImage";
			this.rdImage.Size = new System.Drawing.Size(97, 17);
			this.rdImage.TabIndex = 1;
			this.rdImage.TabStop = true;
			this.rdImage.Text = "Image-quizzible";
			this.rdImage.UseVisualStyleBackColor = true;
			// 
			// rdAudio
			// 
			this.rdAudio.AutoSize = true;
			this.rdAudio.Location = new System.Drawing.Point(213, 19);
			this.rdAudio.Name = "rdAudio";
			this.rdAudio.Size = new System.Drawing.Size(95, 17);
			this.rdAudio.TabIndex = 9;
			this.rdAudio.TabStop = true;
			this.rdAudio.Text = "Audio-quizzible";
			this.rdAudio.UseVisualStyleBackColor = true;
			// 
			// rdNoQuiz
			// 
			this.rdNoQuiz.AutoSize = true;
			this.rdNoQuiz.Location = new System.Drawing.Point(93, 42);
			this.rdNoQuiz.Name = "rdNoQuiz";
			this.rdNoQuiz.Size = new System.Drawing.Size(136, 17);
			this.rdNoQuiz.TabIndex = 10;
			this.rdNoQuiz.TabStop = true;
			this.rdNoQuiz.Text = "Free form (not quizzible)";
			this.rdNoQuiz.UseVisualStyleBackColor = true;
			// 
			// DeckPropertiesDialog
			// 
			this.AcceptButton = this.btnOk;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(338, 194);
			this.Controls.Add(this.grpType);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtSubcategory);
			this.Controls.Add(this.txtCategory);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtTitle);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "DeckPropertiesDialog";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Deck properties";
			this.grpType.ResumeLayout(false);
			this.grpType.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCategory;
		private System.Windows.Forms.TextBox txtSubcategory;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.GroupBox grpType;
		private System.Windows.Forms.RadioButton rdNoQuiz;
		private System.Windows.Forms.RadioButton rdAudio;
		private System.Windows.Forms.RadioButton rdImage;
		private System.Windows.Forms.RadioButton rdText;
	}
}
