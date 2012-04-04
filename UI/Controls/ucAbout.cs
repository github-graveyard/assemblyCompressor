using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace assemblyCompressor.UI.Controls {
	internal partial class ucAbout : UserControl {
		public ucAbout() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
		}

		private void ucAbout_Load(object sender, EventArgs e) {
			try {
				lblVersion.Text = string.Format(lblVersion.Text, Assembly.GetExecutingAssembly().GetName().Version);
			}
			catch (Exception ex) {
				MessageBox.Show(string.Format("Error while reading the Productversion:\r\n{0}", ex));
			}

			try {
				imgApplication.Image = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
			}
			catch {
				imgApplication.Image = SystemIcons.Application.ToBitmap();
			}
		}
	}
}