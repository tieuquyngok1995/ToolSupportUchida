using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormGetSQLinSrc : Form
    {
        private Dictionary<string, List<string>> lstDic = new Dictionary<string, List<string>>();
        private Dictionary<string, string> lstDicParam = new Dictionary<string, string>();
        private List<string> lstParam = new List<string>();

        private string strSQLChar = string.Empty;
        private string strInputSQL = string.Empty;

        #region Load Form
        public FormGetSQLinSrc()
        {
            InitializeComponent();
        }

        private void FormConvert_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(Button))
                {
                    Button btn = (Button)control;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }

                if (control.GetType() == typeof(GroupBox))
                {
                    GroupBox grpB = (GroupBox)control;

                    foreach (Control grbControl in grpB.Controls)
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
        #endregion

        #region Event
        private void gridInputParam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridInputParam.IsCurrentCellDirty)
            {
                gridInputParam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnCreateParam_Click(object sender, EventArgs e)
        {
            strSQLChar = txtSQLChar.Text.Trim();

            this.gridInputParam.Rows.Clear();
            this.gridInputParam.Refresh();

            if (!string.IsNullOrEmpty(txtInputSQL.Text))
            {
                gridInputParam.Visible = true;

                btnConvert.Enabled = true;
                txtSQLChar.Enabled = true;

                strInputSQL = handFormatStringInput(txtInputSQL.Text);
            }
            else
            {
                gridInputParam.Visible = false;

                btnConvert.Enabled = false;
                txtSQLChar.Enabled = true;

                strInputSQL = string.Empty;
            }

            if (!string.IsNullOrEmpty(strInputSQL))
            {
                lstParam = new List<string>();
                handleInputParam(strInputSQL);
                btnConvert.Enabled = true;
            }

            string line = txtInputSQL.Text.Replace("\t", " ");
            while (line.IndexOf("  ") >= 0)
            {
                line = line.Replace("  ", " ");
            }
            txtInputSQL.Text = line;
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string dicValue = string.Empty;
            string strSQL = strInputSQL;
            string result = string.Empty;
            bool checkIf = true;
            bool isNum = false;

            try
            {
                lstDicParam.Clear();
                foreach (DataGridViewRow item in gridInputParam.Rows)
                {
                    dicValue = string.IsNullOrEmpty(item.Cells[2].Value.ToString())
                        ? CONST.STRING_EMPTY : item.Cells[2].Value.ToString();
                    lstDicParam.Add(item.Cells[1].Value.ToString(), dicValue);
                }

                foreach (KeyValuePair<string, string> item in lstDicParam)
                {
                    strSQL = strSQL.Replace(CONST.STRING_FORMAT_13 + item.Key + CONST.STRING_FORMAT_14,
                                                      CONST.STRING_REPLACE_06 + item.Value + CONST.STRING_REPLACE_06);

                    isNum = int.TryParse(item.Value, out int n);
                    if (isNum && item.Value.Trim().StartsWith("\"") && item.Value.Trim().EndsWith("\""))
                    {
                        strSQL = strSQL.Replace(CONST.STRING_FORMAT_15 + item.Key + CONST.STRING_FORMAT_16,
                                                      CONST.STRING_REPLACE_06 + item.Value + CONST.STRING_REPLACE_06);
                    }
                    else
                    {
                        strSQL = strSQL.Replace(CONST.STRING_FORMAT_15 + item.Key + CONST.STRING_FORMAT_16, item.Value);
                    }

                    strSQL = CUtils.ReplaceFormatText(strSQL, item.Key, CONST.STRING_FORMAT_11, item.Value);
                    strSQL = CUtils.ReplaceFormatText(strSQL, item.Key, CONST.STRING_FORMAT_12, item.Value);
                }

                foreach (string item in strSQL.Split(CONST.CHAR_NEW_LINE))
                {
                    if (string.IsNullOrEmpty(item))
                    {
                        continue;
                    }

                    if (!item.Trim().Equals(CONST.STRING_CHECK_END_IF)
                        && (item.Contains(CONST.STRING_CHECK_IF) || item.Contains(CONST.STRING_CHECK_ELSE_IF)))
                    {
                        checkIf = CUtils.ConvertStringToBoolean(item);
                    }
                    else if (item.Equals(CONST.STRING_CHECK_ELSE))
                    {
                        checkIf = !checkIf;
                        continue;
                    }
                    else if (item.Equals(CONST.STRING_CHECK_END_IF))
                    {
                        checkIf = true;
                        continue;
                    }
                    else
                    {
                        if (checkIf)
                        {
                            result = result + item + CONST.CHAR_NEW_LINE;
                        }
                    }
                }

                result = result.Replace(CONST.STRING_CHECK_STRING_EMPTY, CONST.STRING_DOUBLE_APOSTROPHE);

                txtResult.Text = result;

                if (txtResult.Text.Length != 0)
                {
                    btnCopy.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Button Convert") + ex.Message, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputSQL.Text = string.Empty;
            txtResult.Text = string.Empty;


            gridInputParam.DataSource = null;
            gridInputParam.Visible = false;

            btnConvert.Enabled = false;
            btnCopy.Enabled = false;

            this.gridInputParam.Rows.Clear();
            this.gridInputParam.Refresh();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.SetText(txtResult.Text);
        }
        #endregion

        #region Method
        private string handFormatStringInput(string strInputSQL)
        {
            string regexJapan = "'([\u3000-\u303F]|[\u3040-\u309F]|[\u30A0-\u30FF]|[\uFF00-\uFFEF]|[\u4E00-\u9FAF]|[\u2605-\u2606]|[\u2190-\u2195]|\u203B)+";
            string result = string.Empty;
            string item = string.Empty;

            try
            {
                if (strInputSQL.Contains(CONST.STRING_CHECK_THEN))
                {
                    strInputSQL = strInputSQL.Replace(string.Format(CONST.STRING_FORMAT_17, CONST.STRING_CHECK_THEN),
                        string.Format(CONST.STRING_FORMAT_17, CONST.STRING_CHECK_THEN + CONST.CHAR_NEW_LINE));
                }

                strInputSQL = Regex.Replace(strInputSQL, regexJapan, string.Empty);
                strInputSQL = strInputSQL.Replace(CONST.STRING_VBCRLF, string.Empty);
                strInputSQL = strInputSQL.Replace(CONST.STRING_FORMAT_18, string.Empty);

                List<string> listString = new List<string>();
                string[] arrInputSQL = strInputSQL.Split(CONST.CHAR_NEW_LINE);

                arrInputSQL = arrInputSQL.Where(
                    (val, idx) => !(val.Contains(CONST.STRING_CHECK_APOSTROPHE)
                                 && (val.Contains(CONST.STRING_CHECK_ADD_END) || val.Contains(CONST.STRING_CHECK_HASH)
                                 || val.Contains(CONST.STRING_CHECK_REP_START) || val.Contains(CONST.STRING_CHECK_REP_END)
                                 || val.Contains(CONST.STRING_CHECK_HYPHEN)) || val.Contains(CONST.STRING_CHECK_COMMENT)
                                 || val.Contains(CONST.STRING_CHECK_SPLIT))
                                 && !string.Empty.Equals(val)
                                 && !val.Contains(string.Format(CONST.STRING_CHECK_APOSTROPHE_VALUE, strSQLChar))).ToArray();

                for (int i = 0; i < arrInputSQL.Length; i++)
                {
                    item = arrInputSQL[i];

                    item = item.Replace(CONST.STRING_TAB, string.Empty);
                    if (string.Empty.Equals(item)) continue;

                    // Replace format
                    item = item.TrimStart();
                    item = item.TrimEnd();
                    item = CUtils.ReplaceFormat(item, CONST.STRING_FORMAT_01, CONST.STRING_REPLACE_01, strSQLChar);
                    item = CUtils.ReplaceFormat(item, CONST.STRING_FORMAT_02, CONST.STRING_REPLACE_02);
                    item = CUtils.ReplaceFormat(item, CONST.STRING_FORMAT_03, CONST.STRING_REPLACE_03);
                    item = Regex.Replace(item, CONST.STRING_FORMAT_04, CONST.STRING_REPLACE_04);
                    item = Regex.Replace(item, CONST.STRING_FORMAT_05, CONST.STRING_REPLACE_05);
                    if (item.StartsWith("'"))
                    {
                        continue;
                    }

                    if (item.EndsWith("'"))
                    {
                        item = item.Remove(item.Length - 1);
                        item = item.TrimEnd();
                    }

                    if (item.EndsWith("\""))
                    {
                        item = item.Remove(item.Length - 1);
                    }
                    else if (item.Contains(CONST.CHAR_AMPERSAND))
                    {
                        int numAmpersand = item.Count(f => (f == CONST.CHAR_AMPERSAND));
                        if (numAmpersand % 2 == 0)
                        {
                            item = string.Concat(item, CONST.STRING_SPACE, CONST.STRING_CHECK_PARAM_CLOSE);
                        }
                    }

                    // Format string SQL
                    if (item.Contains(string.Format(CONST.STRING_CHECK_CONTAINS_01, strSQLChar)))
                    {
                        item = CUtils.ReplaceFormat(item, CONST.STRING_CHECK_CONTAINS_01, string.Empty, strSQLChar);
                    }
                    else if (item.Contains(string.Format(CONST.STRING_CHECK_CONTAINS_02, strSQLChar)))
                    {
                        item = CUtils.ReplaceFormat(item, CONST.STRING_CHECK_CONTAINS_02, string.Empty, strSQLChar);
                    }
                    else if (item.Contains(string.Format(CONST.STRING_CHECK_CONTAINS_03, strSQLChar)))
                    {
                        item = CUtils.ReplaceFormat(item, CONST.STRING_CHECK_CONTAINS_03, string.Empty, strSQLChar);
                    }
                    else if (Regex.IsMatch(item, CONST.REGEX_WORD_CHARACTER))
                    {
                        continue;
                    }
                    else if (!item.Contains(CONST.STRING_CHECK_IF) && !item.Contains(CONST.STRING_CHECK_ELSE) && !item.Contains(CONST.STRING_CHECK_ELSE_IF))
                    {
                        continue;
                    }

                    // add value in list
                    if ((item.Contains(CONST.STRING_CHECK_IF) && !item.Contains(CONST.STRING_CHECK_END_IF))
                        || item.Contains(CONST.STRING_CHECK_ELSE))
                    {
                        result = result + item.Trim() + CONST.CHAR_NEW_LINE;
                    }
                    else
                    {
                        result = result + item.Trim() + CONST.CHAR_NEW_LINE;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Handle Format String Input") + ex.Message,
                    CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }

        private void handleInputParam(string strSQL)
        {
            try
            {
                string[] arrInputSQL = strSQL.Split(CONST.CHAR_NEW_LINE);

                string result = string.Empty;
                string itemCheck = string.Empty;

                foreach (string item in arrInputSQL)
                {
                    if (item.Contains(CONST.STRING_CHECK_IF) || item.Contains(CONST.STRING_CHECK_ELSE))
                    {
                        string strItem = item.Replace(CONST.STRING_CHECK_IF, string.Empty).
                                                Replace(CONST.STRING_CHECK_ELSE, string.Empty).Trim();

                        string[] arrItem = strItem.Split(new string[] { CONST.STRING_AND_ALSO, CONST.STRING_AND,
                                                                CONST.STRING_OR_ELSE, CONST.STRING_OR,
                                                                CONST.STRING_UPPER_AND_ALSO, CONST.STRING_UPPER_AND,
                                                                CONST.STRING_UPPER_OR_ELSE, CONST.STRING_UPPER_OR },
                                                                        StringSplitOptions.None);
                        foreach (string itemParam in arrItem)
                        {
                            if (string.IsNullOrEmpty(itemParam))
                            {
                                continue;
                            }

                            result = handleItemParam(itemParam, lstParam);
                            if (!string.IsNullOrEmpty(result))
                            {
                                strInputSQL = strInputSQL.Replace(itemParam, result);
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(item)) continue;

                        int indexRow = 1;
                        string[] arrItem = item.Split(new string[] { CONST.STRING_CHECK_PARAM_OPEN,
                                                             CONST.STRING_CHECK_PARAM_CLOSE }, StringSplitOptions.None);

                        while (indexRow < arrItem.Length)
                        {
                            if (!string.IsNullOrEmpty(arrItem[indexRow]))
                            {
                                itemCheck = arrItem[indexRow].Replace(CONST.STRING_CHECK_PARAM_CLOSE, string.Empty).Trim();
                                if (lstParam.Count == 0 || !lstParam.Any(itemLst => itemLst.Equals(itemCheck)))
                                {
                                    lstParam.Add(itemCheck);
                                }
                            }
                            indexRow += 2;
                        };
                    }
                }

                // Add data to data grid view
                handleDataToLstInputParam(lstParam);
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Handle Input Parameter Data") + ex.Message,
                    CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string handleItemParam(string strItem, List<string> lstParam)
        {
            try
            {
                string value = strItem;

                // Check open brackets
                int numOpenBrackets = strItem.Count(f => (f == CONST.CHAR_O_BRACKETS));
                int numCloseBrackets = strItem.Count(f => (f == CONST.CHAR_C_BRACKETS));

                if (strItem.Trim().StartsWith("(") && numOpenBrackets > numCloseBrackets)
                {
                    value = strItem.Remove(0, 1);
                }

                if (strItem.Trim().EndsWith(")") && numOpenBrackets < numCloseBrackets)
                {
                    value = strItem.Remove(strItem.Length - 2);
                }

                if (numOpenBrackets == numCloseBrackets)
                {
                    if (value.Contains(CONST.STRING_CHECK_CONTAINS_04))
                    {
                        value = value.Replace(CONST.STRING_CHECK_CONTAINS_04, CONST.STRING_COMMA);
                    }
                }

                string[] arrItem = value.Trim().Split(CONST.CHAR_SPACE);

                if (arrItem.Length < 2)
                {
                    return string.Empty;
                }

                if (!int.TryParse(arrItem[0], out int n) && (lstParam.Count == 0 || !lstParam.Any(itemLst => itemLst.Equals(arrItem[0]))))
                {
                    lstParam.Add(arrItem[0]);
                }

                if (!arrItem[2].Contains(CONST.CHAR_QUOTATION))
                {
                    if (lstParam.Count == 0 || !lstParam.Any(itemLst => itemLst.Equals(arrItem[2])))
                    {
                        lstParam.Add(arrItem[2]);
                    }
                }
                return value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Handle Item Parameter Data") + ex.Message,
                    CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return string.Empty;
            }
        }

        private void handleDataToLstInputParam(List<string> lstParam)
        {
            int no = 1;
            foreach (string item in lstParam)
            {
                this.gridInputParam.Rows.Add(no++, item, string.Empty);
            }
        }
        #endregion
    }
}
