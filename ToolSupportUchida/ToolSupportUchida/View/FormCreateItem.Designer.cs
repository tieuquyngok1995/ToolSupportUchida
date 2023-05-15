
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
            this.txtInputCode = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.groupBoxResult = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridSetParam = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.act = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rowCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelResult = new System.Windows.Forms.Panel();
            this.chkComment = new System.Windows.Forms.CheckBox();
            this.panelSetting.SuspendLayout();
            this.groupBoxSetting.SuspendLayout();
            this.panelData.SuspendLayout();
            this.groupBoxResult.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSetParam)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.groupBoxSetting);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(704, 77);
            this.panelSetting.TabIndex = 0;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Controls.Add(this.txtInputCode);
            this.groupBoxSetting.Controls.Add(this.btnClear);
            this.groupBoxSetting.Controls.Add(this.btnGet);
            this.groupBoxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxSetting.Location = new System.Drawing.Point(9, 1);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(682, 74);
            this.groupBoxSetting.TabIndex = 0;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Input Code";
            // 
            // txtInputCode
            // 
            this.txtInputCode.Location = new System.Drawing.Point(7, 16);
            this.txtInputCode.Name = "txtInputCode";
            this.txtInputCode.Size = new System.Drawing.Size(567, 51);
            this.txtInputCode.TabIndex = 18;
            this.txtInputCode.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.create;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(580, 42);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 24);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "  Clear";
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGet
            // 
            this.btnGet.FlatAppearance.BorderSize = 0;
            this.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGet.Image = global::ToolSupportCoding.Properties.Resources.button_create_in;
            this.btnGet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGet.Location = new System.Drawing.Point(580, 14);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(95, 24);
            this.btnGet.TabIndex = 9;
            this.btnGet.Text = "  Get Item";
            this.btnGet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGetItem_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.groupBoxResult);
            this.panelData.Controls.Add(this.groupBox1);
            this.panelData.Controls.Add(this.panelResult);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 77);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(704, 297);
            this.panelData.TabIndex = 1;
            // 
            // groupBoxResult
            // 
            this.groupBoxResult.Controls.Add(this.chkComment);
            this.groupBoxResult.Controls.Add(this.btnEdit);
            this.groupBoxResult.Controls.Add(this.lblResult);
            this.groupBoxResult.Controls.Add(this.txtResult);
            this.groupBoxResult.Controls.Add(this.btnCopy);
            this.groupBoxResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxResult.Location = new System.Drawing.Point(9, 148);
            this.groupBoxResult.Name = "groupBoxResult";
            this.groupBoxResult.Size = new System.Drawing.Size(682, 137);
            this.groupBoxResult.TabIndex = 18;
            this.groupBoxResult.TabStop = false;
            this.groupBoxResult.Text = "Result";
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = global::ToolSupportCoding.Properties.Resources.button_create_out;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(580, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 26);
            this.btnEdit.TabIndex = 16;
            this.btnEdit.Text = "  Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(580, 105);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(95, 28);
            this.lblResult.TabIndex = 12;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Visible = false;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(7, 16);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(567, 114);
            this.txtResult.TabIndex = 17;
            this.txtResult.Text = "";
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(580, 80);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(95, 26);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridSetParam);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(9, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 150);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "List Item";
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
            this.act,
            this.index,
            this.rowCount});
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
            this.gridSetParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridSetParam.Size = new System.Drawing.Size(676, 128);
            this.gridSetParam.TabIndex = 1;
            this.gridSetParam.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridSetParam_CurrentCellDirtyStateChanged);
            // 
            // colNo
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNo.HeaderText = "Line.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colNo.Width = 40;
            // 
            // colKey
            // 
            this.colKey.HeaderText = "Name Item";
            this.colKey.Name = "colKey";
            this.colKey.ReadOnly = true;
            this.colKey.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colKey.Width = 215;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 340;
            // 
            // act
            // 
            this.act.HeaderText = "Action";
            this.act.Name = "act";
            this.act.Width = 63;
            // 
            // index
            // 
            this.index.HeaderText = "Note";
            this.index.Name = "index";
            this.index.Visible = false;
            // 
            // rowCount
            // 
            this.rowCount.HeaderText = "Row Count";
            this.rowCount.Name = "rowCount";
            this.rowCount.Visible = false;
            // 
            // panelResult
            // 
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelResult.Location = new System.Drawing.Point(0, 151);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(704, 146);
            this.panelResult.TabIndex = 1;
            // 
            // chkComment
            // 
            this.chkComment.AutoSize = true;
            this.chkComment.Checked = true;
            this.chkComment.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkComment.Location = new System.Drawing.Point(580, 16);
            this.chkComment.Name = "chkComment";
            this.chkComment.Size = new System.Drawing.Size(86, 21);
            this.chkComment.TabIndex = 18;
            this.chkComment.Text = "Comment";
            this.chkComment.UseVisualStyleBackColor = true;
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
            this.panelData.ResumeLayout(false);
            this.groupBoxResult.ResumeLayout(false);
            this.groupBoxResult.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSetParam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridSetParam;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.RichTextBox txtInputCode;
        private System.Windows.Forms.GroupBox groupBoxResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn act;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowCount;
        private System.Windows.Forms.CheckBox chkComment;
    }
}