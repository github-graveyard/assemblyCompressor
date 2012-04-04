using System;
using System.Text;

namespace codeCompiler {
	/// <summary>
	/// Dateiinformationen über das Assembly welches kompilliert werden soll.
	/// </summary>
	[Serializable]
	public class assemblyInfo {
		/// <summary>
		/// Gibt den Titel des Assemblies zurück oder legt diesen fest.
		/// </summary>
		public string assemblyTitle { get; set; }

		/// <summary>
		/// Gibt die Assemblybeschreibung zurück oder legt diese fest.
		/// </summary>
		public string assemblyDescription { get; set; }

		/// <summary>
		/// Gibt die Firma zurück oder legt diese fest.
		/// </summary>
		public string assemblyCompany { get; set; }

		/// <summary>
		/// Gibt den Produktnamen des Assemblies zurück oder legt diesen fest.
		/// </summary>
		public string assemblyProduct { get; set; }

		/// <summary>
		/// Gibt den Copyrighttext des Assemblies zurück oder legt diesen fest.
		/// </summary>
		public string assemblyCopyright { get; set; }

		/// <summary>
		/// Gibt die Trademarkinformationen des Assemblies zurück oder legt diese fes
		/// </summary>
		public string assemblyTrademark { get; set; }

		/// <summary>
		/// Gibt die Version des Assemblies zurück oder legt diese fest.
		/// </summary>
		public string Version { get; set; }

		public string ToCSharpString() {
			var sbAsmInfo = new StringBuilder();
			sbAsmInfo.AppendLine("using System.Reflection;");
			sbAsmInfo.AppendLine("using System.Runtime.CompilerServices;");
			sbAsmInfo.AppendLine("using System.Runtime.InteropServices;");

			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyTitle(\"{0}\")]", assemblyTitle));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyDescription(\"{0}\")]", assemblyDescription));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyCompany(\"{0}\")]", assemblyCompany));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyProduct(\"{0}\")]", assemblyProduct));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyCopyright(\"{0}\")]", assemblyCopyright));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyTrademark(\"{0}\")]", assemblyTrademark));

			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyVersion(\"{0}\")]", Version));
			sbAsmInfo.AppendLine(string.Format("[assembly: AssemblyFileVersion(\"{0}\")]", Version));

			return sbAsmInfo.ToString();
		}

		public string ToVBString() {
			throw new NotImplementedException();
		}
	}
}