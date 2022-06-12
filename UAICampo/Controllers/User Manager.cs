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

namespace UAICampo.UI.Controllers
{
    public partial class User_Manager : UserControl
    {
        BLL_UserManager bll_userManager;

        public User_Manager()
        {
            InitializeComponent();
            bll_userManager = new BLL_UserManager(); 
        }

        private void User_Manager_Load(object sender, EventArgs e)
        {
            updateUserList();
        }
        private void updateUserList()
        {
            dataGridView_user.DataSource = null;
            dataGridView_user.DataSource = bll_userManager.GetUsers();

            dataGridView_user.Columns["Licenses"].Visible = false;
            dataGridView_user.Columns["Password"].Visible = false;
            dataGridView_user.Columns["language"].Visible = false;
        }
    }
}
