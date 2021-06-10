
namespace ToolSupportUchida.View
{
    partial class FormCreateAdapter
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
            this.panelTextJapan = new System.Windows.Forms.Panel();
            this.panelTextEng = new System.Windows.Forms.Panel();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.panelTextJapan.SuspendLayout();
            this.panelTextEng.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTextJapan
            // 
            this.panelTextJapan.Controls.Add(this.groupBox1);
            this.panelTextJapan.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTextJapan.Location = new System.Drawing.Point(0, 0);
            this.panelTextJapan.Name = "panelTextJapan";
            this.panelTextJapan.Size = new System.Drawing.Size(250, 420);
            this.panelTextJapan.TabIndex = 0;
            // 
            // panelTextEng
            // 
            this.panelTextEng.Controls.Add(this.groupBox2);
            this.panelTextEng.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelTextEng.Location = new System.Drawing.Point(314, 0);
            this.panelTextEng.Name = "panelTextEng";
            this.panelTextEng.Size = new System.Drawing.Size(250, 420);
            this.panelTextEng.TabIndex = 1;
            // 
            // panelEvent
            // 
            this.panelEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEvent.Location = new System.Drawing.Point(250, 0);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(64, 420);
            this.panelEvent.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 405);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Japan";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBox2);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(6, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(241, 405);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Result";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(229, 372);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox2.Location = new System.Drawing.Point(6, 27);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(229, 372);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // FormCreateAdapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 420);
            this.Controls.Add(this.panelEvent);
            this.Controls.Add(this.panelTextEng);
            this.Controls.Add(this.panelTextJapan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCreateAdapter";
            this.Text = "FormCreateAdapter";
            this.panelTextJapan.ResumeLayout(false);
            this.panelTextEng.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTextJapan;
        private System.Windows.Forms.Panel panelTextEng;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}