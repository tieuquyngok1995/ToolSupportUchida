using System;
using System.Windows.Forms;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Main());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application error exception: " + ex.Message, CONST.TEXT_CAPTION_ERROR,
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
