using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using assemblyCompressor.Core;
using assemblyCompressor.UI.Forms;
using codeCompiler;

namespace assemblyCompressor.UI.Controls {
	internal partial class ucSettings : UserControl {
		public ucSettings() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			chkCompress.CheckedChanged += chkCompress_CheckedChanged;
			chkStrongName.CheckedChanged += chkStrongName_CheckedChanged;
			txtOutput.TextChanged += txtOutput_TextChanged;
			txtStrongNameKey.TextChanged += txtStrongNameKey_TextChanged;
			rbAutoAssemblyInfoDisabled.CheckedChanged += radiobutton_changed;
			rbAutoAssemblyInfoEnabled.CheckedChanged += radiobutton_changed;
			rbUseCustomIcon.CheckedChanged += radiobuttonIcon_changed;
			rbUseMainIcon.CheckedChanged += radiobuttonIcon_changed;
			cboAppType.SelectedIndexChanged += cboAppType_SelectedIndexChanged;
			cboTargetProcessor.SelectedIndexChanged += cboTargetProcessor_SelectedIndexChanged;
		}

		public Project currentProject { get; set; }

		private void cboTargetProcessor_SelectedIndexChanged(object sender, EventArgs e) {
			currentProject.target = (processorTarget) cboTargetProcessor.SelectedIndex;
		}

		private void cboAppType_SelectedIndexChanged(object sender, EventArgs e) {
			switch (cboAppType.SelectedIndex) {
				case 0:
					currentProject.isConsoleApplication = false;
					break;
				case 1:
					currentProject.isConsoleApplication = true;
					break;
			}
		}

		private void txtStrongNameKey_TextChanged(object sender, EventArgs e) {
			currentProject.snkPath = txtStrongNameKey.Text;
		}

		private void txtOutput_TextChanged(object sender, EventArgs e) {
			currentProject.outputPath = txtOutput.Text;
		}

		private void radiobutton_changed(object sender, EventArgs e) {
			currentProject.retrieveAssemblyInformation = rbAutoAssemblyInfoEnabled.Checked;
			btnAssemblyInformation.Enabled = rbAutoAssemblyInfoDisabled.Checked;
		}

		private void radiobuttonIcon_changed(object sender, EventArgs e) {
			currentProject.useMainAssemblyIcon = rbUseMainIcon.Checked;
			pnlCustomIcon.Enabled = rbUseCustomIcon.Checked;
		}

		private void chkStrongName_CheckedChanged(object sender, EventArgs e) {
			currentProject.signAssembly = chkStrongName.Checked;
			pnlSNK.Enabled = chkStrongName.Checked;
		}

		private void chkCompress_CheckedChanged(object sender, EventArgs e) {
			currentProject.compressFiles = chkCompress.Checked;
		}

		public void reloadSettings() {
			chkCompress.Checked = currentProject.compressFiles;
			chkStrongName.Checked = currentProject.signAssembly;
			txtStrongNameKey.Text = currentProject.snkPath;
			if (currentProject.retrieveAssemblyInformation) {
				rbAutoAssemblyInfoEnabled.Checked = true;
			}
			else {
				rbAutoAssemblyInfoDisabled.Checked = true;
			}
			if (currentProject.useMainAssemblyIcon) {
				rbUseMainIcon.Checked = true;
			}
			else {
				rbUseCustomIcon.Checked = true;
				txtCustomIconPath.Text = currentProject.customIconPath;
				if (File.Exists(currentProject.customIconPath)) {
					pnlIconPreview.BackgroundImage = Icon.ExtractAssociatedIcon(currentProject.customIconPath).ToBitmap();
					pnlCustomIcon.Invalidate();
				}
			}
			if (!currentProject.isConsoleApplication) {
				cboAppType.SelectedIndex = 0;
			}
			else {
				cboAppType.SelectedIndex = 1;
			}
			txtOutput.Text = currentProject.outputPath;

			chkRuntimeLimitation.Checked = currentProject.enableRuntimeLimitation;
			if (currentProject.runtimeLimitationDate != DateTime.MinValue) {
				dtpRuntime.Value = currentProject.runtimeLimitationDate;
			}

			cboTargetProcessor.SelectedIndex = (int) currentProject.target;
		}

		private void btnBrowseStrongName_Click(object sender, EventArgs e) {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "StrongNameKey Container|*.snk";
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					txtStrongNameKey.Text = dlg.FileName;
					currentProject.snkPath = dlg.FileName;
				}
			}
		}

		private void btnChooseOutput_Click(object sender, EventArgs e) {
			using (var dlg = new SaveFileDialog()) {
				dlg.Filter = "Executables|*.exe";
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					txtOutput.Text = dlg.FileName;
					currentProject.outputPath = dlg.FileName;
				}
			}
		}

		private void btnAssemblyInformation_Click(object sender, EventArgs e) {
			using (var asmDlg = new assemblyInfoDialog(currentProject.assemblyInfo)) {
				if (asmDlg.ShowDialog(this) == DialogResult.OK) {
					currentProject.assemblyInfo = asmDlg.getAssemblyInfo;
				}
			}
		}

		private void pnlIconPreview_Paint(object sender, PaintEventArgs e) {
			try {
				if (pnlCustomIcon.BackgroundImage == null) {
					return;
				}

				using (var pen = new Pen(SystemColors.ControlDark, 1)) {
					e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, pnlIconPreview.Width - 1, pnlIconPreview.Height - 1));
					if (pnlCustomIcon.BackgroundImage != null) {
						e.Graphics.DrawImageUnscaled(
							pnlCustomIcon.BackgroundImage,
							new Point((pnlCustomIcon.Width/2) - (pnlCustomIcon.BackgroundImage.Width/2),
							          (pnlCustomIcon.Height/2) - (pnlCustomIcon.BackgroundImage.Height/2)));
					}
				}
			}
			catch {
			}
		}

		private void btnChooseIcon_Click(object sender, EventArgs e) {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "Icons|*.ico";
				if (dlg.ShowDialog(ParentForm) == DialogResult.OK) {
					txtCustomIconPath.Text = dlg.FileName;
					currentProject.customIconPath = dlg.FileName;
					reloadSettings();
				}
			}
		}

		private void chkRuntimeLimitation_CheckedChanged(object sender, EventArgs e) {
			grpRuntimeLimitation.Enabled = chkRuntimeLimitation.Checked;
			currentProject.enableRuntimeLimitation = chkRuntimeLimitation.Checked;
			currentProject.restrictByDate = chkRuntimeLimitation.Checked;
		}

		private void dtpRuntime_ValueChanged(object sender, EventArgs e) {
			currentProject.runtimeLimitationDate = dtpRuntime.Value;
		}
	}
}