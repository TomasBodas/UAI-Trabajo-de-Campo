
namespace UAICampo.UI
{
    partial class FindDr___Main_form
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
            this.label_userName = new System.Windows.Forms.Label();
            this.panel_lateralRow = new System.Windows.Forms.Panel();
            this.button_DoctorsOffice = new System.Windows.Forms.Button();
            this.button_Appointment = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.languageController1 = new UAICampo.UI.Controllers.LanguageController();
            this.button_MyAccount = new System.Windows.Forms.Button();
            this.button_adminPanel = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_userSearch = new System.Windows.Forms.Button();
            this.button_profile = new System.Windows.Forms.Button();
            this.panel_subForm = new System.Windows.Forms.Panel();
            this.button_Practices = new System.Windows.Forms.Button();
            this.panel_lateralRow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_userName
            // 
            this.label_userName.AutoSize = true;
            this.label_userName.Font = new System.Drawing.Font("BIZ UDGothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_userName.ForeColor = System.Drawing.Color.White;
            this.label_userName.Location = new System.Drawing.Point(58, 147);
            this.label_userName.Name = "label_userName";
            this.label_userName.Size = new System.Drawing.Size(76, 21);
            this.label_userName.TabIndex = 0;
            this.label_userName.Text = "label1";
            // 
            // panel_lateralRow
            // 
            this.panel_lateralRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(45)))), ((int)(((byte)(86)))));
            this.panel_lateralRow.Controls.Add(this.button_Practices);
            this.panel_lateralRow.Controls.Add(this.button_DoctorsOffice);
            this.panel_lateralRow.Controls.Add(this.button_Appointment);
            this.panel_lateralRow.Controls.Add(this.pictureBox1);
            this.panel_lateralRow.Controls.Add(this.languageController1);
            this.panel_lateralRow.Controls.Add(this.button_MyAccount);
            this.panel_lateralRow.Controls.Add(this.button_adminPanel);
            this.panel_lateralRow.Controls.Add(this.button_logout);
            this.panel_lateralRow.Controls.Add(this.button_userSearch);
            this.panel_lateralRow.Controls.Add(this.button_profile);
            this.panel_lateralRow.Controls.Add(this.label_userName);
            this.panel_lateralRow.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_lateralRow.Location = new System.Drawing.Point(0, 0);
            this.panel_lateralRow.Name = "panel_lateralRow";
            this.panel_lateralRow.Size = new System.Drawing.Size(200, 736);
            this.panel_lateralRow.TabIndex = 1;
            this.panel_lateralRow.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_lateralRow_Paint);
            // 
            // button_DoctorsOffice
            // 
            this.button_DoctorsOffice.Location = new System.Drawing.Point(3, 339);
            this.button_DoctorsOffice.Name = "button_DoctorsOffice";
            this.button_DoctorsOffice.Size = new System.Drawing.Size(194, 47);
            this.button_DoctorsOffice.TabIndex = 8;
            this.button_DoctorsOffice.Text = "Offices";
            this.button_DoctorsOffice.UseVisualStyleBackColor = true;
            this.button_DoctorsOffice.Click += new System.EventHandler(this.button_DoctorsOffice_Click);
            // 
            // button_Appointment
            // 
            this.button_Appointment.Location = new System.Drawing.Point(3, 286);
            this.button_Appointment.Name = "button_Appointment";
            this.button_Appointment.Size = new System.Drawing.Size(194, 47);
            this.button_Appointment.TabIndex = 7;
            this.button_Appointment.Text = "Appointments";
            this.button_Appointment.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UAICampo.UI.Properties.Resources.Logo_FindDr;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 116);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // languageController1
            // 
            this.languageController1.Location = new System.Drawing.Point(3, 678);
            this.languageController1.Name = "languageController1";
            this.languageController1.Size = new System.Drawing.Size(194, 26);
            this.languageController1.TabIndex = 0;
            // 
            // button_MyAccount
            // 
            this.button_MyAccount.Location = new System.Drawing.Point(3, 625);
            this.button_MyAccount.Name = "button_MyAccount";
            this.button_MyAccount.Size = new System.Drawing.Size(194, 47);
            this.button_MyAccount.TabIndex = 6;
            this.button_MyAccount.Text = "My account";
            this.button_MyAccount.UseVisualStyleBackColor = true;
            // 
            // button_adminPanel
            // 
            this.button_adminPanel.Location = new System.Drawing.Point(3, 572);
            this.button_adminPanel.Name = "button_adminPanel";
            this.button_adminPanel.Size = new System.Drawing.Size(194, 47);
            this.button_adminPanel.TabIndex = 5;
            this.button_adminPanel.Text = "Admin";
            this.button_adminPanel.UseVisualStyleBackColor = true;
            this.button_adminPanel.Click += new System.EventHandler(this.button_adminPanel_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(3, 707);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(194, 27);
            this.button_logout.TabIndex = 4;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_userSearch
            // 
            this.button_userSearch.Location = new System.Drawing.Point(3, 233);
            this.button_userSearch.Name = "button_userSearch";
            this.button_userSearch.Size = new System.Drawing.Size(194, 47);
            this.button_userSearch.TabIndex = 3;
            this.button_userSearch.Text = "search";
            this.button_userSearch.UseVisualStyleBackColor = true;
            this.button_userSearch.Click += new System.EventHandler(this.button_userSearch_Click);
            // 
            // button_profile
            // 
            this.button_profile.Location = new System.Drawing.Point(3, 180);
            this.button_profile.Name = "button_profile";
            this.button_profile.Size = new System.Drawing.Size(194, 47);
            this.button_profile.TabIndex = 2;
            this.button_profile.Text = "profile";
            this.button_profile.UseVisualStyleBackColor = true;
            this.button_profile.Click += new System.EventHandler(this.button_profile_Click);
            // 
            // panel_subForm
            // 
            this.panel_subForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_subForm.Location = new System.Drawing.Point(200, 0);
            this.panel_subForm.Name = "panel_subForm";
            this.panel_subForm.Size = new System.Drawing.Size(1236, 736);
            this.panel_subForm.TabIndex = 2;
            this.panel_subForm.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_subForm_Paint);
            // 
            // button_Practices
            // 
            this.button_Practices.Location = new System.Drawing.Point(3, 392);
            this.button_Practices.Name = "button_Practices";
            this.button_Practices.Size = new System.Drawing.Size(194, 47);
            this.button_Practices.TabIndex = 9;
            this.button_Practices.Text = "Offices";
            this.button_Practices.UseVisualStyleBackColor = true;
            // 
            // FindDr___Main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(28)))), ((int)(((byte)(63)))));
            this.ClientSize = new System.Drawing.Size(1436, 736);
            this.Controls.Add(this.panel_subForm);
            this.Controls.Add(this.panel_lateralRow);
            this.Name = "FindDr___Main_form";
            this.Text = "FindDr___Main_form";
            this.Load += new System.EventHandler(this.FindDr___Main_form_Load);
            this.panel_lateralRow.ResumeLayout(false);
            this.panel_lateralRow.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_lateralRow;
        private System.Windows.Forms.Label label_userName;
        private System.Windows.Forms.Button button_adminPanel;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_userSearch;
        private System.Windows.Forms.Button button_profile;
        private System.Windows.Forms.Panel panel_subForm;
        private Controllers.LanguageController languageController1;
        private System.Windows.Forms.Button button_MyAccount;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_DoctorsOffice;
        private System.Windows.Forms.Button button_Appointment;
        private System.Windows.Forms.Button button_Practices;
    }
}