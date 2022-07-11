
namespace UAICampo.UI
{
    partial class frmTareaDetalle
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
            this.comboBoxAssigned = new System.Windows.Forms.ComboBox();
            this.comboBoxEpic = new System.Windows.Forms.ComboBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.dateTimePickerDeadline = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFinshed = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerCreated = new System.Windows.Forms.DateTimePicker();
            this.labelTaskDetail = new System.Windows.Forms.Label();
            this.labelDateDeadline = new System.Windows.Forms.Label();
            this.labelDateFinished = new System.Windows.Forms.Label();
            this.labelDateCreated = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.labelAssigned = new System.Windows.Forms.Label();
            this.labelEpic = new System.Windows.Forms.Label();
            this.labelValue = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxAssigned
            // 
            this.comboBoxAssigned.FormattingEnabled = true;
            this.comboBoxAssigned.Location = new System.Drawing.Point(175, 255);
            this.comboBoxAssigned.Name = "comboBoxAssigned";
            this.comboBoxAssigned.Size = new System.Drawing.Size(288, 21);
            this.comboBoxAssigned.TabIndex = 47;
            // 
            // comboBoxEpic
            // 
            this.comboBoxEpic.FormattingEnabled = true;
            this.comboBoxEpic.Location = new System.Drawing.Point(175, 228);
            this.comboBoxEpic.Name = "comboBoxEpic";
            this.comboBoxEpic.Size = new System.Drawing.Size(288, 21);
            this.comboBoxEpic.TabIndex = 46;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(388, 411);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 45;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(300, 411);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 44;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // dateTimePickerDeadline
            // 
            this.dateTimePickerDeadline.Location = new System.Drawing.Point(175, 374);
            this.dateTimePickerDeadline.Name = "dateTimePickerDeadline";
            this.dateTimePickerDeadline.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDeadline.TabIndex = 43;
            // 
            // dateTimePickerFinshed
            // 
            this.dateTimePickerFinshed.Location = new System.Drawing.Point(175, 345);
            this.dateTimePickerFinshed.Name = "dateTimePickerFinshed";
            this.dateTimePickerFinshed.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFinshed.TabIndex = 42;
            // 
            // dateTimePickerCreated
            // 
            this.dateTimePickerCreated.Location = new System.Drawing.Point(175, 316);
            this.dateTimePickerCreated.Name = "dateTimePickerCreated";
            this.dateTimePickerCreated.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerCreated.TabIndex = 41;
            // 
            // labelTaskDetail
            // 
            this.labelTaskDetail.AutoSize = true;
            this.labelTaskDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTaskDetail.Location = new System.Drawing.Point(12, 9);
            this.labelTaskDetail.Name = "labelTaskDetail";
            this.labelTaskDetail.Size = new System.Drawing.Size(181, 35);
            this.labelTaskDetail.TabIndex = 40;
            this.labelTaskDetail.Text = "Task details";
            // 
            // labelDateDeadline
            // 
            this.labelDateDeadline.AutoSize = true;
            this.labelDateDeadline.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDateDeadline.Location = new System.Drawing.Point(88, 378);
            this.labelDateDeadline.Name = "labelDateDeadline";
            this.labelDateDeadline.Size = new System.Drawing.Size(64, 17);
            this.labelDateDeadline.TabIndex = 39;
            this.labelDateDeadline.Text = "Deadline";
            // 
            // labelDateFinished
            // 
            this.labelDateFinished.AutoSize = true;
            this.labelDateFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDateFinished.Location = new System.Drawing.Point(57, 349);
            this.labelDateFinished.Name = "labelDateFinished";
            this.labelDateFinished.Size = new System.Drawing.Size(95, 17);
            this.labelDateFinished.TabIndex = 38;
            this.labelDateFinished.Text = "Date Finished";
            // 
            // labelDateCreated
            // 
            this.labelDateCreated.AutoSize = true;
            this.labelDateCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDateCreated.Location = new System.Drawing.Point(60, 319);
            this.labelDateCreated.Name = "labelDateCreated";
            this.labelDateCreated.Size = new System.Drawing.Size(92, 17);
            this.labelDateCreated.TabIndex = 37;
            this.labelDateCreated.Text = "Date Created";
            // 
            // txtValue
            // 
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtValue.Location = new System.Drawing.Point(175, 282);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(40, 23);
            this.txtValue.TabIndex = 36;
            // 
            // labelAssigned
            // 
            this.labelAssigned.AutoSize = true;
            this.labelAssigned.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelAssigned.Location = new System.Drawing.Point(70, 256);
            this.labelAssigned.Name = "labelAssigned";
            this.labelAssigned.Size = new System.Drawing.Size(82, 17);
            this.labelAssigned.TabIndex = 35;
            this.labelAssigned.Text = "Assigned to";
            // 
            // labelEpic
            // 
            this.labelEpic.AutoSize = true;
            this.labelEpic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEpic.Location = new System.Drawing.Point(117, 229);
            this.labelEpic.Name = "labelEpic";
            this.labelEpic.Size = new System.Drawing.Size(35, 17);
            this.labelEpic.TabIndex = 34;
            this.labelEpic.Text = "Epic";
            // 
            // labelValue
            // 
            this.labelValue.AutoSize = true;
            this.labelValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelValue.Location = new System.Drawing.Point(108, 285);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(44, 17);
            this.labelValue.TabIndex = 33;
            this.labelValue.Text = "Value";
            // 
            // txtTitle
            // 
            this.txtTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtTitle.Location = new System.Drawing.Point(175, 76);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(288, 23);
            this.txtTitle.TabIndex = 32;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTitle.Location = new System.Drawing.Point(117, 79);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(35, 17);
            this.labelTitle.TabIndex = 31;
            this.labelTitle.Text = "Title";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtDescription.Location = new System.Drawing.Point(175, 114);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(288, 108);
            this.txtDescription.TabIndex = 30;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelDescription.Location = new System.Drawing.Point(73, 114);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(79, 17);
            this.labelDescription.TabIndex = 29;
            this.labelDescription.Text = "Description";
            // 
            // frmTareaDetalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 450);
            this.Controls.Add(this.comboBoxAssigned);
            this.Controls.Add(this.comboBoxEpic);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.dateTimePickerDeadline);
            this.Controls.Add(this.dateTimePickerFinshed);
            this.Controls.Add(this.dateTimePickerCreated);
            this.Controls.Add(this.labelTaskDetail);
            this.Controls.Add(this.labelDateDeadline);
            this.Controls.Add(this.labelDateFinished);
            this.Controls.Add(this.labelDateCreated);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.labelAssigned);
            this.Controls.Add(this.labelEpic);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.labelDescription);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmTareaDetalle";
            this.Text = "frmTareaDetalle";
            this.Load += new System.EventHandler(this.frmTareaDetalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxAssigned;
        private System.Windows.Forms.ComboBox comboBoxEpic;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.DateTimePicker dateTimePickerDeadline;
        private System.Windows.Forms.DateTimePicker dateTimePickerFinshed;
        private System.Windows.Forms.DateTimePicker dateTimePickerCreated;
        private System.Windows.Forms.Label labelTaskDetail;
        private System.Windows.Forms.Label labelDateDeadline;
        private System.Windows.Forms.Label labelDateFinished;
        private System.Windows.Forms.Label labelDateCreated;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label labelAssigned;
        private System.Windows.Forms.Label labelEpic;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labelDescription;
    }
}