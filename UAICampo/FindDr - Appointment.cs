using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;

namespace UAICampo.UI
{
    public partial class FindDr___Appointment : Form
    {
        List<Appointment> appointments = new List<Appointment>();
        Appointment selectedAppointment = null;

        BLL_UserManager userManagerBll;

        public FindDr___Appointment()
        {
            InitializeComponent();

            userManagerBll = new BLL_UserManager();
        }

        private void FindDr___Appointment_Load(object sender, EventArgs e)
        {
            getMyAppointments();
            loadDataGridView();
        }

        private void getMyAppointments()
        {
            appointments = userManagerBll.getAppointments(UserInstance.getInstance().user);
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = appointments;
            dataGridView1.Columns["Client"].Visible = false;
            dataGridView1.Columns["Practitioner"].Visible = false;
            dataGridView1.Columns["Office"].Visible = false;
            dataGridView1.Columns["Procedure"].Visible = false;

            
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    selectedAppointment = dataGridView1.SelectedRows[0].DataBoundItem as Appointment;

                    User client = selectedAppointment.Client as User;

                    labelClientName.Text = client.Name;
                    labelClientLastname.Text = client.LastName;
                    labelClientEmail.Text = client.Email;

                    labelOfficeAddres1.Text = selectedAppointment.Office.Address1;
                    labelOfficeAddress2.Text = selectedAppointment.Office.Address2;
                    labelOfficeProvince.Text = selectedAppointment.Office.Province.name;

                    labelPracticeName.Text = selectedAppointment.Procedure.Name;
                    labelPracticeDesc.Text = selectedAppointment.Procedure.Desc;

                }
                catch (Exception)
                { }
            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            if (selectedAppointment != null)
            {
                if (userManagerBll.confirmTurn(selectedAppointment))
                {
                    getMyAppointments();
                    loadDataGridView();
                }
            }
        }
    }
}
