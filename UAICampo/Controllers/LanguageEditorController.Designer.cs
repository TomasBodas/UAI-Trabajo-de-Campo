
namespace UAICampo.UI.Controllers
{
    partial class LanguageEditorController
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
            this.label_chooseLanguage = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button_loadWords = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button_addLanguage = new System.Windows.Forms.Button();
            this.button_deleteLanguage = new System.Windows.Forms.Button();
            this.label_addLanguage = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_chooseLanguage
            // 
            this.label_chooseLanguage.AutoSize = true;
            this.label_chooseLanguage.Location = new System.Drawing.Point(25, 27);
            this.label_chooseLanguage.Name = "label_chooseLanguage";
            this.label_chooseLanguage.Size = new System.Drawing.Size(102, 13);
            this.label_chooseLanguage.TabIndex = 0;
            this.label_chooseLanguage.Text = "Choose a language:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(133, 24);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // button_loadWords
            // 
            this.button_loadWords.Location = new System.Drawing.Point(301, 24);
            this.button_loadWords.Name = "button_loadWords";
            this.button_loadWords.Size = new System.Drawing.Size(74, 23);
            this.button_loadWords.TabIndex = 2;
            this.button_loadWords.Text = "Load words";
            this.button_loadWords.UseVisualStyleBackColor = true;
            this.button_loadWords.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(28, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(335, 357);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowLeave);
            // 
            // button_addLanguage
            // 
            this.button_addLanguage.Location = new System.Drawing.Point(172, 447);
            this.button_addLanguage.Name = "button_addLanguage";
            this.button_addLanguage.Size = new System.Drawing.Size(25, 23);
            this.button_addLanguage.TabIndex = 4;
            this.button_addLanguage.Text = "+";
            this.button_addLanguage.UseVisualStyleBackColor = true;
            this.button_addLanguage.Click += new System.EventHandler(this.button2_Click);
            // 
            // button_deleteLanguage
            // 
            this.button_deleteLanguage.Location = new System.Drawing.Point(260, 24);
            this.button_deleteLanguage.Name = "button_deleteLanguage";
            this.button_deleteLanguage.Size = new System.Drawing.Size(25, 23);
            this.button_deleteLanguage.TabIndex = 5;
            this.button_deleteLanguage.Text = "-";
            this.button_deleteLanguage.UseVisualStyleBackColor = true;
            this.button_deleteLanguage.Click += new System.EventHandler(this.button3_Click);
            // 
            // label_addLanguage
            // 
            this.label_addLanguage.AutoSize = true;
            this.label_addLanguage.Location = new System.Drawing.Point(64, 429);
            this.label_addLanguage.Name = "label_addLanguage";
            this.label_addLanguage.Size = new System.Drawing.Size(99, 13);
            this.label_addLanguage.TabIndex = 7;
            this.label_addLanguage.Text = "Add new language:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 449);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 8;
            // 
            // LanguageEditorController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label_addLanguage);
            this.Controls.Add(this.button_deleteLanguage);
            this.Controls.Add(this.button_addLanguage);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_loadWords);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label_chooseLanguage);
            this.Name = "LanguageEditorController";
            this.Size = new System.Drawing.Size(394, 485);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_chooseLanguage;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button_loadWords;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button_addLanguage;
        private System.Windows.Forms.Button button_deleteLanguage;
        private System.Windows.Forms.Label label_addLanguage;
        private System.Windows.Forms.TextBox textBox1;
    }
}
