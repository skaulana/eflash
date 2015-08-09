namespace eFlash.GUI.ViewerAndQuizzer
{
    partial class VisualViewer
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
            this.Next = new System.Windows.Forms.Button();
            this.flip = new System.Windows.Forms.Button();
            this.Previous = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Stop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // Next
            // 
            this.Next.Image = global::eFlash.Properties.Resources.arrow_right2;
            this.Next.Location = new System.Drawing.Point(431, 345);
            this.Next.Name = "Next";
            this.Next.Size = new System.Drawing.Size(69, 67);
            this.Next.TabIndex = 10;
            this.Next.UseVisualStyleBackColor = true;
            this.Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // flip
            // 
            this.flip.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flip.Image = global::eFlash.Properties.Resources.flip;
            this.flip.Location = new System.Drawing.Point(264, 345);
            this.flip.Name = "flip";
            this.flip.Size = new System.Drawing.Size(76, 67);
            this.flip.TabIndex = 9;
            this.flip.UseVisualStyleBackColor = true;
            this.flip.Click += new System.EventHandler(this.flip_Click);
            // 
            // Previous
            // 
            this.Previous.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Previous.Image = global::eFlash.Properties.Resources.arrow_left2;
            this.Previous.Location = new System.Drawing.Point(89, 345);
            this.Previous.Name = "Previous";
            this.Previous.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Previous.Size = new System.Drawing.Size(69, 67);
            this.Previous.TabIndex = 8;
            this.Previous.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(58, 94);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(78, 71);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(357, 25);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(61, 39);
            this.Play.TabIndex = 13;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(307, 94);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(111, 90);
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(440, 25);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(60, 39);
            this.Stop.TabIndex = 15;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // VisualViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 424);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.Next);
            this.Controls.Add(this.flip);
            this.Controls.Add(this.Previous);
            this.Name = "VisualViewer";
            this.Text = "VisualViewer";
            this.Load += new System.EventHandler(this.VisualViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Next;
        private System.Windows.Forms.Button flip;
        private System.Windows.Forms.Button Previous;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button Stop;
    }
}