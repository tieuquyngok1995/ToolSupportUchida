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
        private List<ItemModel> lstItem = new List<ItemModel>();

        private List<string> lstLogic = new List<string>();
        private List<string> lstPhysical = new List<string>();
        private List<string> lstType = new List<string>();
        private List<string> lstNameItem = new List<string>();
        private List<string> lstValidation = new List<string>();

        private Dictionary<string, string[]> dicValidation = new Dictionary<string, string[]>();
        private Dictionary<string, string> dicSetting = new Dictionary<string, string>();
        private Dictionary<string, string> dicArrIndex = new Dictionary<string, string>();

        #region Load Form
        public FormCreateViewModel(List<ItemModel> _lstItem)
        {
            lstItem = _lstItem;

            InitializeComponent();
        }

        private void FormCreateViewModel_Load(object sender, EventArgs e)
        {
            rbModeC.Checked = true;

            txtLogic.Focus();

            getDataSetting();

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

        private void rbModeC_CheckedChanged(object sender, EventArgs e)
        {
            getDataSetting();

            grbMode.Visible = false;
            grbClassName.Visible = false;
        }

        private void rbModeTypescript_CheckedChanged(object sender, EventArgs e)
        {
            getDataSetting();

            grbMode.Visible = true;
            grbClassName.Visible = true;
        }

        private void rbNew_CheckedChanged(object sender, EventArgs e)
        {
            grbInputLogic.Text = "Input Logical";
            grbInputLogic.Width = 132;
            grbInputPhysical.Visible = true;
            grbInputType.Visible = true;
            grbInputNameItem.Visible = true;
            grbInputValidation.Visible = true;
        }

        private void rbTransfer_CheckedChanged(object sender, EventArgs e)
        {
            grbInputLogic.Text = "Input Code";
            grbInputLogic.Width = 683;
            grbInputPhysical.Visible = false;
            grbInputType.Visible = false;
            grbInputNameItem.Visible = false;
            grbInputValidation.Visible = false;
        }

        private void txtClassLogic_Click(object sender, EventArgs e)
        {
            txtClassLogic.SelectAll();
            txtClassLogic.Focus();
        }

        private void txtClassLogic_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtClassPhysical_Click(object sender, EventArgs e)
        {
            txtClassPhysical.SelectAll();
            txtClassPhysical.Focus();
        }

        private void txtClassPhysical_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtLogic_Click(object sender, EventArgs e)
        {
            txtLogic.SelectAll();
            txtLogic.Focus();
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

        private void txtPhysical_Click(object sender, EventArgs e)
        {
            txtPhysical.SelectAll();
            txtPhysical.Focus();
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

        private void txtType_Click(object sender, EventArgs e)
        {
            txtType.SelectAll();
            txtType.Focus();
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

        private void txtNameItem_Click(object sender, EventArgs e)
        {
            txtNameItem.SelectAll();
            txtNameItem.Focus();
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

        private void txtValidation_Click(object sender, EventArgs e)
        {
            txtValidation.SelectAll();
            txtValidation.Focus();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                txtResult.Text = string.Empty;
                string tmpVM, logic, physical, type, annotation;
                string iViewModel = string.Empty;
                string fViewModel = string.Empty;
                string fProperty = string.Empty;
                string mViewModel = string.Empty;
                string mProperty = string.Empty;

                if (rbModeC.Checked)
                {
                    tmpVM = dicSetting[CONST.STRING_SETTING_VIEW_MODEL];
                }
                else
                {
                    tmpVM = dicSetting[CONST.STRING_SETTING_VIEW_MODEL];
                }

                for (int i = 0; i < lstLogic.Count; i++)
                {
                    logic = lstLogic[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                    physical = lstPhysical.Count > i ? lstPhysical[i].Replace(CONST.STRING_TAB, string.Empty).Trim() : string.Empty;
                    type = lstType.Count > i ? lstType[i].Replace(CONST.STRING_TAB, string.Empty).Trim() : string.Empty;

                    if (rbModeC.Checked)
                    {
                        annotation = getAnnotationsC(logic, type);

                        type = CUtils.AddDefaultTypeC(type);

                        txtResult.Text += string.Format(tmpVM, logic, annotation, type, physical).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE) + CONST.STRING_ADD_LINE;

                        txtResult.Text += CONST.STRING_ADD_LINE;
                        txtResult.Text = CUtils.RemoveLastLineBlank(txtResult.Text);
                    }
                    else if (rbModeTypescript.Checked && rbNew.Checked)
                    {
                        type = CUtils.CastTypeCToTs(type);

                        iViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_PROPERTY), physical) + CONST.STRING_ADD_LINE;

                        getAnnotationsTS(logic, physical, type, out fProperty, out mProperty);
                        fViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_FORM), CUtils.FirstCharToLowerCase(physical), type, fProperty) + CONST.STRING_ADD_LINE;

                        mViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_MODEL), physical, CUtils.FirstCharToLowerCase(physical), type, mProperty) + CONST.STRING_ADD_LINE;
                    }
                    else if (rbModeTypescript.Checked && rbTransfer.Checked)
                    {
                        if (logic.Contains(CONST.C_TYPE_PUBLIC))
                        {
                            string[] arrLogic = logic.Split(CONST.CHAR_SPACE);

                            if (arrLogic.Length > 2)
                            {
                                type = CUtils.CastTypeCToTs(arrLogic[1].Replace(CONST.STRING_QUESTION, string.Empty));
                                physical = arrLogic[2];
                            }

                            iViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_PROPERTY), physical) + CONST.STRING_ADD_LINE;

                            fProperty = CUtils.RemoveLastCommaSpace(fProperty).Replace(CONST.STRING_SETTING_LOGIC_REPLACE, physical);
                            fViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_FORM), CUtils.FirstCharToLowerCase(physical), type, fProperty) + CONST.STRING_ADD_LINE;

                            if (!string.IsNullOrEmpty(mProperty))
                            {
                                mProperty = CONST.CHAR_COMMA + CONST.STRING_ADD_LINE + mProperty;

                                int index = mProperty.LastIndexOf(CONST.CHAR_COMMA);
                                mProperty = index != -1 ? mProperty.Remove(index, 1) : mProperty;
                            }
                            else
                            {
                                mProperty = CONST.STRING_ADD_LINE;
                            }
                            mViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_MODEL), physical, CUtils.FirstCharToLowerCase(physical), type, mProperty) + CONST.STRING_ADD_LINE;

                            fProperty = string.Empty;
                            mProperty = string.Empty;
                        }
                        else if (!logic.Contains(CONST.STRING_SLASH + CONST.STRING_SLASH + CONST.STRING_SLASH) &&
                                 !logic.ToLower().Equals(CONST.STRING_GET.ToLower()) && !logic.ToLower().Equals(CONST.STRING_SET.ToLower()) &&
                                 !logic.Equals(CONST.STRING_O_CUR_BRACKETS) && !logic.Equals(CONST.STRING_C_CUR_BRACKETS) &&
                                 !logic.Contains(CONST.STRING_RETURN))
                        {
                            string tmpFProperty, tmpMProperty;
                            getAnotationsInSrc(logic, out tmpFProperty, out tmpMProperty);
                            fProperty += tmpFProperty;
                            mProperty += tmpMProperty;
                        }
                    }
                }

                if (rbModeTypescript.Checked)
                {
                    fViewModel = fViewModel.LastIndexOf(CONST.CHAR_COMMA) != -1 ? fViewModel.TrimEnd(CONST.CHAR_COMMA) : fViewModel;
                    mViewModel = CUtils.RemoveLastLineBlank(mViewModel);

                    txtResult.Text += string.Format(tmpVM, txtClassLogic.Text, txtClassPhysical.Text, iViewModel, fViewModel, mViewModel).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
                }

                if (!string.IsNullOrEmpty(txtResult.Text)) btnCopy.Enabled = true;
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
        }

        #endregion

        #region Method

        private void getDataSetting()
        {
            List<ItemModel> lstSeting;

            dicSetting.Clear();
            dicArrIndex.Clear();

            if (rbModeC.Checked)
            {
                lstSeting = lstItem.Where(item => item.key.Equals(CONST.STRING_SETTING_C_VIEW_MODEL)).ToList();
            }
            else
            {
                lstSeting = lstItem.Where(item => item.key.Equals(CONST.STRING_SETTING_TS_VIEW_MODEL)).ToList();
            }

            foreach (ItemModel item in lstSeting)
            {
                if (!string.IsNullOrEmpty(item.name) && !dicSetting.ContainsKey(item.name))
                {
                    if (item.name.Equals(CONST.STRING_SETTING_INDEX_ARR))
                    {
                        string[] arr = item.value.Split(CONST.CHAR_TILDE);
                        foreach (string str in arr)
                        {
                            if (!string.IsNullOrEmpty(str))
                            {
                                string[] arrIndex = str.Split(CONST.CHAR_COLON);

                                if (arrIndex.Length > 1)
                                {
                                    dicArrIndex.Add(arrIndex[0], arrIndex[1]);
                                }
                            }
                        }
                    }
                    else
                    {
                        dicSetting.Add(item.name, item.value);
                    }
                }
            }
        }

        private bool isEnableButtonCreate()
        {
            if (rbModeTypescript.Checked)
            {
                if (string.IsNullOrEmpty(txtClassLogic.Text) || string.IsNullOrEmpty(txtClassPhysical.Text)) return false;

                if (rbTransfer.Checked && lstLogic.Count > 0) return true;
            }

            if (lstLogic.Count == 0 || lstPhysical.Count == 0 || lstType.Count == 0) return false;

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
                string key = lstLogic.FirstOrDefault(item => (itemName.Equals(item)));
                string[] value = itemVal.Split(CONST.CHAR_TAB);

                if (key == null || string.IsNullOrEmpty(key)) continue;
                dicValidation.Add(key, value);
            }
        }

        private string getAnnotationsC(string strLogic, string type)
        {
            string result = string.Empty;
            string displayFormat = string.Empty;
            string[] arrValidation;

            if (dicValidation.TryGetValue(strLogic, out arrValidation))
            {
                for (int i = 0; i < arrValidation.Length; i++)
                {
                    string validation = arrValidation[i];
                    if (string.IsNullOrEmpty(validation)) continue;

                    string annotation;
                    if (dicArrIndex.TryGetValue(i.ToString(), out annotation))
                    {
                        string tmp;
                        if (dicSetting.TryGetValue(annotation, out tmp))
                        {
                            if (annotation.Contains(CONST.STRING_SETTING_CHECK_TYPE))
                            {
                                if (type.Equals(CONST.C_TYPE_DATE_TIME)) continue;

                                string[] arr = tmp.Split(CONST.CHAR_TILDE);
                                if (type.Equals(CONST.C_TYPE_STRING))
                                {
                                    result += string.Format(arr[0], validation) + CONST.STRING_ADD_LINE;
                                }
                                else if (type.Equals(CONST.C_TYPE_DECIMAL))
                                {
                                    result += string.Format(arr[2], CUtils.GetRangeNumber(validation)) + CONST.STRING_ADD_LINE;
                                }
                                else
                                {
                                    result += string.Format(arr[1], CUtils.GetRangeNumber(validation)) + CONST.STRING_ADD_LINE;
                                }
                            }
                            else if (annotation.Equals(CONST.STRING_SETTING_DISPLAY_FORMAT))
                            {
                                displayFormat = string.Format(tmp, validation) + CONST.STRING_ADD_LINE;
                            }
                            else if (annotation.Contains(CONST.STRING_SETTING_FORMAT))
                            {
                                result += string.Format(tmp, validation) + CONST.STRING_ADD_LINE;
                            }
                            else
                            {
                                result += tmp + CONST.STRING_ADD_LINE;
                            }
                        }
                    }
                }
            }

            return result + displayFormat;
        }

        private string getTemplateTS(string mode)
        {
            string result = string.Empty;
            if (dicSetting.TryGetValue(mode, out result)) return result;
            return result;
        }

        private void getAnnotationsTS(string strLogic, string physical, string type, out string fProperty, out string mProperty)
        {
            string fVM = string.Empty;
            string mVM = string.Empty;

            string[] arrValidation;
            if (dicValidation.TryGetValue(strLogic, out arrValidation))
            {
                for (int i = 0; i < arrValidation.Length; i++)
                {
                    string validation = arrValidation[i];
                    if (string.IsNullOrEmpty(validation)) continue;

                    string annotation;
                    if (dicArrIndex.TryGetValue(i.ToString(), out annotation))
                    {
                        string tmp;
                        if (dicSetting.TryGetValue(annotation, out tmp))
                        {
                            if (annotation.Contains(CONST.STRING_SETTING_CHECK_TYPE))
                            {
                                if (type.Equals(CONST.TS_TYPE_DATE)) continue;

                                string[] arr = tmp.Split(CONST.CHAR_TILDE);
                                if (type.Equals(CONST.C_TYPE_STRING))
                                {
                                    fVM += string.Format(arr[0], validation) + CONST.STRING_COMMA + CONST.STRING_SPACE;
                                    mVM += string.Format(arr[2], validation) + CONST.STRING_ADD_LINE;
                                }
                                else
                                {
                                    fVM += string.Format(arr[1], CUtils.GetRangeNumber(validation)) + CONST.STRING_COMMA + CONST.STRING_SPACE;
                                    mVM += string.Format(arr[3], CUtils.GetRangeNumber(validation)) + CONST.STRING_ADD_LINE;
                                }
                            }
                            else if (annotation.Equals(CONST.STRING_SETTING_DISPLAY_FORMAT))
                            {
                                mVM += string.Format(tmp, validation) + CONST.STRING_ADD_LINE;
                            }
                            else if (annotation.Contains(CONST.STRING_SETTING_FORMAT))
                            {
                                string[] arr = tmp.Split(CONST.CHAR_TILDE);
                                fVM += string.Format(arr[0], physical, validation) + CONST.STRING_COMMA + CONST.STRING_SPACE;
                                mVM += string.Format(arr[1], physical, validation) + CONST.STRING_ADD_LINE;
                            }
                            else
                            {
                                string[] arr = tmp.Split(CONST.CHAR_TILDE);
                                fVM += arr[0] + CONST.STRING_COMMA + CONST.STRING_SPACE;
                                mVM += arr[1] + CONST.STRING_ADD_LINE;
                            }
                        }
                    }
                }
            }

            fProperty = CUtils.RemoveLastCommaSpace(fVM);
            if (!string.IsNullOrEmpty(mVM))
            {
                mVM = CONST.CHAR_COMMA + CONST.STRING_ADD_LINE + mVM;

                int index = mVM.LastIndexOf(CONST.CHAR_COMMA);
                mProperty = index != -1 ? mVM.Remove(index, 1) : mVM;
            }
            else
            {
                mProperty = CONST.STRING_ADD_LINE;
            }
        }

        private void getAnotationsInSrc(string logic, out string fProperty, out string mProperty)
        {
            string[] arrValueLogic = null, arrTmp = null;
            string tmp, value = string.Empty;

            fProperty = string.Empty; mProperty = string.Empty;

            if (logic.Contains(CONST.STRING_SETTING_REQUIRED) && dicSetting.TryGetValue(CONST.STRING_SETTING_REQUIRED, out tmp))
            {
                arrTmp = tmp.Split(CONST.CHAR_TILDE);
                fProperty = arrTmp[0] + CONST.STRING_COMMA + CONST.STRING_SPACE;
                mProperty = arrTmp[1] + CONST.STRING_ADD_LINE;
            }
            else if (logic.Contains(CONST.STRING_SETTING_LENGTH) || logic.Contains(CONST.STRING_SETTING_RANGE))
            {
                arrValueLogic = logic.Split(CONST.CHAR_O_BRACKETS);
                if (arrValueLogic.Length >= 1)
                {
                    value = arrValueLogic[1].Replace(CONST.STRING_C_BRACKETS, string.Empty).Replace(CONST.STRING_C_SQU_BRACKETS, string.Empty)
                                       .Replace("0,", string.Empty).Replace("0d,", string.Empty).Replace("d", string.Empty).Trim();
                }

                if (dicSetting.TryGetValue(CONST.STRING_SETTING_LENGTH + CONST.STRING_SETTING_CHECK_TYPE, out tmp))
                {
                    arrTmp = tmp.Split(CONST.CHAR_TILDE);
                    if (logic.Contains(CONST.STRING_SETTING_LENGTH))
                    {
                        fProperty = string.Format(arrTmp[0], value) + CONST.STRING_COMMA + CONST.STRING_SPACE;
                        mProperty = string.Format(arrTmp[2], value) + CONST.STRING_ADD_LINE;
                    }
                    else
                    {
                        fProperty = string.Format(arrTmp[1], value) + CONST.STRING_COMMA + CONST.STRING_SPACE;
                        mProperty = string.Format(arrTmp[3], value) + CONST.STRING_ADD_LINE;
                    }
                }
            }
            else if (logic.Contains(CONST.STRING_SETTING_DISPLAY) &&
                dicSetting.TryGetValue(CONST.STRING_SETTING_DISPLAY_FORMAT, out tmp))
            {
                arrValueLogic = logic.Split(CONST.CHAR_QUOTATION);
                mProperty = string.Format(tmp, arrValueLogic[1]) + CONST.STRING_ADD_LINE;
            }
            else if (logic.Contains(CONST.STRING_SETTING_LESS_THAN) &&
                dicSetting.TryGetValue(CONST.STRING_SETTING_LESS_THAN + CONST.STRING_SETTING_FORMAT, out tmp))
            {
                arrValueLogic = logic.Split(CONST.CHAR_QUOTATION);
                arrTmp = tmp.Split(CONST.CHAR_TILDE);
                fProperty = string.Format(arrTmp[0], CONST.STRING_SETTING_LOGIC_REPLACE, arrValueLogic[1]) + CONST.STRING_SPACE;
                mProperty = string.Format(arrTmp[1], arrValueLogic[1]) + CONST.STRING_ADD_LINE;
            }
            else if (logic.Contains(CONST.STRING_SETTING_GREATER_THAN) &&
                dicSetting.TryGetValue(CONST.STRING_SETTING_GREATER_THAN + CONST.STRING_SETTING_FORMAT, out tmp))
            {
                arrValueLogic = logic.Split(CONST.CHAR_QUOTATION);
                arrTmp = tmp.Split(CONST.CHAR_TILDE);
                fProperty = string.Format(arrTmp[0], CONST.STRING_SETTING_LOGIC_REPLACE, arrValueLogic[1]) + CONST.STRING_SPACE;
                mProperty = string.Format(arrTmp[1], arrValueLogic[1]) + CONST.STRING_ADD_LINE;
            }
            else if (logic.Contains(CONST.STRING_SETTING_LESS_OR_EQUAL) && dicSetting.TryGetValue(CONST.STRING_SETTING_LESS_OR_EQUAL + CONST.STRING_SETTING_FORMAT, out tmp))
            {
                arrValueLogic = logic.Split(CONST.CHAR_QUOTATION);
                arrTmp = tmp.Split(CONST.CHAR_TILDE);
                fProperty = string.Format(arrTmp[0], CONST.STRING_SETTING_LOGIC_REPLACE, arrValueLogic[1]) + CONST.STRING_SPACE;
                mProperty = string.Format(arrTmp[1], arrValueLogic[1]) + CONST.STRING_ADD_LINE;
            }
            else if (logic.Contains(CONST.STRING_SETTING_GREATER_OR_EQUAL) &&
                dicSetting.TryGetValue(CONST.STRING_SETTING_GREATER_OR_EQUAL + CONST.STRING_SETTING_FORMAT, out tmp))
            {
                arrValueLogic = logic.Split(CONST.CHAR_QUOTATION);
                arrTmp = tmp.Split(CONST.CHAR_TILDE);
                fProperty = string.Format(arrTmp[0], CONST.STRING_SETTING_LOGIC_REPLACE, arrValueLogic[1]) + CONST.STRING_SPACE;
                mProperty = string.Format(arrTmp[1], arrValueLogic[1]) + CONST.STRING_ADD_LINE;
            }
        }
        #endregion
    }
}
