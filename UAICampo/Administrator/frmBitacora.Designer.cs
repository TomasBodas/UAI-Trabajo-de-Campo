
namespace UAICampo.UI.Administrator
{
    partial class frmBitacora
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
            this.bitacoraController1 = new UAICampo.UI.Controllers.BitacoraController();
            this.SuspendLayout();
            // 
            // bitacoraController1
            // 
            this.bitacoraController1.Location = new System.Drawing.Point(12, 5);
            this.bitacoraController1.Name = "bitacoraController1";
            this.bitacoraController1.Size = new System.Drawing.Size(571, 473);
            this.bitacoraController1.TabIndex = 0;
            // 
            // frmBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(594, 490);
            this.Controls.Add(this.bitacoraController1);
            this.Name = "frmBitacora";
            this.Text = "frmBitacora";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.BitacoraController bitacoraController1;
    }
}