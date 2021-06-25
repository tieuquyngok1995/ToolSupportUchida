using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ToolSupportUchida.Model;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.View
{
    public partial class FormCreateAdapter : Form
    {
        private List<AdapterModel> lstAdapter;

        private List<AdapterModel> lstRows;
        private List<AdapterModel> lstColumn;
        private List<AdapterModel> lstSubRows;
        private List<AdapterModel> lstSubColumn;

        private string[] lstLogic;
        private string[] lstPhysi;
        private string[] stringSeparators;

        private string valRows;
        private string valColumn;
        private string valSubRows;
        private string valSubColumn;

        private int indexTab;
        private int maxLengthRow;

        private bool isAppend;

        #region Load Form
        public FormCreateAdapter(List<AdapterModel> lstAdapter)
        {
            InitializeComponent();

            this.lstAdapter = lstAdapter;

            lstLogic = new string[0];
            lstPhysi = new string[0];

            stringSeparators = new string[] { CONST.STRING_ADD_LINE };

            indexTab = 0;
            maxLengthRow = 0;

            isAppend = true;
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
            lstRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_ROWS)).ToList();
            if (lstRows.Count > 0)
            {
                cbRow.DataSource = new BindingSource(lstRows, null);
                cbRow.DisplayMember = CONST.ITEM_KEY;
                cbRow.ValueMember = CONST.ITEM_VALUE;
                cbRow.SelectedIndex = 0;
            }

            lstColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_COLUMNS)).ToList();
            if (lstColumn.Count > 0)
            {
                cbColumn.DataSource = new BindingSource(lstColumn, null);
                cbColumn.DisplayMember = CONST.ITEM_KEY;
                cbColumn.ValueMember = CONST.ITEM_VALUE;
                cbColumn.SelectedIndex = 0;
            }

            lstSubRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_ROWS)).ToList();
            if (lstSubRows.Count > 0)
            {
                cbSubRow.DataSource = new BindingSource(lstSubRows, null);
                cbSubRow.DisplayMember = CONST.ITEM_KEY;
                cbSubRow.ValueMember = CONST.ITEM_VALUE;
                cbSubRow.SelectedIndex = 0;
            }

            lstSubColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_COLUMNS)).ToList();
            if (lstSubColumn.Count > 0)
            {
                cbSubColumn.DataSource = new BindingSource(lstSubColumn, null);
                cbSubColumn.DisplayMember = CONST.ITEM_KEY;
                cbSubColumn.ValueMember = CONST.ITEM_VALUE;
                cbSubColumn.SelectedIndex = 0;
            }
        }
        #endregion

        #region Event
        private void txtLogic_TextChanged(object sender, EventArgs e)
        {
            if (txtLogic.Text.Length == 0)
            {
                lblNumLogic.Visible = false;
            }
            else
            {
                txtLogic.Text = Regex.Replace(txtLogic.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                if (txtLogic.Text.LastIndexOf("\r\n") == txtLogic.Text.Length - 2)
                {
                    txtLogic.Text = txtLogic.Text.Substring(0, txtLogic.Text.Length - 2);
                }
                lstLogic = txtLogic.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumLogic.Text = CONST.TEXT_LINE_NUM + lstLogic.Length;
                lblNumLogic.Visible = true;
            }

            displayButtonInOut();
        }

        private void txtPhysi_TextChanged(object sender, EventArgs e)
        {
            if (txtPhysi.Text.Length == 0)
            {
                lblNumPhy.Visible = false;
            }
            else
            {
                txtPhysi.Text = Regex.Replace(txtPhysi.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
                if (txtPhysi.Text.LastIndexOf("\r\n") == txtPhysi.Text.Length - 2)
                {
                    txtPhysi.Text = txtPhysi.Text.Substring(0, txtPhysi.Text.Length - 2);
                }
                lstPhysi = txtPhysi.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumPhy.Text = CONST.TEXT_LINE_NUM + lstPhysi.Length;
                lblNumPhy.Visible = true;
            }

            displayButtonInOut();
        }

        private void cbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdapterModel obj = (AdapterModel)cbRow.SelectedItem;
            valRows = obj.value;
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdapterModel obj = (AdapterModel)cbColumn.SelectedItem;
            valColumn = obj.value;
        }

        private void cbSubRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdapterModel obj = (AdapterModel)cbSubRow.SelectedItem;
            valSubRows = obj.value;
        }

        private void cbSubColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            AdapterModel obj = (AdapterModel)cbSubColumn.SelectedItem;
            valSubColumn = obj.value;
        }

        private void btnCreateIn_Click(object sender, EventArgs e)
        {
            isAppend = true;
            indexTab = 0;
            maxLengthRow = 0;

            Dictionary<string, string> lstName = new Dictionary<string, string>();

            lstLogic = txtLogic.Text.Split(stringSeparators, StringSplitOptions.None);
            lstLogic = lstLogic.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string result = string.Empty;
            string subResult = string.Empty;
            string tmpResult = string.Empty;
            string tab = string.Empty;
            string nextLine = string.Empty;

            StringBuilder template = new StringBuilder();
            StringBuilder subTemplate = new StringBuilder();

            int lengthText = 0;
            int lengthListLogic = lstLogic.Length;
            int numTab = 0;

            for (int i = 0; i < lengthListLogic; i++)
            {
                string lineLogic = lstLogic[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty);
                string linePhysi = lstPhysi[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty);

                if (lineLogic.Contains(CONST.STRING_LIST_JP) && linePhysi.Contains(CONST.STRING_LIST_EN))
                {
                    string nameList = linePhysi.Replace(CONST.STRING_LIST_EN, String.Empty);

                    if (i <= lstLogic.Length - 2)
                    {
                        nextLine = removeEndTab(lstLogic[i + 1]);
                        numTab = getNumTab(lstLogic[i + 1]);
                    }

                    if (numTab == indexTab)
                    {
                        if (i == lstLogic.Length - 1)
                        {
                            template = CUtils.CreateAppenIn(CONST.STRING_JOIN_LIST_END, tab);
                            tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(nameList),
                                valRows, lineLogic);
                        }
                        else
                        {
                            template = CUtils.CreateAppenIn(CONST.STRING_JOIN_LIST, tab);
                            tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(nameList),
                                valRows, valColumn, lineLogic);
                        }

                        lengthText = tmpResult.LastIndexOf("/");

                        if (lengthText > maxLengthRow)
                        {
                            maxLengthRow = lengthText;
                        }

                        result = string.IsNullOrEmpty(result) ? result : result + CONST.STRING_ADD_LINE;
                        result = result + tmpResult;
                    }
                    else
                    {
                        lstName.Add(lineLogic, nameList);
                        template = CUtils.CreateTemplateForEachInOpen(tab);
                        result = result + string.Format(template.ToString(), CUtils.FirstCharToLowerCase(nameList), CUtils.FirstCharToUpperCase(nameList));
                        result = result + tab + "{" + CONST.STRING_ADD_LINE;

                        tab = createTab();
                        result = result + tab + CONST.STRING_CREATE_BUILDER;
                    }
                }
                else
                {
                    if (isAppend) {
                        template = CUtils.CreateAppenIn(CONST.STRING_CREATE, tab);
                        isAppend = false;
                    }
                    else
                    {
                        template = CUtils.CreateAppenIn(checkNextEndOfList(i, lengthListLogic), tab);
                    }

                    tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(linePhysi),
                        valColumn, lineLogic.Replace(CONST.STRING_TAB, string.Empty));
                    lengthText = tmpResult.LastIndexOf("/");

                    if (lengthText > maxLengthRow)
                    {
                        maxLengthRow = lengthText;
                    }

                    result = string.IsNullOrEmpty(result) ? result : result + CONST.STRING_ADD_LINE;
                    result = result + tmpResult;
                }

                if (indexTab > 0)
                {
                    if (i <= lstLogic.Length - 2)
                    {
                        nextLine = removeEndTab(lstLogic[i + 1]);
                        numTab = getNumTab(lstLogic[i + 1]);
                    }
                    else if (i == lstLogic.Length -1) {
                        numTab = getNumTab(lstLogic[i]);
                        numTab = (indexTab - lstName.Count) >= 0 ? (indexTab - lstName.Count) : 0;
                    }


                    if (indexTab > numTab)
                    {
                        while (indexTab > numTab)
                        {
                            tab = removeTab();

                            result = result + CONST.STRING_ADD_LINE + tab + "}" + CONST.STRING_ADD_LINE;

                            if (indexTab == numTab)
                            {
                                if (i == lstLogic.Length - 1)
                                {
                                    template = CUtils.CreateAppenIn(CONST.STRING_JOIN_END, tab);
                                }
                                else
                                {
                                    template = CUtils.CreateAppenIn(CONST.STRING_CREATE_JOIN, tab);
                                }
                                isAppend = false;
                            }
                            else
                            {
                                template = CUtils.CreateAppenIn(CONST.STRING_CREATE_JOIN_END, tab);
                            }

                            if (i == lstLogic.Length - 1 && indexTab == numTab)
                            {
                                tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(lstName.Values.Last()),
                                valRows, lstName.Keys.Last());
                            }
                            else
                            {
                                tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(lstName.Values.Last()),
                                valRows, valColumn, lstName.Keys.Last());
                            }
                            lengthText = tmpResult.LastIndexOf("/");

                            if (lengthText > maxLengthRow)
                            {
                                maxLengthRow = lengthText;
                            }

                            result = string.IsNullOrEmpty(result) ? result : result + CONST.STRING_ADD_LINE;
                            result = result + tmpResult;

                            if (lstName.Count > 0)
                            {
                                lstName.Remove(lstName.Keys.Last());
                            }
                        }

                    }
                }
            }

            txtResult.Text = formatTextIn(result);

            if (result.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void btnCreateOut_Click(object sender, EventArgs e)
        {
            string result = string.Empty;

            txtResult.Text = result;

            if (result.Length > 0)
            {
                btnCopy.Enabled = true;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResult.Text))
            {
                return;
            }

            Clipboard.Clear();
            Clipboard.SetText(txtResult.Text);
            lblResult.Visible = true;
        }
        #endregion

        #region Method

        private string checkNextEndOfList(int index, int length)
        {
            if (index == length - 1)
            {
                return CONST.STRING_END;
            }
            if (index + 1 == length - 1)
            {
                return string.Empty;
            }
            else if (index + 1 < length && lstLogic[index].Length >= indexTab && lstLogic[index + 1].Length >= indexTab &&
                    (lstLogic[index + 1].Contains(CONST.STRING_LIST_JP) && lstPhysi[index + 1].Contains(CONST.STRING_LIST_EN) ||
                     lstLogic[index].LastIndexOf(CONST.CHAR_TAB, indexTab) > lstLogic[index + 1].LastIndexOf(CONST.CHAR_TAB, indexTab)))
            {

                isAppend = true;
                return CONST.STRING_END_LINE;
            }
            else
            {
                return string.Empty;
            }
        }

        private string formatTextIn( string input)
        {
            string result = string.Empty;
            string textAdd = string.Empty;
            string[] lstInput = input.Split(stringSeparators, StringSplitOptions.None);

            int lengthText = 0;

            foreach (string line in lstInput)
            {
                lengthText = line.LastIndexOf("/");
                if (lengthText != -1 && lengthText < maxLengthRow)
                {
                    textAdd = new string(CONST.CHAR_SPACE, maxLengthRow - lengthText);
                    result = result + line.Substring(0, lengthText-1) + textAdd + line.Substring(lengthText - 1, line.Length - lengthText) + CONST.STRING_ADD_LINE;
                }
                else
                {
                    result = result + line + CONST.STRING_ADD_LINE;
                }
            }

            return result;
        }

        private void displayButtonInOut()
        {
            if (lstLogic.Length == lstPhysi.Length )
            {
                btnCreateIn.Enabled = true;
                btnCreateOut.Enabled = true;
            }
            else
            {
                btnCreateIn.Enabled = false;
                btnCreateOut.Enabled = false;
            }
        }

        private string createTab()
        {
            indexTab++;
            int length = indexTab * 4;
            return new string(CONST.CHAR_SPACE, length);
        }

        private string removeTab()
        {
            indexTab--;
            if (indexTab < 0)
            {
                indexTab = 0;
            }
            int length = indexTab * 4;
            return new string(CONST.CHAR_SPACE, length);
        }

        private string removeEndTab(string input)
        {
            if (string.IsNullOrEmpty(input) || input == string.Empty)
            {
                return input;
            }

            while (input.Last().Equals(CONST.CHAR_TAB)) {
                input = input.Substring(0, input.Length - 1);
            }

            return input;
        }

        private int getNumTab(string input)
        {
            int result = 0;
            if (string.IsNullOrEmpty(input) || input == string.Empty)
            {
                return 0;
            }

            while (input.First().Equals(CONST.CHAR_TAB))
            {
                result++;
                input = input.Substring(1, input.Length-1);
            }

            return result;
        }

        #endregion
    }
}
