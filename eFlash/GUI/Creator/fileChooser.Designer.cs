namespace eFlash.GUI.Creator
{
	partial class FileChooser
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(0, 1);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(250, 20);
			this.txtPath.TabIndex = 0;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(250, -2);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 23);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// FileChooser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtPath);
			this.Name = "FileChooser";
			this.Size = new System.Drawing.Size(327, 22);
			this.Enter += new System.EventHandler(this.FileChooser_Enter);
			this.Leave += new System.EventHandler(this.FileChooser_Leave);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnBrowse;
	}
}
