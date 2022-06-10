
namespace UAICampo.UI.Controllers
{
    partial class License_Manager
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
            this.treeView_License = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treeView_License
            // 
            this.treeView_License.Location = new System.Drawing.Point(20, 42);
            this.treeView_License.Name = "treeView_License";
            this.treeView_License.Size = new System.Drawing.Size(474, 381);
            this.treeView_License.TabIndex = 0;
            // 
            // License_Manager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeView_License);
            this.Name = "License_Manager";
            this.Size = new System.Drawing.Size(559, 476);
            this.Load += new System.EventHandler(this.License_Manager_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView_License;
    }
}
