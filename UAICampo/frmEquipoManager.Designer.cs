
namespace UAICampo.UI
{
    partial class frmEquipoManager
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
            this.equipoController1 = new UAICampo.UI.Controllers.EquipoController();
            this.SuspendLayout();
            // 
            // equipoController1
            // 
            this.equipoController1.Location = new System.Drawing.Point(28, 12);
            this.equipoController1.Name = "equipoController1";
            this.equipoController1.Size = new System.Drawing.Size(386, 459);
            this.equipoController1.TabIndex = 0;
            // 
            // frmEquipoManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(436, 486);
            this.Controls.Add(this.equipoController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmEquipoManager";
            this.Text = "frmEquipoManager";
            this.Load += new System.EventHandler(this.frmEquipoManager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.EquipoController equipoController1;
    }
}