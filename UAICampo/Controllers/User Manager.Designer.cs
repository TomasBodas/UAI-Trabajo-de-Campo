
namespace UAICampo.UI.Controllers
{
    partial class User_Manager
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
            this.button_BlockUser = new System.Windows.Forms.Button();
            this.button_unblockUser = new System.Windows.Forms.Button();
            this.label_title_UserList = new System.Windows.Forms.Label();
            this.dataGridView_userProfile = new System.Windows.Forms.DataGridView();
            this.label_title_UserProfile = new System.Windows.Forms.Label();
            this.dataGridView_GeneralProfileList = new System.Windows.Forms.DataGridView();
            this.button_assignProfile = new System.Windows.Forms.Button();
            this.button_revokeProfile = new System.Windows.Forms.Button();
            this.label_title_ProfilePool = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_userProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GeneralProfileList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_user
            // 
            this.dataGridView_user.AllowUserToDeleteRows = false;
            this.dataGridView_user.AllowUserToResizeRows = false;
            this.dataGridView_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_user.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_user.Location = new System.Drawing.Point(14, 66);
            this.dataGridView_user.MultiSelect = false;
            this.dataGridView_user.Name = "dataGridView_user";
            this.dataGridView_user.ReadOnly = true;
            this.dataGridView_user.RowHeadersVisible = false;
            this.dataGridView_user.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_user.Size = new System.Drawing.Size(523, 188);
            this.dataGridView_user.TabIndex = 0;
            this.dataGridView_user.SelectionChanged += new System.EventHandler(this.dataGridView_user_SelectionChanged);
            // 
            // button_BlockUser
            // 
            this.button_BlockUser.Location = new System.Drawing.Point(564, 66);
            this.button_BlockUser.Name = "button_BlockUser";
            this.button_BlockUser.Size = new System.Drawing.Size(75, 23);
            this.button_BlockUser.TabIndex = 1;
            this.button_BlockUser.Text = "Block";
            this.button_BlockUser.UseVisualStyleBackColor = true;
            this.button_BlockUser.Click += new System.EventHandler(this.button_BlockUser_Click);
            // 
            // button_unblockUser
            // 
            this.button_unblockUser.Location = new System.Drawing.Point(564, 108);
            this.button_unblockUser.Name = "button_unblockUser";
            this.button_unblockUser.Size = new System.Drawing.Size(75, 23);
            this.button_unblockUser.TabIndex = 2;
            this.button_unblockUser.Text = "Unblock";
            this.button_unblockUser.UseVisualStyleBackColor = true;
            this.button_unblockUser.Click += new System.EventHandler(this.button_unblockUser_Click);
            // 
            // label_title_UserList
            // 
            this.label_title_UserList.AutoSize = true;
            this.label_title_UserList.Location = new System.Drawing.Point(11, 50);
            this.label_title_UserList.Name = "label_title_UserList";
            this.label_title_UserList.Size = new System.Drawing.Size(35, 13);
            this.label_title_UserList.TabIndex = 3;
            this.label_title_UserList.Text = "label1";
            // 
            // dataGridView_userProfile
            // 
            this.dataGridView_userProfile.AllowUserToDeleteRows = false;
            this.dataGridView_userProfile.AllowUserToResizeRows = false;
            this.dataGridView_userProfile.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_userProfile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_userProfile.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_userProfile.Location = new System.Drawing.Point(14, 280);
            this.dataGridView_userProfile.MultiSelect = false;
            this.dataGridView_userProfile.Name = "dataGridView_userProfile";
            this.dataGridView_userProfile.ReadOnly = true;
            this.dataGridView_userProfile.RowHeadersVisible = false;
            this.dataGridView_userProfile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_userProfile.Size = new System.Drawing.Size(523, 78);
            this.dataGridView_userProfile.TabIndex = 4;
            // 
            // label_title_UserProfile
            // 
            this.label_title_UserProfile.AutoSize = true;
            this.label_title_UserProfile.Location = new System.Drawing.Point(11, 264);
            this.label_title_UserProfile.Name = "label_title_UserProfile";
            this.label_title_UserProfile.Size = new System.Drawing.Size(35, 13);
            this.label_title_UserProfile.TabIndex = 5;
            this.label_title_UserProfile.Text = "label1";
            // 
            // dataGridView_GeneralProfileList
            // 
            this.dataGridView_GeneralProfileList.AllowUserToDeleteRows = false;
            this.dataGridView_GeneralProfileList.AllowUserToResizeRows = false;
            this.dataGridView_GeneralProfileList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_GeneralProfileList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_GeneralProfileList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_GeneralProfileList.Location = new System.Drawing.Point(667, 66);
            this.dataGridView_GeneralProfileList.MultiSelect = false;
            this.dataGridView_GeneralProfileList.Name = "dataGridView_GeneralProfileList";
            this.dataGridView_GeneralProfileList.ReadOnly = true;
            this.dataGridView_GeneralProfileList.RowHeadersVisible = false;
            this.dataGridView_GeneralProfileList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_GeneralProfileList.Size = new System.Drawing.Size(337, 292);
            this.dataGridView_GeneralProfileList.TabIndex = 6;
            // 
            // button_assignProfile
            // 
            this.button_assignProfile.Location = new System.Drawing.Point(564, 155);
            this.button_assignProfile.Name = "button_assignProfile";
            this.button_assignProfile.Size = new System.Drawing.Size(29, 23);
            this.button_assignProfile.TabIndex = 7;
            this.button_assignProfile.Text = "<";
            this.button_assignProfile.UseVisualStyleBackColor = true;
            this.button_assignProfile.Click += new System.EventHandler(this.button_assignProfile_Click);
            // 
            // button_revokeProfile
            // 
            this.button_revokeProfile.Location = new System.Drawing.Point(610, 155);
            this.button_revokeProfile.Name = "button_revokeProfile";
            this.button_revokeProfile.Size = new System.Drawing.Size(29, 23);
            this.button_revokeProfile.TabIndex = 8;
            this.button_revokeProfile.Text = ">";
            this.button_revokeProfile.UseVisualStyleBackColor = true;
            this.button_revokeProfile.Click += new System.EventHandler(this.button_revokeProfile_Click);
            // 
            // label_title_ProfilePool
            // 
            this.label_title_ProfilePool.AutoSize = true;
            this.label_title_ProfilePool.Location = new System.Drawing.Point(664, 50);
            this.label_title_ProfilePool.Name = "label_title_ProfilePool";
            this.label_title_ProfilePool.Size = new System.Drawing.Size(35, 13);
            this.label_title_ProfilePool.TabIndex = 9;
            this.label_title_ProfilePool.Text = "label1";
            // 
            // User_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_title_ProfilePool);
            this.Controls.Add(this.button_revokeProfile);
            this.Controls.Add(this.button_assignProfile);
            this.Controls.Add(this.dataGridView_GeneralProfileList);
            this.Controls.Add(this.label_title_UserProfile);
            this.Controls.Add(this.dataGridView_userProfile);
            this.Controls.Add(this.label_title_UserList);
            this.Controls.Add(this.button_unblockUser);
            this.Controls.Add(this.button_BlockUser);
            this.Controls.Add(this.dataGridView_user);
            this.Name = "User_Manager";
            this.Size = new System.Drawing.Size(1024, 387);
            this.Load += new System.EventHandler(this.User_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_userProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_GeneralProfileList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.Button button_BlockUser;
        private System.Windows.Forms.Button button_unblockUser;
        private System.Windows.Forms.Label label_title_UserList;
        private System.Windows.Forms.DataGridView dataGridView_userProfile;
        private System.Windows.Forms.Label label_title_UserProfile;
        private System.Windows.Forms.DataGridView dataGridView_GeneralProfileList;
        private System.Windows.Forms.Button button_assignProfile;
        private System.Windows.Forms.Button button_revokeProfile;
        private System.Windows.Forms.Label label_title_ProfilePool;
    }
}
