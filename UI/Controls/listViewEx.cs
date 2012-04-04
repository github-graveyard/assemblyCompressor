using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace assemblyCompressor.UI.Controls {
	[ToolboxBitmap(typeof (ListView))]
	internal class listViewEx : ListView {
		//Listview universal constants
		public const int LVM_FIRST = 0x1000;
		//Listview messages
		public const int LVM_SETEXTENDEDLISTVIEWSTYLE = LVM_FIRST + 54;
		public const int LVS_EX_FULLROWSELECT = 0x00000020;
		//Listview extended styles
		public const int LVS_EX_DOUBLEBUFFER = 0x00010000;
		private Boolean elv;

		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="ListView"/>.
		/// </summary>
		public listViewEx() {
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			DoubleBuffered = true;
			HeaderStyle = ColumnHeaderStyle.Nonclickable;
			FullRowSelect = true;
		}

		[DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
		public static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string pszSubIdList);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

		/// <summary>
		/// Explorerstyle setzen
		/// </summary>
		/// <param name="m"></param>
		protected override void WndProc(ref Message m) {
			// Listen for operating system messages.
			switch (m.Msg) {
				case 15:
					//Paint event
					if (!elv) {
						//1-time run needed
						SetWindowTheme(Handle, "explorer", null);

						SendMessage(Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX_DOUBLEBUFFER, LVS_EX_DOUBLEBUFFER);
							//Blue selection, keeps other extended styles
						elv = true;
					}
					break;
			}
			base.WndProc(ref m);
		}
	}
}