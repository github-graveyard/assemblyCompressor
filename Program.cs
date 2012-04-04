using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using assemblyCompressor.Core;
using assemblyCompressor.UI.Forms;

namespace assemblyCompressor {
	internal static class Program {
		[DllImport("kernel32.dll")]
		private static extern Boolean FreeConsole();
		[STAThread]
		private static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (args.Length > 1 && args[0].ToLower() == "/build") {
				new commandLineUtility(args).Execute();
			}
			else {
				FreeConsole();
				Application.Run(new mainForm());
			}
		}
	}
}