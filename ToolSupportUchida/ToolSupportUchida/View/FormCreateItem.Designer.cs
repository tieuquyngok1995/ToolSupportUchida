
namespace ToolSupportCoding.View
{
    partial class FormCreateItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.txtFormat = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbKey = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridSetParam = new System.Windows.Forms.DataGridView();
            this.panelResult = new System.Windows.Forms.Panel();
            this.btnCreateResult = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSetting.SuspendLayout();
            this.groupBoxSetting.SuspendLayout();
            this.panelData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSetParam)).BeginInit();
            this.panelResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.groupBoxSetting);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(704, 70);
            this.panelSetting.TabIndex = 0;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Controls.Add(this.btnReset);
            this.groupBoxSetting.Controls.Add(this.btnCreate);
            this.groupBoxSetting.Controls.Add(this.txtFormat);
            this.groupBoxSetting.Controls.Add(this.label3);
            this.groupBoxSetting.Controls.Add(this.txtValue);
            this.groupBoxSetting.Controls.Add(this.label2);
            this.groupBoxSetting.Controls.Add(this.cbKey);
            this.groupBoxSetting.Controls.Add(this.label1);
            this.groupBoxSetting.Controls.Add(this.cbType);
            this.groupBoxSetting.Controls.Add(this.label9);
            this.groupBoxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxSetting.Location = new System.Drawing.Point(6, 3);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(686, 65);
            this.groupBoxSetting.TabIndex = 0;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Setting";
            // 
            // btnReset
            // 
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Image = global::ToolSupportCoding.Properties.Resources.create;
            this.btnReset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.Location = new System.Drawing.Point(602, 35);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(78, 24);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "  Reset";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Image = global::ToolSupportCoding.Properties.Resources.button_create_in;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(469, 35);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(128, 24);
            this.btnCreate.TabIndex = 9;
            this.btnCreate.Text = "  Create Param";
            this.btnCreate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // txtFormat
            // 
            this.txtFormat.Location = new System.Drawing.Point(243, 35);
            this.txtFormat.Name = "txtFormat";
            this.txtFormat.Size = new System.Drawing.Size(110, 23);
            this.txtFormat.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(240, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Format Value {-}";
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(360, 35);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(103, 23);
            this.txtValue.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(357, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Value";
            // 
            // cbKey
            // 
            this.cbKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbKey.FormattingEnabled = true;
            this.cbKey.Location = new System.Drawing.Point(127, 35);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(110, 23);
            this.cbKey.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(124, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Item Key";
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(10, 35);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(110, 23);
            this.cbType.TabIndex = 7;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(7, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Item Type";
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.groupBox1);
            this.panelData.Controls.Add(this.panelResult);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 70);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(704, 304);
            this.panelData.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridSetParam);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(6, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(686, 213);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set Param ";
            // 
            // gridSetParam
            // 
            this.gridSetParam.AllowUserToAddRows = false;
            this.gridSetParam.AllowUserToDeleteRows = false;
            this.gridSetParam.AllowUserToResizeColumns = false;
            this.gridSetParam.AllowUserToResizeRows = false;
            this.gridSetParam.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSetParam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSetParam.CausesValidation = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSetParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridSetParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSetParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colKey,
            this.colValue,
            this.index});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSetParam.DefaultCellStyle = dataGridViewCellStyle3;
            this.gridSetParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSetParam.EnableHeadersVisualStyles = false;
            this.gridSetParam.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.gridSetParam.Location = new System.Drawing.Point(3, 19);
            this.gridSetParam.MultiSelect = false;
            this.gridSetParam.Name = "gridSetParam";
            this.gridSetParam.RowHeadersVisible = false;
            this.gridSetParam.RowHeadersWidth = 25;
            this.gridSetParam.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSetParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridSetParam.Size = new System.Drawing.Size(680, 191);
            this.gridSetParam.TabIndex = 1;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.btnCreateResult);
            this.panelResult.Controls.Add(this.lblResult);
            this.panelResult.Controls.Add(this.btnCopy);
            this.panelResult.Controls.Add(this.txtResult);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelResult.Location = new System.Drawing.Point(0, 216);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(704, 88);
            this.panelResult.TabIndex = 1;
            // 
            // btnCreateResult
            // 
            this.btnCreateResult.Enabled = false;
            this.btnCreateResult.FlatAppearance.BorderSize = 0;
            this.btnCreateResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateResult.Image = global::ToolSupportCoding.Properties.Resources.button_create_out;
            this.btnCreateResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateResult.Location = new System.Drawing.Point(9, 58);
            this.btnCreateResult.Name = "btnCreateResult";
            this.btnCreateResult.Size = new System.Drawing.Size(128, 24);
            this.btnCreateResult.TabIndex = 16;
            this.btnCreateResult.Text = "  Create Result";
            this.btnCreateResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateResult.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateResult.UseVisualStyleBackColor = true;
            this.btnCreateResult.Click += new System.EventHandler(this.btnCreateResult_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(570, 65);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(130, 13);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.Visible = false;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(483, 58);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 26);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(8, 6);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(684, 48);
            this.txtResult.TabIndex = 4;
            this.txtResult.TabStop = false;
            // 
            // colNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNo.HeaderText = "No.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNo.Width = 40;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Key Item";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colKey.Width = 280;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value Item";
            this.colValue.Name = "colValue";
            this.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 340;
            // 
            // index
            // 
            this.index.HeaderText = "Index";
            this.index.Name = "index";
            this.index.Visible = false;
            // 
            // FormCreateItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelSetting);
            this.Name = "FormCreateItem";
            this.Text = "Create Item";
            this.Load += new System.EventHandler(this.FormCreateAdapter_Load);
            this.panelSetting.ResumeLayout(false);
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxSetting.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSetParam)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.panelResult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFormat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridSetParam;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCreateResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
    }
}