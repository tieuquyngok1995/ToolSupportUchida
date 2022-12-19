
namespace ToolSupportCoding.View
{
    partial class FormConvertModel
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
            this.panelLanguage = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLanguage = new System.Windows.Forms.Label();
            this.panelComment = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbBlock = new System.Windows.Forms.RadioButton();
            this.rdbLineBlock = new System.Windows.Forms.RadioButton();
            this.rdbLine = new System.Windows.Forms.RadioButton();
            this.panelFormat = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rdbUpperCase = new System.Windows.Forms.RadioButton();
            this.rdbLowerCase = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.lblNumLogic = new System.Windows.Forms.Label();
            this.lblNumPhysi = new System.Windows.Forms.Label();
            this.lblNumType = new System.Windows.Forms.Label();
            this.txtAddLogic = new System.Windows.Forms.TextBox();
            this.txtAddPhysi = new System.Windows.Forms.TextBox();
            this.panelType = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.rdbTypeScript = new System.Windows.Forms.RadioButton();
            this.rdbObservable = new System.Windows.Forms.RadioButton();
            this.rdbSetParam = new System.Windows.Forms.RadioButton();
            this.btnClear = new System.Windows.Forms.Button();
            this.rdbFirst = new System.Windows.Forms.RadioButton();
            this.rdbLast = new System.Windows.Forms.RadioButton();
            this.chkCreateInterf = new System.Windows.Forms.CheckBox();
            this.chkIsTable = new System.Windows.Forms.CheckBox();
            this.txtLogic = new System.Windows.Forms.RichTextBox();
            this.txtPhysi = new System.Windows.Forms.RichTextBox();
            this.txtType = new System.Windows.Forms.RichTextBox();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.panelLanguage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelComment.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panelFormat.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panelType.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLanguage
            // 
            this.panelLanguage.Controls.Add(this.groupBox1);
            this.panelLanguage.Location = new System.Drawing.Point(9, 1);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(166, 46);
            this.panelLanguage.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbLanguage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 46);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // lbLanguage
            // 
            this.lbLanguage.AutoSize = true;
            this.lbLanguage.Location = new System.Drawing.Point(6, 20);
            this.lbLanguage.Name = "lbLanguage";
            this.lbLanguage.Size = new System.Drawing.Size(0, 17);
            this.lbLanguage.TabIndex = 100;
            // 
            // panelComment
            // 
            this.panelComment.Controls.Add(this.groupBox2);
            this.panelComment.Location = new System.Drawing.Point(181, 1);
            this.panelComment.Name = "panelComment";
            this.panelComment.Size = new System.Drawing.Size(166, 46);
            this.panelComment.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbLine);
            this.groupBox2.Controls.Add(this.rdbBlock);
            this.groupBox2.Controls.Add(this.rdbLineBlock);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 46);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comment Mode";
            // 
            // rdbBlock
            // 
            this.rdbBlock.AutoSize = true;
            this.rdbBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBlock.Location = new System.Drawing.Point(64, 20);
            this.rdbBlock.Name = "rdbBlock";
            this.rdbBlock.Size = new System.Drawing.Size(55, 19);
            this.rdbBlock.TabIndex = 11;
            this.rdbBlock.Text = "Block";
            this.rdbBlock.UseVisualStyleBackColor = true;
            this.rdbBlock.CheckedChanged += new System.EventHandler(this.rdbBlock_CheckedChanged);
            // 
            // rdbLineBlock
            // 
            this.rdbLineBlock.AutoSize = true;
            this.rdbLineBlock.Checked = true;
            this.rdbLineBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLineBlock.Location = new System.Drawing.Point(3, 20);
            this.rdbLineBlock.Name = "rdbLineBlock";
            this.rdbLineBlock.Size = new System.Drawing.Size(65, 19);
            this.rdbLineBlock.TabIndex = 10;
            this.rdbLineBlock.TabStop = true;
            this.rdbLineBlock.Text = "L Block";
            this.rdbLineBlock.UseVisualStyleBackColor = true;
            this.rdbLineBlock.CheckedChanged += new System.EventHandler(this.rdbLineBlock_CheckedChanged);
            // 
            // rdbLine
            // 
            this.rdbLine.AutoSize = true;
            this.rdbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLine.Location = new System.Drawing.Point(116, 20);
            this.rdbLine.Name = "rdbLine";
            this.rdbLine.Size = new System.Drawing.Size(49, 19);
            this.rdbLine.TabIndex = 99;
            this.rdbLine.Text = "Line";
            this.rdbLine.UseVisualStyleBackColor = true;
            this.rdbLine.CheckedChanged += new System.EventHandler(this.rdbLine_CheckedChanged);
            // 
            // panelFormat
            // 
            this.panelFormat.Controls.Add(this.groupBox3);
            this.panelFormat.Location = new System.Drawing.Point(353, 1);
            this.panelFormat.Name = "panelFormat";
            this.panelFormat.Size = new System.Drawing.Size(166, 46);
            this.panelFormat.TabIndex = 12;
            this.panelFormat.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rdbUpperCase);
            this.groupBox3.Controls.Add(this.rdbLowerCase);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(166, 46);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Format Case";
            // 
            // rdbUpperCase
            // 
            this.rdbUpperCase.AutoSize = true;
            this.rdbUpperCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUpperCase.Location = new System.Drawing.Point(82, 20);
            this.rdbUpperCase.Name = "rdbUpperCase";
            this.rdbUpperCase.Size = new System.Drawing.Size(59, 19);
            this.rdbUpperCase.TabIndex = 99;
            this.rdbUpperCase.Text = "Upper";
            this.rdbUpperCase.UseVisualStyleBackColor = true;
            this.rdbUpperCase.CheckedChanged += new System.EventHandler(this.rdbUpperCase_CheckedChanged);
            // 
            // rdbLowerCase
            // 
            this.rdbLowerCase.AutoSize = true;
            this.rdbLowerCase.Checked = true;
            this.rdbLowerCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLowerCase.Location = new System.Drawing.Point(4, 20);
            this.rdbLowerCase.Name = "rdbLowerCase";
            this.rdbLowerCase.Size = new System.Drawing.Size(59, 19);
            this.rdbLowerCase.TabIndex = 99;
            this.rdbLowerCase.TabStop = true;
            this.rdbLowerCase.Text = "Lower";
            this.rdbLowerCase.UseVisualStyleBackColor = true;
            this.rdbLowerCase.CheckedChanged += new System.EventHandler(this.rdbLowerCase_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.chkIsTable);
            this.groupBox4.Controls.Add(this.txtLogic);
            this.groupBox4.Controls.Add(this.lblNumLogic);
            this.groupBox4.Controls.Add(this.txtAddLogic);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 44);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 318);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Logical Name";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.chkCreateInterf);
            this.groupBox5.Controls.Add(this.txtAddPhysi);
            this.groupBox5.Controls.Add(this.txtPhysi);
            this.groupBox5.Controls.Add(this.lblNumPhysi);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(181, 44);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 318);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Physical Name";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblNumType);
            this.groupBox6.Controls.Add(this.rdbLast);
            this.groupBox6.Controls.Add(this.txtType);
            this.groupBox6.Controls.Add(this.rdbFirst);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(353, 44);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(166, 318);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Type";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lblResult);
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Controls.Add(this.btnCopy);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(525, 44);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(166, 318);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(36, 302);
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
            this.btnCopy.Location = new System.Drawing.Point(4, 278);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(131, 24);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "  Copy Result";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumLogic.Location = new System.Drawing.Point(61, 298);
            this.lblNumLogic.Name = "lblNumLogic";
            this.lblNumLogic.Size = new System.Drawing.Size(80, 15);
            this.lblNumLogic.TabIndex = 8;
            this.lblNumLogic.Text = "Line number:";
            this.lblNumLogic.Visible = false;
            // 
            // lblNumPhysi
            // 
            this.lblNumPhysi.AutoSize = true;
            this.lblNumPhysi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumPhysi.Location = new System.Drawing.Point(61, 298);
            this.lblNumPhysi.Name = "lblNumPhysi";
            this.lblNumPhysi.Size = new System.Drawing.Size(80, 15);
            this.lblNumPhysi.TabIndex = 9;
            this.lblNumPhysi.Text = "Line number:";
            this.lblNumPhysi.Visible = false;
            // 
            // lblNumType
            // 
            this.lblNumType.AutoSize = true;
            this.lblNumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumType.Location = new System.Drawing.Point(61, 298);
            this.lblNumType.Name = "lblNumType";
            this.lblNumType.Size = new System.Drawing.Size(80, 15);
            this.lblNumType.TabIndex = 10;
            this.lblNumType.Text = "Line number:";
            this.lblNumType.Visible = false;
            // 
            // txtAddLogic
            // 
            this.txtAddLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAddLogic.Location = new System.Drawing.Point(4, 277);
            this.txtAddLogic.Name = "txtAddLogic";
            this.txtAddLogic.Size = new System.Drawing.Size(158, 21);
            this.txtAddLogic.TabIndex = 4;
            this.txtAddLogic.Visible = false;
            this.txtAddLogic.TextChanged += new System.EventHandler(this.txtAddLogic_TextChanged);
            // 
            // txtAddPhysi
            // 
            this.txtAddPhysi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtAddPhysi.Location = new System.Drawing.Point(4, 277);
            this.txtAddPhysi.Name = "txtAddPhysi";
            this.txtAddPhysi.Size = new System.Drawing.Size(158, 21);
            this.txtAddPhysi.TabIndex = 5;
            this.txtAddPhysi.Visible = false;
            this.txtAddPhysi.TextChanged += new System.EventHandler(this.txtAddPhysi_TextChanged);
            // 
            // panelType
            // 
            this.panelType.Controls.Add(this.groupBox8);
            this.panelType.Location = new System.Drawing.Point(525, 1);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(166, 46);
            this.panelType.TabIndex = 13;
            this.panelType.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.rdbTypeScript);
            this.groupBox8.Controls.Add(this.rdbObservable);
            this.groupBox8.Controls.Add(this.rdbSetParam);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(0, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(166, 46);
            this.groupBox8.TabIndex = 99;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Type";
            // 
            // rdbTypeScript
            // 
            this.rdbTypeScript.AutoSize = true;
            this.rdbTypeScript.Checked = true;
            this.rdbTypeScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTypeScript.Location = new System.Drawing.Point(6, 20);
            this.rdbTypeScript.Name = "rdbTypeScript";
            this.rdbTypeScript.Size = new System.Drawing.Size(40, 19);
            this.rdbTypeScript.TabIndex = 99;
            this.rdbTypeScript.TabStop = true;
            this.rdbTypeScript.Text = "TS";
            this.rdbTypeScript.UseVisualStyleBackColor = true;
            this.rdbTypeScript.CheckedChanged += new System.EventHandler(this.rdbTypeScript_CheckedChanged);
            // 
            // rdbObservable
            // 
            this.rdbObservable.AutoSize = true;
            this.rdbObservable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbObservable.Location = new System.Drawing.Point(46, 20);
            this.rdbObservable.Name = "rdbObservable";
            this.rdbObservable.Size = new System.Drawing.Size(47, 19);
            this.rdbObservable.TabIndex = 99;
            this.rdbObservable.Text = "Obs";
            this.rdbObservable.UseVisualStyleBackColor = true;
            this.rdbObservable.CheckedChanged += new System.EventHandler(this.rdbObservable_CheckedChanged);
            // 
            // rdbSetParam
            // 
            this.rdbSetParam.AutoSize = true;
            this.rdbSetParam.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbSetParam.Location = new System.Drawing.Point(93, 20);
            this.rdbSetParam.Name = "rdbSetParam";
            this.rdbSetParam.Size = new System.Drawing.Size(72, 19);
            this.rdbSetParam.TabIndex = 99;
            this.rdbSetParam.Text = "Set Para";
            this.rdbSetParam.UseVisualStyleBackColor = true;
            this.rdbSetParam.CheckedChanged += new System.EventHandler(this.rdbSetParam_CheckedChanged);
            // 
            // btnClear
            // 
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportCoding.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(138, 278);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 9;
            this.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // rdbFirst
            // 
            this.rdbFirst.AutoSize = true;
            this.rdbFirst.Checked = true;
            this.rdbFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbFirst.Location = new System.Drawing.Point(4, 280);
            this.rdbFirst.Name = "rdbFirst";
            this.rdbFirst.Size = new System.Drawing.Size(69, 19);
            this.rdbFirst.TabIndex = 6;
            this.rdbFirst.TabStop = true;
            this.rdbFirst.Text = "Set First";
            this.rdbFirst.UseVisualStyleBackColor = true;
            this.rdbFirst.Visible = false;
            this.rdbFirst.CheckedChanged += new System.EventHandler(this.rdbFirst_CheckedChanged);
            // 
            // rdbLast
            // 
            this.rdbLast.AutoSize = true;
            this.rdbLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLast.Location = new System.Drawing.Point(82, 280);
            this.rdbLast.Name = "rdbLast";
            this.rdbLast.Size = new System.Drawing.Size(69, 19);
            this.rdbLast.TabIndex = 7;
            this.rdbLast.Text = "Set Last";
            this.rdbLast.UseVisualStyleBackColor = true;
            this.rdbLast.Visible = false;
            this.rdbLast.CheckedChanged += new System.EventHandler(this.rdbLast_CheckedChanged);
            // 
            // chkCreateInterf
            // 
            this.chkCreateInterf.AutoSize = true;
            this.chkCreateInterf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkCreateInterf.Location = new System.Drawing.Point(4, 278);
            this.chkCreateInterf.Name = "chkCreateInterf";
            this.chkCreateInterf.Size = new System.Drawing.Size(112, 19);
            this.chkCreateInterf.TabIndex = 14;
            this.chkCreateInterf.Text = "Create Interface";
            this.chkCreateInterf.UseVisualStyleBackColor = true;
            this.chkCreateInterf.Visible = false;
            this.chkCreateInterf.CheckedChanged += new System.EventHandler(this.chkCreateInterf_CheckedChanged);
            // 
            // chkIsTable
            // 
            this.chkIsTable.AutoSize = true;
            this.chkIsTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.chkIsTable.Location = new System.Drawing.Point(4, 278);
            this.chkIsTable.Name = "chkIsTable";
            this.chkIsTable.Size = new System.Drawing.Size(69, 19);
            this.chkIsTable.TabIndex = 15;
            this.chkIsTable.Text = "Is Table";
            this.chkIsTable.UseVisualStyleBackColor = true;
            this.chkIsTable.Visible = false;
            this.chkIsTable.CheckedChanged += new System.EventHandler(this.chkIsTable_CheckedChanged);
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.Size = new System.Drawing.Size(160, 255);
            this.txtLogic.TabIndex = 2;
            this.txtLogic.Text = "";
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            // 
            // txtPhysi
            // 
            this.txtPhysi.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtPhysi.Location = new System.Drawing.Point(3, 19);
            this.txtPhysi.Name = "txtPhysi";
            this.txtPhysi.Size = new System.Drawing.Size(160, 255);
            this.txtPhysi.TabIndex = 0;
            this.txtPhysi.Text = "";
            this.txtPhysi.TextChanged += new System.EventHandler(this.txtPhysi_TextChanged);
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtType.Location = new System.Drawing.Point(3, 19);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(160, 255);
            this.txtType.TabIndex = 0;
            this.txtType.Text = "";
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(160, 256);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // FormConvertModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 389);
            this.Controls.Add(this.panelType);
            this.Controls.Add(this.panelFormat);
            this.Controls.Add(this.panelComment);
            this.Controls.Add(this.panelLanguage);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Name = "FormConvertModel";
            this.Text = "Convert Model";
            this.Load += new System.EventHandler(this.FormConvertModel_Load);
            this.panelLanguage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelComment.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panelFormat.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panelType.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panelComment;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbBlock;
        private System.Windows.Forms.RadioButton rdbLineBlock;
        private System.Windows.Forms.RadioButton rdbLine;
        private System.Windows.Forms.Panel panelFormat;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rdbUpperCase;
        private System.Windows.Forms.RadioButton rdbLowerCase;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label lblNumLogic;
        private System.Windows.Forms.Label lblNumPhysi;
        private System.Windows.Forms.Label lblNumType;
        private System.Windows.Forms.TextBox txtAddLogic;
        private System.Windows.Forms.TextBox txtAddPhysi;
        private System.Windows.Forms.Panel panelType;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton rdbObservable;
        private System.Windows.Forms.RadioButton rdbSetParam;
        private System.Windows.Forms.RadioButton rdbTypeScript;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.RadioButton rdbFirst;
        private System.Windows.Forms.RadioButton rdbLast;
        private System.Windows.Forms.CheckBox chkCreateInterf;
        private System.Windows.Forms.Label lbLanguage;
        private System.Windows.Forms.CheckBox chkIsTable;
        private System.Windows.Forms.RichTextBox txtLogic;
        private System.Windows.Forms.RichTextBox txtPhysi;
        private System.Windows.Forms.RichTextBox txtType;
        private System.Windows.Forms.RichTextBox txtResult;
    }
}