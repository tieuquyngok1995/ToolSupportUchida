
namespace ToolSupportCoding.View
{
    partial class FormCreateHTML
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
            this.txtRowCol = new System.Windows.Forms.RichTextBox();
            this.lblNumRowCol = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtControl = new System.Windows.Forms.RichTextBox();
            this.lblNumControl = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lblNumModel = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.groupBox23 = new System.Windows.Forms.GroupBox();
            this.rbModeHTML = new System.Windows.Forms.RadioButton();
            this.rbModeTable = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtResource = new System.Windows.Forms.RichTextBox();
            this.lblNumResource = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox23.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRowCol);
            this.groupBox4.Controls.Add(this.lblNumRowCol);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 47);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(132, 315);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Row Column";
            // 
            // txtRowCol
            // 
            this.txtRowCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRowCol.Location = new System.Drawing.Point(3, 19);
            this.txtRowCol.Name = "txtRowCol";
            this.txtRowCol.Size = new System.Drawing.Size(126, 264);
            this.txtRowCol.TabIndex = 2;
            this.txtRowCol.Text = "";
            this.txtRowCol.Click += new System.EventHandler(this.txtRowCol_Click);
            this.txtRowCol.TextChanged += new System.EventHandler(this.txtRowCol_TextChanged);
            // 
            // lblNumRowCol
            // 
            this.lblNumRowCol.AutoSize = true;
            this.lblNumRowCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumRowCol.Location = new System.Drawing.Point(27, 290);
            this.lblNumRowCol.Name = "lblNumRowCol";
            this.lblNumRowCol.Size = new System.Drawing.Size(80, 15);
            this.lblNumRowCol.TabIndex = 8;
            this.lblNumRowCol.Text = "Line number:";
            this.lblNumRowCol.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtControl);
            this.groupBox5.Controls.Add(this.lblNumControl);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(147, 47);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(132, 315);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Control";
            // 
            // txtControl
            // 
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtControl.Location = new System.Drawing.Point(3, 19);
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(126, 264);
            this.txtControl.TabIndex = 0;
            this.txtControl.Text = "";
            this.txtControl.Click += new System.EventHandler(this.txtControl_Click);
            this.txtControl.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblNumControl
            // 
            this.lblNumControl.AutoSize = true;
            this.lblNumControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumControl.Location = new System.Drawing.Point(27, 290);
            this.lblNumControl.Name = "lblNumControl";
            this.lblNumControl.Size = new System.Drawing.Size(80, 15);
            this.lblNumControl.TabIndex = 9;
            this.lblNumControl.Text = "Line number:";
            this.lblNumControl.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblNumModel);
            this.groupBox6.Controls.Add(this.txtModel);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(423, 47);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(131, 315);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Model Property";
            // 
            // lblNumModel
            // 
            this.lblNumModel.AutoSize = true;
            this.lblNumModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumModel.Location = new System.Drawing.Point(27, 290);
            this.lblNumModel.Name = "lblNumModel";
            this.lblNumModel.Size = new System.Drawing.Size(80, 15);
            this.lblNumModel.TabIndex = 10;
            this.lblNumModel.Text = "Line number:";
            this.lblNumModel.Visible = false;
            // 
            // txtModel
            // 
            this.txtModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtModel.Location = new System.Drawing.Point(3, 19);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(125, 264);
            this.txtModel.TabIndex = 0;
            this.txtModel.Text = "";
            this.txtModel.Click += new System.EventHandler(this.txtModel_Click);
            this.txtModel.TextChanged += new System.EventHandler(this.txtModel_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCreate);
            this.groupBox7.Controls.Add(this.btnCopy);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(560, 47);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(131, 315);
            this.groupBox7.TabIndex = 8;
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
            this.btnCreate.Location = new System.Drawing.Point(4, 286);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(61, 24);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "  Gen";
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
            this.btnCopy.Location = new System.Drawing.Point(68, 286);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(28, 24);
            this.btnCopy.TabIndex = 11;
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
            this.btnClear.Location = new System.Drawing.Point(99, 286);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 24);
            this.btnClear.TabIndex = 12;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(125, 264);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // groupBox23
            // 
            this.groupBox23.Controls.Add(this.rbModeHTML);
            this.groupBox23.Controls.Add(this.rbModeTable);
            this.groupBox23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox23.Location = new System.Drawing.Point(9, 1);
            this.groupBox23.Name = "groupBox23";
            this.groupBox23.Size = new System.Drawing.Size(166, 49);
            this.groupBox23.TabIndex = 9;
            this.groupBox23.TabStop = false;
            this.groupBox23.Text = "Mode Generate";
            // 
            // rbModeHTML
            // 
            this.rbModeHTML.AutoSize = true;
            this.rbModeHTML.Checked = true;
            this.rbModeHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeHTML.Location = new System.Drawing.Point(10, 20);
            this.rbModeHTML.Name = "rbModeHTML";
            this.rbModeHTML.Size = new System.Drawing.Size(59, 19);
            this.rbModeHTML.TabIndex = 100;
            this.rbModeHTML.TabStop = true;
            this.rbModeHTML.Text = "HTML";
            this.rbModeHTML.UseVisualStyleBackColor = true;
            // 
            // rbModeTable
            // 
            this.rbModeTable.AutoSize = true;
            this.rbModeTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModeTable.Location = new System.Drawing.Point(77, 20);
            this.rbModeTable.Name = "rbModeTable";
            this.rbModeTable.Size = new System.Drawing.Size(56, 19);
            this.rbModeTable.TabIndex = 101;
            this.rbModeTable.Text = "Table";
            this.rbModeTable.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResource);
            this.groupBox1.Controls.Add(this.lblNumResource);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(285, 47);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(132, 315);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Item Resouce";
            // 
            // txtResource
            // 
            this.txtResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResource.Location = new System.Drawing.Point(3, 19);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(126, 264);
            this.txtResource.TabIndex = 0;
            this.txtResource.Text = "";
            this.txtResource.Click += new System.EventHandler(this.txtResource_Click);
            this.txtResource.TextChanged += new System.EventHandler(this.txtResource_TextChanged);
            // 
            // lblNumResource
            // 
            this.lblNumResource.AutoSize = true;
            this.lblNumResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumResource.Location = new System.Drawing.Point(27, 290);
            this.lblNumResource.Name = "lblNumResource";
            this.lblNumResource.Size = new System.Drawing.Size(80, 15);
            this.lblNumResource.TabIndex = 9;
            this.lblNumResource.Text = "Line number:";
            this.lblNumResource.Visible = false;
            // 
            // FormCreateHTML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox23);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Name = "FormCreateHTML";
            this.Text = "Tool Support: Create HTML";
            this.Load += new System.EventHandler(this.FormCreateAdapter_Load);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox23.ResumeLayout(false);
            this.groupBox23.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox txtRowCol;
        private System.Windows.Forms.Label lblNumRowCol;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RichTextBox txtControl;
        private System.Windows.Forms.Label lblNumControl;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label lblNumModel;
        private System.Windows.Forms.RichTextBox txtModel;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox23;
        private System.Windows.Forms.RadioButton rbModeHTML;
        private System.Windows.Forms.RadioButton rbModeTable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox txtResource;
        private System.Windows.Forms.Label lblNumResource;
    }
}