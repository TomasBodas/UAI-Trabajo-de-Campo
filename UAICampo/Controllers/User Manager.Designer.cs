
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).BeginInit();
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
            this.label_title_UserList.Location = new System.Drawing.Point(11, 32);
            this.label_title_UserList.Name = "label_title_UserList";
            this.label_title_UserList.Size = new System.Drawing.Size(35, 13);
            this.label_title_UserList.TabIndex = 3;
            this.label_title_UserList.Text = "label1";
            // 
            // User_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_title_UserList);
            this.Controls.Add(this.button_unblockUser);
            this.Controls.Add(this.button_BlockUser);
            this.Controls.Add(this.dataGridView_user);
            this.Name = "User_Manager";
            this.Size = new System.Drawing.Size(663, 511);
            this.Load += new System.EventHandler(this.User_Manager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_user)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_user;
        private System.Windows.Forms.Button button_BlockUser;
        private System.Windows.Forms.Button button_unblockUser;
        private System.Windows.Forms.Label label_title_UserList;
    }
}
