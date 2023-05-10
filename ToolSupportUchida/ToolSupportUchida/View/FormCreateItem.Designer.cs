
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.panelData = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gridSetParam = new System.Windows.Forms.DataGridView();
            this.panelResult = new System.Windows.Forms.Panel();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnCreateResult = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
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
            this.panelSetting.Size = new System.Drawing.Size(704, 83);
            this.panelSetting.TabIndex = 0;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Controls.Add(this.richTextBox1);
            this.groupBoxSetting.Controls.Add(this.btnClear);
            this.groupBoxSetting.Controls.Add(this.btnGet);
            this.groupBoxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBoxSetting.Location = new System.Drawing.Point(9, 1);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(682, 80);
            this.groupBoxSetting.TabIndex = 0;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Input Code";
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.create;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(580, 46);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(95, 26);
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
            this.btnGet.Location = new System.Drawing.Point(580, 15);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(95, 26);
            this.btnGet.TabIndex = 9;
            this.btnGet.Text = "  Get Item";
            this.btnGet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.groupBox1);
            this.panelData.Controls.Add(this.panelResult);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 83);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(704, 322);
            this.panelData.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gridSetParam);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(9, -4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 177);
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSetParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.gridSetParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSetParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNo,
            this.colKey,
            this.colValue,
            this.index});
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSetParam.DefaultCellStyle = dataGridViewCellStyle12;
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
            this.gridSetParam.Size = new System.Drawing.Size(676, 155);
            this.gridSetParam.TabIndex = 1;
            this.gridSetParam.CurrentCellDirtyStateChanged += new System.EventHandler(this.gridSetParam_CurrentCellDirtyStateChanged);
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.txtResult);
            this.panelResult.Controls.Add(this.btnCreateResult);
            this.panelResult.Controls.Add(this.lblResult);
            this.panelResult.Controls.Add(this.btnCopy);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelResult.Location = new System.Drawing.Point(0, 179);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(704, 143);
            this.panelResult.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(9, 2);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(683, 45);
            this.txtResult.TabIndex = 17;
            this.txtResult.Text = "";
            // 
            // btnCreateResult
            // 
            this.btnCreateResult.Enabled = false;
            this.btnCreateResult.FlatAppearance.BorderSize = 0;
            this.btnCreateResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateResult.Image = global::ToolSupportCoding.Properties.Resources.button_create_out;
            this.btnCreateResult.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateResult.Location = new System.Drawing.Point(9, 57);
            this.btnCreateResult.Name = "btnCreateResult";
            this.btnCreateResult.Size = new System.Drawing.Size(128, 26);
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
            this.lblResult.Location = new System.Drawing.Point(559, 67);
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
            this.btnCopy.Location = new System.Drawing.Point(473, 57);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(85, 28);
            this.btnCopy.TabIndex = 10;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(7, 17);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(567, 55);
            this.richTextBox1.TabIndex = 18;
            this.richTextBox1.Text = "";
            // 
            // colNo
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colNo.DefaultCellStyle = dataGridViewCellStyle11;
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
            this.colKey.Width = 280;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
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
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelSetting);
            this.Name = "FormCreateItem";
            this.Text = "Create Item";
            this.Load += new System.EventHandler(this.FormCreateAdapter_Load);
            this.panelSetting.ResumeLayout(false);
            this.groupBoxSetting.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gridSetParam;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCreateResult;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn index;
    }
}