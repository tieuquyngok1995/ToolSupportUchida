using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportCoding.Common;
using ToolSupportCoding.Model;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCommon : Form
    {
        DataTable table;
        private ToolSupportModel objToolSupport;
        private List<ItemModel> lstItem = new List<ItemModel>();
        private Dictionary<string, string> dicSetting = new Dictionary<string, string>();

        // List using get column
        private Dictionary<string, Dictionary<string, string>> dicColumnData = new Dictionary<string, Dictionary<string, string>>();
        private Dictionary<string, string> dicColumnTable = new Dictionary<string, string>();

        // List get View Model
        private List<string> lstGetVMItem = new List<string>();
        private List<string> lstGetVMFunItem = new List<string>();
        private List<string> lstGetVMFunProperty = new List<string>();

        private Dictionary<string, string> dicFunction = new Dictionary<string, string>();

        // List get Item Resource
        private List<string> lstGetIResItem = new List<string>();
        private List<string> lstGetIResControl = new List<string>();
        private List<string> lstGetIRes = new List<string>();

        // List create JSON
        private string[] lstKey;

        // List create entity
        private string[] lstEntityProcedure;
        private List<ViewModel> lstEntityVM = new List<ViewModel>();
        private List<ViewModel> lstEntityTable = new List<ViewModel>();

        // List create source

        private string createSourcePath;
        private string[] lstSourceLogic;
        private string[] lstSourcePhysical;
        private string[] lstSourcePath;

        // List create report
        private string reportPath;
        private List<string> lstReportItemName = new List<string>();
        private List<string> lstReportSetting = new List<string>();

        // List create comment
        private int createComentLocation = 0;
        private int createComentMode = 0;
        private List<string> lstInputComment = new List<string>();
        private List<string> lstInputCode = new List<string>();

        // List create resources
        private string[] lstResourcesName;
        private string[] lstResourcesValue;
        private string[] lstResourcesComment;

        private List<ItemModel> lstResKey = new List<ItemModel>();

        // List format 
        private string[] lstFormatCode;

        #region Load Form
        public FormCommon(ToolSupportModel _objToolSupport, List<ItemModel> _lstItem)
        {
            InitializeComponent();

            objToolSupport = _objToolSupport;
            createSourcePath = objToolSupport.sourcePath;
            reportPath = _objToolSupport.reportPath;

            lstItem = _lstItem;
        }

        private void FormCheckDataModel_Load(object sender, EventArgs e)
        {
            txColumnData.Focus();

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
            int currentTab = tabControlCommon.SelectedIndex;

            switch (tabControlCommon.TabPages[currentTab].Text)
            {
                case CONST.TAB_GET_NAME:
                    txColumnData.Focus();
                    break;
                case CONST.TAB_GET_VIEW_MODEL:
                    txtGetVMSItem.Focus();
                    break;
                case CONST.TAB_GET_GET_ITEM_RESOURCE:
                    txtGetIResItem.Focus();
                    break;
                case CONST.TAB_CR_JSON:
                    txtCase.Focus();
                    break;
                case CONST.TAB_CR_ENTITY:
                    getSetting(currentTab);
                    txtCrEntityP.Focus();
                    break;
                case CONST.TAB_CR_FILE_SRC:
                    txtCrSourceFolderP.Text = objToolSupport.sourcePath;
                    txtCrSourceFolderP.Focus();
                    break;
                case CONST.TAB_CR_REPORTS:
                    getSetting(currentTab);
                    txtCreReportPath.Text = reportPath;
                    txtCreReportName.Focus();
                    break;
                case CONST.TAB_CR_COMMENT:
                    txtCrCmComment.Focus();
                    break;

                case CONST.TAB_FORMAT_COMMENT:
                    txtFormatCode.Focus();
                    break;
                case CONST.TAB_CR_RESOURCES:
                    txtCrResName.Focus();
                    lstResKey = objToolSupport.lstItem.Where(item => item.key.Equals(CONST.STRING_RESOURCES)).ToList();
                    break;
            }
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
                column.Width = 122;
                column = gridColumnData.Columns[1];
                column.HeaderText = "Logic Table";
                column.Width = 122;
                column = gridColumnData.Columns[2];
                column.HeaderText = "Physical Name";
                column.Width = 140;
                column = gridColumnData.Columns[3];
                column.HeaderText = "Logic Name";
                column.Width = 144;
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

            List<string> lstDoc = txColumnDoc.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

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

            txColumnResult.Text = string.Join(CONST.STRING_NEW_LINE, lstDoc.ToArray());

            btColumnCopy.Enabled = false;
            if (!string.IsNullOrEmpty(txColumnResult.Text))
            {
                btColumnCopy.Enabled = true;
            }
        }

        private void BtColumnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txColumnResult.Text)) return;

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

        private void BtColumnClear_Click(object sender, EventArgs e)
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

        #region Tab Get View Model
        /// <summary>
        /// Event select all text after click text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMSItem_Click(object sender, EventArgs e)
        {
            txtGetVMSItem.SelectAll();
            txtGetVMSItem.Focus();
        }

        /// <summary>
        /// Event handel data after input value to text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMSItem_TextChanged(object sender, EventArgs e)
        {
            lstGetVMItem = txtGetVMSItem.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetVMItem.Count > 0)
            {
                lblGetVMSItem.Visible = true;
                lblGetVMSItem.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetVMItem.Count);
            }
            else
            {
                lblGetVMSItem.Visible = false;
            }

            if (lstGetVMItem.Count == 0 || lstGetVMFunItem.Count == 0 || lstGetVMFunItem.Count != lstGetVMFunProperty.Count)
            {
                btGetVMGenSrc.Enabled = false;
            }
            else
            {
                btGetVMGenSrc.Enabled = true;
            }
        }

        /// <summary>
        /// Event select all text after click text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMFunItem_Click(object sender, EventArgs e)
        {
            txtGetVMFunItem.SelectAll();
            txtGetVMFunItem.Focus();
        }

        /// <summary>
        /// Event handel data after input value to text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMFunItem_TextChanged(object sender, EventArgs e)
        {
            lstGetVMFunItem = txtGetVMFunItem.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetVMFunItem.Count > 0)
            {
                lblGetVMFunItem.Visible = true;
                lblGetVMFunItem.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetVMFunItem.Count);
            }
            else
            {
                lblGetVMFunItem.Visible = false;
            }

            if (lstGetVMItem.Count == 0 || lstGetVMFunItem.Count == 0 || lstGetVMFunItem.Count != lstGetVMFunProperty.Count)
            {
                btGetVMGenSrc.Enabled = false;
            }
            else
            {
                btGetVMGenSrc.Enabled = true;
            }
        }

        /// <summary>
        /// Event select all text after click text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMFunPro_Click(object sender, EventArgs e)
        {
            txtGetVMFunPro.SelectAll();
            txtGetVMFunPro.Focus();
        }

        /// <summary>
        /// Event handel data after input value to text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtGetVMFunPro_TextChanged(object sender, EventArgs e)
        {
            lstGetVMFunProperty = txtGetVMFunPro.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetVMFunProperty.Count > 0)
            {
                lblGetVMFunPro.Visible = true;
                lblGetVMFunPro.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetVMFunProperty.Count);
            }
            else
            {
                lblGetVMFunPro.Visible = false;
            }

            if (lstGetVMItem.Count == 0 || lstGetVMFunItem.Count == 0 || lstGetVMFunItem.Count != lstGetVMFunProperty.Count)
            {
                btGetVMGenSrc.Enabled = false;
            }
            else
            {
                btGetVMGenSrc.Enabled = true;
            }
        }

        /// <summary>
        /// Event gen srcouce 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetVMGenSrc_Click(object sender, EventArgs e)
        {
            txtGetVMResultPhysical.Text = string.Empty;

            if (dicFunction.Count > 0) dicFunction.Clear();

            for (int i = 0; i < lstGetVMFunItem.Count; i++)
            {
                string key = lstGetVMFunItem[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string value = lstGetVMFunProperty[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (string.IsNullOrEmpty(key) || dicFunction.ContainsKey(key)) continue;

                dicFunction.Add(key, value);
            }

            for (int i = 0; i < lstGetVMItem.Count; i++)
            {
                string item = lstGetVMItem[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                string keyVM = string.Empty;
                if (dicFunction.TryGetValue(item, out keyVM))
                {
                    txtGetVMResultPhysical.Text += keyVM + CONST.STRING_NEW_LINE;
                }
                else
                {
                    txtGetVMResultPhysical.Text += CONST.STRING_NEW_LINE;
                }
            }

            if (!string.IsNullOrEmpty(txtGetVMResultPhysical.Text))
            {
                btGetVMCopyPhysical.Enabled = true;
            }
        }

        /// <summary>
        /// Event copy result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetVMCopyPhysical_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetVMResultPhysical.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtGetVMResultPhysical.Text);
        }

        /// <summary>
        /// Event clear value 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btGetVMClear_Click(object sender, EventArgs e)
        {

            txtGetVMSItem.Text = string.Empty;
            lblGetVMSItem.Visible = false;
            lstGetVMItem.Clear();

            txtGetVMFunItem.Text = string.Empty;
            lblGetVMFunItem.Visible = false;
            lstGetVMFunItem.Clear();

            txtGetVMFunPro.Text = string.Empty;
            lblGetVMFunPro.Visible = false;
            lstGetVMFunProperty.Clear();

            txtGetVMResultPhysical.Text = string.Empty;

            btGetVMGenSrc.Enabled = false;
            btGetVMCopyPhysical.Enabled = false;
        }
        #endregion

        #region Tab Get Item Resource
        private void txtGetIResItem_Click(object sender, EventArgs e)
        {
            txtGetIResItem.SelectAll();
            txtGetIResItem.Focus();
        }

        private void txtGetIResItem_TextChanged(object sender, EventArgs e)
        {
            lstGetIResItem = txtGetIResItem.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetIResItem.Count > 0)
            {
                lblGetIResItem.Visible = true;
                lblGetIResItem.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetIResItem.Count);
            }
            else
            {
                lblGetIResItem.Visible = false;
            }

            if (lstGetIResItem.Count > 0 && lstGetIResItem.Count == lstGetIResControl.Count && lstGetIResItem.Count == lstGetIRes.Count)
            {
                btGetIRes.Enabled = true;
            }
            else
            {
                btGetIRes.Enabled = false;
                btGetIResCopy.Enabled = false;
            }
        }

        private void txtGetIResControl_Click(object sender, EventArgs e)
        {
            txtGetIResControl.SelectAll();
            txtGetIResControl.Focus();
        }

        private void txtGetIResControl_TextChanged(object sender, EventArgs e)
        {
            lstGetIResControl = txtGetIResControl.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetIResControl.Count > 0)
            {
                lblGetIResControl.Visible = true;
                lblGetIResControl.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetIResControl.Count);
            }
            else
            {
                lblGetIResControl.Visible = false;
            }

            if (lstGetIResItem.Count > 0 && lstGetIResItem.Count == lstGetIResControl.Count && lstGetIResItem.Count == lstGetIRes.Count)
            {
                btGetIRes.Enabled = true;
            }
            else
            {
                btGetIRes.Enabled = false;
                btGetIResCopy.Enabled = false;
            }
        }

        private void txtGetIRes_Click(object sender, EventArgs e)
        {
            txtGetIRes.SelectAll();
            txtGetIRes.Focus();
        }

        private void txtGetIRes_TextChanged(object sender, EventArgs e)
        {
            lstGetIRes = txtGetIRes.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstGetIRes.Count > 0)
            {
                lblGetIRes.Visible = true;
                lblGetIRes.Text = string.Concat(CONST.TEXT_LINE_NUM, lstGetIRes.Count);
            }
            else
            {
                lblGetIRes.Visible = false;
            }

            if (lstGetIResItem.Count > 0 && lstGetIResItem.Count == lstGetIResControl.Count && lstGetIResItem.Count == lstGetIRes.Count)
            {
                btGetIRes.Enabled = true;
            }
            else
            {
                btGetIRes.Enabled = false;
                btGetIResCopy.Enabled = false;
            }
        }

        private void btGetIRes_Click(object sender, EventArgs e)
        {
            txtGetIResResult.Text = string.Empty;

            string oldItem = string.Empty;
            string oldResource = string.Empty;

            for (int idx = 0; idx < lstGetIResItem.Count; idx++)
            {
                string control = lstGetIResControl[idx].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string item = lstGetIResItem[idx].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (control.Equals(CONST.STRING_SETTING_UCD_LABEL) || control.Equals(CONST.STRING_SETTING_LABEL))
                {
                    oldItem = item;
                    oldResource = lstGetIRes[idx].Replace(CONST.STRING_TAB, string.Empty).Trim();

                    txtGetIResResult.Text += oldResource + CONST.STRING_NEW_LINE;
                }
                else
                {
                    if (item.Contains(oldItem))
                    {
                        txtGetIResResult.Text += oldResource + CONST.STRING_NEW_LINE;
                    }
                    else
                    {
                        txtGetIResResult.Text += CONST.STRING_NEW_LINE;
                    }
                }
            }

            if (!string.IsNullOrEmpty(txtGetIResResult.Text))
            {
                btGetIResCopy.Enabled = true;
            }
            else
            {
                btGetIResCopy.Enabled = false;
            }
        }

        private void btGetIResCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGetIResResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtGetIResResult.Text);
        }

        private void btGetIResClear_Click(object sender, EventArgs e)
        {
            txtGetIResControl.Text = string.Empty;
            txtGetIRes.Text = string.Empty;

            txtGetIResResult.Text = string.Empty;
            btGetIRes.Enabled = false;
            btGetIResCopy.Enabled = false;
        }
        #endregion

        #region Tab Create JSON
        private void txtInputKey_TextChanged(object sender, EventArgs e)
        {
            lstKey = txtInputKey.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
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
                result = "{" + CONST.STRING_NEW_LINE;
                tab = CUtils.CreateTab(ref indexTab);
                template = CUtils.CreTmlCommonCaseOut(tab);
                result = result + string.Format(template, txtCase.Text.Trim(), txtOut.Text.Trim());
                result = result + "{" + CONST.STRING_NEW_LINE;
            }
            else if (rdbCreateObj.Checked)
            {
                result = "[" + CONST.STRING_NEW_LINE;
                tab = CUtils.CreateTab(ref indexTab);
                result = result + tab + "{" + CONST.STRING_NEW_LINE;
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
                    result = result + string.Format(template, key) + "[{" + CONST.STRING_NEW_LINE;
                    isList = true;
                    tab = CUtils.CreateTab(ref indexTab);
                }
                else if (numTab > (indexTab - 2))
                {
                    template = CUtils.CreTmlCommonObj(tab);
                    result = result + string.Format(template, key) + "{" + CONST.STRING_NEW_LINE;
                    tab = CUtils.CreateTab(ref indexTab);
                }
                else if (value.Contains(CONST.STRING_COMMA))
                {
                    string[] lstValue = value.Split(CONST.CHAR_COMMA);
                    lstValue = lstValue.Where(x => !string.IsNullOrEmpty(x)).ToArray();

                    template = CUtils.CreTmlCommonAddArr(tab, isLast);
                    result = result + string.Format(template, key, AddComman(lstValue));
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
                        result = result + tab + "}]" + CONST.STRING_NEW_LINE;
                        isList = false;
                    }
                    else
                    {
                        tab = CUtils.RemoveTab(ref indexTab);
                        result = result + tab + "}" + CONST.STRING_NEW_LINE;
                    }
                }

                index++;
            }

            while (indexTab > 0)
            {
                tab = CUtils.RemoveTab(ref indexTab);
                if (indexTab == 0 && rdbCreateObj.Checked)
                {
                    result = result + tab + "]" + CONST.STRING_NEW_LINE;
                }
                else
                {
                    result = result + tab + "}" + CONST.STRING_NEW_LINE;
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
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.Clear();
            Clipboard.SetText(txtResult.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtInputKey.Text = string.Empty;
            txtResult.Text = string.Empty;

            gridInputParam.Rows.Clear();
            gridInputParam.Refresh();

            displayItem(false);
        }
        #endregion

        #region Tab Create Entity

        private void rbCrEntityGet_CheckedChanged(object sender, EventArgs e)
        {
            grbCrEntityP.Text = "Script Procedure";
            txtCrEntityP.Enabled = true;

            grbCrEntityT.Text = "Script Table";

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else if (lstEntityTable != null && (rbCrEntitySet.Checked || rbCrEntityTarget.Checked))
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }

        private void rbCrEntitySet_CheckedChanged(object sender, EventArgs e)
        {
            grbCrEntityP.Text = "Script Procedure";
            txtCrEntityP.Enabled = false;
            txtCrEntityP.Text = string.Empty;

            grbCrEntityT.Text = "Script Table";

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else if (lstEntityTable != null && (rbCrEntitySet.Checked || rbCrEntityTarget.Checked))
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }

        private void rbCrEntityMap_CheckedChanged(object sender, EventArgs e)
        {
            grbCrEntityP.Text = "Input ViewModel";
            txtCrEntityP.Enabled = true;

            grbCrEntityT.Text = "Script Table";

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else if (lstEntityTable != null && (rbCrEntitySet.Checked || rbCrEntityTarget.Checked))
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }

        private void rbCrEntityTarget_CheckedChanged(object sender, EventArgs e)
        {
            grbCrEntityP.Text = "Script Procedure";
            txtCrEntityP.Enabled = false;
            txtCrEntityP.Text = string.Empty;

            grbCrEntityT.Text = "Script Table";

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else if (lstEntityTable != null && (rbCrEntitySet.Checked || rbCrEntityTarget.Checked))
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }


        private void txtCrEntityP_Click(object sender, EventArgs e)
        {
            txtCrEntityP.SelectAll();
            txtCrEntityP.Focus();
        }

        private void txtCrEntityP_TextChanged(object sender, EventArgs e)
        {
            lstEntityProcedure = txtCrEntityP.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstEntityProcedure.Length > 0)
            {
                if (rbCrEntityMap.Checked)
                {
                    lstEntityVM = new List<ViewModel>();
                    foreach (var item in lstEntityProcedure)
                    {
                        if (string.IsNullOrEmpty(item)) continue;

                        string[] arrItem = CUtils.FormatTab(item).Split(CONST.CHAR_TAB);

                        if (arrItem.Length > 1)
                        {
                            string name = arrItem[0].Trim();
                            string type = arrItem[1].Trim();

                            lstEntityVM.Add(new ViewModel(name, type));
                        }
                    }
                }
                lblCrEntityNumP.Visible = true;
                lblCrEntityNumP.Text = string.Concat(CONST.TEXT_LINE_NUM, lstEntityProcedure.Length);
            }
            else
            {
                lblCrEntityNumP.Visible = false;
            }

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }


        private void txtCrEntityT_Click(object sender, EventArgs e)
        {
            txtCrEntityT.SelectAll();
            txtCrEntityT.Focus();
        }

        private void txtCrEntityT_TextChanged(object sender, EventArgs e)
        {
            string[] arrTable = txtCrEntityT.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (arrTable.Length > 0)
            {
                lstEntityTable = new List<ViewModel>();
                foreach (var item in arrTable)
                {
                    if (string.IsNullOrEmpty(item)) continue;

                    string[] arrItem = item.Replace(CONST.STRING_C_O_SQU_BRACKETS_SPACE, CONST.STRING_C_SQU_BRACKETS_SPACE)
                                            .Split(CONST.STRING_SEPARATORS_TABLE, StringSplitOptions.None);
                    if (arrItem.Length > 1)
                    {
                        string name = arrItem[0].Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_COMMA, string.Empty).Trim();
                        string type = arrItem[1];

                        int index = type.LastIndexOf(CONST.STRING_C_SQU_BRACKETS);
                        if (index != -1) type = type.Substring(0, index);

                        index = type.LastIndexOf(CONST.STRING_O_BRACKETS);
                        if (index != -1) type = type.Substring(0, index);

                        type = CUtils.ConvertSQLToCType(type);

                        lstEntityTable.Add(new ViewModel(name, type));
                    }
                }

                lblCrEntityNumT.Visible = true;
                lblCrEntityNumT.Text = string.Concat(CONST.TEXT_LINE_NUM, arrTable.Length);
            }
            else
            {
                lblCrEntityNumT.Visible = false;
            }

            if (lstEntityProcedure != null && lstEntityTable != null)
            {
                btnCrEntity.Enabled = true;
            }
            else if (lstEntityTable != null && (rbCrEntitySet.Checked || rbCrEntityTarget.Checked))
            {
                btnCrEntity.Enabled = true;
            }
            else
            {
                btnCrEntity.Enabled = false;
            }
        }

        private void btnCrEntity_Click(object sender, EventArgs e)
        {
            txtCrEntityResult.Text = string.Empty;

            if (rbCrEntityGet.Checked)
            {
                txtCrEntityResult.Text = CUtils.RemoveLastLineBlank(createEntityGet());
            }
            else if (rbCrEntitySet.Checked)
            {
                txtCrEntityResult.Text = CUtils.RemoveLastLineBlank(createEntitySet());
            }
            else if (rbCrEntityMap.Checked)
            {
                txtCrEntityResult.Text = CUtils.RemoveLastLineBlank(createEntityMapper());
            }
            else
            {
                txtCrEntityResult.Text = createEntityTarget();
            }

            if (!string.IsNullOrEmpty(txtCrEntityResult.Text)) btnCrEntityCopy.Enabled = true;
        }

        private string createEntityGet()
        {
            string result = string.Empty;
            for (int i = 0; i < lstEntityProcedure.Length; i++)
            {

                if (string.IsNullOrEmpty(lstEntityProcedure[i])) continue;

                if (!lstEntityProcedure[i].ToUpper().Contains(CONST.STRING_CHECK_SQL_AS)) continue;

                // Handle Logic and Physical
                string[] item = lstEntityProcedure[i].Replace(CONST.STRING_TAB, string.Empty).Split(new string[]
                { CONST.STRING_CHECK_SQL_TABLE, CONST.STRING_CHECK_SQL_TABLE_NOT, CONST.STRING_DOT,
                  CONST.STRING_CHECK_SQL_AS, CONST.STRING_CHECK_SQL_AS.ToLower() }, StringSplitOptions.None);
                string logic, physical, type;

                if (item.Length >= 3)
                {
                    logic = item[1].Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_C_SQU_BRACKETS, string.Empty)
                                   .Replace(CONST.STRING_COMMA, string.Empty).Trim();
                    physical = item[2].Trim();
                }
                else if (item.Length >= 2)
                {
                    logic = item[0].Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_C_SQU_BRACKETS, string.Empty)
                                   .Replace(CONST.STRING_COMMA, string.Empty).Trim();
                    physical = item[1].Trim();
                }
                else
                {
                    logic = item[0].Replace(CONST.STRING_O_SQU_BRACKETS, string.Empty).Replace(CONST.STRING_C_SQU_BRACKETS, string.Empty)
                                   .Replace(CONST.STRING_COMMA, string.Empty).Trim();
                    physical = logic;
                }
                logic = logic.Replace(CONST.STRING_COMMA, string.Empty).Replace(CONST.STRING_O_BRACKETS, string.Empty).Replace(CONST.STRING_C_BRACKETS, string.Empty);
                physical = physical.Replace(CONST.STRING_COMMA, string.Empty).Replace(CONST.STRING_O_BRACKETS, string.Empty).Replace(CONST.STRING_C_BRACKETS, string.Empty);

                ViewModel itemModel = lstEntityTable.Where(obj => obj.name.Equals(logic)).FirstOrDefault();
                if (itemModel != null)
                {
                    type = CUtils.AddDefaultTypeC(itemModel.type);
                }
                else
                {
                    type = CONST.C_TYPE_STRING;
                }

                string tmp = CUtils.CreTmlModelC(0);
                if (rbCrEntityBlock.Checked)
                {
                    tmp = CUtils.CreTmlModelC(1);
                }
                else if (rbCrEntityMutilLine.Checked)
                {
                    tmp = CUtils.CreTmlModelC(2);
                }

                result += string.Format(tmp, logic, type, physical) + CONST.STRING_ADD_LINE;
                result += CONST.STRING_ADD_LINE;
            }

            return result;
        }

        private string createEntitySet()
        {
            string result = string.Empty;
            for (int i = 0; i < lstEntityTable.Count; i++)
            {
                ViewModel vm = lstEntityTable[i];
                if (vm == null || string.IsNullOrEmpty(vm.name) || string.IsNullOrEmpty(vm.type)) continue;
                if (vm.name.ToUpper().Contains(CONST.STRING_CREATE_TABLE)) continue;

                string logic = vm.name;
                string type = vm.type;
                if (!string.IsNullOrEmpty(type))
                {
                    type = CUtils.AddDefaultTypeC(type);
                }

                string tmp = CUtils.CreTmlModelC(0);
                if (rbCrEntityBlock.Checked)
                {
                    tmp = CUtils.CreTmlModelC(1);
                }
                else if (rbCrEntityMutilLine.Checked)
                {
                    tmp = CUtils.CreTmlModelC(2);
                }

                result += string.Format(tmp, logic, type, logic) + CONST.STRING_ADD_LINE;
                result += CONST.STRING_ADD_LINE;
            }

            return result;
        }

        private string createEntityMapper()
        {
            string result = string.Empty;
            string tmp = string.Empty;

            if (!dicSetting.TryGetValue(CONST.STRING_SETTING_COMMON_ENTITY_MAPPER, out tmp)) return string.Empty;

            for (int i = 0; i < lstEntityTable.Count; i++)
            {
                ViewModel entity = lstEntityTable[i];
                if (entity == null || string.IsNullOrEmpty(entity.name) || string.IsNullOrEmpty(entity.type)) continue;

                ViewModel viewModel = lstEntityVM.Where(obj => obj.name.Equals(entity.name)).FirstOrDefault();
                if (viewModel != null)
                {
                    result += string.Format(tmp, entity.name, viewModel.type);
                }
                else
                {
                    result += string.Format(tmp, entity.name, string.Empty);
                }
                result += CONST.STRING_ADD_LINE;
            }
            return result;
        }

        private string createEntityTarget()
        {
            string result = string.Empty;
            string resultSqlMetaData = string.Empty;
            string resultSqlDataRecord = string.Empty;

            string tmpSqlMetaData = string.Empty;
            if (!dicSetting.TryGetValue(CONST.STRING_SETTING_COMMON_ENTITY_SQL_META, out tmpSqlMetaData)) return string.Empty;

            string tmpSqlDataRecord = string.Empty;
            if (!dicSetting.TryGetValue(CONST.STRING_SETTING_COMMON_ENTITY_RECORD, out tmpSqlDataRecord)) return string.Empty;

            string tmp = string.Empty;
            if (!dicSetting.TryGetValue(CONST.STRING_SETTING_COMMON_ENTITY_TARGET, out tmp)) return string.Empty;

            for (int i = 0; i < lstEntityTable.Count; i++)
            {
                ViewModel vm = lstEntityTable[i];
                if (vm == null || string.IsNullOrEmpty(vm.name) || string.IsNullOrEmpty(vm.type)) continue;

                resultSqlMetaData += string.Format(tmpSqlMetaData, vm.name, CUtils.CastTypeCToSqlMetaData(vm.type)) + CONST.STRING_ADD_LINE;

                string sqlDataRecord = CUtils.CastTypeCToSqlDataRecord(vm.type);
                string value = vm.name;
                if (CUtils.IsDefaultTypeC(vm.type))
                {
                    value = string.Format(CUtils.CreTmlCheckValueC(), vm.name, sqlDataRecord.Replace(CONST.STRING_SET, string.Empty));
                }
                resultSqlDataRecord += string.Format(tmpSqlDataRecord, sqlDataRecord, i, value) + CONST.STRING_ADD_LINE;
            }

            result = string.Format(tmp, CUtils.RemoveLastLineBlank(resultSqlMetaData), CUtils.RemoveLastLineBlank(resultSqlDataRecord)).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);

            return result;
        }

        private void btnCrEntityCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrEntityResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCrEntityResult.Text);
        }

        private void btnCrEntityClear_Click(object sender, EventArgs e)
        {
            txtCrEntityP.Text = string.Empty;
            lblCrEntityNumP.Visible = false;

            txtCrEntityT.Text = string.Empty;
            lblCrEntityNumT.Visible = false;

            txtCrEntityResult.Text = string.Empty;

            btnCrEntity.Enabled = false;
            btnCrEntityCopy.Enabled = false;
        }
        #endregion

        #region Tab Create File Source

        private void txtCrSourceFolderP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrSourceFolderP.Text))
            {
                return;
            }

            barCrSourceProcess.Value = 0;
            objToolSupport.sourcePath = this.txtCrSourceFolderP.Text;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void btCrSourceOpenPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (!string.IsNullOrEmpty(reportPath)) fbd.SelectedPath = createSourcePath;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtCrSourceFolderP.Text = fbd.SelectedPath;
                createSourcePath = fbd.SelectedPath;

                objToolSupport.sourcePath = createSourcePath;
                BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
            }
        }

        private void txtCrSourceLogic_Click(object sender, EventArgs e)
        {
            txtCrSourceLogic.SelectAll();
            txtCrSourceLogic.Focus();
        }

        private void txtCrSourceLogic_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrSourceLogic.Text)) return;

            lstSourceLogic = txtCrSourceLogic.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstSourceLogic.Length > 0)
            {
                lblCrSourceLogic.Visible = true;
                lblCrSourceLogic.Text = string.Concat(CONST.TEXT_LINE_NUM, lstSourceLogic.Length);
            }
            else
            {
                lblCrSourceLogic.Visible = false;
            }

            if (lstSourceLogic != null && lstSourcePhysical != null && lstSourcePath != null)
            {
                btCrSource.Enabled = true;
            }
            else
            {
                btCrSource.Enabled = false;
            }

            barCrSourceProcess.Value = 0;
        }

        private void txtCrSourcePhysical_Click(object sender, EventArgs e)
        {
            txtCrSourcePhysical.SelectAll();
            txtCrSourcePhysical.Focus();
        }

        private void txtCrSourcePhysical_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrSourcePhysical.Text))
            {
                btCrSource.Enabled = false;
                return;
            }

            lstSourcePhysical = txtCrSourcePhysical.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstSourcePhysical.Length > 0)
            {
                lblCrSourcePhysical.Visible = true;
                lblCrSourcePhysical.Text = string.Concat(CONST.TEXT_LINE_NUM, lstSourcePhysical.Length);
            }
            else
            {
                lblCrSourcePhysical.Visible = false;
            }

            if (lstSourcePhysical != null && lstSourcePath != null && lstSourcePhysical.Length == lstSourcePath.Length)
            {
                btCrSource.Enabled = true;
            }
            else
            {
                btCrSource.Enabled = false;
            }

            barCrSourceProcess.Value = 0;
        }

        private void txtCrSourcePath_Click(object sender, EventArgs e)
        {
            txtCrSourcePath.SelectAll();
            txtCrSourcePath.Focus();
        }

        private void txtCrSourcePath_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrSourcePath.Text))
            {
                btCrSource.Enabled = false;
                return;
            }

            lstSourcePath = txtCrSourcePath.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstSourcePath.Length > 0)
            {
                lblCrSourcePath.Visible = true;
                lblCrSourcePath.Text = string.Concat(CONST.TEXT_LINE_NUM, lstSourcePath.Length);
            }
            else
            {
                lblCrSourcePath.Visible = false;
            }

            if (lstSourcePhysical != null && lstSourcePath != null && lstSourcePhysical.Length == lstSourcePath.Length)
            {
                btCrSource.Enabled = true;
            }
            else
            {
                btCrSource.Enabled = false;
            }

            barCrSourceProcess.Value = 0;
            barCrSourceProcess.Maximum = lstSourcePath.Length - 1;
        }

        private void btCrSource_Click(object sender, EventArgs e)
        {
            string srcPath = txtCrSourceFolderP.Text;
            barCrSourceProcess.Value = 0;

            for (int i = 0; i < lstSourcePath.Length; i++)
            {
                if (string.IsNullOrEmpty(lstSourcePath[i])) continue;

                string logicName = lstSourceLogic[i].Replace(CONST.STRING_TAB, string.Empty);
                string fileName = lstSourcePhysical[i].Replace(CONST.STRING_TAB, string.Empty);
                string path = lstSourcePath[i].Replace(CONST.STRING_TAB, string.Empty);

                if (path.Last() != '/') path = path + CONST.STRING_SLASH;

                string dir = srcPath + path;
                if (dir.Contains(CONST.STRING_ENTITIES)) dir = dir.Remove(dir.LastIndexOf(CONST.STRING_ENTITIES)) + CONST.STRING_ENTITIES + CONST.STRING_SLASH;

                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

                if (!File.Exists(dir + fileName + CONST.C_TYPE_FILE))
                {
                    string text = string.Empty;
                    if (fileName.Contains(CONST.STRING_CONTROLLER))
                    {
                        text = CUtils.CreTmlFileControllerC(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                    else if (fileName.Contains(CONST.STRING_SERVICE))
                    {
                        text = CUtils.CreTmlFileServiceC(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                    else if (fileName.Contains(CONST.STRING_REPOSITORY))
                    {
                        text = CUtils.CreTmlFileRepositoryC(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                    else if (fileName.Contains(CONST.STRING_VIEW_MODEL))
                    {
                        text = CUtils.CreTmlFileViewModelC(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                    else if (fileName.Contains(CONST.STRING_ENTITY))
                    {
                        text = CUtils.CreTmlFileEntityC(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                    else if (fileName.Contains(CONST.STRING_PARAMETERS))
                    {
                        text = CUtils.CreTmlFileParameters(logicName, fileName, path);
                        File.WriteAllText(dir + fileName + CONST.C_TYPE_FILE, text);
                    }
                }

                // Update process
                UpdateProcess();
            }
        }

        private void btCrSourceClear_Click(object sender, EventArgs e)
        {
            txtCrSourceLogic.Text = string.Empty;
            lblCrSourceLogic.Visible = false;

            txtCrSourcePhysical.Text = string.Empty;
            lblCrSourcePhysical.Visible = false;

            txtCrSourcePath.Text = string.Empty;
            lblCrSourcePath.Visible = false;

            barCrSourceProcess.Value = 0;
        }
        #endregion

        #region Tab Create Report

        /// <summary>
        /// Event select path folder report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreReportPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (!string.IsNullOrEmpty(reportPath)) fbd.SelectedPath = reportPath;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtCreReportPath.Text = fbd.SelectedPath;
                    reportPath = fbd.SelectedPath;

                    objToolSupport.reportPath = reportPath;
                    BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event select all text input report name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportName_Click(object sender, EventArgs e)
        {
            txtCreReportName.SelectAll();
            txtCreReportName.Focus();
        }

        /// <summary>
        /// Event change text report name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCreReportName.Text) && !txtCreReportName.Text.Contains(CONST.STRING_REPORT_NAME))
            {
                txtCreReportName.Text += CONST.STRING_REPORT_NAME;
            }
        }

        /// <summary>
        /// Event select all text input report item name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportItemName_Click(object sender, EventArgs e)
        {
            txtCreReportItemName.SelectAll();
            txtCreReportItemName.Focus();
        }

        /// <summary>
        /// Event change value in report item name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportItemName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreReportItemName.Text)) return;

            lstReportItemName = txtCreReportItemName.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstReportItemName.Count > 0)
            {
                lblCreReportItemName.Visible = true;
                lblCreReportItemName.Text = string.Concat(CONST.TEXT_LINE_NUM, lstReportItemName.Count);
            }
            else
            {
                lblCreReportItemName.Visible = false;
            }

            btCreReport.Enabled = lstReportSetting.Count == lstReportItemName.Count ? true : false;
        }

        /// <summary>
        /// Event select all text input report setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportSetting_Click(object sender, EventArgs e)
        {
            txtCreReportSetting.SelectAll();
            txtCreReportSetting.Focus();
        }

        /// <summary>
        /// Event change value in report setting
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtCreReportSetting_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreReportSetting.Text)) return;

            lstReportSetting = txtCreReportSetting.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstReportSetting.Count > 0)
            {
                lblCreReportSetting.Visible = true;
                lblCreReportSetting.Text = string.Concat(CONST.TEXT_LINE_NUM, lstReportSetting.Count);
            }
            else
            {
                lblCreReportSetting.Visible = false;
            }

            btCreReport.Enabled = lstReportSetting.Count == lstReportItemName.Count ? true : false;
        }

        /// <summary>
        /// Event create report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreReport_Click(object sender, EventArgs e)
        {
            try
            {
                int top = 0;
                string template = string.Empty;
                string control = string.Empty;
                string result = string.Empty;
                txtCreReportResult.Text = result;
                Dictionary<string, int> dicNameItem = new Dictionary<string, int>();
                for (int i = 0; i < lstReportSetting.Count; i++)
                {
                    top = i == 1 ? 284 : 284 * i;

                    string nameItem = lstReportItemName[i].Replace(CONST.STRING_TAB, string.Empty).Replace(CONST.STRING_SPACE, string.Empty)
                        .Replace(CONST.STRING_O_BRACKETS, string.Empty).Replace(CONST.STRING_C_BRACKETS, string.Empty)
                        .Replace(CONST.STRING_O_BRACKETS_2B, string.Empty).Replace(CONST.STRING_C_BRACKETS_2B, string.Empty)
                        .Replace(CONST.STRING_DOT, string.Empty).Replace(CONST.STRING_DOT_2B, string.Empty).Trim();
                    if (string.IsNullOrEmpty(nameItem)) continue;
                    if (dicNameItem.ContainsKey(nameItem))
                    {
                        int index = dicNameItem[nameItem] + 1;
                        dicNameItem[nameItem] = index;
                        nameItem = nameItem + index;
                    }
                    else
                    {
                        dicNameItem.Add(nameItem, 0);
                    }

                    if (string.IsNullOrEmpty(lstReportSetting[i].Replace(CONST.STRING_TAB, string.Empty))) continue;
                    string[] arrSetting = CUtils.FormatTab(lstReportSetting[i]).Trim().Split(CONST.CHAR_TAB);

                    string fontSize = string.Empty;
                    if (arrSetting.Length > 0 && (arrSetting[0].Equals(CONST.STRING_JP_FONT_SIZE) || arrSetting[1].ToUpper().Equals(CONST.STRING_VN_FONT_SIZE)))
                        fontSize = CONST.STRING_REPORT_CLASS_NAME;

                    string algin = string.Empty;
                    if (arrSetting.Length > 1 && (arrSetting[1].Equals(CONST.STRING_JP_ALIGN_CENTER) || arrSetting[1].ToUpper().Equals(CONST.STRING_VN_ALIGN_CENTER)))
                        algin = CONST.STRING_REPORT_ALIGN_CENTER;
                    if (arrSetting.Length > 1 && (arrSetting[1].Equals(CONST.STRING_JP_ALIGN_RIGHT) || arrSetting[1].ToUpper().Equals(CONST.STRING_VN_ALIGN_RIGHT)))
                        algin = CONST.STRING_REPORT_ALIGN_RIGHT;

                    string type = arrSetting.Length > 2 ? arrSetting[2] + CONST.STRING_REPORT : string.Empty;

                    dicSetting.TryGetValue(type, out template);
                    if (string.IsNullOrEmpty(template)) continue;
                    string dataField = arrSetting.Length > 5 ? arrSetting[5] : nameItem.Replace(CONST.STRING_JP_ITEM + CONST.STRING_UNDERSCORE, string.Empty);
                    if (!nameItem.Contains(CONST.STRING_JP_ITEM)) nameItem = CONST.STRING_JP_ITEM + CONST.STRING_UNDERSCORE + nameItem;

                    if (type.Equals(CONST.STRING_LABEL_REPORT))
                    {
                        control += string.Format(template, nameItem, top, algin, fontSize);
                    }
                    else if (type.Equals(CONST.STRING_FIELD_REPORT))
                    {
                        control += string.Format(template, nameItem, top, algin, fontSize, dataField);
                    }
                    else if (type.Equals(CONST.STRING_CHECKBOX_REPORT) || type.Equals(CONST.STRING_SUB_REPORT))
                    {
                        control += string.Format(template, nameItem, top, dataField);
                    }
                    else
                    {
                        control += string.Format(template, nameItem, top);
                    }
                }

                if (string.IsNullOrEmpty(txtCreReportName.Text))
                {
                    result = control.Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                    txtCreReportResult.Text = result;
                }
                else
                {
                    dicSetting.TryGetValue(CONST.STRING_SETTING_COMMON_FORMAT_REPORT, out template);
                    result = string.Format(template, control).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                    txtCreReportResult.Text = result;

                    string pathFile = txtCreReportPath.Text + "/" + txtCreReportName.Text;
                    if (!Directory.Exists(txtCreReportPath.Text)) Directory.CreateDirectory(txtCreReportPath.Text);

                    if (File.Exists(pathFile))
                    {
                        string pathFileBk = pathFile.Replace(CONST.STRING_REPORT_NAME, CONST.STRING_BACKUP_NAME);
                        if (File.Exists(pathFileBk)) File.Delete(pathFileBk);

                        File.Copy(pathFile, pathFileBk);
                        File.Delete(pathFile);
                    }

                    File.WriteAllText(pathFile, result);
                }

                btCreReportCopy.Enabled = !string.IsNullOrEmpty(result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error during processing.\r\nError detail: " + ex.Message, "Error Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Event copy result report 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreReportCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCreReportResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCreReportResult.Text);
        }

        /// <summary>
        /// Event clear report
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btCreReportClear_Click(object sender, EventArgs e)
        {
            txtCreReportItemName.Text = string.Empty;
            lblCreReportItemName.Visible = false;
            txtCreReportSetting.Text = string.Empty;
            lblCreReportSetting.Visible = false;
            txtCreReportResult.Text = string.Empty;

            btCreReport.Enabled = false;
            btCreReportCopy.Enabled = false;
        }
        #endregion

        #region Tab Create Comment

        private void txtCrCmComment_TextChanged(object sender, EventArgs e)
        {
            lstInputComment.Clear();
            lstInputComment = txtCrCmComment.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

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
            lstInputCode = txtCrCmCode.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

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
                        if (createComentLocation == 1 && !isBlankLine) txtCrCmResult.Text += CONST.STRING_NEW_LINE;
                    }

                    if (createComentLocation == 1) txtCrCmResult.Text = CUtils.FormatCode(mode, txtCrCmResult.Text, maxLengthRow, isBlankLine);

                    txtCrCmResult.Text = CUtils.RemoveLastLineBlank(txtCrCmResult.Text);

                    btCrCmCopy.Enabled = false;
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
                        stringBuilder.Append("{1}" + CONST.STRING_NEW_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} /** {1} */");
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_NEW_LINE);

                    return stringBuilder.ToString();
                // line
                case 1:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("// {0} \r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_NEW_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} // {1}");
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_NEW_LINE);

                    return stringBuilder.ToString();
                // block
                case 2:
                    if (createComentLocation == 0)
                    {
                        stringBuilder.Append("<!-- {0} -->\r\n");
                        stringBuilder.Append("{1}" + CONST.STRING_NEW_LINE);
                    }
                    else
                    {
                        stringBuilder.Append("{0} <!-- {1} -->");
                    }
                    if (chkCrCmLine.Checked) stringBuilder.Append(CONST.STRING_NEW_LINE);

                    return stringBuilder.ToString();

                default:
                    return string.Empty;
            }
        }

        private void btCrCmCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrCmResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCrCmResult.Text);
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
        }

        #endregion

        #region Tab Create Resources

        private void txtCrResName_TextChanged(object sender, EventArgs e)
        {
            lstResourcesName = txtCrResName.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstResourcesName.Length > 0)
            {
                lblCrResName.Visible = true;
                lblCrResName.Text = string.Concat(CONST.TEXT_LINE_NUM, lstResourcesName.Length);
            }
            else
            {
                lblCrResName.Visible = false;
            }

            if (lstResourcesName != null && lstResourcesValue != null)
            {
                btCrRes.Enabled = true;
            }
            else
            {
                btCrRes.Enabled = false;
            }
        }

        private void txtCrResValue_TextChanged(object sender, EventArgs e)
        {
            lstResourcesValue = txtCrResValue.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstResourcesValue.Length > 0)
            {
                lblCrResValue.Visible = true;
                lblCrResValue.Text = string.Concat(CONST.TEXT_LINE_NUM, lstResourcesValue.Length);
            }
            else
            {
                lblCrResValue.Visible = false;
            }

            if (lstResourcesName != null && lstResourcesValue != null)
            {
                btCrRes.Enabled = true;
            }
            else
            {
                btCrRes.Enabled = false;
            }
        }

        private void txtCrResComment_TextChanged(object sender, EventArgs e)
        {
            lstResourcesComment = txtCrResComment.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);

            if (lstResourcesComment.Length > 0)
            {
                lblCrResComment.Visible = true;
                lblCrResComment.Text = string.Concat(CONST.TEXT_LINE_NUM, lstResourcesComment.Length);
            }
            else
            {
                lblCrResComment.Visible = false;
            }
        }

        private void btCrRes_Click(object sender, EventArgs e)
        {
            txtCrResResult.Text = string.Empty;

            string mode = rbCrResC.Checked ? rbCrResC.Text : rbCrResAngular.Text;
            List<ItemModel> lstKey = lstResKey.Where(item => item.name.Contains(mode)).ToList();

            string tmpResources = string.Empty;
            string tmpValue = string.Empty;
            string tmpComment = string.Empty;
            string result = string.Empty;

            foreach (ItemModel item in lstKey)
            {
                if (item.name.Contains(CONST.STRING_RESOURCES)) tmpResources = item.value;
                if (item.name.Contains(CONST.STRING_VALUE)) tmpValue = item.value;
                if (item.name.Contains(CONST.STRING_COMMENT)) tmpComment = item.value;
            }

            for (int i = 0; i < lstResourcesName.Length; i++)
            {
                string name = lstResourcesName[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                string value = lstResourcesValue[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                value = value.Replace(CONST.STRING_BR, CONST.STRING_BR_REPLACE);

                string comment = string.Empty;
                if (lstResourcesComment != null && lstResourcesComment.Length > 0 && lstResourcesComment.Length > i)
                {
                    comment = lstResourcesComment[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                    comment = string.Format(tmpComment, comment);
                }

                if (string.IsNullOrEmpty(name)) continue;

                if (rbCrResC.Checked)
                {
                    value = string.Format(tmpValue, value);
                    result = string.Format(tmpResources, name, value, comment);
                }
                else
                {
                    result = !string.IsNullOrEmpty(comment) ? comment + CONST.STRING_NEW_LINE : string.Empty;
                    result += string.Format(tmpResources, name, value, comment) + CONST.STRING_NEW_LINE;
                }

                txtCrResResult.Text += result + CONST.STRING_NEW_LINE;
            }

            if (!string.IsNullOrEmpty(txtCrResResult.Text))
            {
                btCrResCopy.Enabled = true;
            }
        }

        private void btCrResCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCrResResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtCrResResult.Text);
        }

        private void btCrResClear_Click(object sender, EventArgs e)
        {
            rbCrRes.Checked = true;

            txtCrResName.Text = string.Empty;
            txtCrResValue.Text = string.Empty;
            txtCrResComment.Text = string.Empty;
            txtCrResResult.Text = string.Empty;

            btCrRes.Enabled = false;
            btCrResCopy.Enabled = false;
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

                result += tmpLine + CONST.STRING_NEW_LINE;
            }

            txtFormatResult.Text = CUtils.FormatCode(mode, result, maxLengthRow);
            txtFormatResult.Text = Regex.Replace(txtFormatResult.Text, @"^\s+$[\n]*", string.Empty, RegexOptions.Multiline);

            if (txtFormatResult.Text.LastIndexOf("\n") == (txtFormatResult.Text.Length - 1))
            {
                txtFormatResult.Text = txtFormatResult.Text.Substring(0, txtFormatResult.Text.Length - 1);
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

        #region Method
        private void getSetting(int mode)
        {
            dicSetting.Clear();
            List<ItemModel> lstSetting = new List<ItemModel>();

            switch (mode)
            {
                case 4:
                    lstSetting = lstItem.Where(item => item.key.Equals(CONST.STRING_SETTING_COMMON_ENTITY)).ToList();
                    break;
                case 6:
                    lstSetting = lstItem.Where(item => item.key.Equals(CONST.STRING_SETTING_COMMON_REPORT)).ToList();
                    break;
                default: break;
            }

            foreach (ItemModel item in lstSetting)
            {
                dicSetting.Add(item.name, item.value);
            }
        }

        private string AddComman(string[] lst)
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

        /// <summary>
        /// Update Progress bar
        /// </summary>
        private void UpdateProcess()
        {
            if (barCrSourceProcess.Value < barCrSourceProcess.Maximum)
            {
                barCrSourceProcess.Value++;
                int percent = (int)(((double)barCrSourceProcess.Value / (double)barCrSourceProcess.Maximum) * 100);
                barCrSourceProcess.CreateGraphics().DrawString("File creation process: " + percent.ToString() + "%", new Font("Microsoft Sans Serif", (float)10, FontStyle.Regular),
                    Brushes.Black, new PointF(barCrSourceProcess.Width / 4 + 10, barCrSourceProcess.Height / 2 - 7));
                Application.DoEvents();
            }
        }
        #endregion
    }
}
