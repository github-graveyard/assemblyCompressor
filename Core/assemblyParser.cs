using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace assemblyCompressor.Core {
	internal class assemblyParser {
		private readonly string _mainAssembly;

		public assemblyParser(string mainAssembly) {
			_mainAssembly = mainAssembly;
		}

		public IEnumerable<assemblyInformation> getDependencies() {
			var dependencies = new List<assemblyInformation>();
			var foundLocalAssemblies = new List<string>(Directory.GetFiles(Path.GetDirectoryName(_mainAssembly), "*.dll"));
			Assembly mainAssembly = Assembly.LoadFile(_mainAssembly);

			foreach (AssemblyName assemblyname in mainAssembly.GetReferencedAssemblies()) {
				string asmName = assemblyname.FullName.Substring(0, assemblyname.FullName.IndexOf(",", System.StringComparison.Ordinal));
				foreach (string item in foundLocalAssemblies) {
					if (item.Contains(asmName)) {
						dependencies.Add(new assemblyInformation(item));
					}
				}
			}

			return dependencies;
		}
	}
}