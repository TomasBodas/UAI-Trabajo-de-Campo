﻿
namespace UAICampo.UI
{
    partial class frmProposal
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
            this.proposalController1 = new UAICampo.UI.Controllers.ProposalController();
            this.SuspendLayout();
            // 
            // proposalController1
            // 
            this.proposalController1.Location = new System.Drawing.Point(12, 12);
            this.proposalController1.Name = "proposalController1";
            this.proposalController1.Size = new System.Drawing.Size(857, 358);
            this.proposalController1.TabIndex = 0;
            // 
            // frmProposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UAICampo.UI.Properties.Resources.background2;
            this.ClientSize = new System.Drawing.Size(885, 387);
            this.Controls.Add(this.proposalController1);
            this.Name = "frmProposal";
            this.Text = "frmProposal";
            this.ResumeLayout(false);

        }

        #endregion

        private Controllers.ProposalController proposalController1;
    }
}