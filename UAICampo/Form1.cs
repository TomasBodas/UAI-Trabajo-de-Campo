using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UAICampo.Services;

namespace UAICampo
{
    public partial class Form1 : Form
    {
        private UI_Validation validations;
        public Form1()
        {
            InitializeComponent();
            validations = new UI_Validation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
