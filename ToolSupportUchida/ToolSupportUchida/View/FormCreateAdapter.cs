using System;
using System.Collections.Generic;
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
    public partial class FormCreateAdapter : Form
    {
        private List<ItemModel> lstItem;

        private List<ItemModel> lstHTML;

        private string[] lstLogic;
        private string[] lstPhysi;

        private string valRows;
        private string valColumn;
        private string valSubRows;
        private string valSubColumn;

        private int indexTab;
        private int maxLengthRow;

        private bool isAppend;

        #region Load Form
        public FormCreateAdapter(List<ItemModel> lstItem)
        {
            InitializeComponent();

            this.lstItem = lstItem;

            lstLogic = new string[0];
            lstPhysi = new string[0];

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
            //lstRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_ROWS)).ToList();
            //if (lstRows.Count > 0)
            //{
            //    cbRow.DataSource = new BindingSource(lstRows, null);
            //    cbRow.DisplayMember = CONST.ITEM_KEY;
            //    cbRow.ValueMember = CONST.ITEM_VALUE;
            //    cbRow.SelectedIndex = 0;
            //}

            //lstColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_COLUMNS)).ToList();
            //if (lstColumn.Count > 0)
            //{
            //    cbColumn.DataSource = new BindingSource(lstColumn, null);
            //    cbColumn.DisplayMember = CONST.ITEM_KEY;
            //    cbColumn.ValueMember = CONST.ITEM_VALUE;
            //    cbColumn.SelectedIndex = 0;
            //}

            //lstSubRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_ROWS)).ToList();
            //if (lstSubRows.Count > 0)
            //{
            //    cbSubRow.DataSource = new BindingSource(lstSubRows, null);
            //    cbSubRow.DisplayMember = CONST.ITEM_KEY;
            //    cbSubRow.ValueMember = CONST.ITEM_VALUE;
            //    cbSubRow.SelectedIndex = 0;
            //}

            //lstSubColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_COLUMNS)).ToList();
            //if (lstSubColumn.Count > 0)
            //{
            //    cbSubColumn.DataSource = new BindingSource(lstSubColumn, null);
            //    cbSubColumn.DisplayMember = CONST.ITEM_KEY;
            //    cbSubColumn.ValueMember = CONST.ITEM_VALUE;
            //    cbSubColumn.SelectedIndex = 0;
            //}
        }
        #endregion

        #region Event
        private void txtLogic_TextChanged(object sender, EventArgs e)
        {

            //lstLogic = txtLogic.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            //if (lstLogic.Length > 0)
            //{
            //    lblNumLogic.Visible = true;
            //    lblNumLogic.Text = string.Concat(CONST.TEXT_LINE_NUM, lstLogic.Length);
            //}
            //else
            //{
            //    lblNumLogic.Visible = false;
            //}

            displayButtonInOut();
        }

        private void txtLogic_Leave(object sender, EventArgs e)
        {
           // txtLogic.Text = Regex.Replace(txtLogic.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
        }

        private void txtPhysi_TextChanged(object sender, EventArgs e)
        {
            //lstPhysi = txtPhysi.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.RemoveEmptyEntries);

            //if (lstPhysi.Length > 0)
            //{
            //    lblNumPhy.Visible = true;
            //    lblNumPhy.Text = string.Concat(CONST.TEXT_LINE_NUM, lstPhysi.Length);
            //}
            //else
            //{
            //    lblNumPhy.Visible = false;
            //}

            displayButtonInOut();
        }

        private void txtPhysi_Leave(object sender, EventArgs e)
        {
            //txtPhysi.Text = Regex.Replace(txtPhysi.Text, @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline);
        }

        private void cbRow_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AdapterModel obj = (AdapterModel)cbRow.SelectedItem;
            //valRows = obj.value;
        }

        private void cbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
           // AdapterModel obj = (AdapterModel)cbColumn.SelectedItem;
            //valColumn = obj.value;
        }

        private void cbSubRow_SelectedIndexChanged(object sender, EventArgs e)
        {
           // AdapterModel obj = (AdapterModel)cbSubRow.SelectedItem;
            //valSubRows = obj.value;
        }

        private void cbSubColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  AdapterModel obj = (AdapterModel)cbSubColumn.SelectedItem;
           // valSubColumn = obj.value;
        }

        private void btnCreateIn_Click(object sender, EventArgs e)
        {
            isAppend = true;
            indexTab = 0;
            maxLengthRow = 0;

            Dictionary<string, string> lstName = new Dictionary<string, string>();

            //lstLogic = txtLogic.Text.Split(CONST.STRING_SEPARATORS, StringSplitOptions.None);
            lstLogic = lstLogic.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string result = string.Empty;
            string subResult = string.Empty;
            string tmpResult = string.Empty;
            string tab = string.Empty;
            string template = string.Empty;

            int lengthText = 0;
            int lengthListLogic = lstLogic.Length;
            int numTab = 0;

            for (int i = 0; i < lengthListLogic; i++)
            {
                string lineLogic = lstLogic[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty).Trim();
                string linePhysi = lstPhysi[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty).Trim(); ;

                if (lineLogic.Contains(CONST.STRING_LIST_JP) && linePhysi.Contains(CONST.STRING_LIST_EN))
                {
                    string nameList = linePhysi.Replace(CONST.STRING_LIST_EN, String.Empty);

                    if (i <= lstLogic.Length - 2)
                    {
                        numTab = CUtils.GetNumTab(lstLogic[i + 1]);
                    }

                    if (numTab == indexTab)
                    {
                        if (i == lstLogic.Length - 1)
                        {
                            template = CUtils.CreateAppenIn(CONST.STRING_JOIN_LIST_END, tab);
                            tmpResult = string.Format(template, CUtils.FirstCharToUpperCase(nameList),
                                valRows, lineLogic);
                        }
                        else
                        {
                            template = CUtils.CreateAppenIn(CONST.STRING_JOIN_LIST, tab);
                            tmpResult = string.Format(template, CUtils.FirstCharToUpperCase(nameList),
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
                        if (!lstName.ContainsKey(lineLogic))
                        {
                            lstName.Add(lineLogic, nameList);
                        }

                        template = CUtils.CreTmlAdapForEachIn(tab);
                        result = result + string.Format(template, CUtils.FirstCharToLowerCase(nameList), CUtils.FirstCharToUpperCase(nameList));
                        result = result + tab + "{" + CONST.STRING_ADD_LINE;

                        tab = CUtils.CreateTab(ref indexTab);
                        result = result + tab + CONST.STRING_CREATE_BUILDER;
                    }
                }
                else
                {
                    if (isAppend)
                    {
                        template = CUtils.CreateAppenIn(CONST.STRING_CREATE, tab);
                        isAppend = false;
                    }
                    else
                    {
                        template = CUtils.CreateAppenIn(checkNextEndOfList(i, lengthListLogic), tab);
                    }

                    tmpResult = string.Format(template, CUtils.FirstCharToUpperCase(linePhysi),
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
                        numTab = CUtils.GetNumTab(lstLogic[i + 1]);
                    }
                    else if (i == lstLogic.Length - 1)
                    {
                        numTab = CUtils.GetNumTab(lstLogic[i]);
                        numTab = (indexTab - lstName.Count) >= 0 ? (indexTab - lstName.Count) : 0;
                    }


                    if (indexTab > numTab)
                    {
                        while (indexTab > numTab)
                        {
                            tab = CUtils.RemoveTab(ref indexTab);

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
                                tmpResult = string.Format(template, CUtils.FirstCharToUpperCase(lstName.Values.Last()),
                                valRows, lstName.Keys.Last());
                            }
                            else
                            {
                                tmpResult = string.Format(template, CUtils.FirstCharToUpperCase(lstName.Values.Last()),
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

           // txtResult.Text = CUtils.FormatCode(result, maxLengthRow);

            if (result.Length > 0)
            {
              //  btnCopy.Enabled = true;
            }
        }

        private void btnCreateOut_Click(object sender, EventArgs e)
        {
            indexTab = 0;

            string result = string.Empty;
            string tab = string.Empty;
            string template = string.Empty;

            Dictionary<string, string> lstName = new Dictionary<string, string>();

            int lengthListLogic = lstLogic.Length;
            int dAry = 1;
            int numTab = 0;

            for (int i = 0; i < lengthListLogic; i++)
            {
                string lineLogic = lstLogic[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty).Trim();
                string linePhysi = lstPhysi[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty).Trim();
                if (i == 0)
                {
                    //if (ckbCreate.Checked)
                    //{
                    //    template = CUtils.CreTmlAdapModelOut(tab, CONST.STRING_CREATE_LIST);
                    //    result = result + string.Format(template, linePhysi);

                    //    template = CUtils.CreTmlAdapForEachOut(tab, dAry, CONST.STRING_CREATE);
                    //    result = result + string.Format(template, valRows);

                    //    result = result + "{" + CONST.STRING_ADD_LINE;
                    //    tab = CUtils.CreateTab(ref indexTab);

                    //    template = CUtils.CreTmlAdapModelOut(tab, CONST.STRING_CREATE);
                    //    result = result + string.Format(template, linePhysi);
                    //}

                    template = CUtils.CreTmlAdapArrayOut(tab, dAry);
                    result = result + string.Format(template, valColumn);
                }
                else if (lineLogic.Contains(CONST.STRING_LIST_JP) && linePhysi.Contains(CONST.STRING_LIST_EN))
                {
                    string nameList = linePhysi.Replace(CONST.STRING_LIST_EN, String.Empty);
                    int numTabCheck = 0;

                    if (i <= lstLogic.Length - 2)
                    {
                        numTabCheck = CUtils.GetNumTab(lstLogic[i + 1]);
                        //if (ckbCreate.Checked)
                        //{
                        //    numTabCheck++;
                        //}
                    }
                    else if (i == lstLogic.Length - 1)
                    {
                        numTabCheck = CUtils.GetNumTab(lstLogic[i]);
                        //if (ckbCreate.Checked)
                        //{
                        //    numTabCheck++;
                        //}
                    }

                    if (numTabCheck == numTab)
                    {
                        if (numTabCheck > 1 && lstName.Count > 1)
                        {
                            template = CUtils.CreTmlAdapListObjOut(tab, dAry, CONST.STRING_SPLIT_ADD_LIST);
                            result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty),
                                lstName.Last().Key, nameList, valSubRows);
                        }
                        else
                        {
                            template = CUtils.CreTmlAdapListObjOut(tab, dAry, CONST.STRING_SPLIT_LIST);
                            result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty), nameList, valSubRows);
                        }
                    }
                    else
                    {
                        if (lstName.Count > 0)
                        {
                            template = CUtils.CreTmlAdapListObjOut(tab, dAry, CONST.STRING_CREATE_LIST);
                            result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty),
                                lstName.Last().Key, nameList);
                        }
                        else
                        {
                            template = CUtils.CreTmlAdapListObjOut(tab, dAry, CONST.STRING_CREATE);
                            result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty), nameList);
                        }

                        if (!lstName.ContainsKey(CUtils.FirstCharToLowerCase(nameList)))
                        {
                            lstName.Add(CUtils.FirstCharToLowerCase(nameList), linePhysi);
                        }

                        template = CUtils.CreTmlAdapForEachOut(tab, dAry, CONST.STRING_CREATE_SPLIT);
                        result = result + string.Format(template, valSubRows);

                        result = result + tab + "{" + CONST.STRING_ADD_LINE;
                        tab = CUtils.CreateTab(ref indexTab);
                        dAry++;

                        template = CUtils.CreTmlAdapModelOut(tab, CONST.STRING_CREATE_SPLIT);
                        result = result + string.Format(template, nameList, CUtils.FirstCharToLowerCase(nameList));

                        template = CUtils.CreTmlAdapArrayOut(tab, dAry);
                        result = result + string.Format(template, valSubColumn);
                    }


                }
                else
                {
                    if (lstName.Count > 0)
                    {
                        template = CUtils.CreTmlAdapOut(tab, dAry, CONST.STRING_CREATE_SPLIT);
                        result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty), lstName.Last().Key, linePhysi);
                    }
                    else
                    {
                        template = CUtils.CreTmlAdapOut(tab, dAry, CONST.STRING_CREATE);
                        result = result + string.Format(template, lineLogic.Replace(CONST.STRING_TAB, string.Empty), linePhysi);
                    }

                }

                if (indexTab > 0)
                {
                    if (i <= lstLogic.Length - 2)
                    {
                        numTab = CUtils.GetNumTab(lstLogic[i + 1]);
                        //if (ckbCreate.Checked)
                        //{
                        //    numTab++;
                        //}
                    }
                    else if (i == lstLogic.Length - 1)
                    {
                        numTab = CUtils.GetNumTab(lstLogic[i]);
                        numTab = (indexTab - lstName.Count) >= 0 ? (indexTab - lstName.Count) : 0;
                        //if (ckbCreate.Checked)
                        //{
                        //    numTab++;
                        //}
                    }


                    if (indexTab > numTab)
                    {
                        while (indexTab > numTab)
                        {
                            string keyListName = lstName.Last().Key;
                            string valListName = lstName.Last().Value;
                            if (lstName.Count > 1)
                            {
                                lstName.Remove(keyListName);
                                dAry--;

                                template = CUtils.CreTmlAdapAddListOut(tab, CONST.STRING_ADD_LIST_SPLIT);
                                result = result + CONST.STRING_ADD_LINE + string.Format(template, lstName.Last().Key, valListName, keyListName);
                            }
                            else
                            {
                                lstName.Remove(keyListName);
                                dAry--;

                                template = CUtils.CreTmlAdapAddListOut(tab, CONST.STRING_ADD_LIST);
                                result = result + CONST.STRING_ADD_LINE + string.Format(template, valListName, keyListName);
                            }

                            tab = CUtils.RemoveTab(ref indexTab);
                            result = result + tab + "}" + CONST.STRING_ADD_LINE;
                        }

                    }
                }

                //if (i == (lstLogic.Length - 1) && ckbCreate.Checked)
                //{
                //    tab = CUtils.RemoveTab(ref indexTab);
                //    result = result + tab + "outputModelList.Add(outputModel);" + CONST.STRING_ADD_LINE;
                //    result = result + "}";
                //}
            }

            //txtResult.Text = result;

            //if (result.Length > 0)
            //{
            //    btnCopy.Enabled = true;
            //}
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

        private void displayButtonInOut()
        {
            //if (lstLogic.Length == lstPhysi.Length)
            //{
            //    btnCreateIn.Enabled = true;
            //    btnCreateOut.Enabled = true;
            //}
            //else
            //{
            //    btnCreateIn.Enabled = false;
            //    btnCreateOut.Enabled = false;
            //}
        }

        #endregion
    }
}
