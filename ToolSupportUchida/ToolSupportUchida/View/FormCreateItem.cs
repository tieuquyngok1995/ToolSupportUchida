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
        private List<ItemModel> lstKey;

        private List<string> lstType;
        private Dictionary<string, string> dicData;

        #region Load Form
        public FormCreateItem(List<SekkeiModel> lstSekei, List<string> lstType, List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstSekei = lstSekei;

            this.lstData = lstItem;
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
        }

        private void LoadData()
        {
            cbType.DataSource = lstType;

            lstKey = lstData.Where(obj => obj.type.Equals(CONST.ITEM_HTML)).ToList();
            if (lstKey.Count > 0)
            {
                cbKey.DataSource = new BindingSource(lstKey, null);
                cbKey.DisplayMember = CONST.ITEM_KEY;
                cbKey.ValueMember = CONST.ITEM_VALUE;
                cbKey.SelectedIndex = 0;
            }
        }

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
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string selectText = "";
            if (cbKey.SelectedItem != null)
            {
                ItemModel obj = (ItemModel)cbKey.SelectedItem;
                selectText = obj.key;
            }
            List<ItemModel> val = lstData.Where(obj => obj.key.Equals(selectText)).ToList();

            if (val.Count > 0)
            {
                handleData(val[0]);
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
        }
        #endregion

        #region Event

        private void handleData(ItemModel data)
        {
            try
            {
                int no = 1, index = 1;
                gridSetParam.Rows.Clear();
                gridSetParam.Refresh();

                string txFromatValue = txtFormat.Text.Trim();
                string txValue = txtValue.Text.Trim();

                string[] stringSeparators = new string[] { "\r\n" };
                string[] lines = data.value.Split(stringSeparators, StringSplitOptions.None);

                if (data.key.ToUpper().Equals(CONST.STRING_TABLE))
                {
                    int numRow = 1;
                    if (!string.IsNullOrEmpty(txValue))
                    {
                        numRow = int.Parse(txValue);
                    }

                    for (int i = 0; i < numRow; i++)
                    {
                        gridSetParam.Rows.Add(no, "col class " + no, "");
                        no++;
                    }

                    return;
                }

                dicData = new Dictionary<string, string>();
                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] lstParam = line.Split(CONST.CHAR_SPACE);

                    foreach (string param in lstParam)
                    {
                        string name, key;
                        string pattern = @"{\d|\D}";
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

                                if (key.ToUpper().Contains(CONST.STRING_TAG_FH))
                                {
                                    string[] lstFH = key.Split(CONST.CHAR_DOT);
                                    foreach (string fh in lstFH)
                                    {
                                        key = fh.ToUpper().Replace(CONST.STRING_TAG_FH, string.Empty);
                                        key = removeChar(key, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                        if (rg.IsMatch(fh) && !dicData.ContainsKey(key))
                                        {
                                            dicData.Add(key, string.Empty);
                                            gridSetParam.Rows.Add(no, name, key);
                                            no++;
                                        }
                                    }
                                }

                                key = removeChar(key, CONST.STRING_O_CUR_BRACKETS, CONST.STRING_C_CUR_BRACKETS, 2, true);
                                if (!dicData.ContainsKey(key))
                                {
                                    dicData.Add(key, string.Empty);
                                    gridSetParam.Rows.Add(no, name, key);
                                    no++;
                                }
                            }
                            else if (cbKey.SelectedItem != null)
                            {
                                ItemModel obj = (ItemModel)cbKey.SelectedItem;
                                if (obj.key.ToUpper().Equals(CONST.STRING_INPUT_TEXT) && lstItem.Length == 1)
                                {
                                    key = lstItem[0].Replace(CONST.STRING_C_SIGN, string.Empty);
                                    if (!dicData.ContainsKey(key) && index == 1)
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, CONST.STRING_FOCUS, key);
                                        no++; index++;
                                    }
                                    else if (!dicData.ContainsKey(key) && index == 2)
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, CONST.STRING_SIZE, key);
                                        no++; index++;
                                    }
                                    else if (!dicData.ContainsKey(key) && index == 3)
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, CONST.STRING_READONLY, key);
                                        no++; index++;
                                    }
                                    else if (!dicData.ContainsKey(key) && index == 4)
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, CONST.STRING_TITLE, key);
                                        no++; index++;
                                    }
                                    else if (!dicData.ContainsKey(key) && index == 5)
                                    {
                                        dicData.Add(key, string.Empty);
                                        gridSetParam.Rows.Add(no, CONST.STRING_SPAN, key);
                                        no++; index++;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An abnormal error occurs in the function: HandleData\nError content: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(txtResult.Text))
            //{
            //    return;
            //}

            //Clipboard.Clear();
            //Clipboard.SetText(txtResult.Text);
            //lblResult.Visible = true;
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
            if ((model == 0 && numStar == -1) || (model == 1 && numEnd == -1)) return val;
            if (numStar == 0 && numEnd == length) return val;

            if (isUp && numEnd != length) numEnd++;

            StringBuilder str = new StringBuilder(val);

            if (model == 0) return val.Substring(numStar, length);
            else if (model == 1) return val.Substring(0, numEnd);
            else val = val.Remove(numEnd); return val.Substring(numStar, val.Length);

        }

        #endregion
    }
}
