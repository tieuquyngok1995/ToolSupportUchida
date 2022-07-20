
namespace ToolSupportUchida.View
{
    partial class FormAbout
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
            this.lstTextUpdateVer = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstDocument = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstTextUpdateVer
            // 
            this.lstTextUpdateVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lstTextUpdateVer.Location = new System.Drawing.Point(6, 22);
            this.lstTextUpdateVer.Name = "lstTextUpdateVer";
            this.lstTextUpdateVer.ReadOnly = true;
            this.lstTextUpdateVer.Size = new System.Drawing.Size(328, 362);
            this.lstTextUpdateVer.TabIndex = 0;
            this.lstTextUpdateVer.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstTextUpdateVer);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(358, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(340, 390);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Ver";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstDocument);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.Location = new System.Drawing.Point(12, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(340, 390);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Document";
            // 
            // lstDocument
            // 
            this.lstDocument.Location = new System.Drawing.Point(6, 22);
            this.lstDocument.Name = "lstDocument";
            this.lstDocument.ReadOnly = true;
            this.lstDocument.Size = new System.Drawing.Size(328, 362);
            this.lstDocument.TabIndex = 0;
            this.lstDocument.Text = "";
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 405);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FormAbout";
            this.Text = "About Me";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox lstTextUpdateVer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox lstDocument;
    }
}