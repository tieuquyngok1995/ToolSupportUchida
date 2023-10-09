using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;
using static System.Net.Mime.MediaTypeNames;

namespace ToolSupportCoding.View
{
    public partial class FormAbout : Form
    {
        private Dictionary<string, string> dicDoc = new Dictionary<string, string>();

        #region Load Form
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            LoadTheme();

            SetDataDoc();

            SetDataVer();
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

        #region Event
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            txtDocument.Text = string.Empty;

            foreach (KeyValuePair<string, string> dic in dicDoc)
            {
                string key = dic.Key;

                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    result += dic.Value + CONST.CHAR_NEW_LINE;
                }
                else if (key.ToUpper().Contains(txtSearch.Text.ToUpper()))
                {
                    result += dic.Value + CONST.CHAR_NEW_LINE;
                }
            }

            txtDocument.Text = result;
        }

        #endregion

        #region Methor
        private void SetDataDoc()
        {
            txtDocument.Text += "Huong Dan Su Dung." + CONST.CHAR_NEW_LINE;

            string textDoc = string.Empty;
            textDoc += "Setting CONST" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Them cong cu thiet lap noi dung Logic va Physical." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Tao file data theo format: Key=Value." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Su dung chuc nang Import Data bang file da tao tu truoc mode Const." + CONST.CHAR_NEW_LINE;
            textDoc += "Setting Format" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Them noi dung setting cho cac chuc nang se su dung tai tool." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Tao file data theo format: Type[--]Key[--]Value<br>." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Su dung chuc nang Import Data bang file da tao tu truoc mode Format." + CONST.CHAR_NEW_LINE;
            textDoc += "Luu Y" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Co the search thong tin da duoc luu, them moi chinh sua theo cac button chuc nang da setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Co the chinh sua truc tiep thong tin tai tung row data tren table da setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Co the xoa truc tiep thong tin tai tung row data tren table da setting." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Setting", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chuc nang Get SQL in Src" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Su dung de lay noi dung SQL theo noi dung da coding trong src, cho phep input noi dung parameter su dung trong src input." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Copy string SQL tu src paste vao o Input SQL." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input SQL char(ten bien SQL su dung trong Src vd: sql, strSql ... )." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Nhan button Add Param de lay cac parameter co trong src SQL hien thi len luoi Input Parameter." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input value Parameter vao luoi." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Nhan button Convert SQL de lay ket qua SQL sau khi xu li." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu Y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tool chi ho tro tach cac cau SQL don gian, truong hop noi dung can xu li dai thi nen tach ra xu li tung phan." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Vui long kiem tra lai noi dung sau khi xu li tranh sai xot." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get SQL in Src", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chuc nang Get Const" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Su dung get thong tin Logical hoac Physical theo noi dung da duoc setting tai phan setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name hoac Physical Name can tim." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Nhan button mui ten trai hoac phai de lay thong tin, truong hop k ton tai thi se tra ve gia tri da input." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu Y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Co the input nhieu dong de tim kiem." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Upper Case va Lower Case duoc ap dung cho physical name." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Const", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chuc nang Create Model" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Su dung de tao Model theo noi dung da duoc mo ta tai thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (ten tieng nhat) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiet ke" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu Y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Doi voi Typescript dang cho phep tao src theo kieu Typescript va Observables." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Doi voi Typescript khi chon Set Para cho phep chen them ky tu vao Logic Name va Physical Name vao noi dung Src duoc tao ra, cho phep setting vi tri them ky tu." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Doi voi Typescript khi chon checkbox Create Interface se thuc hien tao noi dung src Interface." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Doi voi Java khi chon checkbox Create Static se thuc hien tao noi dung src Static." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chuc nang Create View Model" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Su dung de tao Src View Model theo noi dung da duoc mo ta tai thiet ke, dang su dung cho 2 mode C# va Typescript." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (ten tieng nhat) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiet ke" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input Name Item ten item su dung hien thi tren man hinh duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Input Validation duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu Y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Gia tri tai Name Item va Validation phai bang nhau." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Validation se maping theo Name Item check Name Item bang cach su dung common Get View Model." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tai mode Typescript can input them ten Logical va Physical View Model theo thiet ke" + CONST.CHAR_NEW_LINE;
            textDoc += "Chuc nang Create HTML" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Su dung de tao noi dung sr HTML theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (ten tieng nhat) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiet ke" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input Name Item ten item su dung hien thi tren man hinh duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Input Validation duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu Y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Gia tri tai Name Item va Validation phai bang nhau." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Validation se maping theo Name Item check Name Item bang cach su dung common Get View Model." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tai mode Typescript can input them ten Logical va Physical View Model theo thiet ke" + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create View Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chuc nang Common" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khai Quat:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Cac chuc nang common duoc tao de su dung o nhieu truong hop." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Common", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "    + Get Name Column:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tim kiem thong tin column trong table theo ten da duoc mo ta tai thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Data theo noi dung mo ta tai thiet ke table, lay thong tin tu cot Table Logical Name cho toi ten ten Logic." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input danh sach table se su dung." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Name Column", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Get View Model:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Lay thong tin Logical va Physical cua item tren man hinh theo thong tin Item man hinh, Item View Model va Functional Item theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Screen Item theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Logical va Physical Name theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Functional Item va Functional Property theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get View Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Get Item Resource:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Lay thong tin Item Resource tu noi dung theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Name Item duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Control theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Resource theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Item Resource", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create JSON:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tao noi dung JSON theo format da duoc setting truoc." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Case, Out trong truong hop la mode Create Json." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Key Parameter, khoi tao danh sach parameter de input value tai phan Input Value." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input value theo tung Key vao table." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Mode Create Object se tao Object thay vi chuoi string json." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create JSON", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Entity:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tao noi dung File Entity theo mo ta tai thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input noi dung thiet ke procedure vao cot SQL Procedure." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input thong tin table theo thiet ke vao cot SQL Table." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Bam button Create Enity de thuc thi tao src." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Entity", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create File Source:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tao file theo noi dung da duoc mo ta theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input ten tieng nhat cua file se duoc tao theo thiet ke tai cot Logical Class Name." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input ten file tai cot Physical Class Name." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input duong dan file tai cot Path Source Name." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - T.h thiet ke khong co mo ta ten Logical Name thi co the de trong" + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create File Source", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Message:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tao Message theo thong tin da duoc cung cap theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Code theo thiet ke vao Message Code." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Content theo thiet ke vao Message Content." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Co the tao src Message theo cac tuy chon da Setting" + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Message", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Comment:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Them comment vao noi dung src theo format da setting, comment se them vao tung dong code tuong ung." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Comment can add vao Input Comment." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Code da duoc tao." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Comment", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Resources:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tao noi dung Resources theo thiet ke, co the tao theo 2 mode Item va Message." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Name Resources theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Value Resources theo thiet ke." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Comment theo thiet ke neu co." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu y:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Co the tao Resources theo 2 mode C# va Angular." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Resources", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Format Comment:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Thay doi noi dung format cua comment co trong src code." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input code co chua comment." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Chon mode comment can format." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Format Comment", textDoc);
            textDoc += " More update to next time ............" + CONST.CHAR_NEW_LINE;

            txtDocument.Text += textDoc;
        }

        private void SetDataVer()
        {
            // Set data version update
            string textVer = "";
            textVer += "Ver 3.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang tao ViewModel theo thiet ke chi tiet cho 2 ngon ngu C# va Typescript." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chinh sua chuc nang Create Item thanh chuc nang Create HTML theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Get View Model, tao noi dung thong tin Logical va Physical theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Get Item Resource, lay noi dung Resource theo thong tin tai thiet ke." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Create Entity, tao noi dung file Entity theo thong tin tai thiet ke." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chinh sua chuc nang Common Create File Source, tao file source theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chinh sua chuc nang Common Create Resource, tao noi dung Item Resource va Message Resource theo thiet ke chi tiet." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += "Ver 2.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common, tao cac chuc nang common co the su dung cho nhieu du an." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Get Name Column, lay thong tin column table theo noi dung mo ta tai thiet ke." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Create JSON, thuc hien tao noi dung file json theo key paramater input." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Create Message, thuc hien tao noi dung code file Message." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Common Format Comment, format noi dung code theo format." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += "Ver 1.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Phien ban dau tien, tao tool ho tro cong viec du an cac thong tin common duoc setting va su dung linh dong cho tung giai doan khac nhau." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Get SQL in Src, thuc hien lay thong tin SQL tu noi dung code da duoc input" + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Get CONST, lay thong tin Logical va Physical theo noi dung da duoc setting." + CONST.CHAR_NEW_LINE;
            textVer += "    - Them moi chuc nang Create Model, tao noi dung model theo thong tin duoc mo ta tai thiet ke." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += " More update to next time ............" + CONST.CHAR_NEW_LINE;

            txtUpdateVer.Text = textVer;
        }
        #endregion

    }
}
