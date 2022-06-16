
namespace UAICampo.UI.Controllers
{
    partial class Profile_Manager
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
            this.dataGridView_Profile = new System.Windows.Forms.DataGridView();
            this.dataGridView_Lincense = new System.Windows.Forms.DataGridView();
            this.dataGridView_ProfileLicense = new System.Windows.Forms.DataGridView();
            this.button_AssignLicense = new System.Windows.Forms.Button();
            this.button_revokeLicense = new System.Windows.Forms.Button();
            this.label_Title_Profile = new System.Windows.Forms.Label();
            this.label_Title_License = new System.Windows.Forms.Label();
            this.label_Title_ProfileLicenses = new System.Windows.Forms.Label();
            this.button_addProfile = new System.Windows.Forms.Button();
            this.button_removeProfile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lincense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProfileLicense)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Profile
            // 
            this.dataGridView_Profile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Profile.Location = new System.Drawing.Point(3, 36);
            this.dataGridView_Profile.Name = "dataGridView_Profile";
            this.dataGridView_Profile.RowHeadersVisible = false;
            this.dataGridView_Profile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Profile.Size = new System.Drawing.Size(306, 253);
            this.dataGridView_Profile.TabIndex = 0;
            this.dataGridView_Profile.SelectionChanged += new System.EventHandler(this.dataGridView_Profile_SelectionChanged);
            // 
            // dataGridView_Lincense
            // 
            this.dataGridView_Lincense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Lincense.Location = new System.Drawing.Point(373, 36);
            this.dataGridView_Lincense.Name = "dataGridView_Lincense";
            this.dataGridView_Lincense.RowHeadersVisible = false;
            this.dataGridView_Lincense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Lincense.Size = new System.Drawing.Size(308, 399);
            this.dataGridView_Lincense.TabIndex = 1;
            this.dataGridView_Lincense.SelectionChanged += new System.EventHandler(this.dataGridView_Lincense_SelectionChanged);
            // 
            // dataGridView_ProfileLicense
            // 
            this.dataGridView_ProfileLicense.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ProfileLicense.Location = new System.Drawing.Point(3, 354);
            this.dataGridView_ProfileLicense.Name = "dataGridView_ProfileLicense";
            this.dataGridView_ProfileLicense.RowHeadersVisible = false;
            this.dataGridView_ProfileLicense.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_ProfileLicense.Size = new System.Drawing.Size(306, 81);
            this.dataGridView_ProfileLicense.TabIndex = 2;
            this.dataGridView_ProfileLicense.SelectionChanged += new System.EventHandler(this.dataGridView_ProfileLicense_SelectionChanged);
            // 
            // button_AssignLicense
            // 
            this.button_AssignLicense.Location = new System.Drawing.Point(315, 36);
            this.button_AssignLicense.Name = "button_AssignLicense";
            this.button_AssignLicense.Size = new System.Drawing.Size(52, 23);
            this.button_AssignLicense.TabIndex = 3;
            this.button_AssignLicense.Text = "<";
            this.button_AssignLicense.UseVisualStyleBackColor = true;
            this.button_AssignLicense.Click += new System.EventHandler(this.button_AssignLicense_Click);
            // 
            // button_revokeLicense
            // 
            this.button_revokeLicense.Location = new System.Drawing.Point(315, 65);
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
            this.label_Title_Profile.Location = new System.Drawing.Point(3, 20);
            this.label_Title_Profile.Name = "label_Title_Profile";
            this.label_Title_Profile.Size = new System.Drawing.Size(35, 13);
            this.label_Title_Profile.TabIndex = 5;
            this.label_Title_Profile.Text = "label1";
            // 
            // label_Title_License
            // 
            this.label_Title_License.AutoSize = true;
            this.label_Title_License.Location = new System.Drawing.Point(370, 20);
            this.label_Title_License.Name = "label_Title_License";
            this.label_Title_License.Size = new System.Drawing.Size(35, 13);
            this.label_Title_License.TabIndex = 6;
            this.label_Title_License.Text = "label1";
            // 
            // label_Title_ProfileLicenses
            // 
            this.label_Title_ProfileLicenses.AutoSize = true;
            this.label_Title_ProfileLicenses.Location = new System.Drawing.Point(3, 338);
            this.label_Title_ProfileLicenses.Name = "label_Title_ProfileLicenses";
            this.label_Title_ProfileLicenses.Size = new System.Drawing.Size(35, 13);
            this.label_Title_ProfileLicenses.TabIndex = 7;
            this.label_Title_ProfileLicenses.Text = "label1";
            // 
            // button_addProfile
            // 
            this.button_addProfile.Location = new System.Drawing.Point(3, 295);
            this.button_addProfile.Name = "button_addProfile";
            this.button_addProfile.Size = new System.Drawing.Size(145, 23);
            this.button_addProfile.TabIndex = 8;
            this.button_addProfile.Text = "add profile";
            this.button_addProfile.UseVisualStyleBackColor = true;
            this.button_addProfile.Click += new System.EventHandler(this.button_addProfile_Click);
            // 
            // button_removeProfile
            // 
            this.button_removeProfile.Location = new System.Drawing.Point(164, 295);
            this.button_removeProfile.Name = "button_removeProfile";
            this.button_removeProfile.Size = new System.Drawing.Size(145, 23);
            this.button_removeProfile.TabIndex = 9;
            this.button_removeProfile.Text = "removeProfile";
            this.button_removeProfile.UseVisualStyleBackColor = true;
            this.button_removeProfile.Click += new System.EventHandler(this.button_removeProfile_Click);
            // 
            // Profile_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_removeProfile);
            this.Controls.Add(this.button_addProfile);
            this.Controls.Add(this.label_Title_ProfileLicenses);
            this.Controls.Add(this.label_Title_License);
            this.Controls.Add(this.label_Title_Profile);
            this.Controls.Add(this.button_revokeLicense);
            this.Controls.Add(this.button_AssignLicense);
            this.Controls.Add(this.dataGridView_ProfileLicense);
            this.Controls.Add(this.dataGridView_Lincense);
            this.Controls.Add(this.dataGridView_Profile);
            this.Name = "Profile_Manager";
            this.Size = new System.Drawing.Size(686, 438);
            this.Load += new System.EventHandler(this.Profile_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Lincense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ProfileLicense)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Profile;
        private System.Windows.Forms.DataGridView dataGridView_Lincense;
        private System.Windows.Forms.DataGridView dataGridView_ProfileLicense;
        private System.Windows.Forms.Button button_AssignLicense;
        private System.Windows.Forms.Button button_revokeLicense;
        private System.Windows.Forms.Label label_Title_Profile;
        private System.Windows.Forms.Label label_Title_License;
        private System.Windows.Forms.Label label_Title_ProfileLicenses;
        private System.Windows.Forms.Button button_addProfile;
        private System.Windows.Forms.Button button_removeProfile;
    }
}
