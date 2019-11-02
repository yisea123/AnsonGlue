using System;
using System.Windows.Forms;
using AnsonGlue.UI;

namespace AnsonGlue
{
    static class _PROGRAM
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CGlue());
        }
    }
}
