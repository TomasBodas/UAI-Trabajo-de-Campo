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
using UAICampo.Abstractions.Observer;
using UAICampo.Services;

namespace UAICampo.UI
{
    public partial class frmLogin : Form, IObserver
    {

        public event EventHandler userLogin;

        BLL_SessionManager sessionBLL;
        frmMain parent;
        ControlCollection ctrl;
        public frmLogin(frmMain parent)
        {
            InitializeComponent();
            sessionBLL = new BLL_SessionManager();
            this.parent = parent;
            ctrl = new ControlCollection(this);
            ctrl.Add(btnLogin);

            if(UserInstance.getInstance().user!=null)
            {
                UserInstance.getInstance().user.Add(this);
            }
        }

        public void Update(ILanguage l)
        {
            foreach (var item in ctrl)
            {
            }
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
                //this.parent.ValidateForm();
                frmMain main = new frmMain();
                main.Show();
                this.Close();
            }


        }

        private void Parent_userLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void FrmLogin_userLogin(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
