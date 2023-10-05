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
    public partial class FormCreateViewModel : Form
    {
        private int isMode = 0;

        private List<SekkeiModel> lstSekkei = new List<SekkeiModel>();
        private List<ItemModel> lstItem = new List<ItemModel>();

        private List<string> lstLogic = new List<string>();
        private List<string> lstPhysical = new List<string>();
        private List<string> lstType = new List<string>();
        private List<string> lstNameItem = new List<string>();
        private List<string> lstValidation = new List<string>();

        private Dictionary<string, string[]> dicValidation = new Dictionary<string, string[]>();

        #region Load Form
        public FormCreateViewModel(int _mode, List<SekkeiModel> _lstSekkei, List<ItemModel> _lstItem)
        {
            isMode = _mode;
            lstSekkei = _lstSekkei;
            lstItem = _lstItem;

            InitializeComponent();
        }

        private void FormCreateViewModel_Load(object sender, EventArgs e)
        {
            if (isMode == 0)
            {
                this.lblLanguage.Text = "C#";
            }
            else
            {
                this.lblLanguage.Text = "TypeScript";
            }
            txtLogicNameVM.Focus();

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

        private void txtPhysicalNameVM_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtLogic_TextChanged(object sender, EventArgs e)
        {
            lstLogic = txtLogic.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstLogic.Count > 0)
            {
                lblNumLogic.Visible = true;
                lblNumLogic.Text = string.Concat(CONST.TEXT_LINE_NUM, lstLogic.Count);
            }
            else
            {
                lblNumLogic.Visible = false;
            }

            if (lstLogic.Count > 0 && (lstNameItem.Count == lstValidation.Count))
            {
                handleDataValidation();
            }

            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtPhysical_TextChanged(object sender, EventArgs e)
        {
            lstPhysical = txtPhysical.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstLogic.Count > 0)
            {
                lblNumPhysical.Visible = true;
                lblNumPhysical.Text = string.Concat(CONST.TEXT_LINE_NUM, lstPhysical.Count);
            }
            else
            {
                lblNumPhysical.Visible = false;
            }

            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            lstType = txtType.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstType.Count > 0)
            {
                lblNumType.Visible = true;
                lblNumType.Text = string.Concat(CONST.TEXT_LINE_NUM, lstType.Count);
            }
            else
            {
                lblNumType.Visible = false;
            }

            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            lstNameItem = txtNameItem.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstNameItem.Count > 0)
            {
                lblNumNameItem.Visible = true;
                lblNumNameItem.Text = string.Concat(CONST.TEXT_LINE_NUM, lstNameItem.Count);
            }
            else
            {
                lblNumNameItem.Visible = false;
            }

            if (lstLogic.Count > 0 && (lstNameItem.Count == lstValidation.Count))
            {
                handleDataValidation();
            }

            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtValidation_TextChanged(object sender, EventArgs e)
        {
            lstValidation = txtValidation.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstValidation.Count > 0)
            {
                lblNumValidation.Visible = true;
                lblNumValidation.Text = string.Concat(CONST.TEXT_LINE_NUM, lstValidation.Count);
            }
            else
            {
                lblNumValidation.Visible = false;
            }

            if (lstLogic.Count > 0 && (lstNameItem.Count == lstValidation.Count))
            {
                handleDataValidation();
            }

            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void btnCreateMess_Click(object sender, EventArgs e)
        {

        }

        private void btnMessCopy_Click(object sender, EventArgs e)
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

        private void btnMessClear_Click(object sender, EventArgs e)
        {
            txtLogicNameVM.Text = string.Empty;
            txtPhysicalNameVM.Text = string.Empty;

            txtLogic.Text = string.Empty;
            lstLogic.Clear();

            txtPhysical.Text = string.Empty;
            lstPhysical.Clear();

            txtType.Text = string.Empty;
            lstType.Clear();

            txtNameItem.Text = string.Empty;
            lstNameItem.Clear();

            txtValidation.Text = string.Empty;
            lstValidation.Clear();

            txtResult.Text = string.Empty;

            btnCreate.Enabled = false;
            btnCopy.Enabled = false;
            lblResult.Visible = false;
        }

        #endregion

        #region Method

        private bool isEnableButtonCreate()
        {
            if (string.IsNullOrEmpty(txtPhysicalNameVM.Text)) return false;

            if (lstLogic.Count != lstPhysical.Count || lstLogic.Count != lstType.Count) return false;

            if (lstNameItem.Count != lstValidation.Count) return false;

            return true;
        }


        private void handleDataValidation()
        {
            dicValidation.Clear();

            for (int i = 0; i < lstValidation.Count; i++)
            {
                string itemVal = lstValidation[i];
                if (string.IsNullOrEmpty(itemVal.Replace(CONST.STRING_TAB, string.Empty))) continue;

                string itemName = lstNameItem[i].Replace(CONST.STRING_TAB, string.Empty);
                string key = lstLogic.FirstOrDefault(item => (itemName.Contains(item)));
                string[] value = itemVal.Split(CONST.CHAR_TAB);

                if (key == null || string.IsNullOrEmpty(key)) continue;
                dicValidation.Add(key, value);
            }
        }
        #endregion

    }
}
