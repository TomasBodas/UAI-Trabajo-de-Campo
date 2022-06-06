using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions.Observer;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class frmMain : Form, IObserver
    {
        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;
        public frmMain()
        {
            InitializeComponent();
            ValidateForm();
            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();
            languageBLL.loadDefaultLanguage();

            this.translateTexts();
        }

        private void translateTexts()
        {
            this.button1.Text = Language.getInstance().translate("Login");
        }
        private void itemLogin_Click(object sender, EventArgs e)
        {
            if (!isWindowOpen("frmLogin"))
                new frmLogin(this).Show();
        }
        public void ValidateForm()
        {
            this.itemLogin.Enabled = !UserInstance.getInstance().userIsLoggedIn();
            this.itemLogout.Enabled = UserInstance.getInstance().userIsLoggedIn();
            if (UserInstance.getInstance().userIsLoggedIn())
            {
                this.toolStripStatusLabel.Text = UserInstance.getInstance().user.Username;
                this.label1.Text = UserInstance.getInstance().user.Id.ToString();
                this.label2.Text = UserInstance.getInstance().user.Username.ToString();
                this.label3.Text = UserInstance.getInstance().user.Email.ToString();
                this.label4.Text = UserInstance.getInstance().user.IsBlocked.ToString();
                this.label5.Text = UserInstance.getInstance().user.Attempts.ToString();
                button3.Enabled = true;

            }
            else
            {
                this.label1.Text = "Id";
                this.label2.Text = "Username";
                this.label3.Text = "Email";
                this.label4.Text = "IsBlocked";
                this.label5.Text = "Attempts";
                this.toolStripStatusLabel.Text = "Guest";
            }
        }
        private void itemLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                ValidateForm();
            }
        }
        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isWindowOpen("FrmRegister"))
                new FrmRegister(this).Show();
        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isWindowOpen("frmLogin"))
                new frmLogin(this).Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (UserInstance.getInstance().userIsLoggedIn())
            {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                ValidateForm();
            }
            }
            else
            {
                button3.Enabled = false;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!isWindowOpen("FrmRegister"))
                new FrmRegister(this).Show();
        }

        private bool isWindowOpen(string name)
        {
            foreach (Form frm in Application.OpenForms)
            {
                if (frm != null && frm.Name == name)
                    return true;
            }

            return false;
        }

        public void Update(ILanguage l)
        {
            throw new NotImplementedException();
        }
    }
}
