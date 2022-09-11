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
        private List<SekkeiModel> lstSekei;
        private List<ItemModel> lstData;
        private List<ItemModel> lstSeting;
        private List<ItemModel> lstKey;

        private ItemModel objItem;

        private List<string> lstType;
        private Dictionary<string, string> dicData;

        private string valKey;

        #region Load Form
        public FormCreateItem(List<SekkeiModel> lstSekei, List<string> lstType, List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstSekei = lstSekei;

            this.lstData = lstItem;
            lstSeting = new List<ItemModel>();
            this.lstType = lstType;

            dicData = new Dictionary<string, string>();
        }

        private void FormCreateAdapter_Load(object sender, EventArgs e)
        {
            LoadTheme();

            LoadData();
        }

        private void LoadTheme()
        {
            foreach (Control btns in this.groupBoxSetting.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = ThemeColor.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = ThemeColor.SecondaryColor;
                }
            }
            foreach (Control btns in this.panelResult.Controls)
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

        private void LoadData()
        {
            List<string> lstTypeCombobox = lstType.Where(str => str != CONST.ITEM_SETTING).ToList();
            cbType.DataSource = lstTypeCombobox;

            lstKey = lstData.Where(obj => obj.type.Equals(CONST.ITEM_HTML)).ToList();
            if (lstKey.Count > 0)
            {
                cbKey.DataSource = new BindingSource(lstKey, null);
                cbKey.DisplayMember = CONST.ITEM_KEY;
                cbKey.ValueMember = CONST.ITEM_VALUE;
                cbKey.SelectedIndex = 0;
            }

            lstSeting = lstData.Where(obj => obj.type.Equals(CONST.ITEM_SETTING) && obj.key.Equals(cbType.SelectedItem.ToString())).ToList();
        }
        #endregion

        #region Event
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectText = "";
            if (cbType.SelectedItem != null)
            {
                selectText = cbType.SelectedItem.ToString();
            }

            lstKey = lstData.Where(obj => obj.type.Equals(selectText)).ToList();
            if (lstKey.Count > 0)
            {
                cbKey.DataSource = new BindingSource(lstKey, null);
                cbKey.DisplayMember = CONST.ITEM_KEY;
                cbKey.ValueMember = CONST.ITEM_VALUE;
                cbKey.SelectedIndex = 0;
            }
            lstSeting = lstData.Where(obj => obj.type.Equals(CONST.ITEM_SETTING) && obj.key.Equals(cbType.SelectedItem.ToString())).ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            valKey = "";
            if (cbKey.SelectedItem != null)
            {
                ItemModel obj = (ItemModel)cbKey.SelectedItem;
                valKey = obj.key;
            }
            List<ItemModel> val = lstData.Where(obj => obj.key.Equals(valKey)).ToList();

            txtFormat.Text = string.Empty;
            if (!valKey.ToUpper().Equals(CONST.STRING_TABLE))
            {
                txtValue.Text = string.Empty;
            }

            txtResult.Text = string.Empty;
            lblResult.Visible = false;
            if (val.Count > 0)
            {
                objItem = val[0];
                handleData(objItem);

                if (!dicData.ContainsKey(CONST.STRING_FORM_VALUE))
                {
                    txtFormat.Enabled = false;
                }
                else
                {
                    txtFormat.Enabled = true;
                }

                btnCreateResult.Enabled = true;

            }
            else
            {
                btnCreateResult.Enabled = false;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            cbKey.SelectedIndex = 0;

            txtFormat.Text = string.Empty;
            txtValue.Text = string.Empty;

            gridSetParam.Rows.Clear();
            gridSetParam.Refresh();

            btnCreateResult.Enabled = false;
            txtResult.Text = string.Empty;
            btnCopy.Enabled = false;
            lblResult.Visible = false;
        }

        private void handleData(ItemModel data)
        {
            try
            {
                int no = 1, index = 0;
                string name, key;
                bool isMess = false;
                gridSetParam.Rows.Clear();
                gridSetParam.Refresh();

                string txFromatValue = txtFormat.Text.Trim();
                string txValue = txtValue.Text.Trim();

                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = data.value.Split(stringSeparators, StringSplitOptions.None);

                List<ItemModel> lstSetingHandle = lstSeting.Where(obj => obj.key.Equals(data.type) && data.key.Equals(obj.value.Split('|')[0])).ToList();

                dicData = new Dictionary<string, string>();
                if (lstSetingHandle.Count == 1 && lstSetingHandle[0].value.Contains(data.key))
                {
                    int numRow = 1;
                    if (!string.IsNullOrEmpty(txValue))
                    {
                        numRow = int.Parse(txValue);
                    }

                    for (int i = 0; i < numRow; i++)
                    {
                        gridSetParam.Rows.Add(no, "Col class " + no, "", "");
                        no++;
                    }

                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] lstParam = line.Split(CONST.CHAR_SPACE);

                        foreach (string param in lstParam)
                        {
                            string pattern = @"{[0-9]}";
                            Regex rg = new Regex(pattern);
                            if (rg.IsMatch(param))
                            {
                                string value = removeChar(param, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                dicData.Add(value, string.Empty);
                            }
                        }
                    }

                    txtValue.Enabled = true;
                    return;
                }

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] lstParam = line.Split(CONST.CHAR_SPACE);

                    foreach (string param in lstParam)
                    {
                        if (param.Contains(CONST.STRING_MESSAGE)) isMess = true;

                        string pattern = @"{[0-9]}";
                        Regex rg = new Regex(pattern);
                        if (rg.IsMatch(param))
                        {
                            string[] lstItem = param.Split(CONST.CHAR_EQUALS);
                            if (lstItem.Length > 1)
                            {
                                name = lstItem[0];
                                key = lstItem[1];

                                key = removeChar(key, "", CONST.STRING_END_TAG, 1);
                                key = key.Replace(CONST.STRING_QUOTATION_MARKS, string.Empty);

                                if (key.Contains(CONST.STRING_FORM_VALUE) && !dicData.ContainsKey(CONST.STRING_FORM_VALUE))
                                {
                                    dicData.Add(CONST.STRING_FORM_VALUE, txtFormat.Text.Trim());
                                }

                                if (isMess && name.ToUpper().Equals(CONST.STRING_NAME_ID)) name = "Message " + name;
                                else name = CUtils.FirstCharToUpperCase(name);

                                if (key.ToUpper().Contains(CONST.STRING_TAG_FH))
                                {
                                    string[] lstFH = key.Split(CONST.CHAR_DOT);
                                    foreach (string fh in lstFH)
                                    {
                                        key = fh.ToUpper().Replace(CONST.STRING_TAG_FH, string.Empty);
                                        key = removeChar(key, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                        if (rg.IsMatch(fh) && !dicData.ContainsKey(key))
                                        {
                                            dicData.Add(key, isMess ? CONST.STRING_MESSAGE : string.Empty);
                                            gridSetParam.Rows.Add(no, name, string.Empty, key);
                                            no++;
                                        }
                                    }
                                    continue;
                                }
                                else if (key.ToUpper().Contains(CONST.STRING_TEST))
                                {
                                    string[] lstTest = key.Split(CONST.CHAR_DOT);
                                    foreach (string test in lstTest)
                                    {
                                        key = test.ToUpper().Replace(CONST.STRING_TEST, string.Empty);
                                        key = removeChar(key, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                        if (rg.IsMatch(test) && !dicData.ContainsKey(key))
                                        {
                                            dicData.Add(key, isMess ? CONST.STRING_MESSAGE : string.Empty);
                                            gridSetParam.Rows.Add(no, name, string.Empty, key);
                                            no++;
                                        }
                                    }
                                    continue;
                                }

                                key = removeChar(key, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                if (!dicData.ContainsKey(key))
                                {
                                    dicData.Add(key, isMess ? CONST.STRING_MESSAGE : string.Empty);
                                    gridSetParam.Rows.Add(no, name, string.Empty, key);
                                    no++;
                                }
                            }
                            else if (lstItem.Length == 1 && lstSetingHandle.Count > 0)
                            {
                                key = lstItem[0].Replace(CONST.STRING_C_SIGN, string.Empty);
                                if (index < lstSetingHandle.Count)
                                {
                                    string text = lstSetingHandle[index].value.Split('|')[1];

                                    if (!dicData.ContainsKey(key))
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, text, string.Empty, key);
                                        no++; index = index + 1;
                                    }
                                }
                            }
                        }
                    }
                }
                txtValue.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(CONST.MESS_ERROR_EXCEPTION.Replace("{0}", "Handle Data") + ex.Message,
                    CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCreateResult_Click(object sender, EventArgs e)
        {
            if (dicData.ContainsKey(CONST.STRING_FORM_VALUE))
            {
                string valTxFormat = txtFormat.Text.Trim();
                if (string.IsNullOrEmpty(valTxFormat))
                {
                    MessageBox.Show(CONST.MESS_FORMAT_VALUE_EMPTY, CONST.TEXT_CAPTION_ERROR, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dicData[CONST.STRING_FORM_VALUE] = valTxFormat;
            }

            List<ItemModel> lstSetingParam = lstSeting.Where(obj => CONST.STRING_FORMAT.Equals(obj.value.Split('|')[0].ToUpper())).ToList();

            foreach (DataGridViewRow item in gridSetParam.Rows)
            {
                string key = item.Cells[1].Value.ToString();
                string value = item.Cells[2].Value.ToString();
                string index = item.Cells[3].Value.ToString();

                if (valKey.ToUpper().Equals(CONST.STRING_TABLE))
                {
                    ItemModel objFormat = lstSetingParam.Find(obj => valKey.ToUpper().Equals(obj.value.Split('|')[1].ToUpper()));
                    string format = value;
                    if (objFormat != null)
                    {
                        format = objFormat.value.Split('|')[2];
                        format = format.Replace(CONST.STRING_FORM_VALUE, value);
                    }

                    List<string> lstKey = dicData.Keys.ToList();
                    for (int idx = 0; idx < lstKey.Count; idx++)
                    {
                        value = dicData[lstKey[idx]];
                        if (idx == 0)
                        {
                            dicData[lstKey[idx]] = value + "        " + format + CONST.STRING_ADD_LINE;
                        }
                        else
                        {
                            dicData[lstKey[idx]] = value + "        <tr>\r\n            <th></th>\r\n            <td></td>\r\n        </tr>" + CONST.STRING_ADD_LINE;
                        }
                    }
                }
                else if (dicData.ContainsKey(index))
                {

                    if (key.ToUpper().Contains(CONST.STRING_MESSAGE.ToUpper()))
                    {
                        SekkeiModel objSekkei = lstSekei.Find(obj => obj.physiName.Equals(value));
                        if (objSekkei != null)
                        {
                            dicData[index] = objSekkei.logicName;
                        }
                        else
                        {
                            dicData[index] = value;
                        }
                    }
                    else
                    {
                        if (lstSetingParam.Count > 0)
                        {
                            ItemModel objFormat = lstSetingParam.Find(obj => key.ToUpper().Equals(obj.value.Split('|')[1].ToUpper()));
                            string format = value;
                            if (objFormat != null)
                            {
                                format = objFormat.value.Split('|')[2];
                                format = format.Replace(CONST.STRING_FORM_VALUE, value);
                            }
                            else
                            {
                                objFormat = lstSetingParam.Find(obj => valKey.ToUpper().Equals(obj.value.Split('|')[1].ToUpper()) && key.ToUpper().Equals(obj.value.Split('|')[2].ToUpper()));
                                if (objFormat != null && !string.IsNullOrEmpty(value))
                                {
                                    format = objFormat.value.Split('|')[3];
                                    if (format.ToUpper().Contains(CONST.STRING_MESSAGE.ToUpper()))
                                    {
                                        SekkeiModel objSekkei = lstSekei.Find(obj => obj.physiName.Equals(value));
                                        if (objSekkei != null)
                                        {
                                            value = objSekkei.logicName;
                                        }
                                        format = format.Replace(CONST.STRING_FORM_VALUE, value);
                                    }
                                    format = format.Replace(CONST.STRING_FORM_VALUE, value);
                                }
                            }

                            dicData[index] = format;
                        }
                        else
                        {
                            dicData[index] = value;
                        }
                    }
                }
            }

            string result = objItem.value;
            foreach (KeyValuePair<string, string> dic in dicData)
            {
                result = result.Replace(dic.Key, dic.Value);
            }

            txtResult.Text = result;

            btnCopy.Enabled = true;
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

        /// <summary>
        /// Remove end char text in string
        /// </summary>
        /// <param name="val">text need change</param>
        /// <param name="txFistChar">first char check</param>
        /// <param name="txLastChar">last char check</param>
        /// <param name="model">0: fist, 1: last: 2: all</param>
        /// <param name="isUp">remove start after text</param>
        /// <returns></returns>
        private string removeChar(string val, string txFistChar, string txLastChar, int model, bool isUp = false)
        {
            int numStar = val.IndexOf(txFistChar);
            int numEnd = val.IndexOf(txLastChar);
            int length = val.Length - 1;
            if ((model == 0 && numStar == -1) || (model == 1 && numEnd == -1) || (model == 2 && numStar == -1)) return val;
            if (numStar == 0 && numEnd == length) return val;

            if (isUp && numEnd != length) numEnd++;

            if (model == 0 || (model == 2 && numEnd == length)) return val.Substring(numStar);
            else if (model == 1 || (model == 2 && numStar == 0)) return val.Substring(0, numEnd);
            else val = val.Substring(numStar); return val.Substring(0, val.Length - val.IndexOf(txLastChar));
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
