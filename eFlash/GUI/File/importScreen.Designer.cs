namespace eFlash.GUI.File
{
    partial class importscreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importscreen));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBox_Browse = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_delimiter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_noItems = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_Next = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(197, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 80);
            this.label2.TabIndex = 3;
            this.label2.Text = "Welcome!\r\n\r\nThis wizard will guide you through the\r\nprocess of creating a deck ba" +
                "sed off of\r\na text file that you supply.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(425, 48);
            this.label3.TabIndex = 4;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 247);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "For more information, click";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(170, 247);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(35, 16);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "here";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "File*";
            // 
            // txtBox_Browse
            // 
            this.txtBox_Browse.Location = new System.Drawing.Point(64, 314);
            this.txtBox_Browse.Name = "txtBox_Browse";
            this.txtBox_Browse.Size = new System.Drawing.Size(274, 20);
            this.txtBox_Browse.TabIndex = 8;
            // 
            // btn_Browse
            // 
            this.btn_Browse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(344, 312);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(92, 23);
            this.btn_Browse.TabIndex = 9;
            this.btn_Browse.Text = "Browse...";
            this.btn_Browse.UseVisualStyleBackColor = true;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(61, 295);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(272, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Choose the file from which you wish to import:";
            // 
            // comboBox_delimiter
            // 
            this.comboBox_delimiter.FormattingEnabled = true;
            this.comboBox_delimiter.Items.AddRange(new object[] {
            "   (space)",
            ", (comma)",
            "; (semicolon)",
            "% (percent)",
            "/ (slash)"});
            this.comboBox_delimiter.Location = new System.Drawing.Point(318, 381);
            this.comboBox_delimiter.Name = "comboBox_delimiter";
            this.comboBox_delimiter.Size = new System.Drawing.Size(121, 21);
            this.comboBox_delimiter.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 370);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(281, 48);
            this.label7.TabIndex = 12;
            this.label7.Text = "Choose the delimiter that separates the words \r\nfrom the definitions, or the pict" +
                "ures/sound titles\r\nfrom their locations.";
            // 
            // comboBox_noItems
            // 
            this.comboBox_noItems.FormattingEnabled = true;
            this.comboBox_noItems.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6"});
            this.comboBox_noItems.Location = new System.Drawing.Point(318, 453);
            this.comboBox_noItems.Name = "comboBox_noItems";
            this.comboBox_noItems.Size = new System.Drawing.Size(121, 21);
            this.comboBox_noItems.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 458);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(256, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Specify the number of sides for each card.";
            // 
            // btn_Next
            // 
            this.btn_Next.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Next.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.Location = new System.Drawing.Point(318, 493);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(121, 26);
            this.btn_Next.TabIndex = 15;
            this.btn_Next.Text = "Next";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(191, 493);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 26);
            this.button1.TabIndex = 16;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "*required field";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(437, 381);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "*";
            // 
            // importscreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::eFlash.Properties.Resources.Import;
            this.ClientSize = new System.Drawing.Size(460, 531);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_noItems);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_delimiter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.txtBox_Browse);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importscreen";
            this.Text = "Import From File";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.importscreen_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBox_Browse;
        private System.Windows.Forms.Button btn_Browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBox_delimiter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_noItems;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
    }
}