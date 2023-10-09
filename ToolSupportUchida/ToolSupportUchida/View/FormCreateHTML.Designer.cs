
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
            this.lblNumResource = new System.Windows.Forms.Label();
            this.txtResource = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtRowCol);
            this.groupBox4.Controls.Add(this.lblNumRowCol);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 1);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(166, 361);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Input Row Column";
            // 
            // txtRowCol
            // 
            this.txtRowCol.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRowCol.Location = new System.Drawing.Point(3, 19);
            this.txtRowCol.Name = "txtRowCol";
            this.txtRowCol.Size = new System.Drawing.Size(160, 310);
            this.txtRowCol.TabIndex = 2;
            this.txtRowCol.Text = "";
            this.txtRowCol.TextChanged += new System.EventHandler(this.txtRowCol_TextChanged);
            // 
            // lblNumRowCol
            // 
            this.lblNumRowCol.AutoSize = true;
            this.lblNumRowCol.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumRowCol.Location = new System.Drawing.Point(61, 336);
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
            this.groupBox5.Location = new System.Drawing.Point(181, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(166, 361);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Input Control";
            // 
            // txtControl
            // 
            this.txtControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtControl.Location = new System.Drawing.Point(3, 19);
            this.txtControl.Name = "txtControl";
            this.txtControl.Size = new System.Drawing.Size(160, 310);
            this.txtControl.TabIndex = 0;
            this.txtControl.Text = "";
            this.txtControl.TextChanged += new System.EventHandler(this.txtControl_TextChanged);
            // 
            // lblNumControl
            // 
            this.lblNumControl.AutoSize = true;
            this.lblNumControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumControl.Location = new System.Drawing.Point(61, 336);
            this.lblNumControl.Name = "lblNumControl";
            this.lblNumControl.Size = new System.Drawing.Size(80, 15);
            this.lblNumControl.TabIndex = 9;
            this.lblNumControl.Text = "Line number:";
            this.lblNumControl.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lblNumResource);
            this.groupBox6.Controls.Add(this.txtResource);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(353, 1);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(166, 361);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Input Model Property";
            // 
            // lblNumResource
            // 
            this.lblNumResource.AutoSize = true;
            this.lblNumResource.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lblNumResource.Location = new System.Drawing.Point(61, 336);
            this.lblNumResource.Name = "lblNumResource";
            this.lblNumResource.Size = new System.Drawing.Size(80, 15);
            this.lblNumResource.TabIndex = 10;
            this.lblNumResource.Text = "Line number:";
            this.lblNumResource.Visible = false;
            // 
            // txtResource
            // 
            this.txtResource.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtResource.Location = new System.Drawing.Point(3, 19);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(160, 310);
            this.txtResource.TabIndex = 0;
            this.txtResource.Text = "";
            this.txtResource.TextChanged += new System.EventHandler(this.txtResource_TextChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnCreate);
            this.groupBox7.Controls.Add(this.btnCopy);
            this.groupBox7.Controls.Add(this.btnClear);
            this.groupBox7.Controls.Add(this.txtResult);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(525, 1);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(166, 361);
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
            this.btnCreate.Location = new System.Drawing.Point(4, 332);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(96, 24);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "  Create";
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
            this.btnCopy.Location = new System.Drawing.Point(103, 332);
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
            this.btnClear.Location = new System.Drawing.Point(134, 332);
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
            this.txtResult.Size = new System.Drawing.Size(160, 307);
            this.txtResult.TabIndex = 0;
            this.txtResult.Text = "";
            // 
            // FormCreateHTML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 374);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
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
        private System.Windows.Forms.Label lblNumResource;
        private System.Windows.Forms.RichTextBox txtResource;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnClear;
    }
}