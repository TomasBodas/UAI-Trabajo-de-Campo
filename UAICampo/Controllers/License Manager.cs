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
using Component = UAICampo.Services.Composite.Component;

namespace UAICampo.UI.Controllers
{
    public partial class License_Manager : UserControl
    {

        BLL_Licences bLL_Licences;
        BLL_SessionManager bll_session;

        IList<Composite> licenses;

        Component selectedLicense = null;

        public License_Manager()
        {
            InitializeComponent();
            bLL_Licences = new BLL_Licences();
            bll_session = new BLL_SessionManager();

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

                }
                catch (Exception)
                { }
            }
        }
    }
}
