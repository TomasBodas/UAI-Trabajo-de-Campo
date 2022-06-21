
namespace UAICampo.UI
{
    partial class frmUserManager
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
            this.user_Manager1 = new UAICampo.UI.Controllers.User_Manager();
            this.SuspendLayout();
            // 
            // user_Manager1
            // 
            this.user_Manager1.Location = new System.Drawing.Point(12, 12);
            this.user_Manager1.Name = "user_Manager1";
            this.user_Manager1.Size = new System.Drawing.Size(1024, 387);
            this.user_Manager1.TabIndex = 0;
            // 
            // frmUserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(1049, 412);
            this.Controls.Add(this.user_Manager1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmUserManager";
            this.Text = "frmUserManager";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.User_Manager user_Manager1;
    }
}