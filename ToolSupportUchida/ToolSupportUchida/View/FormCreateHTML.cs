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
        private void txtRowCol_TextChanged(object sender, EventArgs e)
        {
            lstRowCol = txtRowCol.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstRowCol.Count > 0)
            {
                lblNumRowCol.Visible = true;
                lblNumRowCol.Text = string.Concat(CONST.TEXT_LINE_NUM, lstRowCol.Count);
            }
            else
            {
                lblNumRowCol.Visible = false;
            }

            if (lstRowCol.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            lstControl = txtControl.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstControl.Count > 0)
            {
                lblNumControl.Visible = true;
                lblNumControl.Text = string.Concat(CONST.TEXT_LINE_NUM, lstControl.Count);
            }
            else
            {
                lblNumControl.Visible = false;
            }

            if (lstControl.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count)
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }
        }

        private void txtResource_TextChanged(object sender, EventArgs e)
        {
            lstResource = txtResource.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstResource.Count > 0)
            {
                lblNumResource.Visible = true;
                lblNumResource.Text = string.Concat(CONST.TEXT_LINE_NUM, lstResource.Count);
            }
            else
            {
                lblNumResource.Visible = false;
            }

            if (lstResource.Count > 0 && lstRowCol.Count == lstControl.Count && lstRowCol.Count == lstResource.Count)
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
            bool isFristRow = false;

            string result = string.Empty;
            string srcCol = string.Empty;

            string tmpRow = getTemplate(CONST.STRING_SETTING_HTML_ROW);
            string tmpCol = getTemplate(CONST.STRING_SETTING_HTML_COL);

            for (int i = 0; i < lstRowCol.Count; i++)
            {
                string col = lstRowCol[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string control = lstControl[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                string resource = lstResource[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (col.Contains(CONST.STRING_SETTING_HTML_ADD_ROW))
                {
                    if (isFristRow)
                    {
                        srcCol = CUtils.removeLastLineBlank(srcCol);
                        result += string.Format(tmpRow, srcCol).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                    }

                    srcCol = string.Empty;
                    col = col.Replace(CONST.STRING_SETTING_HTML_ADD_ROW, string.Empty);

                    isFristRow = true;
                }

                string srcControl = string.Format(getTemplate(control), resource);
                srcCol += string.Format(tmpCol, col, srcControl).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);

                if(isFristRow && lstRowCol.Count -1 == i)
                {
                    srcCol = CUtils.removeLastLineBlank(srcCol);
                    result += string.Format(tmpRow, srcCol).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                }
            }

            txtResult.Text = CUtils.removeLastLineBlank(result);

            if (!string.IsNullOrEmpty(txtResult.Text)) btnCopy.Enabled = true;
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

            txtResource.Text = string.Empty;
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
        #endregion

    }
}
