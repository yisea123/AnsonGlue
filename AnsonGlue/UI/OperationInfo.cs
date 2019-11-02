using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class COperationInfo : Form
    {
        private CKernel m_oKernel;
        public COperationInfo()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        private void m_dataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex < 0 && e.RowIndex >= 0) // 绘制 自动序号
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);
                Rectangle vRect = e.CellBounds;
                vRect.Inflate(-2, 2);
                TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, vRect, e.CellStyle.ForeColor, TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                e.Handled = true;
            }

            // ----- 其它样式设置 -------
            if (e.RowIndex % 2 == 0)
            { // 行序号为双数（含0）时 
                e.CellStyle.BackColor = Color.White;
            }
            else
            {
                e.CellStyle.BackColor = Color.Honeydew;
            }
            e.CellStyle.SelectionBackColor = Color.Gray; // 选中单元格时，背景色
            e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //单位格内数据对齐方式
        }

        public void AddOperationInfo(string strEvent)
        {
            if (m_dataGridViewInfo.InvokeRequired)
            {
                
                //CFileTcp.DISPLAY_MSG displayOperationMsg = AddOperationInfo;
                //m_dataGridViewInfo.Invoke(displayOperationMsg, strEvent);
                m_dataGridViewInfo.Invoke(new Action(() =>
                {
                    int index = m_dataGridViewInfo.Rows.Add();
                    m_dataGridViewInfo.Rows[index].Cells[0].Value = strEvent;
                    m_dataGridViewInfo.Rows[index].Cells[1].Value = DateTime.Now.AddSeconds(1.1).ToString(CultureInfo.CurrentCulture);
                }));
            }
            else
            {
                int index = m_dataGridViewInfo.Rows.Add();
                m_dataGridViewInfo.Rows[index].Cells[0].Value = strEvent;
                m_dataGridViewInfo.Rows[index].Cells[1].Value = DateTime.Now.AddSeconds(1.1).ToString(CultureInfo.CurrentCulture);
            }
        }

        public new void Close()
        {
            Dispose();
        }
    }
}
