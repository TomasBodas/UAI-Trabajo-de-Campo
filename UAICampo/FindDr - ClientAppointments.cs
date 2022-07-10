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
using UAICampo.BE;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI
{
    public partial class FindDr___ClientAppointments : Form, IObserver
    {
        List<Appointment> appointments = new List<Appointment>();
        Appointment selectedAppointment = null;
        Address userAddress = null;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        BLL_UserManager userManagerBll;
        BLL_LanguageManager languageBll;
        BLL_Address addressBll;

        public FindDr___ClientAppointments()
        {
            InitializeComponent();
            userManagerBll = new BLL_UserManager();
            languageBll = new BLL_LanguageManager();
            addressBll = new BLL_Address();

            userAddress = addressBll.getUserAddress(UserInstance.getInstance().user);

            if (UserInstance.getInstance().userIsLoggedIn())
            {
                foreach (Profile profile in UserInstance.getInstance().user.profileList)
                {
                    licenses.AddRange(profile.getAllLicenses());
                }
            }

            SetControllerTags();
            ValidateForm();

            //subscribe form as observer to user subject
            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }

        }

        private void FindDr___ClientAppointments_Load(object sender, EventArgs e)
        {
            getMyAppointments();
            loadDataGridView();
        }
        private void getMyAppointments()
        {
            appointments = userManagerBll.getClientAppointments(UserInstance.getInstance().user);

            foreach (Appointment appointment in appointments)
            {
                User client = appointment.Client as User;
                User practitioner = appointment.Practitioner as User;
                Address office = appointment.Office as Address;
                Procedure procedure = appointment.Procedure as Procedure;

                appointment.ClientName = $"{client.LastName} {client.Name}";
                appointment.PractitionerName = $"{practitioner.LastName} {practitioner.Name}";
                appointment.OfficeDir = $"{office.Address1} - {office.Address2} - {office.AddressNumber}";
                appointment.ProcedureName = $"{procedure.Name}";

            }
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = appointments;
            dataGridView1.Columns["Client"].Visible = false;
            dataGridView1.Columns["Practitioner"].Visible = false;
            dataGridView1.Columns["Office"].Visible = false;
            dataGridView1.Columns["Procedure"].Visible = false;

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["Client"].Visible = false;
            dataGridView1.Columns["Practitioner"].Visible = false;
            dataGridView1.Columns["Office"].Visible = false;
            dataGridView1.Columns["Procedure"].Visible = false;
            dataGridView1.Columns["ClientId"].Visible = false;
            dataGridView1.Columns["PractitionerId"].Visible = false;
            dataGridView1.Columns["OfficeId"].Visible = false;
            dataGridView1.Columns["ProcedureId"].Visible = false;
            dataGridView1.Columns["ClientName"].Visible = false;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                Appointment currentRow = row.DataBoundItem as Appointment;
                if (currentRow.Confirmed == false)
                {
                    dataGridView1.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Red;
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else
                {
                    dataGridView1.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    selectedAppointment = dataGridView1.SelectedRows[0].DataBoundItem as Appointment;

                    User client = selectedAppointment.Practitioner as User;

                    labelClientName.Text = $"{client.Name} {client.LastName}";
                    labelClientEmail.Text = client.Email;

                    labelOfficeAddres1.Text = $"{selectedAppointment.Office.Address1} {selectedAppointment.Office.Address2} {selectedAppointment.Office.AddressNumber}";

                    labelPracticeName.Text = selectedAppointment.Procedure.Name;
                    labelPracticeDesc.Text = selectedAppointment.Procedure.Desc;

                    webBrowser1.Navigate(GoogleMapsBuilder.pathDistanceBuilder(userAddress.Address1,
                                                                                userAddress.Address2,
                                                                                userAddress.AddressNumber,
                                                                                userAddress.City,
                                                                                selectedAppointment.Office.Address1,
                                                                                selectedAppointment.Office.Address2,
                                                                                selectedAppointment.Office.AddressNumber,
                                                                                selectedAppointment.Office.City));
                }
                catch (Exception)
                { }
            }
        }
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
                    //set Labels text

                    //showing or hiding controllers according to user licences
                    foreach (var controller in controllers)
                    {
                        if (controller.Key.LicenseId == 0 || licenses.Any(t => t.Id == controller.Key.LicenseId))
                        {
                            controller.Value.Visible = true;
                        }
                        else
                        {
                            controller.Value.Visible = false;
                        }
                    }
                }
            }
            catch (Exception)
            { }
        }
        public void Update()
        {
            //Get user saver language
            Language selectedLanguage = UserInstance.getInstance().user.language;
            languageBll.loadLanguageWords(selectedLanguage);

            //Updating each controller accordingly
            foreach (var controller in controllers)
            {
                try
                {
                    if (controller.Key.Word != null)
                    {
                        KeyValuePair<string, string> textValue = selectedLanguage.words.SingleOrDefault(kvp => kvp.Key == controller.Key.Word);
                        if (textValue.Value != null)
                        {
                            //If the tag is in the DB and has a word for the selected language
                            controller.Value.Text = textValue.Value;
                        }
                        else
                        {
                            //If there is no translation
                            controller.Value.Text = "Not found";
                        }
                    }
                }
                catch (Exception)
                { }
            }
        }
        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            ////General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Practices"), label_Title_Practices));
        }
    }
}
