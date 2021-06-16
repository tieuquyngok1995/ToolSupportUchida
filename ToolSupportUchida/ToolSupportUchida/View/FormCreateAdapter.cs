using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;

namespace ToolSupportUchida.View
{
    public partial class FormCreateAdapter : Form
    {
        private string[] lstLogic;
        private string[] lstPhysi;
        private string[] lsttype;

        #region Load Form
        public FormCreateAdapter()
        {
            InitializeComponent();
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
