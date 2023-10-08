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
        public FormCreateViewModel(int _mode, List<ItemModel> _lstItem)
        {
            isMode = _mode;
            lstItem = _lstItem;

            InitializeComponent();
        }

        private void FormCreateViewModel_Load(object sender, EventArgs e)
        {
            if (isMode == 0)
            {
                rbModeC.Checked = true;
            }
            else
            {
                rbModeTypescript.Checked = true;
                grbClassName.Visible = true;
            }
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

            grbClassName.Visible = false;
        }

        private void rbModeTypescript_CheckedChanged(object sender, EventArgs e)
        {
            getDataSetting();

            grbClassName.Visible = true;
        }

        private void txtClassLogic_TextChanged(object sender, EventArgs e)
        {
            btnCreate.Enabled = isEnableButtonCreate();
        }

        private void txtClassPhysical_TextChanged(object sender, EventArgs e)
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

        private void btnCreate_Click(object sender, EventArgs e)
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
                physical = lstPhysical[i].Replace(CONST.STRING_TAB, string.Empty).Trim();
                type = lstType[i].Replace(CONST.STRING_TAB, string.Empty).Trim();

                if (rbModeC.Checked)
                {
                    annotation = getAnnotationsC(logic, type);
                    txtResult.Text += string.Format(tmpVM, logic, annotation, type, physical).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE) + CONST.STRING_ADD_LINE;

                    txtResult.Text += CONST.STRING_ADD_LINE;
                    txtResult.Text = CUtils.removeLastLineBlank(txtResult.Text);
                }
                else
                {
                    type = CUtils.castTypeCToTs(type);

                    iViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_PROPERTY), physical) + CONST.STRING_ADD_LINE;

                    getAnnotationsTS(logic, physical, type, out fProperty, out mProperty);
                    fViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_FORM), CUtils.FirstCharToLowerCase(physical), type, fProperty) + CONST.STRING_ADD_LINE;

                    mViewModel += string.Format(getTemplateTS(CONST.STRING_SETTING_TS_MODEL), physical, CUtils.FirstCharToLowerCase(physical), type, mProperty) + CONST.STRING_ADD_LINE;
                }
            }

            if (rbModeTypescript.Checked)
            {
                fViewModel = fViewModel.LastIndexOf(CONST.CHAR_COMMA) != -1 ? fViewModel.TrimEnd(CONST.CHAR_COMMA) : fViewModel;
                mViewModel = CUtils.removeLastLineBlank(mViewModel);

                txtResult.Text += string.Format(tmpVM, txtClassLogic.Text, txtClassPhysical.Text, iViewModel, fViewModel, mViewModel).Replace(CONST.STRING_TILDE, CONST.STRING_ADD_LINE);
            }

            if (!string.IsNullOrEmpty(txtResult.Text)) btnCopy.Enabled = true;
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

        private string createTsForm(string mode, string strLogic)
        {
            string tmp = getTemplateTS(CONST.STRING_SETTING_TS_FORM);


            return "";
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

            fProperty = CUtils.removeLastCommaSpace(fVM);
            if (!string.IsNullOrEmpty(mVM))
            {
                mVM = CONST.CHAR_COMMA + CONST.STRING_ADD_LINE + mVM;

                int index = mVM.LastIndexOf(CONST.CHAR_COMMA);
                mProperty = index != -1 ? mVM.Remove(index, 1) : mVM;
            } else
            {
                mProperty = CONST.STRING_ADD_LINE;
            }
        }
        #endregion
    }
}
