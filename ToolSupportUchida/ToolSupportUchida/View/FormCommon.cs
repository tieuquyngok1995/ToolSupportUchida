using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;
using static System.Windows.Forms.TabControl;

namespace ToolSupportUchida.View
{
    public partial class FormCommon : Form
    {
        private string[] lstKey;
        private string[] stringSeparators;

        private string[] lstMessCode;
        private string[] lstMessContent;

        private string[] lstFormatCode;

        #region Load Form
        public FormCommon()
        {
            InitializeComponent();

            stringSeparators = new string[] { CONST.STRING_ADD_LINE };
        }

        private void FormCheckDataModel_Load(object sender, EventArgs e)
        {
            txtCase.Focus();

            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control tabControl in tabControlCommon.Controls)
            {
                TabPage tabPage = (TabPage)tabControl;
                foreach (Control pageControl in tabPage.Controls)
                {
                    if (pageControl.GetType() == typeof(Button))
                    {
                        Button btn = (Button)pageControl;
                        btn.BackColor = ThemeColor.PrimaryColor;
                        btn.ForeColor = Color.White;
                        btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                    }
                }

            }
        }

        private void tabControlCommon_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = tabControlCommon.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = tabControlCommon.GetTabRect(e.Index);
            if (e.State == DrawItemState.Selected)
            {
                Brush brush = new SolidBrush(ThemeColor.PrimaryColor);
                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.White);
                g.FillRectangle(brush, e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 2, e.Bounds.Height);
            }
            else
            {
                _textBrush = new SolidBrush(e.ForeColor);
                e.DrawBackground();
            }

            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        private void tabControlCommon_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlCommon.SelectedIndex)
            {
                case 0:
                    txtCase.Focus();
                    break;
                case 1:
                    txtMessCode.Focus();
                    break;
                case 2:
                    txtFormatCode.Focus();
                    break;
                case 3:
                    txtID.Focus();
                    break;
            }
        }
        #endregion

        #region Tab Create Json
        private void txtInputKey_TextChanged(object sender, EventArgs e)
        {
            lstKey = txtInputKey.Text.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (string.IsNullOrEmpty(txtInputKey.Text) && lstKey.Length > 0)
            {
                displayItem(false);
            }
            else
            {
                gridInputParam.Rows.Clear();
                gridInputParam.Refresh();

                int index = 1;
                foreach (string item in lstKey)
                {
                    gridInputParam.Rows.Add(index, item, string.Empty);
                    index++;
                }

                displayItem(true);
            }
        }

        private void txtInputKey_Leave(object sender, EventArgs e)
        {
            txtInputKey.Text = Regex.Replace(txtInputKey.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
        }

        private void gridInputParam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridInputParam.IsCurrentCellDirty)
            {
                gridInputParam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string tab = string.Empty;
            string template = string.Empty;
            string nextLine = string.Empty;

            bool isList = false;
            bool isLast = false;

            int indexTab = 0;
            int numTab = 0;
            int index = 0;

            if (rdbCreateJson.Checked)
            {
                result = "{" + CONST.STRING_ADD_LINE;
                tab = CUtils.CreateTab(ref indexTab);
                template = CUtils.CreTmlCommonCaseOut(tab);
                result = result + string.Format(template, txtCase.Text.Trim(), txtOut.Text.Trim());
                result = result + "{" + CONST.STRING_ADD_LINE;
            }
            else if (rdbCreateObj.Checked)
            {
                result = "[" + CONST.STRING_ADD_LINE;
                tab = CUtils.CreateTab(ref indexTab);
                result = result + tab + "{" + CONST.STRING_ADD_LINE;
            }

            tab = CUtils.CreateTab(ref indexTab);

            foreach (DataGridViewRow row in gridInputParam.Rows)
            {
                string key = row.Cells[1].Value.ToString().Trim();
                string value = row.Cells[2].Value.ToString().Trim();

                if (index <= lstKey.Length - 2)
                {
                    numTab = CUtils.GetNumTab(lstKey[index + 1]);
                    if ((numTab + 2) < indexTab)
                    {
                        isLast = true;
                    }

                }
                else if (index == lstKey.Length - 1)
                {
                    isLast = true;
                }

                if (key.Contains(CONST.STRING_LIST_EN))
                {
                    template = CUtils.CreTmlCommonObj(tab);
                    result = result + string.Format(template, key) + "[{" + CONST.STRING_ADD_LINE;
                    isList = true;
                    tab = CUtils.CreateTab(ref indexTab);
                }
                else if (numTab > (indexTab - 2))
                {
                    template = CUtils.CreTmlCommonObj(tab);
                    result = result + string.Format(template, key) + "{" + CONST.STRING_ADD_LINE;
                    tab = CUtils.CreateTab(ref indexTab);
                }
                else if (value.Contains(CONST.STRING_COMMA))
                {
                    string[] lstValue = value.Split(CONST.CHAR_COMMA);
                    lstValue = lstValue.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                    template = CUtils.CreTmlCommonAddArr(tab, isLast);
                    result = result + string.Format(template, key, addComman(lstValue));
                }
                else
                {
                    template = CUtils.CreTmlCommonAddData(tab, isLast);
                    result = result + string.Format(template, key, value);
                }

                if (isLast)
                {
                    if (isList)
                    {
                        tab = CUtils.RemoveTab(ref indexTab);
                        result = result + tab + "}]" + CONST.STRING_ADD_LINE;
                        isList = false;
                    }
                    else
                    {
                        tab = CUtils.RemoveTab(ref indexTab);
                        result = result + tab + "}" + CONST.STRING_ADD_LINE;
                    }
                }

                index++;
            }

            while (indexTab > 0)
            {
                tab = CUtils.RemoveTab(ref indexTab);
                if (indexTab == 0 && rdbCreateObj.Checked)
                {
                    result = result + tab + "]" + CONST.STRING_ADD_LINE;
                }
                else {
                    result = result + tab + "}" + CONST.STRING_ADD_LINE;
                }
            }

            txtResult.Text = result;

            if (result.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtResult.Text);
            lblResult.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputKey.Text = string.Empty;
            txtResult.Text = string.Empty;

            gridInputParam.Rows.Clear();
            gridInputParam.Refresh();

            lblResult.Visible = false;
            displayItem(false);
        }
        #endregion

        #region Tab Create Message
        private void txtMessCode_TextChanged(object sender, EventArgs e)
        {
            lstMessCode = txtMessCode.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstMessCode.Length > 0)
            {
                lblNumLMessCode.Visible = true;
                lblNumLMessCode.Text = string.Concat(CONST.TEXT_LINE_NUM, lstMessCode.Length);
            }
            else
            {
                lblNumLMessCode.Visible = false;
            }

            if (lstMessCode != null && lstMessContent != null && lstMessCode.Length == lstMessContent.Length)
            {
                btnCreateMess.Enabled = true;
            }
            else
            {
                btnCreateMess.Enabled = false;
            }
        }

        private void txtMessContent_TextChanged(object sender, EventArgs e)
        {
            lstMessContent = txtMessContent.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstMessContent.Length > 0)
            {
                lblNumMessContent.Visible = true;
                lblNumMessContent.Text = string.Concat(CONST.TEXT_LINE_NUM, lstMessContent.Length);
            }
            else
            {
                lblNumMessContent.Visible = false;
            }

            if (lstMessCode != null && lstMessContent != null && lstMessCode.Length == lstMessContent.Length)
            {
                btnCreateMess.Enabled = true;
            }
            else
            {
                btnCreateMess.Enabled = false;
            }
        }

        private void btnCreateMess_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string template = string.Empty;

            for (int i = 0; i < lstMessCode.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (i + 1 < lstMessContent.Length && !string.IsNullOrEmpty(lstMessContent[i + 1]) && lstMessContent[i + 1] != "\"\"")
                    {
                        template = CUtils.CreTmlMess(CONST.STRING_CREATE_MESS_EQ);
                        result += string.Format(template, lstMessCode[i],
                            lstMessContent[i].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty),
                            lstMessContent[i + 1].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty));
                    }
                    else
                    {
                        template = CUtils.CreTmlMess(CONST.STRING_CREATE_MESS);
                        result += string.Format(template, lstMessCode[i], lstMessContent[i].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty));
                    }
                }
            }

            txtMessResult.Text = result;

            if (result.Length > 0)
            {
                btnMessCopy.Enabled = true;
            }
        }

        private void btnMessCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMessResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtMessResult.Text);
            lblMessResult.Visible = true;
        }

        private void btnMessClear_Click(object sender, EventArgs e)
        {
            txtMessCode.Text = string.Empty;
            txtMessContent.Text = string.Empty;

            lblMessResult.Visible = false;
        }
        #endregion

        #region Tab Format Code
        private void txtFormatCode_TextChanged(object sender, EventArgs e)
        {
            lstFormatCode = txtFormatCode.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstFormatCode.Length > 0)
            {
                btnFormatCode.Enabled = true;
            }
            else
            {
                btnFormatCode.Enabled = false;
            }
        }

        private void btnFormatCode_Click(object sender, EventArgs e)
        {
            int lengthText = 0;
            int maxLengthRow = 0;
            int lengthAppend = -1;

            string result = string.Empty;
            string tmpLine = string.Empty;


            foreach (string line in lstFormatCode)
            {
                tmpLine = line.Trim();

                if (tmpLine.Contains(CONST.STRING_APPEND))
                {
                    if (tmpLine.Substring(0, 1).Equals(CONST.STRING_DOT))
                    {
                        tmpLine = CUtils.CreateSpace(lengthAppend) + tmpLine;
                    }
                    else
                    {
                        lengthAppend = tmpLine.IndexOf(CONST.STRING_DOT);
                    }

                    lengthText = tmpLine.LastIndexOf("/");
                }
                else
                {
                    lengthText = tmpLine.LastIndexOf("/") + 1;
                }


                if (lengthText > maxLengthRow)
                {
                    maxLengthRow = lengthText;
                }

                result += tmpLine + CONST.STRING_ADD_LINE;
            }

            txtFormatResult.Text = CUtils.FormatCode(result, maxLengthRow);
            txtFormatResult.Text = Regex.Replace(txtFormatResult.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);

            if (txtFormatResult.Text.LastIndexOf("\r\n") == (txtFormatResult.Text.Length - 2))
            {
                txtFormatResult.Text = txtFormatResult.Text.Substring(0, txtFormatResult.Text.Length - 2);
            }

            if (txtFormatResult.Text.Length > 0)
            {
                btnFormatCopy.Enabled = true;
            }
        }

        private void btnFormatCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFormatResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtFormatResult.Text);
            lblFormatResult.Visible = true;
        }

        private void btnFormatClear_Click(object sender, EventArgs e)
        {
            txtFormatCode.Text = string.Empty;
            txtFormatResult.Text = string.Empty;

            lblFormatResult.Visible = false;
        }
        #endregion

        #region Tab Create HTML
        private void txtID_TextChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void txtRow_TextChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void txtRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void chkMain_CheckedChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void chkSub_CheckedChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void chkPara_CheckedChanged(object sender, EventArgs e)
        {
            createHTML();
        }

        private void createHTML()
        {
            if ((!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtRow.Text)) &&
                chkMain.Checked || chkSub.Checked)
            {
                createBundle();

                createController();

                createInit();

                if (chkSub.Checked)
                {
                    createDialog();
                }

                createCshtml();
            }
            else
            {
                txtBundle.Text = string.Empty;
                txtController.Text = string.Empty;
                txtInit.Text = string.Empty;
                txtDialog.Text = string.Empty;
                txtCshtml.Text = string.Empty;
            }
        }

        private void createBundle()
        {
            string id = string.Empty;
            string name = txtID.Text.ToUpper();
            StringBuilder sb = new StringBuilder();

            if (name.Contains(CONST.STRING_FRS))
            {
                id = name.Substring(0, name.IndexOf(CONST.STRING_FRS));
            }
            else if (name.Contains(CONST.STRING_FRM))
            {
                id = name.Substring(0, name.IndexOf(CONST.STRING_FRM));
            }
            else if (name.Contains(CONST.STRING_HLP))
            {
                id = name.Substring(0, name.IndexOf(CONST.STRING_HLP));
            }
            else if (name.Contains(CONST.STRING_CALL))
            {
                id = name.Substring(0, name.IndexOf(CONST.STRING_CALL));
            }

            sb.Append("//-------------------------------------------------------------\r\n");
            sb.Append("// {1}\r\n");
            sb.Append("//-------------------------------------------------------------\r\n");
            sb.Append("bundles.Add(new StyleBundle(\"/Content/{0}/{1}\").Include(\r\n");
            sb.Append("    \"/Content/app/{0}/{1}/{2}.index.css\"));\r\n");
            sb.Append("bundles.Add(new ScriptBundle(\"/bundles/{0}/{1}\").Include(\r\n");
            sb.Append("    \"/Scripts/app/{0}/{1}/{2}.init.js\",\r\n");
            sb.Append("    \"/Scripts/app/{0}/{1}/{2}.viewmodel.js\"\r\n");

            txtBundle.Text = string.Format(sb.ToString(), id, name, name.ToLower());

            if (!string.IsNullOrEmpty(txtBundle.Text))
            {
                btnCopyBundle.Enabled = true;
            }
            else
            {
                btnCopyBundle.Enabled = false;
            }
        }

        private void btnCopyBundle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBundle.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtBundle.Text);
        }

        private void createController()
        {
            string name = txtID.Text.ToUpper();
            StringBuilder sb = new StringBuilder();

            sb.Append("// {0}：{1}画面\r\n");
            if (chkMain.Checked && !chkSub.Checked && !chkPara.Checked)
            {
                sb.Append("public ActionResult {0}()");
            }
            else if (chkMain.Checked && chkSub.Checked && !chkPara.Checked)
            {
                sb.Append("public ActionResult {0}(string dialog)\r\n");
                sb.Append("    if (dialog == \"1\")\r\n");
                sb.Append("    {{\r\n");
                sb.Append("        // サブ画面で開くために \"PartialView()\"を使用\r\n");
                sb.Append("        return PartialView();\r\n");
                sb.Append("    }}\r\n");
            }
            else if (chkMain.Checked && !chkSub.Checked && chkPara.Checked)
            {
                sb.Append("public ActionResult {0}(string para)\r\n");
                sb.Append("    ViewBag.Para = para;\r\n");
            }
            else if (chkMain.Checked && chkSub.Checked && chkPara.Checked)
            {
                sb.Append("public ActionResult {0}(string dialog, string para)\r\n");
                sb.Append("    ViewBag.Para = para;\r\n");
                sb.Append("\r\n");
                sb.Append("    if (dialog == \"1\")\r\n");
                sb.Append("    {{\r\n");
                sb.Append("        // サブ画面で開くために \"PartialView()\"を使用\r\n");
                sb.Append("        return PartialView();\r\n");
                sb.Append("    }}\r\n");
            }
            else
            {
                sb.Append("public ActionResult {0}()");
            }

            sb.Append("\r\n");
            sb.Append("    // 主要画面で開くために \"View()\"を使用\r\n");
            sb.Append("    return View();\r\n");
            sb.Append("}}\r\n");

            txtController.Text = string.Format(sb.ToString(), name, txtName.Text);

            if (!string.IsNullOrEmpty(txtController.Text))
            {
                btnCopyController.Enabled = true;
            }
            else
            {
                btnCopyController.Enabled = false;
            }
        }

        private void btnCopyController_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtController.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtController.Text);
        }

        private void createInit()
        {
            string id = txtID.Text.ToLower();
            string idUpCase = CUtils.FirstCharToUpperCase(id);
            string date = DateTime.Now.Year +"/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            StringBuilder sb = new StringBuilder();

            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("// ファイル名\r\n");
            sb.Append("// {0}.init.ts\r\n");
            sb.Append("// 概要\r\n");
            sb.Append("// \r\n");
            sb.Append("// 著作権\r\n");
            sb.Append("// Copyright © UCHIDA YOKO CO., LTD. All rights reserved.\r\n");
            sb.Append("// 作成者\r\n");
            sb.Append("// フジネットシステムズ株式会社\r\n");
            sb.Append("// 作成日\r\n");
            sb.Append("// {1}\r\n");
            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("\r\n");
            sb.Append("$(() => {{\r\n");
            sb.Append("    const viewmodel = new {2}ViewModel();\r\n");
            sb.Append("    Utils.applyBindings(viewmodel, $(\"#{0}Main\"));\r\n");

            if (chkPara.Checked)
            {
                sb.Append("    const para = $(\"#{0}Main > input.para\").val();\r\n");
                sb.Append("    viewmodel.init({{\r\n");
                sb.Append("        initParam: para\r\n");
                sb.Append("    }});\r\n");
            }
            else
            {
                sb.Append("    viewmodel.init();\r\n");
            }

            sb.Append("}});\r\n");

            txtInit.Text = string.Format(sb.ToString(), id, date, idUpCase);

            if (!string.IsNullOrEmpty(txtInit.Text))
            {
                btnCopyInit.Enabled = true;
            }
            else
            {
                btnCopyInit.Enabled = false;
            }
        }

        private void btnCopyInit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInit.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtInit.Text);
        }

        private void createDialog()
        {
            string id = txtID.Text.ToUpper();
            string firId = string.Empty;
            string idUpCase = CUtils.FirstCharToUpperCase(id.ToLower());
            string date = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            StringBuilder sb = new StringBuilder();

            if (id.Contains(CONST.STRING_FRS))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_FRS));
            }
            else if (id.Contains(CONST.STRING_FRM))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_FRM));
            }
            else if (id.Contains(CONST.STRING_HLP))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_HLP));
            }
            else if (id.Contains(CONST.STRING_CALL))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_CALL));
            }

            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("// ファイル名\r\n");
            sb.Append("// {0}.dialog.ts\r\n");
            sb.Append("// 概要\r\n");
            sb.Append("// \r\n");
            sb.Append("// 著作権\r\n");
            sb.Append("// Copyright © UCHIDA YOKO CO., LTD. All rights reserved.\r\n");
            sb.Append("// 作成者\r\n");
            sb.Append("// フジネットシステムズ株式会社\r\n");
            sb.Append("// 作成日\r\n");
            sb.Append("// {1}\r\n");
            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("\r\n");
            sb.Append("class {2}Dialog extends BaseSubDialog {{\r\n");
            sb.Append("    // 呼び出すサブ画面のアドレスの設定などを行う。\r\n");
            sb.Append("    public constructor() {{\r\n");
            sb.Append("        super(Utils.toFullAddress(\"{3}/{4}\"), {{\r\n");
            sb.Append("            width:  \"90%\",\r\n");
            sb.Append("            height: \"90%\",\r\n");
            sb.Append("            lowerPartsId: \"{0}BottomBtnArea\",\r\n");
            sb.Append("        }});\r\n");
            sb.Append("    }}\r\n");
            sb.Append("\r\n");
            sb.Append("    // ダイアログ内の画面にバインディングするビューモデルの作成メソッド\r\n");
            sb.Append("    protected createViewModel(): BaseViewModel {{\r\n");
            sb.Append("        return new {2}ViewModel();\r\n");
            sb.Append("    }}\r\n");
            sb.Append("}}\r\n");

            txtDialog.Text = string.Format(sb.ToString(), id.ToLower(), date, idUpCase, firId, id.ToUpper()); ;

            if (!string.IsNullOrEmpty(txtDialog.Text))
            {
                btnCopyDialog.Enabled = true;
            }
            else
            {
                btnCopyDialog.Enabled = false;
            }
        }

        private void btnCopyDialog_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDialog.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtDialog.Text);
        }

        private void createCshtml()
        {
            string id = txtID.Text.ToUpper();
            string firId = string.Empty;
            string name = txtName.Text;
            StringBuilder sb = new StringBuilder();

            if (id.Contains(CONST.STRING_FRS))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_FRS));
            }
            else if (id.Contains(CONST.STRING_FRM))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_FRM));
            }
            else if (id.Contains(CONST.STRING_HLP))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_HLP));
            }
            else if (id.Contains(CONST.STRING_CALL))
            {
                firId = id.Substring(0, id.IndexOf(CONST.STRING_CALL));
            }

            sb.Append("@{{\r\n");
            sb.Append("    var titleMap = new Dictionary<string, string>();\r\n");
            sb.Append("    titleMap[\"default\"] = \"{0}\";\r\n");
            sb.Append("    if (ViewBag.Para is string str && titleMap.TryGetValue(str, out string title))\r\n");
            sb.Append("    {{\r\n");
            sb.Append("        ViewBag.Title = title;\r\n");
            sb.Append("    }}\r\n");
            sb.Append("    else\r\n");
            sb.Append("    {{\r\n");
            sb.Append("        ViewBag.Title = titleMap[\"default\"];\r\n");
            sb.Append("    }}\r\n");
            sb.Append("    ViewBag.TitleMap = titleMap;\r\n");
            sb.Append("\r\n");

            if (chkSub.Checked)
            {
                sb.Append("    if (ViewBag.IsPartialView == true)\r\n");
                sb.Append("    {{\r\n");
                sb.Append("        // サブ画面の場合\r\n");
                sb.Append("        Layout = \"~/Views/Shared/_SubLayout.cshtml\";\r\n");
                sb.Append("    }}\r\n");
            }

            sb.Append("    var literalCtrl = WWWCore.Literal.LiteralManager.GetLiteral(\"{1}\");\r\n");
            sb.Append("    var spreadLiteral = literalCtrl.GetSpreadLiterals(\"S1\");\r\n");
            sb.Append("}}\r\n");
            sb.Append("\r\n");
            sb.Append("@section scripts {{\r\n");
            sb.Append("    @* メイン画面のスクリプトの定義は@section scripts内に記述する *@\r\n");
            sb.Append("    @Scripts.Render(\"~/Message/Script/{1}\")\r\n");
            sb.Append("    @Scripts.Render(\"~/bundles/jquery-ui\")\r\n");
            sb.Append("    @Scripts.Render(\"~/bundles/grid\")\r\n");
            sb.Append("    @Scripts.Render(\"~/bundles/{2}/{1}\")\r\n");
            sb.Append("}}\r\n");
            sb.Append("\r\n");
            sb.Append("@section css {{\r\n");
            sb.Append("    @* メイン画面のスクリプトの定義は@section css内に記述する *@\r\n");
            sb.Append("    @Styles.Render(\"~/Content/themes/base/jquery-ui\")\r\n");
            sb.Append("    @Styles.Render(\"~/Content/grid-2.4.1/css\")\r\n");
            sb.Append("    @Styles.Render(\"~/Content/{2}/{1}\")\r\n");
            sb.Append("}}\r\n");
            sb.Append("\r\n");
            sb.Append("<div id=\"{3}Main\" class=\"contentMain {3}-style\">\r\n");
            sb.Append("    <input class=\"para\" type=\"hidden\" value=\"@ViewBag.Para\"/>\r\n");
            sb.Append("    @Html.Hidden(\"spreadLiteral\", @Newtonsoft.Json.JsonConvert.SerializeObject(spreadLiteral))\r\n");
            sb.Append("    <!-- コンテンツエリア -->\r\n");
            sb.Append("        <div class=\"card main\">\r\n");
            sb.Append("            <div class=\"card-body\">\r\n");

            for (int i = 0; i < int.Parse(txtRow.Text); i++)
            {
                sb.Append("                <div class=\"row align-items-center my-2\">\r\n");
                sb.Append("                    <div class=\"col\">\r\n");
                sb.Append("                    </div>\r\n");
                sb.Append("                </div>\r\n");
            }

            sb.Append("            </div>\r\n");
            sb.Append("        </div>\r\n");
            sb.Append("\r\n");
            sb.Append("        <div class=\"contentFooter {3}BottomBtnArea\">\r\n");
            sb.Append("            <div class=\"row align-items-center\">\r\n");
            sb.Append("                <div class=\"col\">\r\n");
            sb.Append("                </div>\r\n");
            sb.Append("            </div>\r\n");
            sb.Append("        </div>\r\n");
            sb.Append("    </div>\r\n");
            sb.Append("</div>\r\n");

            txtCshtml.Text = string.Format(sb.ToString(), name, id, firId, id.ToLower()); ;

            if (!string.IsNullOrEmpty(txtCshtml.Text))
            {
                btnCopyCSHMTML.Enabled = true;
            }
            else
            {
                btnCopyCSHMTML.Enabled = false;
            }
        }

        private void btnCopyCSHMTML_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCshtml.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCshtml.Text);
        }

        #endregion

        #region Method
        private string addComman(string[] lst)
        {
            string result = string.Empty;
            int i = 0;
            foreach (string item in lst)
            {
                if (i == 0)
                {
                    result += "\"" + item + "\", ";
                }
                else if (i <= lst.Length - 2)
                {
                    result += "\"" + item + "\", ";
                }
                else
                {
                    result += "\"" + item + "\"";
                }
                i++;
            }
            return result;
        }

        private void displayItem(bool val)
        {
            btnCreate.Enabled = val;
            btnClear.Enabled = val;
            btnCopy.Enabled = val;

            gridInputParam.Visible = val;
        }
        #endregion
    }
}
