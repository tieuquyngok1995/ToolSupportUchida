using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private string[] lsttype;
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
            lsttype = new string[0];

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
                if (txtLogic.Text.Length > 2 && txtLogic.Text.Substring(txtLogic.Text.Length - 2).Equals(CONST.STRING_ADD_LINE))
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
                if (txtPhysi.Text.Length > 2 && txtPhysi.Text.Substring(txtPhysi.Text.Length - 2).Equals(CONST.STRING_ADD_LINE))
                {
                    txtPhysi.Text = txtPhysi.Text.Substring(0, txtPhysi.Text.Length - 2);
                }

                lstPhysi = txtPhysi.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumPhy.Text = CONST.TEXT_LINE_NUM + lstPhysi.Length;
                lblNumPhy.Visible = true;
            }

            displayButtonInOut();
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            if (txtType.Text.Length == 0)
            {
                lblNumType.Visible = false;
            }
            else
            {
                if (txtType.Text.Length > 2 && txtType.Text.Substring(txtType.Text.Length - 2).Equals(CONST.STRING_ADD_LINE))
                {
                    txtType.Text = txtType.Text.Substring(0, txtType.Text.Length - 2);
                }

                lsttype = txtType.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumType.Text = CONST.TEXT_LINE_NUM + lsttype.Length;
                lblNumType.Visible = true;
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
            lstLogic = txtLogic.Text.Split(stringSeparators, StringSplitOptions.None);
            lstLogic = lstLogic.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            string result = string.Empty;
            string tmpResult = string.Empty;
            StringBuilder template = new StringBuilder();

            int lengthText = 0;

            for(int i = 0; i < lstLogic.Length; i++)
            {
                string lineLogic = lstLogic[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty);
                string linePhysi = lstPhysi[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty);
                string lineType = lsttype[i].Replace(CONST.STRING_CARRIAGE_RETUR, string.Empty);

                if (lineLogic.Contains(CONST.STRING_LIST_JP) && linePhysi.Contains(CONST.STRING_LIST_EN))
                {

                }
                else
                {
                    if (isAppend) {
                        template = CUtils.CreateAppenIn(isAppend);
                        isAppend = false;
                    }
                    else
                    {
                        template = CUtils.CreateAppenIn(isAppend);
                    }

                    tmpResult = string.Format(template.ToString(), CUtils.FirstCharToUpperCase(linePhysi), valColumn, lineLogic);
                    lengthText = tmpResult.LastIndexOf("/");

                    if (lengthText > maxLengthRow)
                    {
                        maxLengthRow = lengthText;
                    }

                    result = result + tmpResult;
                    result = result + CONST.STRING_ADD_LINE;
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

        private string formatTextIn( string input)
        {
            string result = string.Empty;
            string textAdd = string.Empty;
            string[] lstInput = input.Split(stringSeparators, StringSplitOptions.None);
            lstInput = lstInput.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            int lengthText = 0;

            foreach (string line in lstInput)
            {
                lengthText = line.LastIndexOf("/");
                if (lengthText < maxLengthRow)
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
            if (lstLogic.Length == lstPhysi.Length && lstLogic.Length == lsttype.Length)
            {
                btnCreateIn.Enabled = true;
                btnCreateOut.Enabled = true;
                btnClear.Enabled = true;
            }
            else
            {
                btnCreateIn.Enabled = false;
                btnCreateOut.Enabled = false;
                btnClear.Enabled = false;
            }
        }

        private string createTab()
        {
            int length = indexTab * 4;
            return new string(CONST.CHAR_SPACE, length);
        }

        #endregion
    }
}
