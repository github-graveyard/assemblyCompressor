using System.Collections.Generic;
using System.Threading;

namespace assemblyCompressor.Core.subSystem {
	internal static class languageHelper {
		private static Dictionary<string, string> _stringsDe;
		private static Dictionary<string, string> _stringsEn;

		private static void initializeDictionaries() {
			_stringsDe = new Dictionary<string, string>();
			_stringsEn = new Dictionary<string, string>();

			_stringsDe.Add("global_application", "Die Anwendung");
			_stringsEn.Add("global_application", "The Application");
			_stringsDe.Add("global_close", "Schließen");
			_stringsEn.Add("global_close", "Close");

			_stringsDe.Add("exceptionDialog_title", "%appname% hat ein Problem festgestellt.");
			_stringsEn.Add("exceptionDialog_title", "%appname% has encountered an Error.");
			_stringsDe.Add("exceptionDialog_info", "%appname% musste auf Grund des folgenden Problems beendet werden:\r\n{0}");
			_stringsEn.Add("exceptionDialog_info", "%appname% had to be stopped due to the following error:\r\n{0}");
		}

		public static string getString(string Id) {
			if (_stringsDe == null || _stringsEn == null)
				initializeDictionaries();

			return Thread.CurrentThread.CurrentCulture.Name.Contains("de") ? _stringsDe[Id] : _stringsEn[Id];
		}
	}
}