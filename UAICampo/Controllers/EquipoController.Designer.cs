
namespace UAICampo.UI.Controllers
{
    partial class EquipoController
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
            this.labelTeam = new System.Windows.Forms.Label();
            this.textBoxTeamName = new System.Windows.Forms.TextBox();
            this.labelTeamName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnPropose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxMembers = new System.Windows.Forms.GroupBox();
            this.groupBoxPosition = new System.Windows.Forms.GroupBox();
            this.buttonAddPosition = new System.Windows.Forms.Button();
            this.comboBoxPosition = new System.Windows.Forms.ComboBox();
            this.textBoxLevel = new System.Windows.Forms.TextBox();
            this.labelLevel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxMembers.SuspendLayout();
            this.groupBoxPosition.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTeam
            // 
            this.labelTeam.AutoSize = true;
            this.labelTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 23F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTeam.Location = new System.Drawing.Point(23, 26);
            this.labelTeam.Name = "labelTeam";
            this.labelTeam.Size = new System.Drawing.Size(191, 35);
            this.labelTeam.TabIndex = 0;
            this.labelTeam.Text = "Team details";
            // 
            // textBoxTeamName
            // 
            this.textBoxTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxTeamName.Location = new System.Drawing.Point(110, 77);
            this.textBoxTeamName.Name = "textBoxTeamName";
            this.textBoxTeamName.Size = new System.Drawing.Size(227, 30);
            this.textBoxTeamName.TabIndex = 1;
            // 
            // labelTeamName
            // 
            this.labelTeamName.AutoSize = true;
            this.labelTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTeamName.Location = new System.Drawing.Point(35, 87);
            this.labelTeamName.Name = "labelTeamName";
            this.labelTeamName.Size = new System.Drawing.Size(45, 17);
            this.labelTeamName.TabIndex = 2;
            this.labelTeamName.Text = "Name";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Position,
            this.User});
            this.dataGridView1.Location = new System.Drawing.Point(128, 149);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(246, 274);
            this.dataGridView1.TabIndex = 3;
            // 
            // Position
            // 
            this.Position.FillWeight = 130.7692F;
            this.Position.HeaderText = "Position";
            this.Position.MinimumWidth = 10;
            this.Position.Name = "Position";
            // 
            // User
            // 
            this.User.FillWeight = 130.7692F;
            this.User.HeaderText = "User";
            this.User.MinimumWidth = 10;
            this.User.Name = "User";
            // 
            // btnPropose
            // 
            this.btnPropose.Location = new System.Drawing.Point(25, 158);
            this.btnPropose.Name = "btnPropose";
            this.btnPropose.Size = new System.Drawing.Size(75, 43);
            this.btnPropose.TabIndex = 4;
            this.btnPropose.Text = "Propose";
            this.btnPropose.UseVisualStyleBackColor = true;
            this.btnPropose.Click += new System.EventHandler(this.btnPropose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(23, 22);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(23, 51);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnProfile
            // 
            this.btnProfile.Location = new System.Drawing.Point(23, 80);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(75, 23);
            this.btnProfile.TabIndex = 1;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = true;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(218, 438);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 33);
            this.buttonAccept.TabIndex = 6;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(299, 438);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 33);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // groupBoxMembers
            // 
            this.groupBoxMembers.Controls.Add(this.btnProfile);
            this.groupBoxMembers.Controls.Add(this.btnRemove);
            this.groupBoxMembers.Controls.Add(this.btnAdd);
            this.groupBoxMembers.Location = new System.Drawing.Point(3, 219);
            this.groupBoxMembers.Name = "groupBoxMembers";
            this.groupBoxMembers.Size = new System.Drawing.Size(116, 119);
            this.groupBoxMembers.TabIndex = 7;
            this.groupBoxMembers.TabStop = false;
            this.groupBoxMembers.Text = "Members";
            // 
            // groupBoxPosition
            // 
            this.groupBoxPosition.Controls.Add(this.buttonAddPosition);
            this.groupBoxPosition.Controls.Add(this.comboBoxPosition);
            this.groupBoxPosition.Location = new System.Drawing.Point(3, 345);
            this.groupBoxPosition.Name = "groupBoxPosition";
            this.groupBoxPosition.Size = new System.Drawing.Size(116, 78);
            this.groupBoxPosition.TabIndex = 8;
            this.groupBoxPosition.TabStop = false;
            this.groupBoxPosition.Text = "Position";
            // 
            // buttonAddPosition
            // 
            this.buttonAddPosition.Location = new System.Drawing.Point(22, 46);
            this.buttonAddPosition.Name = "buttonAddPosition";
            this.buttonAddPosition.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPosition.TabIndex = 1;
            this.buttonAddPosition.Text = "Add";
            this.buttonAddPosition.UseVisualStyleBackColor = true;
            this.buttonAddPosition.Click += new System.EventHandler(this.buttonAddPosition_Click);
            // 
            // comboBoxPosition
            // 
            this.comboBoxPosition.FormattingEnabled = true;
            this.comboBoxPosition.Location = new System.Drawing.Point(6, 19);
            this.comboBoxPosition.Name = "comboBoxPosition";
            this.comboBoxPosition.Size = new System.Drawing.Size(104, 21);
            this.comboBoxPosition.TabIndex = 0;
            // 
            // textBoxLevel
            // 
            this.textBoxLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBoxLevel.Location = new System.Drawing.Point(110, 113);
            this.textBoxLevel.Name = "textBoxLevel";
            this.textBoxLevel.Size = new System.Drawing.Size(43, 30);
            this.textBoxLevel.TabIndex = 1;
            // 
            // labelLevel
            // 
            this.labelLevel.AutoSize = true;
            this.labelLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelLevel.Location = new System.Drawing.Point(35, 123);
            this.labelLevel.Name = "labelLevel";
            this.labelLevel.Size = new System.Drawing.Size(42, 17);
            this.labelLevel.TabIndex = 2;
            this.labelLevel.Text = "Level";
            // 
            // EquipoController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxPosition);
            this.Controls.Add(this.groupBoxMembers);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.btnPropose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.labelLevel);
            this.Controls.Add(this.labelTeamName);
            this.Controls.Add(this.textBoxLevel);
            this.Controls.Add(this.textBoxTeamName);
            this.Controls.Add(this.labelTeam);
            this.Name = "EquipoController";
            this.Size = new System.Drawing.Size(386, 479);
            this.Load += new System.EventHandler(this.EquipoController_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxMembers.ResumeLayout(false);
            this.groupBoxPosition.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTeam;
        private System.Windows.Forms.TextBox textBoxTeamName;
        private System.Windows.Forms.Label labelTeamName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPropose;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.GroupBox groupBoxMembers;
        private System.Windows.Forms.GroupBox groupBoxPosition;
        private System.Windows.Forms.Button buttonAddPosition;
        private System.Windows.Forms.ComboBox comboBoxPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.TextBox textBoxLevel;
        private System.Windows.Forms.Label labelLevel;
    }
}
