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
using UAICampo.Abstractions;

namespace UAICampo.UI
{
    public partial class frmLogin : Form, IObserver
    {
        FrmRegister frmregister = null;

        BLL_SessionManager sessionBLL;
        ControlCollection ctrl;
        public frmLogin()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.w;
            sessionBLL = new BLL_SessionManager();
            ctrl = new ControlCollection(this);
            //ctrl.Add(btnLogin);

            if(UserInstance.getInstance().user!=null)
            {
                UserInstance.getInstance().user.Add(this);
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
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    frmMain main = new frmMain();
                    main.Show();
                    this.Hide();
                }  
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (frmregister == null)
            {
                frmregister = new FrmRegister();
                frmregister.FormClosed += new FormClosedEventHandler(frmLogin_FormClosed);
                frmregister.Show();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLogin_FormClosed(object sender, EventArgs e)
        {
            frmregister = null;
        }
    }
}
