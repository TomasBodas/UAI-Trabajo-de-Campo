
namespace UAICampo.UI.Controllers
{
    partial class License_Manager
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
            this.treeView_License = new System.Windows.Forms.TreeView();
            this.label_TItle = new System.Windows.Forms.Label();
            this.label_LicenseId = new System.Windows.Forms.Label();
            this.labelLicenseName = new System.Windows.Forms.Label();
            this.label_LicenseDescription = new System.Windows.Forms.Label();
            this.label_Title_LicenseId = new System.Windows.Forms.Label();
            this.label_Title_LicenseName = new System.Windows.Forms.Label();
            this.label_Title_LicenseDesc = new System.Windows.Forms.Label();
            this.button_addLicense = new System.Windows.Forms.Button();
            this.button_deleteLicense = new System.Windows.Forms.Button();
            this.button_addChildLicense = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label_Title_LicensePool = new System.Windows.Forms.Label();
            this.button_removeChildLicense = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView_License
            // 
            this.treeView_License.Location = new System.Drawing.Point(12, 54);
            this.treeView_License.Name = "treeView_License";
            this.treeView_License.Size = new System.Drawing.Size(389, 264);
            this.treeView_License.TabIndex = 0;
            this.treeView_License.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_License_AfterSelect);
            this.treeView_License.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView_License_MouseUp);
            // 
            // label_TItle
            // 
            this.label_TItle.AutoSize = true;
            this.label_TItle.Location = new System.Drawing.Point(9, 22);
            this.label_TItle.Name = "label_TItle";
            this.label_TItle.Size = new System.Drawing.Size(89, 13);
            this.label_TItle.TabIndex = 1;
            this.label_TItle.Text = "License Manager";
            // 
            // label_LicenseId
            // 
            this.label_LicenseId.AutoSize = true;
            this.label_LicenseId.Location = new System.Drawing.Point(153, 337);
            this.label_LicenseId.Name = "label_LicenseId";
            this.label_LicenseId.Size = new System.Drawing.Size(0, 13);
            this.label_LicenseId.TabIndex = 2;
            // 
            // labelLicenseName
            // 
            this.labelLicenseName.AutoSize = true;
            this.labelLicenseName.Location = new System.Drawing.Point(153, 370);
            this.labelLicenseName.Name = "labelLicenseName";
            this.labelLicenseName.Size = new System.Drawing.Size(0, 13);
            this.labelLicenseName.TabIndex = 3;
            // 
            // label_LicenseDescription
            // 
            this.label_LicenseDescription.AutoSize = true;
            this.label_LicenseDescription.Location = new System.Drawing.Point(153, 406);
            this.label_LicenseDescription.Name = "label_LicenseDescription";
            this.label_LicenseDescription.Size = new System.Drawing.Size(0, 13);
            this.label_LicenseDescription.TabIndex = 4;
            // 
            // label_Title_LicenseId
            // 
            this.label_Title_LicenseId.AutoSize = true;
            this.label_Title_LicenseId.Location = new System.Drawing.Point(19, 337);
            this.label_Title_LicenseId.Name = "label_Title_LicenseId";
            this.label_Title_LicenseId.Size = new System.Drawing.Size(61, 13);
            this.label_Title_LicenseId.TabIndex = 5;
            this.label_Title_LicenseId.Text = "License ID:";
            // 
            // label_Title_LicenseName
            // 
            this.label_Title_LicenseName.AutoSize = true;
            this.label_Title_LicenseName.Location = new System.Drawing.Point(19, 370);
            this.label_Title_LicenseName.Name = "label_Title_LicenseName";
            this.label_Title_LicenseName.Size = new System.Drawing.Size(78, 13);
            this.label_Title_LicenseName.TabIndex = 6;
            this.label_Title_LicenseName.Text = "License Name:";
            // 
            // label_Title_LicenseDesc
            // 
            this.label_Title_LicenseDesc.AutoSize = true;
            this.label_Title_LicenseDesc.Location = new System.Drawing.Point(19, 406);
            this.label_Title_LicenseDesc.Name = "label_Title_LicenseDesc";
            this.label_Title_LicenseDesc.Size = new System.Drawing.Size(75, 13);
            this.label_Title_LicenseDesc.TabIndex = 7;
            this.label_Title_LicenseDesc.Text = "License Desc:";
            // 
            // button_addLicense
            // 
            this.button_addLicense.Location = new System.Drawing.Point(407, 324);
            this.button_addLicense.Name = "button_addLicense";
            this.button_addLicense.Size = new System.Drawing.Size(77, 23);
            this.button_addLicense.TabIndex = 8;
            this.button_addLicense.Text = "Add License";
            this.button_addLicense.UseVisualStyleBackColor = true;
            this.button_addLicense.Click += new System.EventHandler(this.button_addLicense_Click);
            // 
            // button_deleteLicense
            // 
            this.button_deleteLicense.Location = new System.Drawing.Point(496, 324);
            this.button_deleteLicense.Name = "button_deleteLicense";
            this.button_deleteLicense.Size = new System.Drawing.Size(77, 23);
            this.button_deleteLicense.TabIndex = 9;
            this.button_deleteLicense.Text = "Delete License";
            this.button_deleteLicense.UseVisualStyleBackColor = true;
            this.button_deleteLicense.Click += new System.EventHandler(this.button_deleteLicense_Click);
            // 
            // button_addChildLicense
            // 
            this.button_addChildLicense.Location = new System.Drawing.Point(449, 353);
            this.button_addChildLicense.Name = "button_addChildLicense";
            this.button_addChildLicense.Size = new System.Drawing.Size(35, 23);
            this.button_addChildLicense.TabIndex = 10;
            this.button_addChildLicense.Text = "<";
            this.button_addChildLicense.UseVisualStyleBackColor = true;
            this.button_addChildLicense.Click += new System.EventHandler(this.button_addChildLicense_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(407, 54);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(166, 264);
            this.listBox1.TabIndex = 11;
            // 
            // label_Title_LicensePool
            // 
            this.label_Title_LicensePool.AutoSize = true;
            this.label_Title_LicensePool.Location = new System.Drawing.Point(404, 22);
            this.label_Title_LicensePool.Name = "label_Title_LicensePool";
            this.label_Title_LicensePool.Size = new System.Drawing.Size(68, 13);
            this.label_Title_LicensePool.TabIndex = 12;
            this.label_Title_LicensePool.Text = "License Pool";
            // 
            // button_removeChildLicense
            // 
            this.button_removeChildLicense.Location = new System.Drawing.Point(496, 353);
            this.button_removeChildLicense.Name = "button_removeChildLicense";
            this.button_removeChildLicense.Size = new System.Drawing.Size(35, 23);
            this.button_removeChildLicense.TabIndex = 13;
            this.button_removeChildLicense.Text = ">";
            this.button_removeChildLicense.UseVisualStyleBackColor = true;
            this.button_removeChildLicense.Click += new System.EventHandler(this.button_removeChildLicense_Click);
            // 
            // License_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_removeChildLicense);
            this.Controls.Add(this.label_Title_LicensePool);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button_addChildLicense);
            this.Controls.Add(this.button_deleteLicense);
            this.Controls.Add(this.button_addLicense);
            this.Controls.Add(this.label_Title_LicenseDesc);
            this.Controls.Add(this.label_Title_LicenseName);
            this.Controls.Add(this.label_Title_LicenseId);
            this.Controls.Add(this.label_LicenseDescription);
            this.Controls.Add(this.labelLicenseName);
            this.Controls.Add(this.label_LicenseId);
            this.Controls.Add(this.label_TItle);
            this.Controls.Add(this.treeView_License);
            this.Name = "License_Manager";
            this.Size = new System.Drawing.Size(580, 470);
            this.Load += new System.EventHandler(this.License_Manager_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_License;
        private System.Windows.Forms.Label label_TItle;
        private System.Windows.Forms.Label label_LicenseId;
        private System.Windows.Forms.Label labelLicenseName;
        private System.Windows.Forms.Label label_LicenseDescription;
        private System.Windows.Forms.Label label_Title_LicenseId;
        private System.Windows.Forms.Label label_Title_LicenseName;
        private System.Windows.Forms.Label label_Title_LicenseDesc;
        private System.Windows.Forms.Button button_addLicense;
        private System.Windows.Forms.Button button_deleteLicense;
        private System.Windows.Forms.Button button_addChildLicense;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label_Title_LicensePool;
        private System.Windows.Forms.Button button_removeChildLicense;
    }
}
