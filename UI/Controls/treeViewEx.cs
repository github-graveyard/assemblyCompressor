using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace assemblyCompressor.UI.Controls {
	internal class treeViewEx : TreeView {
		[DllImport("uxtheme", CharSet = CharSet.Unicode)]
		private static extern Int32 SetWindowTheme(IntPtr hWnd, String textSubAppName, String textSubIdList);
		public treeViewEx() {
			SetWindowTheme(Handle, "explorer", null);
		}
	}
}