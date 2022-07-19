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
            StringBuilder lstTextVer = new StringBuilder();
            lstTextVer.Append("Ver1.0").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Phiên bản đầu tiên cho phép setting thông tin sử dụng cho typescript và c#.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Convert Databse từ hệ thống trước đó.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Convert Sekkei hệ thống chạy tương tự hệ thống của khách hàng.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Convert Model tạo model theo thông tin input của người dùng.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Create Addapter theo thông tin config.").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("------------------------------------------------------------------").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("Ver2.0").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Common nơi có các chức năng có thể sử dụng ở nhiều dự án.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Create Json giúp rút ngắn thời gian tạo data json.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Create Message tạo message theo format.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Format Comment giúp chỉnh src của các comment sau nội dung src.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Create Html theo thiết kế chi tiết.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng Create Item Html theo format của kh.").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("------------------------------------------------------------------").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("Ver2.1").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Thêm mới chức năng chọn ngôn ngữ java.").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Chỉnh sửa chức năng Convert Sekkei thành Check CONST thêm khả năng search data const của data đã input .").Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("    - Chỉnh sửa  Convert Model cho phép tạo Model theo ngôn ngữ java.").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append("------------------------------------------------------------------").Append(CONST.CHAR_NEW_LINE).Append(CONST.CHAR_NEW_LINE);
            lstTextVer.Append(" More update to next time ............").Append(CONST.CHAR_NEW_LINE);

            lstTextUpdateVer.Text = lstTextVer.ToString();
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
