namespace eFlash.GUI.Creator
{
	partial class TemplateSelector
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
			this.components = new System.ComponentModel.Container();
			this.panelTemplates = new System.Windows.Forms.FlowLayoutPanel();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.SuspendLayout();
			// 
			// panelTemplates
			// 
			this.panelTemplates.AutoSize = true;
			this.panelTemplates.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
			this.panelTemplates.Location = new System.Drawing.Point(1, 2);
			this.panelTemplates.Margin = new System.Windows.Forms.Padding(0);
			this.panelTemplates.Name = "panelTemplates";
			this.panelTemplates.Size = new System.Drawing.Size(60, 148);
			this.panelTemplates.TabIndex = 0;
			this.panelTemplates.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.panelTemplates_ControlRemoved);
			this.panelTemplates.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panelTemplates_ControlAdded);
			// 
			// TemplateSelector
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Transparent;
			this.Controls.Add(this.panelTemplates);
			this.Name = "TemplateSelector";
			this.Size = new System.Drawing.Size(62, 150);
			this.SizeChanged += new System.EventHandler(this.TemplateSelector_SizeChanged);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.FlowLayoutPanel panelTemplates;
		private System.Windows.Forms.ToolTip toolTip;
	}
}
