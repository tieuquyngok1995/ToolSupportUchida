﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;

namespace ToolSupportCoding.View
{
    public partial class FormCreateModel : Form
    {
        private int isMode = 0;
        private List<string> lstLogic = new List<string>();

        private List<string> lstPhysi = new List<string>();

        private List<string> lstType = new List<string>();

        private List<string> lstResult = new List<string>();

        private readonly string[] DELI = new[] { "\r\n" };

        private Dictionary<string, string> typeScriptKeyword = new Dictionary<string, string>
    {
        { "function", " = (): void => { \r\n}" },
        { "void", " = (): void => { \r\n}" },

        { "integer", "number" },
        { "string", "string" },
        { "checkbox", "boolean" },
        { "JQuery", "JQuery" },
        { "object[]", "object" },
        { "object", "object" },
        { "List<Record<string, any>>", "Record<string, any>[]" },
        { "Record<string, any>", "Record<string, any>[]" },

        { "float", "number" },
        { "double", "number" },
        { "int", "number" },
        { "decimal", "number" },
        { "long", "number" },
        { "number", "number" },
        { "bool", "boolean" },
        { "boolean", "boolean" },
        { "char", "string" },

        { "button", "button" },
        { "label", "label" },
        { "text", "text" },
        { "radio", "checkbox" },
        { "spread", "spread" },
        { "selectbox", "selectbox" },
    };

        #region Load Form
        public FormCreateModel(int mode)
        {
            this.isMode = mode;
            InitializeComponent();
        }

        private void FormConvertModel_Load(object sender, EventArgs e)
        {
            LoadTheme();

            txtLogic.Focus();

            if (this.isMode == 0)
            {
                this.lbLanguage.Text = "C#";

                this.panelComment.Visible = true;
                this.panelFormat.Visible = false;
                this.panelType.Visible = false;

                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = false;
                this.rdbLast.Visible = false;

                this.chkIsTable.Visible = false;
                this.chkCreateInterf.Visible = false;
            }
            else if (this.isMode == 1)
            {
                this.lbLanguage.Text = "TypeScript";

                this.panelComment.Visible = true;
                this.panelFormat.Visible = true;
                this.panelType.Visible = true;

                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = true;
                this.rdbLast.Visible = true;

                this.chkIsTable.Visible = false;
                this.chkCreateInterf.Visible = true;

                this.rdbFirst.Text = "Set Public";
                this.rdbLast.Text = "Set Private";

                this.chkCreateInterf.Text = "Create Interface";
            }
            if (this.isMode == 2)
            {
                this.lbLanguage.Text = "Java";

                this.panelComment.Visible = true;
                this.panelFormat.Visible = true;
                this.panelType.Visible = false;

                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = true;
                this.rdbLast.Visible = true;

                this.chkIsTable.Visible = true;
                this.chkCreateInterf.Visible = true;

                this.rdbFirst.Text = "Set Public";
                this.rdbLast.Text = "Set Private";

                this.chkCreateInterf.Text = "Create Static";
            }
            if (this.isMode == 3)
            {
                this.lbLanguage.Text = "HTML";

                this.panelComment.Visible = false;
                this.panelFormat.Visible = false;
                this.panelType.Visible = false;

                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = false;
                this.rdbLast.Visible = false;

                this.chkIsTable.Visible = false;
                this.chkCreateInterf.Visible = false;
            }
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
        private void txtLogic_Click(object sender, EventArgs e)
        {
            txtLogic.SelectAll();
            txtLogic.Focus();
        }

        private void txtLogic_TextChanged(object sender, EventArgs e)
        {
            lstLogic.Clear();
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

            convert();
        }

        private void txtPhysi_Click(object sender, EventArgs e)
        {
            txtPhysi.SelectAll();
            txtPhysi.Focus();
        }

        private void txtPhysi_TextChanged(object sender, EventArgs e)
        {
            lstPhysi.Clear();
            lstPhysi = txtPhysi.Text.Replace("\t", "").Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries).ToList();

            if (lstPhysi.Count > 0)
            {
                lblNumPhysi.Visible = true;
                lblNumPhysi.Text = string.Concat(CONST.TEXT_LINE_NUM, lstPhysi.Count);
            }
            else
            {
                lblNumPhysi.Visible = false;
            }

            convert();
        }

