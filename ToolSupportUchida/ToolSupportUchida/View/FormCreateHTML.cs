using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToolSupportCoding.Model;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCreateHTML : Form
    {
        private List<ItemModel> lstItem;

        private List<string> lstRowCol = new List<string>();
        private List<string> lstControl = new List<string>();
        private List<string> lstResource = new List<string>();
        private List<string> lstModel = new List<string>();

        private Dictionary<string, string> dicSetting = new Dictionary<string, string>();

        #region Load Form
        public FormCreateHTML(List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstItem = lstItem;
        }

        private void FormCreateAdapter_Load(object sender, EventArgs e)
        {
            LoadTheme();

            GetDataSetting();

            txtRowCol.Focus();
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

        private void txtRowCol_Click(object sender, EventArgs e)
        {
            txtRowCol.SelectAll();
            txtRowCol.Focus();
        }

        private void txtRowCol_TextChanged(object sender, EventArgs e)
        {
            lstRowCol = txtRowCol.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstRowCol.Count > 0)
            {
                lblNumRowCol.Visible = true;
                lblNumRowCol.Text = string.Concat(CONST.TEXT_LINE_NUM, lstRowCol.Count);
            }
            else
            {
                lblNumRowCol.Visible = false;
            }

            if (lstRowCol.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count && lstRowCol.Count == lstModel.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void txtControl_Click(object sender, EventArgs e)
        {
            txtControl.SelectAll();
            txtControl.Focus();
        }

        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            lstControl = txtControl.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstControl.Count > 0)
            {
                lblNumControl.Visible = true;
                lblNumControl.Text = string.Concat(CONST.TEXT_LINE_NUM, lstControl.Count);
            }
            else
            {
                lblNumControl.Visible = false;
            }

            if (lstControl.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count && lstRowCol.Count == lstModel.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void txtResource_Click(object sender, EventArgs e)
        {
            txtResource.SelectAll();
            txtResource.Focus();
        }

        private void txtResource_TextChanged(object sender, EventArgs e)
        {
            lstResource = txtResource.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstResource.Count > 0)
            {
                lblNumResource.Visible = true;
                lblNumResource.Text = string.Concat(CONST.TEXT_LINE_NUM, lstResource.Count);
            }
            else
            {
                lblNumResource.Visible = false;
            }

            if (lstResource.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count && lstRowCol.Count == lstModel.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void txtModel_Click(object sender, EventArgs e)
        {
            txtModel.SelectAll();
            txtModel.Focus();
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            lstModel = txtModel.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            if (lstModel.Count > 0)
            {
                lblNumModel.Visible = true;
                lblNumModel.Text = string.Concat(CONST.TEXT_LINE_NUM, lstModel.Count);
            }
            else
            {
                lblNumModel.Visible = false;
            }

            if (lstModel.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count && lstRowCol.Count == lstModel.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;

            try
            {
                if (rbModeHTML.Checked)
                {
                    generateHTML();
                }
                else
                {
                    generateTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Application error exception: " + ex.Message, CONST.TEXT_CAPTION_ERROR,
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtRowCol.Text = string.Empty;
            lstRowCol.Clear();

            txtControl.Text = string.Empty;
            lstControl.Clear();

            txtModel.Text = string.Empty;
            lstResource.Clear();

            btnCreate.Enabled = false;
            btnCopy.Enabled = false;
        }
        #endregion

        #region Method
        private void GetDataSetting()
        {
            List<ItemModel> lstSeting = lstItem.Where(item => item.key.Equals(CONST.STRING_SETTING_HTML)).ToList();

            foreach (ItemModel item in lstSeting)
            {
                if (!string.IsNullOrEmpty(item.name) && !dicSetting.ContainsKey(item.name))
                {
                    dicSetting.Add(item.name, item.value);
                }
            }
        }

        private string getTemplate(string key)
        {
            string result = string.Empty;
            if (dicSetting.TryGetValue(key, out result)) return result;
            return result;
        }

        private void generateHTML()
        {
            bool isFristRow = false;

            string result = string.Empty;
            string srcCol = string.Empty;

            string tmpRow = getTemplate(CONST.STRING_SETTING_HTML_ROW);
            string tmpCol = getTemplate(CONST.STRING_SETTING_HTML_COL);

            for (int i = 0; i < lstRowCol.Count; i++)
            {
                string col = lstRowCol[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string tmp = string.Empty;
                string control = lstControl[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string resource = lstResource[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string model = lstModel[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (!string.IsNullOrEmpty(col))
                {

                    if (col.Contains(CONST.STRING_SETTING_HTML_ADD_ROW))
                    {
                        if (isFristRow)
                        {
                            srcCol = CUtils.RemoveLastLineBlank(srcCol);
                            result += string.Format(tmpRow, srcCol).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                        }

                        srcCol = string.Empty;
                        col = col.Replace(CONST.STRING_SETTING_HTML_ADD_ROW, string.Empty);

                        isFristRow = true;
                    }

                    if (string.IsNullOrEmpty(control)) continue;

                    tmp = getTemplate(control);
                    string srcControl = string.Empty;

                    if (control.Equals(CONST.STRING_SETTING_UCD_LABEL))
                    {
                        if (i + 1 < lstRowCol.Count && !lstModel[i + 1].Equals(CONST.STRING_SETTING_UCD_LABEL))
                        {
                            resource = string.IsNullOrEmpty(lstModel[i + 1]) ? resource : lstModel[i + 1].Replace(CONST.STRING_TAB, string.Empty).Trim();
                        }
                        srcControl = tmp == null ? string.Empty : string.Format(tmp, resource);
                    }
                    else if (control.ToUpper().Equals(CONST.STRING_LABEL))
                    {
                        srcControl = tmp == null ? string.Empty : string.Format(tmp, resource);
                    }
                    else
                    {
                        srcControl = tmp == null ? string.Empty : string.Format(tmp, model);
                    }

                    srcCol += string.Format(tmpCol, col, srcControl).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                }

                if (isFristRow && lstRowCol.Count - 1 == i)
                {
                    srcCol = CUtils.RemoveLastLineBlank(srcCol);
                    result += string.Format(tmpRow, srcCol).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                }
            }

            txtResult.Text = CUtils.RemoveLastLineBlank(result);

            if (!string.IsNullOrEmpty(txtResult.Text)) btnCopy.Enabled = true;
        }

        private void generateTable()
        {
            int totalWidth = 0;
            int numRowHeader = -1;

            int lastRow = lstRowCol.FindLastIndex(x => x.Contains(CONST.STRING_SETTING_HTML_ADD_ROW));
            double totalCol = CUtils.CountTotal(lstRowCol);

            string dataSource = string.Empty;
            string headerRow = string.Empty;
            string headerColumns = string.Empty;
            string colgroup = string.Empty;
            string rowContainer = string.Empty;
            string row = string.Empty;

            string tmpTable = getTemplate(CONST.STRING_SETTING_HTML_TABLE);
            string tmpTableColumns = getTemplate(CONST.STRING_SETTING_HTML_TABLE_COLUMNS);
            string tmpTableButton = getTemplate(CONST.STRING_SETTING_HTML_TABLE_BUTTON);
            string tmpTableContainer = getTemplate(CONST.STRING_SETTING_HTML_TABLE_CONTAINER);
            string tmpTableHeaderRow = getTemplate(CONST.STRING_SETTING_HTML_TABLE_HEADER_ROW);
            string tmpTableRow = getTemplate(CONST.STRING_SETTING_HTML_TABLE_ROW);
            string tmpTableColGroup = getTemplate(CONST.STRING_SETTING_HTML_TABLE_COLGROUP);
            string[] arrTmpTableColGroup = tmpTableColGroup.Split(CONST.CHAR_TILDE);

            Dictionary<int, string> dicHeaderRow = new Dictionary<int, string>();

            for (int i = 0; i < lstRowCol.Count; i++)
            {
                string col = lstRowCol[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string rowSpan = string.Empty;
                string colSpan = string.Empty;
                string control = lstControl[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string resource = lstResource[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string model = lstModel[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (string.IsNullOrEmpty(col)) continue;

                if (col.Equals(CONST.STRING_SETTING_HTML_ADD_ROW))
                {
                    dataSource = model.Replace(CONST.STRING_VIEW_MODEL, CONST.STRING_DATA_SOURCE);
                    continue;
                }
                else if (col.Contains(CONST.STRING_SETTING_HTML_ADD_ROW))
                {
                    if (numRowHeader != -1)
                    {
                        dicHeaderRow.Add(numRowHeader, headerColumns);
                        headerColumns = string.Empty;
                    }

                    numRowHeader = numRowHeader + 1;
                }

                string column = lstRowCol[i].Replace(CONST.STRING_SETTING_HTML_ADD_ROW, string.Empty);
                string[] arrColumn = column.Split(CONST.CHAR_COMMA);
                if (arrColumn.Length > 2)
                {
                    column = arrColumn[0];

                    if (!string.IsNullOrEmpty(arrColumn[1])) rowSpan = CUtils.CreHTMLRowSpan(arrColumn[1]);
                    if (!string.IsNullOrEmpty(arrColumn[2])) colSpan = CUtils.CreHTMLColSpan(arrColumn[2]);
                }

                int width = getWidth(column, totalCol);
                if (width + totalWidth > 100)
                {
                    width = 100 - totalWidth;
                }
                else
                {
                    totalWidth += width;
                }

                if (control.ToUpper().Equals(CONST.STRING_BUTTON))
                {
                    colgroup += arrTmpTableColGroup[0] + CONST.STRING_ADD_LINE;
                    rowContainer += string.Format(tmpTableButton, resource, rowSpan + colSpan).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                }
                else
                {
                    string rowControl = string.Format(getTemplate(control), model);
                    string rowContainerTmp = string.Format(tmpTableContainer, resource, rowSpan + colSpan, rowControl).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                    if (string.IsNullOrEmpty(rowSpan) && i < lastRow)
                    {
                        rowContainerTmp = rowContainerTmp.Replace(CONST.STRING_SETTING_HTML_CLASS_STICKY, string.Empty);
                    }
                    colgroup += string.Format(arrTmpTableColGroup[1], width) + CONST.STRING_ADD_LINE;
                    rowContainer += rowContainerTmp;
                }

                if (string.IsNullOrEmpty(resource) || resource.Equals(CONST.STRING_SETTING_HTML_ADD_ROW))
                {
                    headerColumns += CONST.STRING_APOSTROPHE + CONST.STRING_APOSTROPHE + CONST.STRING_COMMA;
                }
                else
                {
                    headerColumns += string.Format(tmpTableColumns, resource);
                }
            }

            if (!string.IsNullOrEmpty(headerColumns))
            {
                if (numRowHeader != -1)
                {
                    dicHeaderRow.Add(numRowHeader, headerColumns);

                    foreach (KeyValuePair<int, string> item in dicHeaderRow)
                    {
                        int index = item.Value.LastIndexOf(CONST.CHAR_COMMA);
                        string val = index != -1 ? item.Value.Remove(index, 1) : item.Value;
                        headerRow += string.Format(tmpTableHeaderRow, val);
                        row += string.Format(tmpTableRow, val);
                    }

                    tmpTable = tmpTable.Replace(CONST.STRING_SETTING_HTML_MAT_TABLE, CONST.STRING_SETTING_HTML_MAT_TABLE + CONST.STRING_SETTING_HTML_MAT_TABLE_MULTI);

                }
                else
                {
                    int index = headerColumns.LastIndexOf(CONST.CHAR_COMMA);
                    headerColumns = index != -1 ? headerColumns.Remove(index, 1) : headerColumns;
                    headerRow = string.Format(tmpTableHeaderRow, headerColumns);
                    row = string.Format(tmpTableRow, headerColumns);
                }
            }

            txtResult.Text = string.Format(tmpTable, dataSource, colgroup, CUtils.RemoveLastLineBlank(rowContainer), headerRow, row).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
            if (!string.IsNullOrEmpty(txtResult.Text)) btnCopy.Enabled = true;
        }

        private int getWidth(string col, double totalCol)
        {
            return Convert.ToInt32(Math.Round((Convert.ToInt32(col) / totalCol) * 100, MidpointRounding.AwayFromZero));
        }

        private bool isNumber(string str)
        {
            if (int.TryParse(str, out _))
            {
                return true;
            }
            return false;
        }
        #endregion

    }
}
