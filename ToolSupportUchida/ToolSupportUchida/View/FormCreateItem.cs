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
    public partial class FormCreateItem : Form
    {
        private List<string> lstType;

        private List<ItemModel> lstData;
        private List<ItemModel> lstKey;


        #region Load Form
        public FormCreateItem(List<string> lstType,List<ItemModel> lstItem)
        {
            InitializeComponent();

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
                selectText = (string)cbType.SelectedItem;
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

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            cbKey.SelectedIndex = 0;
            txtFormat.Text = string.Empty;
            txtValue.Text = string.Empty;
        }
        #endregion

        #region Event


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

        #endregion
    }
}
