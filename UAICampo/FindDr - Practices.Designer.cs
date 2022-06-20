
namespace UAICampo.UI
{
    partial class FindDr___Practices
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_deleteProcedure = new System.Windows.Forms.Button();
            this.button_addProcedure = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label_Name = new System.Windows.Forms.Label();
            this.label_Description = new System.Windows.Forms.Label();
            this.label_Price = new System.Windows.Forms.Label();
            this.label_Title_AddProcedure = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1164, 289);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // button_deleteProcedure
            // 
            this.button_deleteProcedure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_deleteProcedure.FlatAppearance.BorderSize = 0;
            this.button_deleteProcedure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_deleteProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_deleteProcedure.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_deleteProcedure.ForeColor = System.Drawing.Color.White;
            this.button_deleteProcedure.Location = new System.Drawing.Point(982, 332);
            this.button_deleteProcedure.Name = "button_deleteProcedure";
            this.button_deleteProcedure.Size = new System.Drawing.Size(139, 40);
            this.button_deleteProcedure.TabIndex = 25;
            this.button_deleteProcedure.Text = "Remove";
            this.button_deleteProcedure.UseVisualStyleBackColor = false;
            this.button_deleteProcedure.Click += new System.EventHandler(this.button_deleteProcedure_Click);
            // 
            // button_addProcedure
            // 
            this.button_addProcedure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(194)))), ((int)(((byte)(180)))));
            this.button_addProcedure.FlatAppearance.BorderSize = 0;
            this.button_addProcedure.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(239)))), ((int)(((byte)(147)))));
            this.button_addProcedure.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_addProcedure.Font = new System.Drawing.Font("BIZ UDPGothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addProcedure.ForeColor = System.Drawing.Color.White;
            this.button_addProcedure.Location = new System.Drawing.Point(274, 549);
            this.button_addProcedure.Name = "button_addProcedure";
            this.button_addProcedure.Size = new System.Drawing.Size(139, 40);
            this.button_addProcedure.TabIndex = 24;
            this.button_addProcedure.Text = "Add";
            this.button_addProcedure.UseVisualStyleBackColor = false;
            this.button_addProcedure.Click += new System.EventHandler(this.button_addProcedure_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_name.Location = new System.Drawing.Point(208, 395);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(300, 31);
            this.textBox_name.TabIndex = 26;
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // textBox_description
            // 
            this.textBox_description.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_description.Location = new System.Drawing.Point(208, 442);
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(300, 31);
            this.textBox_description.TabIndex = 27;
            this.textBox_description.TextChanged += new System.EventHandler(this.textBox_description_TextChanged);
            // 
            // textBox_price
            // 
            this.textBox_price.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_price.Location = new System.Drawing.Point(208, 488);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.Size = new System.Drawing.Size(300, 31);
            this.textBox_price.TabIndex = 28;
            this.textBox_price.TextChanged += new System.EventHandler(this.textBox_price_TextChanged);
            // 
            // label_Name
            // 
            this.label_Name.AutoSize = true;
            this.label_Name.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Name.ForeColor = System.Drawing.Color.White;
            this.label_Name.Location = new System.Drawing.Point(52, 402);
            this.label_Name.Name = "label_Name";
            this.label_Name.Size = new System.Drawing.Size(82, 24);
            this.label_Name.TabIndex = 29;
            this.label_Name.Text = "label1";
            // 
            // label_Description
            // 
            this.label_Description.AutoSize = true;
            this.label_Description.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Description.ForeColor = System.Drawing.Color.White;
            this.label_Description.Location = new System.Drawing.Point(52, 452);
            this.label_Description.Name = "label_Description";
            this.label_Description.Size = new System.Drawing.Size(82, 24);
            this.label_Description.TabIndex = 30;
            this.label_Description.Text = "label2";
            // 
            // label_Price
            // 
            this.label_Price.AutoSize = true;
            this.label_Price.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Price.ForeColor = System.Drawing.Color.White;
            this.label_Price.Location = new System.Drawing.Point(52, 498);
            this.label_Price.Name = "label_Price";
            this.label_Price.Size = new System.Drawing.Size(82, 24);
            this.label_Price.TabIndex = 31;
            this.label_Price.Text = "label3";
            // 
            // label_Title_AddProcedure
            // 
            this.label_Title_AddProcedure.AutoSize = true;
            this.label_Title_AddProcedure.Font = new System.Drawing.Font("BIZ UDGothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Title_AddProcedure.ForeColor = System.Drawing.Color.White;
            this.label_Title_AddProcedure.Location = new System.Drawing.Point(150, 316);
            this.label_Title_AddProcedure.Name = "label_Title_AddProcedure";
            this.label_Title_AddProcedure.Size = new System.Drawing.Size(82, 24);
            this.label_Title_AddProcedure.TabIndex = 32;
            this.label_Title_AddProcedure.Text = "label1";
            // 
            // FindDr___Practices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(82)))), ((int)(((byte)(117)))));
            this.ClientSize = new System.Drawing.Size(1164, 698);
            this.Controls.Add(this.label_Title_AddProcedure);
            this.Controls.Add(this.label_Price);
            this.Controls.Add(this.label_Description);
            this.Controls.Add(this.label_Name);
            this.Controls.Add(this.textBox_price);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.button_deleteProcedure);
            this.Controls.Add(this.button_addProcedure);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FindDr___Practices";
            this.Text = "FindDr___Practices";
            this.Load += new System.EventHandler(this.FindDr___Practices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_deleteProcedure;
        private System.Windows.Forms.Button button_addProcedure;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.TextBox textBox_price;
        private System.Windows.Forms.Label label_Name;
        private System.Windows.Forms.Label label_Description;
        private System.Windows.Forms.Label label_Price;
        private System.Windows.Forms.Label label_Title_AddProcedure;
    }
}