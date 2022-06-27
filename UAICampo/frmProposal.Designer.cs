
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
            this.groupBoxScores = new System.Windows.Forms.GroupBox();
            this.groupBoxSearch = new System.Windows.Forms.GroupBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.dataGridViewProposal = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioReconocimientoSuperiores = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PorcentajeObjetivosCumplidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioReconocimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadObjetivosNoCumplidos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadReconocimientos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelProposal = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.groupBoxScores.SuspendLayout();
            this.groupBoxSearch.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProposal)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxScores
            // 
            this.groupBoxScores.Controls.Add(this.buttonRefresh);
            this.groupBoxScores.Controls.Add(this.groupBoxSearch);
            this.groupBoxScores.Controls.Add(this.groupBoxPosition);
            this.groupBoxScores.Controls.Add(this.buttonSelect);
            this.groupBoxScores.Controls.Add(this.dataGridViewProposal);
            this.groupBoxScores.Location = new System.Drawing.Point(30, 77);
            this.groupBoxScores.Name = "groupBoxScores";
            this.groupBoxScores.Size = new System.Drawing.Size(825, 280);
            this.groupBoxScores.TabIndex = 6;
            this.groupBoxScores.TabStop = false;
            this.groupBoxScores.Text = "Scores";
            // 
            // groupBoxSearch
            // 
            this.groupBoxSearch.Controls.Add(this.buttonSearch);
            this.groupBoxSearch.Controls.Add(this.textBox1);
            this.groupBoxSearch.Location = new System.Drawing.Point(24, 188);
            this.groupBoxSearch.Name = "groupBoxSearch";
            this.groupBoxSearch.Size = new System.Drawing.Size(116, 74);
            this.groupBoxSearch.TabIndex = 10;
            this.groupBoxSearch.TabStop = false;
            this.groupBoxSearch.Text = "Search";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(22, 45);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(10, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 6;
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.buttonFilter);
            this.groupBoxPosition.Controls.Add(this.comboBoxPosition);
            this.groupBoxPosition.Location = new System.Drawing.Point(24, 104);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(116, 78);
            this.groupBoxPosition.TabIndex = 9;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Position";
            this.groupBoxPosition.Visible = false;
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
            // buttonSelect
            // 
            this.buttonSelect.Location = new System.Drawing.Point(30, 33);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(104, 51);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Text = "Select";
            this.buttonSelect.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProposal
            // 
            this.dataGridViewProposal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProposal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Username,
            this.Profile,
            this.Value,
            this.PromedioReconocimientoSuperiores,
            this.PorcentajeObjetivosCumplidos,
            this.PromedioReconocimiento,
            this.CantidadObjetivosNoCumplidos,
            this.CantidadReconocimientos});
            this.dataGridViewProposal.Location = new System.Drawing.Point(166, 19);
            this.dataGridViewProposal.Name = "dataGridViewProposal";
            this.dataGridViewProposal.Size = new System.Drawing.Size(642, 243);
            this.dataGridViewProposal.TabIndex = 2;
            // 
            // Id
            // 
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            // 
            // Username
            // 
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            // 
            // Profile
            // 
            this.Profile.HeaderText = "Profile";
            this.Profile.Name = "Profile";
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // PromedioReconocimientoSuperiores
            // 
            this.PromedioReconocimientoSuperiores.HeaderText = "Promedio Reconocimiento Superiores";
            this.PromedioReconocimientoSuperiores.Name = "PromedioReconocimientoSuperiores";
            // 
            // PorcentajeObjetivosCumplidos
            // 
            this.PorcentajeObjetivosCumplidos.HeaderText = "Porcentaje Objetivos Cumplidos";
            this.PorcentajeObjetivosCumplidos.Name = "PorcentajeObjetivosCumplidos";
            // 
            // PromedioReconocimiento
            // 
            this.PromedioReconocimiento.HeaderText = "Promedio Reconocimiento";
            this.PromedioReconocimiento.Name = "PromedioReconocimiento";
            // 
            // CantidadObjetivosNoCumplidos
            // 
            this.CantidadObjetivosNoCumplidos.HeaderText = "Cantidad Objetivos No Cumplidos";
            this.CantidadObjetivosNoCumplidos.Name = "CantidadObjetivosNoCumplidos";
            // 
            // CantidadReconocimientos
            // 
            this.CantidadReconocimientos.HeaderText = "Cantidad Reconocimientos";
            this.CantidadReconocimientos.Name = "CantidadReconocimientos";
            // 
            // labelProposal
            // 
            this.labelProposal.AutoSize = true;
            this.labelProposal.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelProposal.Location = new System.Drawing.Point(33, 29);
            this.labelProposal.Name = "labelProposal";
            this.labelProposal.Size = new System.Drawing.Size(137, 35);
            this.labelProposal.TabIndex = 5;
            this.labelProposal.Text = "Proposal";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(30, 91);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(104, 23);
            this.buttonRefresh.TabIndex = 11;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // frmProposal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 387);
            this.Controls.Add(this.groupBoxScores);
            this.Controls.Add(this.labelProposal);
            this.Name = "frmProposal";
            this.Text = "frmProposal";
            this.Load += new System.EventHandler(this.frmProposal_Load);
            this.groupBoxScores.ResumeLayout(false);
            this.groupBoxSearch.ResumeLayout(false);
            this.groupBoxSearch.PerformLayout();
            this.groupBoxPosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProposal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxScores;
        private System.Windows.Forms.GroupBox groupBoxSearch;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.DataGridView dataGridViewProposal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioReconocimientoSuperiores;
        private System.Windows.Forms.DataGridViewTextBoxColumn PorcentajeObjetivosCumplidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioReconocimiento;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadObjetivosNoCumplidos;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadReconocimientos;
        private System.Windows.Forms.Label labelProposal;
        private System.Windows.Forms.Button buttonRefresh;
    }
}