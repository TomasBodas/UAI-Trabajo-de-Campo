﻿
namespace UAICampo.UI.Administrator
{
    partial class frmChangelog
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
            this.changelogController1 = new UAICampo.UI.Controllers.ChangelogController();
            this.SuspendLayout();
            // 
            // changelogController1
            // 
            this.changelogController1.Location = new System.Drawing.Point(12, 12);
            this.changelogController1.Name = "changelogController1";
            this.changelogController1.Size = new System.Drawing.Size(671, 473);
            this.changelogController1.TabIndex = 0;
            // 
            // frmChangelog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(696, 497);
            this.Controls.Add(this.changelogController1);
            this.Name = "frmChangelog";
            this.Text = "frmChangelog";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.ChangelogController changelogController1;
    }
}