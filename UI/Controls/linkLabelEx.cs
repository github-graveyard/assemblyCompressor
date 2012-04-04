using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace assemblyCompressor.UI.Controls {
	internal class linkLabelEx : LinkLabel {
		public linkLabelEx() {
			LinkColor = SystemColors.HotTrack;
			base.Font = SystemFonts.MessageBoxFont;
			ActiveLinkColor = SystemColors.Highlight;
		}

		public string Url { get; set; }

		private void openFailed() {
			MessageBox.Show(
				"Sorry but I failed to open this Url:\r\n" + Url,
				"assemblyCompressor",
				MessageBoxButtons.OK,
				MessageBoxIcon.Exclamation);
		}

		protected override void OnClick(EventArgs e) {
			if (!string.IsNullOrEmpty(Url)) {
				new Thread(openUrl).Start(Url);
			}
			else {
				base.OnClick(e);
			}
		}

		private void openUrl(object argument) {
			try {
				Process.Start((argument as string));
			}
			catch {
				Invoke(new delOpenFailed(openFailed));
			}
		}

		#region Nested type: delOpenFailed

		private delegate void delOpenFailed();

		#endregion
	}
}