
namespace UAICampo.UI
{
    partial class frmEpicaDetalle
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
            this.epicasDetalleController1 = new UAICampo.UI.Controllers.EpicasDetalleController();
            this.SuspendLayout();
            // 
            // epicasDetalleController1
            // 
            this.epicasDetalleController1.Location = new System.Drawing.Point(12, 12);
            this.epicasDetalleController1.Name = "epicasDetalleController1";
            this.epicasDetalleController1.Size = new System.Drawing.Size(446, 297);
            this.epicasDetalleController1.TabIndex = 0;
            // 
            // frmEpicaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(471, 324);
            this.Controls.Add(this.epicasDetalleController1);
            this.Name = "frmEpicaDetalle";
            this.Text = "frmEpicaDetalle";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.EpicasDetalleController epicasDetalleController1;
    }
}