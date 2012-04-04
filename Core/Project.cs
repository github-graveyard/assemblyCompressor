using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using codeCompiler;

namespace assemblyCompressor.Core {
	[Serializable]
	public class Project {
		public Project() {
			referenceAssemblies = new assemblyCollection();
			assemblyInfo = new assemblyInfo();
			retrieveAssemblyInformation = true;
			useMainAssemblyIcon = true;
			target = processorTarget.anycpu;
		}

		#region " Properties "

		public assemblyInformation mainAssembly { get; set; }

		public assemblyInfo assemblyInfo { get; set; }

		public assemblyCollection referenceAssemblies { get; set; }

		public bool compressFiles { get; set; }

		public bool signAssembly { get; set; }

		public string snkPath { get; set; }

		public string outputPath { get; set; }

		public bool retrieveAssemblyInformation { get; set; }

		public bool useMainAssemblyIcon { get; set; }

		public string customIconPath { get; set; }

		public bool isConsoleApplication { get; set; }

		public bool enableRuntimeLimitation { get; set; }

		public bool restrictByDate { get; set; }

		public DateTime runtimeLimitationDate { get; set; }

		public processorTarget target { get; set; }

		#endregion

		#region " Methods "

		/// <summary>Loads a Project</summary>
		/// <param name="Path">The Fullpath to the Projectfile.</param>
		public static Project Load(string Path) {
			var serializer = new XmlSerializer(typeof (Project));
			using (var reader = new StreamReader(Path, Encoding.UTF8)) {
				return (Project) serializer.Deserialize(reader);
			}
		}

		/// <summary>Saves a Project.</summary>
		/// <param name="Path">The Fullpath to the Project.</param>
		public static void Save(string Path, Project instance) {
			var serializer = new XmlSerializer(typeof (Project));
			using (var writer = new StreamWriter(Path, false, Encoding.UTF8)) {
				serializer.Serialize(writer, instance);
			}
		}

		#endregion
	}
}