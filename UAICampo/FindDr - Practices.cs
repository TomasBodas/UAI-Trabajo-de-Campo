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
    public partial class FindDr___Practices : Form, IObserver
    {
        BLL_UserManager userBll = new BLL_UserManager();
        BLL_SessionManager sessionBLL;
        BLL_LanguageManager languageBLL;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        List<Services.Composite.Component> licenses = new List<Services.Composite.Component>();

        List<Procedure> procedures = new List<Procedure>();
        Procedure selectedProcedure = null;


        public FindDr___Practices()
        {
            InitializeComponent();
        }

        private void FindDr___Practices_Load(object sender, EventArgs e)
        {
            sessionBLL = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();

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

            loadProcedures();
            loadDataGridView();

            button_addProcedure.Enabled = false;
            button_deleteProcedure.Enabled = false;
        }
        //Button Add -----------------------------------------------------------------------
        private void button_addProcedure_Click(object sender, EventArgs e)
        {
            string name = textBox_name.Text;
            string desc = textBox_description.Text;
            double price = double.Parse(textBox_price.Text);

            Procedure newProcedure = new Procedure();
            newProcedure.Name = name;
            newProcedure.Desc = desc;
            newProcedure.Price = price;

            if (userBll.addProcedure(newProcedure, UserInstance.getInstance().user))
            {
                loadProcedures();
                loadDataGridView();
            }

            textBox_name.Text = "";
            textBox_description.Text = "";
            textBox_price.Text = "";
        }
        //Button Remove --------------------------------------------------------------------
        private void button_deleteProcedure_Click(object sender, EventArgs e)
        {
            if (selectedProcedure != null)
            {
                if (userBll.removeProcedure(selectedProcedure))
                {
                    loadProcedures();
                    loadDataGridView();
                }
            }
        }
        //-----------------------------------------------------------------------------------
        private void loadProcedures()
        {
            procedures.Clear();
            procedures = userBll.loadProcedures(UserInstance.getInstance().user);
        }
        private void loadDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = procedures;
        }
        private bool validate()
        {
            bool validated = true;
            if (textBox_name.Text == string.Empty) { validated = false; }
            if (textBox_description.Text == string.Empty) { validated = false; }
            if (textBox_price.Text == string.Empty) { validated = false; }
            if (!double.TryParse(textBox_price.Text, out _)) { validated = false; }
            return validated;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows != null)
            {
                try
                {
                    selectedProcedure = dataGridView1.SelectedRows[0].DataBoundItem as Procedure;
                    if (selectedProcedure != null)
                    {
                        button_deleteProcedure.Enabled = true;
                    }
                    else
                    {
                        button_deleteProcedure.Enabled = false;
                    }
                }
                catch (Exception)
                { }
            }
        }

        private void textBox_name_TextChanged(object sender, EventArgs e)
        {
            if (validate()) { button_addProcedure.Enabled = true; }
            else { button_addProcedure.Enabled = false; }
        }

        private void textBox_description_TextChanged(object sender, EventArgs e)
        {
            if (validate()) { button_addProcedure.Enabled = true; }
            else { button_addProcedure.Enabled = false; }
        }

        private void textBox_price_TextChanged(object sender, EventArgs e)
        {
            if (validate()) { button_addProcedure.Enabled = true; }
            else { button_addProcedure.Enabled = false; }
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Procedure"), label_Title_AddProcedure));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Name"), label_Name));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Description"), label_Description));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Price"), label_Price));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Submit"), button_addProcedure));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Remove"), button_deleteProcedure));


        }

    }
}
