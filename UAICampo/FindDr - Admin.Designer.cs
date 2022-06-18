
namespace UAICampo.UI
{
    partial class FindDr___Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_Title_Admin = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_LicenseManager = new System.Windows.Forms.Button();
            this.button_UserManager = new System.Windows.Forms.Button();
            this.button_ProfileManager = new System.Windows.Forms.Button();
            this.button_LanguageManager = new System.Windows.Forms.Button();
            this.languageEditorController1 = new UAICampo.UI.Controllers.LanguageEditorController();
            this.user_Manager1 = new UAICampo.UI.Controllers.User_Manager();
            this.license_Manager1 = new UAICampo.UI.Controllers.License_Manager();
            this.profile_Manager1 = new UAICampo.UI.Controllers.Profile_Manager();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(53)))), ((int)(((byte)(99)))));
            this.panel1.Controls.Add(this.label_Title_Admin);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.button_LicenseManager);
            this.panel1.Controls.Add(this.button_UserManager);
            this.panel1.Controls.Add(this.button_ProfileManager);
            this.panel1.Controls.Add(this.button_LanguageManager);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 645);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label_Title_Admin
            // 
            this.label_Title_Admin.AutoSize = true;
            this.label_Title_Admin.Font = new System.Drawing.Font("BIZ UDGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title_Admin.ForeColor = System.Drawing.Color.White;
            this.label_Title_Admin.Location = new System.Drawing.Point(12, 9);
            this.label_Title_Admin.Name = "label_Title_Admin";
            this.label_Title_Admin.Size = new System.Drawing.Size(76, 21);
            this.label_Title_Admin.TabIndex = 5;
            this.label_Title_Admin.Text = "label1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UAICampo.UI.Properties.Resources.Admin_Profile_PNG_Image;
            this.pictureBox1.Location = new System.Drawing.Point(12, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // button_LicenseManager
            // 
            this.button_LicenseManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_LicenseManager.FlatAppearance.BorderSize = 0;
            this.button_LicenseManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_LicenseManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LicenseManager.Font = new System.Drawing.Font("BIZ UDPGothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LicenseManager.ForeColor = System.Drawing.Color.White;
            this.button_LicenseManager.Location = new System.Drawing.Point(12, 183);
            this.button_LicenseManager.Name = "button_LicenseManager";
            this.button_LicenseManager.Size = new System.Drawing.Size(139, 40);
            this.button_LicenseManager.TabIndex = 7;
            this.button_LicenseManager.Text = "button1";
            this.button_LicenseManager.UseVisualStyleBackColor = false;
            this.button_LicenseManager.Click += new System.EventHandler(this.button_LicenseManager_Click);
            // 
            // button_UserManager
            // 
            this.button_UserManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_UserManager.FlatAppearance.BorderSize = 0;
            this.button_UserManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_UserManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_UserManager.Font = new System.Drawing.Font("BIZ UDPGothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_UserManager.ForeColor = System.Drawing.Color.White;
            this.button_UserManager.Location = new System.Drawing.Point(12, 275);
            this.button_UserManager.Name = "button_UserManager";
            this.button_UserManager.Size = new System.Drawing.Size(139, 40);
            this.button_UserManager.TabIndex = 6;
            this.button_UserManager.Text = "button1";
            this.button_UserManager.UseVisualStyleBackColor = false;
            this.button_UserManager.Click += new System.EventHandler(this.button_UserManager_Click);
            // 
            // button_ProfileManager
            // 
            this.button_ProfileManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_ProfileManager.FlatAppearance.BorderSize = 0;
            this.button_ProfileManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_ProfileManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_ProfileManager.Font = new System.Drawing.Font("BIZ UDPGothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_ProfileManager.ForeColor = System.Drawing.Color.White;
            this.button_ProfileManager.Location = new System.Drawing.Point(12, 229);
            this.button_ProfileManager.Name = "button_ProfileManager";
            this.button_ProfileManager.Size = new System.Drawing.Size(139, 40);
            this.button_ProfileManager.TabIndex = 5;
            this.button_ProfileManager.Text = "button1";
            this.button_ProfileManager.UseVisualStyleBackColor = false;
            this.button_ProfileManager.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_LanguageManager
            // 
            this.button_LanguageManager.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_LanguageManager.FlatAppearance.BorderSize = 0;
            this.button_LanguageManager.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_LanguageManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_LanguageManager.Font = new System.Drawing.Font("BIZ UDPGothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_LanguageManager.ForeColor = System.Drawing.Color.White;
            this.button_LanguageManager.Location = new System.Drawing.Point(12, 321);
            this.button_LanguageManager.Name = "button_LanguageManager";
            this.button_LanguageManager.Size = new System.Drawing.Size(139, 40);
            this.button_LanguageManager.TabIndex = 3;
            this.button_LanguageManager.Text = "button1";
            this.button_LanguageManager.UseVisualStyleBackColor = false;
            this.button_LanguageManager.Click += new System.EventHandler(this.button_LanguageManager_Click);
            // 
            // languageEditorController1
            // 
            this.languageEditorController1.Location = new System.Drawing.Point(441, 83);
            this.languageEditorController1.Name = "languageEditorController1";
            this.languageEditorController1.Size = new System.Drawing.Size(394, 485);
            this.languageEditorController1.TabIndex = 1;
            // 
            // user_Manager1
            // 
            this.user_Manager1.Location = new System.Drawing.Point(172, 12);
            this.user_Manager1.Name = "user_Manager1";
            this.user_Manager1.Size = new System.Drawing.Size(1024, 387);
            this.user_Manager1.TabIndex = 2;
            this.user_Manager1.Load += new System.EventHandler(this.user_Manager1_Load);
            // 
            // license_Manager1
            // 
            this.license_Manager1.Location = new System.Drawing.Point(335, 83);
            this.license_Manager1.Name = "license_Manager1";
            this.license_Manager1.Size = new System.Drawing.Size(580, 470);
            this.license_Manager1.TabIndex = 3;
            // 
            // profile_Manager1
            // 
            this.profile_Manager1.Location = new System.Drawing.Point(335, 115);
            this.profile_Manager1.Name = "profile_Manager1";
            this.profile_Manager1.Size = new System.Drawing.Size(686, 438);
            this.profile_Manager1.TabIndex = 4;
            // 
            // FindDr___Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(82)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1123, 645);
            this.Controls.Add(this.profile_Manager1);
            this.Controls.Add(this.license_Manager1);
            this.Controls.Add(this.user_Manager1);
            this.Controls.Add(this.languageEditorController1);
            this.Controls.Add(this.panel1);
            this.Name = "FindDr___Admin";
            this.Text = "FindDr___Admin";
            this.Load += new System.EventHandler(this.FindDr___Admin_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_UserManager;
        private System.Windows.Forms.Button button_ProfileManager;
        private System.Windows.Forms.Button button_LanguageManager;
        private System.Windows.Forms.Button button_LicenseManager;
        private Controllers.LanguageEditorController languageEditorController1;
        private Controllers.User_Manager user_Manager1;
        private Controllers.License_Manager license_Manager1;
        private Controllers.Profile_Manager profile_Manager1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Title_Admin;
    }
}