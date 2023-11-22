namespace ToolSupportCoding.View
{
    partial class FormCreateViewModel
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
            this.grbInputLogic = new System.Windows.Forms.GroupBox();
            this.txtLogic = new System.Windows.Forms.RichTextBox();
            this.lblNumLogic = new System.Windows.Forms.Label();
            this.grbInputType = new System.Windows.Forms.GroupBox();
            this.txtType = new System.Windows.Forms.RichTextBox();
            this.lblNumType = new System.Windows.Forms.Label();
            this.grbInputPhysical = new System.Windows.Forms.GroupBox();
            this.txtPhysical = new System.Windows.Forms.RichTextBox();
            this.lblNumPhysical = new System.Windows.Forms.Label();
            this.grbInputNameItem = new System.Windows.Forms.GroupBox();
            this.txtNameItem = new System.Windows.Forms.RichTextBox();
            this.lblNumNameItem = new System.Windows.Forms.Label();
            this.grbInputValidation = new System.Windows.Forms.GroupBox();
            this.txtValidation = new System.Windows.Forms.RichTextBox();
            this.lblNumValidation = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.rbModeC = new System.Windows.Forms.RadioButton();
            this.rbModeTypescript = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.grbClassName = new System.Windows.Forms.GroupBox();
            this.txtClassPhysical = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClassLogic = new System.Windows.Forms.TextBox();
            this.grbMode = new System.Windows.Forms.GroupBox();
            this.rbNew = new System.Windows.Forms.RadioButton();
            this.rbTransfer = new System.Windows.Forms.RadioButton();
            this.grbInputLogic.SuspendLayout();
            this.grbInputType.SuspendLayout();
            this.grbInputPhysical.SuspendLayout();
            this.grbInputNameItem.SuspendLayout();
            this.grbInputValidation.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grbClassName.SuspendLayout();
            this.grbMode.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbInputLogic
            // 
            this.grbInputLogic.Controls.Add(this.txtLogic);
            this.grbInputLogic.Controls.Add(this.lblNumLogic);
            this.grbInputLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputLogic.Location = new System.Drawing.Point(9, 47);
            this.grbInputLogic.Name = "grbInputLogic";
            this.grbInputLogic.Size = new System.Drawing.Size(132, 242);
            this.grbInputLogic.TabIndex = 1;
            this.grbInputLogic.TabStop = false;
            this.grbInputLogic.Text = "Input Logical";
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.Size = new System.Drawing.Size(126, 191);
            this.txtLogic.TabIndex = 1;
            this.txtLogic.Text = "";
            this.txtLogic.Click += new System.EventHandler(this.txtLogic_Click);
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumLogic.Location = new System.Drawing.Point(27, 217);
            this.lblNumLogic.Name = "lblNumLogic";
            this.lblNumLogic.Size = new System.Drawing.Size(80, 15);
            this.lblNumLogic.TabIndex = 0;
            this.lblNumLogic.Text = "Line number:";
            this.lblNumLogic.Visible = false;
            // 
            // grbInputType
            // 
            this.grbInputType.Controls.Add(this.txtType);
            this.grbInputType.Controls.Add(this.lblNumType);
            this.grbInputType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputType.Location = new System.Drawing.Point(285, 47);
            this.grbInputType.Name = "grbInputType";
            this.grbInputType.Size = new System.Drawing.Size(132, 242);
            this.grbInputType.TabIndex = 3;
            this.grbInputType.TabStop = false;
            this.grbInputType.Text = "Input Type";
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtType.Location = new System.Drawing.Point(3, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(126, 191);
            this.txtType.TabIndex = 3;
            this.txtType.Text = "";
            this.txtType.Click += new System.EventHandler(this.txtType_Click);
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // lblNumType
            // 
            this.lblNumType.AutoSize = true;
            this.lblNumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumType.Location = new System.Drawing.Point(27, 217);
            this.lblNumType.Name = "lblNumType";
            this.lblNumType.Size = new System.Drawing.Size(80, 15);
            this.lblNumType.TabIndex = 0;
            this.lblNumType.Text = "Line number:";
            this.lblNumType.Visible = false;
            // 
            // grbInputPhysical
            // 
            this.grbInputPhysical.Controls.Add(this.txtPhysical);
            this.grbInputPhysical.Controls.Add(this.lblNumPhysical);
            this.grbInputPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputPhysical.Location = new System.Drawing.Point(147, 47);
            this.grbInputPhysical.Name = "grbInputPhysical";
            this.grbInputPhysical.Size = new System.Drawing.Size(132, 242);
            this.grbInputPhysical.TabIndex = 2;
            this.grbInputPhysical.TabStop = false;
            this.grbInputPhysical.Text = "Input Physical";
            // 
            // txtPhysical
            // 
            this.txtPhysical.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPhysical.Location = new System.Drawing.Point(3, 19);
            this.txtPhysical.Name = "txtPhysical";
            this.txtPhysical.Size = new System.Drawing.Size(126, 191);
            this.txtPhysical.TabIndex = 2;
            this.txtPhysical.Text = "";
            this.txtPhysical.Click += new System.EventHandler(this.txtPhysical_Click);
            this.txtPhysical.TextChanged += new System.EventHandler(this.txtPhysical_TextChanged);
            // 
            // lblNumPhysical
            // 
            this.lblNumPhysical.AutoSize = true;
            this.lblNumPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumPhysical.Location = new System.Drawing.Point(27, 217);
            this.lblNumPhysical.Name = "lblNumPhysical";
            this.lblNumPhysical.Size = new System.Drawing.Size(80, 15);
            this.lblNumPhysical.TabIndex = 0;
            this.lblNumPhysical.Text = "Line number:";
            this.lblNumPhysical.Visible = false;
            // 
            // grbInputNameItem
            // 
            this.grbInputNameItem.Controls.Add(this.txtNameItem);
            this.grbInputNameItem.Controls.Add(this.lblNumNameItem);
            this.grbInputNameItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputNameItem.Location = new System.Drawing.Point(423, 47);
            this.grbInputNameItem.Name = "grbInputNameItem";
            this.grbInputNameItem.Size = new System.Drawing.Size(131, 242);
            this.grbInputNameItem.TabIndex = 4;
            this.grbInputNameItem.TabStop = false;
            this.grbInputNameItem.Text = "Input Name Item";
            // 
            // txtNameItem
            // 
            this.txtNameItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNameItem.Location = new System.Drawing.Point(3, 19);
            this.txtNameItem.Name = "txtNameItem";
            this.txtNameItem.Size = new System.Drawing.Size(125, 191);
            this.txtNameItem.TabIndex = 4;
            this.txtNameItem.Text = "";
            this.txtNameItem.Click += new System.EventHandler(this.txtNameItem_Click);
            this.txtNameItem.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // lblNumNameItem
            // 
            this.lblNumNameItem.AutoSize = true;
            this.lblNumNameItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumNameItem.Location = new System.Drawing.Point(26, 217);
            this.lblNumNameItem.Name = "lblNumNameItem";
            this.lblNumNameItem.Size = new System.Drawing.Size(80, 15);
            this.lblNumNameItem.TabIndex = 0;
            this.lblNumNameItem.Text = "Line number:";
            this.lblNumNameItem.Visible = false;
            // 
            // grbInputValidation
            // 
            this.grbInputValidation.Controls.Add(this.txtValidation);
            this.grbInputValidation.Controls.Add(this.lblNumValidation);
            this.grbInputValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputValidation.Location = new System.Drawing.Point(560, 47);
            this.grbInputValidation.Name = "grbInputValidation";
            this.grbInputValidation.Size = new System.Drawing.Size(131, 242);
            this.grbInputValidation.TabIndex = 5;
            this.grbInputValidation.TabStop = false;
            this.grbInputValidation.Text = "Input Validation";
            // 
            // txtValidation
            // 
            this.txtValidation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtValidation.Location = new System.Drawing.Point(3, 19);
            this.txtValidation.Name = "txtValidation";
            this.txtValidation.Size = new System.Drawing.Size(125, 191);
            this.txtValidation.TabIndex = 5;
            this.txtValidation.Text = "";
            this.txtValidation.Click += new System.EventHandler(this.txtValidation_Click);
            this.txtValidation.TextChanged += new System.EventHandler(this.txtValidation_TextChanged);
            // 
            // lblNumValidation
            // 
            this.lblNumValidation.AutoSize = true;
            this.lblNumValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumValidation.Location = new System.Drawing.Point(26, 217);
            this.lblNumValidation.Name = "lblNumValidation";
            this.lblNumValidation.Size = new System.Drawing.Size(80, 15);
            this.lblNumValidation.TabIndex = 0;
            this.lblNumValidation.Text = "Line number:";
            this.lblNumValidation.Visible = false;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.rbModeC);
            this.groupBox23.Controls.Add(this.rbModeTypescript);
            this.groupBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox23.Location = new System.Drawing.Point(9, 1);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(132, 49);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Language";
            // 
            // rbModeC
            // 
            this.rbModeC.AutoSize = true;
            this.rbModeC.Checked = true;
            this.rbModeC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeC.Location = new System.Drawing.Point(10, 20);
            this.rbModeC.Name = "rbModeC";
            this.rbModeC.Size = new System.Drawing.Size(40, 19);
            this.rbModeC.TabIndex = 100;
            this.rbModeC.TabStop = true;
            this.rbModeC.Text = "C#";
            this.rbModeC.UseVisualStyleBackColor = true;
            this.rbModeC.CheckedChanged += new System.EventHandler(this.rbModeC_CheckedChanged);
            // 
            // rbModeTypescript
            // 
            this.rbModeTypescript.AutoSize = true;
            this.rbModeTypescript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeTypescript.Location = new System.Drawing.Point(50, 20);
            this.rbModeTypescript.Name = "rbModeTypescript";
            this.rbModeTypescript.Size = new System.Drawing.Size(80, 19);
            this.rbModeTypescript.TabIndex = 101;
            this.rbModeTypescript.Text = "Typescript";
            this.rbModeTypescript.UseVisualStyleBackColor = true;
            this.rbModeTypescript.CheckedChanged += new System.EventHandler(this.rbModeTypescript_CheckedChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCreate);
            this.groupBox7.Controls.Add(this.btnCopy);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(9, 286);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(682, 76);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result";
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCreate.Image = global::ToolSupportCoding.Properties.Resources.create;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(536, 47);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(80, 24);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(619, 47);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 24);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(650, 47);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 24);
            this.btnClear.TabIndex = 9;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(530, 54);
            this.txtResult.TabIndex = 6;
            this.txtResult.Text = "";
            // 
            // grbClassName
            // 
            this.grbClassName.Controls.Add(this.txtClassPhysical);
            this.grbClassName.Controls.Add(this.label1);
            this.grbClassName.Controls.Add(this.label9);
            this.grbClassName.Controls.Add(this.txtClassLogic);
            this.grbClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClassName.Location = new System.Drawing.Point(285, 1);
            this.grbClassName.Name = "grbClassName";
            this.grbClassName.Size = new System.Drawing.Size(407, 49);
            this.grbClassName.TabIndex = 102;
            this.grbClassName.TabStop = false;
            this.grbClassName.Text = "Class Name View Model";
            this.grbClassName.Visible = false;
            // 
            // txtClassPhysical
            // 
            this.txtClassPhysical.Location = new System.Drawing.Point(295, 18);
            this.txtClassPhysical.Name = "txtClassPhysical";
            this.txtClassPhysical.Size = new System.Drawing.Size(105, 23);
            this.txtClassPhysical.TabIndex = 11;
            this.txtClassPhysical.Click += new System.EventHandler(this.txtClassPhysical_Click);
            this.txtClassPhysical.TextChanged += new System.EventHandler(this.txtClassPhysical_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(204, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Physical Name";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 9;
            this.label9.Text = "Logical Name";
            // 
            // txtClassLogic
            // 
            this.txtClassLogic.Location = new System.Drawing.Point(92, 18);
            this.txtClassLogic.Name = "txtClassLogic";
            this.txtClassLogic.Size = new System.Drawing.Size(105, 23);
            this.txtClassLogic.TabIndex = 8;
            this.txtClassLogic.Click += new System.EventHandler(this.txtClassLogic_Click);
            this.txtClassLogic.TextChanged += new System.EventHandler(this.txtClassLogic_TextChanged);
            // 
            // grbMode
            // 
            this.grbMode.Controls.Add(this.rbNew);
            this.grbMode.Controls.Add(this.rbTransfer);
            this.grbMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbMode.Location = new System.Drawing.Point(147, 1);
            this.grbMode.Name = "grbMode";
            this.grbMode.Size = new System.Drawing.Size(132, 49);
            this.grbMode.TabIndex = 102;
            this.grbMode.TabStop = false;
            this.grbMode.Text = "Mode";
            this.grbMode.Visible = false;
            // 
            // rbNew
            // 
            this.rbNew.AutoSize = true;
            this.rbNew.Checked = true;
            this.rbNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNew.Location = new System.Drawing.Point(10, 20);
            this.rbNew.Name = "rbNew";
            this.rbNew.Size = new System.Drawing.Size(50, 19);
            this.rbNew.TabIndex = 100;
            this.rbNew.TabStop = true;
            this.rbNew.Text = "New";
            this.rbNew.UseVisualStyleBackColor = true;
            this.rbNew.CheckedChanged += new System.EventHandler(this.rbNew_CheckedChanged);
            // 
            // rbTransfer
            // 
            this.rbTransfer.AutoSize = true;
            this.rbTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbTransfer.Location = new System.Drawing.Point(61, 20);
            this.rbTransfer.Name = "rbTransfer";
            this.rbTransfer.Size = new System.Drawing.Size(70, 19);
            this.rbTransfer.TabIndex = 101;
            this.rbTransfer.Text = "Transfer";
            this.rbTransfer.UseVisualStyleBackColor = true;
            this.rbTransfer.CheckedChanged += new System.EventHandler(this.rbTransfer_CheckedChanged);
            // 
            // FormCreateViewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.grbMode);
            this.Controls.Add(this.grbClassName);
            this.Controls.Add(this.groupBox23);
            this.Controls.Add(this.grbInputValidation);
            this.Controls.Add(this.grbInputNameItem);
            this.Controls.Add(this.grbInputType);
            this.Controls.Add(this.grbInputLogic);
            this.Controls.Add(this.grbInputPhysical);
            this.Controls.Add(this.groupBox7);
            this.Name = "FormCreateViewModel";
            this.Text = "Tool Support: Create View Model";
            this.Load += new System.EventHandler(this.FormCreateViewModel_Load);
            this.grbInputLogic.ResumeLayout(false);
            this.grbInputLogic.PerformLayout();
            this.grbInputType.ResumeLayout(false);
            this.grbInputType.PerformLayout();
            this.grbInputPhysical.ResumeLayout(false);
            this.grbInputPhysical.PerformLayout();
            this.grbInputNameItem.ResumeLayout(false);
            this.grbInputNameItem.PerformLayout();
            this.grbInputValidation.ResumeLayout(false);
            this.grbInputValidation.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.grbClassName.ResumeLayout(false);
            this.grbClassName.PerformLayout();
            this.grbMode.ResumeLayout(false);
            this.grbMode.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbInputLogic;
        private System.Windows.Forms.RichTextBox txtLogic;
        private System.Windows.Forms.Label lblNumLogic;
        private System.Windows.Forms.GroupBox grbInputType;
        private System.Windows.Forms.RichTextBox txtType;
        private System.Windows.Forms.Label lblNumType;
        private System.Windows.Forms.GroupBox grbInputPhysical;
        private System.Windows.Forms.RichTextBox txtPhysical;
        private System.Windows.Forms.Label lblNumPhysical;
        private System.Windows.Forms.GroupBox grbInputNameItem;
        private System.Windows.Forms.RichTextBox txtNameItem;
        private System.Windows.Forms.Label lblNumNameItem;
        private System.Windows.Forms.GroupBox grbInputValidation;
        private System.Windows.Forms.RichTextBox txtValidation;
        private System.Windows.Forms.Label lblNumValidation;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rbModeTypescript;
        private System.Windows.Forms.RadioButton rbModeC;
        private System.Windows.Forms.GroupBox grbClassName;
        private System.Windows.Forms.TextBox txtClassPhysical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClassLogic;
        private System.Windows.Forms.GroupBox grbMode;
        private System.Windows.Forms.RadioButton rbNew;
        private System.Windows.Forms.RadioButton rbTransfer;
    }
}