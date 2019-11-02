using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnsonGlue.UI
{
    public partial class COkNg : Form
    {
        public COkNg()
        {
            InitializeComponent();
        }

        private void OkNg_Load(object sender, EventArgs e)
        {
            List<string> xData = new List<string>() { "Good", "NG", "No Check"};
            List<int> yData = new List<int>() { 70, 10, 20};
            m_chartOkNg.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            m_chartOkNg.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            m_chartOkNg.Series[0].Points.DataBindXY(xData, yData);
        }
    }
}
