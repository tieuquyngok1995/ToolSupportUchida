using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ToolSupportUchida.Model;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.View
{
    public partial class FormCreateAdapter : Form
    {

        private List<AdapterModel> lstRows;
        private List<AdapterModel> lstColumn;
        private List<AdapterModel> lstSubRows;
        private List<AdapterModel> lstSubColumn;

        private string[] lstLogic;
        private string[] lstPhysi;
        private string[] lsttype;

        #region Load Form
        public FormCreateAdapter(List<AdapterModel> lstAdapter)
        {
            InitializeComponent();

            lstRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_ROWS)).ToList();
            if (lstRows.Count > 0)
            {
                cbRow.DataSource = new BindingSource(lstRows, null);
                cbRow.DisplayMember = "key";
                cbRow.ValueMember = "value";
                cbRow.SelectedIndex = 0;
            }

            lstColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_COLUMNS)).ToList();
            if (lstColumn.Count > 0)
            {
                cbColumn.DataSource = new BindingSource(lstColumn, null);
                cbColumn.DisplayMember = "key";
                cbColumn.ValueMember = "value";
                cbColumn.SelectedIndex = 0;
            }

            lstSubRows = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_ROWS)).ToList();
            if (lstSubRows.Count > 0)
            {
                cbSubRow.DataSource = new BindingSource(lstSubRows, null);
                cbSubRow.DisplayMember = "key";
                cbSubRow.ValueMember = "value";
                cbSubRow.SelectedIndex = 0;
            }

            lstSubColumn = lstAdapter.Where(obj => obj.type.Equals(CONST.ITEM_SUB_COLUMNS)).ToList();
            if (lstSubColumn.Count > 0)
            {
                cbSubColumn.DataSource = new BindingSource(lstSubColumn, null);
                cbSubColumn.DisplayMember = "key";
                cbSubColumn.ValueMember = "value";
                cbSubColumn.SelectedIndex = 0;
            }
        }

        private void FormCreateAdapter_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
                lstLogic = txtLogic.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumLogic.Text = CONST.TEXT_LINE_NUM + lstLogic.Length;
                lblNumLogic.Visible = true;
            }
        }

        private void txtPhysi_TextChanged(object sender, EventArgs e)
        {
            if (txtPhysi.Text.Length == 0)
            {
                lblNumPhy.Visible = false;
            }
            else
            {
                lstPhysi = txtPhysi.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumPhy.Text = CONST.TEXT_LINE_NUM + lstPhysi.Length;
                lblNumPhy.Visible = true;
            }
        }

        private void txtType_TextChanged(object sender, EventArgs e)
        {
            if (txtType.Text.Length == 0)
            {
                lblNumType.Visible = false;
            }
            else
            {
                lsttype = txtType.Text.Split(CONST.CHAR_NEW_LINE);

                lblNumType.Text = CONST.TEXT_LINE_NUM + lsttype.Length;
                lblNumType.Visible = true;
            }
        }
        #endregion

        #region Method
        #endregion
    }
}
