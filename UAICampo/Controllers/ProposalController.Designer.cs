
namespace UAICampo.UI.Controllers
{
    partial class ProposalController
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
            this.labelProposal = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBoxScores = new System.Windows.Forms.GroupBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxScores.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelProposal
            // 
            this.labelProposal.AutoSize = true;
            this.labelProposal.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProposal.Location = new System.Drawing.Point(17, 11);
            this.labelProposal.Name = "labelProposal";
            this.labelProposal.Size = new System.Drawing.Size(137, 35);
            this.labelProposal.TabIndex = 1;
            this.labelProposal.Text = "Proposal";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(168, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(642, 243);
            this.dataGridView1.TabIndex = 2;
            // 
            // groupBoxScores
            // 
            this.groupBoxScores.Controls.Add(this.groupBoxPosition);
            this.groupBoxScores.Controls.Add(this.buttonSelect);
            this.groupBoxScores.Controls.Add(this.dataGridView1);
            this.groupBoxScores.Location = new System.Drawing.Point(14, 59);
            this.groupBoxScores.Name = "groupBoxScores";
            this.groupBoxScores.Size = new System.Drawing.Size(825, 280);
            this.groupBoxScores.TabIndex = 4;
            this.groupBoxScores.TabStop = false;
            this.groupBoxScores.Text = "Scores";
            // 
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(30, 47);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(104, 23);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.buttonFilter);
            this.groupBoxPosition.Controls.Add(this.comboBoxPosition);
            this.groupBoxPosition.Location = new System.Drawing.Point(24, 90);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(116, 78);
            this.groupBoxPosition.TabIndex = 9;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Position";
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(22, 46);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 1;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(6, 19);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(104, 21);
            this.comboBoxPosition.TabIndex = 0;
            // 
            // ProposalController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxScores);
            this.Controls.Add(this.labelProposal);
            this.Name = "ProposalController";
            this.Size = new System.Drawing.Size(857, 358);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxScores.ResumeLayout(false);
            this.groupBoxPosition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelProposal;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxScores;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxPosition;
    }
}
