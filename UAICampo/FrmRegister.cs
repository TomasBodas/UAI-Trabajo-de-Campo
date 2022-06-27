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
        public FrmRegister()
        {
            InitializeComponent();

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

            if (!string.IsNullOrEmpty(textBoxPassword.Text) || !string.IsNullOrEmpty(textBoxConfirmPassword.Text))
            {
                if (textBoxPassword.Text == textBoxConfirmPassword.Text)
                {
                    if (bllUserManager.createUser(USERNAME, PASSWORD, EMAIL) != null)
                    {

                        this.Close();
                    }
                    else
                    {
                        Interaction.MsgBox("This Username already exists. Please try a different one.");
                    }
                }
                else
                {
                    Interaction.MsgBox("Password doesn't match. Please try again.");
                }
            }
            else
            {
                Interaction.MsgBox("Please enter a password.");
            }
        }
    }
}
