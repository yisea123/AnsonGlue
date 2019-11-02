using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AnsonGlue.Repaint
{
    public partial class CRoundButton : Button
    {
        public Color m_disable;
        public Color m_enter;
        public Color m_fore;

        public Color m_hover;
        public Color m_press;
        public int m_radius;

        private MODEL m_oPaintmodel = MODEL.HOVER;


        public CRoundButton()
        {
            InitializeComponent();
            //这些得带上，不然会有黑边
            m_radius = 20;
            m_hover = Color.FromArgb(174, 218, 151);
            m_disable = Color.Red;
            m_enter = Color.FromArgb(255, 192, 192);
            m_press = Color.FromArgb(255, 128, 128);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
            FlatAppearance.MouseDownBackColor = Color.Transparent;
            FlatAppearance.MouseOverBackColor = Color.Transparent;
            SetDefaultColor();
        }

        /// <summary>
        /// 鼠标悬挂在按钮外时的按钮背景颜色
        /// </summary>
        public Color HoverBackColor
        {
            get { return m_hover; }
            set { m_hover = value; }
        }
        /// <summary>
        /// 鼠标进入按钮时按钮的背景颜色
        /// </summary>
        public Color EnterBackColor
        {
            get { return m_enter; }
            set { m_enter = value; }
        }
        /// <summary>
        /// 鼠标点击按钮时按钮的背景颜色
        /// </summary>
        public Color PressBackColor
        {
            get { return m_press; }
            set { m_press = value; }
        }
        /// <summary>
        /// 鼠标悬挂在按钮外时的按钮上字体的颜色
        /// </summary>
        public Color HoverForeColor
        {
            get { return m_fore; }
            set { m_fore = value; }
        }
        /// <summary>
        /// 鼠标进入按钮时的按钮上字体的颜色
        /// </summary>
        public Color EnterForeColor
        {
            get { return m_fore; }
            set { m_fore = value; }
        }
        /// <summary>
        /// 鼠标点击按钮时的按钮上字体的颜色
        /// </summary>
        public Color PressForeColor
        {
            get { return m_fore; }
            set { m_fore = value; }
        }
        /// <summary>
        /// 鼠标关闭使能时按钮的背景颜色
        /// </summary>
        public Color DisableBackColor
        {
            get { return m_disable; }
            set { m_disable = value; }
        }
        /// <summary>
        /// 圆角按钮的顶角弧度
        /// </summary>
        public int Radius
        {
            get { return m_radius; }
            set { m_radius = value; }
        }
        /// <summary>
        /// 设置按钮各个方面的颜色
        /// </summary>
        public void SetDefaultColor()
        {
            //给个初始值
            HoverBackColor = m_hover;
            EnterBackColor = m_enter;
            PressBackColor = m_press;
            HoverForeColor = m_fore;
            EnterForeColor = m_fore;
            PressForeColor = m_fore;
            DisableBackColor = m_disable;
            Radius = m_radius;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            SetDefaultColor();
            Refresh();
            base.OnLayout(levent);
        }

        protected override void OnParentChanged(EventArgs e)
        {
            Parent.SizeChanged += delegate { Refresh(); };
            base.OnParentChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); //这个不能去，而且得放在前面，不然会有黑框之类的莫名其妙的东西
            var colorback = HoverBackColor;
            var colorfore = HoverForeColor;
            switch (m_oPaintmodel)
            {
                case MODEL.HOVER:
                    colorback = HoverBackColor;
                    colorfore = HoverForeColor;
                    break;
                case MODEL.ENTER:
                    colorback = EnterBackColor;
                    colorfore = EnterForeColor;
                    break;
                case MODEL.PRESS:
                    colorback = PressBackColor;
                    colorfore = PressForeColor;
                    break;
                case MODEL.ENABLE:
                    colorback = HoverBackColor;
                    break;
                case MODEL.DISABLE:
                    colorback = DisableBackColor;
                    break;
                default:
                    colorback = HoverBackColor;
                    colorfore = HoverForeColor;
                    break;
            }

            Draw(e.ClipRectangle, e.Graphics, false, colorback);
            DrawText(e.ClipRectangle, e.Graphics, colorfore);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            m_oPaintmodel = MODEL.ENTER;
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            m_oPaintmodel = MODEL.HOVER;
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            m_oPaintmodel = MODEL.PRESS;
            base.OnMouseDown(mevent);
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            m_oPaintmodel = Enabled ? MODEL.ENABLE : MODEL.DISABLE;
            Invalidate(); //false 转换为true的时候不会刷新 这里强制刷新下
            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="rectangle">矩形</param>
        /// <param name="g">按钮图案的引用</param>
        /// <param name="cusp">是否加尖角</param>
        /// <param name="beginColor">渐变颜色的开始颜色</param>
        /// <param name="endColorex">渐变颜色的结束颜色</param>
        private void Draw(Rectangle rectangle, Graphics g, bool cusp, Color beginColor, Color? endColorex = null)
        {
            var endColor = endColorex ?? beginColor;
            var span = 2;
            //抗锯齿
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //渐变填充
            var myLinearGradientBrush =
                new LinearGradientBrush(rectangle, beginColor, endColor, LinearGradientMode.Vertical);
            //画尖角
            if (cusp)
            {
                span = 10;
                var p1 = new PointF(rectangle.Width - 12, rectangle.Y + 10);
                var p2 = new PointF(rectangle.Width - 12, rectangle.Y + 30);
                var p3 = new PointF(rectangle.Width, rectangle.Y + 20);
                PointF[] ptsArray = { p1, p2, p3 };
                g.FillPolygon(myLinearGradientBrush, ptsArray);
            }

            //填充
            g.FillPath(myLinearGradientBrush,
                DrawRoundRect(rectangle.X, rectangle.Y, rectangle.Width - span, rectangle.Height - 1, Radius));
        }
        /// <summary>
        /// 显示文本
        /// </summary>
        /// <param name="rectangle">按钮表现的矩形</param>
        /// <param name="g">按钮图案的引用</param>
        /// <param name="color">文本的颜色</param>
        private void DrawText(Rectangle rectangle, Graphics g, Color color)
        {
            var sbr = new SolidBrush(color);
            var rect = new RectangleF();
            switch (TextAlign)
            {
                case ContentAlignment.MiddleCenter:
                    rect = GetTextRec(rectangle, g);
                    break;
                default:
                    rect = GetTextRec(rectangle, g);
                    break;
            }

            g.DrawString(Text, Font, sbr, rect);
        }
        /// <summary>
        /// 得到文本信息所在的矩形
        /// </summary>
        /// <param name="rectangle">按钮表现的矩形</param>
        /// <param name="g">按钮图像的引用</param>
        /// <returns></returns>
        private RectangleF GetTextRec(Rectangle rectangle, Graphics g)
        {
            var rect = new RectangleF();
            var size = g.MeasureString(Text, Font);
            if (size.Width > rectangle.Width || size.Height > rectangle.Height)
            {
                rect = rectangle;
            }
            else
            {
                rect.Size = size;
                rect.Location = new PointF(rectangle.X + (rectangle.Width - size.Width) / 2,
                    rectangle.Y + (rectangle.Height - size.Height) / 2);
            }

            return rect;
        }
        /// <summary>
        /// 画圆角矩形
        /// </summary>
        /// <param name="x">圆角矩形的左上角顶点坐标X</param>
        /// <param name="y">圆角矩形的左上角顶点坐标Y</param>
        /// <param name="width">圆角矩形的宽</param>
        /// <param name="height">圆角矩形的高</param>
        /// <param name="radius">圆角矩形的弧度</param>
        /// <returns>返回的图像</returns>
        private GraphicsPath DrawRoundRect(int x, int y, int width, int height, int radius)
        {
            //四边圆角
            var gp = new GraphicsPath();
            gp.AddArc(x, y, radius, radius, 180, 90);
            gp.AddArc(width - radius, y, radius, radius, 270, 90);
            gp.AddArc(width - radius, height - radius, radius, radius, 0, 90);
            gp.AddArc(x, height - radius, radius, radius, 90, 90);
            gp.CloseAllFigures();
            return gp;
        }
        /// <summary>
        /// 鼠标和按钮的关系枚举
        /// </summary>
        private enum MODEL
        {
            HOVER,
            ENTER,
            PRESS,
            ENABLE,
            DISABLE
        }
    }
}