using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        #region Load Form
        public FormCreateItem(List<SekkeiModel> lstSekei, List<string> lstType, List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstSekei = lstSekei;

            this.lstData = lstItem;
            this.lstType = lstType;
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
            try {
                int no = 1;
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

                foreach (string line in lines)
                {
                    if (string.IsNullOrEmpty(line)) continue;

                    string[] lstParam = line.Split(CONST.CHAR_SPACE);
                   
                    foreach(string param in lstParam)
                    {
                        string pattern = @"{\d|\D}";
                        Regex rg = new Regex(pattern);
                        if (rg.IsMatch(param))
                        {
                            Console.WriteLine(param);
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

        private int checkEndTag(string val)
        {
            if (val.Contains(CONST.STRING_END_TAG))
            {
                return val.IndexOf(CONST.STRING_END_TAG);
            }
            else
            {
                return -1;
            }
        }

        private string removeEndTag(string val)
        {
            int numEnd = checkEndTag(val);
            if (numEnd == -1)
            {
                return val;
            }
            else
            {
                return val.Substring(0, numEnd);
            }
        }

        #endregion
    }
}
