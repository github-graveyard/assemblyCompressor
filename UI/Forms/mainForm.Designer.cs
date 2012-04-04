using assemblyCompressor.Properties;

namespace assemblyCompressor.UI.Forms
{
	partial class mainForm
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
			this.components = new System.ComponentModel.Container();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.button1 = new System.Windows.Forms.Button();
			this.btnRemoveAssembly = new System.Windows.Forms.Button();
			this.btnAddAssembly = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnChooseMainAssembly = new System.Windows.Forms.Button();
			this.txtMainAssembly = new System.Windows.Forms.TextBox();
			this.tvAssemblies = new assemblyCompressor.UI.Controls.treeViewEx();
			this.imglAssemblies = new System.Windows.Forms.ImageList(this.components);
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.ctpSettings = new assemblyCompressor.UI.Controls.contentPanel();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.ctpAbout = new assemblyCompressor.UI.Controls.contentPanel();
			this.neuToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.öffnenToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.speichernToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsOpen = new System.Windows.Forms.ToolStripButton();
			this.tsSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.tsBuild = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.btnUpdates = new System.Windows.Forms.ToolStripButton();
			this.updController = new updateSystemDotNet.updateController();
			this.bgwCompile = new System.ComponentModel.BackgroundWorker();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 28);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(621, 364);
			this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button1);
			this.tabPage1.Controls.Add(this.btnRemoveAssembly);
			this.tabPage1.Controls.Add(this.btnAddAssembly);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.tvAssemblies);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(613, 338);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Assemblies";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(448, 308);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(159, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Throw test Exception";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// btnRemoveAssembly
			// 
			this.btnRemoveAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRemoveAssembly.Enabled = false;
			this.btnRemoveAssembly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnRemoveAssembly.Location = new System.Drawing.Point(214, 307);
			this.btnRemoveAssembly.Name = "btnRemoveAssembly";
			this.btnRemoveAssembly.Size = new System.Drawing.Size(75, 24);
			this.btnRemoveAssembly.TabIndex = 7;
			this.btnRemoveAssembly.Text = "Remove";
			this.btnRemoveAssembly.UseVisualStyleBackColor = true;
			this.btnRemoveAssembly.Click += new System.EventHandler(this.btnRemoveAssembly_Click);
			// 
			// btnAddAssembly
			// 
			this.btnAddAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAddAssembly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddAssembly.Location = new System.Drawing.Point(131, 307);
			this.btnAddAssembly.Name = "btnAddAssembly";
			this.btnAddAssembly.Size = new System.Drawing.Size(77, 24);
			this.btnAddAssembly.TabIndex = 6;
			this.btnAddAssembly.Text = "Add";
			this.btnAddAssembly.UseVisualStyleBackColor = true;
			this.btnAddAssembly.Click += new System.EventHandler(this.btnAddAssembly_Click);
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label2.Location = new System.Drawing.Point(6, 307);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(119, 24);
			this.label2.TabIndex = 5;
			this.label2.Text = "Dependencies:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btnChooseMainAssembly);
			this.groupBox1.Controls.Add(this.txtMainAssembly);
			this.groupBox1.Location = new System.Drawing.Point(6, 6);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(601, 55);
			this.groupBox1.TabIndex = 4;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Mainassembly";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 18);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 22);
			this.label1.TabIndex = 2;
			this.label1.Text = "Path:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnChooseMainAssembly
			// 
			this.btnChooseMainAssembly.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnChooseMainAssembly.Location = new System.Drawing.Point(519, 17);
			this.btnChooseMainAssembly.Name = "btnChooseMainAssembly";
			this.btnChooseMainAssembly.Size = new System.Drawing.Size(76, 23);
			this.btnChooseMainAssembly.TabIndex = 3;
			this.btnChooseMainAssembly.Text = "Browse...";
			this.btnChooseMainAssembly.UseVisualStyleBackColor = true;
			this.btnChooseMainAssembly.Click += new System.EventHandler(this.btnChooseMainAssembly_Click);
			// 
			// txtMainAssembly
			// 
			this.txtMainAssembly.AllowDrop = true;
			this.txtMainAssembly.Location = new System.Drawing.Point(61, 18);
			this.txtMainAssembly.Name = "txtMainAssembly";
			this.txtMainAssembly.ReadOnly = true;
			this.txtMainAssembly.Size = new System.Drawing.Size(452, 22);
			this.txtMainAssembly.TabIndex = 0;
			// 
			// tvAssemblies
			// 
			this.tvAssemblies.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tvAssemblies.HotTracking = true;
			this.tvAssemblies.ImageIndex = 0;
			this.tvAssemblies.ImageList = this.imglAssemblies;
			this.tvAssemblies.ItemHeight = 22;
			this.tvAssemblies.Location = new System.Drawing.Point(6, 67);
			this.tvAssemblies.Name = "tvAssemblies";
			this.tvAssemblies.SelectedImageIndex = 0;
			this.tvAssemblies.ShowLines = false;
			this.tvAssemblies.Size = new System.Drawing.Size(601, 234);
			this.tvAssemblies.TabIndex = 0;
			// 
			// imglAssemblies
			// 
			this.imglAssemblies.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imglAssemblies.ImageSize = new System.Drawing.Size(16, 16);
			this.imglAssemblies.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.ctpSettings);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(613, 338);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Settings";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// ctpSettings
			// 
			this.ctpSettings.AutoScroll = true;
			this.ctpSettings.BackColor = System.Drawing.Color.White;
			this.ctpSettings.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctpSettings.Location = new System.Drawing.Point(3, 3);
			this.ctpSettings.Name = "ctpSettings";
			this.ctpSettings.Size = new System.Drawing.Size(607, 332);
			this.ctpSettings.TabIndex = 0;
			this.ctpSettings.Text = "Settings";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.ctpAbout);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(613, 338);
			this.tabPage2.TabIndex = 3;
			this.tabPage2.Text = "About";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// ctpAbout
			// 
			this.ctpAbout.AutoScroll = true;
			this.ctpAbout.BackColor = System.Drawing.Color.White;
			this.ctpAbout.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ctpAbout.Location = new System.Drawing.Point(3, 3);
			this.ctpAbout.Name = "ctpAbout";
			this.ctpAbout.Size = new System.Drawing.Size(607, 332);
			this.ctpAbout.TabIndex = 0;
			// 
			// neuToolStripButton
			// 
			this.neuToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.neuToolStripButton.Name = "neuToolStripButton";
			this.neuToolStripButton.Size = new System.Drawing.Size(49, 22);
			this.neuToolStripButton.Text = "&New";
			// 
			// öffnenToolStripButton
			// 
			this.öffnenToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.öffnenToolStripButton.Name = "öffnenToolStripButton";
			this.öffnenToolStripButton.Size = new System.Drawing.Size(64, 22);
			this.öffnenToolStripButton.Text = "Open";
			// 
			// speichernToolStripButton
			// 
			this.speichernToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.speichernToolStripButton.Name = "speichernToolStripButton";
			this.speichernToolStripButton.Size = new System.Drawing.Size(79, 22);
			this.speichernToolStripButton.Text = "&Save";
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsOpen,
			this.tsSave,
			this.toolStripSeparator1,
			this.tsBuild,
			this.toolStripSeparator2,
			this.btnUpdates});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Padding = new System.Windows.Forms.Padding(12, 0, 1, 0);
			this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.toolStrip1.ShowItemToolTips = false;
			this.toolStrip1.Size = new System.Drawing.Size(645, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// tsOpen
			// 
			this.tsOpen.Image = global::assemblyCompressor.Properties.Resources.open;
			this.tsOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsOpen.Name = "tsOpen";
			this.tsOpen.Size = new System.Drawing.Size(56, 22);
			this.tsOpen.Text = "Open";
			this.tsOpen.Click += new System.EventHandler(this.tsOpen_Click);
			// 
			// tsSave
			// 
			this.tsSave.Image = global::assemblyCompressor.Properties.Resources.save;
			this.tsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsSave.Name = "tsSave";
			this.tsSave.Size = new System.Drawing.Size(51, 22);
			this.tsSave.Text = "Save";
			this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// tsBuild
			// 
			this.tsBuild.Image = global::assemblyCompressor.Properties.Resources.build;
			this.tsBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsBuild.Name = "tsBuild";
			this.tsBuild.Size = new System.Drawing.Size(54, 22);
			this.tsBuild.Text = "Build";
			this.tsBuild.Click += new System.EventHandler(this.tsBuild_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// btnUpdates
			// 
			this.btnUpdates.Image = global::assemblyCompressor.Properties.Resources.updates;
			this.btnUpdates.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btnUpdates.Name = "btnUpdates";
			this.btnUpdates.Size = new System.Drawing.Size(133, 22);
			this.btnUpdates.Text = "Check for Updates...";
			this.btnUpdates.Click += new System.EventHandler(this.btnUpdates_Click);
			// 
			// updController
			// 
			this.updController.applicationLocation = "";
			this.updController.autoCopyCommandlineArguments = true;
			this.updController.customUpdateCheckInterval = 1;
			this.updController.Language = updateSystemDotNet.Languages.English;
			this.updController.projectId = "94977846-97a8-42d1-ace3-c90904d1d4fa";
			this.updController.proxyPassword = null;
			this.updController.proxyUrl = null;
			this.updController.proxyUsername = null;
			this.updController.releaseFilter.checkForAlpha = false;
			this.updController.releaseFilter.checkForBeta = false;
			this.updController.releaseFilter.checkForFinal = true;
			this.updController.releaseInfo.Version = "";
			this.updController.requestElevation = true;
			this.updController.restartApplication = true;
			this.updController.retrieveHostVersion = true;
			this.updController.updateCheckInterval = updateSystemDotNet.Interval.Custom;
			this.updController.updateUrl = "https://secure.devs-on.net/updates/assemblyCompressor/";
			// 
			// mainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(645, 404);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "mainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "assemblyCompressor";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private assemblyCompressor.UI.Controls.treeViewEx tvAssemblies;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMainAssembly;
		private System.Windows.Forms.Button btnChooseMainAssembly;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnRemoveAssembly;
		private System.Windows.Forms.Button btnAddAssembly;
		private System.Windows.Forms.ImageList imglAssemblies;
		private System.Windows.Forms.ToolStripButton neuToolStripButton;
		private System.Windows.Forms.ToolStripButton öffnenToolStripButton;
		private System.Windows.Forms.ToolStripButton speichernToolStripButton;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsOpen;
		private System.Windows.Forms.ToolStripButton tsSave;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton btnUpdates;
		private updateSystemDotNet.updateController updController;
		private System.ComponentModel.BackgroundWorker bgwCompile;
		private System.Windows.Forms.ToolStripButton tsBuild;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.TabPage tabPage3;
		private assemblyCompressor.UI.Controls.contentPanel ctpSettings;
		private System.Windows.Forms.TabPage tabPage2;
		private assemblyCompressor.UI.Controls.contentPanel ctpAbout;
		private System.Windows.Forms.Button button1;


	}
}