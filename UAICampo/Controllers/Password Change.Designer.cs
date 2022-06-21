
namespace UAICampo.UI.Controllers
{
    partial class Password_Change
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
            this.textBox_password = new System.Windows.Forms.TextBox();
            this.textBox_passwordConfirm = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.label_PasswordConfirm = new System.Windows.Forms.Label();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.button_showPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_password
            // 
            this.textBox_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_password.Location = new System.Drawing.Point(22, 37);
            this.textBox_password.Name = "textBox_password";
            this.textBox_password.Size = new System.Drawing.Size(203, 31);
            this.textBox_password.TabIndex = 0;
            this.textBox_password.UseSystemPasswordChar = true;
            this.textBox_password.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox_passwordConfirm
            // 
            this.textBox_passwordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_passwordConfirm.Location = new System.Drawing.Point(22, 92);
            this.textBox_passwordConfirm.Name = "textBox_passwordConfirm";
            this.textBox_passwordConfirm.Size = new System.Drawing.Size(203, 31);
            this.textBox_passwordConfirm.TabIndex = 1;
            this.textBox_passwordConfirm.UseSystemPasswordChar = true;
            this.textBox_passwordConfirm.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(22, 21);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(35, 13);
            this.label_Password.TabIndex = 2;
            this.label_Password.Text = "label1";
            // 
            // label_PasswordConfirm
            // 
            this.label_PasswordConfirm.AutoSize = true;
            this.label_PasswordConfirm.Location = new System.Drawing.Point(22, 76);
            this.label_PasswordConfirm.Name = "label_PasswordConfirm";
            this.label_PasswordConfirm.Size = new System.Drawing.Size(35, 13);
            this.label_PasswordConfirm.TabIndex = 3;
            this.label_PasswordConfirm.Text = "label2";
            // 
            // button_Confirm
            // 
            this.button_Confirm.Location = new System.Drawing.Point(36, 139);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(75, 23);
            this.button_Confirm.TabIndex = 4;
            this.button_Confirm.Text = "button1";
            this.button_Confirm.UseVisualStyleBackColor = true;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // button_showPassword
            // 
            this.button_showPassword.Location = new System.Drawing.Point(127, 139);
            this.button_showPassword.Name = "button_showPassword";
            this.button_showPassword.Size = new System.Drawing.Size(98, 23);
            this.button_showPassword.TabIndex = 5;
            this.button_showPassword.Text = "button1";
            this.button_showPassword.UseVisualStyleBackColor = true;
            this.button_showPassword.Click += new System.EventHandler(this.button_showPassword_Click);
            // 
            // Password_Change
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_showPassword);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.label_PasswordConfirm);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_passwordConfirm);
            this.Controls.Add(this.textBox_password);
            this.Name = "Password_Change";
            this.Size = new System.Drawing.Size(253, 184);
            this.Load += new System.EventHandler(this.Password_Change_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_password;
        private System.Windows.Forms.TextBox textBox_passwordConfirm;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.Label label_PasswordConfirm;
        private System.Windows.Forms.Button button_Confirm;
        private System.Windows.Forms.Button button_showPassword;
    }
}
