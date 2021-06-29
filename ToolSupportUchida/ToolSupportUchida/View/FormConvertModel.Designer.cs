
namespace ToolSupportUchida.View
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
            this.rdbJS = new System.Windows.Forms.RadioButton();
            this.rdbC = new System.Windows.Forms.RadioButton();
            this.rdbHTML = new System.Windows.Forms.RadioButton();
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
            this.txtLogic = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtPhysi = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtResult = new System.Windows.Forms.TextBox();
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
            this.panelLanguage.Location = new System.Drawing.Point(9, 3);
            this.panelLanguage.Name = "panelLanguage";
            this.panelLanguage.Size = new System.Drawing.Size(165, 50);
            this.panelLanguage.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbJS);
            this.groupBox1.Controls.Add(this.rdbC);
            this.groupBox1.Controls.Add(this.rdbHTML);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 50);
            this.groupBox1.TabIndex = 99;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Language";
            // 
            // rdbJS
            // 
            this.rdbJS.AutoSize = true;
            this.rdbJS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbJS.Location = new System.Drawing.Point(50, 22);
            this.rdbJS.Name = "rdbJS";
            this.rdbJS.Size = new System.Drawing.Size(39, 19);
            this.rdbJS.TabIndex = 99;
            this.rdbJS.Text = "JS";
            this.rdbJS.UseVisualStyleBackColor = true;
            this.rdbJS.CheckedChanged += new System.EventHandler(this.rdbJS_CheckedChanged);
            // 
            // rdbC
            // 
            this.rdbC.AutoSize = true;
            this.rdbC.Checked = true;
            this.rdbC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbC.Location = new System.Drawing.Point(6, 22);
            this.rdbC.Name = "rdbC";
            this.rdbC.Size = new System.Drawing.Size(40, 19);
            this.rdbC.TabIndex = 99;
            this.rdbC.TabStop = true;
            this.rdbC.Text = "C#";
            this.rdbC.UseVisualStyleBackColor = true;
            this.rdbC.CheckedChanged += new System.EventHandler(this.rdbC_CheckedChanged);
            // 
            // rdbHTML
            // 
            this.rdbHTML.AutoSize = true;
            this.rdbHTML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHTML.Location = new System.Drawing.Point(95, 22);
            this.rdbHTML.Name = "rdbHTML";
            this.rdbHTML.Size = new System.Drawing.Size(59, 19);
            this.rdbHTML.TabIndex = 99;
            this.rdbHTML.Text = "HTML";
            this.rdbHTML.UseVisualStyleBackColor = true;
            this.rdbHTML.CheckedChanged += new System.EventHandler(this.rdbHTML_CheckedChanged);
            // 
            // panelComment
            // 
            this.panelComment.Controls.Add(this.groupBox2);
            this.panelComment.Location = new System.Drawing.Point(181, 3);
            this.panelComment.Name = "panelComment";
            this.panelComment.Size = new System.Drawing.Size(192, 50);
            this.panelComment.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbBlock);
            this.groupBox2.Controls.Add(this.rdbLineBlock);
            this.groupBox2.Controls.Add(this.rdbLine);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(192, 50);
            this.groupBox2.TabIndex = 99;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Comment Mode";
            // 
            // rdbBlock
            // 
            this.rdbBlock.AutoSize = true;
            this.rdbBlock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbBlock.Location = new System.Drawing.Point(87, 22);
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
            this.rdbLineBlock.Location = new System.Drawing.Point(6, 22);
            this.rdbLineBlock.Name = "rdbLineBlock";
            this.rdbLineBlock.Size = new System.Drawing.Size(82, 19);
            this.rdbLineBlock.TabIndex = 10;
            this.rdbLineBlock.TabStop = true;
            this.rdbLineBlock.Text = "Line Block";
            this.rdbLineBlock.UseVisualStyleBackColor = true;
            this.rdbLineBlock.CheckedChanged += new System.EventHandler(this.rdbLineBlock_CheckedChanged);
            // 
            // rdbLine
            // 
            this.rdbLine.AutoSize = true;
            this.rdbLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLine.Location = new System.Drawing.Point(142, 22);
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
            this.panelFormat.Location = new System.Drawing.Point(380, 3);
            this.panelFormat.Name = "panelFormat";
            this.panelFormat.Size = new System.Drawing.Size(136, 50);
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
            this.groupBox3.Size = new System.Drawing.Size(136, 50);
            this.groupBox3.TabIndex = 99;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Format Case";
            // 
            // rdbUpperCase
            // 
            this.rdbUpperCase.AutoSize = true;
            this.rdbUpperCase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbUpperCase.Location = new System.Drawing.Point(65, 22);
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
            this.rdbLowerCase.Location = new System.Drawing.Point(6, 22);
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
            this.groupBox4.Controls.Add(this.txtLogic);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 52);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(165, 300);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Logical Name";
            // 
            // txtLogic
            // 
            this.txtLogic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogic.Location = new System.Drawing.Point(3, 19);
            this.txtLogic.Multiline = true;
            this.txtLogic.Name = "txtLogic";
            this.txtLogic.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogic.Size = new System.Drawing.Size(159, 278);
            this.txtLogic.TabIndex = 1;
            this.txtLogic.TextChanged += new System.EventHandler(this.txtLogic_TextChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtPhysi);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(181, 52);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(165, 300);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Physical Name";
            // 
            // txtPhysi
            // 
            this.txtPhysi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhysi.Location = new System.Drawing.Point(3, 19);
            this.txtPhysi.Multiline = true;
            this.txtPhysi.Name = "txtPhysi";
            this.txtPhysi.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtPhysi.Size = new System.Drawing.Size(159, 278);
            this.txtPhysi.TabIndex = 2;
            this.txtPhysi.TextChanged += new System.EventHandler(this.txtPhysi_TextChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtType);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(353, 52);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(165, 300);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Type";
            // 
            // txtType
            // 
            this.txtType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtType.Location = new System.Drawing.Point(3, 19);
            this.txtType.Multiline = true;
            this.txtType.Name = "txtType";
            this.txtType.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtType.Size = new System.Drawing.Size(159, 278);
            this.txtType.TabIndex = 3;
            this.txtType.TextChanged += new System.EventHandler(this.txtType_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(525, 52);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(165, 300);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Result";
            // 
            // txtResult
            // 
            this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResult.Enabled = false;
            this.txtResult.Location = new System.Drawing.Point(3, 19);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(159, 278);
            this.txtResult.TabIndex = 3;
            this.txtResult.TabStop = false;
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(547, 385);
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
            this.btnCopy.Image = global::ToolSupportUchida.Properties.Resources.button_copy_clipboar;
            this.btnCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCopy.Location = new System.Drawing.Point(529, 356);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 28);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Text = "  Copy";
            this.btnCopy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // lblNumLogic
            // 
            this.lblNumLogic.AutoSize = true;
            this.lblNumLogic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumLogic.Location = new System.Drawing.Point(44, 380);
            this.lblNumLogic.Name = "lblNumLogic";
            this.lblNumLogic.Size = new System.Drawing.Size(91, 17);
            this.lblNumLogic.TabIndex = 8;
            this.lblNumLogic.Text = "Line number:";
            this.lblNumLogic.Visible = false;
            // 
            // lblNumPhysi
            // 
            this.lblNumPhysi.AutoSize = true;
            this.lblNumPhysi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumPhysi.Location = new System.Drawing.Point(216, 380);
            this.lblNumPhysi.Name = "lblNumPhysi";
            this.lblNumPhysi.Size = new System.Drawing.Size(91, 17);
            this.lblNumPhysi.TabIndex = 9;
            this.lblNumPhysi.Text = "Line number:";
            this.lblNumPhysi.Visible = false;
            // 
            // lblNumType
            // 
            this.lblNumType.AutoSize = true;
            this.lblNumType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumType.Location = new System.Drawing.Point(387, 380);
            this.lblNumType.Name = "lblNumType";
            this.lblNumType.Size = new System.Drawing.Size(91, 17);
            this.lblNumType.TabIndex = 10;
            this.lblNumType.Text = "Line number:";
            this.lblNumType.Visible = false;
            // 
            // txtAddLogic
            // 
            this.txtAddLogic.Location = new System.Drawing.Point(12, 357);
            this.txtAddLogic.Name = "txtAddLogic";
            this.txtAddLogic.Size = new System.Drawing.Size(159, 20);
            this.txtAddLogic.TabIndex = 4;
            this.txtAddLogic.Visible = false;
            this.txtAddLogic.TextChanged += new System.EventHandler(this.txtAddLogic_TextChanged);
            // 
            // txtAddPhysi
            // 
            this.txtAddPhysi.Location = new System.Drawing.Point(184, 357);
            this.txtAddPhysi.Name = "txtAddPhysi";
            this.txtAddPhysi.Size = new System.Drawing.Size(159, 20);
            this.txtAddPhysi.TabIndex = 5;
            this.txtAddPhysi.Visible = false;
            this.txtAddPhysi.TextChanged += new System.EventHandler(this.txtAddPhysi_TextChanged);
            // 
            // panelType
            // 
            this.panelType.Controls.Add(this.groupBox8);
            this.panelType.Location = new System.Drawing.Point(523, 3);
            this.panelType.Name = "panelType";
            this.panelType.Size = new System.Drawing.Size(167, 50);
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
            this.groupBox8.Size = new System.Drawing.Size(167, 50);
            this.groupBox8.TabIndex = 99;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Type";
            // 
            // rdbTypeScript
            // 
            this.rdbTypeScript.AutoSize = true;
            this.rdbTypeScript.Checked = true;
            this.rdbTypeScript.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbTypeScript.Location = new System.Drawing.Point(6, 22);
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
            this.rdbObservable.Location = new System.Drawing.Point(46, 22);
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
            this.rdbSetParam.Location = new System.Drawing.Point(93, 22);
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
            this.btnClear.Image = global::ToolSupportUchida.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(638, 357);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(28, 28);
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
            this.rdbFirst.Location = new System.Drawing.Point(356, 358);
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
            this.rdbLast.Location = new System.Drawing.Point(436, 358);
            this.rdbLast.Name = "rdbLast";
            this.rdbLast.Size = new System.Drawing.Size(69, 19);
            this.rdbLast.TabIndex = 7;
            this.rdbLast.Text = "Set Last";
            this.rdbLast.UseVisualStyleBackColor = true;
            this.rdbLast.Visible = false;
            this.rdbLast.CheckedChanged += new System.EventHandler(this.rdbLast_CheckedChanged);
            // 
            // FormConvertModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 421);
            this.Controls.Add(this.rdbLast);
            this.Controls.Add(this.rdbFirst);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.panelType);
            this.Controls.Add(this.txtAddPhysi);
            this.Controls.Add(this.txtAddLogic);
            this.Controls.Add(this.lblNumType);
            this.Controls.Add(this.lblNumPhysi);
            this.Controls.Add(this.lblNumLogic);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.panelFormat);
            this.Controls.Add(this.panelComment);
            this.Controls.Add(this.panelLanguage);
            this.Controls.Add(this.lblResult);
            this.Name = "FormConvertModel";
            this.Text = "FormConvertModel";
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
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelLanguage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbJS;
        private System.Windows.Forms.RadioButton rdbC;
        private System.Windows.Forms.RadioButton rdbHTML;
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
        private System.Windows.Forms.TextBox txtLogic;
        private System.Windows.Forms.TextBox txtPhysi;
        private System.Windows.Forms.TextBox txtType;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.RadioButton rdbFirst;
        private System.Windows.Forms.RadioButton rdbLast;
    }
}