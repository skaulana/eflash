namespace eFlash.GUI.Creator
{
	partial class PlayerControl
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
			this.btnPlay = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.button = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnPlay
			// 
			this.btnPlay.Location = new System.Drawing.Point(26, 22);
			this.btnPlay.Name = "btnPlay";
			this.btnPlay.Size = new System.Drawing.Size(75, 23);
			this.btnPlay.TabIndex = 0;
			this.btnPlay.Text = "Play";
			this.btnPlay.UseVisualStyleBackColor = true;
			this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
			// 
			// btnStop
			// 
			this.btnStop.Location = new System.Drawing.Point(26, 62);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(75, 23);
			this.btnStop.TabIndex = 1;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// button
			// 
			this.button.Enabled = false;
			this.button.Location = new System.Drawing.Point(26, 104);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(75, 23);
			this.button.TabIndex = 2;
			this.button.TabStop = false;
			this.button.UseVisualStyleBackColor = true;
			this.button.Visible = false;
			this.button.Resize += new System.EventHandler(this.button_Resize);
			// 
			// PlayerControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.button);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnPlay);
			this.Margin = new System.Windows.Forms.Padding(0);
			this.Name = "PlayerControl";
			this.Resize += new System.EventHandler(this.PlayerControl_Resize);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnPlay;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.Button button;
	}
}
