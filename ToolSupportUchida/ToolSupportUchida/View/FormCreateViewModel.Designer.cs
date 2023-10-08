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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLogic = new System.Windows.Forms.RichTextBox();
            this.lblNumLogic = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtType = new System.Windows.Forms.RichTextBox();
            this.lblNumType = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPhysical = new System.Windows.Forms.RichTextBox();
            this.lblNumPhysical = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtNameItem = new System.Windows.Forms.RichTextBox();
            this.lblNumNameItem = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtValidation = new System.Windows.Forms.RichTextBox();
            this.lblNumValidation = new System.Windows.Forms.Label();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.rbModeC = new System.Windows.Forms.RadioButton();
            this.rbModeTypescript = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.grbClassName = new System.Windows.Forms.GroupBox();
            this.txtClassPhysical = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtClassLogic = new System.Windows.Forms.TextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grbClassName.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLogic);
            this.groupBox4.Controls.Add(this.lblNumLogic);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 48);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 265);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Logical";
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.Size = new System.Drawing.Size(126, 210);
            this.txtLogic.TabIndex = 1;
            this.txtLogic.Text = "";
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumLogic.Location = new System.Drawing.Point(27, 238);
            this.lblNumLogic.Name = "lblNumLogic";
            this.lblNumLogic.Size = new System.Drawing.Size(80, 15);
            this.lblNumLogic.TabIndex = 0;
            this.lblNumLogic.Text = "Line number:";
            this.lblNumLogic.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtType);
            this.groupBox1.Controls.Add(this.lblNumType);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(285, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 265);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Type";
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtType.Location = new System.Drawing.Point(3, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(126, 210);
            this.txtType.TabIndex = 3;
            this.txtType.Text = "";
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // lblNumType
            // 
            this.lblNumType.AutoSize = true;
            this.lblNumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumType.Location = new System.Drawing.Point(27, 238);
            this.lblNumType.Name = "lblNumType";
            this.lblNumType.Size = new System.Drawing.Size(80, 15);
            this.lblNumType.TabIndex = 0;
            this.lblNumType.Text = "Line number:";
            this.lblNumType.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPhysical);
            this.groupBox2.Controls.Add(this.lblNumPhysical);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(147, 48);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 265);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Physical";
            // 
            // txtPhysical
            // 
            this.txtPhysical.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPhysical.Location = new System.Drawing.Point(3, 19);
            this.txtPhysical.Name = "txtPhysical";
            this.txtPhysical.Size = new System.Drawing.Size(126, 210);
            this.txtPhysical.TabIndex = 2;
            this.txtPhysical.Text = "";
            this.txtPhysical.TextChanged += new System.EventHandler(this.txtPhysical_TextChanged);
            // 
            // lblNumPhysical
            // 
            this.lblNumPhysical.AutoSize = true;
            this.lblNumPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumPhysical.Location = new System.Drawing.Point(27, 238);
            this.lblNumPhysical.Name = "lblNumPhysical";
            this.lblNumPhysical.Size = new System.Drawing.Size(80, 15);
            this.lblNumPhysical.TabIndex = 0;
            this.lblNumPhysical.Text = "Line number:";
            this.lblNumPhysical.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtNameItem);
            this.groupBox3.Controls.Add(this.lblNumNameItem);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(423, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 265);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Name Item";
            // 
            // txtNameItem
            // 
            this.txtNameItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNameItem.Location = new System.Drawing.Point(3, 19);
            this.txtNameItem.Name = "txtNameItem";
            this.txtNameItem.Size = new System.Drawing.Size(125, 210);
            this.txtNameItem.TabIndex = 4;
            this.txtNameItem.Text = "";
            this.txtNameItem.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // lblNumNameItem
            // 
            this.lblNumNameItem.AutoSize = true;
            this.lblNumNameItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumNameItem.Location = new System.Drawing.Point(27, 238);
            this.lblNumNameItem.Name = "lblNumNameItem";
            this.lblNumNameItem.Size = new System.Drawing.Size(80, 15);
            this.lblNumNameItem.TabIndex = 0;
            this.lblNumNameItem.Text = "Line number:";
            this.lblNumNameItem.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtValidation);
            this.groupBox5.Controls.Add(this.lblNumValidation);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(560, 48);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 265);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Validation";
            // 
            // txtValidation
            // 
            this.txtValidation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtValidation.Location = new System.Drawing.Point(3, 19);
            this.txtValidation.Name = "txtValidation";
            this.txtValidation.Size = new System.Drawing.Size(125, 210);
            this.txtValidation.TabIndex = 5;
            this.txtValidation.Text = "";
            this.txtValidation.TextChanged += new System.EventHandler(this.txtValidation_TextChanged);
            // 
            // lblNumValidation
            // 
            this.lblNumValidation.AutoSize = true;
            this.lblNumValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumValidation.Location = new System.Drawing.Point(27, 238);
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
            this.groupBox23.Size = new System.Drawing.Size(132, 50);
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
            this.groupBox7.Controls.Add(this.lblResult);
            this.groupBox7.Controls.Add(this.btnCreate);
            this.groupBox7.Controls.Add(this.btnCopy);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(9, 310);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(682, 82);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(543, 57);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(130, 13);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.Visible = false;
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCreate.Image = global::ToolSupportCoding.Properties.Resources.create;
            this.btnCreate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreate.Location = new System.Drawing.Point(539, 21);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(68, 26);
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
            this.btnCopy.Location = new System.Drawing.Point(613, 21);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 26);
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
            this.btnClear.Location = new System.Drawing.Point(647, 21);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 26);
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
            this.txtResult.Size = new System.Drawing.Size(530, 60);
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
            this.grbClassName.Location = new System.Drawing.Point(147, 1);
            this.grbClassName.Name = "grbClassName";
            this.grbClassName.Size = new System.Drawing.Size(545, 50);
            this.grbClassName.TabIndex = 102;
            this.grbClassName.TabStop = false;
            this.grbClassName.Text = "Class Name View Model";
            this.grbClassName.Visible = false;
            // 
            // txtClassPhysical
            // 
            this.txtClassPhysical.Location = new System.Drawing.Point(373, 19);
            this.txtClassPhysical.Name = "txtClassPhysical";
            this.txtClassPhysical.Size = new System.Drawing.Size(168, 23);
            this.txtClassPhysical.TabIndex = 11;
            this.txtClassPhysical.TextChanged += new System.EventHandler(this.txtClassPhysical_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(282, 22);
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
            this.txtClassLogic.Location = new System.Drawing.Point(102, 19);
            this.txtClassLogic.Name = "txtClassLogic";
            this.txtClassLogic.Size = new System.Drawing.Size(168, 23);
            this.txtClassLogic.TabIndex = 8;
            this.txtClassLogic.TextChanged += new System.EventHandler(this.txtClassLogic_TextChanged);
            // 
            // FormCreateViewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.grbClassName);
            this.Controls.Add(this.groupBox23);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox7);
            this.Name = "FormCreateViewModel";
            this.Text = "Tool Support: Create View Model";
            this.Load += new System.EventHandler(this.FormCreateViewModel_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grbClassName.ResumeLayout(false);
            this.grbClassName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtLogic;
        private System.Windows.Forms.Label lblNumLogic;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtType;
        private System.Windows.Forms.Label lblNumType;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtPhysical;
        private System.Windows.Forms.Label lblNumPhysical;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox txtNameItem;
        private System.Windows.Forms.Label lblNumNameItem;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox txtValidation;
        private System.Windows.Forms.Label lblNumValidation;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.RadioButton rbModeTypescript;
        private System.Windows.Forms.RadioButton rbModeC;
        private System.Windows.Forms.GroupBox grbClassName;
        private System.Windows.Forms.TextBox txtClassPhysical;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtClassLogic;
    }
}