﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UAICampo.UI
{
    public partial class frmEquipoManager : Form
    {
        public frmEquipoManager()
        {
            InitializeComponent();
        }

        private void frmEquipoManager_Load(object sender, EventArgs e)
        {
            equipoController1.F1 = this;
        }
    }
}
