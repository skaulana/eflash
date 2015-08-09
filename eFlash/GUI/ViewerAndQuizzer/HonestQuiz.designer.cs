namespace eFlash.GUI.ViewerAndQuizzer
{
    partial class HonestQuiz
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HonestQuiz));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.answer_button = new System.Windows.Forms.Button();
            this.correct_button = new System.Windows.Forms.Button();
            this.incorrect_button = new System.Windows.Forms.Button();
            this.Answer_box = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PMingLiU", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(31, 167);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 29);
            this.label2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PMingLiU", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(113, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 48);
            this.label1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(44, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 336);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.DetectUrls = false;
            this.richTextBox1.Location = new System.Drawing.Point(45, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox1.Size = new System.Drawing.Size(349, 264);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(168, 138);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(72, 42);
            this.button2.TabIndex = 15;
            this.button2.Text = "Play";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // answer_button
            // 
            this.answer_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer_button.Location = new System.Drawing.Point(45, 431);
            this.answer_button.Name = "answer_button";
            this.answer_button.Size = new System.Drawing.Size(136, 47);
            this.answer_button.TabIndex = 16;
            this.answer_button.Text = "Answer";
            this.answer_button.UseVisualStyleBackColor = true;
            this.answer_button.Click += new System.EventHandler(this.answer_button_Click);
            // 
            // correct_button
            // 
            this.correct_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.correct_button.Location = new System.Drawing.Point(221, 431);
            this.correct_button.Name = "correct_button";
            this.correct_button.Size = new System.Drawing.Size(136, 47);
            this.correct_button.TabIndex = 17;
            this.correct_button.Text = "correct and Next";
            this.correct_button.UseVisualStyleBackColor = true;
            this.correct_button.Click += new System.EventHandler(this.correct_button_Click);
            // 
            // incorrect_button
            // 
            this.incorrect_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.incorrect_button.Location = new System.Drawing.Point(389, 431);
            this.incorrect_button.Name = "incorrect_button";
            this.incorrect_button.Size = new System.Drawing.Size(136, 47);
            this.incorrect_button.TabIndex = 18;
            this.incorrect_button.Text = "Incorrect and Next";
            this.incorrect_button.UseVisualStyleBackColor = true;
            this.incorrect_button.Click += new System.EventHandler(this.incorrect_button_Click);
            // 
            // Answer_box
            // 
            this.Answer_box.BackColor = System.Drawing.Color.White;
            this.Answer_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Answer_box.DetectUrls = false;
            this.Answer_box.Location = new System.Drawing.Point(411, 43);
            this.Answer_box.Name = "Answer_box";
            this.Answer_box.ReadOnly = true;
            this.Answer_box.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.Answer_box.Size = new System.Drawing.Size(254, 336);
            this.Answer_box.TabIndex = 19;
            this.Answer_box.TabStop = false;
            this.Answer_box.Text = "";
            this.Answer_box.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(496, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 29);
            this.label4.TabIndex = 21;
            this.label4.Text = "Answer";
            // 
            // HonestQuiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 521);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Answer_box);
            this.Controls.Add(this.incorrect_button);
            this.Controls.Add(this.correct_button);
            this.Controls.Add(this.answer_button);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HonestQuiz";
            this.Text = "Honest Quiz";
            this.Load += new System.EventHandler(this.HonestQuiz_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.HonestQuiz_FormClosed);
        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button answer_button;
        private System.Windows.Forms.Button correct_button;
        private System.Windows.Forms.Button incorrect_button;
        private System.Windows.Forms.RichTextBox Answer_box;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}