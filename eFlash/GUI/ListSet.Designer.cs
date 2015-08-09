namespace eFlash.GUI
{
    partial class ListSet
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
            this.button_cat = new System.Windows.Forms.Button();
            this.button_alpha = new System.Windows.Forms.Button();
            this.button_time = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button_cat
            // 
            this.button_cat.BackColor = System.Drawing.Color.Transparent;
            this.button_cat.BackgroundImage = global::eFlash.Properties.Resources.cat_view;
            this.button_cat.Location = new System.Drawing.Point(0, 0);
            this.button_cat.Name = "button_cat";
            this.button_cat.Size = new System.Drawing.Size(30, 30);
            this.button_cat.TabIndex = 0;
            this.toolTip1.SetToolTip(this.button_cat, "Categorical Order");
            this.button_cat.UseVisualStyleBackColor = false;
            this.button_cat.Click += new System.EventHandler(this.button_cat_Click);
            // 
            // button_alpha
            // 
            this.button_alpha.BackColor = System.Drawing.Color.Transparent;
            this.button_alpha.BackgroundImage = global::eFlash.Properties.Resources.alpha_view;
            this.button_alpha.Location = new System.Drawing.Point(30, 0);
            this.button_alpha.Name = "button_alpha";
            this.button_alpha.Size = new System.Drawing.Size(30, 30);
            this.button_alpha.TabIndex = 1;
            this.toolTip1.SetToolTip(this.button_alpha, "Alphabetical Order");
            this.button_alpha.UseVisualStyleBackColor = false;
            this.button_alpha.Click += new System.EventHandler(this.button_alpha_Click);
            // 
            // button_time
            // 
            this.button_time.BackColor = System.Drawing.Color.Transparent;
            this.button_time.BackgroundImage = global::eFlash.Properties.Resources.time_view;
            this.button_time.Location = new System.Drawing.Point(60, 0);
            this.button_time.Name = "button_time";
            this.button_time.Size = new System.Drawing.Size(30, 30);
            this.button_time.TabIndex = 2;
            this.toolTip1.SetToolTip(this.button_time, "Order by Time");
            this.button_time.UseVisualStyleBackColor = false;
            this.button_time.Click += new System.EventHandler(this.button_time_Click);
            // 
            // ListSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_time);
            this.Controls.Add(this.button_alpha);
            this.Controls.Add(this.button_cat);
            this.Name = "ListSet";
            this.Size = new System.Drawing.Size(90, 30);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_cat;
        private System.Windows.Forms.Button button_alpha;
        private System.Windows.Forms.Button button_time;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
