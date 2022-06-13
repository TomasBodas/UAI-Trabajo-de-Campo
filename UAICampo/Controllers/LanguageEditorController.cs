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
        public LanguageEditorController()
        {
            InitializeComponent();
            languageBLL = new BLL_LanguageManager();

            FillLanguages();
            dataGridView1.Columns.Add("key", "Tag");
            dataGridView1.Columns.Add("value", "Word");

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
    }
}
