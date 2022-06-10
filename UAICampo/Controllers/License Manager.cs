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

namespace UAICampo.UI.Controllers
{
    public partial class License_Manager : UserControl
    {
        private static readonly string ADMIN_PROFILE = "Admin";

        BLL_Licences bLL_Licences;
        BLL_SessionManager bll_session;

        IList<Composite> licenses;

        public License_Manager()
        {
            InitializeComponent();
            bLL_Licences = new BLL_Licences();
            bll_session = new BLL_SessionManager();

            licenses = new List<Composite>();
        }

        private void License_Manager_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                treeView_License.Nodes.Clear();

                User currentUser = UserInstance.getInstance().user;
                Profile profile = currentUser.profileList.Find(x => x.ProfileName == ADMIN_PROFILE);

                if (profile != null)
                {
                    TreeNode node = treeView_License.Nodes.Add(profile.ProfileName + " --> " + profile.Desc);

                    foreach (Composite license in profile.Licences)
                    {
                        node.Nodes.Add(AddNode(license));
                    }

                }
            }
        }

        private TreeNode AddNode(Composite license)
        {
            TreeNode node = new TreeNode();

            foreach (Composite item in license.GetAllChildren())
            {
                node.Text = license.Name + " --> " + license.Description;
                node.Nodes.Add(AddNode(item));
            }
            return node;
        }
    }
}
