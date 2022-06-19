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
    public partial class FindDr___Office_manager : Form, IObserver
    {
        BLL_Address addressBll;
        BLL_UserManager userBll;
        BLL_LanguageManager languageBll;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        List<Province> provinces;
        Address newAddress = new Address();
        List<Address> offices = new List<Address>();

        public FindDr___Office_manager()
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

        private void FindDr___Office_manager_Load(object sender, EventArgs e)
        {
            getAllOffices();
        }

        private void button_addAddress_Click(object sender, EventArgs e)
        {
            string address1 = textBox_Address1.Text;
            string address2 = textBox_Address2.Text;
            int addressNumber = int.Parse(textBox_AddressNum.Text);
            Province selectedProvince = null;
            foreach (Province province in provinces)
            {
                if (province.name == comboBox2.Text)
                {
                    selectedProvince = province;
                    break;
                }
            }

            newAddress.Address1 = address1;
            newAddress.Address2 = address2;
            newAddress.AddressNumber = addressNumber;
            newAddress.Province = selectedProvince;

            addressBll.AddOffice(newAddress, UserInstance.getInstance().user);

            textBox_Address1.Text = "";
            textBox_Address2.Text = "";
            textBox_AddressNum.Text = "";
            comboBox2.Text = "";

            getAllOffices();
        }

        private void loadProvinces()
        {
            button_addAddress.Enabled = false;
            comboBox1.DataSource = null;
            provinces = addressBll.getProvincesList();
            foreach (Province province in provinces)
            {
                comboBox2.Items.Add(province.name);
            }
        }

        private void getAllOffices()
        {
            comboBox1.Items.Clear();
            offices = addressBll.getAllOffices(UserInstance.getInstance().user);
            foreach (Address address in offices)
            {
                comboBox1.Items.Add($"{address.Address1}");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Address address in offices)
            {
                if (address.Address1 == comboBox1.Text)
                {
                    webBrowser1.Navigate(GoogleMapsBuilder.addressBuilder(address.Address1, address.Address2, address.AddressNumber, address.City));
                }
            }
        }
        private bool validateFields()
        {
            bool validated = true;

            if (textBox_Address1.Text == "") { validated = false; }
            if (textBox_Address2.Text == "") { validated = false; }
            if (textBox_AddressNum.Text == "" || !int.TryParse(textBox_AddressNum.Text, out _)) { validated = false; }
            if (comboBox2.Text == "") { validated = false; }

            return validated;
        }
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

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!validateFields()) { button_addAddress.Enabled = false; }
            else { button_addAddress.Enabled = true; }
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Address1"), label_Address1));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Address2"), label_Address2));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddressNum"), label_AddressNum));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddressProvince"), label_AddressProvince));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Office"), label_Title_Office));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Cancel"), button_cancel));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Submit"), button_addAddress));
        }

        
    }
}
