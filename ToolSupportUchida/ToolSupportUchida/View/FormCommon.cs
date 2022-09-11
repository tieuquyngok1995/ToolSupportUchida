using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCommon : Form
    {
        private string[] lstKey;
        private string[] stringSeparators;

        // list format 
        private string[] lstFormatCode;

        // list using get column
        private Dictionary<string, Dictionary<string, string>> dicColumnData = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, string> dicColumnTable = new Dictionary<string, string>();

        // list create comment
        private List<string> lstInputComment = new List<string>();
        private List<string> lstInputCode = new List<string>();

        private int createComentLocation = 0;
        private int createComentMode = 0;

        // cons split 
        private readonly string[] DELI = new[] { "\r\n" };

        DataTable table;

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
                    //cbMessDone.SelectedIndex = 0;
                    //cbMessCancel.SelectedIndex = 0;
                    //txtMessCode.Focus();
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

        #region Tab Create JSON
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
                lblResult.Visible = false;
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
            int mode = 0;
            if (rbFormatCommentLine.Checked) mode = 1;

            int maxLengthRow = 0;
            int lengthAppend = -1;

            string result = string.Empty;
            foreach (string line in lstFormatCode)
            {
                string tmpLine = line.Trim();
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
                }
                else
                {
                    if (tmpLine.Contains("'"))
                    {
                        tmpLine = tmpLine.Replace("'", "//");
                    }
                }

                maxLengthRow = getLengthText(mode, tmpLine, maxLengthRow);

                result += tmpLine + CONST.STRING_ADD_LINE;
            }

            txtFormatResult.Text = CUtils.FormatCode(mode, result, maxLengthRow);
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
                lblFormatResult.Visible = true;
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

        #region Tab Get Name Column
        private void txColumnData_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string value = txColumnData.Text;
                List<string> lstColumnData = new List<string>();
                // create data in table 
                if (!string.IsNullOrEmpty(value))
                {
                    string strRegex = @"[\t]+";
                    Regex myRegex = new Regex(strRegex, RegexOptions.None);
                    string strReplace = @"\t";
                    value = myRegex.Replace(value, strReplace);

                    string[] stringSeparators = new string[] { "テーブル論理名" };
                    lstColumnData = value.Split(stringSeparators, StringSplitOptions.None).ToList();
                }

                // create list in table
                if (lstColumnData.Count > 0)
                {
                    dicColumnData = new Dictionary<string, Dictionary<string, string>>();
                    dicColumnTable = new Dictionary<string, string>();
                    foreach (string table in lstColumnData)
                    {
                        if (!string.IsNullOrEmpty(table))
                        {
                            string[] stringNewLine = new string[] { "\r\n" };
                            string[] data = table.Split(stringNewLine, StringSplitOptions.None);

                            string[] stringNameTable = new string[] { "テーブル物理名" };
                            string[] lstNameTable = data[0].Split(stringNameTable, StringSplitOptions.None);

                            string nameLogicTable = ""; string namePhysTable;
                            if (lstNameTable.Length > 1)
                            {
                                namePhysTable = Regex.Replace(lstNameTable[0], @"\\t", "");
                                nameLogicTable = Regex.Replace(lstNameTable[1], @"\\t", "");
                                dicColumnTable.Add(nameLogicTable, namePhysTable.Replace("テーブル", ""));
                            }

                            Dictionary<string, string> dicData = new Dictionary<string, string>();
                            string[] stringTab = new string[] { "\\t" };
                            for (int idx = 1; idx < data.Length; idx++)
                            {
                                if (!string.IsNullOrEmpty(data[idx]))
                                {
                                    string[] item = data[idx].Split(stringTab, StringSplitOptions.None);
                                    if (item.Length > 1)
                                    {
                                        dicData.Add(item[0], item[1]);
                                    }
                                }
                            }
                            if (dicData.Count > 0)
                            {
                                dicColumnData.Add(nameLogicTable, dicData);
                            }
                        }
                    }
                }

                setDataTable();

                getColumn();
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Column Data") + ex.Message, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbColumnTable_CheckedChanged(object sender, EventArgs e)
        {
            if (rbColumnTable.Checked)
            {
                cbColumnFormat.SelectedIndex = -1;
                txColumnInput.Text = string.Empty;

                setDataTable();
            }
        }

        private void cbColumnTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbColumnTable.Checked)
            {
                setDataTable(false);
                if (!string.IsNullOrEmpty(txColumnSearch.Text))
                {
                    DataView dv = table.DefaultView;

                    string filter = "";
                    if (cbColumnTable.SelectedItem != null && !string.IsNullOrEmpty(cbColumnTable.Text))
                    {
                        filter = "LogicTable = '" + cbColumnTable.SelectedItem + "' And ";
                    }
                    filter += "PhysicalName LIKE '" + txColumnSearch.Text + "%'";
                    dv.RowFilter = filter;
                    gridColumnData.DataSource = dv;
                }
            }
        }

        private void txColumnSearch_Click(object sender, EventArgs e)
        {
            txColumnSearch.SelectAll();
        }

        private void txColumnSearch_TextChanged(object sender, EventArgs e)
        {
            if (rbColumnTable.Checked)
            {
                int selectIndexTable = cbColumnTable.SelectedIndex;
                setDataTable();

                cbColumnTable.SelectedIndex = selectIndexTable;

                DataView dv = table.DefaultView;

                string filter = "";
                if (cbColumnTable.SelectedItem != null && !string.IsNullOrEmpty(cbColumnTable.Text))
                {
                    filter = "LogicTable = '" + cbColumnTable.SelectedItem + "' And ";
                }
                filter += "PhysicalName LIKE '" + txColumnSearch.Text + "%'";
                dv.RowFilter = filter;
                gridColumnData.DataSource = dv;
            }
        }

        private void rbColumnFormat_CheckedChanged(object sender, EventArgs e)
        {
            if (rbColumnFormat.Checked)
            {
                cbColumnTable.SelectedIndex = -1;
                txColumnSearch.Text = string.Empty;

                setDataTable();
            }
        }

        private void cbColumnFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbColumnFormat.Checked)
            {
                getColumn();
            }
        }

        private void txColumnInput_TextChanged(object sender, EventArgs e)
        {
            if (rbColumnFormat.Checked)
            {
                setDataTable();

                getColumn();
            }
        }

        private void txColumnInput_Click(object sender, EventArgs e)
        {
            txColumnInput.SelectAll();
        }

        private void setDataTable(bool isClear = true)
        {
            try
            {
                // set data to combo
                List<string> lstTableName = new List<string>();

                table = new DataTable();

                table.Columns.Add("PhysicalTable", typeof(string));
                table.Columns.Add("LogicTable", typeof(string));
                table.Columns.Add("PhysicalName", typeof(string));
                table.Columns.Add("LogicName", typeof(string));

                if (isClear)
                {
                    cbColumnTable.Items.Clear();
                    cbColumnTable.Items.Add("");
                    lstTableName = new List<string>(dicColumnData.Keys);
                }
                else
                {
                    if (string.IsNullOrEmpty(cbColumnTable.SelectedItem.ToString()))
                    {
                        lstTableName = new List<string>(dicColumnData.Keys);
                    }
                    else
                    {
                        lstTableName.Add(cbColumnTable.SelectedItem.ToString());
                    }
                }

                foreach (string item in lstTableName)
                {
                    if (isClear) cbColumnTable.Items.Add(item);
                    // Set data to table
                    Dictionary<string, string> lstData = dicColumnData[item];
                    foreach (KeyValuePair<string, string> pair in lstData)
                    {
                        table.Rows.Add(dicColumnTable[item], item, pair.Key, pair.Value);
                    }
                }

                // set data to gird
                gridColumnData.DataSource = table;
                DataGridViewColumn column = gridColumnData.Columns[0];
                column.HeaderText = "Physical Table";
                column.Width = 125;
                column = gridColumnData.Columns[1];
                column.HeaderText = "Logic Table";
                column.Width = 125;
                column = gridColumnData.Columns[2];
                column.HeaderText = "Physical Name";
                column.Width = 140;
                column = gridColumnData.Columns[3];
                column.HeaderText = "Logic Name";
                column.Width = 145;
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Set Data Table") + ex.Message, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getColumn()
        {
            try
            {
                string valueInput = txColumnInput.Text.Trim();
                string strRegex = @"[\t]+";
                Regex myRegex = new Regex(strRegex, RegexOptions.None);
                string strReplace = "";
                valueInput = myRegex.Replace(valueInput, strReplace);
                valueInput.Replace("\r\n", "");

                string format = "";
                int selectIndex = 0;
                if (cbColumnFormat.SelectedItem != null)
                {
                    selectIndex = cbColumnFormat.SelectedIndex;
                    format = cbColumnFormat.Text;
                }

                if (string.IsNullOrEmpty(valueInput) || string.IsNullOrEmpty(format))
                {
                    return;
                }

                // get value input
                string key = "", value = "";
                getKeyValueFormat(valueInput, selectIndex, ref key, ref value);

                DataView dv = table.DefaultView;

                key = key.Replace("テーブル", "");
                string filter = "PhysicalTable = '" + key + "' And PhysicalName LIKE '" + value + "%'";

                dv.RowFilter = filter;
                gridColumnData.DataSource = dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Get Column") + ex.Message, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void getKeyValueFormat(string val, int index, ref string key, ref string value)
        {
            string[] lstVal; string[] stringFormat;
            switch (index)
            {
                case 0:
                    stringFormat = new string[] { "].[" };
                    lstVal = val.Split(stringFormat, StringSplitOptions.None);
                    if (lstVal.Length > 1)
                    {
                        key = lstVal[0].Replace("[", "");
                        value = lstVal[1].Replace("]", "");
                    }
                    break;
                case 1:
                    stringFormat = new string[] { "】.[" };
                    lstVal = val.Split(stringFormat, StringSplitOptions.None);
                    if (lstVal.Length > 1)
                    {
                        key = lstVal[0].Replace("【", "");
                        value = lstVal[1].Replace("]", "");
                    }
                    break;
                case 2:
                    stringFormat = new string[] { "】.【" };
                    lstVal = val.Split(stringFormat, StringSplitOptions.None);
                    if (lstVal.Length > 1)
                    {
                        key = lstVal[0].Replace("【", "");
                        value = lstVal[1].Replace("】", "");
                    }
                    break;
                case 3:
                    stringFormat = new string[] { "/" };
                    lstVal = val.Split(stringFormat, StringSplitOptions.None);
                    if (lstVal.Length > 1)
                    {
                        key = lstVal[0].Replace("[", "");
                        value = lstVal[1].Replace("]", "");
                    }
                    break;
                case 4:
                    stringFormat = new string[] { "/" };
                    lstVal = val.Split(stringFormat, StringSplitOptions.None);
                    if (lstVal.Length > 1)
                    {
                        key = lstVal[0].Replace("【", "");
                        value = lstVal[1].Replace("】", "");
                    }
                    break;
            }
        }

        private void txColumnDoc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txColumnDoc.Text) || string.IsNullOrEmpty(txColumnData.Text))
            {
                txColumnResult.Text = string.Empty;
                btColumnCopy.Enabled = false;

                return;
            }

            if (!rbColumnFormat.Checked || (rbColumnFormat.Checked && cbColumnFormat.SelectedItem == null))
            {
                MessageBox.Show(CONST.MESS_COMMON_COLUMN_SELECT_FORMAT, CONST.TEXT_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<string> lstDoc = txColumnDoc.Text.Replace("\t", "").Split(DELI, StringSplitOptions.RemoveEmptyEntries).ToList();

            string format = "";
            int selectIndex = 0;
            if (cbColumnFormat.SelectedItem != null)
            {
                selectIndex = cbColumnFormat.SelectedIndex;
                format = cbColumnFormat.Text;
            }

            for (int i = 0; i<lstDoc.Count; i++){
                string valueInput = lstDoc[i].Trim();
                string[] lstValueInput = { valueInput };
                if (valueInput.Contains(CONST.STRING_EQUAL))
                {
                    lstValueInput = valueInput.Split(CONST.CHAR_EQUALS);
                }

                foreach (string val in lstValueInput)
                {
                    Dictionary<string, string> dicData = new Dictionary<string, string>();
                    // get value input
                    string key = "", value = "", newVal = "";
                    string olKey = "", olValue = "", keyCheck = "";
                    getKeyValueFormat(val.Trim(), selectIndex, ref olKey, ref olValue);

                    olKey = olKey.Replace("テーブル", "");
                    if (string.IsNullOrEmpty(keyCheck) || keyCheck != key)
                    {
                        key = dicColumnTable.FirstOrDefault(x => x.Value == olKey).Key;
                        if (key != null && !string.IsNullOrEmpty(key))
                        {
                            keyCheck = key;
                            dicData = dicColumnData[key];
                        }
                    }

                    if (key != null && !string.IsNullOrEmpty(key))
                    {
                        bool keyExists = dicData.TryGetValue(olValue, out value);
                        if (!keyExists) value = olValue;
                        newVal = key + CONST.STRING_DOT + value + " ";

                        valueInput = valueInput.Replace(val, newVal);
                    }
                }

                lstDoc[i] = valueInput;
            }

            txColumnResult.Text = string.Join(CONST.STRING_ADD_LINE, lstDoc.ToArray());

            btColumnCopy.Enabled = false;
            if (!string.IsNullOrEmpty(txColumnResult.Text))
            {
                btColumnCopy.Enabled = true;
            }
        }

        private void btColumnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txColumnResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txColumnResult.Text);
        }

        private void btColumnReset_Click(object sender, EventArgs e)
        {
            rbColumnTable.Checked = true;

            txColumnSearch.Text = "";
            txColumnInput.Text = "";

            cbColumnTable.SelectedIndex = -1;
            cbColumnFormat.SelectedIndex = -1;

            setDataTable();
        }

        private void btColumnClear_Click(object sender, EventArgs e)
        {
            txColumnData.Text = "";

            rbColumnTable.Checked = true;

            txColumnSearch.Text = "";
            txColumnInput.Text = "";

            cbColumnTable.Items.Clear();
            cbColumnFormat.SelectedIndex = -1;

            gridColumnData.DataSource = null;
            gridColumnData.Rows.Clear();
        }

        #endregion

        #region Tab Create Comment

        private void txtCrCmComment_Click(object sender, EventArgs e)
        {
            txtCrCmComment.SelectAll();
        }

        private void txtCrCmComment_TextChanged(object sender, EventArgs e)
        {
            lstInputComment.Clear();
            lstInputComment = txtCrCmComment.Text.Replace("\t", "").Split(DELI, StringSplitOptions.None).ToList();

            if (lstInputComment.Count > 0)
            {
                lblCrCmNumComment.Visible = true;
                lblCrCmNumComment.Text = string.Concat(CONST.TEXT_LINE_NUM, lstInputComment.Count);
            }
            else
            {
                lblCrCmNumComment.Visible = false;
            }
        }

        private void txtCrCmComment_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrCmComment.Text)) createComment();
        }

        private void txtCrCmCode_Click(object sender, EventArgs e)
        {
            txtCrCmCode.SelectAll();
        }

        private void txtCrCmCode_TextChanged(object sender, EventArgs e)
        {
            lstInputCode.Clear();
            lstInputCode = txtCrCmCode.Text.Replace("\t", "").Split(DELI, StringSplitOptions.None).ToList();

            if (lstInputCode.Count > 0)
            {
                lblCrCmNumCode.Visible = true;
                lblCrCmNumCode.Text = string.Concat(CONST.TEXT_LINE_NUM, lstInputCode.Count);
            }
            else
            {
                lblCrCmNumCode.Visible = false;
            }
        }

        private void txtCrCmCode_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCrCmCode.Text)) createComment();
        }

        private void rbCrCmFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmFirst.Checked)
            {
                rbCrCmBlock.Visible = true;
                createComentLocation = 0;

                createComment();
            }
        }

        private void rbCrCmLast_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmLast.Checked)
            {
                rbCrCmBlock.Visible = false;
                createComentLocation = 1;

                createComment();
            }
        }

        private void rbCrCmLineBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmLineBlock.Checked)
            {
                createComentMode =0 ;

                createComment();
            }
        }

        private void rbCrCmBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmBlock.Checked)
            {
                createComentMode = 1;

                createComment();
            }
        }

        private void rbCrCmLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmLine.Checked)
            {
                createComentMode = 1;

                createComment();
            }
        }

        private void chkCrCmLine_CheckedChanged(object sender, EventArgs e)
        {
            createComment();
        }

        private void createComment()
        {
            try
            {
                txtCrCmResult.Clear();

                if ((lstInputCode.Count == lstInputComment.Count) || (lstInputComment.Count > 0 && lstInputCode.Count == 1))
                {
                    string template = getFormatComment();
                    int maxLengthRow = 0;
                    bool isBlankLine = chkCrCmLine.Checked;

                    int mode = 0;
                    if (rbCrCmLine.Checked) mode = 1;

                    for (int i = 0; i < lstInputComment.Count; i++)
                    {
                        string comment = lstInputComment[i];
                        string input = lstInputCode[0];
                        string element = string.Empty;

                        if (string.IsNullOrEmpty(comment)) continue;

                        if (lstInputCode.Count > 1) input = lstInputCode[i];

                        // Add comment first
                        if (createComentLocation == 0)
                        {
                            element = string.Format(template, comment, input);
                        }
                        // Add comment last
                        else
                        {
                            element = string.Format(template, input, comment);
                        }

                        maxLengthRow = getLengthText(mode, element, maxLengthRow);

                        if (i < lstInputComment.Count - 1) txtResult.Text += CONST.STRING_ADD_LINE;
                        txtCrCmResult.Text += element;
                    }

                    if (createComentLocation == 1) txtCrCmResult.Text = CUtils.FormatCode(mode, txtCrCmResult.Text, maxLengthRow, isBlankLine);

                    txtCrCmResult.Text = CUtils.removeLastLineBlank(txtCrCmResult.Text);

                    btCrCmCopy.Enabled = false;
                    lblCrCmCopy.Visible = false;
                    if (!string.IsNullOrEmpty(txtCrCmResult.Text))
                    {
                        btCrCmCopy.Enabled = true;
                    }
                }
                else
                {
                    if (lstInputComment.Count > 0 && txtCrCmCode.Focused) return;

                    MessageBox.Show(CONST.MESS_COMMON_CREATE_COMMENT, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Create Comment") + ex.Message, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string getFormatComment()
        {
            StringBuilder stringBuilder = new StringBuilder();
            switch (createComentMode)
            {
                // line block
                case 0:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("/** {0} */\r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_ADD_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} /** {1} */" + CONST.STRING_ADD_LINE);
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_ADD_LINE);

                    return stringBuilder.ToString();
                // line
                case 1:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("// {0} \r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_ADD_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} // {1}" + CONST.STRING_ADD_LINE);
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_ADD_LINE);

                    return stringBuilder.ToString();
                // block
                case 2:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("/**\r\n");
                        stringBuilder.Append(" * {0}\r\n");
                        stringBuilder.Append(" */\r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_ADD_LINE);
                    }
                    
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_ADD_LINE);

                    return stringBuilder.ToString();
                
                default:
                    return string.Empty;
            }
        }

        private void btCrCmCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrCmResult.Text))
            {
                lblCrCmCopy.Visible = false;
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCrCmResult.Text);
            lblCrCmCopy.Visible = true;
        }

        private void btCrCmClear_Click(object sender, EventArgs e)
        {
            rbCrCmFirst.Checked = true;
            rbCrCmLineBlock.Checked = true;
            chkCrCmLine.Checked = true;

            txtCrCmComment.Text = string.Empty;
            txtCrCmCode.Text = string.Empty;
            txtCrCmResult.Text = string.Empty;

            btCrCmCopy.Enabled = false;
            lblCrCmCopy.Visible = false;
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

        private int getLengthText(int mode, string line, int maxLengthRow)
        {
            int lengthText;

            string charComment = "/**";
            if (mode == 1) charComment = "//";

            if (line.Contains(CONST.STRING_APPEND))
            {
                lengthText = line.LastIndexOf(charComment);
            }
            else
            {
                lengthText = line.LastIndexOf(charComment) + 1;
            }

            if (lengthText > maxLengthRow)
            {
                return lengthText;
            }

            return maxLengthRow;
        }

        #endregion
    }
}
