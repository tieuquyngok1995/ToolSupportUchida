﻿
namespace ToolSupportUchida
{
    partial class Main
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelSettingRight = new System.Windows.Forms.Panel();
            this.panelSettingLeft = new System.Windows.Forms.Panel();
            this.gridSekkei = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLogic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPhysi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelSettingTop = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPhysiName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLogicName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.colEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.colDelete = new System.Windows.Forms.DataGridViewImageColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearchSekkei = new System.Windows.Forms.Button();
            this.btnAddSekkei = new System.Windows.Forms.Button();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.btnCreateAdapter = new System.Windows.Forms.Button();
            this.btnConvertModel = new System.Windows.Forms.Button();
            this.btnConverSekkei = new System.Windows.Forms.Button();
            this.btnConvertDatabase = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.panelSettingLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSekkei)).BeginInit();
            this.panelSettingTop.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnCheckData);
            this.panelMenu.Controls.Add(this.btnCreateAdapter);
            this.panelMenu.Controls.Add(this.btnConvertModel);
            this.panelMenu.Controls.Add(this.btnConverSekkei);
            this.panelMenu.Controls.Add(this.btnConvertDatabase);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 484);
            this.panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 64);
            this.panelLogo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(66, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tool Support";
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelTitleBar.Controls.Add(this.btnMinimize);
            this.panelTitleBar.Controls.Add(this.btnClose);
            this.panelTitleBar.Controls.Add(this.btnCloseChildForm);
            this.panelTitleBar.Controls.Add(this.lblTitle);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(700, 64);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Ancuu", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(637, 3);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(30, 30);
            this.btnMinimize.TabIndex = 3;
            this.btnMinimize.TabStop = false;
            this.btnMinimize.Text = "O";
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Ancuu", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(667, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(30, 30);
            this.btnClose.TabIndex = 2;
            this.btnClose.TabStop = false;
            this.btnClose.Text = "O";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(310, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Setting";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.panelSettingRight);
            this.panelDesktopPane.Controls.Add(this.panelSettingLeft);
            this.panelDesktopPane.Controls.Add(this.panelSettingTop);
            this.panelDesktopPane.Controls.Add(this.panelFooter);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 64);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(700, 420);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // panelSettingRight
            // 
            this.panelSettingRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSettingRight.Location = new System.Drawing.Point(305, 80);
            this.panelSettingRight.Name = "panelSettingRight";
            this.panelSettingRight.Size = new System.Drawing.Size(395, 320);
            this.panelSettingRight.TabIndex = 3;
            // 
            // panelSettingLeft
            // 
            this.panelSettingLeft.Controls.Add(this.gridSekkei);
            this.panelSettingLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSettingLeft.Location = new System.Drawing.Point(0, 80);
            this.panelSettingLeft.Name = "panelSettingLeft";
            this.panelSettingLeft.Size = new System.Drawing.Size(305, 320);
            this.panelSettingLeft.TabIndex = 2;
            // 
            // gridSekkei
            // 
            this.gridSekkei.AllowUserToAddRows = false;
            this.gridSekkei.AllowUserToDeleteRows = false;
            this.gridSekkei.AllowUserToResizeColumns = false;
            this.gridSekkei.AllowUserToResizeRows = false;
            this.gridSekkei.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridSekkei.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridSekkei.CausesValidation = false;
            this.gridSekkei.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.gridSekkei.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridSekkei.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.colLogic,
            this.colPhysi,
            this.colEdit,
            this.colDelete});
            this.gridSekkei.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gridSekkei.DefaultCellStyle = dataGridViewCellStyle1;
            this.gridSekkei.EnableHeadersVisualStyles = false;
            this.gridSekkei.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridSekkei.Location = new System.Drawing.Point(6, 6);
            this.gridSekkei.MultiSelect = false;
            this.gridSekkei.Name = "gridSekkei";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridSekkei.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridSekkei.RowHeadersVisible = false;
            this.gridSekkei.RowHeadersWidth = 25;
            this.gridSekkei.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridSekkei.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridSekkei.Size = new System.Drawing.Size(291, 309);
            this.gridSekkei.TabIndex = 0;
            this.gridSekkei.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridSekkei_CellContentClick);
            // 
            // Column5
            // 
            this.Column5.HeaderText = "No.";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column5.Width = 25;
            // 
            // colLogic
            // 
            this.colLogic.HeaderText = "Logical Name";
            this.colLogic.Name = "colLogic";
            this.colLogic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // colPhysi
            // 
            this.colPhysi.HeaderText = "Physical Name";
            this.colPhysi.Name = "colPhysi";
            this.colPhysi.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // panelSettingTop
            // 
            this.panelSettingTop.Controls.Add(this.groupBox1);
            this.panelSettingTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSettingTop.Location = new System.Drawing.Point(0, 0);
            this.panelSettingTop.Name = "panelSettingTop";
            this.panelSettingTop.Size = new System.Drawing.Size(700, 80);
            this.panelSettingTop.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSearchSekkei);
            this.groupBox1.Controls.Add(this.btnAddSekkei);
            this.groupBox1.Controls.Add(this.txtPhysiName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtLogicName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(299, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting Sekkei";
            // 
            // txtPhysiName
            // 
            this.txtPhysiName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhysiName.Location = new System.Drawing.Point(130, 38);
            this.txtPhysiName.Name = "txtPhysiName";
            this.txtPhysiName.Size = new System.Drawing.Size(95, 22);
            this.txtPhysiName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(127, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Physical Name";
            // 
            // txtLogicName
            // 
            this.txtLogicName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogicName.Location = new System.Drawing.Point(30, 38);
            this.txtLogicName.Name = "txtLogicName";
            this.txtLogicName.Size = new System.Drawing.Size(95, 22);
            this.txtLogicName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Logical Name";
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelFooter.Controls.Add(this.label5);
            this.panelFooter.Controls.Add(this.label4);
            this.panelFooter.Controls.Add(this.label2);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 400);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(700, 20);
            this.panelFooter.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(486, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "© 2021 Copyright: Me";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Right;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(631, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "|";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(642, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ver: 1.0";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.FillWeight = 24F;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ToolSupportUchida.Properties.Resources.button_edit;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 24;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.FillWeight = 24F;
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = global::ToolSupportUchida.Properties.Resources.button_delete;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 24;
            // 
            // colEdit
            // 
            this.colEdit.FillWeight = 24F;
            this.colEdit.HeaderText = "";
            this.colEdit.Image = global::ToolSupportUchida.Properties.Resources.button_edit;
            this.colEdit.Name = "colEdit";
            this.colEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colEdit.Width = 24;
            // 
            // colDelete
            // 
            this.colDelete.FillWeight = 24F;
            this.colDelete.HeaderText = "";
            this.colDelete.Image = global::ToolSupportUchida.Properties.Resources.button_delete;
            this.colDelete.Name = "colDelete";
            this.colDelete.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDelete.Width = 24;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Image = global::ToolSupportUchida.Properties.Resources.button_clear;
            this.btnClear.Location = new System.Drawing.Point(253, 37);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(24, 24);
            this.btnClear.TabIndex = 5;
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearchSekkei
            // 
            this.btnSearchSekkei.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchSekkei.Image = global::ToolSupportUchida.Properties.Resources.button_search;
            this.btnSearchSekkei.Location = new System.Drawing.Point(4, 37);
            this.btnSearchSekkei.Name = "btnSearchSekkei";
            this.btnSearchSekkei.Size = new System.Drawing.Size(24, 24);
            this.btnSearchSekkei.TabIndex = 1;
            this.btnSearchSekkei.UseVisualStyleBackColor = true;
            this.btnSearchSekkei.Click += new System.EventHandler(this.btnSearchSekkei_Click);
            // 
            // btnAddSekkei
            // 
            this.btnAddSekkei.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSekkei.Image = global::ToolSupportUchida.Properties.Resources.button_add;
            this.btnAddSekkei.Location = new System.Drawing.Point(228, 37);
            this.btnAddSekkei.Name = "btnAddSekkei";
            this.btnAddSekkei.Size = new System.Drawing.Size(24, 24);
            this.btnAddSekkei.TabIndex = 4;
            this.btnAddSekkei.UseVisualStyleBackColor = true;
            this.btnAddSekkei.Click += new System.EventHandler(this.btnAddSekkei_Click);
            // 
            // btnCloseChildForm
            // 
            this.btnCloseChildForm.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCloseChildForm.FlatAppearance.BorderSize = 0;
            this.btnCloseChildForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseChildForm.Image = global::ToolSupportUchida.Properties.Resources.close;
            this.btnCloseChildForm.Location = new System.Drawing.Point(0, 0);
            this.btnCloseChildForm.Name = "btnCloseChildForm";
            this.btnCloseChildForm.Size = new System.Drawing.Size(60, 64);
            this.btnCloseChildForm.TabIndex = 1;
            this.btnCloseChildForm.TabStop = false;
            this.btnCloseChildForm.UseVisualStyleBackColor = true;
            this.btnCloseChildForm.Click += new System.EventHandler(this.btnCloseChildForm_Click);
            // 
            // btnCheckData
            // 
            this.btnCheckData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCheckData.FlatAppearance.BorderSize = 0;
            this.btnCheckData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckData.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCheckData.Image = global::ToolSupportUchida.Properties.Resources.check_data_model;
            this.btnCheckData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckData.Location = new System.Drawing.Point(0, 304);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCheckData.Size = new System.Drawing.Size(220, 60);
            this.btnCheckData.TabIndex = 3;
            this.btnCheckData.TabStop = false;
            this.btnCheckData.Text = "  Check Data Model";
            this.btnCheckData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // btnCreateAdapter
            // 
            this.btnCreateAdapter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCreateAdapter.FlatAppearance.BorderSize = 0;
            this.btnCreateAdapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateAdapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAdapter.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnCreateAdapter.Image = global::ToolSupportUchida.Properties.Resources.convert_adapter;
            this.btnCreateAdapter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAdapter.Location = new System.Drawing.Point(0, 244);
            this.btnCreateAdapter.Name = "btnCreateAdapter";
            this.btnCreateAdapter.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCreateAdapter.Size = new System.Drawing.Size(220, 60);
            this.btnCreateAdapter.TabIndex = 2;
            this.btnCreateAdapter.TabStop = false;
            this.btnCreateAdapter.Text = "  Create Adapter";
            this.btnCreateAdapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateAdapter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCreateAdapter.UseVisualStyleBackColor = true;
            this.btnCreateAdapter.Click += new System.EventHandler(this.btnCreateAdapter_Click);
            // 
            // btnConvertModel
            // 
            this.btnConvertModel.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConvertModel.FlatAppearance.BorderSize = 0;
            this.btnConvertModel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertModel.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvertModel.Image = global::ToolSupportUchida.Properties.Resources.convert_model;
            this.btnConvertModel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertModel.Location = new System.Drawing.Point(0, 184);
            this.btnConvertModel.Name = "btnConvertModel";
            this.btnConvertModel.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConvertModel.Size = new System.Drawing.Size(220, 60);
            this.btnConvertModel.TabIndex = 1;
            this.btnConvertModel.TabStop = false;
            this.btnConvertModel.Text = "  Convert Model";
            this.btnConvertModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertModel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertModel.UseVisualStyleBackColor = true;
            this.btnConvertModel.Click += new System.EventHandler(this.btnConvertModel_Click);
            // 
            // btnConverSekkei
            // 
            this.btnConverSekkei.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConverSekkei.FlatAppearance.BorderSize = 0;
            this.btnConverSekkei.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConverSekkei.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConverSekkei.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConverSekkei.Image = global::ToolSupportUchida.Properties.Resources.convert_sekkeei;
            this.btnConverSekkei.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConverSekkei.Location = new System.Drawing.Point(0, 124);
            this.btnConverSekkei.Name = "btnConverSekkei";
            this.btnConverSekkei.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConverSekkei.Size = new System.Drawing.Size(220, 60);
            this.btnConverSekkei.TabIndex = 3;
            this.btnConverSekkei.TabStop = false;
            this.btnConverSekkei.Text = "  Convert Sekkei";
            this.btnConverSekkei.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConverSekkei.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConverSekkei.UseVisualStyleBackColor = true;
            this.btnConverSekkei.Click += new System.EventHandler(this.btnConverSekkei_Click);
            // 
            // btnConvertDatabase
            // 
            this.btnConvertDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConvertDatabase.FlatAppearance.BorderSize = 0;
            this.btnConvertDatabase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertDatabase.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvertDatabase.Image = global::ToolSupportUchida.Properties.Resources.convert_database;
            this.btnConvertDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertDatabase.Location = new System.Drawing.Point(0, 64);
            this.btnConvertDatabase.Name = "btnConvertDatabase";
            this.btnConvertDatabase.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConvertDatabase.Size = new System.Drawing.Size(220, 60);
            this.btnConvertDatabase.TabIndex = 0;
            this.btnConvertDatabase.TabStop = false;
            this.btnConvertDatabase.Text = "  Convert Database";
            this.btnConvertDatabase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertDatabase.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertDatabase.UseVisualStyleBackColor = true;
            this.btnConvertDatabase.Click += new System.EventHandler(this.btnConvertDatabase_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::ToolSupportUchida.Properties.Resources.logo_tool;
            this.pictureBox1.InitialImage = global::ToolSupportUchida.Properties.Resources.logo_tool;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Padding = new System.Windows.Forms.Padding(8, 8, 0, 0);
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 484);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Support Uchida";
            this.Load += new System.EventHandler(this.Main_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
            this.panelSettingLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSekkei)).EndInit();
            this.panelSettingTop.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnConvertDatabase;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.Button btnCreateAdapter;
        private System.Windows.Forms.Button btnConvertModel;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDesktopPane;
        private System.Windows.Forms.Button btnCloseChildForm;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConverSekkei;
        private System.Windows.Forms.Panel panelSettingTop;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLogicName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPhysiName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddSekkei;
        private System.Windows.Forms.Button btnSearchSekkei;
        private System.Windows.Forms.Panel panelSettingLeft;
        private System.Windows.Forms.DataGridView gridSekkei;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Panel panelSettingRight;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLogic;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPhysi;
        private System.Windows.Forms.DataGridViewImageColumn colEdit;
        private System.Windows.Forms.DataGridViewImageColumn colDelete;
        private System.Windows.Forms.Button btnClear;
    }
}

