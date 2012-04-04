using System;
using System.ComponentModel;
using System.Windows.Forms;
using assemblyCompressor.Core;
using System.Drawing;

namespace assemblyCompressor.UI.Forms {
	internal partial class buildDialog : Form {
		private readonly Project _project;

		public buildDialog(Project project) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			_project = project;

			FormClosing += buildDialog_FormClosing;
			Shown += buildDialog_Shown;
			bgwBuild.RunWorkerCompleted += bgwBuild_RunWorkerCompleted;
			bgwBuild.ProgressChanged += bgwBuild_ProgressChanged;
		}

		private void showException(Exception ex) {
			MessageBox.Show(this, string.Format("The Project could not be build:\r\n{0}", ex.Message), "assemblyCompressor",
			                  MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public new DialogResult ShowDialog(IWin32Window owner) {
			if (owner == null) {
				StartPosition = FormStartPosition.CenterScreen;
			}
			return base.ShowDialog(owner);
		}

		private void bgwBuild_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			prgBuild.Value = e.ProgressPercentage;
		}

		private void bgwBuild_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Result != null) {
				DialogResult = DialogResult.OK;
			}
			Close();
		}

		private void buildDialog_Shown(object sender, EventArgs e) {
			bgwBuild.RunWorkerAsync(_project);
		}

		private void buildDialog_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = bgwBuild.IsBusy;
		}

		private void bgwBuild_DoWork(object sender, DoWorkEventArgs e) {
			try {
				var project = (Project) e.Argument;
				var compiler = new Compiler(project);
				compiler.compilerProgressChanged += compiler_compilerProgressChanged;

				compiler.Compile();

				compiler.Dispose();
				e.Result = true;
			}
			catch (Exception ex) {
				Invoke(new delShowException(showException), ex);
			}
		}

		private void compiler_compilerProgressChanged(object sender, compilerProgressChangedEventArgs e) {
			bgwBuild.ReportProgress(e.PercentDone);
		}

		#region Nested type: delShowException

		private delegate void delShowException(Exception ex);

		#endregion
	}
}