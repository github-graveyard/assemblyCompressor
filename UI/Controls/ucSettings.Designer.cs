namespace assemblyCompressor.UI.Controls
{
    partial class ucSettings
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.pnlCustomIcon = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCustomIconPath = new System.Windows.Forms.TextBox();
			this.btnChooseIcon = new System.Windows.Forms.Button();
			this.pnlIconPreview = new System.Windows.Forms.Panel();
			this.rbUseCustomIcon = new System.Windows.Forms.RadioButton();
			this.rbUseMainIcon = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbAutoAssemblyInfoDisabled = new System.Windows.Forms.RadioButton();
			this.rbAutoAssemblyInfoEnabled = new System.Windows.Forms.RadioButton();
			this.btnAssemblyInformation = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkStrongName = new System.Windows.Forms.CheckBox();
			this.pnlSNK = new System.Windows.Forms.Panel();
			this.btnBrowseStrongName = new System.Windows.Forms.Button();
			this.txtStrongNameKey = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cboTargetProcessor = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.cboAppType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtOutput = new System.Windows.Forms.TextBox();
			this.btnChooseOutput = new System.Windows.Forms.Button();
			this.chkCompress = new System.Windows.Forms.CheckBox();
			this.chkRuntimeLimitation = new System.Windows.Forms.CheckBox();
			this.grpRuntimeLimitation = new System.Windows.Forms.GroupBox();
			this.dtpRuntime = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.groupBox5.SuspendLayout();
			this.pnlCustomIcon.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.pnlSNK.SuspendLayout();
			this.grpRuntimeLimitation.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.pnlCustomIcon);
			this.groupBox5.Controls.Add(this.rbUseCustomIcon);
			this.groupBox5.Controls.Add(this.rbUseMainIcon);
			this.groupBox5.Location = new System.Drawing.Point(3, 27);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(578, 110);
			this.groupBox5.TabIndex = 17;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Icon";
			// 
			// pnlCustomIcon
			// 
			this.pnlCustomIcon.Controls.Add(this.label1);
			this.pnlCustomIcon.Controls.Add(this.txtCustomIconPath);
			this.pnlCustomIcon.Controls.Add(this.btnChooseIcon);
			this.pnlCustomIcon.Controls.Add(this.pnlIconPreview);
			this.pnlCustomIcon.Enabled = false;
			this.pnlCustomIcon.Location = new System.Drawing.Point(23, 65);
			this.pnlCustomIcon.Name = "pnlCustomIcon";
			this.pnlCustomIcon.Size = new System.Drawing.Size(544, 39);
			this.pnlCustomIcon.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(45, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(61, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Iconfile:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtCustomIconPath
			// 
			this.txtCustomIconPath.Location = new System.Drawing.Point(112, 9);
			this.txtCustomIconPath.Name = "txtCustomIconPath";
			this.txtCustomIconPath.ReadOnly = true;
			this.txtCustomIconPath.Size = new System.Drawing.Size(388, 22);
			this.txtCustomIconPath.TabIndex = 9;
			// 
			// btnChooseIcon
			// 
			this.btnChooseIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnChooseIcon.Location = new System.Drawing.Point(506, 9);
			this.btnChooseIcon.Name = "btnChooseIcon";
			this.btnChooseIcon.Size = new System.Drawing.Size(35, 23);
			this.btnChooseIcon.TabIndex = 10;
			this.btnChooseIcon.Text = "...";
			this.btnChooseIcon.UseVisualStyleBackColor = true;
			this.btnChooseIcon.Click += new System.EventHandler(this.btnChooseIcon_Click);
			// 
			// pnlIconPreview
			// 
			this.pnlIconPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.pnlIconPreview.Dock = System.Windows.Forms.DockStyle.Left;
			this.pnlIconPreview.Location = new System.Drawing.Point(0, 0);
			this.pnlIconPreview.Name = "pnlIconPreview";
			this.pnlIconPreview.Size = new System.Drawing.Size(39, 39);
			this.pnlIconPreview.TabIndex = 0;
			this.pnlIconPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlIconPreview_Paint);
			// 
			// rbUseCustomIcon
			// 
			this.rbUseCustomIcon.AutoSize = true;
			this.rbUseCustomIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbUseCustomIcon.Location = new System.Drawing.Point(6, 44);
			this.rbUseCustomIcon.Name = "rbUseCustomIcon";
			this.rbUseCustomIcon.Size = new System.Drawing.Size(111, 18);
			this.rbUseCustomIcon.TabIndex = 1;
			this.rbUseCustomIcon.TabStop = true;
			this.rbUseCustomIcon.Text = "Use custom Icon";
			this.rbUseCustomIcon.UseVisualStyleBackColor = true;
			// 
			// rbUseMainIcon
			// 
			this.rbUseMainIcon.AutoSize = true;
			this.rbUseMainIcon.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbUseMainIcon.Location = new System.Drawing.Point(6, 21);
			this.rbUseMainIcon.Name = "rbUseMainIcon";
			this.rbUseMainIcon.Size = new System.Drawing.Size(180, 18);
			this.rbUseMainIcon.TabIndex = 0;
			this.rbUseMainIcon.TabStop = true;
			this.rbUseMainIcon.Text = "Extract Icon from Mainassembly";
			this.rbUseMainIcon.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbAutoAssemblyInfoDisabled);
			this.groupBox4.Controls.Add(this.rbAutoAssemblyInfoEnabled);
			this.groupBox4.Controls.Add(this.btnAssemblyInformation);
			this.groupBox4.Location = new System.Drawing.Point(3, 143);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(578, 79);
			this.groupBox4.TabIndex = 16;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Assemblyinformation";
			// 
			// rbAutoAssemblyInfoDisabled
			// 
			this.rbAutoAssemblyInfoDisabled.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbAutoAssemblyInfoDisabled.Location = new System.Drawing.Point(6, 45);
			this.rbAutoAssemblyInfoDisabled.Name = "rbAutoAssemblyInfoDisabled";
			this.rbAutoAssemblyInfoDisabled.Size = new System.Drawing.Size(123, 23);
			this.rbAutoAssemblyInfoDisabled.TabIndex = 10;
			this.rbAutoAssemblyInfoDisabled.Text = "Use own:";
			this.rbAutoAssemblyInfoDisabled.UseVisualStyleBackColor = true;
			// 
			// rbAutoAssemblyInfoEnabled
			// 
			this.rbAutoAssemblyInfoEnabled.AutoSize = true;
			this.rbAutoAssemblyInfoEnabled.Checked = true;
			this.rbAutoAssemblyInfoEnabled.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.rbAutoAssemblyInfoEnabled.Location = new System.Drawing.Point(6, 21);
			this.rbAutoAssemblyInfoEnabled.Name = "rbAutoAssemblyInfoEnabled";
			this.rbAutoAssemblyInfoEnabled.Size = new System.Drawing.Size(170, 18);
			this.rbAutoAssemblyInfoEnabled.TabIndex = 9;
			this.rbAutoAssemblyInfoEnabled.TabStop = true;
			this.rbAutoAssemblyInfoEnabled.Text = "Extract from  Mainassembly";
			this.rbAutoAssemblyInfoEnabled.UseVisualStyleBackColor = true;
			// 
			// btnAssemblyInformation
			// 
			this.btnAssemblyInformation.Enabled = false;
			this.btnAssemblyInformation.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAssemblyInformation.Location = new System.Drawing.Point(135, 45);
			this.btnAssemblyInformation.Name = "btnAssemblyInformation";
			this.btnAssemblyInformation.Size = new System.Drawing.Size(87, 23);
			this.btnAssemblyInformation.TabIndex = 8;
			this.btnAssemblyInformation.Text = "Edit";
			this.btnAssemblyInformation.UseVisualStyleBackColor = true;
			this.btnAssemblyInformation.Click += new System.EventHandler(this.btnAssemblyInformation_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkStrongName);
			this.groupBox3.Controls.Add(this.pnlSNK);
			this.groupBox3.Controls.Add(this.cboTargetProcessor);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.cboAppType);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.txtOutput);
			this.groupBox3.Controls.Add(this.btnChooseOutput);
			this.groupBox3.Location = new System.Drawing.Point(3, 228);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(578, 185);
			this.groupBox3.TabIndex = 15;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Output";
			// 
			// chkStrongName
			// 
			this.chkStrongName.AutoSize = true;
			this.chkStrongName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkStrongName.Location = new System.Drawing.Point(6, 113);
			this.chkStrongName.Name = "chkStrongName";
			this.chkStrongName.Size = new System.Drawing.Size(225, 18);
			this.chkStrongName.TabIndex = 3;
			this.chkStrongName.Text = "Sign Outputassembly with a Strongname:";
			this.chkStrongName.UseVisualStyleBackColor = true;
			// 
			// pnlSNK
			// 
			this.pnlSNK.Controls.Add(this.btnBrowseStrongName);
			this.pnlSNK.Controls.Add(this.txtStrongNameKey);
			this.pnlSNK.Controls.Add(this.label5);
			this.pnlSNK.Enabled = false;
			this.pnlSNK.Location = new System.Drawing.Point(6, 137);
			this.pnlSNK.Name = "pnlSNK";
			this.pnlSNK.Size = new System.Drawing.Size(561, 31);
			this.pnlSNK.TabIndex = 4;
			// 
			// btnBrowseStrongName
			// 
			this.btnBrowseStrongName.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnBrowseStrongName.Location = new System.Drawing.Point(523, 2);
			this.btnBrowseStrongName.Name = "btnBrowseStrongName";
			this.btnBrowseStrongName.Size = new System.Drawing.Size(35, 23);
			this.btnBrowseStrongName.TabIndex = 2;
			this.btnBrowseStrongName.Text = "...";
			this.btnBrowseStrongName.UseVisualStyleBackColor = true;
			this.btnBrowseStrongName.Click += new System.EventHandler(this.btnBrowseStrongName_Click);
			// 
			// txtStrongNameKey
			// 
			this.txtStrongNameKey.Location = new System.Drawing.Point(97, 3);
			this.txtStrongNameKey.Name = "txtStrongNameKey";
			this.txtStrongNameKey.ReadOnly = true;
			this.txtStrongNameKey.Size = new System.Drawing.Size(420, 22);
			this.txtStrongNameKey.TabIndex = 1;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(3, 3);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(88, 22);
			this.label5.TabIndex = 0;
			this.label5.Text = "Keyfile:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboTargetProcessor
			// 
			this.cboTargetProcessor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboTargetProcessor.FormattingEnabled = true;
			this.cboTargetProcessor.Items.AddRange(new object[] {
            "Any CPU",
            "x86 (32 Bit)",
            "x64 (64 Bit)"});
			this.cboTargetProcessor.Location = new System.Drawing.Point(116, 83);
			this.cboTargetProcessor.Name = "cboTargetProcessor";
			this.cboTargetProcessor.Size = new System.Drawing.Size(197, 21);
			this.cboTargetProcessor.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(9, 83);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(101, 21);
			this.label4.TabIndex = 10;
			this.label4.Text = "Architecture:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cboAppType
			// 
			this.cboAppType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboAppType.FormattingEnabled = true;
			this.cboAppType.Items.AddRange(new object[] {
            "Windows Forms Application",
            "Consoleapplication"});
			this.cboAppType.Location = new System.Drawing.Point(116, 52);
			this.cboAppType.Name = "cboAppType";
			this.cboAppType.Size = new System.Drawing.Size(197, 21);
			this.cboAppType.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(9, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(101, 21);
			this.label2.TabIndex = 8;
			this.label2.Text = "Applicationtype:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(9, 18);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(101, 22);
			this.label6.TabIndex = 5;
			this.label6.Text = "Outputfile:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtOutput
			// 
			this.txtOutput.Location = new System.Drawing.Point(116, 18);
			this.txtOutput.Name = "txtOutput";
			this.txtOutput.ReadOnly = true;
			this.txtOutput.Size = new System.Drawing.Size(407, 22);
			this.txtOutput.TabIndex = 6;
			// 
			// btnChooseOutput
			// 
			this.btnChooseOutput.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnChooseOutput.Location = new System.Drawing.Point(529, 18);
			this.btnChooseOutput.Name = "btnChooseOutput";
			this.btnChooseOutput.Size = new System.Drawing.Size(35, 23);
			this.btnChooseOutput.TabIndex = 7;
			this.btnChooseOutput.Text = "...";
			this.btnChooseOutput.UseVisualStyleBackColor = true;
			this.btnChooseOutput.Click += new System.EventHandler(this.btnChooseOutput_Click);
			// 
			// chkCompress
			// 
			this.chkCompress.AutoSize = true;
			this.chkCompress.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkCompress.Location = new System.Drawing.Point(3, 3);
			this.chkCompress.Name = "chkCompress";
			this.chkCompress.Size = new System.Drawing.Size(109, 18);
			this.chkCompress.TabIndex = 13;
			this.chkCompress.Text = "Compress Data";
			this.chkCompress.UseVisualStyleBackColor = true;
			// 
			// chkRuntimeLimitation
			// 
			this.chkRuntimeLimitation.AutoSize = true;
			this.chkRuntimeLimitation.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chkRuntimeLimitation.Location = new System.Drawing.Point(9, 428);
			this.chkRuntimeLimitation.Name = "chkRuntimeLimitation";
			this.chkRuntimeLimitation.Size = new System.Drawing.Size(116, 18);
			this.chkRuntimeLimitation.TabIndex = 18;
			this.chkRuntimeLimitation.Text = "Restrict Runtime";
			this.chkRuntimeLimitation.UseVisualStyleBackColor = true;
			this.chkRuntimeLimitation.CheckedChanged += new System.EventHandler(this.chkRuntimeLimitation_CheckedChanged);
			// 
			// grpRuntimeLimitation
			// 
			this.grpRuntimeLimitation.Controls.Add(this.dtpRuntime);
			this.grpRuntimeLimitation.Controls.Add(this.label3);
			this.grpRuntimeLimitation.Enabled = false;
			this.grpRuntimeLimitation.Location = new System.Drawing.Point(9, 443);
			this.grpRuntimeLimitation.Name = "grpRuntimeLimitation";
			this.grpRuntimeLimitation.Size = new System.Drawing.Size(572, 56);
			this.grpRuntimeLimitation.TabIndex = 19;
			this.grpRuntimeLimitation.TabStop = false;
			// 
			// dtpRuntime
			// 
			this.dtpRuntime.Location = new System.Drawing.Point(193, 21);
			this.dtpRuntime.Name = "dtpRuntime";
			this.dtpRuntime.Size = new System.Drawing.Size(200, 22);
			this.dtpRuntime.TabIndex = 1;
			this.dtpRuntime.ValueChanged += new System.EventHandler(this.dtpRuntime_ValueChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(181, 22);
			this.label3.TabIndex = 0;
			this.label3.Text = "Application executable until:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ucSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.grpRuntimeLimitation);
			this.Controls.Add(this.chkRuntimeLimitation);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.chkCompress);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.MaximumSize = new System.Drawing.Size(590, 500);
			this.MinimumSize = new System.Drawing.Size(590, 500);
			this.Name = "ucSettings";
			this.Size = new System.Drawing.Size(590, 500);
			this.groupBox5.ResumeLayout(false);
			this.groupBox5.PerformLayout();
			this.pnlCustomIcon.ResumeLayout(false);
			this.pnlCustomIcon.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.pnlSNK.ResumeLayout(false);
			this.pnlSNK.PerformLayout();
			this.grpRuntimeLimitation.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rbAutoAssemblyInfoDisabled;
        private System.Windows.Forms.RadioButton rbAutoAssemblyInfoEnabled;
        private System.Windows.Forms.Button btnAssemblyInformation;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnChooseOutput;
        private System.Windows.Forms.CheckBox chkStrongName;
        private System.Windows.Forms.Panel pnlSNK;
        private System.Windows.Forms.Button btnBrowseStrongName;
        private System.Windows.Forms.TextBox txtStrongNameKey;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkCompress;
        private System.Windows.Forms.RadioButton rbUseMainIcon;
        private System.Windows.Forms.RadioButton rbUseCustomIcon;
        private System.Windows.Forms.Panel pnlCustomIcon;
        private System.Windows.Forms.Panel pnlIconPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomIconPath;
        private System.Windows.Forms.Button btnChooseIcon;
        private System.Windows.Forms.ComboBox cboAppType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkRuntimeLimitation;
        private System.Windows.Forms.GroupBox grpRuntimeLimitation;
        private System.Windows.Forms.DateTimePicker dtpRuntime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTargetProcessor;
		private System.Windows.Forms.Label label4;
    }
}
