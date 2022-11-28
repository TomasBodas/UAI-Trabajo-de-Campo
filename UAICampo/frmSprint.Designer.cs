
namespace UAICampo.UI
{
    partial class frmSprint
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
            this.groupBoxScores = new System.Windows.Forms.GroupBox();
            this.dataGridViewProposal = new System.Windows.Forms.DataGridView();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioReconocimientoSuperiores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeObjetivosCumplidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioReconocimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadObjetivosNoCumplidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadReconocimientos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonExport = new System.Windows.Forms.Button();
            this.labelStats = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonXML = new System.Windows.Forms.Button();
            this.groupBoxScores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProposal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxScores
            // 
            this.groupBoxScores.Controls.Add(this.dataGridViewProposal);
            this.groupBoxScores.Location = new System.Drawing.Point(12, 59);
            this.groupBoxScores.Name = "groupBoxScores";
            this.groupBoxScores.Size = new System.Drawing.Size(752, 280);
            this.groupBoxScores.TabIndex = 7;
            this.groupBoxScores.TabStop = false;
            this.groupBoxScores.Text = "Scores";
            // 
            // dataGridViewProposal
            // 
            this.dataGridViewProposal.AllowUserToAddRows = false;
            this.dataGridViewProposal.AllowUserToDeleteRows = false;
            this.dataGridViewProposal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProposal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Username,
            this.Profile,
            this.Value,
            this.PromedioReconocimientoSuperiores,
            this.PorcentajeObjetivosCumplidos,
            this.PromedioReconocimiento,
            this.CantidadObjetivosNoCumplidos,
            this.CantidadReconocimientos});
            this.dataGridViewProposal.Location = new System.Drawing.Point(13, 19);
            this.dataGridViewProposal.Name = "dataGridViewProposal";
            this.dataGridViewProposal.ReadOnly = true;
            this.dataGridViewProposal.RowHeadersVisible = false;
            this.dataGridViewProposal.Size = new System.Drawing.Size(721, 243);
            this.dataGridViewProposal.TabIndex = 2;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 80;
            // 
            // Profile
            // 
            this.Profile.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Profile.HeaderText = "Profile";
            this.Profile.Name = "Profile";
            this.Profile.ReadOnly = true;
            this.Profile.Width = 61;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            this.Value.Width = 59;
            // 
            // PromedioReconocimientoSuperiores
            // 
            this.PromedioReconocimientoSuperiores.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PromedioReconocimientoSuperiores.HeaderText = "Promedio Reconocimiento Superiores";
            this.PromedioReconocimientoSuperiores.Name = "PromedioReconocimientoSuperiores";
            this.PromedioReconocimientoSuperiores.ReadOnly = true;
            // 
            // PorcentajeObjetivosCumplidos
            // 
            this.PorcentajeObjetivosCumplidos.HeaderText = "Porcentaje Objetivos Cumplidos";
            this.PorcentajeObjetivosCumplidos.Name = "PorcentajeObjetivosCumplidos";
            this.PorcentajeObjetivosCumplidos.ReadOnly = true;
            // 
            // PromedioReconocimiento
            // 
            this.PromedioReconocimiento.HeaderText = "Promedio Reconocimiento";
            this.PromedioReconocimiento.Name = "PromedioReconocimiento";
            this.PromedioReconocimiento.ReadOnly = true;
            // 
            // CantidadObjetivosNoCumplidos
            // 
            this.CantidadObjetivosNoCumplidos.HeaderText = "Cantidad Objetivos No Cumplidos";
            this.CantidadObjetivosNoCumplidos.Name = "CantidadObjetivosNoCumplidos";
            this.CantidadObjetivosNoCumplidos.ReadOnly = true;
            // 
            // CantidadReconocimientos
            // 
            this.CantidadReconocimientos.HeaderText = "Cantidad Reconocimientos";
            this.CantidadReconocimientos.Name = "CantidadReconocimientos";
            this.CantidadReconocimientos.ReadOnly = true;
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(871, 519);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(105, 68);
            this.buttonExport.TabIndex = 11;
            this.buttonExport.Text = "Export to PDF";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // labelStats
            // 
            this.labelStats.AutoSize = true;
            this.labelStats.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelStats.Location = new System.Drawing.Point(19, 12);
            this.labelStats.Name = "labelStats";
            this.labelStats.Size = new System.Drawing.Size(171, 35);
            this.labelStats.TabIndex = 8;
            this.labelStats.Text = "Sprint stats";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listBox2);
            this.groupBox1.Controls.Add(this.listBox1);
            this.groupBox1.Location = new System.Drawing.Point(103, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(585, 242);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tasks";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Unfinished:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Completed:";
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(314, 38);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(232, 186);
            this.listBox2.TabIndex = 1;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(18, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 186);
            this.listBox1.TabIndex = 0;
            // 
            // buttonXML
            // 
            this.buttonXML.Location = new System.Drawing.Point(871, 490);
            this.buttonXML.Name = "buttonXML";
            this.buttonXML.Size = new System.Drawing.Size(105, 23);
            this.buttonXML.TabIndex = 13;
            this.buttonXML.Text = "Export to XML";
            this.buttonXML.UseVisualStyleBackColor = true;
            this.buttonXML.Click += new System.EventHandler(this.buttonXML_Click);
            // 
            // frmSprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 599);
            this.Controls.Add(this.buttonXML);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.labelStats);
            this.Controls.Add(this.groupBoxScores);
            this.Name = "frmSprint";
            this.Text = "frmSprint";
            this.Load += new System.EventHandler(this.frmSprint_Load);
            this.groupBoxScores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProposal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxScores;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.DataGridView dataGridViewProposal;
        private System.Windows.Forms.Label labelStats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioReconocimientoSuperiores;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeObjetivosCumplidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioReconocimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadObjetivosNoCumplidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadReconocimientos;
        private System.Windows.Forms.Button buttonXML;
    }
}