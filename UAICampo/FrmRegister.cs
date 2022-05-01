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
using UAICampo.Services;
using UAICampo.Abstractions;
using Microsoft.VisualBasic;

namespace UAICampo.UI
{
    public partial class FrmRegister : Form
    {
        private static BLL_UserManager bllUserManager;
        private static UI_Validation validations;


        private string USERNAME = "";
        private string PASSWORD = "";
        private string EMAIL = "";
        frmMain parent;
        public FrmRegister(frmMain parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {
            bllUserManager = new BLL_UserManager();
            validations = new UI_Validation();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            USERNAME = textBoxUsername.Text;
            PASSWORD = textBoxPassword.Text;
            EMAIL = textBoxEmail.Text;

            if (bllUserManager.createUser(USERNAME, PASSWORD, EMAIL) != null)
            {

                this.Dispose();
            }
            else
            {
                Interaction.MsgBox("This Username already exists. Please try a different one.");
            }
        }
    }
}
