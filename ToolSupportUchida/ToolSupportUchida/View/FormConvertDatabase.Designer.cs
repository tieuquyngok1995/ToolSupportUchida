
namespace ToolSupportCoding.View
{
    partial class FormConvertDatabase
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
            this.panelInputSQL = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInputSQL = new System.Windows.Forms.RichTextBox();
            this.panelInputParam = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.gridInputParam = new System.Windows.Forms.DataGridView();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelResult = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtSQLChar = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnConvert = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCreateParam = new System.Windows.Forms.Button();
            this.panelInputSQL.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelInputParam.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).BeginInit();
            this.panelResult.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelInputSQL
            // 
            this.panelInputSQL.Controls.Add(this.groupBox1);
            this.panelInputSQL.Location = new System.Drawing.Point(9, 3);
            this.panelInputSQL.Name = "panelInputSQL";
            this.panelInputSQL.Size = new System.Drawing.Size(335, 172);
            this.panelInputSQL.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInputSQL);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input SQL";
            // 
            // txtInputSQL
            // 
            this.txtInputSQL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInputSQL.Location = new System.Drawing.Point(3, 19);
            this.txtInputSQL.Name = "txtInputSQL";
            this.txtInputSQL.Size = new System.Drawing.Size(329, 150);
            this.txtInputSQL.TabIndex = 0;
            this.txtInputSQL.Text = "";
            // 
            // panelInputParam
            // 
            this.panelInputParam.Controls.Add(this.groupBox2);
            this.panelInputParam.Location = new System.Drawing.Point(9, 175);
            this.panelInputParam.Name = "panelInputParam";
            this.panelInputParam.Size = new System.Drawing.Size(477, 185);
            this.panelInputParam.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gridInputParam);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(477, 185);
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
            this.gridInputParam.Size = new System.Drawing.Size(471, 163);
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
            this.colValue.Width = 243;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.groupBox3);
            this.panelResult.Location = new System.Drawing.Point(492, 2);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(200, 360);
            this.panelResult.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtResult);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 360);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(194, 338);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtSQLChar);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(348, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 46);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "SQL Char";
            // 
            // txtSQLChar
            // 
            this.txtSQLChar.Location = new System.Drawing.Point(6, 18);
            this.txtSQLChar.Name = "txtSQLChar";
            this.txtSQLChar.Size = new System.Drawing.Size(127, 23);
            this.txtSQLChar.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(452, 121);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 26);
            this.btnClear.TabIndex = 5;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnConvert
            // 
            this.btnConvert.Enabled = false;
            this.btnConvert.FlatAppearance.BorderSize = 0;
            this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvert.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvert.Image = global::ToolSupportCoding.Properties.Resources.button_convert;
            this.btnConvert.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.Location = new System.Drawing.Point(354, 89);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(126, 26);
            this.btnConvert.TabIndex = 4;
            this.btnConvert.Text = "  Convert SQL";
            this.btnConvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvert.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(351, 154);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(130, 13);
            this.lblResult.TabIndex = 7;
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
            this.btnCopy.Location = new System.Drawing.Point(354, 121);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 26);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCreateParam
            // 
            this.btnCreateParam.FlatAppearance.BorderSize = 0;
            this.btnCreateParam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateParam.Image = global::ToolSupportCoding.Properties.Resources.button_add;
            this.btnCreateParam.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateParam.Location = new System.Drawing.Point(354, 56);
            this.btnCreateParam.Name = "btnCreateParam";
            this.btnCreateParam.Size = new System.Drawing.Size(126, 26);
            this.btnCreateParam.TabIndex = 8;
            this.btnCreateParam.Text = "  Add Param";
            this.btnCreateParam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateParam.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateParam.UseVisualStyleBackColor = true;
            this.btnCreateParam.Click += new System.EventHandler(this.btnCreateParam_Click);
            // 
            // FormConvertDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.btnCreateParam);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panelResult);
            this.Controls.Add(this.panelInputSQL);
            this.Controls.Add(this.panelInputParam);
            this.Name = "FormConvertDatabase";
            this.Text = "Convert Database";
            this.Load += new System.EventHandler(this.FormConvert_Load);
            this.panelInputSQL.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.panelInputParam.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridInputParam)).EndInit();
            this.panelResult.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelInputSQL;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelInputParam;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtInputSQL;
        private System.Windows.Forms.DataGridView gridInputParam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtSQLChar;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnCreateParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
    }
}