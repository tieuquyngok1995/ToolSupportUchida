using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

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

                    if (pageControl.GetType() == typeof(GroupBox))
                    {
                        GroupBox grbC = (GroupBox)pageControl;

                        foreach (Control grbControl in grbC.Controls)
                        {
                            if (grbControl.GetType() == typeof(Button))
                            {
                                Button btn = (Button)grbControl;
                                btn.BackColor = ThemeColor.PrimaryColor;
                                btn.ForeColor = Color.White;
                                btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                            }
                        }
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
                    cbMessDone.SelectedIndex = 0;
                    cbMessCancel.SelectedIndex = 0;
                    txtMessCode.Focus();
                    break;
                case 2:
                    txtFormatCode.Focus();
                    break;
                case 3:
                    txtID.Focus();
                    break;
                case 4:
                    cbItem.SelectedIndex = 0;
                    cbItem.Focus();
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
                else
                {
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
        private void rdMess_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMess.Checked)
            {
                this.grbMessText.Visible = true;
                this.grbMessTitle.Visible = true;
                this.grbMessTextI.Visible = false;

                this.rdMessErr.Text = "エラー情報";
                this.rdMessNoti.Text = "通知";
                this.rdMessVeri.Visible = true;
                this.chkMessShowC.Text = "Show Cancel";

                this.lblMessDone.Visible = true;
                this.cbMessDone.Visible = true;
            }
        }

        private void rdMessDisp_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMessDisp.Checked)
            {
                this.grbMessText.Visible = false;
                this.grbMessTitle.Visible = false;
                this.grbMessTextI.Visible = true;

                this.lblMessCode.Text = "Msg Code";
                this.txtMessMsgCode.Text = "0001";
                this.lblMessDesc.Text = "Msg Desc";
                this.txtMessDesc.Text = "UCHIDA";
                this.lblMessDescH.Text = "Msg DescH";
                this.lblMessQuestion.Text = "Question";
                this.lblMessType.Text = "Type";
                this.lblMessQuestion.Visible = true;
                this.lblMessType.Visible = true;
            }
        }

        private void rdbMessF_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMessF.Checked)
            {
                this.grbMessText.Visible = true;
                this.grbMessTitle.Visible = true;
                this.grbMessTextI.Visible = false;

                this.rdMessErr.Text = "F Core";
                this.rdMessNoti.Text = "F Civion";
                this.rdMessVeri.Visible = false;
                this.chkMessShowC.Text = "Error M";

                this.lblMessDone.Visible = false;
                this.cbMessDone.Visible = false;
            }
        }

        private void rdMessBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMessBox.Checked)
            {
                this.grbMessText.Visible = false;
                this.grbMessTitle.Visible = false;
                this.grbMessTextI.Visible = true;

                this.lblMessCode.Text = "Message";
                this.txtMessMsgCode.Text = string.Empty;
                this.lblMessDesc.Text = "Type";
                this.txtMessDesc.Text = string.Empty;
                this.lblMessDescH.Text = "Title";
                this.lblMessQuestion.Visible = false;
                this.txtMessQues.Visible = false;
                this.lblMessType.Visible = false;
                this.txtMessType.Visible = false;
            }
        }

        private void chkMessShowC_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMessShowC.Checked && rdbMess.Checked)
            {
                lblMessCancel.Visible = true;
                cbMessCancel.Visible = true;
            }
            else
            {
                lblMessCancel.Visible = false;
                cbMessCancel.Visible = false;
            }
        }

        private void txtMessMsg_TextChanged(object sender, EventArgs e)
        {
            string input = txtMessMsg.Text.Trim();
            string inputN = string.Empty;
            string[] arrI;

            if (!string.IsNullOrEmpty(input))
            {
                txtMessCode.Text = string.Empty;
                txtMessDesc.Text = string.Empty;
            }

            if (rdbMessDisp.Checked)
            {
                if (input.Contains(CONST.CHAR_O_BRACKETS))
                {
                    if (input.Contains(CONST.CHAR_C_BRACKETS))
                    {
                        inputN = input.Substring(input.IndexOf(CONST.CHAR_O_BRACKETS) + 1, input.IndexOf(CONST.CHAR_C_BRACKETS) - input.IndexOf(CONST.CHAR_O_BRACKETS));
                    }
                    else
                    {
                        inputN = input.Substring(input.IndexOf(CONST.CHAR_O_BRACKETS) + 1);
                    }
                }

                arrI = inputN.Split(CONST.CHAR_COMMA);

                if (arrI.Length > 0)
                {
                    txtMessMsgCode.Text = arrI[0];
                }

                if (arrI.Length > 1)
                {
                    txtMessDesc.Text = arrI[1];
                }

                if (arrI.Length > 2)
                {
                    txtMessDescH.Text = arrI[2];
                }

                if (arrI.Length > 3)
                {
                    txtMessQues.Text = arrI[3];
                }

                if (arrI.Length > 4)
                {
                    txtMessType.Text = arrI[4];
                }
            }
            else if (rdbMessBox.Checked)
            {
                if (input.Length > 6 && input.Substring(0,6).ToUpper() == CONST.STRING_MSGBOX)
                {
                    inputN = input.Substring(7).Trim(); ;
                }

                arrI = inputN.Split(CONST.CHAR_COMMA);

                if (arrI.Length > 0)
                {
                    txtMessMsgCode.Text = arrI[0].Replace("\"", "");
                }

                if (arrI.Length > 1)
                {
                    txtMessDesc.Text = arrI[1];
                }

                if (arrI.Length > 2)
                {
                    txtMessDescH.Text = arrI[2];
                }
            }
        }

        private void txtMessType_KeyPress(object sender, KeyPressEventArgs e)
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

        private void btnMessCreate_Click(object sender, EventArgs e)
        {
            string result = string.Empty;
            string doneText = string.Empty;
            string cancelText = string.Empty;

            StringBuilder sb = new StringBuilder();

            if (chkMessStatus.Checked)
            {
                sb.Append("const {{ status }} = await this._messageDialog.open({{\r\n");
            }
            else
            {
                sb.Append("await this._messageDialog.open({{\r\n");
            }

            if (rdbMess.Checked)
            {
                if (rdMessErr.Checked)
                {
                    sb.Append("    title: \"エラー情報\",\r\n");
                    sb.Append("    message: Utils.createErrorMessage(Utils.getMessage(\"{0}\", \"{1}\")),\r\n");
                }
                else if (rdMessNoti.Checked)
                {
                    sb.Append("    title: \"通知\",\r\n");
                    sb.Append("    message: Utils.createMessage(Utils.getMessage(\"{0}\", \"{1}\")),\r\n");
                }
                else if (rdMessVeri.Checked)
                {
                    sb.Append("    title: \"確認\",\r\n");
                    sb.Append("    message: Utils.createMessage(Utils.getMessage(\"{0}\", \"{1}\")),\r\n");
                }

                sb.Append("    showDone: true,\r\n");
                sb.Append("    doneText: \"{2}\",\r\n");
                doneText = cbMessDone.Text;

                if (chkMessShowC.Checked)
                {
                    cancelText = cbMessCancel.Text;
                    sb.Append("    showCancel: true,\r\n");
                    sb.Append("    cancelText: \"{3}\",\r\n");
                    sb.Append("}});\r\n");

                    result = string.Format(sb.ToString(), txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), doneText, cancelText);
                }
                else
                {
                    sb.Append("}});\r\n");
                    result = string.Format(sb.ToString(), txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), doneText);
                }
            }
            else if (rdbMessF.Checked)
            {
                if (rdMessErr.Checked)
                {
                    if (chkMessShowC.Checked)
                    {
                        sb.Append("    title: \"確認\",\r\n");
                        sb.Append("    // 確認メッセージ(エラー区分＝\"M\"など)の場合\r\n");
                        sb.Append("    message: Utils.createErrorMessage(response.errMessage, response.errMessageHosoku),\r\n");
                    }
                    else
                    {
                        sb.Append("    title: \"エラー情報\",\r\n");
                        sb.Append("    // エラーメッセージの場合\r\n");
                        sb.Append("    message: Utils.createErrorMessage(response.errMessage, response.errMessageHosoku, response.errMessageNo),\r\n");
                    }
                }
                else if (rdMessNoti.Checked)
                {
                    if (chkMessShowC.Checked)
                    {
                        sb.Append("    title: \"確認\",\r\n");
                        sb.Append("    // 確認メッセージ(エラー区分＝\"M\"など)の場合\r\n");
                        sb.Append("    message: Utils.createErrorMessage(response.errMessage, null),\r\n");
                    }
                    else
                    {
                        sb.Append("    title: \"エラー情報\",\r\n");
                        sb.Append("    // エラーメッセージの場合\r\n");
                        sb.Append("    message: Utils.createErrorMessage(response.errMessage, null, response.errMessageNo),\r\n");
                    }
                }
                sb.Append("    showDone: true,\r\n");
                sb.Append("    doneText: \"OK\",\r\n");

                if (chkMessShowC.Checked)
                {
                    sb.Append("    showCancel: true,\r\n");
                    sb.Append("    cancelText: \"いいえ\",\r\n");
                }

                sb.Append("}});\r\n");

                result = string.Format(sb.ToString());
            }

            txtMessResult.Text = result;

            if (result.Length > 0)
            {
                btnMessCopy.Enabled = true;
                lblMessResult.Visible = false;
                Clipboard.Clear();
            }
        }

        private void btnCreateMessI_Click(object sender, EventArgs e)
        {
            string mType = txtMessType.Text;
            string mTitle = "メッセージ";
            string result = string.Empty;
            bool showDone = false;

            StringBuilder sb = new StringBuilder();
            if (rdbMessDisp.Checked)
            {
                if (!string.IsNullOrEmpty(mType))
                {
                    if (!string.IsNullOrEmpty(txtMessDesc.Text))
                    {
                        if (string.IsNullOrEmpty(txtMessMsgCode.Text))
                        {
                            mTitle = "通知";
                        }
                        else
                        {
                            mTitle = "エラー情報";
                        }
                    }

                    if (!string.IsNullOrEmpty(txtMessDescH.Text))
                    {
                        mTitle = "エラー情報";
                    }

                    if (!string.IsNullOrEmpty(txtMessQues.Text))
                    {
                        mTitle = "確認";
                    }

                    if (txtMessDesc.Text.Contains(":"))
                    {
                        string[] mArrayWk = txtMessDesc.Text.Split(':');
                        if (mArrayWk[0].Length == 9)
                        {
                            if (mArrayWk[0].Substring(0, 1).ToUpper() == "W")
                            {
                                mTitle = "確認";
                            }
                        }
                    }
                }
                else
                {
                    string[] mArray = txtMessQues.Text.Split(CONST.CHAR_COMMA);
                    string mIcon = string.Empty;
                    string mButtonType = string.Empty;
                    int mTyp = 0;

                    if (mArray.Length > 0)
                    {
                        mIcon = mArray[0];
                    }
                    if (mArray.Length > 0)
                    {
                        mIcon = mArray[1];
                    }

                    switch (mIcon.ToUpper())
                    {
                        case "C":
                            mTyp = 16;
                            mTitle = "警告";
                            break;
                        case "Q":
                            mTyp = 32;
                            mTitle = "問い合わせ";
                            break;
                        case "E":
                            mTyp = 48;
                            mTitle = "注意";
                            break;
                        case "I":
                            mTyp = 64;
                            mTitle = "情報";
                            break;
                    }

                    switch (mButtonType)
                    {
                        case "0":
                            mTyp = mTyp + 0;
                            break;
                        case "1":
                            mTyp = mTyp + 1;
                            break;
                        case "2":
                            mTyp = mTyp + 2;
                            break;
                        case "3":
                            mTyp = mTyp + 3 + 256;
                            break;
                        case "4":
                            mTyp = mTyp + 4 + 256;
                            break;
                        case "5":
                            mTyp = mTyp + 5 + 256;
                            break;
                    }
                }

                if (mType == "1" || mType == "4" || mType == "5" || mType == "17" || mType == "20" ||
                    mType == "21" || mType == "33" || mType == "36" || mType == "37" || mType == "49" ||
                    mType == "52" || mType == "53" || mType == "65" || mType == "68" || mType == "69" ||
                    mType == "257" || mType == "260" || mType == "261" || mType == "273" || mType == "276" ||
                    mType == "289" || mType == "292" || mType == "293" || mType == "305" || mType == "308" ||
                    mType == "309" || mType == "321" || mType == "324" || mType == "325")
                {
                    showDone = true;
                }

                if (chkMessStatusI.Checked)
                {
                    sb.Append("const {{ status }} = await this._messageDialog.open({{\r\n");
                }
                else
                {
                    sb.Append("await this._messageDialog.open({{\r\n");
                }

                if (mTitle == "エラー情報")
                {
                    sb.Append("    title: \"{0}\",\r\n");
                    sb.Append("    message: Utils.createErrorMessage(Utils.getMessage(\"{1}\", \"{2}\")),\r\n");
                }
                else
                {
                    sb.Append("    title: \"{0}\",\r\n");
                    sb.Append("    message: Utils.createMessage(Utils.getMessage(\"{1}\", \"{2}\")),\r\n");
                }

                sb.Append("    showDone: true,\r\n");
                sb.Append("    doneText: \"{3}\",\r\n");

                if (showDone)
                {
                    sb.Append("    showCancel: true,\r\n");
                    sb.Append("    cancelText: \"{4}\",\r\n");
                    sb.Append("}});\r\n");

                    result = string.Format(sb.ToString(), mTitle, txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), "OK", "いいえ");
                }
                else
                {
                    sb.Append("}});\r\n");
                    result = string.Format(sb.ToString(), mTitle, txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), "OK");
                }
            }
            else
            {
                string type = txtMessDesc.Text.Trim().ToUpper();
                if (type.Equals("VBOKCANCEL") || type.Equals("VBYESNO"))
                {
                    showDone = true;
                }

                if (chkMessStatusI.Checked)
                {
                    sb.Append("const {{ status }} = await this._messageDialog.open({{\r\n");
                }
                else
                {
                    sb.Append("await this._messageDialog.open({{\r\n");
                }

                if (showDone)
                {
                    sb.Append("    title: \"エラー情報\",\r\n");
                    sb.Append("    message: Utils.createErrorMessage(Utils.getMessage(\"{0}\", \"{1}\")),\r\n");
                }
                else
                {
                    sb.Append("    title: \"確認\",\r\n");
                    sb.Append("    message: Utils.createMessage(Utils.getMessage(\"{0}\", \"{1}\")),\r\n");
                }

                sb.Append("    showDone: true,\r\n");
                sb.Append("    doneText: \"{2}\",\r\n");

                if (showDone)
                {
                    sb.Append("    showCancel: true,\r\n");
                    sb.Append("    cancelText: \"{3}\",\r\n");
                    sb.Append("}});\r\n");

                    result = string.Format(sb.ToString(), txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), "OK", "いいえ");
                }
                else
                {
                    sb.Append("}});\r\n");
                    result = string.Format(sb.ToString(), txtMessCode.Text.Trim(), txtMessContent.Text.Trim(), "OK");
                }
            }

            txtMessResult.Text = result;

            if (result.Length > 0)
            {
                btnMessCopy.Enabled = true;
                lblMessResult.Visible = false;
                Clipboard.Clear();
            }

        }

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

            if (lstMessCode == null)
            {
                return;
            }

            for (int i = 0; i < lstMessCode.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (i + 1 < lstMessContent.Length && !string.IsNullOrEmpty(lstMessContent[i + 1]) && lstMessContent[i + 1] != "\"\"")
                    {
                        result += string.Format(CUtils.CreTmlMess(CONST.STRING_CREATE_MESS_EQ), lstMessCode[i],
                            lstMessContent[i].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty),
                            lstMessContent[i + 1].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty));
                    }
                    else
                    {
                        result += string.Format(CUtils.CreTmlMess(CONST.STRING_CREATE_MESS), lstMessCode[i], lstMessContent[i].Replace(CONST.STRING_QUOTATION_MARKS, string.Empty));
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
                tmpLine = tmpLine.Replace(CONST.STRING_TAB, "    ");

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
                    if (tmpLine.Contains("'"))
                    {
                        tmpLine = tmpLine.Replace("'", "//");
                    }
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
            if ((!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrEmpty(txtName.Text)) &&
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

            lblResultSrcBundel.Visible = false;
            lblResultSrcController.Visible = false;
            lblResultSrcDialog.Visible = false;
            lblResultSrcHtml.Visible = false;
            lblResultSrcInit.Visible = false;
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
            sb.Append("bundles.Add(new StyleBundle(\"~/Content/{0}/{1}\").Include(\r\n");
            sb.Append("    \"~/Content/app/{0}/{1}/{2}.index.css\"));\r\n");
            sb.Append("bundles.Add(new ScriptBundle(\"~/bundles/{0}/{1}\").Include(\r\n");
            sb.Append("    \"~/Scripts/app/{0}/{1}/{2}.init.js\",\r\n");
            sb.Append("    \"~/Scripts/app/{0}/{1}/{2}.viewmodel.js\"));\r\n");

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

            lblResultSrcBundel.Visible = true;
            Clipboard.Clear();
            Clipboard.SetText(txtBundle.Text);
        }

        private void createController()
        {
            string name = txtID.Text.ToUpper();
            StringBuilder sb = new StringBuilder();

            sb.Append("/// <summary>\r\n");
            sb.Append("/// {0}：{1}画面\r\n");
            sb.Append("/// <summary>\r\n");
            if (chkMain.Checked && !chkSub.Checked && !chkPara.Checked)
            {
                sb.Append("/// <returns></returns>\r\n");
                sb.Append("public ActionResult {0}(){{\r\n");
            }
            else if (chkMain.Checked && !chkSub.Checked && chkPara.Checked)
            {
                sb.Append("/// <param name=\"para\"></param>\r\n");
                sb.Append("/// <returns></returns>\r\n");
                sb.Append("public ActionResult {0}(string para){{\r\n");
                sb.Append("    ViewBag.Para = para ?? \"\";\r\n");
            }
            else if (chkSub.Checked && !chkPara.Checked)
            {
                sb.Append("/// <param name=\"dialog\"></param>\r\n");
                sb.Append("/// <returns></returns>\r\n");
                sb.Append("public ActionResult {0}(string dialog){{\r\n");
                sb.Append("    if (dialog == \"1\")\r\n");
                sb.Append("    {{\r\n");
                sb.Append("        // サブ画面で開くために \"PartialView()\"を使用\r\n");
                sb.Append("        return PartialView();\r\n");
                sb.Append("    }}\r\n");
            }
            else if (chkSub.Checked && chkPara.Checked)
            {
                sb.Append("/// <param name=\"dialog\"></param>\r\n");
                sb.Append("/// <param name=\"para\"></param>\r\n");
                sb.Append("/// <returns></returns>\r\n");
                sb.Append("public ActionResult {0}(string dialog, string para){{\r\n");
                sb.Append("    ViewBag.Para = para ?? \"\";\r\n");
                sb.Append("\r\n");
                sb.Append("    if (dialog == \"1\")\r\n");
                sb.Append("    {{\r\n");
                sb.Append("        // サブ画面で開くために \"PartialView()\"を使用\r\n");
                sb.Append("        return PartialView();\r\n");
                sb.Append("    }}\r\n");
            }
            else
            {
                sb.Append("/// <returns></returns>\r\n");
                sb.Append("public ActionResult {0}(){{\r\n");
            }

            if (!chkMain.Checked)
            {
                sb.Append("}}\r\n");
            }
            else
            {
                sb.Append("    // 主要画面で開くために \"View()\"を使用\r\n");
                sb.Append("    return View();\r\n");
                sb.Append("}}\r\n");
            }

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

            lblResultSrcController.Visible = true;
            Clipboard.Clear();
            Clipboard.SetText(txtController.Text);
        }

        private void createInit()
        {
            string id = txtID.Text.ToLower();
            string idUpCase = CUtils.FirstCharToUpperCase(id);
            string date = DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day;

            StringBuilder sb = new StringBuilder();

            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("// ファイル名\r\n");
            sb.Append("//    {0}.init.ts\r\n");
            sb.Append("// 概要\r\n");
            sb.Append("// \r\n");
            sb.Append("// 著作権\r\n");
            sb.Append("//    Copyright © UCHIDA YOKO CO., LTD. All rights reserved.\r\n");
            sb.Append("// 作成者\r\n");
            sb.Append("//    フジネットシステムズ株式会社\r\n");
            sb.Append("// 作成日\r\n");
            sb.Append("//    {1}\r\n");
            sb.Append("//-----------------------------------------------------------------------\r\n");
            sb.Append("\r\n");
            sb.Append("$(() => {{\r\n");
            sb.Append("    const viewmodel = new {2}ViewModel();\r\n\r\n");
            sb.Append("    Utils.applyBindings(viewmodel, $(\"#{0}Main\"));\r\n");

            if (chkPara.Checked)
            {
                sb.Append("    const para = $(\"#{0}Main > input.para\").val();\r\n\r\n");
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

            lblResultSrcInit.Visible = true;
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

            lblResultSrcDialog.Visible = true;
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
            sb.Append("<div id=\"{3}Main\" class=\"contentMain-row-25 {3}-style\">\r\n");
            sb.Append("    <input class=\"para\" type=\"hidden\" value=\"@ViewBag.Para\"/>\r\n");
            sb.Append("    @Html.Hidden(\"spreadLiteral\", @Newtonsoft.Json.JsonConvert.SerializeObject(spreadLiteral))\r\n");
            sb.Append("    <!-- コンテンツエリア -->\r\n");
            sb.Append("    <div class=\"card main\">\r\n");
            sb.Append("        <div class=\"card-body\">\r\n");

            for (int i = 0; i < 25; i++)
            {
                sb.Append("            <div class=\"d-flex row-25 align-items-center col-px\">\r\n");
                sb.Append("                <div class=\"col\">\r\n");
                sb.Append("                </div>\r\n");
                sb.Append("            </div>\r\n");
            }

            sb.Append("        </div>\r\n");
            sb.Append("    </div>\r\n");
            sb.Append("\r\n");
            sb.Append("    <div class=\"contentFooter {3}BottomBtnArea\">\r\n");
            sb.Append("        <div class=\"d-flex row-25 align-items-center col-px\">\r\n");
            sb.Append("            <div class=\"col\">\r\n");
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

            lblResultSrcHtml.Visible = true;
            Clipboard.Clear();
            Clipboard.SetText(txtCshtml.Text);
        }

        #endregion

        #region Tab Create Item HTML
        private void cbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cbItem.SelectedIndex;

            switch (index)
            {
                case 0:
                    lbHtmlJpName.Text = "J Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 1:
                    lbHtmlJpName.Text = "J Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "E Name";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = true;
                    rdbUpdate.Visible = true;
                    rdbDelete.Visible = true;

                    chkItem.Visible = true;
                    chkItem.Text = "Span";
                    break;
                case 2:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = true;
                    chkItem.Text = "Readonly";
                    break;
                case 3:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "Length";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = true;
                    rdbNone.Text = "Left";
                    rdbUpdate.Visible = true;
                    rdbUpdate.Text = "Right";
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 4:
                    lbHtmlJpName.Text = "F Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "T Name";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = true;
                    rdbNone.Text = "From";
                    rdbUpdate.Visible = true;
                    rdbUpdate.Text = "To";
                    rdbDelete.Visible = false;

                    chkItem.Visible = true;
                    chkItem.Text = "To";
                    break;
                case 5:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 6:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 7:
                    lbHtmlJpName.Text = "B Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "I Name";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 8:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "Num Col";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = true;
                    chkItem.Text = "Readonly";
                    break;
                case 9:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 10:
                    lbHtmlJpName.Text = "J Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "E Name";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 11:
                    lbHtmlJpName.Text = "J Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "E Name";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 12:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = false;
                    txtHtmlName.Visible = false;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
                case 13:
                    lbHtmlJpName.Text = "E Name";
                    lbHtmlName.Visible = true;
                    lbHtmlName.Text = "ID Sceen";
                    txtHtmlName.Visible = true;

                    rdbNone.Visible = false;
                    rdbUpdate.Visible = false;
                    rdbDelete.Visible = false;

                    chkItem.Visible = false;
                    break;
            }
            txtHtmlJPName.Text = string.Empty;
            txtHtmlName.Text = string.Empty;
            txtResult.Text = string.Empty;

            btnHtmlCopy.Enabled = false;
            btnHtmlClear.Enabled = false;
            lblHtmlResult.Visible = false;
        }

        private void btnCreateOut_Click(object sender, EventArgs e)
        {
            int index = cbItem.SelectedIndex;
            string name = txtHtmlName.Text;
            string jpName = txtHtmlJPName.Text;
            string result = string.Empty;
            StringBuilder sb = new StringBuilder();

            switch (index)
            {
                case 0:
                    sb.Append("<label class=\"label row-25\" tabindex=\"-1\">@Html.Raw(literalCtrl[\"\"].CreateHtml(\"{0}\"))</label>\r\n");

                    result = string.Format(sb.ToString(), jpName);
                    break;
                case 1:
                    if (rdbUpdate.Checked)
                    {
                        sb.Append("<button class=\"btn row-25 btn-primary btn-block\" tabindex=\"-1\"\r\n");
                        sb.Append("        data-bind=\"click: bt{0}OnClick, disable: bt{0}Disable, hasFocus: bt{0}Focus\">\r\n");
                    }
                    else if (rdbDelete.Checked)
                    {
                        sb.Append("<button class=\"btn row-25 btn-danger btn-block\" tabindex=\"-1\"\r\n");
                        sb.Append("        data-bind=\"click: bt{0}OnClick, disable: bt{0}Disable, hasFocus: bt{0}Focus\">\r\n");
                    }
                    else
                    {
                        sb.Append("<button class=\"btn row-25 btn-light border-secondary btn-block\" tabindex=\"-1\"\r\n");
                        sb.Append("        data-bind=\"click: bt{0}OnClick, disable: bt{0}Disable, hasFocus: bt{0}Focus\">\r\n");
                    }

                    if (chkItem.Checked && rdbUpdate.Checked)
                    {
                        sb.Append("    <span class=\"fa fa-save mr-1\"></span>\r\n");
                    }
                    else if (chkItem.Checked && rdbDelete.Checked)
                    {
                        sb.Append("    <span class=\"fa fa-trash mr-1\"></span>\r\n");
                    }
                    else if (chkItem.Checked)
                    {
                        sb.Append("    <span class=\"fa fa- mr-1\"></span>\r\n");
                    }

                    if (!string.IsNullOrEmpty(jpName))
                    {
                        sb.Append("    @Html.Raw(literalCtrl[\"\"].CreateHtml(\"{1}\"))\r\n");
                        sb.Append("</button>\r\n");
                        result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(name), jpName);
                    }
                    else
                    {
                        sb.Append("</button>\r\n");
                        result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(name));
                    }

                    break;
                case 2:
                    if (chkItem.Checked)
                    {
                        sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                        sb.Append("       data-bind = \"value: tx{0}, disable: tx{0}Disable, hidden: tx{0}Hidden, hasFocus: tx{0}Focus\" readonly/>\r\n");
                    }
                    else
                    {
                        sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                        sb.Append("       data-bind = \"value: tx{0}, disable: tx{0}Disable, hidden: tx{0}Hidden, hasFocus: tx{0}Focus\"/>\r\n");
                    }

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 3:
                    if (rdbNone.Checked)
                    {
                        sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                        sb.Append("       data-bind = \"codeValue: tx{0}, codePaddingOnly: true, codeLength: {1}, codePadding: 'left', disable: tx{0}Disable, hasFocus: tx{0}Focus\"/>\r\n");
                    }
                    else
                    {
                        sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex =\"-1\"\r\n");
                        sb.Append("       data-bind = \"codeValue: tx{0}, codePaddingOnly: true, codeLength: {1}, codePadding: 'right', disable: tx{0}Disable, hasFocus: tx{0}Focus\"/>\r\n");

                    }

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName), name);
                    break;
                case 4:
                    sb.Append("<div class=\"input-group row-25\">\r\n");
                    sb.Append("    <input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                    sb.Append("           data-bind=\"dateJpValue: tx{0}, disable: tx{0}Disable, hasFocus: tx{0}Focus\">\r\n");
                    sb.Append("    <div class=\"input-group-append\">\r\n");
                    sb.Append("        <button class=\"btn row-25 btn-primary border-secondary\" tabindex=\"-1\" data-bind=\"disable: bt{0}Disable, hasFocus: bt{0}Focus\">\r\n");
                    sb.Append("            <span class=\"far fa-calendar-alt\"></span>\r\n");
                    sb.Append("        </button>\r\n");

                    if (rdbNone.Checked)
                    {
                        if (chkItem.Checked)
                        {
                            sb.Append("        <dropdown-calendar params=\"fromValue: tx{0}, toValue: tx{1}\"></dropdown-calendar>\r\n");
                            sb.Append("    </div>\r\n");
                            sb.Append("</div>\r\n");

                            result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName), CUtils.FirstCharToUpperCase(name));
                        }
                        else
                        {
                            sb.Append("        <dropdown-calendar params=\"fromValue: tx{0}\"></dropdown-calendar>\r\n");
                            sb.Append("    </div>\r\n");
                            sb.Append("</div>\r\n");

                            result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                        }
                    }
                    else
                    {
                        sb.Append("        <dropdown-calendar params=\"toValue: tx{0}\"></dropdown-calendar>\r\n");
                        sb.Append("    </div>\r\n");
                        sb.Append("</div>\r\n");

                        result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(name));
                    }

                    break;
                case 5:
                    sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                    sb.Append("       data-bind = \"moneyValue: tx{0}, disable: tx{0}Disable, hasFocus: tx{0}Focus\"/>\r\n");

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 6:
                    sb.Append("<input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                    sb.Append("       data-bind = \"postCodeValue: tx{0}, disable: tx{0}Disable, hasFocus: tx{0}Focus\"/>\r\n");

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 7:
                    sb.Append("<div class=\"input-group\">\r\n");
                    sb.Append("    <div class=\"input-group-prepend\">\r\n");
                    sb.Append("        <button class=\"btn row-25 btn-light border-secondary\" tabindex=\"-1\"\r\n");
                    sb.Append("                data-bind=\"click: bt{0}OnClick, disable: bt{0}Disable, hasFocus: bt{0}Focus\">\r\n");
                    sb.Append("            <span class=\"fa fa-search\"></span>\r\n");
                    sb.Append("        </button>\r\n");
                    sb.Append("    </div>\r\n");
                    sb.Append("    <input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                    sb.Append("           data-bind = \"value: tx{1}Code, disable: tx{1}CodeDisable, hasFocus: tx{1}CodeFocus\" readonly/>\r\n");
                    sb.Append("    <input type=\"text\" class=\"form-control row-25\" tabindex=\"-1\"\r\n");
                    sb.Append("           data-bind = \"value: tx{1}Name, disable: tx{1}NameDisable, hasFocus: tx{1}NameFocus\" readonly/>\r\n");
                    sb.Append("    <div class=\"input-group-append\">\r\n");
                    sb.Append("        <button class=\"btn row-25 btn-light border-secondary\" tabindex=\"-1\"\r\n");
                    sb.Append("                data-bind=\"click: bt{0}ClearOnClick, disable: bt{0}ClearDisable, hasFocus: bt{0}ClearFocus\">\r\n");
                    sb.Append("            <span class=\"fa fa-eraser\"></span>\r\n");
                    sb.Append("        </button>\r\n");
                    sb.Append("    </div>\r\n");
                    sb.Append("</div>\r\n");

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(name), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 8:
                    if (chkItem.Checked)
                    {
                        sb.Append("<textarea class=\"form-control txarea-row-25\" maxleng=\"100\" tabindex=\"-1\"\r\n");
                        sb.Append("       data-bind = \"value: tx{0}, disable: tx{0}Disable, hidden: tx{0}Hidden, hasFocus: tx{0}Focus\" readonly/>\r\n");
                    }
                    else
                    {
                        sb.Append("<textarea class=\"form-control txarea-row-25\" maxleng=\"100\" tabindex=\"-1\"\r\n");
                        sb.Append("       data-bind = \"value: tx{0}, disable: tx{0}Disable, hidden: tx{0}Hidden, hasFocus: tx{0}Focus\"/>\r\n");
                    }

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 9:
                    sb.Append("<select class=\"form-control row-25\" data-bind=\"\r\n");
                    sb.Append("        options:       cx{0},\r\n");
                    sb.Append("        optionsText:  'cx{0}Name',\r\n");
                    sb.Append("        optionsValue: 'cx{0}Code',\r\n");
                    sb.Append("        value:         cx{0}Sentaku,\r\n");
                    sb.Append("        disable:       cx{0}Disable,\r\n");
                    sb.Append("        hasfocus:      cx{0}Focus\">\r\n");
                    sb.Append("</select>\r\n");

                    result = string.Format(sb.ToString(), CUtils.FirstCharToUpperCase(jpName));
                    break;
                case 10:
                    sb.Append("<label class=\"label row-25\">\r\n");
                    sb.Append("    <input type=\"checkbox\" class=\"check-row-25\" value=\"0\"\r\n");
                    sb.Append("           data-bind=\"checked: ck{1}, disable: ck{1}Disable, hasfocus: ck{1}Focus\">\r\n");
                    sb.Append("        @Html.Raw(literalCtrl[\"\"].CreateHtml(\"{0}\"))\r\n");
                    sb.Append("</label>\r\n");

                    result = string.Format(sb.ToString(), jpName, CUtils.FirstCharToUpperCase(name));
                    break;
                case 11:
                    sb.Append("<label class=\"label row-25\">\r\n");
                    sb.Append("    <input type=\"radio\" class=\"check-row-25\" name=\"rb{1}\" value=\"0\"\r\n");
                    sb.Append("           data-bind=\"checked: rb{1}, disable: rb{1}Disable, hasfocus: rb{1}Focus\">\r\n");
                    sb.Append("        @Html.Raw(literalCtrl[\"\"].CreateHtml(\"{0}\"))\r\n");
                    sb.Append("</label>\r\n");

                    result = string.Format(sb.ToString(), jpName, CUtils.FirstCharToUpperCase(name));
                    break;
                case 12:
                    sb.Append("<div class=\"d-flex row-25 col-px align-items-center\">\r\n");
                    sb.Append("    <div class=\"col-12\">\r\n");
                    sb.Append("        <div id=\"{0}Spread\" class=\"sp-font-row-25\"></div>\r\n");
                    sb.Append("    </div>\r\n");
                    sb.Append("</div>\r\n");

                    result = string.Format(sb.ToString(), jpName);
                    break;
                case 13:
                    sb.Append("<div class=\"d-flex row-25 col-px align-items-center\" id=\"{0}TreeArea\">\r\n");
                    sb.Append("    <div class=\"tree-main\">\r\n");
                    sb.Append("        <div class=\"tree-body\">\r\n");
                    sb.Append("            <div id=\"{1}Tree\" class=\"tree-font-row-25\"></div>\r\n");
                    sb.Append("        </div>\r\n");
                    sb.Append("    </div>\r\n");
                    sb.Append("</div>\r\n");

                    result = string.Format(sb.ToString(), name, jpName);
                    break;
            }

            if (string.IsNullOrEmpty(result))
            {
                txtHtmlResult.Text = result;
                btnHtmlCopy.Enabled = false;
                btnHtmlClear.Enabled = false;
            }
            else
            {
                txtHtmlResult.Text = result;
                btnHtmlCopy.Enabled = true;
                btnHtmlClear.Enabled = true;
            }

            lblHtmlResult.Visible = false;
        }

        private void btnHtmlCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtHtmlResult.Text))
            {
                return;
            }

            lblHtmlResult.Visible = true;
            Clipboard.Clear();
            Clipboard.SetText(txtHtmlResult.Text);
        }

        private void btnHtmlClear_Click(object sender, EventArgs e)
        {
            cbItem.SelectedIndex = 0;

            txtHtmlResult.Text = string.Empty;
            txtHtmlName.Text = string.Empty;
            txtHtmlJPName.Text = string.Empty;

            lblHtmlResult.Visible = false;

            Clipboard.Clear();
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
