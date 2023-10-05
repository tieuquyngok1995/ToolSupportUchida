﻿namespace ToolSupportCoding.View
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
            this.lblLanguage = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogicNameVM = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhysicalNameVM = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtLogic);
            this.groupBox4.Controls.Add(this.lblNumLogic);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 245);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Logical";
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.Size = new System.Drawing.Size(126, 194);
            this.txtLogic.TabIndex = 1;
            this.txtLogic.Text = "";
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumLogic.Location = new System.Drawing.Point(27, 220);
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
            this.groupBox1.Location = new System.Drawing.Point(285, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 245);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Type";
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtType.Location = new System.Drawing.Point(3, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(126, 194);
            this.txtType.TabIndex = 3;
            this.txtType.Text = "";
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // lblNumType
            // 
            this.lblNumType.AutoSize = true;
            this.lblNumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumType.Location = new System.Drawing.Point(27, 220);
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
            this.groupBox2.Location = new System.Drawing.Point(147, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(132, 245);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Physical";
            // 
            // txtPhysical
            // 
            this.txtPhysical.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPhysical.Location = new System.Drawing.Point(3, 19);
            this.txtPhysical.Name = "txtPhysical";
            this.txtPhysical.Size = new System.Drawing.Size(126, 194);
            this.txtPhysical.TabIndex = 2;
            this.txtPhysical.Text = "";
            this.txtPhysical.TextChanged += new System.EventHandler(this.txtPhysical_TextChanged);
            // 
            // lblNumPhysical
            // 
            this.lblNumPhysical.AutoSize = true;
            this.lblNumPhysical.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumPhysical.Location = new System.Drawing.Point(27, 220);
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
            this.groupBox3.Location = new System.Drawing.Point(423, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(131, 245);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input Name Item";
            // 
            // txtNameItem
            // 
            this.txtNameItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNameItem.Location = new System.Drawing.Point(3, 19);
            this.txtNameItem.Name = "txtNameItem";
            this.txtNameItem.Size = new System.Drawing.Size(125, 194);
            this.txtNameItem.TabIndex = 4;
            this.txtNameItem.Text = "";
            this.txtNameItem.TextChanged += new System.EventHandler(this.txtItemName_TextChanged);
            // 
            // lblNumNameItem
            // 
            this.lblNumNameItem.AutoSize = true;
            this.lblNumNameItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumNameItem.Location = new System.Drawing.Point(27, 220);
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
            this.groupBox5.Location = new System.Drawing.Point(560, 44);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 245);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Validation";
            // 
            // txtValidation
            // 
            this.txtValidation.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtValidation.Location = new System.Drawing.Point(3, 19);
            this.txtValidation.Name = "txtValidation";
            this.txtValidation.Size = new System.Drawing.Size(125, 194);
            this.txtValidation.TabIndex = 5;
            this.txtValidation.Text = "";
            this.txtValidation.TextChanged += new System.EventHandler(this.txtValidation_TextChanged);
            // 
            // lblNumValidation
            // 
            this.lblNumValidation.AutoSize = true;
            this.lblNumValidation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumValidation.Location = new System.Drawing.Point(27, 220);
            this.lblNumValidation.Name = "lblNumValidation";
            this.lblNumValidation.Size = new System.Drawing.Size(80, 15);
            this.lblNumValidation.TabIndex = 0;
            this.lblNumValidation.Text = "Line number:";
            this.lblNumValidation.Visible = false;
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.lblLanguage);
            this.groupBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox23.Location = new System.Drawing.Point(9, 1);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(132, 46);
            this.groupBox23.TabIndex = 0;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Language";
            // 
            // lblLanguage
            // 
            this.lblLanguage.AutoSize = true;
            this.lblLanguage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblLanguage.Location = new System.Drawing.Point(6, 21);
            this.lblLanguage.Name = "lblLanguage";
            this.lblLanguage.Size = new System.Drawing.Size(0, 15);
            this.lblLanguage.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.txtLogicNameVM);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.txtPhysicalNameVM);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(147, 1);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(545, 46);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "View Model Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label6.Location = new System.Drawing.Point(282, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Physical Name";
            // 
            // txtLogicNameVM
            // 
            this.txtLogicNameVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtLogicNameVM.Location = new System.Drawing.Point(95, 18);
            this.txtLogicNameVM.Name = "txtLogicNameVM";
            this.txtLogicNameVM.Size = new System.Drawing.Size(172, 21);
            this.txtLogicNameVM.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Logical Name";
            // 
            // txtPhysicalNameVM
            // 
            this.txtPhysicalNameVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPhysicalNameVM.Location = new System.Drawing.Point(376, 16);
            this.txtPhysicalNameVM.Name = "txtPhysicalNameVM";
            this.txtPhysicalNameVM.Size = new System.Drawing.Size(162, 21);
            this.txtPhysicalNameVM.TabIndex = 2;
            this.txtPhysicalNameVM.TextChanged += new System.EventHandler(this.txtPhysicalNameVM_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblResult);
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
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(543, 53);
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
            this.btnCreate.Location = new System.Drawing.Point(539, 19);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(68, 24);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Create";
            this.btnCreate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreateMess_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(613, 19);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 24);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnMessCopy_Click);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(647, 19);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 24);
            this.btnClear.TabIndex = 9;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnMessClear_Click);
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
            // FormCreateViewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.groupBox10);
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
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
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
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLogicNameVM;
        private System.Windows.Forms.TextBox txtPhysicalNameVM;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Label lblLanguage;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblResult;
    }
}