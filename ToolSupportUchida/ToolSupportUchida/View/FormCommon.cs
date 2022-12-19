﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolCommon.Models;
using ToolCommon.Service;
using ToolSupportCoding.Common;
using ToolSupportCoding.Model;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCommon : Form
    {
        private string[] lstKey;
        private string[] stringSeparators;

        private string[] lstMessCode;
        private string[] lstMessContent;

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

        private CreateFileService _createFileService;

        private List<ItemModel> lstItem;

        private ToolSupportModel objToolSupport;

        DataTable table;

        #region Load Form
        public FormCommon(ToolSupportModel objToolSupport)
        {
            InitializeComponent();

            this.objToolSupport = objToolSupport;

            this.lstItem = objToolSupport.lstItem;

            _createFileService = new CreateFileService(this.getAppSettingModel(this.lstItem));

            stringSeparators = new string[] { CONST.STRING_ADD_LINE };
        }

        private void FormCheckDataModel_Load(object sender, EventArgs e)
        {
            txtCase.Focus();

            tabControlCommon.TabPages.Remove(tabPageCreateJson);
            tabControlCommon.TabPages.Remove(tabPageGetColumn);

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
            else if (rbFormatCommentSQL.Checked) mode = 2;

            int maxLengthRow = 0;
            int lengthAppend = -1;

            string result = string.Empty;
            foreach (string line in lstFormatCode)
            {
                string tmpLine = line;
                if (mode != 0) tmpLine = tmpLine.Trim();

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

            for (int i = 0; i < lstDoc.Count; i++)
            {
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

            lblColumnResult.Visible = true;
        }

        private void btColumnReset_Click(object sender, EventArgs e)
        {
            rbColumnTable.Checked = true;

            txColumnSearch.Text = "";
            txColumnInput.Text = "";

            cbColumnTable.SelectedIndex = -1;
            cbColumnFormat.SelectedIndex = -1;

            setDataTable();

            lblColumnResult.Visible = false;
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

            lblColumnResult.Visible = false;
        }

        #endregion

        #region Tab Create Comment

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
                createComentLocation = 0;

                createComment();
            }
        }

        private void rbCrCmLast_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmLast.Checked)
            {
                createComentLocation = 1;

                createComment();
            }
        }

        private void rbCrCmLineBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmLineBlock.Checked)
            {
                createComentMode = 0;

                createComment();
            }
        }

        private void rbCrCmBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCrCmBlock.Checked)
            {
                createComentMode = 2;

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
                    else if (rbCrCmBlock.Checked) mode = 2;

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

                        txtCrCmResult.Text += element;
                        if (createComentLocation == 1 && !isBlankLine) txtCrCmResult.Text += CONST.STRING_ADD_LINE;
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
                    if (lstInputCode.Count > 0 && txtCrCmComment.Focused) return;

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
                        stringBuilder.Append("{0} /** {1} */");
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
                        stringBuilder.Append("{0} // {1}");
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_ADD_LINE);

                    return stringBuilder.ToString();
                // block
                case 2:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("<!-- {0} -->\r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_ADD_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} <!-- {1} -->");
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
                if (input.Length > 6 && input.Substring(0, 6).ToUpper() == CONST.STRING_MSGBOX)
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
        }

        private void btnMessClear_Click(object sender, EventArgs e)
        {
            txtMessCode.Text = string.Empty;
            txtMessContent.Text = string.Empty;
        }
        #endregion

        #region Tab Clone Src 

        private void btnChoosePath_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.txtChoosePath.Text = folderDlg.SelectedPath;
                foreach (ItemModel item in this.lstItem)
                {
                    if (item.key.Equals("sourcePath"))
                    {
                        item.value = folderDlg.SelectedPath;
                    }
                }
            }
            _createFileService = new CreateFileService(this.getAppSettingModel(this.lstItem));
            objToolSupport.lstItem = this.lstItem;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                this.txtViewResult.Text = "";
                this.btnDeleteFileCreated.Visible = false;
                this._createFileService.Generate(txtScreeenSample.Text.Trim(), txtScreenNew.Text.Trim());
                if (rdbFuncProcess.Checked)
                {
                    this._createFileService.editFileWithFunctionAndProcess();
                }
                else if (rdbNoFunc.Checked)
                {
                    this._createFileService.editFileWithoutFunction();
                    this._createFileService.editFileWithFunctionAndProcess();
                }
                this.txtViewResult.Text = this._createFileService.resultData;
                MessageBox.Show(this._createFileService.message);
                this.btnDeleteFileCreated.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteFileCreated_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure?", "Delete Files",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.Yes)
                {
                    this.txtViewResult.Text = this._createFileService.deleteFileCreated(); ;
                    MessageBox.Show(this._createFileService.message);
                    this.btnDeleteFileCreated.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            else if (mode == 2) charComment = "<!--";

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

        private AppSettingModel getAppSettingModel(List<ItemModel> lstItem)
        {
            AppSettingModel appSettingModel = new AppSettingModel
            {
                sourcePath = "D:\\",
                generateSource = new GenerateSource(),
                editSource = new List<EditSource>()
            };

            if (lstItem.Count <= 0) return appSettingModel;

            List<ItemModel> lstCloneSrc = lstItem.Where(i => i.type.Equals("SettingCloneSrc")).ToList();
            appSettingModel.sourcePath = lstCloneSrc.Where(i => i.key.Equals("sourcePath")).ToList()[0].value;
            appSettingModel.generateSource.ignoreFile = lstCloneSrc.Where(i => i.key.Equals("ignoreFile")).ToList()[0].value.Split('%');
            List<ItemModel> lstEditSrc = lstCloneSrc.Where(i => i.key.Equals("editSource")).ToList();
            foreach (ItemModel item in lstEditSrc)
            {
                string[] value = item.value.Split('%');
                appSettingModel.editSource.Add(new EditSource
                {
                    fileType = value[0],
                    functionPattern = value[1],
                    functionKeyword = value[2]
                });
            }
            this.txtChoosePath.Text = appSettingModel.sourcePath;
            return appSettingModel;
        }

        #endregion
    }
}
