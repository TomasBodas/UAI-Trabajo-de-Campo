
namespace UAICampo.UI
{
    partial class frmBusqueda
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
            this.searchUserController1 = new UAICampo.UI.Controllers.SearchUserController();
            this.SuspendLayout();
            // 
            // searchUserController1
            // 
            this.searchUserController1.Location = new System.Drawing.Point(12, 12);
            this.searchUserController1.Name = "searchUserController1";
            this.searchUserController1.Size = new System.Drawing.Size(697, 228);
            this.searchUserController1.TabIndex = 0;
            // 
            // frmBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(723, 254);
            this.Controls.Add(this.searchUserController1);
            this.Name = "frmBusqueda";
            this.Text = "frmBusqueda";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.SearchUserController searchUserController1;
    }
}