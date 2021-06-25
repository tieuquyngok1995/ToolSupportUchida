
namespace ToolSupportUchida.View
{
    partial class FormCommon
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
            this.tabControlCommon = new System.Windows.Forms.TabControl();
            this.tabPageCreateJson = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlCommon.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlCommon
            // 
            this.tabControlCommon.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControlCommon.Controls.Add(this.tabPageCreateJson);
            this.tabControlCommon.Controls.Add(this.tabPage2);
            this.tabControlCommon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlCommon.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlCommon.ItemSize = new System.Drawing.Size(28, 120);
            this.tabControlCommon.Location = new System.Drawing.Point(0, 0);
            this.tabControlCommon.Multiline = true;
            this.tabControlCommon.Name = "tabControlCommon";
            this.tabControlCommon.Padding = new System.Drawing.Point(3, 3);
            this.tabControlCommon.SelectedIndex = 0;
            this.tabControlCommon.Size = new System.Drawing.Size(564, 397);
            this.tabControlCommon.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlCommon.TabIndex = 0;
            this.tabControlCommon.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControlCommon_DrawItem);
            // 
            // tabPageCreateJson
            // 
            this.tabPageCreateJson.Location = new System.Drawing.Point(124, 4);
            this.tabPageCreateJson.Name = "tabPageCreateJson";
            this.tabPageCreateJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCreateJson.Size = new System.Drawing.Size(436, 389);
            this.tabPageCreateJson.TabIndex = 0;
            this.tabPageCreateJson.Text = "Create JSON";
            this.tabPageCreateJson.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(124, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(436, 389);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormCommon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 397);
            this.Controls.Add(this.tabControlCommon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCommon";
            this.Text = "FormCheck";
            this.Load += new System.EventHandler(this.FormCheckDataModel_Load);
            this.tabControlCommon.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlCommon;
        private System.Windows.Forms.TabPage tabPageCreateJson;
        private System.Windows.Forms.TabPage tabPage2;
    }
}