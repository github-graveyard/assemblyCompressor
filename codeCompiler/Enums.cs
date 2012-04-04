namespace codeCompiler {
	/// <summary>
	/// Enumeration mit den möglichen Assemblytypen.
	/// </summary>
	public enum Targets {
		/// <summary>
		/// Eine Win32 Exe mit einer grafischen Oberfläche.
		/// </summary>
		Win32Exe = 0,

		/// <summary>
		/// Eine Win32 Konsolenanwendung.
		/// </summary>
		Win32ConsoleApplication,

		/// <summary>
		/// Eine Programmbibliothek.
		/// </summary>
		LinkLibrary
	}

	/// <summary>
	/// Enumeration mit den möglichen Prozessortypen in die das Assembly kompilliert werden kann.
	/// </summary>
	public enum processorTarget {
		/// <summary>
		/// Für jeden CPU Typ kompillieren (Default).
		/// </summary>
		anycpu = 0,

		/// <summary>
		/// Für 32-Bit CPUs kompillieren.
		/// </summary>
		x86 = 1,

		/// <summary>
		/// Für 64-Bit CPUs kompillieren.
		/// </summary>
		x64 = 2
	}
}