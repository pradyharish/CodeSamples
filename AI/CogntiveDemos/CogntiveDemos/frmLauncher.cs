using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CogntiveDemos
{
    public partial class frmLauncher : Form
    {
        public frmLauncher()
        {
            InitializeComponent();
        }

        private void btnComputerVision_Click(object sender, EventArgs e)
        {
            frmComputerVision frmCV = new frmComputerVision();
            frmCV.ShowDialog();
        }

        private void btnTranslator_Click(object sender, EventArgs e)
        {
            frmTranslator frmTsnltr = new frmTranslator();
            frmTsnltr.ShowDialog();
        }

        private void btnTranslator_Click_1(object sender, EventArgs e)
        {
            frmTranslator frmTsnltr = new frmTranslator();
            frmTsnltr.ShowDialog();
        }

        private void btnFace_Click(object sender, EventArgs e)
        {
            frmFace frmFace1 = new frmFace();
            frmFace1.ShowDialog();
        }
    }
}
