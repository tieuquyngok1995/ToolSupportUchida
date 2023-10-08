using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

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
            txtDocument.Text += "Hướng Dẫn Sử Dụng." + CONST.CHAR_NEW_LINE;

            string textDoc = string.Empty;
            textDoc += "Setting CONST" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Thêm nội dung setting Logical và Physical vào tool." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Tạo file data theo format: Key=Value." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Sử dụng chức năng Import Data bằng file đã tạo từ trước mode Const." + CONST.CHAR_NEW_LINE;
            textDoc += "Setting Format" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Thêm nội dung setting cho các chức năng sẽ sử dụng tại tool." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Tạo file data theo format: Type[--]Key[--]Value<br>." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Sử dụng chức năng Import Data bằng file đã tạo từ trước mode Format." + CONST.CHAR_NEW_LINE;
            textDoc += "Lưu Ý" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Có thể search thông tin đã được lưu, thêm mới chỉnh sửa theo các button chức năng đã setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Có thể chỉnh sửa trực tiếp thông tin tại từng row data trên table đã setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Có thể xóa trực tiếp thông tin tại từng row data trên table đã setting." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Setting", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chức năng Get SQL in Src" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Sử dụng để lấy nội dung SQL theo nội dung đã coding trong src, cho phép input nội dung parameter sử dụng trong src input." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Copy string SQL từ src paste vào ô Input SQL." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input SQL char(tên biến SQL sử dụng trong Src vd: sql, strSql ... )." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Nhấn button Add Param để lấy các parameter có trong src SQL hiển thị lên lưới Input Parameter." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input value Parameter vao luoi." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Nhấn button Convert SQL để lấy kết quả SQL sau khi xử lí." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu Ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tool chỉ hỗ trợ tách các câu SQL đơn giản, trường hợp nội dung cần xử lí dài thì nên tách ra xử lí từng phần." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Vui lòng kiểm tra lại nội dung sau khi xử lí tránh sai xót." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get SQL in Src", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chức năng Get Const" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Sử dụng get thông tin Logical hoặc Physical theo nội dung đã được setting tại phần setting." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name hoặc Physical Name cần tìm." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Nhấn button mũi tên trái hoặc phải để lấy thông tin, trường hợp k tồn tại thì sẽ trả về giá trị đã input." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu Ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Có thể input nhiều dòng để tìm kiếm." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Upper Case và Lower Case được áp dụng cho physical name." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Const", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chức năng Create Model" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Sử dụng để tạo Model theo nội dung đã được mô tả tại thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (tên tiếng nhật) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiết kế" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu Ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Đối với Typescript đang cho phép tạo src theo kiểu Typescript và Observables." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Đối với Typescript khi chọn Set Para cho phép chèn thêm ký tự vào Logic Name và Physical Name vào nội dung Src được tạo ra, cho phép setting vị trí thêm ký tự." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Đối với Typescript khi chọn checkbox Create Interface sẽ thực hiện tạo nội dung src Interface." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Đối với Java khi chọn checkbox Create Static sẽ thực hiện tạo nội dung src Static." + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chức năng Create View Model" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Sử dụng để tạo Src View Model theo nội dung đã được mô tả tại thiết kế, đang sử dụng cho 2 mode C# và Typescript." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (tên tiếng nhật) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiết kế" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input Name Item tên item sử dụng hiển thị trên màn hình được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Input Validation được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu Ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Giá trị tại Name Item và Validation phải bằng nhau." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Validation sẽ maping theo Name Item check Name Item bằng cách sử dụng common Get View Model." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tại mode Typescript cần input thêm tên Logical và Physical View Model theo thiết kế" + CONST.CHAR_NEW_LINE;
            textDoc += "Chức năng Create HTML" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Sử dụng để tạo nội dung sr HTML theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Logical Name (tên tiếng nhật) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Physical Came (id, code ...) theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Type theo thiết kế" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Input Name Item tên item sử dụng hiển thị trên màn hình được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B5: Input Validation được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu Ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Giá trị tại Name Item và Validation phải bằng nhau." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Validation sẽ maping theo Name Item check Name Item bằng cách sử dụng common Get View Model." + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tại mode Typescript cần input thêm tên Logical và Physical View Model theo thiết kế" + CONST.CHAR_NEW_LINE;
            textDoc += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create View Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "Chức năng Common" + CONST.CHAR_NEW_LINE;
            textDoc += "    + Khái Quát:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Các chức năng common được tạo để sử dụng ở nhiều trường hợp." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Common", textDoc);
            txtDocument.Text += textDoc;

            textDoc = "    + Get Name Column:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tìm kiếm thông tin column trong table theo tên đã được mô tả tại thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Data theo nội dung mô tả tại thiết kế table, lấy thông tin từ cột Table Logical Name cho tới tên tên Logic." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input danh sách table sẽ sử dụng." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Name Column", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Get View Model:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Lấy thông tin Logical và Physical của item trên màn hình theo thông tin Item màn hình, Item View Model và Functional Item theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Screen Item theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Logical và Physical Name theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Functional Item và Functional Property theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get View Model", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Get Item Resource:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Lấy thông tin Item Resource từ nội dung theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Name Item được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Control theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Resource theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Get Item Resource", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create JSON:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tạo nội dung JSON theo format đã được setting trước." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cách Dùng:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Case, Out trong trường hợp là mode Create Json." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Key Parameter, khởi tạo danh sách parameter để input value tại phần Input Value." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input value theo từng Key vao table." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Mode Create Object sẽ tạo Object thay vì chuỗi string json." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create JSON", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Entity:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tạo nội dung File Entity theo mô tả tại thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input noi dung thiet ke procedure vao cot SQL Procedure." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input thong tin table theo thiet ke vao cot SQL Table." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B4: Bam button Create Enity de thuc thi tao src." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Entity", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create File Source:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tạo file theo nội dung đã được mô tả theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input tên tiếng nhật của file sẽ được tạo theo thiết kế tại cột Logical Class Name." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input tên file tại cột Physical Class Name." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input đường dẫn file tại cột Path Source Name." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Lưu ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - T.h thiết kế không có mô tả tên Logical Name thì có thể để trống" + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create File Source", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Message:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tạo Message theo thông tin đã được cung cấp theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Code theo thiết kế vào Message Code." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Content theo thiết kế vao Message Content." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Có thể tạo src Message theo các tùy chọn đã Setting" + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Message", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Comment:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Thêm comment vào nội dung src theo format đã setting, comment sẽ thêm vào từng dòng code tương ứng." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Comment cần add vào Input Comment." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Code đã được tạo." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Comment", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Create Resources:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Tạo nội dung Resources theo thiết kế, có thể tạo theo 2 mode Item và Message." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input Name Resources theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Input Value Resources theo thiết kế." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B3: Input Comment theo thiết kế nếu có." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Luu ý:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Có thể tạo Resources theo 2 mode C# và Angular." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Create Resources", textDoc);
            txtDocument.Text += textDoc;

            textDoc += "    + Format Comment:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - Thay đổi nội dung format của comment có trong src code." + CONST.CHAR_NEW_LINE;
            textDoc += "    + Cach Dung:" + CONST.CHAR_NEW_LINE;
            textDoc += "          - B1: Input code có chứa comment." + CONST.CHAR_NEW_LINE;
            textDoc += "          - B2: Chọn mode comment cần format." + CONST.CHAR_NEW_LINE;
            textDoc += "*************************************************************" + CONST.CHAR_NEW_LINE;

            dicDoc.Add("Format Comment", textDoc);
            textDoc += " More update to next time ............" + CONST.CHAR_NEW_LINE;
            txtDocument.Text += textDoc;
        }

        private void SetDataVer()
        {
            // Set data version update
            string textVer = "";
            textVer += "Ver3.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng tạo ViewModel theo thiết kế chi tiết cho 2 ngôn ngữ C# và Typescript." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chỉnh sửa chức năng Create Item thành chức năng Create HTML theo thiết kế chi tiết." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Get View Model, tạo nội dung thông tin Logical và Physical theo thiết kế chi tiết." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Get Item Resource, lấy nội dung Resource theo thông tin tại thiết kế." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Create Entity, tạo nội dung file Entity theo thông tin tại thiết kế." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chỉnh sửa chức năng Common Create File Source, tạo file source theo thiết kế chi tiết." + CONST.CHAR_NEW_LINE;
            textVer += "    - Chỉnh sửa chức năng Common Create Resource, tạo nội dung Item Resource và Message Resource theo thiết kế chi tiết." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += "Ver2.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common, tạo các chức năng common có thể sử dụng cho nhiều dự án." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Get Name Column, lấy thông tin column table theo nội dung mô tả tại thiết kế." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Create JSON, thực hiện tạo nội dung file json theo key paramater input." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Create Message, thực hiện tạo nội dung code file Message." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Common Format Comment, format nội dung code theo format." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += "Ver1.0" + CONST.CHAR_NEW_LINE;
            textVer += "    - Phiên bản đầu tiên, tạo tool hỗ trợ công việc dự án các thông tin common được setting và sử dụng linh động cho từng giai đoạn khác nhau." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Get SQL in Src, thực hiện lấy thông tin SQL từ nội dung code đã được input" + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Get CONST, lấy thông tin Logical và Physical theo nội dung đã được setting." + CONST.CHAR_NEW_LINE;
            textVer += "    - Thêm mới chức năng Create Model, tạo nội dung model theo thông tin được mô tả tại thiết kế." + CONST.CHAR_NEW_LINE;
            textVer += "----------------------------------------------------------------------------" + CONST.CHAR_NEW_LINE;
            textVer += " More update to next time ............" + CONST.CHAR_NEW_LINE;

            txtUpdateVer.Text = textVer;
        }
        #endregion

    }
}
