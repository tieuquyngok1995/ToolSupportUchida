﻿
namespace ToolSupportUchida.View
{
    partial class FormConvertSekkei
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLogicName = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPhysiName = new System.Windows.Forms.RichTextBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnConvertLogic = new System.Windows.Forms.Button();
            this.btnConvertPhysi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogicName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 390);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Logical Name";
            // 
            // txtLogicName
            // 
            this.txtLogicName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogicName.Location = new System.Drawing.Point(6, 22);
            this.txtLogicName.Name = "txtLogicName";
            this.txtLogicName.Size = new System.Drawing.Size(258, 362);
            this.txtLogicName.TabIndex = 0;
            this.txtLogicName.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPhysiName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(422, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(270, 390);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Physical Name";
            // 
            // txtPhysiName
            // 
            this.txtPhysiName.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysiName.Location = new System.Drawing.Point(6, 22);
            this.txtPhysiName.Name = "txtPhysiName";
            this.txtPhysiName.Size = new System.Drawing.Size(258, 362);
            this.txtPhysiName.TabIndex = 1;
            this.txtPhysiName.Text = "";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(288, 251);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(130, 13);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportUchida.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(334, 182);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(32, 32);
            this.btnClear.TabIndex = 6;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Image = global::ToolSupportUchida.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(285, 220);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(131, 28);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "Copy to Clipboard";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnConvertLogic
            // 
            this.btnConvertLogic.FlatAppearance.BorderSize = 0;
            this.btnConvertLogic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertLogic.Image = global::ToolSupportUchida.Properties.Resources.button_left;
            this.btnConvertLogic.Location = new System.Drawing.Point(285, 182);
            this.btnConvertLogic.Name = "btnConvertLogic";
            this.btnConvertLogic.Size = new System.Drawing.Size(32, 32);
            this.btnConvertLogic.TabIndex = 2;
            this.btnConvertLogic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertLogic.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertLogic.UseVisualStyleBackColor = true;
            this.btnConvertLogic.Click += new System.EventHandler(this.btnConvertLogic_Click);
            // 
            // btnConvertPhysi
            // 
            this.btnConvertPhysi.FlatAppearance.BorderSize = 0;
            this.btnConvertPhysi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertPhysi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertPhysi.Image = global::ToolSupportUchida.Properties.Resources.button_right;
            this.btnConvertPhysi.Location = new System.Drawing.Point(383, 182);
            this.btnConvertPhysi.Name = "btnConvertPhysi";
            this.btnConvertPhysi.Size = new System.Drawing.Size(32, 32);
            this.btnConvertPhysi.TabIndex = 3;
            this.btnConvertPhysi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertPhysi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertPhysi.UseVisualStyleBackColor = true;
            this.btnConvertPhysi.Click += new System.EventHandler(this.btnConvertPhysi_Click);
            // 
            // FormConvertSekkei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnConvertLogic);
            this.Controls.Add(this.btnConvertPhysi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormConvertSekkei";
            this.Text = "ConvertSekkei";
            this.Load += new System.EventHandler(this.FormConvertSekkei_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox txtLogicName;
        private System.Windows.Forms.RichTextBox txtPhysiName;
        private System.Windows.Forms.Button btnConvertPhysi;
        private System.Windows.Forms.Button btnConvertLogic;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
    }
}