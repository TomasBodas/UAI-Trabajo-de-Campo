
namespace UAICampo.UI
{
    partial class FindDr___Search
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
            this.button_addAddress = new System.Windows.Forms.Button();
            this.label_nonExistingAddress = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox_Speciality = new System.Windows.Forms.ComboBox();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.button_Search = new System.Windows.Forms.Button();
            this.label_Speciality = new System.Windows.Forms.Label();
            this.label_Province = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_FoundResults = new System.Windows.Forms.DataGridView();
            this.button_AskAppointment = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.dataGridView_Offices = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FoundResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Offices)).BeginInit();
            this.SuspendLayout();
            // 
            // button_addAddress
            // 
            this.button_addAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_addAddress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_addAddress.FlatAppearance.BorderSize = 0;
            this.button_addAddress.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_addAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addAddress.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addAddress.ForeColor = System.Drawing.Color.White;
            this.button_addAddress.Location = new System.Drawing.Point(514, 203);
            this.button_addAddress.Name = "button_addAddress";
            this.button_addAddress.Size = new System.Drawing.Size(139, 40);
            this.button_addAddress.TabIndex = 12;
            this.button_addAddress.Text = "addAddress";
            this.button_addAddress.UseVisualStyleBackColor = false;
            this.button_addAddress.Click += new System.EventHandler(this.button_addAddress_Click);
            // 
            // label_nonExistingAddress
            // 
            this.label_nonExistingAddress.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_nonExistingAddress.AutoSize = true;
            this.label_nonExistingAddress.Font = new System.Drawing.Font("BIZ UDPGothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nonExistingAddress.ForeColor = System.Drawing.Color.White;
            this.label_nonExistingAddress.Location = new System.Drawing.Point(542, 105);
            this.label_nonExistingAddress.Name = "label_nonExistingAddress";
            this.label_nonExistingAddress.Size = new System.Drawing.Size(111, 29);
            this.label_nonExistingAddress.TabIndex = 13;
            this.label_nonExistingAddress.Text = "label1";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Right;
            this.webBrowser1.Location = new System.Drawing.Point(498, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(717, 732);
            this.webBrowser1.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_Province);
            this.panel1.Controls.Add(this.label_Speciality);
            this.panel1.Controls.Add(this.button_Search);
            this.panel1.Controls.Add(this.comboBox_Province);
            this.panel1.Controls.Add(this.comboBox_Speciality);
            this.panel1.Location = new System.Drawing.Point(23, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 495);
            this.panel1.TabIndex = 15;
            // 
            // comboBox_Speciality
            // 
            this.comboBox_Speciality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Speciality.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Speciality.FormattingEnabled = true;
            this.comboBox_Speciality.Location = new System.Drawing.Point(200, 61);
            this.comboBox_Speciality.Name = "comboBox_Speciality";
            this.comboBox_Speciality.Size = new System.Drawing.Size(210, 32);
            this.comboBox_Speciality.TabIndex = 0;
            // 
            // comboBox_Province
            // 
            this.comboBox_Province.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Province.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_Province.FormattingEnabled = true;
            this.comboBox_Province.Location = new System.Drawing.Point(200, 186);
            this.comboBox_Province.Name = "comboBox_Province";
            this.comboBox_Province.Size = new System.Drawing.Size(210, 32);
            this.comboBox_Province.TabIndex = 1;
            // 
            // button_Search
            // 
            this.button_Search.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_Search.FlatAppearance.BorderSize = 0;
            this.button_Search.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Search.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Search.ForeColor = System.Drawing.Color.White;
            this.button_Search.Location = new System.Drawing.Point(141, 326);
            this.button_Search.Name = "button_Search";
            this.button_Search.Size = new System.Drawing.Size(139, 40);
            this.button_Search.TabIndex = 16;
            this.button_Search.Text = "search";
            this.button_Search.UseVisualStyleBackColor = false;
            this.button_Search.Click += new System.EventHandler(this.button_Search_Click);
            // 
            // label_Speciality
            // 
            this.label_Speciality.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Speciality.AutoSize = true;
            this.label_Speciality.Font = new System.Drawing.Font("BIZ UDPGothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Speciality.ForeColor = System.Drawing.Color.White;
            this.label_Speciality.Location = new System.Drawing.Point(30, 64);
            this.label_Speciality.Name = "label_Speciality";
            this.label_Speciality.Size = new System.Drawing.Size(111, 29);
            this.label_Speciality.TabIndex = 16;
            this.label_Speciality.Text = "label1";
            // 
            // label_Province
            // 
            this.label_Province.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Province.AutoSize = true;
            this.label_Province.Font = new System.Drawing.Font("BIZ UDPGothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Province.ForeColor = System.Drawing.Color.White;
            this.label_Province.Location = new System.Drawing.Point(30, 189);
            this.label_Province.Name = "label_Province";
            this.label_Province.Size = new System.Drawing.Size(111, 29);
            this.label_Province.TabIndex = 17;
            this.label_Province.Text = "label1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView_Offices);
            this.panel2.Controls.Add(this.button_Cancel);
            this.panel2.Controls.Add(this.button_AskAppointment);
            this.panel2.Controls.Add(this.dataGridView_FoundResults);
            this.panel2.Location = new System.Drawing.Point(23, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(443, 643);
            this.panel2.TabIndex = 16;
            // 
            // dataGridView_FoundResults
            // 
            this.dataGridView_FoundResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_FoundResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FoundResults.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_FoundResults.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_FoundResults.Name = "dataGridView_FoundResults";
            this.dataGridView_FoundResults.RowHeadersVisible = false;
            this.dataGridView_FoundResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_FoundResults.Size = new System.Drawing.Size(443, 319);
            this.dataGridView_FoundResults.TabIndex = 0;
            this.dataGridView_FoundResults.SelectionChanged += new System.EventHandler(this.dataGridView_FoundResults_SelectionChanged);
            // 
            // button_AskAppointment
            // 
            this.button_AskAppointment.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_AskAppointment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_AskAppointment.FlatAppearance.BorderSize = 0;
            this.button_AskAppointment.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_AskAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_AskAppointment.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AskAppointment.ForeColor = System.Drawing.Color.White;
            this.button_AskAppointment.Location = new System.Drawing.Point(51, 569);
            this.button_AskAppointment.Name = "button_AskAppointment";
            this.button_AskAppointment.Size = new System.Drawing.Size(139, 40);
            this.button_AskAppointment.TabIndex = 18;
            this.button_AskAppointment.Text = "Appointment";
            this.button_AskAppointment.UseVisualStyleBackColor = false;
            // 
            // button_Cancel
            // 
            this.button_Cancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_Cancel.FlatAppearance.BorderSize = 0;
            this.button_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Cancel.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.ForeColor = System.Drawing.Color.White;
            this.button_Cancel.Location = new System.Drawing.Point(247, 569);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(139, 40);
            this.button_Cancel.TabIndex = 19;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = false;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // dataGridView_Offices
            // 
            this.dataGridView_Offices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_Offices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Offices.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView_Offices.Location = new System.Drawing.Point(0, 319);
            this.dataGridView_Offices.Name = "dataGridView_Offices";
            this.dataGridView_Offices.RowHeadersVisible = false;
            this.dataGridView_Offices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Offices.Size = new System.Drawing.Size(443, 137);
            this.dataGridView_Offices.TabIndex = 20;
            this.dataGridView_Offices.SelectionChanged += new System.EventHandler(this.dataGridView_Offices_SelectionChanged);
            // 
            // FindDr___Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(82)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1215, 732);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label_nonExistingAddress);
            this.Controls.Add(this.button_addAddress);
            this.Name = "FindDr___Search";
            this.Text = "FindDr___Search";
            this.Load += new System.EventHandler(this.FindDr___Search_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FoundResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Offices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_addAddress;
        private System.Windows.Forms.Label label_nonExistingAddress;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_Search;
        private System.Windows.Forms.ComboBox comboBox_Province;
        private System.Windows.Forms.ComboBox comboBox_Speciality;
        private System.Windows.Forms.Label label_Province;
        private System.Windows.Forms.Label label_Speciality;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.Button button_AskAppointment;
        private System.Windows.Forms.DataGridView dataGridView_FoundResults;
        private System.Windows.Forms.DataGridView dataGridView_Offices;
    }
}