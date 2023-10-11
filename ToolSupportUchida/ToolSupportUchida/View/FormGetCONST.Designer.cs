
namespace ToolSupportCoding.View
{
    partial class FormGetCONST
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
            this.rdbUpperCase = new System.Windows.Forms.RadioButton();
            this.rdbLowerCase = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLogicName);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 361);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Logical Name";
            // 
            // txtLogicName
            // 
            this.txtLogicName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogicName.Location = new System.Drawing.Point(3, 19);
            this.txtLogicName.Name = "txtLogicName";
            this.txtLogicName.Size = new System.Drawing.Size(273, 339);
            this.txtLogicName.TabIndex = 1;
            this.txtLogicName.Text = "";
            this.txtLogicName.Click += new System.EventHandler(this.txtLogicName_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtPhysiName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(416, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 361);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Physical Name";
            // 
            // txtPhysiName
            // 
            this.txtPhysiName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhysiName.Location = new System.Drawing.Point(3, 19);
            this.txtPhysiName.Name = "txtPhysiName";
            this.txtPhysiName.Size = new System.Drawing.Size(269, 339);
            this.txtPhysiName.TabIndex = 1;
            this.txtPhysiName.Text = "";
            this.txtPhysiName.Click += new System.EventHandler(this.txtPhysiName_Click);
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(2, 138);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(104, 33);
            this.lblResult.TabIndex = 5;
            this.lblResult.Text = "Copy to Clipboard is done!";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblResult.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(41, 73);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 28);
            this.btnClear.TabIndex = 6;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Enabled = false;
            this.btnCopy.FlatAppearance.BorderSize = 0;
            this.btnCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnCopy.Image = global::ToolSupportCoding.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(6, 107);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(97, 24);
            this.btnCopy.TabIndex = 4;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnConvertLogic
            // 
            this.btnConvertLogic.FlatAppearance.BorderSize = 0;
            this.btnConvertLogic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertLogic.Image = global::ToolSupportCoding.Properties.Resources.button_left;
            this.btnConvertLogic.Location = new System.Drawing.Point(7, 73);
            this.btnConvertLogic.Name = "btnConvertLogic";
            this.btnConvertLogic.Size = new System.Drawing.Size(28, 28);
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
            this.btnConvertPhysi.Image = global::ToolSupportCoding.Properties.Resources.button_right;
            this.btnConvertPhysi.Location = new System.Drawing.Point(75, 73);
            this.btnConvertPhysi.Name = "btnConvertPhysi";
            this.btnConvertPhysi.Size = new System.Drawing.Size(28, 28);
            this.btnConvertPhysi.TabIndex = 3;
            this.btnConvertPhysi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertPhysi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertPhysi.UseVisualStyleBackColor = true;
            this.btnConvertPhysi.Click += new System.EventHandler(this.btnConvertPhysi_Click);
            // 
            // rdbUpperCase
            // 
            this.rdbUpperCase.AutoSize = true;
            this.rdbUpperCase.Checked = true;
            this.rdbUpperCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rdbUpperCase.Location = new System.Drawing.Point(10, 23);
            this.rdbUpperCase.Name = "rdbUpperCase";
            this.rdbUpperCase.Size = new System.Drawing.Size(90, 19);
            this.rdbUpperCase.TabIndex = 7;
            this.rdbUpperCase.TabStop = true;
            this.rdbUpperCase.Text = "Upper Case";
            this.rdbUpperCase.UseVisualStyleBackColor = true;
            // 
            // rdbLowerCase
            // 
            this.rdbLowerCase.AutoSize = true;
            this.rdbLowerCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.rdbLowerCase.Location = new System.Drawing.Point(10, 48);
            this.rdbLowerCase.Name = "rdbLowerCase";
            this.rdbLowerCase.Size = new System.Drawing.Size(90, 19);
            this.rdbLowerCase.TabIndex = 8;
            this.rdbLowerCase.TabStop = true;
            this.rdbLowerCase.Text = "Lower Case";
            this.rdbLowerCase.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbUpperCase);
            this.groupBox3.Controls.Add(this.btnClear);
            this.groupBox3.Controls.Add(this.btnCopy);
            this.groupBox3.Controls.Add(this.rdbLowerCase);
            this.groupBox3.Controls.Add(this.btnConvertPhysi);
            this.groupBox3.Controls.Add(this.btnConvertLogic);
            this.groupBox3.Controls.Add(this.lblResult);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox3.Location = new System.Drawing.Point(297, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(110, 361);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Setting";
            // 
            // FormGetCONST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormGetCONST";
            this.Text = "Tool Support: Get CONST";
            this.Load += new System.EventHandler(this.FormConvertSekkei_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConvertPhysi;
        private System.Windows.Forms.Button btnConvertLogic;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdbUpperCase;
        private System.Windows.Forms.RadioButton rdbLowerCase;
        private System.Windows.Forms.RichTextBox txtLogicName;
        private System.Windows.Forms.RichTextBox txtPhysiName;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}