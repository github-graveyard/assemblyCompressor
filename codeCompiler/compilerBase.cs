using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace codeCompiler {
	/// <summary>
	/// Basisklasse für den C# und VB Codecompiler
	/// </summary>
	public abstract class compilerBase : IDisposable {
		/// <summary>
		/// Initialisiert eine neue Instanz der <see cref="compilerBase"/>.
		/// </summary>
		public compilerBase() {
			References = new List<string>();
			codeFiles = new List<string>();
			embeddedResources = new List<string>();
			assemblyInformation = new assemblyInfo();
			processorTarget = processorTarget.anycpu;
		}

		/// <summary>
		/// Legt die Referenzen für das Assembly fest oder gibt diese zurück.
		/// </summary>
		public List<string> References { get; set; }

		/// <summary>
		/// Gibt die Codedateien an aus welchen das Assembly kompilliert werden soll zurück oder legt diese fest.
		/// </summary>
		public List<string> codeFiles { get; set; }

		/// <summary>
		/// Gibt die Pfade zu den Dateien zurück die in das Assembly eingebettet werden sollen oder legt diese fest.
		/// </summary>
		public List<string> embeddedResources { get; set; }

		/// <summary>
		/// <para>Gibt den Pfad für des Icons für das Assembly an oder legt diesen fest.</para>
		/// <para>Wird nur berücksichtigt wenn als Ausgabetyp <see cref="Targets.Win32Exe"/> oder <see cref="Targets.Win32ConsoleApplication"/> ausgewählt wurde.</para>
		/// </summary>
		public string IconPath { get; set; }


		/// <summary>
		/// Gibt den vollständigen Pfad zu dem Assembly zurück oder legt diesen fest.
		/// </summary>
		public string destinationFile { get; set; }

		/// <summary>
		/// Gibt den Pfad zu der Schlüsseldatei zurück, welche den starken Namen für das Assembly ethält oder legt diesen fest.
		/// </summary>
		public string keyFile { get; set; }

		/// <summary>
		/// Gibt den Zieltype das Assemblies zurück oder legt diesen fest.
		/// </summary>
		public Targets Target { get; set; }

		/// <summary>
		/// Legt den Prozessortyp fest, gegen diesen die Assembly kompilliert werden soll.
		/// </summary>
		public processorTarget processorTarget { get; set; }

		/// <summary>
		/// Gibt an oder legt fest, ob das Assembly auf der Festplatte erzeugt werden soll.
		/// </summary>
		public bool generateExecutable { get; set; }

		/// <summary>
		/// Gibt an oder legt fest, ob das Assembly im Arbeitsspeicher kompilliert werden soll.
		/// </summary>
		public bool generateInMemory { get; set; }

		/// <summary>
		/// Gibt die Dateiinformationen für das neue Assembly zurück oder legt diese fest.
		/// </summary>
		public assemblyInfo assemblyInformation { get; set; }

		#region " Protected "

		/// <summary>
		/// Gibt das Temporäre Verzeichnis für den Kompillierungsvorgang zurück oder legt dieses fest.
		/// </summary>
		protected string tempDirectory { get; set; }

		/// <summary>
		/// Erstellt aus den angegebenen Informationen Parameter für den CodeDOM-Provider.
		/// </summary>
		/// <returns>Gibt ein Objekt vom Typ CompilerParameters zurück welches an den CodeDOM-Provider übergeben werden muss.</returns>
		protected CompilerParameters buildCompilerParameters() {
			var result = new CompilerParameters();

			tempDirectory = Path.Combine(Environment.GetEnvironmentVariable("TEMP"), "codeCompiler");
			if (!Directory.Exists(tempDirectory)) {
				Directory.CreateDirectory(tempDirectory);
			}

			var compilerOptions = new List<string>();

			//Compileroptionen erstellen
			//Anwendungsziel
			string cpTarget = "exe";
			switch (Target) {
				case Targets.Win32Exe:
					cpTarget = "winexe";
					break;
				case Targets.LinkLibrary:
					cpTarget = "library";
					break;
			}
			compilerOptions.Add(string.Format("/target:{0}", cpTarget));

			//Zielarchitektur hinzufügen
			compilerOptions.Add(string.Format("/platform:{0}", processorTarget.ToString()));

			//Anwendungssymbol
			if (!string.IsNullOrEmpty(IconPath) && Target != Targets.LinkLibrary) {
				File.Copy(IconPath, Path.Combine(tempDirectory, "app.ico"), true);
				compilerOptions.Add(string.Format("/win32icon:\"{0}\"", Path.Combine(tempDirectory, "app.ico")));
			}

			//Schlüsseldatei (StrongNameKey)
			if (!string.IsNullOrEmpty(keyFile)) {
				compilerOptions.Add(string.Format("/keyfile:\"{0}\"", keyFile));
			}

			var sbCompilerItems = new StringBuilder();
			for (int i = 0; i < compilerOptions.Count; i++) {
				sbCompilerItems.Append(string.Format("{0}{1}", compilerOptions[i], (i == (compilerOptions.Count - 1) ? "" : " ")));
			}

			result.CompilerOptions = sbCompilerItems.ToString();

			result.TreatWarningsAsErrors = false;
			result.GenerateExecutable = generateExecutable;
			result.GenerateInMemory = generateInMemory;

			/*
             Eingebette Resourcen hinzufügen.
             Funktioniert nur mit Dateien, deshalb werden hier Strings mit den Dateinamen übergeben.
            */
			foreach (string embdItem in embeddedResources) {
				result.EmbeddedResources.Add(embdItem);
			}

			//Referenzen hinzufügen. (z.B.: System.Windows, System)
			foreach (string referenceItem in References) {
				result.ReferencedAssemblies.Add(referenceItem);
			}

			if (generateExecutable) {
				result.OutputAssembly = destinationFile;
			}

			return result;
		}

		/// <summary>
		/// Löst das <see cref="compilerFinished"/>-Event aus.
		/// </summary>
		/// <param name="e">Die EventArgs die an das Event übergeben werden sollen.</param>
		protected void onCompilerFinished(compilerFinishedEventArgs e) {
			if (compilerFinished != null)
				compilerFinished(this, e);
		}

		#endregion

		#region IDisposable Members

		/// <summary>
		/// Entfernt das Temporäre Verzeichnis.
		/// </summary>
		public void Dispose() {
			if (Directory.Exists(tempDirectory)) {
				Directory.Delete(tempDirectory, true);
			}
		}

		#endregion

		/// <summary>
		/// Event welches ausgelöst wird, wenn der Codecompiler fertig ist.
		/// </summary>
		public event compilerFinishedEventHandler compilerFinished;

		/// <summary>
		/// Startet den Kompillierungsvorgang.
		/// </summary>
		public abstract void Compile();
	}
}