using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using codeCompiler;

namespace assemblyCompressor.Core {
	internal class commandLineUtility {
		private readonly List<KeyValuePair<string, string>> _arguments;

		public commandLineUtility(string[] arguments) {
			_arguments = new List<KeyValuePair<string, string>>();

			foreach (string item in arguments) {
				if (item.Contains(":")) {
					string key = string.Empty;
					string value = string.Empty;

					key = item.Substring(0, item.IndexOf(':'));
					value = item.Substring(item.IndexOf(':') + 1);

					_arguments.Add(new KeyValuePair<string, string>(key.Trim(), value.Trim()));
				}
				else {
					_arguments.Add(new KeyValuePair<string, string>(item.Trim(), string.Empty));
				}
			}
		}

		[DllImport("kernel32.dll")]
		private static extern Boolean AllocConsole();

		[DllImport("kernel32.dll")]
		private static extern Boolean FreeConsole();

		private void validateArguments() {
			if (!keyExists("/mainAssembly"))
				throw new missingArgumentException("/mainAssembly");

			if (!File.Exists(getValue("/mainAssembly")))
				throw new FileNotFoundException("Das Hauptassembly konnte nicht gefunden werden!", getValue("/mainAssembly"));

			if (!keyExists("/outputFile"))
				throw new missingArgumentException("/outputFile");
		}

		private bool keyExists(string key) {
			foreach (var item in _arguments) {
				if (item.Key.ToLower().Equals(key.ToLower()))
					return true;
			}
			return false;
		}

		private string getValue(string key) {
			foreach (var item in _arguments) {
				if (item.Key.ToLower().Equals(key.ToLower()))
					return item.Value;
			}
			throw new KeyNotFoundException();
		}

		/// <summary>
		/// Erstellt aus den übergebenen Kommandozeilenparemtern eine Projektdatei.
		/// </summary>
		/// <returns>Gibt eine assemblyCompressor Projektdatei zurück die an den Compiler übergeben werden kann.</returns>
		private Project createProject() {
			var proj = new Project();

			proj.mainAssembly = new assemblyInformation(getValue("/mainAssembly"));
			proj.outputPath = getValue("/outputFile");
			proj.retrieveAssemblyInformation = true;

			//Referenzen hinzufügen (falls übergeben)
			foreach (string reference in getReferences()) {
				try {
					proj.referenceAssemblies.Add(new assemblyInformation(reference));
				}
				catch (BadImageFormatException) {
					continue;
				} //Fehler abfangen, falls eine Referenz geladen wurde, welche kein .NET Assembly ist.
			}

			//Wenn vorhanden dann Schlüsseldatei anhängen
			if (keyExists("/keyFile") && File.Exists(getValue("/keyFile"))) {
				proj.signAssembly = true;
				proj.snkPath = getValue("/keyFile");
			}

			if (keyExists("/target") && !string.IsNullOrEmpty(getValue("/target"))) {
				proj.target = (processorTarget) Enum.Parse(typeof (processorTarget), getValue("/target").ToLower());
			}

			if (keyExists("/compress"))
				proj.compressFiles = true;

			if (keyExists("/iconFile") && File.Exists(getValue("/iconFile")))
				proj.customIconPath = getValue("/iconFile");

			if (keyExists("/consoleApplication"))
				proj.isConsoleApplication = true;

			return proj;
		}

		/// <summary>
		/// Gibt eine Liste mit Referenzassemblies zurück welche via Parameter übergeben wurden.
		/// </summary>
		/// <returns></returns>
		private List<string> getReferences() {
			var assemblies = new List<string>();

			for (int i = 0; i < _arguments.Count; i++) {
				if (_arguments[i].Key.ToLower().Equals("/referenceFile".ToLower()) && File.Exists(_arguments[i].Value))
					assemblies.Add(_arguments[i].Value);
				else if (_arguments[i].Key.ToLower().Equals("/referencePath".ToLower()) && Directory.Exists(_arguments[i].Value)) {
					foreach (string file in Directory.GetFiles(_arguments[i].Value, "*.dll", SearchOption.TopDirectoryOnly)) {
						if (!assemblies.Contains(file))
							assemblies.Add(file);
					}
				}
			}


			return assemblies;
		}

		public void Execute() {
			//AllocConsole();
			int exitCode = 0;
			try {
				printHeader();

				if (keyExists("/help")) //Der Benutzer möchte nur die Hilfe angezeigt bekommen
				{
					printUsage();
					return;
				}

				//Überprüfen ob alle notwendigen Argumente mitgegeben wurden
				validateArguments();

				Project project = createProject();
				var compiler = new Compiler(project);

				Console.WriteLine("Erstelle Assembly...");
				compiler.Compile();

				Console.WriteLine("Das Assembly wurde erfolgreich erstellt.");
			}
			catch (missingArgumentException msEx) {
				exitCode = -1;
				Console.WriteLine("Fehler: " + msEx.Message);

				//DEBUG
				int Counter = 1;
				foreach (var argument in _arguments) {
					Console.WriteLine("{0}: {1}->{2}", Counter.ToString(), argument.Key, argument.Value);
					Counter++;
				}

				printUsage();
			}
			catch (Exception ex) {
				exitCode = -99;
				Console.WriteLine("Es ist ein Fehler aufgetreten!");
				Console.WriteLine(ex.ToString());
			}
			finally {
				//FreeConsole();
			}
			Environment.Exit(exitCode);
		}

		private void printHeader() {
			var seperator = new string('-', 55);
			Console.WriteLine(seperator);
			Console.WriteLine("assemblyCompressor - Version {0}", Assembly.GetExecutingAssembly().GetName().Version);
			Console.WriteLine("Copyright (c) Maximilian Krauss - maximiliankrauss.net");
			Console.WriteLine(seperator);
		}

		private void printUsage() {
			Console.WriteLine("Usage: assemblyCompressor.exe /build <Required commands> [Optional commands]");
			Console.WriteLine("\tRequired commands:");
			Console.WriteLine("\t/mainAssembly:\"<Dateiname>\" - Das Hauptassembly");
			Console.WriteLine("\t/outputFile:\"<Dateiname>\" - Der Pfad zu der Ausgabedatei");

			Console.WriteLine();

			Console.WriteLine("\tOptional commands:");
			Console.WriteLine("\t/compress - Komprimiert die Assemblies");
			Console.WriteLine(
				"\t/referenceFile:\"<Dateiname>\" - Ein Referenzassembly welches eingebunden werden soll. Dieser Parameter kann mehrfach angegeben werden.");
			Console.WriteLine(
				"\treferencePath:<Verzeichnis> - Ein Verzeichnis mit Assemblies welche allesamt als Referenzen eingebunden werden sollen.");
			Console.WriteLine("\t/iconFile:\"<Dateiname>\" - Der Pfad zu einem Symbol.");
			Console.WriteLine(
				"\t/keyFile:\"<Dateiname>\" - Der Pfad zu einer Schlüsseldatei (*.snk) zum signieren des Assemblies.");
			Console.WriteLine(
				"\t/target:<Prozessortarget> - Der Prozessortyp gegen diesen Kompilliert werden soll (anycpu, x86, x64).");
			Console.WriteLine("\t/consoleApplication - Kompilliert den Loader als Konsolenanwendung.");
		}
	}
}