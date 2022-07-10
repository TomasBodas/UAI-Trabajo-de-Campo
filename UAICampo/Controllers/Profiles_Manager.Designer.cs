
namespace UAICampo.UI.Controllers
{
    partial class Profiles_Manager
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
            this.dataGridView_user = new System.Windows.Forms.DataGridView();
            this.dataGridView_Lincense = new System.Windows.Forms.DataGridView();
            this.dataGridView_ProfileLicense = new System.Windows.Forms.DataGridView();
            this.button_AssignLicense = new System.Windows.Forms.Button();
            this.button_revokeLicense = new System.Windows.Forms.Button();
            this.label_Title_Profile = new System.Windows.Forms.Label();
            this.label_Title_License = new System.Windows.Forms.Label();
            this.label_Title_ProfileLicenses = new System.Windows.Forms.Label();
            this.button_BlockUser = new System.Windows.Forms.Button();
            this.button_unblockUser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lincense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProfileLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_user.Location = new System.Drawing.Point(6, 22);
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.RowHeadersVisible = false;
            this.dataGridView_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_user.Size = new System.Drawing.Size(537, 253);
            this.dataGridView_user.TabIndex = 0;
            this.dataGridView_user.SelectionChanged += new System.EventHandler(this.dataGridView_Profile_SelectionChanged);
            // 
            // dataGridView_Lincense
            // 
            this.dataGridView_Lincense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lincense.Location = new System.Drawing.Point(741, 22);
            this.dataGridView_Lincense.Name = "dataGridView_Lincense";
            this.dataGridView_Lincense.RowHeadersVisible = false;
            this.dataGridView_Lincense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lincense.Size = new System.Drawing.Size(324, 385);
            this.dataGridView_Lincense.TabIndex = 1;
            this.dataGridView_Lincense.SelectionChanged += new System.EventHandler(this.dataGridView_Lincense_SelectionChanged);
            // 
            // dataGridView_ProfileLicense
            // 
            this.dataGridView_ProfileLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProfileLicense.Location = new System.Drawing.Point(73, 310);
            this.dataGridView_ProfileLicense.Name = "dataGridView_ProfileLicense";
            this.dataGridView_ProfileLicense.RowHeadersVisible = false;
            this.dataGridView_ProfileLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProfileLicense.Size = new System.Drawing.Size(415, 81);
            this.dataGridView_ProfileLicense.TabIndex = 2;
            this.dataGridView_ProfileLicense.SelectionChanged += new System.EventHandler(this.dataGridView_ProfileLicense_SelectionChanged);
            // 
            // button_AssignLicense
            // 
            this.button_AssignLicense.Location = new System.Drawing.Point(613, 22);
            this.button_AssignLicense.Name = "button_AssignLicense";
            this.button_AssignLicense.Size = new System.Drawing.Size(52, 23);
            this.button_AssignLicense.TabIndex = 3;
            this.button_AssignLicense.Text = "<";
            this.button_AssignLicense.UseVisualStyleBackColor = true;
            this.button_AssignLicense.Click += new System.EventHandler(this.button_AssignLicense_Click);
            // 
            // button_revokeLicense
            // 
            this.button_revokeLicense.Location = new System.Drawing.Point(613, 67);
            this.button_revokeLicense.Name = "button_revokeLicense";
            this.button_revokeLicense.Size = new System.Drawing.Size(52, 23);
            this.button_revokeLicense.TabIndex = 4;
            this.button_revokeLicense.Text = ">";
            this.button_revokeLicense.UseVisualStyleBackColor = true;
            this.button_revokeLicense.Click += new System.EventHandler(this.button_revokeLicense_Click);
            // 
            // label_Title_Profile
            // 
            this.label_Title_Profile.AutoSize = true;
            this.label_Title_Profile.Location = new System.Drawing.Point(3, 6);
            this.label_Title_Profile.Name = "label_Title_Profile";
            this.label_Title_Profile.Size = new System.Drawing.Size(35, 13);
            this.label_Title_Profile.TabIndex = 5;
            this.label_Title_Profile.Text = "label1";
            // 
            // label_Title_License
            // 
            this.label_Title_License.AutoSize = true;
            this.label_Title_License.Location = new System.Drawing.Point(738, 6);
            this.label_Title_License.Name = "label_Title_License";
            this.label_Title_License.Size = new System.Drawing.Size(35, 13);
            this.label_Title_License.TabIndex = 6;
            this.label_Title_License.Text = "label1";
            // 
            // label_Title_ProfileLicenses
            // 
            this.label_Title_ProfileLicenses.AutoSize = true;
            this.label_Title_ProfileLicenses.Location = new System.Drawing.Point(70, 294);
            this.label_Title_ProfileLicenses.Name = "label_Title_ProfileLicenses";
            this.label_Title_ProfileLicenses.Size = new System.Drawing.Size(35, 13);
            this.label_Title_ProfileLicenses.TabIndex = 7;
            this.label_Title_ProfileLicenses.Text = "label1";
            // 
            // button_BlockUser
            // 
            this.button_BlockUser.Location = new System.Drawing.Point(601, 127);
            this.button_BlockUser.Name = "button_BlockUser";
            this.button_BlockUser.Size = new System.Drawing.Size(75, 23);
            this.button_BlockUser.TabIndex = 8;
            this.button_BlockUser.Text = "Block";
            this.button_BlockUser.UseVisualStyleBackColor = true;
            this.button_BlockUser.Click += new System.EventHandler(this.button_BlockUser_Click);
            // 
            // button_unblockUser
            // 
            this.button_unblockUser.Location = new System.Drawing.Point(601, 178);
            this.button_unblockUser.Name = "button_unblockUser";
            this.button_unblockUser.Size = new System.Drawing.Size(75, 23);
            this.button_unblockUser.TabIndex = 9;
            this.button_unblockUser.Text = "Unblock";
            this.button_unblockUser.UseVisualStyleBackColor = true;
            this.button_unblockUser.Click += new System.EventHandler(this.button_unblockUser_Click);
            // 
            // Profile_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_unblockUser);
            this.Controls.Add(this.button_BlockUser);
            this.Controls.Add(this.label_Title_ProfileLicenses);
            this.Controls.Add(this.label_Title_License);
            this.Controls.Add(this.label_Title_Profile);
            this.Controls.Add(this.button_revokeLicense);
            this.Controls.Add(this.button_AssignLicense);
            this.Controls.Add(this.dataGridView_ProfileLicense);
            this.Controls.Add(this.dataGridView_Lincense);
            this.Controls.Add(this.dataGridView_user);
            this.Name = "Profile_Manager";
            this.Size = new System.Drawing.Size(1076, 418);
            this.Load += new System.EventHandler(this.Profile_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lincense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProfileLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.DataGridView dataGridView_Lincense;
        private System.Windows.Forms.DataGridView dataGridView_ProfileLicense;
        private System.Windows.Forms.Button button_AssignLicense;
        private System.Windows.Forms.Button button_revokeLicense;
        private System.Windows.Forms.Label label_Title_Profile;
        private System.Windows.Forms.Label label_Title_License;
        private System.Windows.Forms.Label label_Title_ProfileLicenses;
        private System.Windows.Forms.Button button_BlockUser;
        private System.Windows.Forms.Button button_unblockUser;
    }
}
