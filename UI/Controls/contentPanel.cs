using System.Windows.Forms;

namespace assemblyCompressor.UI.Controls {
	internal class contentPanel : ContainerControl {
		public contentPanel() {
			base.AutoScroll = true;
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}
	}
}