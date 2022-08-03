
namespace ToolSupportCoding.View
{
    partial class FormCreateAdapter
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
            this.panelTextJapan = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtPhysi = new System.Windows.Forms.TextBox();
            this.lblNumPhy = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogic = new System.Windows.Forms.TextBox();
            this.lblNumLogic = new System.Windows.Forms.Label();
            this.panelTextEng = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRow = new System.Windows.Forms.ComboBox();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.groupBoxSetting = new System.Windows.Forms.GroupBox();
            this.ckbCreate = new System.Windows.Forms.CheckBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnCreateOut = new System.Windows.Forms.Button();
            this.btnCreateIn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbSubColumn = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSubRow = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbColumn = new System.Windows.Forms.ComboBox();
            this.panelTextJapan.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelTextEng.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.groupBoxSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTextJapan
            // 
            this.panelTextJapan.Controls.Add(this.groupBox3);
            this.panelTextJapan.Controls.Add(this.groupBox1);
            this.panelTextJapan.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTextJapan.Location = new System.Drawing.Point(0, 0);
            this.panelTextJapan.Name = "panelTextJapan";
            this.panelTextJapan.Size = new System.Drawing.Size(375, 405);
            this.panelTextJapan.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtPhysi);
            this.groupBox3.Controls.Add(this.lblNumPhy);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(192, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 394);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Physical Name";
            // 
            // txtPhysi
            // 
            this.txtPhysi.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPhysi.Location = new System.Drawing.Point(3, 19);
            this.txtPhysi.Multiline = true;
            this.txtPhysi.Name = "txtPhysi";
            this.txtPhysi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPhysi.Size = new System.Drawing.Size(174, 338);
            this.txtPhysi.TabIndex = 3;
            this.txtPhysi.TextChanged += new System.EventHandler(this.txtPhysi_TextChanged);
            this.txtPhysi.Leave += new System.EventHandler(this.txtPhysi_Leave);
            // 
            // lblNumPhy
            // 
            this.lblNumPhy.AutoSize = true;
            this.lblNumPhy.Location = new System.Drawing.Point(6, 364);
            this.lblNumPhy.Name = "lblNumPhy";
            this.lblNumPhy.Size = new System.Drawing.Size(91, 17);
            this.lblNumPhy.TabIndex = 2;
            this.lblNumPhy.Text = "Line number:";
            this.lblNumPhy.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogic);
            this.groupBox1.Controls.Add(this.lblNumLogic);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Logical Name";
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Multiline = true;
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogic.Size = new System.Drawing.Size(174, 338);
            this.txtLogic.TabIndex = 2;
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            this.txtLogic.Leave += new System.EventHandler(this.txtLogic_Leave);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Location = new System.Drawing.Point(6, 364);
            this.lblNumLogic.Name = "lblNumLogic";
            this.lblNumLogic.Size = new System.Drawing.Size(91, 17);
            this.lblNumLogic.TabIndex = 1;
            this.lblNumLogic.Text = "Line number:";
            this.lblNumLogic.Visible = false;
            // 
            // panelTextEng
            // 
            this.panelTextEng.Controls.Add(this.groupBox2);
            this.panelTextEng.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTextEng.Location = new System.Drawing.Point(489, 0);
            this.panelTextEng.Name = "panelTextEng";
            this.panelTextEng.Size = new System.Drawing.Size(215, 405);
            this.panelTextEng.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResult);
            this.groupBox2.Controls.Add(this.txtResult);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 393);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(4, 367);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(149, 15);
            this.lblResult.TabIndex = 13;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.Visible = false;
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResult.Enabled = false;
            this.txtResult.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(194, 338);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Rows";
            // 
            // cbRow
            // 
            this.cbRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRow.Location = new System.Drawing.Point(4, 47);
            this.cbRow.Name = "cbRow";
            this.cbRow.Size = new System.Drawing.Size(102, 24);
            this.cbRow.Sorted = true;
            this.cbRow.TabIndex = 3;
            this.cbRow.SelectedIndexChanged += new System.EventHandler(this.cbRow_SelectedIndexChanged);
            // 
            // panelSetting
            // 
            this.panelSetting.Controls.Add(this.groupBoxSetting);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(375, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(114, 405);
            this.panelSetting.TabIndex = 4;
            // 
            // groupBoxSetting
            // 
            this.groupBoxSetting.Controls.Add(this.ckbCreate);
            this.groupBoxSetting.Controls.Add(this.btnClear);
            this.groupBoxSetting.Controls.Add(this.btnCopy);
            this.groupBoxSetting.Controls.Add(this.btnCreateOut);
            this.groupBoxSetting.Controls.Add(this.btnCreateIn);
            this.groupBoxSetting.Controls.Add(this.label6);
            this.groupBoxSetting.Controls.Add(this.cbSubColumn);
            this.groupBoxSetting.Controls.Add(this.label7);
            this.groupBoxSetting.Controls.Add(this.cbSubRow);
            this.groupBoxSetting.Controls.Add(this.label5);
            this.groupBoxSetting.Controls.Add(this.cbColumn);
            this.groupBoxSetting.Controls.Add(this.label4);
            this.groupBoxSetting.Controls.Add(this.cbRow);
            this.groupBoxSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSetting.Location = new System.Drawing.Point(0, 0);
            this.groupBoxSetting.Name = "groupBoxSetting";
            this.groupBoxSetting.Size = new System.Drawing.Size(114, 393);
            this.groupBoxSetting.TabIndex = 4;
            this.groupBoxSetting.TabStop = false;
            this.groupBoxSetting.Text = "Setting";
            // 
            // ckbCreate
            // 
            this.ckbCreate.AutoSize = true;
            this.ckbCreate.Location = new System.Drawing.Point(9, 261);
            this.ckbCreate.Name = "ckbCreate";
            this.ckbCreate.Size = new System.Drawing.Size(95, 21);
            this.ckbCreate.TabIndex = 14;
            this.ckbCreate.Text = "Create List";
            this.ckbCreate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.Location = new System.Drawing.Point(78, 326);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 28);
            this.btnClear.TabIndex = 13;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(4, 326);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(65, 28);
            this.btnCopy.TabIndex = 12;
            this.btnCopy.Text = "Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnCreateOut
            // 
            this.btnCreateOut.Enabled = false;
            this.btnCreateOut.FlatAppearance.BorderSize = 0;
            this.btnCreateOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateOut.Image = global::ToolSupportCoding.Properties.Resources.button_create_out;
            this.btnCreateOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateOut.Location = new System.Drawing.Point(4, 290);
            this.btnCreateOut.Name = "btnCreateOut";
            this.btnCreateOut.Size = new System.Drawing.Size(102, 28);
            this.btnCreateOut.TabIndex = 11;
            this.btnCreateOut.Text = "Create Out";
            this.btnCreateOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateOut.UseVisualStyleBackColor = true;
            this.btnCreateOut.Click += new System.EventHandler(this.btnCreateOut_Click);
            // 
            // btnCreateIn
            // 
            this.btnCreateIn.Enabled = false;
            this.btnCreateIn.FlatAppearance.BorderSize = 0;
            this.btnCreateIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateIn.Image = global::ToolSupportCoding.Properties.Resources.button_create_in;
            this.btnCreateIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateIn.Location = new System.Drawing.Point(4, 224);
            this.btnCreateIn.Name = "btnCreateIn";
            this.btnCreateIn.Size = new System.Drawing.Size(102, 28);
            this.btnCreateIn.TabIndex = 10;
            this.btnCreateIn.Text = "Create In";
            this.btnCreateIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateIn.UseVisualStyleBackColor = true;
            this.btnCreateIn.Click += new System.EventHandler(this.btnCreateIn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Sub Columns";
            // 
            // cbSubColumn
            // 
            this.cbSubColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubColumn.FormattingEnabled = true;
            this.cbSubColumn.Location = new System.Drawing.Point(4, 194);
            this.cbSubColumn.Name = "cbSubColumn";
            this.cbSubColumn.Size = new System.Drawing.Size(102, 24);
            this.cbSubColumn.TabIndex = 9;
            this.cbSubColumn.SelectedIndexChanged += new System.EventHandler(this.cbSubColumn_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Sub Rows";
            // 
            // cbSubRow
            // 
            this.cbSubRow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubRow.FormattingEnabled = true;
            this.cbSubRow.Location = new System.Drawing.Point(4, 145);
            this.cbSubRow.Name = "cbSubRow";
            this.cbSubRow.Size = new System.Drawing.Size(102, 24);
            this.cbSubRow.TabIndex = 7;
            this.cbSubRow.SelectedIndexChanged += new System.EventHandler(this.cbSubRow_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Columns";
            // 
            // cbColumn
            // 
            this.cbColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumn.FormattingEnabled = true;
            this.cbColumn.Location = new System.Drawing.Point(4, 96);
            this.cbColumn.Name = "cbColumn";
            this.cbColumn.Size = new System.Drawing.Size(102, 24);
            this.cbColumn.TabIndex = 5;
            this.cbColumn.SelectedIndexChanged += new System.EventHandler(this.cbColumn_SelectedIndexChanged);
            // 
            // FormCreateAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.panelSetting);
            this.Controls.Add(this.panelTextEng);
            this.Controls.Add(this.panelTextJapan);
            this.Name = "FormCreateAdapter";
            this.Text = "Create Adapter";
            this.Load += new System.EventHandler(this.FormCreateAdapter_Load);
            this.panelTextJapan.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelTextEng.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelSetting.ResumeLayout(false);
            this.groupBoxSetting.ResumeLayout(false);
            this.groupBoxSetting.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTextJapan;
        private System.Windows.Forms.Panel panelTextEng;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblNumPhy;
        private System.Windows.Forms.Label lblNumLogic;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRow;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.GroupBox groupBoxSetting;
        private System.Windows.Forms.Button btnCreateIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbSubColumn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbSubRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbColumn;
        private System.Windows.Forms.Button btnCreateOut;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtPhysi;
        private System.Windows.Forms.TextBox txtLogic;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox ckbCreate;
    }
}