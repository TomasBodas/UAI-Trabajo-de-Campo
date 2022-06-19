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
    public partial class FindDr___AddAddress : Form, IObserver
    {
        private readonly string PRACTITIONER_PROFILE = "Practitioner";
        private Form activeForm = null;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        BLL_Address addressBll;
        BLL_UserManager userBll;
        BLL_LanguageManager languageBll;

        Address newAddress = new Address();
        List<Province> provinces;

        public FindDr___AddAddress()
        {
            InitializeComponent();

            addressBll = new BLL_Address();
            userBll = new BLL_UserManager();
            languageBll = new BLL_LanguageManager();

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
            loadProvinces();

            //subscribe form as observer to user subject
            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }   
        }
        private void FindDr___AddAddress_Load(object sender, EventArgs e)
        {

        }
        private void loadProvinces()
        {
            button_addAddress.Enabled = false;
            comboBox1.DataSource = null;
            provinces = addressBll.getProvincesList();
            foreach (Province province in provinces)
            {
                comboBox1.Items.Add(province.name);
            }
        }

        // Button Cancel -------------------------------------------------------------------
        private void button_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Button Add address ---------------------------------------------------------------
        private void button_addAddress_Click(object sender, EventArgs e)
        {
            
            string address1 = textBox_Address1.Text;
            string address2 = textBox_Address2.Text;
            int addressNumber = int.Parse(textBox_AddressNum.Text);
            Province selectedProvince = null;
            foreach (Province province in provinces)
            {
                if (province.name == comboBox1.Text)
                {
                    selectedProvince = province;
                    break;
                }
            }

            newAddress.Address1 = address1;
            newAddress.Address2 = address2;
            newAddress.AddressNumber = addressNumber;
            newAddress.Province = selectedProvince;

            addressBll.addUserAddress(newAddress, UserInstance.getInstance().user);
        }
        //Button Google Maps --------------------------------------------------------------------
        private void button_FindAddress_Click(object sender, EventArgs e)
        {
            string address1 = textBox_Address1.Text;
            string address2 = textBox_Address2.Text;
            int addressNumber = int.Parse(textBox_AddressNum.Text);
            string province = comboBox1.Text;
            webBrowser1.Navigate(GoogleMapsBuilder.addressBuilder(address1, address2, addressNumber, province));
        }

        // Method used for validating completition of required fields ---------------------------
        private bool validateFields()
        {
            bool validated = true;

            if (textBox_Address1.Text == "") { validated = false; }
            if (textBox_Address2.Text == "") { validated = false; }
            if (textBox_AddressNum.Text == "" || !int.TryParse(textBox_AddressNum.Text, out _)) { validated = false; }
            if (comboBox1.Text == "") { validated = false; }

            return validated;
        }

        //Validation controller event handlers-----------------------------------------------------------------------------
        private void textBox_Address1_TextChanged(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void textBox_Address2_TextChanged(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void textBox_AddressNum_TextChanged(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }
        //Validation controller event handlers-----------------------------------------------------------------------------
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Address1"), label_Address1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Address2"), label_Address2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddressNum"), label_AddressNum));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddressProvince"), label_AddressProvince));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddAddress"), label_title_addAddress));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), button_cancel));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Submit"), button_addAddress));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "FindAddress"), button_FindAddress));
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
