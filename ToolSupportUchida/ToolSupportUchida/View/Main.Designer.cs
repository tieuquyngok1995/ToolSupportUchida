
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelDesktopPane = new System.Windows.Forms.Panel();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCloseChildForm = new System.Windows.Forms.Button();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.btnConver = new System.Windows.Forms.Button();
            this.btnConvertAdapter = new System.Windows.Forms.Button();
            this.btnConvertModel = new System.Windows.Forms.Button();
            this.btnConvertDatabase = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitleBar.SuspendLayout();
            this.panelDesktopPane.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelMenu.Controls.Add(this.btnCheckData);
            this.panelMenu.Controls.Add(this.btnConver);
            this.panelMenu.Controls.Add(this.btnConvertAdapter);
            this.panelMenu.Controls.Add(this.btnConvertModel);
            this.panelMenu.Controls.Add(this.btnConvertDatabase);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 500);
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
            this.panelTitleBar.Size = new System.Drawing.Size(580, 64);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnMinimize
            // 
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Ancuu", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(514, 3);
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
            this.btnClose.Location = new System.Drawing.Point(547, 3);
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
            this.lblTitle.Location = new System.Drawing.Point(217, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(71, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Home";
            // 
            // panelDesktopPane
            // 
            this.panelDesktopPane.Controls.Add(this.panelFooter);
            this.panelDesktopPane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPane.Location = new System.Drawing.Point(220, 64);
            this.panelDesktopPane.Name = "panelDesktopPane";
            this.panelDesktopPane.Size = new System.Drawing.Size(580, 436);
            this.panelDesktopPane.TabIndex = 2;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.panelFooter.Controls.Add(this.label5);
            this.panelFooter.Controls.Add(this.label4);
            this.panelFooter.Controls.Add(this.label2);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 416);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(580, 20);
            this.panelFooter.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(366, 0);
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
            this.label4.Location = new System.Drawing.Point(511, 0);
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
            this.label2.Location = new System.Drawing.Point(522, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ver: 1.0";
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
            // btnConver
            // 
            this.btnConver.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConver.FlatAppearance.BorderSize = 0;
            this.btnConver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConver.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConver.Image = global::ToolSupportUchida.Properties.Resources.check_data_model;
            this.btnConver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConver.Location = new System.Drawing.Point(0, 244);
            this.btnConver.Name = "btnConver";
            this.btnConver.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConver.Size = new System.Drawing.Size(220, 60);
            this.btnConver.TabIndex = 3;
            this.btnConver.TabStop = false;
            this.btnConver.Text = "  Convert ";
            this.btnConver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConver.UseVisualStyleBackColor = true;
            // 
            // btnConvertAdapter
            // 
            this.btnConvertAdapter.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConvertAdapter.FlatAppearance.BorderSize = 0;
            this.btnConvertAdapter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConvertAdapter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConvertAdapter.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConvertAdapter.Image = global::ToolSupportUchida.Properties.Resources.convert_adapter;
            this.btnConvertAdapter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertAdapter.Location = new System.Drawing.Point(0, 184);
            this.btnConvertAdapter.Name = "btnConvertAdapter";
            this.btnConvertAdapter.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnConvertAdapter.Size = new System.Drawing.Size(220, 60);
            this.btnConvertAdapter.TabIndex = 2;
            this.btnConvertAdapter.TabStop = false;
            this.btnConvertAdapter.Text = "  Create Adapter";
            this.btnConvertAdapter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConvertAdapter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConvertAdapter.UseVisualStyleBackColor = true;
            this.btnConvertAdapter.Click += new System.EventHandler(this.btnCreateAdapter_Click);
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
            this.btnConvertModel.Location = new System.Drawing.Point(0, 124);
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
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.panelDesktopPane);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tool Support Uchida";
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panelDesktopPane.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnConvertAdapter;
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
        private System.Windows.Forms.Button btnConver;
    }
}

