
namespace UAICampo.UI
{
    partial class Equipo_Manager
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxTeams = new System.Windows.Forms.GroupBox();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.groupBoxLeader = new System.Windows.Forms.GroupBox();
            this.buttonScores = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxTeams.SuspendLayout();
            this.groupBoxLeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxTeams
            // 
            this.groupBoxTeams.Controls.Add(this.buttonDetails);
            this.groupBoxTeams.Location = new System.Drawing.Point(15, 17);
            this.groupBoxTeams.Name = "groupBoxTeams";
            this.groupBoxTeams.Size = new System.Drawing.Size(205, 61);
            this.groupBoxTeams.TabIndex = 0;
            this.groupBoxTeams.TabStop = false;
            this.groupBoxTeams.Text = "Manage Teams";
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(14, 24);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 1;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // groupBoxLeader
            // 
            this.groupBoxLeader.Controls.Add(this.buttonScores);
            this.groupBoxLeader.Controls.Add(this.button2);
            this.groupBoxLeader.Location = new System.Drawing.Point(15, 96);
            this.groupBoxLeader.Name = "groupBoxLeader";
            this.groupBoxLeader.Size = new System.Drawing.Size(205, 56);
            this.groupBoxLeader.TabIndex = 1;
            this.groupBoxLeader.TabStop = false;
            this.groupBoxLeader.Text = "Leader actions";
            // 
            // buttonScores
            // 
            this.buttonScores.Location = new System.Drawing.Point(96, 19);
            this.buttonScores.Name = "buttonScores";
            this.buttonScores.Size = new System.Drawing.Size(93, 23);
            this.buttonScores.TabIndex = 0;
            this.buttonScores.Text = "Member scores";
            this.buttonScores.UseVisualStyleBackColor = true;
            this.buttonScores.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Create Epic";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Equipo_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBoxLeader);
            this.Controls.Add(this.groupBoxTeams);
            this.Name = "Equipo_Manager";
            this.Size = new System.Drawing.Size(238, 169);
            this.groupBoxTeams.ResumeLayout(false);
            this.groupBoxLeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxTeams;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.GroupBox groupBoxLeader;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonScores;
    }
}
