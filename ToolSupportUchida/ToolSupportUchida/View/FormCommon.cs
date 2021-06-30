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
                    if (i + 1 < lstMessContent.Length && !string.IsNullOrEmpty(lstMessContent[i + 1]))
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
            lstFormatCode = txtMessCode.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

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

            foreach (string line in lstFormatCode)
            {
                lengthText = line.LastIndexOf("/");
                if (lengthText > maxLengthRow)
                {
                    maxLengthRow = lengthText;
                }
            }

            txtFormatResult.Text = CUtils.FormatCode(txtFormatResult.Text, maxLengthRow);

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
