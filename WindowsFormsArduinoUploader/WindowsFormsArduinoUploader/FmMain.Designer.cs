namespace WindowsFormsArduinoUploader
{
    partial class FmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FmMain));
            this.TBMain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnBrowse = new System.Windows.Forms.Button();
            this.CmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CmbPort = new System.Windows.Forms.ComboBox();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.PBMain = new System.Windows.Forms.ProgressBar();
            this.RTBMain = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // TBMain
            // 
            resources.ApplyResources(this.TBMain, "TBMain");
            this.TBMain.Name = "TBMain";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // BtnBrowse
            // 
            resources.ApplyResources(this.BtnBrowse, "BtnBrowse");
            this.BtnBrowse.Name = "BtnBrowse";
            this.BtnBrowse.UseVisualStyleBackColor = true;
            this.BtnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // CmbType
            // 
            resources.ApplyResources(this.CmbType, "CmbType");
            this.CmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbType.FormattingEnabled = true;
            this.CmbType.Name = "CmbType";
            this.CmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // CmbPort
            // 
            resources.ApplyResources(this.CmbPort, "CmbPort");
            this.CmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPort.FormattingEnabled = true;
            this.CmbPort.Name = "CmbPort";
            // 
            // BtnUpload
            // 
            resources.ApplyResources(this.BtnUpload, "BtnUpload");
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.UseVisualStyleBackColor = true;
            this.BtnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // PBMain
            // 
            resources.ApplyResources(this.PBMain, "PBMain");
            this.PBMain.Name = "PBMain";
            // 
            // RTBMain
            // 
            resources.ApplyResources(this.RTBMain, "RTBMain");
            this.RTBMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RTBMain.Name = "RTBMain";
            this.RTBMain.ReadOnly = true;
            // 
            // FmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.RTBMain);
            this.Controls.Add(this.PBMain);
            this.Controls.Add(this.BtnUpload);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CmbPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CmbType);
            this.Controls.Add(this.BtnBrowse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBMain);
            this.Name = "FmMain";
            this.Load += new System.EventHandler(this.FmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnBrowse;
        private System.Windows.Forms.ComboBox CmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CmbPort;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.ProgressBar PBMain;
        private System.Windows.Forms.RichTextBox RTBMain;
    }
}

