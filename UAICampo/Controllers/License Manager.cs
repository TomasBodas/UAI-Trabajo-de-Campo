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
using UAICampo.Services;
using UAICampo.Services.Composite;
using Microsoft.VisualBasic;
using Component = UAICampo.Services.Composite.Component;
using UAICampo.Abstractions.Observer;
using UAICampo.Services.Observer;

namespace UAICampo.UI.Controllers
{
    public partial class License_Manager : UserControl, IObserver
    {

        BLL_Licences bLL_Licences;
        BLL_SessionManager bll_session;
        BLL_LanguageManager languageBLL;

        IList<Composite> licenses;

        List<KeyValuePair<Tag, Control>> controllers = new List<KeyValuePair<Tag, Control>>();

        Component selectedLicense = null;

        public License_Manager()
        {
            InitializeComponent();
            bLL_Licences = new BLL_Licences();
            bll_session = new BLL_SessionManager();
            languageBLL = new BLL_LanguageManager();

            SetControllerTags();

            if (UserInstance.getInstance().user != null)
            {
                UserInstance.getInstance().user.Add(this);
                Update();
            }

            licenses = new List<Composite>();
        }

        private void getLicenseTree()
        {

        }
        private void License_Manager_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                loadTreeView();
                loadLicensePool();
            }
        }
        private void loadLicensePool()
        {
            List<Component> OrphanLicensePool = bLL_Licences.getOrphanLicensePool();

            listBox1.Items.Clear();
            foreach (Component license in OrphanLicensePool)
            {
                listBox1.Items.Add(license);
            }
        }
        private void loadTreeView()
        {
            treeView_License.Nodes.Clear();

            TreeNode parentNode = new TreeNode();
            parentNode.Text = "Existing Licenses: ";

            treeView_License.Nodes.Add(parentNode);

            Component licenses = bLL_Licences.getLicensePersistanceTree();

            AddNode((Composite)licenses, parentNode);
            treeView_License.ExpandAll();
        }
        private void AddNode(Composite component, TreeNode node)
        {
            if (component != null)
            {
                TreeNode newNode = new TreeNode();
                newNode.Text = $"{component.Name}";
                newNode.Tag = component.Id;

                node.Nodes.Add(newNode);

                foreach (Composite license in component.child)
                {
                    AddNode(license, newNode);
                }
            }
        }
        private void treeView_License_MouseUp(object sender, MouseEventArgs e)
        {
            if (treeView_License.SelectedNode != null && treeView_License.SelectedNode.Tag != null)
            {
                Component license = bLL_Licences.SearchLicenseById((int)treeView_License.SelectedNode.Tag);

                selectedLicense = license;

                if (license != null)
                {
                    label_LicenseId.Text = license.Id.ToString();
                    labelLicenseName.Text = license.Name;
                    label_LicenseDescription.Text = license.Description;
                }
            }
        }

        private void button_addChildLicense_Click(object sender, EventArgs e)
        {
            if (selectedLicense != null && listBox1.SelectedItem != null)
            {
                try
                {
                    Component orphanLicense = (Component)listBox1.SelectedItem;

                    //First retrieve the persistance tree from de DB
                    Component PersistanceTree = bLL_Licences.getLicensePersistanceTree();

                    //Then, we get the list of all licenses currently in the persistance tree
                    List<Component> PersistanceTreeLicenseTree = PersistanceTree.GetAllChildren().ToList();

                    //Then, we search the list, until we find the same license as the one selected by the user
                    foreach (Component license in PersistanceTreeLicenseTree)
                    {
                        //If we find the license, we add the selected orphan license as its child.
                        if (license.Id == selectedLicense.Id)
                        {
                            //We send both IDs to be persisted in the relationship table.
                            bLL_Licences.updateRelationships(license.Id, orphanLicense.Id);

                            BLL_LogManager.addMessage(new Log
                            {
                                Date = DateTime.Now,
                                Code = "NEW_LICENSE_RELATION_OK",
                                Description = String.Format($"Account {UserInstance.getInstance().user.Username} added a new license dependency" +
                                $" Master License ID: {license.Id}, Slave License ID: {orphanLicense.Id}"),
                                Type = LogType.Control,
                                User = UserInstance.getInstance().user
                            }); ;
                        }
                    }

                    //After that, we refresh the UI
                    loadTreeView();
                    loadLicensePool();
                }
                catch (Exception)
                { }
            }
        }

        private void button_removeChildLicense_Click(object sender, EventArgs e)
        {
            if (selectedLicense != null)
            {
                try
                {
                    //First retrieve the persistance tree from de DB
                    Component PersistanceTree = bLL_Licences.getLicensePersistanceTree();

                    //Then, we get the list of all licenses currently in the persistance tree
                    List<Component> PersistanceTreeLicenseTree = PersistanceTree.GetAllChildren().ToList();

                    //Then, we search the list, until we find the same license as the one selected by the user
                    foreach (Component license in PersistanceTreeLicenseTree)
                    {
                        //If we find the license, we add the selected orphan license as its child.
                        if (license.Id == selectedLicense.Id)
                        {
                            //We send both IDs to be persisted in the relationship table.
                            bLL_Licences.removeRelationship(license);

                            BLL_LogManager.addMessage(new Log
                            {
                                Date = DateTime.Now,
                                Code = "LICENSE_TO_LICENSEPOOL_OK",
                                Description = String.Format($"Account {UserInstance.getInstance().user.Username} moved license to orphan license pool" +
                                $" License ID: {license.Id}"),
                                Type = LogType.Control,
                                User = UserInstance.getInstance().user
                            }); ;
                        }
                    }

                    //After that, we refresh the UI
                    loadTreeView();
                    loadLicensePool();
                }
                catch (Exception)
                { }
            }
        }

        //Add new license
        //You can only add licenses into de License pool
        //You can not alter the persistance license relation tree
        private void button_addLicense_Click(object sender, EventArgs e)
        {
            string licenseName = "";
            string licenseDescription = "";

            licenseName = Interaction.InputBox("License", "Name", "License Name");
            licenseDescription = Interaction.InputBox("License", "Description", "License Description");

            if (licenseName != "" && licenseDescription != "")
            {
                //new component is created, without an ID, as it will be assigned in the DB
                Component NewLicense = new Composite(licenseName, licenseDescription);

                //New License will be persisted
                if (bLL_Licences.addNewLicense(NewLicense))
                {
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "NEW_LICENSE_ADD_OK",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} added a new license"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    }); ;

                    loadTreeView();
                    loadLicensePool();
                }
                else
                {
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "NEW_LICENSE_ADD_FAIL",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} tried to add a new license"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    }); ;
                }
            }
        }

        //Delete license
        //You can only delete licenses in the license pool.
        //You can not alter the persistance license relation tree
        private void button_deleteLicense_Click(object sender, EventArgs e)
        {
            Component orphanLicense = (Component)listBox1.SelectedItem;
            if (orphanLicense != null)
            {
                if (bLL_Licences.removeLicense(orphanLicense))
                {
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "NEW_LICENSE_DELETE_OK",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} removed an existing license"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    }); ;

                    loadTreeView();
                    loadLicensePool();
                }
                else
                {
                    BLL_LogManager.addMessage(new Log
                    {
                        Date = DateTime.Now,
                        Code = "NEW_LICENSE_DELETE_FAIL",
                        Description = String.Format($"Account {UserInstance.getInstance().user.Username} tried to remove an existing license"),
                        Type = LogType.Control,
                        User = UserInstance.getInstance().user
                    }); ;
                }
            }
        }

        //Language Update
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

        private void SetControllerTags()
        {
            //In here, we set each controller tag list.
            //This list wil be made out of keyvaluepairs, with a controller, and a tag
            //Each Tag will be made out of two values
            //First value: license required for it to show up to the user
            //Second value: Word Tag, used for language runtime changes

            //General controllers------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Add"), button_addLicense));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "Remove"), button_deleteLicense));
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseList"), label_TItle));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicensePoolList"), label_Title_LicensePool));
            //-------------------------------------------------------------------------------------------------------
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseId"), label_Title_LicenseId));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseName"), label_Title_LicenseName));
            controllers.Add(new KeyValuePair<Tag, Control>(new Services.Tag(0, "LicenseDesc"), label_Title_LicenseDesc));
        }
    }
}
