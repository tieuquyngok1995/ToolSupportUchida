
namespace ToolSupportUchida.View
{
    partial class FormCommon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlCreateMessage = new System.Windows.Forms.TabControl();
            this.tabPageCreateJson = new System.Windows.Forms.TabPage();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtInputKey = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridInputParam = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbCreateJson = new System.Windows.Forms.RadioButton();
            this.rdbCreateObj = new System.Windows.Forms.RadioButton();
            this.txtOut = new System.Windows.Forms.TextBox();
            this.txtCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCreateMess = new System.Windows.Forms.Button();
            this.lblMessResult = new System.Windows.Forms.Label();
            this.btnMessCopy = new System.Windows.Forms.Button();
            this.btnMessClear = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtMessResult = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtMessContent = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtMessCode = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblNumLMessCode = new System.Windows.Forms.Label();
            this.lblNumMessContent = new System.Windows.Forms.Label();
            this.tabControlCreateMessage.SuspendLayout();
            this.tabPageCreateJson.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlCreateMessage
            // 
            this.tabControlCreateMessage.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlCreateMessage.Controls.Add(this.tabPageCreateJson);
            this.tabControlCreateMessage.Controls.Add(this.tabPage2);
            this.tabControlCreateMessage.Controls.Add(this.tabPage1);
            this.tabControlCreateMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCreateMessage.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlCreateMessage.ItemSize = new System.Drawing.Size(28, 120);
            this.tabControlCreateMessage.Location = new System.Drawing.Point(0, 0);
            this.tabControlCreateMessage.Multiline = true;
            this.tabControlCreateMessage.Name = "tabControlCreateMessage";
            this.tabControlCreateMessage.Padding = new System.Drawing.Point(3, 3);
            this.tabControlCreateMessage.SelectedIndex = 0;
            this.tabControlCreateMessage.Size = new System.Drawing.Size(704, 405);
            this.tabControlCreateMessage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlCreateMessage.TabIndex = 0;
            this.tabControlCreateMessage.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlCommon_DrawItem);
            // 
            // tabPageCreateJson
            // 
            this.tabPageCreateJson.Controls.Add(this.btnCreate);
            this.tabPageCreateJson.Controls.Add(this.lblResult);
            this.tabPageCreateJson.Controls.Add(this.btnCopy);
            this.tabPageCreateJson.Controls.Add(this.btnClear);
            this.tabPageCreateJson.Controls.Add(this.groupBox4);
            this.tabPageCreateJson.Controls.Add(this.groupBox3);
            this.tabPageCreateJson.Controls.Add(this.groupBox2);
            this.tabPageCreateJson.Controls.Add(this.groupBox1);
            this.tabPageCreateJson.Location = new System.Drawing.Point(124, 4);
            this.tabPageCreateJson.Name = "tabPageCreateJson";
            this.tabPageCreateJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreateJson.Size = new System.Drawing.Size(576, 397);
            this.tabPageCreateJson.TabIndex = 0;
            this.tabPageCreateJson.Text = "Create JSON";
            this.tabPageCreateJson.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = global::ToolSupportUchida.Properties.Resources.create;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(330, 356);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 28);
            this.btnCreate.TabIndex = 15;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(478, 356);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(95, 28);
            this.lblResult.TabIndex = 14;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportUchida.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(411, 356);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 28);
            this.btnCopy.TabIndex = 13;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::ToolSupportUchida.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(445, 356);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 28);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtResult);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(330, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(236, 254);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Enabled = false;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(230, 232);
            this.txtResult.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtInputKey);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(330, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(236, 96);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Key Paramerter";
            // 
            // txtInputKey
            // 
            this.txtInputKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputKey.Location = new System.Drawing.Point(3, 19);
            this.txtInputKey.Multiline = true;
            this.txtInputKey.Name = "txtInputKey";
            this.txtInputKey.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtInputKey.Size = new System.Drawing.Size(230, 74);
            this.txtInputKey.TabIndex = 0;
            this.txtInputKey.TextChanged += new System.EventHandler(this.txtInputKey_TextChanged);
            this.txtInputKey.Leave += new System.EventHandler(this.txtInputKey_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridInputParam);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(9, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(312, 287);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Value";
            // 
            // gridInputParam
            // 
            this.gridInputParam.AllowUserToAddRows = false;
            this.gridInputParam.AllowUserToDeleteRows = false;
            this.gridInputParam.AllowUserToResizeColumns = false;
            this.gridInputParam.AllowUserToResizeRows = false;
            this.gridInputParam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridInputParam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridInputParam.CausesValidation = false;
            this.gridInputParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridInputParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colParam,
            this.colValue});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridInputParam.DefaultCellStyle = dataGridViewCellStyle2;
            this.gridInputParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridInputParam.EnableHeadersVisualStyles = false;
            this.gridInputParam.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridInputParam.Location = new System.Drawing.Point(3, 19);
            this.gridInputParam.MultiSelect = false;
            this.gridInputParam.Name = "gridInputParam";
            this.gridInputParam.RowHeadersVisible = false;
            this.gridInputParam.RowHeadersWidth = 25;
            this.gridInputParam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridInputParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridInputParam.Size = new System.Drawing.Size(306, 265);
            this.gridInputParam.TabIndex = 1;
            this.gridInputParam.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridInputParam_CurrentCellDirtyStateChanged);
            // 
            // colNo
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle1;
            this.colNo.HeaderText = "No.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNo.Width = 35;
            // 
            // colParam
            // 
            this.colParam.HeaderText = "Param";
            this.colParam.Name = "colParam";
            this.colParam.ReadOnly = true;
            this.colParam.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParam.Width = 113;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 140;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbCreateJson);
            this.groupBox1.Controls.Add(this.rdbCreateObj);
            this.groupBox1.Controls.Add(this.txtOut);
            this.groupBox1.Controls.Add(this.txtCase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 96);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Case Out";
            // 
            // rdbCreateJson
            // 
            this.rdbCreateJson.AutoSize = true;
            this.rdbCreateJson.Checked = true;
            this.rdbCreateJson.Location = new System.Drawing.Point(210, 28);
            this.rdbCreateJson.Name = "rdbCreateJson";
            this.rdbCreateJson.Size = new System.Drawing.Size(102, 21);
            this.rdbCreateJson.TabIndex = 6;
            this.rdbCreateJson.TabStop = true;
            this.rdbCreateJson.Text = "Create Json";
            this.rdbCreateJson.UseVisualStyleBackColor = true;
            // 
            // rdbCreateObj
            // 
            this.rdbCreateObj.AutoSize = true;
            this.rdbCreateObj.Location = new System.Drawing.Point(210, 63);
            this.rdbCreateObj.Name = "rdbCreateObj";
            this.rdbCreateObj.Size = new System.Drawing.Size(94, 21);
            this.rdbCreateObj.TabIndex = 5;
            this.rdbCreateObj.Text = "Create Obj";
            this.rdbCreateObj.UseVisualStyleBackColor = true;
            // 
            // txtOut
            // 
            this.txtOut.Location = new System.Drawing.Point(83, 62);
            this.txtOut.Name = "txtOut";
            this.txtOut.Size = new System.Drawing.Size(120, 23);
            this.txtOut.TabIndex = 4;
            this.txtOut.Text = "1";
            // 
            // txtCase
            // 
            this.txtCase.Location = new System.Drawing.Point(83, 28);
            this.txtCase.Name = "txtCase";
            this.txtCase.Size = new System.Drawing.Size(120, 23);
            this.txtCase.TabIndex = 3;
            this.txtCase.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Input Out";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input Case";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCreateMess);
            this.tabPage2.Controls.Add(this.lblMessResult);
            this.tabPage2.Controls.Add(this.btnMessCopy);
            this.tabPage2.Controls.Add(this.btnMessClear);
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(124, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create Message";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCreateMess
            // 
            this.btnCreateMess.Enabled = false;
            this.btnCreateMess.FlatAppearance.BorderSize = 0;
            this.btnCreateMess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateMess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMess.Image = global::ToolSupportUchida.Properties.Resources.create;
            this.btnCreateMess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateMess.Location = new System.Drawing.Point(385, 344);
            this.btnCreateMess.Name = "btnCreateMess";
            this.btnCreateMess.Size = new System.Drawing.Size(112, 28);
            this.btnCreateMess.TabIndex = 20;
            this.btnCreateMess.Text = "Create Mess";
            this.btnCreateMess.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateMess.UseVisualStyleBackColor = true;
            this.btnCreateMess.Click += new System.EventHandler(this.btnCreateMess_Click);
            // 
            // lblMessResult
            // 
            this.lblMessResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessResult.ForeColor = System.Drawing.Color.Red;
            this.lblMessResult.Location = new System.Drawing.Point(400, 374);
            this.lblMessResult.Name = "lblMessResult";
            this.lblMessResult.Size = new System.Drawing.Size(165, 18);
            this.lblMessResult.TabIndex = 19;
            this.lblMessResult.Text = "Copy to Clipboard is done!";
            this.lblMessResult.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMessResult.Visible = false;
            // 
            // btnMessCopy
            // 
            this.btnMessCopy.Enabled = false;
            this.btnMessCopy.FlatAppearance.BorderSize = 0;
            this.btnMessCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMessCopy.Image = global::ToolSupportUchida.Properties.Resources.button_copy_clipboar;
            this.btnMessCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMessCopy.Location = new System.Drawing.Point(503, 343);
            this.btnMessCopy.Name = "btnMessCopy";
            this.btnMessCopy.Size = new System.Drawing.Size(28, 28);
            this.btnMessCopy.TabIndex = 18;
            this.btnMessCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMessCopy.UseVisualStyleBackColor = true;
            this.btnMessCopy.Click += new System.EventHandler(this.btnMessCopy_Click);
            // 
            // btnMessClear
            // 
            this.btnMessClear.FlatAppearance.BorderSize = 0;
            this.btnMessClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMessClear.Image = global::ToolSupportUchida.Properties.Resources.button_clear;
            this.btnMessClear.Location = new System.Drawing.Point(537, 343);
            this.btnMessClear.Name = "btnMessClear";
            this.btnMessClear.Size = new System.Drawing.Size(28, 28);
            this.btnMessClear.TabIndex = 17;
            this.btnMessClear.UseVisualStyleBackColor = true;
            this.btnMessClear.Click += new System.EventHandler(this.btnMessClear_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtMessResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(380, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(185, 338);
            this.groupBox7.TabIndex = 16;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result";
            // 
            // txtMessResult
            // 
            this.txtMessResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessResult.Enabled = false;
            this.txtMessResult.Location = new System.Drawing.Point(3, 19);
            this.txtMessResult.Multiline = true;
            this.txtMessResult.Name = "txtMessResult";
            this.txtMessResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessResult.Size = new System.Drawing.Size(179, 316);
            this.txtMessResult.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblNumMessContent);
            this.groupBox6.Controls.Add(this.txtMessContent);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(195, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(178, 385);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Message Content";
            // 
            // txtMessContent
            // 
            this.txtMessContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessContent.Location = new System.Drawing.Point(3, 19);
            this.txtMessContent.Multiline = true;
            this.txtMessContent.Name = "txtMessContent";
            this.txtMessContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessContent.Size = new System.Drawing.Size(172, 343);
            this.txtMessContent.TabIndex = 2;
            this.txtMessContent.TextChanged += new System.EventHandler(this.txtMessContent_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lblNumLMessCode);
            this.groupBox5.Controls.Add(this.txtMessCode);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(9, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(178, 385);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Message Code";
            // 
            // txtMessCode
            // 
            this.txtMessCode.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtMessCode.Location = new System.Drawing.Point(3, 19);
            this.txtMessCode.Multiline = true;
            this.txtMessCode.Name = "txtMessCode";
            this.txtMessCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessCode.Size = new System.Drawing.Size(172, 343);
            this.txtMessCode.TabIndex = 2;
            this.txtMessCode.TextChanged += new System.EventHandler(this.txtMessCode_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(124, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 397);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Comming Soon";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblNumLMessCode
            // 
            this.lblNumLMessCode.AutoSize = true;
            this.lblNumLMessCode.Location = new System.Drawing.Point(3, 365);
            this.lblNumLMessCode.Name = "lblNumLMessCode";
            this.lblNumLMessCode.Size = new System.Drawing.Size(91, 17);
            this.lblNumLMessCode.TabIndex = 3;
            this.lblNumLMessCode.Text = "Line number:";
            this.lblNumLMessCode.Visible = false;
            // 
            // lblNumMessContent
            // 
            this.lblNumMessContent.AutoSize = true;
            this.lblNumMessContent.Location = new System.Drawing.Point(3, 365);
            this.lblNumMessContent.Name = "lblNumMessContent";
            this.lblNumMessContent.Size = new System.Drawing.Size(91, 17);
            this.lblNumMessContent.TabIndex = 4;
            this.lblNumMessContent.Text = "Line number:";
            this.lblNumMessContent.Visible = false;
            // 
            // FormCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.tabControlCreateMessage);
            this.Name = "FormCommon";
            this.Text = "FormCheck";
            this.Load += new System.EventHandler(this.FormCheckDataModel_Load);
            this.tabControlCreateMessage.ResumeLayout(false);
            this.tabPageCreateJson.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCreateMessage;
        private System.Windows.Forms.TabPage tabPageCreateJson;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOut;
        private System.Windows.Forms.TextBox txtCase;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtInputKey;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridView gridInputParam;
        private System.Windows.Forms.RadioButton rdbCreateJson;
        private System.Windows.Forms.RadioButton rdbCreateObj;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnCreateMess;
        private System.Windows.Forms.Label lblMessResult;
        private System.Windows.Forms.Button btnMessCopy;
        private System.Windows.Forms.Button btnMessClear;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtMessResult;
        private System.Windows.Forms.TextBox txtMessContent;
        private System.Windows.Forms.TextBox txtMessCode;
        private System.Windows.Forms.Label lblNumMessContent;
        private System.Windows.Forms.Label lblNumLMessCode;
    }
}