
namespace UAICampo.UI
{
    partial class frmLicenseManager
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
            this.license_Manager1 = new UAICampo.UI.Controllers.License_Manager();
            this.SuspendLayout();
            // 
            // license_Manager1
            // 
            this.license_Manager1.Location = new System.Drawing.Point(12, 12);
            this.license_Manager1.Name = "license_Manager1";
            this.license_Manager1.Size = new System.Drawing.Size(580, 470);
            this.license_Manager1.TabIndex = 0;
            // 
            // frmLicenseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(605, 496);
            this.Controls.Add(this.license_Manager1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLicenseManager";
            this.Text = "frmLicenseManager";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.License_Manager license_Manager1;
    }
}