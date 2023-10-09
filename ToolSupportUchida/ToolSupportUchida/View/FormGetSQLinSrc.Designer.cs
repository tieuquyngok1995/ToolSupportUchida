
namespace ToolSupportCoding.View
{
    partial class FormGetSQLinSrc
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
            this.panelInputParam = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridInputParam = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSQLChar = new System.Windows.Forms.TextBox();
            this.txtInputSQL = new System.Windows.Forms.RichTextBox();
            this.btnCreateParam = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panelInputParam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInputParam
            // 
            this.panelInputParam.Controls.Add(this.groupBox2);
            this.panelInputParam.Location = new System.Drawing.Point(9, 170);
            this.panelInputParam.Name = "panelInputParam";
            this.panelInputParam.Size = new System.Drawing.Size(476, 192);
            this.panelInputParam.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridInputParam);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 192);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Parameters";
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
            this.gridInputParam.Size = new System.Drawing.Size(470, 170);
            this.gridInputParam.TabIndex = 0;
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
            this.colNo.Width = 40;
            // 
            // colParam
            // 
            this.colParam.HeaderText = "Param";
            this.colParam.Name = "colParam";
            this.colParam.ReadOnly = true;
            this.colParam.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colParam.Width = 170;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "Value";
            this.colValue.Name = "colValue";
            this.colValue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValue.Width = 242;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnConvert);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(491, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 361);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(194, 310);
            this.txtResult.TabIndex = 6;
            this.txtResult.Text = "";
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(170, 332);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(26, 24);
            this.btnClear.TabIndex = 5;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(141, 332);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(26, 24);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Image = global::ToolSupportCoding.Properties.Resources.button_convert;
            this.btnConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.Location = new System.Drawing.Point(4, 332);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(134, 24);
            this.btnConvert.TabIndex = 3;
            this.btnConvert.Text = "  Convert SQL";
            this.btnConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCreateParam);
            this.groupBox1.Controls.Add(this.txtInputSQL);
            this.groupBox1.Controls.Add(this.txtSQLChar);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(476, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input SQL";
            // 
            // txtSQLChar
            // 
            this.txtSQLChar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtSQLChar.Location = new System.Drawing.Point(96, 15);
            this.txtSQLChar.Name = "txtSQLChar";
            this.txtSQLChar.Size = new System.Drawing.Size(237, 23);
            this.txtSQLChar.TabIndex = 1;
            // 
            // txtInputSQL
            // 
            this.txtInputSQL.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtInputSQL.Location = new System.Drawing.Point(3, 44);
            this.txtInputSQL.Name = "txtInputSQL";
            this.txtInputSQL.Size = new System.Drawing.Size(470, 125);
            this.txtInputSQL.TabIndex = 0;
            this.txtInputSQL.Text = "";
            // 
            // btnCreateParam
            // 
            this.btnCreateParam.FlatAppearance.BorderSize = 0;
            this.btnCreateParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.btnCreateParam.Image = global::ToolSupportCoding.Properties.Resources.button_add;
            this.btnCreateParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateParam.Location = new System.Drawing.Point(339, 15);
            this.btnCreateParam.Name = "btnCreateParam";
            this.btnCreateParam.Size = new System.Drawing.Size(130, 23);
            this.btnCreateParam.TabIndex = 2;
            this.btnCreateParam.Text = "  Add Parameter";
            this.btnCreateParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateParam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateParam.UseVisualStyleBackColor = true;
            this.btnCreateParam.Click += new System.EventHandler(this.btnCreateParam_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "SQL Character";
            // 
            // FormGetSQLinSrc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panelInputParam);
            this.Name = "FormGetSQLinSrc";
            this.Text = "Tool Support: Get SQL in Source";
            this.Load += new System.EventHandler(this.FormConvert_Load);
            this.panelInputParam.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelInputParam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView gridInputParam;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCreateParam;
        private System.Windows.Forms.RichTextBox txtInputSQL;
        private System.Windows.Forms.TextBox txtSQLChar;
    }
}