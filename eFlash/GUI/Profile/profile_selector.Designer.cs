namespace eFlash.GUI.Profile
{
    partial class profile_selector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(profile_selector));
            this.comboBox_name = new System.Windows.Forms.ComboBox();
            this.label_profile = new System.Windows.Forms.Label();
            this.label_pw = new System.Windows.Forms.Label();
            this.textBox_pw = new System.Windows.Forms.TextBox();
            this.checkBox_savepw = new System.Windows.Forms.CheckBox();
            this.checkBox_autolog = new System.Windows.Forms.CheckBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_create = new System.Windows.Forms.Button();
            this.button_del = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_name
            // 
            this.comboBox_name.FormattingEnabled = true;
            this.comboBox_name.Location = new System.Drawing.Point(114, 98);
            this.comboBox_name.Name = "comboBox_name";
            this.comboBox_name.Size = new System.Drawing.Size(176, 21);
            this.comboBox_name.TabIndex = 0;
            this.comboBox_name.SelectedIndexChanged += new System.EventHandler(this.comboBox_name_SelectedIndexChanged);
            // 
            // label_profile
            // 
            this.label_profile.AutoSize = true;
            this.label_profile.BackColor = System.Drawing.Color.Transparent;
            this.label_profile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_profile.Location = new System.Drawing.Point(14, 99);
            this.label_profile.Name = "label_profile";
            this.label_profile.Size = new System.Drawing.Size(86, 16);
            this.label_profile.TabIndex = 8;
            this.label_profile.Text = "Profile Name";
            this.label_profile.Click += new System.EventHandler(this.label_profile_Click);
            // 
            // label_pw
            // 
            this.label_pw.AutoSize = true;
            this.label_pw.BackColor = System.Drawing.Color.Transparent;
            this.label_pw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_pw.Location = new System.Drawing.Point(14, 126);
            this.label_pw.Name = "label_pw";
            this.label_pw.Size = new System.Drawing.Size(68, 16);
            this.label_pw.TabIndex = 9;
            this.label_pw.Text = "Password";
            // 
            // textBox_pw
            // 
            this.textBox_pw.Location = new System.Drawing.Point(114, 125);
            this.textBox_pw.Name = "textBox_pw";
            this.textBox_pw.PasswordChar = '*';
            this.textBox_pw.Size = new System.Drawing.Size(176, 20);
            this.textBox_pw.TabIndex = 1;
            // 
            // checkBox_savepw
            // 
            this.checkBox_savepw.AutoSize = true;
            this.checkBox_savepw.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_savepw.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_savepw.Location = new System.Drawing.Point(114, 156);
            this.checkBox_savepw.Name = "checkBox_savepw";
            this.checkBox_savepw.Size = new System.Drawing.Size(121, 20);
            this.checkBox_savepw.TabIndex = 2;
            this.checkBox_savepw.Text = "Save password";
            this.checkBox_savepw.UseVisualStyleBackColor = false;
            // 
            // checkBox_autolog
            // 
            this.checkBox_autolog.AutoSize = true;
            this.checkBox_autolog.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_autolog.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_autolog.Location = new System.Drawing.Point(114, 177);
            this.checkBox_autolog.Name = "checkBox_autolog";
            this.checkBox_autolog.Size = new System.Drawing.Size(142, 20);
            this.checkBox_autolog.TabIndex = 3;
            this.checkBox_autolog.Text = "Automatically log in";
            this.checkBox_autolog.UseVisualStyleBackColor = false;
            // 
            // button_login
            // 
            this.button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_login.Location = new System.Drawing.Point(352, 98);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(150, 30);
            this.button_login.TabIndex = 4;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_create
            // 
            this.button_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_create.Location = new System.Drawing.Point(352, 134);
            this.button_create.Name = "button_create";
            this.button_create.Size = new System.Drawing.Size(150, 30);
            this.button_create.TabIndex = 5;
            this.button_create.Text = "Create Profile";
            this.button_create.UseVisualStyleBackColor = true;
            this.button_create.Click += new System.EventHandler(this.button_create_Click);
            // 
            // button_del
            // 
            this.button_del.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_del.Location = new System.Drawing.Point(352, 170);
            this.button_del.Name = "button_del";
            this.button_del.Size = new System.Drawing.Size(150, 30);
            this.button_del.TabIndex = 6;
            this.button_del.Text = "Delete Profile";
            this.button_del.UseVisualStyleBackColor = true;
            this.button_del.Click += new System.EventHandler(this.button_del_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "To begin, select a name from the list, or type a new one.";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // profile_selector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::eFlash.Properties.Resources.Profile;
            this.ClientSize = new System.Drawing.Size(514, 218);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_del);
            this.Controls.Add(this.button_create);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.checkBox_autolog);
            this.Controls.Add(this.checkBox_savepw);
            this.Controls.Add(this.textBox_pw);
            this.Controls.Add(this.label_pw);
            this.Controls.Add(this.label_profile);
            this.Controls.Add(this.comboBox_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "profile_selector";
            this.Text = "Profile Selection";
            this.Activated += new System.EventHandler(this.profile_selector_Activated);
            this.Load += new System.EventHandler(this.profile_selector_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_name;
        private System.Windows.Forms.Label label_profile;
        private System.Windows.Forms.Label label_pw;
        private System.Windows.Forms.TextBox textBox_pw;
        private System.Windows.Forms.CheckBox checkBox_savepw;
        private System.Windows.Forms.CheckBox checkBox_autolog;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_create;
        private System.Windows.Forms.Button button_del;
        private System.Windows.Forms.Label label1;
    }
}