using System;
using System.Threading;
using System.Windows.Forms;
using AnsonGlue.Kernel;

namespace AnsonGlue.UI
{
    public partial class CPositionSetting : Form
    {
        

        /// <summary>
        ///     单例motionKernel对象
        /// </summary>
        private CKernel m_oKernel;

        public CPositionSetting()
        {
            InitializeComponent();
            m_oKernel = CKernel.GetInstance();
        }

        /// <summary>
        ///     窗口加载函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParaSetting_Load(object sender, EventArgs e)
        {
            
            AddRowToDataGridView(@"安全位");
            AddRowToDataGridView(@"清胶位");
            AddRowToDataGridView(@"排胶位");
            AddRowToDataGridView(@"拍照位");
            AddRowToDataGridView(@"相机标定");
            AddRowToDataGridView(@"阀标定");
            UpdateGridViewData();
        }


        private void AddRowToDataGridView(string strPositionName)
        {
            var index = dataGridView_Position.Rows.Add();
            dataGridView_Position.Rows[index].Cells[0].Value = strPositionName;
        }


        ///// <summary>
        /////     点击保存位置按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void m_rBtnSavePosition_Click(object sender, EventArgs e)
        //{
        //    var dXposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
        //    var dYposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
        //    var dZposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);
        //    var structPosition = new CKernel.STRUCT_POSITION(dXposition.ToString(CultureInfo.CurrentCulture),
        //        dYposition.ToString(CultureInfo.CurrentCulture), dZposition.ToString(CultureInfo.CurrentCulture));
        //   // m_oKernel.SetPositionToIni(m_comboBoxPosition.Text, structPosition);
        //}

        ///// <summary>
        /////     点击去当前选择位置按钮
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void m_rBtnGoPosition_Click(object sender, EventArgs e)
        //{
        //    var tGoPositionThread = new Thread(GoPositionThread) { IsBackground = true };
        //    //tGoPositionThread.Start(m_comboBoxPosition.Text);
        //}

        /// <summary>
        /// 走位线程
        /// </summary>
        /// <param name="obj"></param>
        private void GoPositionThread(object obj)
        {
            string strPosition = (string)obj;
            m_oKernel.Go2DPosition(0, strPosition);
        }

        /// <summary>
        /// 右键菜单点击保存选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Position.CurrentRow != null)
            {
                int iRowIndex = dataGridView_Position.CurrentRow.Index;
                string strXPosition = dataGridView_Position.Rows[iRowIndex].Cells[1].Value.ToString();
                string strYPosition = dataGridView_Position.Rows[iRowIndex].Cells[2].Value.ToString();
                string strZPosition = dataGridView_Position.Rows[iRowIndex].Cells[3].Value.ToString();
                var structPosition = new CKernel.STRUCT_POSITION(strXPosition,strYPosition, strZPosition);

                string strPosition = dataGridView_Position.Rows[iRowIndex].Cells[0].Value.ToString();
                m_oKernel.SetPositionToIni(strPosition, structPosition);

            }
        }

        /// <summary>
        /// 菜单点击运动选项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 运动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Position.CurrentRow != null)
            {
                int iRowIndex = dataGridView_Position.CurrentRow.Index;
                string strPosition = dataGridView_Position.Rows[iRowIndex].Cells[0].Value.ToString();
                var tGoPositionThread = new Thread(GoPositionThread) { IsBackground = true };
                //tGoPositionThread.Start(strPosition);
            }
        }

        /// <summary>
        /// 更新表格
        /// </summary>
        private void UpdateGridViewData()
        {
            int iRowCounts = dataGridView_Position.Rows.Count;
            for (int i = 0; i < iRowCounts; i++)
            {
                string strPosition = dataGridView_Position.Rows[i].Cells[0].Value.ToString();
                CKernel.STRUCT_POSITION sPosition;
                m_oKernel.GetPositionFromIni(strPosition, out sPosition);
                dataGridView_Position.Rows[i].Cells[1].Value = sPosition.m_strPositionX;
                dataGridView_Position.Rows[i].Cells[2].Value = sPosition.m_strPositionY;
                dataGridView_Position.Rows[i].Cells[3].Value = sPosition.m_strPositionZ;
            }
        }

        private void 获取当前位置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView_Position.CurrentRow != null)
            {
                var dXposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.X_AXIS);
                var dYposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Y_AXIS);
                var dZposition = m_oKernel.GetAxisCurPos(0, CKernel.ENUM_AXIS_TYPE.Z_AXIS);

                int iRowIndex = dataGridView_Position.CurrentRow.Index;

                dataGridView_Position.Rows[iRowIndex].Cells[1].Value = dXposition.ToString();
                dataGridView_Position.Rows[iRowIndex].Cells[2].Value = dYposition.ToString();
                dataGridView_Position.Rows[iRowIndex].Cells[3].Value = dZposition.ToString();

                //Console.Write(dataGridView_Position.Rows[dataGridView_Position.CurrentRow.Index].Cells[0].Value);
            }
        }

    }
}