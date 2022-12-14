using System;
using System.Drawing;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
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
            lstTextDoc += "Setting CONST" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung Setting Logical Name va Physical Name su dung tai chuc nang Get CONST." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Tao file data theo format: Key=Value." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Su dung chuc nang Import Data bang file da tao tu B1, mode Const." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the thao tac them tung dong tai muc Setting CONST." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the thao tac chinh sua va xoa record tai table." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Setting Format" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung Setting Format cho cac item tai Create Iten." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Tao file data theo format: Type[--]Key[--]Value<br>." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Su dung chuc nang Import Data bang file da tao tu B1, mode Format." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the thao tac them tung dong tai muc Setting Format." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the thao tac them Setting rieng biet co cac item theo format: Setting[--]Type can setting[--] item key can setting| gia tri setting." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the tao Setting cho cac item dac biet theo format: Setting[--]Type can format[--]format|key can format|Value format su dung {-}." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Convert Database" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de tach sql tu string sql." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Copy string SQL tu src paste vao input sql." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input SQL char(ten bien sql trong src vd: sql)." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Nhan button Add Param de lay cac param can thiet do vao luoi." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B4: Input value Param vao luoi." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B5: Nhan button Convert SQL de lay cau sql da dc input param." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Tool chi ho tro tach cau sql don gian, truong hop qua dai vui long copy tung phan." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co nhieu truong hop tool co the bo xot, vui long confirm lai." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Get Const" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de get thong tin theo key value da duoc luu tai man hinh setting." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input logic name (ten tieng nhat)." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Bam button mui ten phai de lay physical name (id, code ...)." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - De lay logic name theo physical name thi lam nguoc lai." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Upper Case va Lower Case duoc ap dung cho physical name." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Convert Model" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de tao src theo tung ngon ngu da duoc setting co comment theo ten tieng nhat." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input logic name (ten tieng nhat)." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input physical name (id, code ...)." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Input type" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript dang cho phep tao src theo kieu Typescript va Observables." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript khi chon Set Para cho phep chen them ky tu vao logic name va physical name o src gen, duoc chon mode chen truoc hoac sau." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi Typescript khi chon checkbox interface se thuc hien tao ra src interface." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Doi voi HTML...." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Create Item" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Su dung de tao src theo thong tin da duoc seting tai seting, hien tai chi su dung doi voi html." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Chon cac thong tin can thiet va bam Create Param." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input gia tri cac item yeu cau tai table set param." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Input gia tri Format Value hoac Value neu duoc yeu cau." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B4: Bam Create Result de lay duoc src." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Format Value la thong tin gia tri {-} da duoc setting tai setting." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Value hien tai dang duoc su dung cho viec tao table." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Truong hop la class tieng thi input tieng nhat tool tu lay code tuong ung neu co." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "Chuc nang Common" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Mot so chuc nang common thuong dung." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Create JSON:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Tao string JSON theo format da duoc setting truoc." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input Case, Out" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input key parameter, khi nay se xuat hien key tai table." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Input value theo tung key vao tabl.e" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B4: Nhan duoc chuoi json theo format voi key values da input." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Mode create obj se tao object thay vi chuoi string json." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Format Comment:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Format comment cuoi ham cua 1 doan src." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input noi dung src chua comment o cuoi hang sau do bam format." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Tu format thang hang cac coment." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Get Name Column:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Lay thong tin cua tung colum table trong thiet ke theo format." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input data la thong tin table co trong thiet ke, dong dau tien la ten table tu テーブル論理名 toi ten logic." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input danh sach table se su dung." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Input doan text can tim kiem." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B4: Chon format tuong ung cua doan text da input." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - " + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Create Message:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Tao message theo thong tin da duoc cung cap tai thiet ke ." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B1: Input code tai file thiet ke vao filed message code." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B2: Input message tai file thiet ke vao filed message content." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - B3: Nhan Create mess de nhan noi dung message tuong ung cua noi dung da input." + CONST.CHAR_NEW_LINE;
            lstTextDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            lstTextDoc += "          - Co the tao src tao message theo cac tuy chon da setting" + CONST.CHAR_NEW_LINE;
            lstDocument.Text = lstTextDoc;


            // Set data version update
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
            lstTextVer += "Ver2.2" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang chon common Get Name Column." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Create Adapter thanh Create Item theo thong tin da duoc setting." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Remove chuc nang Common Create Item HTML." + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextVer += "Ver2.3" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang tao comment tu noi dung tieng nhat va src." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Get Name Column them xu li tao sql theo tkct." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Chinh sua chuc nang Format Comment them chon mode comment." + CONST.CHAR_NEW_LINE;
            lstTextVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            lstTextVer += "Ver2.4" + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Them moi chuc nang tao copy va clone file src tu src da co." + CONST.CHAR_NEW_LINE;
            lstTextVer += "    - Reopen chuc nang tao comment tu thong tin da co." + CONST.CHAR_NEW_LINE;
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
