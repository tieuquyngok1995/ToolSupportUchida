﻿using System;
using System.Collections.Generic;
using System.Drawing;
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
            Clipboard.Clear();

            if (txtLogicName.Text.Length != 0)
             {
                string[] arrLogicName = txtLogicName.Text.Split(CONST.CHAR_NEW_LINE);
                string result = string.Empty;
                foreach (string item in arrLogicName)
                {
                    result = findSekkeiLogicName(item.Trim());
                    txtPhysiName.Text = txtPhysiName.Text + result + CONST.CHAR_NEW_LINE;
                }

                clearEmptyLine();

                isCopyPhysi = true;
                lblResult.Visible = false;
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
        }

        private void btnConvertLogic_Click(object sender, EventArgs e)
        {
            txtLogicName.Text = string.Empty;
            Clipboard.Clear();

            if (txtPhysiName.Text.Length != 0)
            {
                string[] arrPhysiName = txtPhysiName.Text.Split(CONST.CHAR_NEW_LINE);
                string result = string.Empty;
                foreach (string item in arrPhysiName)
                {
                    result = findSekkeiPhysiName(item.Trim());
                    txtLogicName.Text = txtLogicName.Text + result + CONST.CHAR_NEW_LINE;
                }

                clearEmptyLine();

                isCopyPhysi = false;
                lblResult.Visible = false;
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
        private string findSekkeiLogicName(string nameLogic)
        {
            string result = nameLogic;
            SekkeiModel objSekkei = lstSekkei.Find(item => nameLogic.Contains(item.logicName));

            if (objSekkei == null)
            {
                return result;
            }
            else
            {
                result = result.Replace(objSekkei.logicName, objSekkei.physiName);
                result = findSekkeiLogicName(result);
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
