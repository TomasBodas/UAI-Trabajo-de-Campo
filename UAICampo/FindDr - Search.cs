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
    public partial class FindDr___Search : Form, IObserver
    {
        BLL_Address addressBll;
        BLL_UserManager userManagerBll;
        BLL_LanguageManager languageBLL;

        Address userAddress = new Address();
        Province selectedProvince = null;
        Speciality selectedSpeciality = null;
        User selectedPractitioner = null;
        Address selectedOffice = null;
        

        List<Province> provinces = new List<Province>();
        List<Speciality> Specialities = new List<Speciality>();
        List<User> foundResults = new List<User>();
        List<Address> offices = new List<Address>();

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        private Form activeForm = null;

        public FindDr___Search()
        {
            InitializeComponent();

            addressBll = new BLL_Address();
            userManagerBll = new BLL_UserManager();
            languageBLL = new BLL_LanguageManager();
        }

        private void FindDr___Search_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(GoogleMapsBuilder.addressBuilder("", "", 0, "Buenos Aires"));

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

            panel2.Visible = false;

            getUserAddress();
            ValidateForm();

            getProvinces();
            getSpecialities();

        }
        //Button Add Address --------------------------------------------------------------------------------
        private void button_addAddress_Click(object sender, EventArgs e)
        {
            FindDr___AddAddress addAddress = new FindDr___AddAddress();
            addAddress.FormClosed += AddAddress_FormClosed;
            openChildSubForm(addAddress);
        }
        //Button search -------------------------------------------------------------------------------------
        private void button_Search_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            //select speciality from combobox
            foreach (Speciality speciality in Specialities)
            {
                if (speciality.Name == comboBox_Speciality.Text)
                {
                    selectedSpeciality = speciality;
                }
            }
            //select province from combobox
            foreach (Province province in provinces)
            {
                if (province.name == comboBox_Province.Text)
                {
                    selectedProvince = province;
                }
            }
            foundResults.Clear();
            foundResults = userManagerBll.searchPractitionerResults(selectedSpeciality, selectedProvince);
            loadDataGridViewUser();
        }
        //Button cancel -------------------------------------------------------------------------------------
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }
        //Event handler for addAddress form closing event ---------------------------------------------------
        private void AddAddress_FormClosed(object sender, FormClosedEventArgs e)
        {
            getUserAddress();
            ValidateForm();
        }
        //Select Specialist from datagridview---------------------------------------------------------------
        private void dataGridView_FoundResults_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                selectedPractitioner = dataGridView_FoundResults.SelectedRows[0].DataBoundItem as User;
                offices = addressBll.getAllOffices(selectedPractitioner);
                loadDataGridViewOffices();
            }
            catch (Exception)
            {}
        }
        //Select office from dataGridView-------------------------------------------------------------------
        private void dataGridView_Offices_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                selectedOffice = dataGridView_Offices.SelectedRows[0].DataBoundItem as Address;

                if (userAddress != null && selectedOffice != null)
                {
                    webBrowser1.Navigate(GoogleMapsBuilder.pathDistanceBuilder( userAddress.Address1,
                                                                                userAddress.Address2,
                                                                                userAddress.AddressNumber,
                                                                                userAddress.City,
                                                                                selectedOffice.Address1, 
                                                                                selectedOffice.Address2,
                                                                                selectedOffice.AddressNumber, 
                                                                                selectedOffice.City));
                }
            }
            catch (Exception)
            { }
        }
        //Form methods --------------------------------------------------------------------------------------
        //Get User Address ----------------------------------------------------------------------------------
        private void getUserAddress()
        {
            userAddress = addressBll.getUserAddress(UserInstance.getInstance().user);
        }
        //get specialities list -----------------------------------------------------------------------------
        private void getSpecialities()
        {
            comboBox_Speciality.Items.Clear();
            Specialities = userManagerBll.getAllSpecialities();
            foreach (Speciality speciality in Specialities)
            {
                comboBox_Speciality.Items.Add(speciality.Name);
            }
        }
        //Get Provinces list --------------------------------------------------------------------------------
        private void getProvinces()
        {
            comboBox_Province.DataSource = null;
            comboBox_Province.Items.Clear();
            provinces = addressBll.getProvincesList();
            foreach (Province province in provinces)
            {
                comboBox_Province.Items.Add(province.name);
            }
        }
        // Load DataGridView -------------------------------------------------------------------------------
        private void loadDataGridViewUser()
        {
            dataGridView_FoundResults.DataSource = null;
            dataGridView_FoundResults.DataSource = foundResults;

            //hide columns
            dataGridView_FoundResults.Columns["isBlocked"].Visible = false;
            dataGridView_FoundResults.Columns["Username"].Visible = false;
            dataGridView_FoundResults.Columns["Attempts"].Visible = false;
            dataGridView_FoundResults.Columns["Password"].Visible = false;
            dataGridView_FoundResults.Columns["Birthdate"].Visible = false;
            dataGridView_FoundResults.Columns["Dni"].Visible = false;
            dataGridView_FoundResults.Columns["Licenses"].Visible = false;
            dataGridView_FoundResults.Columns["language"].Visible = false;
            dataGridView_FoundResults.Columns["Id"].Visible = false;
        }
        private void loadDataGridViewOffices()
        {
            dataGridView_Offices.DataSource = null;
            dataGridView_Offices.DataSource = offices;

            dataGridView_Offices.Columns["Id"].Visible = false;
            dataGridView_Offices.Columns["City"].Visible = false;
            dataGridView_Offices.Columns["Province"].Visible = false;
        }
        private void ValidateForm()
        {
            try
            {
                if (UserInstance.getInstance().userIsLoggedIn())
                {
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
                    if (userAddress == null)
                    {
                        //if the user doesnt have an address, all controllers are hidden except for the ones to add an address
                        label_nonExistingAddress.Visible = true;
                        button_addAddress.Visible = true;
                        button_addAddress.Enabled = true;
                        panel1.Visible = false;
                        panel2.Visible = false;
                        webBrowser1.Visible = false;
                    }
                    else
                    {
                        //if user has an address, addAddress controllers are hidden
                        label_nonExistingAddress.Visible = false;
                        button_addAddress.Visible = false;
                        panel1.Visible = true;
                        webBrowser1.Visible = true;
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
            languageBLL.loadLanguageWords(selectedLanguage);

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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "NonAddress"), label_nonExistingAddress));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Speciality"), label_Speciality));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddressProvince"), label_Province));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Search"), button_Search));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), button_Cancel));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddAddress"), button_addAddress));
        }
        private void openChildSubForm(Form subForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = subForm;
            subForm.TopLevel = false;
            subForm.FormBorderStyle = FormBorderStyle.None;
            subForm.Dock = DockStyle.Fill;
            this.Controls.Add(subForm);
            this.Tag = subForm;
            subForm.BringToFront();
            subForm.Show();
        }

        
    }
}
