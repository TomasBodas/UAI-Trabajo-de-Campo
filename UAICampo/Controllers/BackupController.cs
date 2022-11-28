using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Abstractions.Observer;
using UAICampo.BLL;
using UAICampo.Services;
using UAICampo.Services.Observer;
using UAICampo.UI.Administrator;

namespace UAICampo.UI.Controllers
{
    public partial class BackupController : UserControl, IObserver
    {
        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();
        BLL_LanguageManager bllLanguage;
        BLL_BackupManager bllBackup;
        private OpenFileDialog openFileDialog1;
        private SaveFileDialog saveFileDialog1;
        Language selectedLanguage;
        frmChangelog frmChangelog = null;

        public BackupController()
        {
            InitializeComponent();
            bllLanguage = new BLL_LanguageManager();
            bllBackup = new BLL_BackupManager();
            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
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
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "RestoreDV"), button3));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Changelog"), button4));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "ProfileList"), label_Title_Profile));
            //controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_Title_ProfileLicenses));
        }

        public void Update()
        {
            selectedLanguage = UserInstance.getInstance().user.language;
            bllLanguage.loadLanguageWords(selectedLanguage);

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

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Database backups (*.bak)|*.bak",
                Title = "Create database backup",
                InitialDirectory = Directory.GetCurrentDirectory(),
            };

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bllBackup.backup(saveFileDialog1.FileName))
                    {
                        MessageBox.Show("Backup created");
                    }
                    else
                    {
                        MessageBox.Show("Backup error!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "Database backups (*.bak)|*.bak",
                Title = "Open database backup",
                InitialDirectory = Directory.GetCurrentDirectory(),
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show(selectedLanguage.translate("Confirmation"), selectedLanguage.translate("Confirm"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (bllBackup.restore(openFileDialog1.FileName))
                    {
                        MessageBox.Show("Database restored");
                    }
                    MessageBox.Show("Restore error!");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BLL_DVManager.actualizarDV();
            MessageBox.Show("DV restored");
        }

        private void BackupController_Load(object sender, EventArgs e)
        {
            string[] errors = BLL_DVManager.obtenerErrores().Split('\n');
            foreach (string error in errors)
            {
                listBox1.Items.Add(error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (frmChangelog == null)
            {
                frmChangelog = new frmChangelog();
                frmChangelog.FormClosed += new FormClosedEventHandler(frmChangelog_FormClosed);
                frmChangelog.Show();
            }
            else
            {
                frmChangelog.BringToFront();
            }
        }

        private void frmChangelog_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChangelog = null;
        }
    }
}
