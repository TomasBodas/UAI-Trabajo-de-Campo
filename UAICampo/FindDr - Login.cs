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
    public partial class FindDr___Login : Form
    {
        BLL_SessionManager sessionBLL;
        frmMain parent;
        public FindDr___Login()
        {
            InitializeComponent();
            sessionBLL = new BLL_SessionManager();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                parent = new frmMain();
                parent.Show();
                this.Close();
            }
        }

        private void FindDr___Login_Load(object sender, EventArgs e)
        {

        }
    }
}
