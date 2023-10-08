using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ToolSupportCoding.Common;
using ToolSupportCoding.Model;
using ToolSupportCoding.Theme;
using ToolSupportCoding.Utils;
using ToolSupportCoding.View;

namespace ToolSupportCoding
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
        private int noAdapter;
        private int rowIndex;

        private ToolSupportModel objToolSupport;

        private int mode;
        private List<SekkeiModel> lstSekkei;
        private List<ItemModel> lstItem;

        //Constructor
        public Main()
        {
            InitializeComponent();
            random = new Random();
            no = 1;
            noAdapter = 1;
            rowIndex = -1;

            objToolSupport = new ToolSupportModel();

            lstSekkei = new List<SekkeiModel>();
            lstItem = new List<ItemModel>();

            btnCloseChildForm.Visible = false;

            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            txFormat.Text = CONST.ITEM_CHAR_FORMAT_EQUALS;
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
                    gridSekkei.Rows.Add(no, sekkei.logicName, sekkei.physiName);
                    no++;
                }
            }

            if (objToolSupport.lstItem != null)
            {
                lstItem = objToolSupport.lstItem;
                foreach (ItemModel adapter in objToolSupport.lstItem)
                {
                    gridFormat.Rows.Add(noAdapter, adapter.name, adapter.key, adapter.value);
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

        private void Main_Shown(object sender, EventArgs e)
        {
            //MessageBox.Show("\t\tThông báo\r\n" +
                //"Tool chỉ hỗ trợ không phải chính xác tuyệt đối.\r\n" +
                //"Mọi chức năng vui lòng kiểm tra lại sau khi sử dụng.\r\n" +
                //"Trong trường hợp phát sinh lỗi vui lòng liên hệ team 3.2 để được hỗ trợ.\r\n" +
                //"\t\t\t\tTrân trọng!!!", CONST.TEXT_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

                    int mode = 0;
                    if (this.rbFormat.Checked) mode = 1;

                    string[] stringSeparators = new string[] { "\r\n" };
                    if (mode == 1)
                    {
                        stringSeparators = new string[] { "<br>" };
                    }

                    string[] lines = text.Split(stringSeparators, StringSplitOptions.None);


                    lstSekkei = new List<SekkeiModel>();
                    lstItem = new List<ItemModel>();
                    foreach (string line in lines)
                    {
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] dataLine = new string[0];

                        if (mode == 0)
                        {
                            dataLine = line.Split(CONST.CHAR_EQUALS);

                            if (dataLine.Length > 1)
                            {
                                lstSekkei.Add(new SekkeiModel(dataLine[0], dataLine[1]));
                            }
                        }
                        else if (mode == 1)
                        {
                            stringSeparators = new string[] { "[--]" };
                            dataLine = line.Split(stringSeparators, StringSplitOptions.None);

                            if (dataLine.Length > 1)
                            {
                                lstItem.Add(new ItemModel(dataLine[0].Replace(CONST.STRING_ADD_LINE, string.Empty), dataLine[1], dataLine[2]));
                            }
                        }
                    }

                    if (lstSekkei.Count > 0)
                    {
                        objToolSupport.lstSekkei = lstSekkei;
                        BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                        no = 1;
                        gridSekkei.Rows.Clear();
                        gridSekkei.Refresh();
                        foreach (SekkeiModel sekkei in objToolSupport.lstSekkei)
                        {
                            gridSekkei.Rows.Add(no, sekkei.logicName, sekkei.physiName);
                            no++;
                        }
                    }
                    if (lstItem.Count > 0)
                    {
                        objToolSupport.lstItem = lstItem;
                        BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                        noAdapter = 1;
                        gridFormat.Rows.Clear();
                        gridFormat.Refresh();
                        foreach (ItemModel item in objToolSupport.lstItem)
                        {
                            gridFormat.Rows.Add(noAdapter, item.name, item.key, item.value);
                            noAdapter++;
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
                    this.gridSekkei.Rows.Add(no++, logicName, physiName);
                    lstSekkei.Add(new SekkeiModel(logicName, physiName));
                }

                objToolSupport.lstSekkei = lstSekkei;
                BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                // Clear data
                txtLogicName.Text = string.Empty;
                txtPhysiName.Text = string.Empty;

                btnSearchSekkei.Enabled = true;
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
            btnSearchSekkei.Enabled = true;

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

                btnSearchSekkei.Enabled = false;
            }
            else if (colName.Equals(CONST.NAME_COL_SEKKEI_DELETE))
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
                    objToolSupport.lstSekkei = lstSekkei;

                    BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
                }
            }
            else
            {
                return;
            }
        }

        private void rbConst_CheckedChanged(object sender, EventArgs e)
        {
            txFormat.Text = CONST.ITEM_CHAR_FORMAT_EQUALS;
        }

        private void rbFormat_CheckedChanged(object sender, EventArgs e)
        {
            txFormat.Text = CONST.ITEM_CHAR_FORMAT_TAB;
        }

        private void btnSearchAdapter_Click(object sender, EventArgs e)
        {
            string txKey = txtKey.Text.Trim();
            string txValue = txtValue.Text.Trim();

            gridFormat.Rows.Clear();
            gridFormat.Refresh();
            no = 1;

            if (string.IsNullOrEmpty(txKey) && string.IsNullOrEmpty(txValue))
            {
                foreach (ItemModel item in lstItem)
                {
                    gridFormat.Rows.Add(no, item.name, item.key, item.value);
                    no++;
                }
            }
            else
            {
                ItemModel objItem;
                if (!string.IsNullOrEmpty(txKey) && string.IsNullOrEmpty(txValue))
                {
                    objItem = lstItem.Find(item => item.key.Equals(txKey));
                }
                else if (string.IsNullOrEmpty(txKey) && !string.IsNullOrEmpty(txValue))
                {
                    objItem = lstItem.Find(item => item.value.Equals(txValue));
                }
                else
                {
                    objItem = lstItem.Find(item => (item.key.Equals(txKey) && item.value.Equals(txValue)));
                }

                if (objItem != null)
                {
                    this.gridFormat.Rows.Add(1, objItem.name, objItem.key, objItem.value);
                    no++;
                }
                else
                {
                    MessageBox.Show(CONST.MESS_NO_RESULT, CONST.TEXT_CAPTION_WARNING, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnAddAdapter_Click(object sender, EventArgs e)
        {
            string txName = txtName.Text.Trim();
            string txKey = txtKey.Text.Trim();
            string txValue = txtValue.Text.Trim();

            if (string.IsNullOrEmpty(txKey))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_JOIN_KEY_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(txValue))
            {
                MessageBox.Show(CONST.MESS_ADD_NEW_JOIN_VALUE_BLANK, CONST.TEXT_CAPTION_ERROR,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool containsItem = lstItem.Any(item => (item.key == txKey));

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
                    this.gridFormat.Rows[rowIndex].Cells[1].Value = txName;
                    this.gridFormat.Rows[rowIndex].Cells[2].Value = txKey;
                    this.gridFormat.Rows[rowIndex].Cells[3].Value = txValue;
                    lstItem[rowIndex] = new ItemModel(txName, txKey, txValue);

                    rowIndex = -1;
                }
                else
                {
                    this.gridFormat.Rows.Add(noAdapter++, txName, txKey, txValue);
                    lstItem.Add(new ItemModel(txName, txKey, txValue));
                }

                objToolSupport.lstItem = lstItem;
                BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);

                // Clear data
                txtKey.Text = string.Empty;
                txtValue.Text = string.Empty;
                btnSearchAdapter.Enabled = true;
            }
        }

        private void btnClearAdaper_Click(object sender, EventArgs e)
        {
            txtName.Text = string.Empty;
            txtKey.Text = string.Empty;
            txtValue.Text = string.Empty;
            btnSearchAdapter.Enabled = true;

            txtKey.Focus();
        }

        private void gridAdapter_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            string colName = this.gridFormat.Columns[e.ColumnIndex].Name;
            DataGridViewRow row = this.gridFormat.Rows[e.RowIndex];

            if (colName.Equals(CONST.NAME_COL_ADAPTER_EDIT))
            {
                txtName.Text = row.Cells[1].Value.ToString();
                txtKey.Text = row.Cells[2].Value.ToString();
                txtValue.Text = row.Cells[3].Value.ToString();
                rowIndex = e.RowIndex;

                btnSearchAdapter.Enabled = false;
            }
            else if (colName.Equals(CONST.NAME_COL_ADAPTER_DELETE))
            {

                DialogResult result = MessageBox.Show(CONST.MESS_DELETE_ROW, CONST.TEXT_CAPTION_WARNING,
                                                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.gridFormat.Rows.Remove(row);
                    noAdapter--;

                    for (int i = 0; i < noAdapter - 1; i++)
                    {
                        this.gridFormat.Rows[i].Cells[0].Value = i + 1;
                    }

                    lstItem.RemoveAt(e.RowIndex);
                    objToolSupport.lstItem = lstItem;

                    BinarySerialization.WriteToBinaryFile<ToolSupportModel>(objToolSupport);
                }
            }
            else
            {
                return;
            }
        }

        private void btnGetSQLinSrc_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGetSQLinSrc(), sender);
        }

        private void btnGetCONST_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormGetCONST(lstSekkei), sender);
        }

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCreateModel(mode), sender);
        }

        private void btnCreateViewModel_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCreateViewModel(mode, lstItem), sender);
        }

        private void btnCreateItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCreateHTML(lstItem), sender);
        }

        private void btnCommon_Click(object sender, EventArgs e)
        {
            OpenChildForm(new FormCommon(objToolSupport), sender);
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
