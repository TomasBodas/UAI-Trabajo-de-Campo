﻿using System;
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

namespace UAICampo.UI
{
    public partial class frmMain : Form
    {
        BLL_SessionManager sessionBLL;
        public frmMain()
        {
            InitializeComponent();
            ValidateForm();
            sessionBLL = new BLL_SessionManager();
        }

        private void itemLogin_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            frm.MdiParent = this;
            frm.Show();
        }

        public void ValidateForm()
        {
            this.itemLogin.Enabled = !UserInstance.getInstance().userIsLoggedIn();
            this.itemLogout.Enabled = UserInstance.getInstance().userIsLoggedIn();
        }

        private void itemLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                sessionBLL.Logout();
                ValidateForm();
            }
        }
    }
}
