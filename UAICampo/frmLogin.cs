using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.BLL;

namespace UAICampo.UI
{
    public partial class frmLogin : Form
    {
        BLL_SessionManager sessionBLL;
        public frmLogin()
        {
            InitializeComponent();
            sessionBLL = new BLL_SessionManager();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            errorProvider2.Clear();
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                txtUser.Focus();
                errorProvider1.SetError(txtUser, "Please enter a username");
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Focus();
                errorProvider2.SetError(txtPassword, "Please enter a password");
            }
            if (!string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                sessionBLL.Login(txtUser.Text, txtPassword.Text);
                frmMain frm = (frmMain)this.MdiParent;
                frm.ValidateForm();

                this.Close();
            }


        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
