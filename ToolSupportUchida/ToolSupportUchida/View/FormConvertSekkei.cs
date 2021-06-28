using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportUchida.Model;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.View
{
    public partial class FormConvertSekkei : Form
    {
        private bool isCopyPhysi;
        private List<SekkeiModel> lstSekkei;

        private const string reduceMultiSpace = @"[ ]{2,}";

        #region Load Form
        public FormConvertSekkei(List<SekkeiModel> lstSekkei)
        {
            InitializeComponent();

            this.isCopyPhysi = true;
            this.lstSekkei = lstSekkei;
        }

        private void FormConvertSekkei_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
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

        private void btnConvertPhysi_Click(object sender, EventArgs e)
        {
            txtPhysiName.Text = string.Empty;

            if (txtLogicName.Text.Length != 0)
             {
                string[] arrLogicName = txtLogicName.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                string result = string.Empty;
                foreach (string item in arrLogicName)
                {
                    result = findSekkeiLogicName(lstSekkei, item.Trim());
                    txtPhysiName.Text = txtPhysiName.Text + result.Replace(CONST.STRING_SPACE, string.Empty) + CONST.STRING_ADD_LINE;
                }

                txtPhysiName.Text = Regex.Replace(txtPhysiName.Text, CONST.REGEX_REMOVE_LINE, string.Empty, RegexOptions.Multiline);
                txtLogicName.Text = Regex.Replace(txtLogicName.Text, CONST.REGEX_REMOVE_LINE, string.Empty, RegexOptions.Multiline);

                clearEmptyLine();

                isCopyPhysi = true;
                lblResult.Visible = false;
                btnCopy.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLogicName.Text = string.Empty;
            txtPhysiName.Text = string.Empty;

            txtLogicName.Focus();
            btnCopy.Enabled = false;
            lblResult.Visible = false;
        }

        private void btnConvertLogic_Click(object sender, EventArgs e)
        {
            txtLogicName.Text = string.Empty;

            if (txtPhysiName.Text.Length != 0)
            {
                string[] arrPhysiName = txtPhysiName.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);
                string result = string.Empty;
                foreach (string item in arrPhysiName)
                {
                    result = findSekkeiPhysiName(item.Trim());
                    txtLogicName.Text = txtLogicName.Text + result.Replace(CONST.STRING_SPACE, string.Empty) + CONST.STRING_ADD_LINE;
                }

                txtPhysiName.Text = Regex.Replace(txtPhysiName.Text, CONST.REGEX_REMOVE_LINE, string.Empty, RegexOptions.Multiline);
                txtLogicName.Text = Regex.Replace(txtLogicName.Text, CONST.REGEX_REMOVE_LINE, string.Empty, RegexOptions.Multiline);

                clearEmptyLine();

                isCopyPhysi = false;
                lblResult.Visible = false;
                btnCopy.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (isCopyPhysi && !string.IsNullOrEmpty(txtPhysiName.Text))
            {

                Clipboard.SetText(txtPhysiName.Text);
                lblResult.Visible = true;
            }
            else if (!isCopyPhysi && !string.IsNullOrEmpty(txtLogicName.Text))
            {
                Clipboard.SetText(txtLogicName.Text);
                lblResult.Visible = true;
            }
        }
        #endregion

        #region Method
        private string findSekkeiLogicName(List<SekkeiModel> lstSekkei, string nameLogic)
        {
            string result = nameLogic;

            List<SekkeiModel> lstSekkeiTmp = new List<SekkeiModel>();
            lstSekkeiTmp.AddRange(lstSekkei);
            SekkeiModel objSekkei = lstSekkeiTmp.Find(obj => nameLogic.Contains(obj.logicName));

            if (objSekkei == null)
            {
                return result;
            }
            else
            {
                result = result.Replace(objSekkei.logicName, objSekkei.physiName);
                lstSekkeiTmp.RemoveAll(obj => obj.logicName.Equals(objSekkei.logicName) && obj.physiName.Equals(objSekkei.physiName));
                result = findSekkeiLogicName(lstSekkeiTmp, result);
            }

            return result;
        }

        private string findSekkeiPhysiName(string namePhysi)
        {
            string result = namePhysi;
            SekkeiModel objSekkei = lstSekkei.Find(item => namePhysi.Contains(item.physiName));

            if (objSekkei == null)
            {
                return result;
            }
            else
            {
                result = result.Replace(objSekkei.physiName, objSekkei.logicName);
                result = findSekkeiPhysiName(result);
            }

            return result;
        }

        private void clearEmptyLine()
        {
            txtPhysiName.Text = txtPhysiName.Text.Replace(CONST.STRING_DOUBLE_LINE, CONST.STRING_NEW_LINE);
            txtLogicName.Text = txtLogicName.Text.Replace(CONST.STRING_DOUBLE_LINE, CONST.STRING_NEW_LINE);
        }
        #endregion
    }
}
