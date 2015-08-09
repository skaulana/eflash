namespace eFlash.GUI.File
{
    partial class importscreen5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(importscreen5));
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Import = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(189, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 80);
            this.label5.TabIndex = 10;
            this.label5.Text = "Thank you! Import is almost complete.\r\n\r\nThese cards will be appended to the\r\ncur" +
                "rent deck when you press Finish\r\nand Import.";
            // 
            // btn_Import
            // 
            this.btn_Import.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Import.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Import.Location = new System.Drawing.Point(301, 180);
            this.btn_Import.Name = "btn_Import";
            this.btn_Import.Size = new System.Drawing.Size(120, 26);
            this.btn_Import.TabIndex = 14;
            this.btn_Import.Text = "Finish and Import";
            this.btn_Import.UseVisualStyleBackColor = true;
            this.btn_Import.Click += new System.EventHandler(this.btn_Import_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Back.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Back.Location = new System.Drawing.Point(206, 180);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(89, 26);
            this.btn_Back.TabIndex = 15;
            this.btn_Back.Text = "Back";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // importscreen5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::eFlash.Properties.Resources.Import;
            this.ClientSize = new System.Drawing.Size(450, 218);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Import);
            this.Controls.Add(this.label5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "importscreen5";
            this.Text = "Import From File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_Import;
        private System.Windows.Forms.Button btn_Back;
    }
}