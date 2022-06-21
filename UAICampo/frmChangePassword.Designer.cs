
namespace UAICampo.UI
{
    partial class frmChangePassword
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
            this.password_Change1 = new UAICampo.UI.Controllers.Password_Change();
            this.SuspendLayout();
            // 
            // password_Change1
            // 
            this.password_Change1.Location = new System.Drawing.Point(30, 30);
            this.password_Change1.Name = "password_Change1";
            this.password_Change1.Size = new System.Drawing.Size(253, 184);
            this.password_Change1.TabIndex = 0;
            // 
            // frmChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(320, 240);
            this.Controls.Add(this.password_Change1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmChangePassword";
            this.Text = "frmChangePassword";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.Password_Change password_Change1;
    }
}