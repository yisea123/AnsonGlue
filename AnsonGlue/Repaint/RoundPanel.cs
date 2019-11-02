using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnsonGlue.Repaint
{
    public partial class CRoundPanel : UserControl
    {
        private int m_oCount;
        public int m_radius;

        public CRoundPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 重载的构造函数
        /// </summary>
        /// <param name="container">用来放RoundPanel的引用</param>
        public CRoundPanel(IContainer container)
        {
            m_oCount = 0;
            m_radius = 10;
            container.Add(this);
            InitializeComponent();
        }
        /// <summary>
        /// 设置Panel的圆角的弧度
        /// </summary>
        public int SetRoundRadius
        {
            get { return m_radius; }
            set
            {
                m_radius = value < 0 ? 0 : value;
                base.Refresh();
            }
        }

        /// <summary>
        /// 画圆角
        /// </summary>
        /// <param name="region">先要实现圆角的区域</param>
        public void Round(Region region)
        {
            var oPath = new GraphicsPath();
            if (m_oCount == 0)
            {
                var x = 0;
                var y = 0;

                var thisWidth = Width;
                var thisHeight = Height;
                var angle = m_radius;
                if (angle > 0)
                {
                    CreateGraphics();
                    oPath.AddArc(x, y, angle, angle, 180, 90);
                    // 左上角
                    oPath.AddArc(thisWidth - angle, y, angle, angle, 270, 90);
                    // 右上角
                    oPath.AddArc(thisWidth - angle, thisHeight - angle, angle, angle, 0, 90);
                    // 右下角
                    oPath.AddArc(x, thisHeight - angle, angle, angle, 90, 90);
                    // 左下角
                    oPath.CloseAllFigures();
                    Region = new Region(oPath);
                }
                // ---------------------------------------------------------------------------------------------
                else
                {
                    // 顶端
                    oPath.AddLine(x + angle, y, thisWidth - angle, y);
                    // 右边
                    oPath.AddLine(thisWidth, y + angle, thisWidth, thisHeight - angle);
                    // 底边
                    oPath.AddLine(thisWidth - angle, thisHeight, x + angle, thisHeight);
                    // 左边
                    oPath.AddLine(x, y + angle, x, thisHeight - angle);
                    oPath.CloseAllFigures();
                    Region = new Region(oPath);
                }

                m_oCount += 1;
            }
        }
        /// <summary>
        /// 重绘函数
        /// </summary>
        /// <param name="pe">重绘事件实参</param>
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            Round(Region);
        } // 圆角

        protected override void OnResize(EventArgs eventargs)
        {
            base.OnResize(eventargs);
            base.Refresh();
        }
    }
}