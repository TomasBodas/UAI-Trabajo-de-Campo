
namespace UAICampo.UI.Controllers
{
    partial class TareasController
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
            this.labelTareas = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonDetails = new System.Windows.Forms.Button();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonDeassign = new System.Windows.Forms.Button();
            this.buttonFinalize = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.labelEquipoTareas = new System.Windows.Forms.Label();
            this.buttonAddTask = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonArchive = new System.Windows.Forms.Button();
            this.buttonDetails2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelTareas
            // 
            this.labelTareas.AutoSize = true;
            this.labelTareas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelTareas.Location = new System.Drawing.Point(27, 10);
            this.labelTareas.Name = "labelTareas";
            this.labelTareas.Size = new System.Drawing.Size(90, 25);
            this.labelTareas.TabIndex = 1;
            this.labelTareas.Text = "My tasks";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(31, 45);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(325, 238);
            this.listBox1.TabIndex = 2;
            // 
            // buttonDetails
            // 
            this.buttonDetails.Location = new System.Drawing.Point(785, 289);
            this.buttonDetails.Name = "buttonDetails";
            this.buttonDetails.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails.TabIndex = 3;
            this.buttonDetails.Text = "Details";
            this.buttonDetails.UseVisualStyleBackColor = true;
            this.buttonDetails.Click += new System.EventHandler(this.buttonDetails_Click);
            // 
            // buttonAssign
            // 
            this.buttonAssign.Location = new System.Drawing.Point(378, 120);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(29, 23);
            this.buttonAssign.TabIndex = 4;
            this.buttonAssign.Text = "<";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Visible = false;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonDeassign
            // 
            this.buttonDeassign.Location = new System.Drawing.Point(479, 120);
            this.buttonDeassign.Name = "buttonDeassign";
            this.buttonDeassign.Size = new System.Drawing.Size(29, 23);
            this.buttonDeassign.TabIndex = 4;
            this.buttonDeassign.Text = ">";
            this.buttonDeassign.UseVisualStyleBackColor = true;
            this.buttonDeassign.Visible = false;
            // 
            // buttonFinalize
            // 
            this.buttonFinalize.Location = new System.Drawing.Point(281, 289);
            this.buttonFinalize.Name = "buttonFinalize";
            this.buttonFinalize.Size = new System.Drawing.Size(75, 23);
            this.buttonFinalize.TabIndex = 4;
            this.buttonFinalize.Text = "Finalize";
            this.buttonFinalize.UseVisualStyleBackColor = true;
            this.buttonFinalize.Click += new System.EventHandler(this.buttonFinalize_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(535, 45);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(325, 238);
            this.listBox2.TabIndex = 2;
            // 
            // labelEquipoTareas
            // 
            this.labelEquipoTareas.AutoSize = true;
            this.labelEquipoTareas.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelEquipoTareas.Location = new System.Drawing.Point(530, 10);
            this.labelEquipoTareas.Name = "labelEquipoTareas";
            this.labelEquipoTareas.Size = new System.Drawing.Size(128, 25);
            this.labelEquipoTareas.TabIndex = 1;
            this.labelEquipoTareas.Text = "Team\'s tasks";
            // 
            // buttonAddTask
            // 
            this.buttonAddTask.Location = new System.Drawing.Point(404, 175);
            this.buttonAddTask.Name = "buttonAddTask";
            this.buttonAddTask.Size = new System.Drawing.Size(75, 23);
            this.buttonAddTask.TabIndex = 3;
            this.buttonAddTask.Text = "Add Task";
            this.buttonAddTask.UseVisualStyleBackColor = true;
            this.buttonAddTask.Click += new System.EventHandler(this.buttonAddTask_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(404, 59);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 3;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonArchive
            // 
            this.buttonArchive.Location = new System.Drawing.Point(404, 262);
            this.buttonArchive.Name = "buttonArchive";
            this.buttonArchive.Size = new System.Drawing.Size(75, 23);
            this.buttonArchive.TabIndex = 4;
            this.buttonArchive.Text = "Archive";
            this.buttonArchive.UseVisualStyleBackColor = true;
            this.buttonArchive.Visible = false;
            // 
            // buttonDetails2
            // 
            this.buttonDetails2.Location = new System.Drawing.Point(32, 289);
            this.buttonDetails2.Name = "buttonDetails2";
            this.buttonDetails2.Size = new System.Drawing.Size(75, 23);
            this.buttonDetails2.TabIndex = 5;
            this.buttonDetails2.Text = "Details";
            this.buttonDetails2.UseVisualStyleBackColor = true;
            this.buttonDetails2.Click += new System.EventHandler(this.buttonDetails2_Click);
            // 
            // TareasController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDetails2);
            this.Controls.Add(this.buttonArchive);
            this.Controls.Add(this.buttonFinalize);
            this.Controls.Add(this.buttonDeassign);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonAddTask);
            this.Controls.Add(this.buttonDetails);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.labelEquipoTareas);
            this.Controls.Add(this.labelTareas);
            this.Name = "TareasController";
            this.Size = new System.Drawing.Size(896, 326);
            this.Load += new System.EventHandler(this.TareasController_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTareas;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonDetails;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonDeassign;
        private System.Windows.Forms.Button buttonFinalize;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label labelEquipoTareas;
        private System.Windows.Forms.Button buttonAddTask;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonArchive;
        private System.Windows.Forms.Button buttonDetails2;
    }
}
