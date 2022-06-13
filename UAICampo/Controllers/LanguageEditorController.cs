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
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class LanguageEditorController : UserControl, IObserver
    {
        BLL_LanguageManager languageBLL;

        public static List<Language> languages;
        public static Dictionary<string, string> words;
        public static Language language;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        public LanguageEditorController()
        {
            InitializeComponent();
            languageBLL = new BLL_LanguageManager();

            FillLanguages();
            dataGridView1.Columns.Add("key", "Tag");
            dataGridView1.Columns.Add("value", "Word");

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }
        }

        public void FillLanguages()
        {
            languages = languageBLL.getAll().ToList();

            comboBox1.Items.Clear();
            foreach (var item in languages)
            {
                comboBox1.Items.Add(item.Name);
            }
        }

        public void loadDictionary()
        {
            words = languageBLL.loadWordsDictionary(language);
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string selectedLanguage = comboBox1.SelectedItem.ToString();
            language = languages.Find(item => item.Name == selectedLanguage);
            loadDictionary();
            foreach (KeyValuePair<string, string> item in words)
            {
                dataGridView1.Rows.Add(new string[] { item.Key, item.Value });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            languageBLL.createLanguage(textBox1.Text);
            MessageBox.Show("Language created");
            textBox1.Clear();
            FillLanguages();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string selectedLanguage = comboBox1.SelectedItem.ToString();
                Language language = languages.Find(item => item.Name == selectedLanguage);
                languageBLL.deleteLanguage(language);
                comboBox1.SelectedIndex = -1;
                FillLanguages();
                MessageBox.Show(String.Format("Language {0} deleted", language.Name));
            }
        }

        public void Update()
        {
            Language selectedLanguage = UserInstance.getInstance().user.language;

            languageBLL.loadLanguageWords(selectedLanguage);

            foreach (var controller in controllers)
            {
                try
                {
                    if (controller.Key.Word != null)
                    {
                        KeyValuePair<string, string> textValue = selectedLanguage.words.SingleOrDefault(kvp => kvp.Key == controller.Key.Word);
                        if (textValue.Value != null)
                        {
                            controller.Value.Text = textValue.Value;
                        }
                        else
                        {
                            controller.Value.Text = "Not found";
                        }

                    }
                }
                catch (Exception)
                { }
            }
        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.IsCurrentRowDirty)
            {
                dataGridView1.EndEdit();
                if (!words.ContainsKey(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    languageBLL.addWord(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), language.Id);
                }
                else
                {
                    languageBLL.updateWord(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(), language.Id);
                }
                loadDictionary();
            }
        }

        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Add"), button_addLanguage));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Remove"), button_deleteLanguage));
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LoadWords"), button_loadWords));
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "AddLanguage"), label_addLanguage));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ChooseLanguage"), label_chooseLanguage));
        }
    }
}
