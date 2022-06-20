
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
            this.label_Province = new System.Windows.Forms.Label();
            this.label_Speciality = new System.Windows.Forms.Label();
            this.button_Search = new System.Windows.Forms.Button();
            this.comboBox_Province = new System.Windows.Forms.ComboBox();
            this.comboBox_Speciality = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView_Offices = new System.Windows.Forms.DataGridView();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.button_AskAppointment = new System.Windows.Forms.Button();
            this.dataGridView_FoundResults = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelClientEmail = new System.Windows.Forms.Label();
            this.labelClientLastname = new System.Windows.Forms.Label();
            this.labelClientName = new System.Windows.Forms.Label();
            this.labelOfficeProvince = new System.Windows.Forms.Label();
            this.labelOfficeAddress2 = new System.Windows.Forms.Label();
            this.labelOfficeAddres1 = new System.Windows.Forms.Label();
            this.dataGridView_procedures = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label_date = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Offices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FoundResults)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_procedures)).BeginInit();
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
            this.button_AskAppointment.Click += new System.EventHandler(this.button_AskAppointment_Click);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.label_date);
            this.panel3.Controls.Add(this.dateTimePicker1);
            this.panel3.Controls.Add(this.dataGridView_procedures);
            this.panel3.Controls.Add(this.labelOfficeProvince);
            this.panel3.Controls.Add(this.labelOfficeAddress2);
            this.panel3.Controls.Add(this.labelOfficeAddres1);
            this.panel3.Controls.Add(this.labelClientEmail);
            this.panel3.Controls.Add(this.labelClientLastname);
            this.panel3.Controls.Add(this.labelClientName);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.button1);
            this.panel3.Location = new System.Drawing.Point(23, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(443, 646);
            this.panel3.TabIndex = 17;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(36, 571);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 40);
            this.button1.TabIndex = 21;
            this.button1.Text = "Appointment";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(248, 571);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 40);
            this.button2.TabIndex = 21;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelClientEmail
            // 
            this.labelClientEmail.AutoSize = true;
            this.labelClientEmail.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientEmail.ForeColor = System.Drawing.Color.White;
            this.labelClientEmail.Location = new System.Drawing.Point(58, 113);
            this.labelClientEmail.Name = "labelClientEmail";
            this.labelClientEmail.Size = new System.Drawing.Size(82, 24);
            this.labelClientEmail.TabIndex = 24;
            this.labelClientEmail.Text = "label3";
            // 
            // labelClientLastname
            // 
            this.labelClientLastname.AutoSize = true;
            this.labelClientLastname.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientLastname.ForeColor = System.Drawing.Color.White;
            this.labelClientLastname.Location = new System.Drawing.Point(58, 69);
            this.labelClientLastname.Name = "labelClientLastname";
            this.labelClientLastname.Size = new System.Drawing.Size(82, 24);
            this.labelClientLastname.TabIndex = 23;
            this.labelClientLastname.Text = "label2";
            // 
            // labelClientName
            // 
            this.labelClientName.AutoSize = true;
            this.labelClientName.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientName.ForeColor = System.Drawing.Color.White;
            this.labelClientName.Location = new System.Drawing.Point(58, 24);
            this.labelClientName.Name = "labelClientName";
            this.labelClientName.Size = new System.Drawing.Size(82, 24);
            this.labelClientName.TabIndex = 22;
            this.labelClientName.Text = "label1";
            // 
            // labelOfficeProvince
            // 
            this.labelOfficeProvince.AutoSize = true;
            this.labelOfficeProvince.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfficeProvince.ForeColor = System.Drawing.Color.White;
            this.labelOfficeProvince.Location = new System.Drawing.Point(244, 113);
            this.labelOfficeProvince.Name = "labelOfficeProvince";
            this.labelOfficeProvince.Size = new System.Drawing.Size(82, 24);
            this.labelOfficeProvince.TabIndex = 27;
            this.labelOfficeProvince.Text = "label4";
            // 
            // labelOfficeAddress2
            // 
            this.labelOfficeAddress2.AutoSize = true;
            this.labelOfficeAddress2.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfficeAddress2.ForeColor = System.Drawing.Color.White;
            this.labelOfficeAddress2.Location = new System.Drawing.Point(244, 69);
            this.labelOfficeAddress2.Name = "labelOfficeAddress2";
            this.labelOfficeAddress2.Size = new System.Drawing.Size(82, 24);
            this.labelOfficeAddress2.TabIndex = 26;
            this.labelOfficeAddress2.Text = "label4";
            // 
            // labelOfficeAddres1
            // 
            this.labelOfficeAddres1.AutoSize = true;
            this.labelOfficeAddres1.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOfficeAddres1.ForeColor = System.Drawing.Color.White;
            this.labelOfficeAddres1.Location = new System.Drawing.Point(244, 24);
            this.labelOfficeAddres1.Name = "labelOfficeAddres1";
            this.labelOfficeAddres1.Size = new System.Drawing.Size(82, 24);
            this.labelOfficeAddres1.TabIndex = 25;
            this.labelOfficeAddres1.Text = "label4";
            // 
            // dataGridView_procedures
            // 
            this.dataGridView_procedures.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_procedures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_procedures.Location = new System.Drawing.Point(28, 189);
            this.dataGridView_procedures.Name = "dataGridView_procedures";
            this.dataGridView_procedures.RowHeadersVisible = false;
            this.dataGridView_procedures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_procedures.Size = new System.Drawing.Size(443, 137);
            this.dataGridView_procedures.TabIndex = 28;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(210, 389);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_date.ForeColor = System.Drawing.Color.White;
            this.label_date.Location = new System.Drawing.Point(58, 385);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(58, 24);
            this.label_date.TabIndex = 30;
            this.label_date.Text = "date";
            // 
            // FindDr___Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(82)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1215, 732);
            this.Controls.Add(this.panel3);
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Offices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FoundResults)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_procedures)).EndInit();
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
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelClientEmail;
        private System.Windows.Forms.Label labelClientLastname;
        private System.Windows.Forms.Label labelClientName;
        private System.Windows.Forms.Label labelOfficeProvince;
        private System.Windows.Forms.Label labelOfficeAddress2;
        private System.Windows.Forms.Label labelOfficeAddres1;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridView dataGridView_procedures;
    }
}