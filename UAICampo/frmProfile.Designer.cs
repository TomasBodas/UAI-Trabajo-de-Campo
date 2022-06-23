
namespace UAICampo.UI
{
    partial class frmProfile
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
            this.profileUser1 = new UAICampo.UI.Controllers.ProfileUser();
            this.SuspendLayout();
            // 
            // profileUser1
            // 
            this.profileUser1.Location = new System.Drawing.Point(12, 12);
            this.profileUser1.Name = "profileUser1";
            this.profileUser1.Size = new System.Drawing.Size(380, 416);
            this.profileUser1.TabIndex = 0;
            // 
            // frmProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(408, 441);
            this.Controls.Add(this.profileUser1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmProfile";
            this.Text = "frmProfile";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.ProfileUser profileUser1;
    }
}