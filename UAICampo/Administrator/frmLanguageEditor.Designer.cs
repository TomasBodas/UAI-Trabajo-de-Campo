
namespace UAICampo.UI
{
    partial class frmLanguageEditor
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
            this.languageEditorController1 = new UAICampo.UI.Controllers.LanguageEditorController();
            this.SuspendLayout();
            // 
            // languageEditorController1
            // 
            this.languageEditorController1.Location = new System.Drawing.Point(12, 12);
            this.languageEditorController1.Name = "languageEditorController1";
            this.languageEditorController1.Size = new System.Drawing.Size(394, 485);
            this.languageEditorController1.TabIndex = 0;
            // 
            // frmLanguageEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(422, 506);
            this.Controls.Add(this.languageEditorController1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmLanguageEditor";
            this.Text = "frmLanguageEditor";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.LanguageEditorController languageEditorController1;
    }
}