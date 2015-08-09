namespace eFlash.GUI.ViewerAndQuizzer
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.Previous = new System.Windows.Forms.Button();
            this.Flip = new System.Windows.Forms.Button();
            this.Next = new System.Windows.Forms.Button();
            this.side = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.LastCard = new System.Windows.Forms.Button();
            this.FirstCard = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Previous
            // 
            this.Previous.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Previous.Image = global::eFlash.Properties.Resources.View_prev;
            this.Previous.Location = new System.Drawing.Point(165, 447);
            this.Previous.Name = "Previous";
            this.Previous.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Previous.Size = new System.Drawing.Size(74, 66);
            this.Previous.TabIndex = 1;
            this.toolTip1.SetToolTip(this.Previous, "Previous Card");
            this.Previous.UseVisualStyleBackColor = true;
            this.Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // Flip
            // 
            this.Flip.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Flip.Image = global::eFlash.Properties.Resources.View_flip;
            this.Flip.Location = new System.Drawing.Point(301, 446);
            this.Flip.Name = "Flip";
            this.Flip.Size = new System.Drawing.Size(76, 67);
            this.Flip.TabIndex = 2;
            this.toolTip1.SetToolTip(this.Flip, "Flip Card");
            this.Flip.UseVisualStyleBackColor = true;
            this.Flip.Click += new System.EventHandler(this.Flip_Click);
            // 
            // Next
            // 
            this.Next.Image = global::eFlash.Properties.Resources.View_next;
            this.Next.Location = new System.Drawing.Point(436, 446);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(74, 66);
            this.Next.TabIndex = 7;
            this.toolTip1.SetToolTip(this.Next, "Next Card");
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // side
            // 
            this.side.AutoSize = true;
            this.side.Location = new System.Drawing.Point(487, 9);
            this.side.Name = "side";
            this.side.Size = new System.Drawing.Size(23, 12);
            this.side.TabIndex = 8;
            this.side.Text = "side";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(29, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 400);
            this.panel1.TabIndex = 9;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_2);
            // 
            // LastCard
            // 
            this.LastCard.BackgroundImage = global::eFlash.Properties.Resources.View_first;
            this.LastCard.Location = new System.Drawing.Point(29, 447);
            this.LastCard.Name = "LastCard";
            this.LastCard.Size = new System.Drawing.Size(71, 66);
            this.LastCard.TabIndex = 10;
            this.LastCard.UseVisualStyleBackColor = true;
            this.LastCard.Click += new System.EventHandler(this.LastCard_Click);
            // 
            // FirstCard
            // 
            this.FirstCard.BackgroundImage = global::eFlash.Properties.Resources.View_last;
            this.FirstCard.Location = new System.Drawing.Point(559, 446);
            this.FirstCard.Name = "FirstCard";
            this.FirstCard.Size = new System.Drawing.Size(70, 66);
            this.FirstCard.TabIndex = 11;
            this.FirstCard.UseVisualStyleBackColor = true;
            this.FirstCard.Click += new System.EventHandler(this.FirstCard_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 12;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "How to Use";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 521);
            this.Controls.Add(this.LastCard);
            this.Controls.Add(this.FirstCard);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.side);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.Flip);
            this.Controls.Add(this.Previous);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Viewer";
            this.Text = "Viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Viewer_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        void Viewer_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            this.clearCard();
            prevWin.Show();
        }

        #endregion

        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.Button Flip;
        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Label side;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button LastCard;
        private System.Windows.Forms.Button FirstCard;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}