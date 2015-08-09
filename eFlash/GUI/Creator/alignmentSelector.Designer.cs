namespace eFlash.GUI.Creator
{
	partial class AlignmentSelector
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
			this.btnCenter = new System.Windows.Forms.Button();
			this.btnRight = new System.Windows.Forms.Button();
			this.btnLeft = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCenter
			// 
			this.btnCenter.BackgroundImage = global::eFlash.Properties.Resources.alignCenter;
			this.btnCenter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnCenter.FlatAppearance.BorderSize = 0;
			this.btnCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCenter.Location = new System.Drawing.Point(24, 0);
			this.btnCenter.Name = "btnCenter";
			this.btnCenter.Size = new System.Drawing.Size(24, 23);
			this.btnCenter.TabIndex = 0;
			this.btnCenter.UseVisualStyleBackColor = true;
			this.btnCenter.Click += new System.EventHandler(this.btnCenter_Click);
			// 
			// btnRight
			// 
			this.btnRight.BackgroundImage = global::eFlash.Properties.Resources.alignRight;
			this.btnRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRight.FlatAppearance.BorderSize = 0;
			this.btnRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnRight.Location = new System.Drawing.Point(48, 0);
			this.btnRight.Name = "btnRight";
			this.btnRight.Size = new System.Drawing.Size(24, 23);
			this.btnRight.TabIndex = 1;
			this.btnRight.UseVisualStyleBackColor = true;
			this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
			// 
			// btnLeft
			// 
			this.btnLeft.BackgroundImage = global::eFlash.Properties.Resources.alignLeft;
			this.btnLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnLeft.FlatAppearance.BorderSize = 0;
			this.btnLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnLeft.Location = new System.Drawing.Point(0, 0);
			this.btnLeft.Name = "btnLeft";
			this.btnLeft.Size = new System.Drawing.Size(24, 23);
			this.btnLeft.TabIndex = 2;
			this.btnLeft.UseVisualStyleBackColor = true;
			this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
			// 
			// AlignmentSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.btnLeft);
			this.Controls.Add(this.btnRight);
			this.Controls.Add(this.btnCenter);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "AlignmentSelector";
			this.Size = new System.Drawing.Size(73, 25);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCenter;
		private System.Windows.Forms.Button btnRight;
		private System.Windows.Forms.Button btnLeft;
	}
}
