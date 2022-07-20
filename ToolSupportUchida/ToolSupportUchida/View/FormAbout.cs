using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.View
{
    public partial class FormAbout : Form
    {

        #region Load Form
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            LoadTheme();

            // Set data ver update
            string lstTextVer = "";
            lstTextVer += "Ver1.0" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Phien ban dau tien cho phep setting thong tin su dung cho typescript va c#." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Databse tu he thong truoc đo."+ CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Sekkei he thong chay tuong tu he thong cua khach hang." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Model tao model theo thong tin input cua nguoi dung." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Addapter theo thông tin config." + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += "Ver2.0" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Common noi co cac chuc nang co the su dung o nhieu du an." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Json giup rut ngan thoi gian tao data json." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Message tao message theo format." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Format Comment giup chinh src cua cac comment sau noi dung src." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Html theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Item Html theo format cua kh." + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += "Ver2.1" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang chon ngon ngu java." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Convert Sekkei thanh Check CONST them kha năng search data const cua data đa input ." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Convert Model cho phep tao Model theo ngon ngu java." + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE + CONST.CHAR_NEW_LINE;
            lstTextVer += " More update to next time ............" + CONST.CHAR_NEW_LINE;

            lstTextUpdateVer.Text = lstTextVer;
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
        }
        #endregion
    }
}
