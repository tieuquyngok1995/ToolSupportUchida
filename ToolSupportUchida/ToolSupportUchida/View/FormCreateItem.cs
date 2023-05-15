using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportCoding.Model;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCreateItem : Form
    {
        private List<ItemModel> lstItem;

        #region Load Form
        public FormCreateItem(List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstItem = lstItem;
        }

        private void FormCreateAdapter_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in groupBoxSetting.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control btns in groupBoxResult.Controls)
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
        private void btnGetItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtInputCode.Text)) return;

            List<string> lstCode = new List<string>();
            lstCode = txtInputCode.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            gridSetParam.Rows.Clear();
            gridSetParam.Refresh();

            if (lstCode.Count <= 0) return;

            int numOpen = 0, numClose = 0, rowIndex = 0, rowCount = 1;
            bool isExit = false, isClose = true;
            string rowTmp = string.Empty;
            ItemModel objItem = new ItemModel();
            List<string> lstKey = lstItem.Select(obj => obj.key).ToList();

            for (int i = 0; i < lstCode.Count; i++)
            {
                string row = lstCode[i];

                if (isClose)
                {
                    isExit = lstItem.Any(obj => row.Contains(obj.name));
                }
                else
                {
                    rowTmp += row;
                    rowCount++;
                    numOpen += row.Split(CONST.CHAR_O_BRACKETS).Length - 1;
                    numClose += row.Split(CONST.CHAR_C_BRACKETS).Length - 1;

                    if (numOpen == numClose)
                    {
                        string action = objItem.key.Equals(CONST.STRING_DEL) ? CONST.STRING_DEL :
                                       (objItem.key.Equals(CONST.STRING_REPLACE) ? CONST.STRING_REPLACE : CONST.STRING_EDIT);

                        rowTmp = Regex.Replace(rowTmp, @"\s", "");
                        gridSetParam.Rows.Add(rowIndex, objItem.name, rowTmp.Trim(), action, objItem.value, rowCount);
                        rowCount = 1;
                        isClose = true;
                    }
                    else if (numClose > numOpen)
                    {
                        rowCount = 1;
                        isExit = false;
                        isClose = true;
                    }
                }

                if (isExit)
                {
                    rowIndex = i + 1;

                    numOpen = row.Split(CONST.CHAR_O_BRACKETS).Length - 1;
                    numClose = row.Split(CONST.CHAR_C_BRACKETS).Length - 1;

                    objItem = lstItem.FirstOrDefault(obj => row.Contains(obj.name));

                    if (numOpen == numClose)
                    {
                        string action = objItem.key.Equals(CONST.STRING_DEL) ? CONST.STRING_DEL :
                                       (objItem.key.Equals(CONST.STRING_REPLACE) ? CONST.STRING_REPLACE : CONST.STRING_EDIT);

                        gridSetParam.Rows.Add(rowIndex, objItem.name, row.Trim(), action, objItem.value, rowCount);
                        isClose = true;
                    }
                    else
                    {
                        rowTmp = row;
                        isExit = false;
                        isClose = false;
                    }
                }
            }

            if (gridSetParam.Rows.Count > 0)
            {
                btnEdit.Enabled = true;
                txtResult.Text = string.Empty;
                btnCopy.Enabled = true;
                lblResult.Visible = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtInputCode.Text = string.Empty;

            gridSetParam.Rows.Clear();
            gridSetParam.Refresh();

            btnEdit.Enabled = false;
            txtResult.Text = string.Empty;
            btnCopy.Enabled = false;
            lblResult.Visible = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            List<string> lstCode = new List<string>();
            lstCode = txtInputCode.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None).ToList();

            foreach (DataGridViewRow row in gridSetParam.Rows)
            {
                int rowIdx = int.Parse(row.Cells[0].Value.ToString()) - 1;
                int rowCount = int.Parse(row.Cells[5].Value.ToString());

                string value = row.Cells[2].Value.ToString();
                string type = row.Cells[3].Value.ToString();
                string valueAdd = row.Cells[4].Value.ToString();
                string paramAdd = string.Empty;

                if (type.Equals(CONST.STRING_EDIT))
                {
                    if (chkComment.Checked)
                    {
                        lstCode[rowIdx] = CUtils.CreTmlHTMLComment(value);
                    }
                    else
                    {
                        lstCode[rowIdx] = string.Empty;
                    }

                    if (value.Contains(CONST.STRING_FUNCTION))
                    {
                        paramAdd = addProperty(value);
                    }
                    if (value.Contains(CONST.STRING_DATA_BIND))
                    {
                        paramAdd += addDataBind(value);
                    }
                    if (value.Contains(CONST.STRING_TD_CLASS) || value.Contains(CONST.STRING_TD))
                    {
                        valueAdd = editTagTD(value, valueAdd);
                    }

                    if (value.Contains(CONST.STRING_CLASS) || value.Contains(CONST.STRING_CLASS_SP))
                    {
                        valueAdd = addClassColumn(value, valueAdd);
                    }

                    if (rowCount >= 2 && chkComment.Checked)
                    {
                        rowIdx++;
                        lstCode[rowIdx] = valueAdd.Replace("{0}", paramAdd);
                    }
                    else
                    {
                        lstCode[rowIdx] += (chkComment.Checked ? CONST.STRING_NEW_LINE : string.Empty) + valueAdd.Replace("{0}", paramAdd);
                    }

                    int rowTmp = chkComment.Checked ? 3 : 2;
                    while (rowTmp <= rowCount)
                    {
                        rowIdx++;
                        lstCode[rowIdx] = string.Empty;
                        rowTmp++;
                    }
                }
                else if (type.Equals(CONST.STRING_DEL))
                {
                    lstCode[rowIdx] = string.Empty;
                }
                else if (type.Equals(CONST.STRING_REPLACE))
                {
                    lstCode[rowIdx] = valueAdd;
                }
            }

            txtResult.Text = string.Join("\n", lstCode);

            txtResult.Text = editCommentZazor(txtResult.Text);
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

        #endregion

        #region Method

        private string addProperty(string value)
        {
            value = Regex.Replace(value, @"\s", "");
            string[] arr = value.Split(new[] { "(Function(x)" }, StringSplitOptions.None);

            if (arr.Length < 1) return string.Empty;

            arr = arr[1].Replace("})", string.Empty).Split(new[] { ",NewWith" }, StringSplitOptions.None);

            return "[ucdProperty]=\"" + arr[0].Replace("x.", "model.") + "\"";
        }

        private string addDataBind(string value)
        {
            value = Regex.Replace(value, @"\s", "");
            string[] arr = value.Split(new[] { ".data_bind=\"" }, StringSplitOptions.None);

            if (arr.Length < 1) return string.Empty;

            value = arr[1].Replace("\"})", string.Empty);

            return " data-bind=\"" + value + "\"";
        }

        private string editTagTD(string value, string valueAdd)
        {
            string[] arr = value.Split(new char[] { '<', '>' });

            if (arr.Length < 3) return string.Empty;

            return "<" + arr[1] + ">" + valueAdd + "<" + arr[3] + ">";
        }

        private string addClassColumn(string value, string valueAdd)
        {
            string strClass = getClass(value);
            if (!string.IsNullOrEmpty(strClass))
            {
                return "<div class=\"" + strClass + "\">" + CONST.CHAR_NEW_LINE + valueAdd + CONST.CHAR_NEW_LINE + "</div>";
            }
            else
            {
                return valueAdd;
            }
        }

        private string getClass(string value)
        {
            value = Regex.Replace(value, @"\s", "");
            string[] arr = value.Split(new[] { ".class=\"" }, StringSplitOptions.None);

            if (arr.Length < 1) return string.Empty;

            arr = arr[1].Split('"');

            return arr[0].Trim();
        }

        private string editCommentZazor(string value)
        {
            return value.Replace(CONST.STRING_COMMENT_O_ZAZOR, CONST.STRING_COMMENT_O_HTML)
                        .Replace(CONST.STRING_COMMENT_C_ZAZOR, CONST.STRING_COMMENT_C_HTML);
        }
        #endregion

        private void gridSetParam_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridSetParam.IsCurrentCellDirty)
            {
                gridSetParam.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
