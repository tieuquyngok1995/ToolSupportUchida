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
            string lstTextDoc = "";
            lstTextDoc += "Huong Dan Su Dung Tool." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Convert Database" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de tach sql tu string sql" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Copy string SQL tu src paste vao input sql" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input SQL char(ten bien sql trong src vd: sql)" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Nhan button Add Param de lay cac param can thiet do vao luoi" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B4: Input value Param vao luoi " + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B5: Nhan button Convert SQL de lay cau sql da dc input param" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Tool chi ho tro tach cau sql don gian, truong hop qua dai vui long copy tung phan" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co nhieu truong hop tool co the bo xot, vui long confirm lai" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Get Const" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de get thong tin theo key value da duoc luu tai man hinh setting" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input logic name (ten tieng nhat)" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Bam button mui ten phai de lay physical name (id, code ...)" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - De lay logic name theo physical name thi lam nguoc lai" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Upper Case va Lower Case duoc ap dung cho physical name" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Convert Model" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de tao src theo tung ngon ngu da duoc setting co comment theo ten tieng nhat" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input logic name (ten tieng nhat)" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input physical name (id, code ...)" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Input type" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript dang cho phep tao src theo kieu Typescript va Observables" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript khi chon Set Para cho phep chen them ky tu vao logic name va physical name o src gen, duoc chon mode chen truoc hoac sau" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript khi chon checkbox interface se thuc hien tao ra src interface" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi HTML...." + CONST.CHAR_NEW_LINE;
            lstDocument.Text = lstTextDoc;


            // Set data ver update
            string lstTextVer = "";
            lstTextVer += "Ver1.0" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Phien ban dau tien cho phep setting thong tin su dung cho typescript va c#." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Databse tu he thong truoc đo."+ CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Sekkei he thong chay tuong tu he thong cua khach hang." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Convert Model tao model theo thong tin input cua nguoi dung." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Addapter theo thông tin config." + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE ;
            lstTextVer += "Ver2.0" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Common noi co cac chuc nang co the su dung o nhieu du an." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Json giup rut ngan thoi gian tao data json." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Message tao message theo format." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Format Comment giup chinh src cua cac comment sau noi dung src." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Html theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang Create Item Html theo format cua kh." + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextVer += "Ver2.1" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang chon ngon ngu java." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Convert Sekkei thanh Check CONST them kha năng search data const cua data đa input ." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Convert Model cho phep tao Model theo ngon ngu java." + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
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