        private void txtType_Click(object sender, EventArgs e)
        {
            txtType.SelectAll();
            txtType.Focus();
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            lstType.Clear();
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

            convert();
        }

        private void rdbLineBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLineBlock.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                if (this.isMode == 1 && rdbTypeScript.Checked)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else if (this.isMode == 1 && rdbSetParam.Checked)
                {
                    this.chkCreateInterf.Visible = false;
                    this.rdbFirst.Visible = true;
                    this.rdbLast.Visible = true;
                    this.txtAddLogic.Visible = true;
                    this.txtAddPhysi.Visible = true;
                }
                else if (this.isMode == 2)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else
                {
                    this.rdbFirst.Visible = false;
                    this.rdbLast.Visible = false;
                    this.chkCreateInterf.Visible = false;
                }

                convert();
            }
        }

        private void rdbBlock_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBlock.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                if (this.isMode == 1 && rdbTypeScript.Checked)
                {
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else if (this.isMode == 1 && rdbSetParam.Checked)
                {
                    this.chkCreateInterf.Visible = false;
                    this.rdbFirst.Visible = true;
                    this.rdbLast.Visible = true;
                    this.txtAddLogic.Visible = true;
                    this.txtAddPhysi.Visible = true;
                }
                else if (this.isMode == 2)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else
                {
                    this.rdbFirst.Visible = false;
                    this.rdbLast.Visible = false;
                    this.chkCreateInterf.Visible = false;
                }

                convert();
            }
        }

        private void rdbLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLine.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                if (this.isMode == 1 && rdbTypeScript.Checked)
                {
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else if (this.isMode == 1 && rdbSetParam.Checked)
                {
                    this.chkCreateInterf.Visible = false;
                    this.rdbFirst.Visible = true;
                    this.rdbLast.Visible = true;
                    this.txtAddLogic.Visible = true;
                    this.txtAddPhysi.Visible = true;
                }
                else if (this.isMode == 2)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else
                {
                    this.rdbFirst.Visible = false;
                    this.rdbLast.Visible = false;
                    this.chkCreateInterf.Visible = false;
                }

                convert();
            }
        }

        private void rdbLowerCase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLowerCase.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                if (this.isMode == 1 && rdbTypeScript.Checked)
                {
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else if (this.isMode == 1 && rdbSetParam.Checked)
                {
                    this.chkCreateInterf.Visible = false;
                    this.rdbFirst.Visible = true;
                    this.rdbLast.Visible = true;
                    this.txtAddLogic.Visible = true;
                    this.txtAddPhysi.Visible = true;
                }
                else if (this.isMode == 2)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else
                {
                    this.rdbFirst.Visible = false;
                    this.rdbLast.Visible = false;
                    this.chkCreateInterf.Visible = false;
                }

                convert();
            }
        }

        private void rdbUpperCase_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUpperCase.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                if (this.isMode == 1 && rdbTypeScript.Checked)
                {
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else if (this.isMode == 1 && rdbSetParam.Checked)
                {
                    this.chkCreateInterf.Visible = false;
                    this.rdbFirst.Visible = true;
                    this.rdbLast.Visible = true;
                    this.txtAddLogic.Visible = true;
                    this.txtAddPhysi.Visible = true;
                }
                else if (this.isMode == 2)
                {
                    this.chkCreateInterf.Visible = true;
                    if (this.chkCreateInterf.Checked)
                    {
                        this.rdbFirst.Visible = false;
                        this.rdbLast.Visible = false;
                    }
                    else
                    {
                        this.rdbFirst.Visible = true;
                        this.rdbLast.Visible = true;
                    }
                }
                else
                {
                    this.rdbFirst.Visible = false;
                    this.rdbLast.Visible = false;
                    this.chkCreateInterf.Visible = false;
                }

                convert();
            }
        }

        private void rdbSetParam_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbSetParam.Checked)
            {
                this.txtAddLogic.Visible = true;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = true;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = true;
                this.rdbLast.Visible = true;

                this.rdbFirst.Text = "Set First";
                this.rdbLast.Text = "Set Last";

                this.chkCreateInterf.Visible = false;

                convert();
            }
        }

        private void rdbObservable_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbObservable.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty; 

                this.rdbFirst.Visible = false;
                this.rdbLast.Visible = false;

                this.chkCreateInterf.Visible = false;

                convert();
            }
        }

        private void rdbTypeScript_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTypeScript.Checked)
            {
                this.txtAddLogic.Visible = false;
                this.txtAddLogic.Text = string.Empty;
                this.txtAddPhysi.Visible = false;
                this.txtAddPhysi.Text = string.Empty;

                this.rdbFirst.Visible = true;
                this.rdbLast.Visible = true;

                this.rdbFirst.Text = "Set Public";
                this.rdbLast.Text = "Set Private";

                this.chkCreateInterf.Visible = true;

                convert();
            }
        }

        private void chkIsTable_CheckedChanged(object sender, EventArgs e)
        {
            convert();
        }

        private void chkCreateInterf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCreateInterf.Checked)
            {
                this.rdbFirst.Visible = false;
                this.rdbLast.Visible = false;
            }
            else
            {
                this.rdbFirst.Visible = true;
                this.rdbLast.Visible = true;
            }

            convert();
        }

        private void rdbFirst_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFirst.Checked)
            {
                convert();
            }
        }

        private void rdbLast_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbLast.Checked)
            {
                convert();
            }
        }

        private void txtAddLogic_TextChanged(object sender, EventArgs e)
        {
            convert();
        }

        private void txtAddPhysi_TextChanged(object sender, EventArgs e)
        {
            convert();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.lstLogic.Clear();
            this.lstPhysi.Clear();
            this.lstType.Clear();

            txtLogic.Text = string.Empty;
            txtPhysi.Text = string.Empty;
            txtType.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtAddLogic.Text = string.Empty;
            txtAddPhysi.Text = string.Empty;

            lblNumLogic.Visible = false;
            lblNumPhysi.Visible = false;
            lblNumType.Visible = false;

            this.chkCreateInterf.Checked = false;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text)) return;

            Clipboard.Clear();
            Clipboard.SetText(txtResult.Text);
        }
        #endregion

        #region Method
        private void convert()
        {
            this.lstResult.Clear();

            if (this.isMode == 0)
            {
                convertToCsharp();
            }
            else if (this.isMode == 1)
            {
                convertToTypeScripts();
            }
            else if (this.isMode == 2)
            {
                convertToJava();
            }
            else if (this.isMode == 3)
            {
                convertToHTML();
            }
        }

        private void convertToCsharp()
        {
            txtResult.Text = string.Empty;

            if (lstLogic.Count != lstPhysi.Count || lstLogic.Count != lstType.Count)
            {
                return;
            }

            string template = string.Empty; ;

            for (int i = 0; i < lstLogic.Count; i++)
            {
                string element = string.Empty;
                string nameLogic = lstLogic[i].Trim();
                template = createTemplateC(lstLogic[i].Trim());

                if (nameLogic.ToLower().Equals(CONST.STRING_NONE) || string.IsNullOrEmpty(nameLogic))
                {
                    element = string.Format(template, lstType[i].Trim(), lstPhysi[i].Trim());
                }
                else
                {
                    element = string.Format(template, lstLogic[i].Trim(), lstType[i].Trim(), lstPhysi[i].Trim());
                }

                if (i == lstLogic.Count - 1)
                {
                    lstResult.Add(element);
                }
                else
                {
                    lstResult.Add(element + "\r\n");
                }
            }

            foreach (string value in lstResult)
            {
                txtResult.Text += value;
            }

            if (txtResult.Text.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void convertToTypeScripts()
        {
            txtResult.Text = string.Empty;

            string namePhy = string.Empty;
            string dot = ": ";
            string nameLog = string.Empty;
            string element = string.Empty;

            if (lstLogic.Count != lstPhysi.Count || lstLogic.Count != lstType.Count)
            {
                return;
            }

            for (int i = 0; i < lstLogic.Count; i++)
            {

                string type = lstType[i].Trim();
                if (type.Equals("void") || type.Equals("function"))
                {
                    dot = string.Empty;
                }

                if (typeScriptKeyword.TryGetValue(type.ToLower(), out string value))
                {
                    if (rdbTypeScript.Checked)
                    {
                        type = value;
                    }
                    else if (rdbObservable.Checked)
                    {
                        if (type.Equals("object[]"))
                        {
                            type = "KnockoutObservableArray<" + value + ">";
                        }
                        else if (type.Equals("void") || type.Equals("function"))
                        {
                            type = value;
                        }
                        else
                        {
                            type = "KnockoutObservable<" + value + ">";
                        }
                    }
                }
                else
                {
                    if (type.StartsWith("List") && type.Length >= 6)
                    {
                        type = type.Substring(5, type.Length - 6) + "[]";
                    }
                }

                namePhy = lstPhysi[i].Trim();

                if (!string.IsNullOrEmpty(namePhy) && chkCreateInterf.Checked && namePhy.Length > 10 && namePhy.ToUpper().Contains(CONST.STRING_PRIVATEM))
                {
                    namePhy = namePhy.Substring(9);
                }

                if (rdbLowerCase.Checked)
                {
                    namePhy = namePhy.Substring(0, 1).ToLower() + namePhy.Substring(1);
                }
                else if (rdbUpperCase.Checked)
                {
                    namePhy = namePhy.Substring(0, 1).ToUpper() + namePhy.Substring(1);
                }

                nameLog = lstLogic[i].Trim();
                if (!string.IsNullOrEmpty(nameLog) && nameLog.Length > 1 && nameLog.Substring(0, 1).Equals(CONST.STRING_APOSTROPHE))
                {
                    nameLog = nameLog.Substring(1);
                }

                if (!String.IsNullOrEmpty(txtAddLogic.Text.Trim()) && !nameLog.ToLower().Equals(CONST.STRING_NONE))
                {
                    nameLog = nameLog + txtAddLogic.Text.Trim();
                }

                if (!String.IsNullOrEmpty(txtAddPhysi.Text.Trim()))
                {
                    if (rdbFirst.Checked)
                    {
                        namePhy = txtAddPhysi.Text.Trim() + namePhy;
                    }
                    else
                    {
                        namePhy = namePhy + txtAddPhysi.Text.Trim();
                    }
                }

                if (rdbSetParam.Checked)
                {
                    type = " = " + type + ";";
                }

                StringBuilder stringBuilder = new StringBuilder();
                if (!nameLog.ToLower().Equals(CONST.STRING_NONE) && !string.IsNullOrEmpty(nameLog))
                {
                    if (i > 0)
                    {
                        lstResult[i - 1] = lstResult[i - 1] + "\r\n";
                    }

                    if (rdbLine.Checked)
                    {
                        stringBuilder.Append("// {0}\r\n");
                    }
                    else if (rdbBlock.Checked)
                    {
                        stringBuilder.Append("/**\r\n");
                        stringBuilder.Append(" * {0}\r\n");
                        stringBuilder.Append(" **/\r\n");
                    }
                    else if (rdbLineBlock.Checked)
                    {
                        stringBuilder.Append("/** {0} */\r\n");
                    }

                    if (rdbSetParam.Checked)
                    {
                        dot = string.Empty;
                        stringBuilder.Append("{1}{2}{3}");
                    }
                    else if (rdbObservable.Checked)
                    {
                        stringBuilder.Append("readonly {1}{2}{3};");
                    }
                    else
                    {
                        if (rdbFirst.Checked && rdbFirst.Visible)
                        {
                            stringBuilder.Append("public {1}{2}{3}");
                        }
                        else if (rdbLast.Checked && rdbLast.Visible)
                        {
                            stringBuilder.Append("private {1}{2}{3}");
                        }
                        else if (chkCreateInterf.Checked)
                        {
                            stringBuilder.Append("{1}{2}{3}");
                        }

                        if (chkCreateInterf.Checked)
                        {
                            stringBuilder.Append(",");
                        }
                        else if (!lstType[i].Trim().Equals("void") && !lstType[i].Trim().Equals("function"))
                        {
                            stringBuilder.Append(";");
                        }
                        else
                        {
                            stringBuilder.Append("");
                        }
                    }

                    element = string.Format(stringBuilder.ToString(), nameLog, namePhy, dot, type);
                }
                else
                {
                    if (rdbSetParam.Checked)
                    {
                        dot = string.Empty;
                        stringBuilder.Append("{0}{1}{2}");
                    }
                    else if (rdbObservable.Checked)
                    {
                        stringBuilder.Append("readonly {0}{1}{2};");
                    }
                    else
                    {
                        if (rdbFirst.Checked && rdbFirst.Visible)
                        {
                            stringBuilder.Append("public {0}{1}{2}");
                        }
                        else if (rdbLast.Checked && rdbLast.Visible)
                        {
                            stringBuilder.Append("private {0}{1}{2}");
                        }
                        else if (chkCreateInterf.Checked)
                        {
                            stringBuilder.Append("{1}{2}{3}");
                        }

                        if (chkCreateInterf.Checked)
                        {
                            stringBuilder.Append(",");
                        }
                        if (!lstType[i].Trim().Equals("void") && !lstType[i].Trim().Equals("function"))
                        {
                            stringBuilder.Append(";");
                        }
                        else
                        {
                            stringBuilder.Append("");
                        }
                    }

                    element = string.Format(stringBuilder.ToString(), namePhy, dot, type);
                }

                if (i == lstLogic.Count - 1)
                {
                    lstResult.Add(element);
                }
                else
                {
                    lstResult.Add(element + "\r\n");
                }
            }

            foreach (string value in lstResult)
            {
                txtResult.Text += value;
            }

            if (txtResult.Text.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void convertToJava()
        {
            txtResult.Text = string.Empty;

            if (lstLogic.Count != lstPhysi.Count || lstLogic.Count != lstType.Count)
            {
                return;
            }

            string template = string.Empty;

            for (int i = 0; i < lstLogic.Count; i++)
            {
                string element = string.Empty;
                string nameLogic = lstLogic[i].Trim();
                template = cereateTemplateJava(lstLogic[i].Trim(), lstPhysi[i].Trim());
                string txPhysi = lstPhysi[i].Trim();

                if (this.chkIsTable.Checked && !string.IsNullOrEmpty(txPhysi) && !txPhysi.Equals(CONST.STRING_HYPHEN))
                {
                    if (txPhysi.Substring(0, 2).Equals(CONST.STRING_IS_TABLE))
                    {
                        txPhysi = txPhysi.Replace(CONST.STRING_IS_TABLE, "");
                        txPhysi = CUtils.FirstCharToLowerCase(txPhysi);
                    }
                } else if (this.rdbLowerCase.Checked)
                {
                    txPhysi = CUtils.FirstCharToLowerCase(txPhysi);
                } else if (this.rdbUpperCase.Checked)
                {
                    txPhysi = CUtils.FirstCharToUpperCase(txPhysi);
                }

                if (template == null)
                {
                    element = "";
                }
                else if (nameLogic.ToLower().Equals(CONST.STRING_NONE) || string.IsNullOrEmpty(nameLogic))
                {
                    element = string.Format(template, lstType[i].Trim(), txPhysi);
                }
                else
                {
                    element = string.Format(template, lstLogic[i].Trim(), lstType[i].Trim(), txPhysi);
                }

                if (i == lstLogic.Count - 1)
                {
                    lstResult.Add(element);
                }
                else if (template != null)
                {
                    lstResult.Add(element + "\r\n");
                }
            }

            foreach (string value in lstResult)
            {
                txtResult.Text += value;
            }

            if (txtResult.Text.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void convertToHTML()
        {
            txtResult.Text = string.Empty;

            if (lstLogic.Count != lstPhysi.Count || lstLogic.Count != lstType.Count)
            {
                return;
            }

            string element = string.Empty;
            for (int i = 0; i < lstLogic.Count; i++)
            {
                StringBuilder stringbuilder = new StringBuilder();
                if (typeScriptKeyword.TryGetValue(lstPhysi[i].Trim(), out string value))
                {
                    switch (value)
                    {
                        case "button":
                            stringbuilder.Append("<button type=\"button\" class=\"btn btn-sm btn-light border-secondary\" data-bind=\"{0}</button>\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("button", lstType[i].Trim()), lstLogic[i].Trim().Replace(lstLogic[i].Trim(), string.Empty));
                            break;
                        case "label":
                            stringbuilder.Append("<label class=\"label label-sm\">\r\n{0}\r\n</label>\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("label", lstType[i].Trim()));
                            break;
                        case "text":
                            stringbuilder.Append("<input type=\"text\" class=\"form-control\" data-bind=\"{0}\"/>\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("text", lstType[i].Trim()));
                            break;
                        case "boolean":
                            stringbuilder.Append("<input type=\"checkbox\" data-bind=\"{0}\"/>\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("checkbox", lstType[i].Trim()));
                            break;
                        case "spread":
                            stringbuilder.Append("<div id=\"{0}\" data-bind=\"{1}\"></div>\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("spread", lstType[i].Trim()), lstLogic[i].Trim().Replace(lstLogic[i].Trim(), string.Empty));
                            break;
                        case "selectbox":
                            stringbuilder.Append("<select class=\"form-control\" data-bind=\"{0}\"></ select >\r\n");
                            element = string.Format(stringbuilder.ToString(), createDataBind("selectbox", lstType[i].Trim()));
                            break;
                    }
                }

                if (i == lstLogic.Count - 1)
                {
                    lstResult.Add(element);
                }
                else
                {
                    lstResult.Add(element + " \r\n");
                }
            }

            foreach (string value in lstResult)
            {
                txtResult.Text += value;
            }

            if (txtResult.Text.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private string createDataBind(string type, string value)
        {
            string[] arrValue = value.Split(',');
            string result = string.Empty;

            if (arrValue.Length == 0)
            {
                return result;
            }

            switch (type)
            {
                case "button":
                    if (arrValue.Length == 3)
                    {
                        result = "click: " + arrValue[0] +
                            "\">\r\n    @Html.Raw(literalCtrl[\"" + arrValue[1] + "\"]).CreateHtml(\"" + arrValue[2] + "\"))\r\n";
                    }
                    else if (arrValue.Length == 4)
                    {
                        result = "click: " + arrValue[0] + ", disable: " + arrValue[1] +
                            "\">\r\n    @Html.Raw(literalCtrl[\"" + arrValue[2] + "\"]).CreateHtml(\"" + arrValue[3] + "\"))\r\n";
                    }
                    else if (arrValue.Length == 5)
                    {
                        result = "click: " + arrValue[0] + ", visible: " + arrValue[1] + ", disable: " + arrValue[2]
                            + "\">\r\n    @Html.Raw(literalCtrl[\"" + arrValue[3] + "\"]).CreateHtml(\"" + arrValue[4] + "\"))\r\n";
                    }
                    else if (arrValue.Length == 6)
                    {
                        result = "click: " + arrValue[0] + ", visible: " + arrValue[1] + ", disable: " + arrValue[2] +
                            "\">\r\n    <span class=\"fas " + arrValue[3] + "\"></span>"
                            + "@Html.Raw(literalCtrl[\"" + arrValue[4] + "\"]).CreateHtml(\"" + arrValue[5] + "\"))\r\n";
                    }

                    return result;
                case "label":
                    if (arrValue.Length == 1)
                    {
                        result = arrValue[0];

                    }
                    else if (arrValue.Length == 2)
                    {
                        if (string.IsNullOrEmpty(arrValue[1]))
                        {
                            result = "    " + arrValue[0] + " <span class=\"text-danger\">＊</span>";
                        }
                        else
                        {
                            result = "    @Html.Raw(literalCtrl[\"" + arrValue[0] + "\"]).CreateHtml(\"" + arrValue[1] + "\"))";
                        }
                    }
                    else if (arrValue.Length == 3)
                    {
                        result = "    @Html.Raw(literalCtrl[\"" + arrValue[0] + "\"]).CreateHtml(\"" + arrValue[1] + "\")) <span class=\"text-danger\">＊</span>";
                    }
                    return result;
                case "text":
                    if (arrValue.Length == 1)
                    {
                        result = "value: " + arrValue[0];
                    }
                    else if (arrValue.Length == 2)
                    {
                        result = "value: " + arrValue[0] + ", disable: " + arrValue[1];
                    }
                    else if (arrValue.Length == 3)
                    {
                        result = "value: " + arrValue[0] + ", visible: " + arrValue[1] + ", disable: " + arrValue[2];
                    }
                    else if (arrValue.Length == 4)
                    {
                        result = "value: " + arrValue[0] + ", visible: " + arrValue[1] + ", disable: " + arrValue[2] + ", hasfocus:" + arrValue[3];
                    }
                    return result;
                case "checkbox":
                    if (arrValue.Length == 1)
                    {
                        result = "checked: " + arrValue[0];
                    }
                    else if (arrValue.Length == 2)
                    {
                        result = "checked: " + arrValue[0] + ", disable: " + arrValue[1];
                    }
                    else if (arrValue.Length == 3)
                    {
                        result = "checked: " + arrValue[0] + ", visible: " + arrValue[1] + ", disable: " + arrValue[2];
                    }
                    return result;
                case "spread":
                    if (arrValue.Length == 1)
                    {
                        result = "disable: " + arrValue[0];
                    }
                    else if (arrValue.Length == 2)
                    {
                        result = "visible: " + arrValue[0] + ", disable: " + arrValue[1];
                    }
                    return result;
                case "selectbox":
                    if (arrValue.Length == 5)
                    {
                        result = "options: " + arrValue[0] + ", optionsText: '" + arrValue[1] + "', optionsValue: '" + arrValue[2] + "', value: " + arrValue[3] + ", disable: " + arrValue[4];
                    }
                    else if (arrValue.Length == 6)
                    {
                        result = "options: " + arrValue[0] + ", optionsText: '" + arrValue[1] + "', optionsValue: '" + arrValue[2] + "', value: " + arrValue[3] + ", visible: " + arrValue[4] + ", disable: " + arrValue[5];
                    }
                    return result;
            }

            return result;
        }

        private string createTemplateC(string nameLogic)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!nameLogic.ToLower().Equals(CONST.STRING_NONE) && !string.IsNullOrEmpty(nameLogic))
            {
                if (rdbLine.Checked)
                {
                    stringBuilder.Append("/// <summary>\r\n");

                    if (string.IsNullOrEmpty(txtAddLogic.Text))
                    {
                        stringBuilder.Append("/// {0}\r\n");
                    }
                    else
                    {
                        stringBuilder.Append("/// {0}" + txtAddLogic.Text + "\r\n");
                    }

                    stringBuilder.Append("/// </summary>\r\n");
                }
                else if (rdbBlock.Checked)
                {
                    stringBuilder.Append("/**\r\n");

                    if (string.IsNullOrEmpty(txtAddLogic.Text))
                    {
                        stringBuilder.Append(" * {0}\r\n");
                    }
                    else
                    {
                        stringBuilder.Append(" * {0}" + txtAddLogic.Text + "\r\n");
                    }

                    stringBuilder.Append(" */\r\n");
                }
                else if (rdbLineBlock.Checked)
                {
                    if (string.IsNullOrEmpty(txtAddLogic.Text))
                    {
                        stringBuilder.Append("/** {0} */\r\n");
                    }
                    else
                    {
                        stringBuilder.Append("/** {0}" + txtAddLogic.Text + " */\r\n");
                    }
                }

                if (string.IsNullOrEmpty(txtAddPhysi.Text))
                {
                    stringBuilder.Append("public {1} {2} {{ get; set; }}\r\n");
                }
                else
                {
                    stringBuilder.Append("public {1} {2}" + txtAddPhysi.Text + " {{ get; set; }}\r\n");
                }
            }
            else
            {
                if (string.IsNullOrEmpty(txtAddPhysi.Text))
                {
                    stringBuilder.Append("public {0} {1} {{ get; set; }}\r\n");
                }
                else
                {
                    stringBuilder.Append("public {0} {1}" + txtAddPhysi.Text + " {{ get; set; }}\r\n");
                }
            }

            return stringBuilder.ToString();
        }

        private string cereateTemplateJava(string nameLogic, string namePhysi)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (namePhysi.Equals(CONST.STRING_HYPHEN))
            {
                return null;
            }

            string aces = "public";
            if (this.rdbLast.Checked)
            {
                aces = "private";
            }

            if (!nameLogic.ToLower().Equals(CONST.STRING_NONE) && !string.IsNullOrEmpty(nameLogic))
            {
                if (rdbLine.Checked)
                {
                    stringBuilder.Append("// {0} \r\n");
                }
                else if (rdbBlock.Checked)
                {
                    stringBuilder.Append("/**\r\n");
                    stringBuilder.Append(" * {0}\r\n");
                    stringBuilder.Append(" */\r\n");
                }
                else if (rdbLineBlock.Checked)
                {
                    stringBuilder.Append("/** {0} */\r\n");
                }

                if (this.chkCreateInterf.Checked)
                {
                    stringBuilder.Append(aces + " static final {1} {2} = \"\";\r\n");
                }
                else
                {
                    stringBuilder.Append(aces + " {1} {2} ;\r\n");
                }
            }

            return stringBuilder.ToString();
        }
        #endregion

    }
}
