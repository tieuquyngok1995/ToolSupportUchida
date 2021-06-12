using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ToolSupportUchida.Common;
using ToolSupportUchida.Model;
using ToolSupportUchida.Theme;
using ToolSupportUchida.Utils;
using ToolSupportUchida.View;

namespace ToolSupportUchida
{
    public partial class Main : Form
    {
        // Dll
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Fields
        private Form activeForm;
        private Button currentButton;

        private Random random;
        private int tempIndex;
        private int no;
        private int rowIndex;

        private ToolSupportModel toolSupport;
        private List<SekkeiModel> lstSekkei;

        //Constructor
        public Main()
        {
            InitializeComponent();
            random = new Random();
            no = 1;
            rowIndex = -1;

            toolSupport = new ToolSupportModel();
            lstSekkei = new List<SekkeiModel>();

            btnCloseChildForm.Visible = false;

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        #region Theme
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    panelTitleBar.BackColor = color;
                    panelFooter.BackColor = color;
                    panelLogo.BackColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    ThemeColor.PrimaryColor = color;
                    ThemeColor.SecondaryColor = ThemeColor.ChangeColorBrightness(color, -0.3);
                    btnCloseChildForm.Visible = true;
                }
            }
        }

        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
        #endregion

        #region Form
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            this.panelSettingTop.Hide();
            this.panelSettingLeft.Hide();
            this.panelSettingRight.Hide();
            this.panelDesktopPane.Controls.Add(childForm);
            this.panelDesktopPane.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnCloseChildForm_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
                activeForm.Close();
            Reset();
        }

        private void Reset()
        {
            DisableButton();

            this.panelSettingTop.Show();
            this.panelSettingLeft.Show();
            this.panelSettingRight.Show();

            panelTitleBar.BackColor = Color.FromArgb(0, 150, 136);
            panelFooter.BackColor = Color.FromArgb(0, 150, 136);
            panelLogo.BackColor = Color.FromArgb(39, 39, 58);
            lblTitle.Text = CONST.TEXT_SETTING;

            currentButton = null;
            btnCloseChildForm.Visible = false;
        }
        #endregion

        #region Event
        private void Main_Load(object sender, EventArgs e)
        {
            lstSekkei = BinarySerialization.ReadFromBinaryFile<List<SekkeiModel>>();

            foreach (SekkeiModel sekkei in lstSekkei)
            {
                gridSekkei.Rows.Add(no, sekkei.logicName, sekkei.physiName);
                no++;
            }
        }

        private void btnAddSekkei_Click(object sender, EventArgs e)
        {
            string logicName = txtLogicName.Text.Trim();
            string physiName = txtPhysiName.Text.Trim();

            if (string.IsNullOrEmpty(logicName))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_LOGIC_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(physiName))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_PHYSI_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool containsItem = lstSekkei.Any(item => (item.logicName == logicName));

                if (containsItem && rowIndex == -1)
                {
                    MessageBox.Show(CONST.MESS_ADD_NEW_EXIST, CONST.TEXT_CAPTION_ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (containsItem && rowIndex == -1)
                {
                    return;
                }

                if (rowIndex != -1)
                {
                    this.gridSekkei.Rows[rowIndex].Cells[1].Value = txtLogicName.Text;
                    this.gridSekkei.Rows[rowIndex].Cells[2].Value = txtPhysiName.Text;
                    lstSekkei[rowIndex] = new SekkeiModel(txtLogicName.Text, txtPhysiName.Text);

                    rowIndex = -1;
                }
                else
                {
                    this.gridSekkei.Rows.Add(no++, txtLogicName.Text, txtPhysiName.Text);
                    lstSekkei.Add(new SekkeiModel(txtLogicName.Text, txtPhysiName.Text));
                }

                BinarySerialization.WriteToBinaryFile<List<SekkeiModel>>(lstSekkei);

                // Clear data
                txtLogicName.Text = string.Empty;
                txtPhysiName.Text = string.Empty;
            }
        }

        private void btnSearchSekkei_Click(object sender, EventArgs e)
        {
            string logicName = txtLogicName.Text.Trim();
            string physiName = txtPhysiName.Text.Trim();

            gridSekkei.Rows.Clear();
            gridSekkei.Refresh();
            no = 1;

            if (string.IsNullOrEmpty(logicName) && string.IsNullOrEmpty(physiName))
            {
                foreach (SekkeiModel sekkei in lstSekkei)
                {
                    gridSekkei.Rows.Add(no, sekkei.logicName, sekkei.physiName);
                    no++;
                }
            }
            else
            {
                SekkeiModel objSekkei;
                if (!string.IsNullOrEmpty(logicName) && string.IsNullOrEmpty(physiName))
                {
                    objSekkei = lstSekkei.Find(item => item.logicName.Equals(logicName));
                }
                else if (string.IsNullOrEmpty(logicName) && !string.IsNullOrEmpty(physiName))
                {
                    objSekkei = lstSekkei.Find(item => item.physiName.Equals(physiName));
                }
                else
                {
                    objSekkei = lstSekkei.Find(item => (item.logicName.Equals(logicName) && item.physiName.Equals(physiName)));
                }

                if (objSekkei != null)
                {
                    this.gridSekkei.Rows.Add(1, objSekkei.logicName, objSekkei.physiName);
                    no++;
                }
                else
                {
                    MessageBox.Show(CONST.MESS_NO_RESULT, CONST.TEXT_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtLogicName.Text = string.Empty;
            txtPhysiName.Text = string.Empty;

            txtLogicName.Focus();
        }

        private void gridSekkei_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            string colName = this.gridSekkei.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = this.gridSekkei.Rows[e.RowIndex];

            if (colName.Equals(CONST.NAME_COL_EDIT))
            {
                txtLogicName.Text = row.Cells[1].Value.ToString();
                txtPhysiName.Text = row.Cells[2].Value.ToString();
                rowIndex = e.RowIndex;
            }
            else if (colName.Equals(CONST.NAME_COL_DELETE))
            {

                DialogResult result = MessageBox.Show(CONST.MESS_DELETE_ROW, CONST.TEXT_CAPTION_WARNING,
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.gridSekkei.Rows.Remove(row);
                    no--;

                    for (int i = 0; i < no - 1; i++)
                    {
                        this.gridSekkei.Rows[i].Cells[0].Value = i + 1;
                    }

                    lstSekkei.RemoveAt(e.RowIndex);
                    BinarySerialization.WriteToBinaryFile<List<SekkeiModel>>(lstSekkei);
                }
            }
            else
            {
                return;
            }
        }

        private void btnConvertDatabase_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormConvertDatabase(), sender);
        }

        private void btnConverSekkei_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormConvertSekkei(lstSekkei), sender);
        }

        private void btnConvertModel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormConvertModel(), sender);
        }

        private void btnCreateAdapter_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCreateAdapter(), sender);
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCheckDataModel(), sender);
        }

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}
