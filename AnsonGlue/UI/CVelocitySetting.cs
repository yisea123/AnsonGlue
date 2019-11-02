using System;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class CVelocitySetting : Form
    {
        public CVelocitySetting()
        {
            InitializeComponent();
        }

        private void m_rBtnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}