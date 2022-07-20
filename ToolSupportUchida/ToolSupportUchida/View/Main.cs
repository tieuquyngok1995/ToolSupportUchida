using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private int noSekkei;
        private int noAdapter;
        private int rowIndex;

        private ToolSupportModel objToolSupport;

        private int mode;
        private List<SekkeiModel> lstSekkei;
        private List<AdapterModel> lstAdapter;

        //Constructor
        public Main()
        {
            InitializeComponent();
            random = new Random();
            noSekkei = 1;
            noAdapter = 1;
            rowIndex = -1;

            objToolSupport = new ToolSupportModel();

            lstSekkei = new List<SekkeiModel>();
            lstAdapter = new List<AdapterModel>();

            btnCloseChildForm.Visible = false;

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            cbCharFormat.Items.Add(CONST.ITEM_CHAR_FORMAT_EQUALS);
            cbCharFormat.Items.Add(CONST.ITEM_CHAR_FORMAT_TAB);
            cbCharFormat.SelectedIndex = 0;

            cbType.Items.Add(CONST.ITEM_ROWS);
            cbType.Items.Add(CONST.ITEM_COLUMNS);
            cbType.Items.Add(CONST.ITEM_SUB_ROWS);
            cbType.Items.Add(CONST.ITEM_SUB_COLUMNS);
            cbType.SelectedIndex = 0;
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
            objToolSupport = BinarySerialization.ReadFromBinaryFile<ToolSupportModel>();

            if (objToolSupport.lstSekkei != null)
            {
                lstSekkei = objToolSupport.lstSekkei;
                foreach (SekkeiModel sekkei in objToolSupport.lstSekkei)
                {
                    gridSekkei.Rows.Add(noSekkei, sekkei.logicName, sekkei.physiName);
                    noSekkei++;
                }
            }

            if (objToolSupport.lstAdapter != null)
            {
                lstAdapter = objToolSupport.lstAdapter;
                foreach (AdapterModel adapter in objToolSupport.lstAdapter)
                {
                    gridAdapter.Rows.Add(noAdapter, adapter.type, adapter.key, adapter.value);
                    noAdapter++;
                }
            }

            mode = objToolSupport.modeLanguage;
            if (mode == 0)
            {
                rbC.Checked = true;
            }
            else if (mode == 1)
            {
                rbTypeScript.Checked = true;
            }
            else if (mode == 2)
            {
                rbJava.Checked = true;
            }
            else if (mode == 3)
            {
                rbHtml.Checked = true;
            }

        }

        private void rbC_CheckedChanged(object sender, EventArgs e)
        {
            mode = 0;
            objToolSupport.modeLanguage = mode;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void rbTypeScript_CheckedChanged(object sender, EventArgs e)
        {
            mode = 1;
            objToolSupport.modeLanguage = mode;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void rbJava_CheckedChanged(object sender, EventArgs e)
        {
            mode = 2;
            objToolSupport.modeLanguage = mode;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void rbHtml_CheckedChanged(object sender, EventArgs e)
        {
            mode = 3;
            objToolSupport.modeLanguage = mode;
            BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            DialogResult result = openFileDialog.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog.FileName;
                try
                {
                    string text = File.ReadAllText(file);

                    string[] stringSeparators = new string[] { "\r\n" };
                    string[] lines = text.Split(stringSeparators, StringSplitOptions.None);

                    int mode = 0;
                    if (this.rbFormat.Checked) mode = 1;

                    int charFormat = this.cbCharFormat.SelectedIndex;

                    lstSekkei = new List<SekkeiModel>();
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] dataLine = new string[0];
                        if (mode == 0)
                        {
                            if (charFormat == 0) {
                                dataLine = line.Split(CONST.CHAR_EQUALS);
                            } else if (charFormat == 1) {
                                dataLine = line.Split(CONST.CHAR_TAB);
                            }

                            if (dataLine.Length >= 1)
                            {
                                lstSekkei.Add(new SekkeiModel(dataLine[0], dataLine[1]));
                            }
                        }
                        else if (mode == 1)
                        {
                            dataLine = line.Split(CONST.CHAR_TAB);
                        }
                    }

                    if (lstSekkei.Count > 0)
                    {
                        objToolSupport.lstSekkei = lstSekkei;
                        BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                        gridSekkei.Rows.Clear();
                        gridSekkei.Refresh();
                        foreach (SekkeiModel sekkei in objToolSupport.lstSekkei)
                        {
                            gridSekkei.Rows.Add(noSekkei, sekkei.logicName, sekkei.physiName);
                            noSekkei++;
                        }
                    }
                    
                }
                catch (IOException)
                {
                    MessageBox.Show(CONST.MESS_OPEN_FILE, CONST.TEXT_CAPTION_ERROR,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnAddSekkei_Click(object sender, EventArgs e)
        {
            string logicName = txtLogicName.Text.Trim();
            string physiName = txtPhysiName.Text.Trim();

            if (string.IsNullOrEmpty(logicName))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_LOGIC_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.gridSekkei.Rows[rowIndex].Cells[1].Value = logicName;
                    this.gridSekkei.Rows[rowIndex].Cells[2].Value = physiName;
                    lstSekkei[rowIndex] = new SekkeiModel(logicName, physiName);

                    rowIndex = -1;
                }
                else
                {
                    this.gridSekkei.Rows.Add(noSekkei++, logicName, physiName);
                    lstSekkei.Add(new SekkeiModel(logicName, physiName));
                }

                objToolSupport.lstSekkei = lstSekkei;
                BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

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
            noSekkei = 1;

            if (string.IsNullOrEmpty(logicName) && string.IsNullOrEmpty(physiName))
            {
                foreach (SekkeiModel sekkei in lstSekkei)
                {
                    gridSekkei.Rows.Add(noSekkei, sekkei.logicName, sekkei.physiName);
                    noSekkei++;
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
                    noSekkei++;
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

            if (colName.Equals(CONST.NAME_COL_SEKKEI_EDIT))
            {
                txtLogicName.Text = row.Cells[1].Value.ToString();
                txtPhysiName.Text = row.Cells[2].Value.ToString();
                rowIndex = e.RowIndex;
            }
            else if (colName.Equals(CONST.NAME_COL_SEKKEI_DELETE))
            {

                DialogResult result = MessageBox.Show(CONST.MESS_DELETE_ROW, CONST.TEXT_CAPTION_WARNING,
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.gridSekkei.Rows.Remove(row);
                    noSekkei--;

                    for (int i = 0; i < noSekkei - 1; i++)
                    {
                        this.gridSekkei.Rows[i].Cells[0].Value = i + 1;
                    }

                    lstSekkei.RemoveAt(e.RowIndex);
                    objToolSupport.lstSekkei = lstSekkei;

                    BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
                }
            }
            else
            {
                return;
            }
        }

        private void btnSearchAdapter_Click(object sender, EventArgs e)
        {

        }

        private void btnAddAdapter_Click(object sender, EventArgs e)
        {
            string joinType = this.cbType.GetItemText(cbType.SelectedItem);
            string joinKey = txtJoinKey.Text.Trim();
            string joinValue = txtJoinValue.Text.Trim();

            if (string.IsNullOrEmpty(joinKey))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_JOIN_KEY_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(joinValue))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_JOIN_VALUE_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool containsItem = lstAdapter.Any(item => (item.key == joinKey));

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
                    this.gridAdapter.Rows[rowIndex].Cells[1].Value = joinType;
                    this.gridAdapter.Rows[rowIndex].Cells[2].Value = joinKey;
                    this.gridAdapter.Rows[rowIndex].Cells[3].Value = joinValue;
                    lstAdapter[rowIndex] = new AdapterModel(joinType, joinKey, joinValue);

                    rowIndex = -1;
                }
                else
                {
                    this.gridAdapter.Rows.Add(noAdapter++, joinType, joinKey, joinValue);
                    lstAdapter.Add(new AdapterModel(joinType, joinKey, joinValue));
                }

                objToolSupport.lstAdapter = lstAdapter;
                BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                // Clear data
                txtJoinKey.Text = string.Empty;
                txtJoinValue.Text = string.Empty;
            }
        }

        private void btnClearAdaper_Click(object sender, EventArgs e)
        {
            cbType.SelectedIndex = 0;
            txtJoinKey.Text = string.Empty;
            txtJoinValue.Text = string.Empty;

            txtJoinKey.Focus();
        }

        private void gridAdapter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            string colName = this.gridAdapter.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = this.gridAdapter.Rows[e.RowIndex];

            if (colName.Equals(CONST.NAME_COL_ADAPTER_EDIT))
            {
                cbType.SelectedItem = row.Cells[1].Value.ToString();
                txtJoinKey.Text = row.Cells[2].Value.ToString();
                txtJoinValue.Text = row.Cells[3].Value.ToString();
                rowIndex = e.RowIndex;
            }
            else if (colName.Equals(CONST.NAME_COL_ADAPTER_DELETE))
            {

                DialogResult result = MessageBox.Show(CONST.MESS_DELETE_ROW, CONST.TEXT_CAPTION_WARNING,
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.gridAdapter.Rows.Remove(row);
                    noAdapter--;

                    for (int i = 0; i < noAdapter - 1; i++)
                    {
                        this.gridAdapter.Rows[i].Cells[0].Value = i + 1;
                    }

                    lstAdapter.RemoveAt(e.RowIndex);
                    objToolSupport.lstAdapter = lstAdapter;

                    BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
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
            OpenChildForm(new FormConvertSekkei(lstSekkei, mode), sender);
        }

        private void btnConvertModel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormConvertModel(mode), sender);
        }

        private void btnCreateAdapter_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCreateAdapter(lstAdapter), sender);
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCommon(), sender);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormAbout(), sender);
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
