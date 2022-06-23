
namespace UAICampo.UI.Controllers
{
    partial class ProfileUser
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
            this.labelProfile = new System.Windows.Forms.Label();
            this.tabControlProfile = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.tabPagePassword = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.labelMail = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.labelProfileLicense = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.labelTeam = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.labelPosition = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.labelDate = new System.Windows.Forms.Label();
            this.password_Change1 = new UAICampo.UI.Controllers.Password_Change();
            this.tabPageAchievements = new System.Windows.Forms.TabPage();
            this.tabControlProfile.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.tabPagePassword.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProfile.Location = new System.Drawing.Point(25, 31);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(103, 35);
            this.labelProfile.TabIndex = 1;
            this.labelProfile.Text = "Profile";
            // 
            // tabControlProfile
            // 
            this.tabControlProfile.Controls.Add(this.tabPageInformation);
            this.tabControlProfile.Controls.Add(this.tabPagePassword);
            this.tabControlProfile.Controls.Add(this.tabPageAchievements);
            this.tabControlProfile.Location = new System.Drawing.Point(18, 82);
            this.tabControlProfile.Name = "tabControlProfile";
            this.tabControlProfile.SelectedIndex = 0;
            this.tabControlProfile.Size = new System.Drawing.Size(337, 314);
            this.tabControlProfile.TabIndex = 2;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.textBox6);
            this.tabPageInformation.Controls.Add(this.labelDate);
            this.tabPageInformation.Controls.Add(this.textBox5);
            this.tabPageInformation.Controls.Add(this.labelPosition);
            this.tabPageInformation.Controls.Add(this.textBox4);
            this.tabPageInformation.Controls.Add(this.labelTeam);
            this.tabPageInformation.Controls.Add(this.textBox3);
            this.tabPageInformation.Controls.Add(this.labelProfileLicense);
            this.tabPageInformation.Controls.Add(this.textBox2);
            this.tabPageInformation.Controls.Add(this.labelMail);
            this.tabPageInformation.Controls.Add(this.textBox1);
            this.tabPageInformation.Controls.Add(this.label1);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(329, 288);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Information";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // tabPagePassword
            // 
            this.tabPagePassword.Controls.Add(this.password_Change1);
            this.tabPagePassword.Location = new System.Drawing.Point(4, 22);
            this.tabPagePassword.Name = "tabPagePassword";
            this.tabPagePassword.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePassword.Size = new System.Drawing.Size(329, 288);
            this.tabPagePassword.TabIndex = 1;
            this.tabPagePassword.Text = "Change Password";
            this.tabPagePassword.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(51, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox1.Location = new System.Drawing.Point(144, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(127, 23);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox2.Location = new System.Drawing.Point(144, 71);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(127, 23);
            this.textBox2.TabIndex = 3;
            // 
            // labelMail
            // 
            this.labelMail.AutoSize = true;
            this.labelMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelMail.Location = new System.Drawing.Point(76, 75);
            this.labelMail.Name = "labelMail";
            this.labelMail.Size = new System.Drawing.Size(47, 17);
            this.labelMail.TabIndex = 2;
            this.labelMail.Text = "E-Mail";
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.Location = new System.Drawing.Point(144, 100);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(127, 23);
            this.textBox3.TabIndex = 5;
            // 
            // labelProfileLicense
            // 
            this.labelProfileLicense.AutoSize = true;
            this.labelProfileLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProfileLicense.Location = new System.Drawing.Point(76, 104);
            this.labelProfileLicense.Name = "labelProfileLicense";
            this.labelProfileLicense.Size = new System.Drawing.Size(48, 17);
            this.labelProfileLicense.TabIndex = 4;
            this.labelProfileLicense.Text = "Profile";
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox4.Location = new System.Drawing.Point(144, 129);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(127, 23);
            this.textBox4.TabIndex = 7;
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTeam.Location = new System.Drawing.Point(80, 132);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(44, 17);
            this.labelTeam.TabIndex = 6;
            this.labelTeam.Text = "Team";
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox5.Location = new System.Drawing.Point(144, 158);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(127, 23);
            this.textBox5.TabIndex = 9;
            // 
            // labelPosition
            // 
            this.labelPosition.AutoSize = true;
            this.labelPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelPosition.Location = new System.Drawing.Point(66, 161);
            this.labelPosition.Name = "labelPosition";
            this.labelPosition.Size = new System.Drawing.Size(58, 17);
            this.labelPosition.TabIndex = 8;
            this.labelPosition.Text = "Position";
            // 
            // textBox6
            // 
            this.textBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox6.Location = new System.Drawing.Point(144, 187);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(127, 23);
            this.textBox6.TabIndex = 11;
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDate.Location = new System.Drawing.Point(18, 190);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(106, 17);
            this.labelDate.TabIndex = 10;
            this.labelDate.Text = "Date registered";
            // 
            // password_Change1
            // 
            this.password_Change1.Location = new System.Drawing.Point(36, 42);
            this.password_Change1.Name = "password_Change1";
            this.password_Change1.Size = new System.Drawing.Size(253, 184);
            this.password_Change1.TabIndex = 0;
            // 
            // tabPageAchievements
            // 
            this.tabPageAchievements.Location = new System.Drawing.Point(4, 22);
            this.tabPageAchievements.Name = "tabPageAchievements";
            this.tabPageAchievements.Size = new System.Drawing.Size(329, 288);
            this.tabPageAchievements.TabIndex = 2;
            this.tabPageAchievements.Text = "Achievements";
            this.tabPageAchievements.UseVisualStyleBackColor = true;
            // 
            // ProfileUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlProfile);
            this.Controls.Add(this.labelProfile);
            this.Name = "ProfileUser";
            this.Size = new System.Drawing.Size(380, 416);
            this.tabControlProfile.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.tabPageInformation.PerformLayout();
            this.tabPagePassword.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.TabControl tabControlProfile;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPagePassword;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label labelPosition;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label labelProfileLicense;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label labelMail;
        private Password_Change password_Change1;
        private System.Windows.Forms.TabPage tabPageAchievements;
    }
}
