using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing.IconLib;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Resources;
using System.Text;
using System.Xml;
using assemblyCompressor.Properties;
using codeCompiler;

namespace assemblyCompressor.Core {
	internal delegate void compilerProgessChangedEventHandler(object sender, compilerProgressChangedEventArgs e);

	internal class Compiler : IDisposable {
		private const int _compilerActions = 3;
		private readonly Project _project;
		private readonly string _tempFoder;

		public Compiler(Project project) {
			_project = project;

			//Temporäres Verzeichnis erstellen
			_tempFoder = Path.Combine(Environment.GetEnvironmentVariable("TMP"), "assemblyCompressor");
			if (!Directory.Exists(_tempFoder)) {
				Directory.CreateDirectory(_tempFoder);
			}
		}

		#region IDisposable Members

		public void Dispose() {
			if (Directory.Exists(_tempFoder)) {
				Directory.Delete(_tempFoder, true);
			}
		}

		#endregion

		public event compilerProgessChangedEventHandler compilerProgressChanged;

		public void Compile() {
			createXmlMap();
			createResourcefile();
			compileLoader();
		}

		private int Percent(double currentValue, double maximumValue) {
			return (int) (((currentValue/(maximumValue))*100.0));
		}

		private void sendActionProgress(int actionIndex, int actionPercentDone) {
			int percentDone = Percent(
				actionPercentDone + (actionIndex*100),
				(_compilerActions*100));
			if (compilerProgressChanged != null)
				compilerProgressChanged(this, new compilerProgressChangedEventArgs(percentDone));
		}

		internal static assemblyInfo retrieveAssemblyinfo(string file) {
			FileVersionInfo fviMain = FileVersionInfo.GetVersionInfo(file);
			var retval = new assemblyInfo();
			retval.assemblyCompany = fviMain.CompanyName;
			retval.assemblyCopyright = fviMain.LegalCopyright;
			retval.assemblyDescription = fviMain.Comments;
			retval.assemblyProduct = fviMain.ProductName;
			retval.assemblyTitle = fviMain.ProductName;
			retval.assemblyTrademark = fviMain.LegalTrademarks;
			retval.Version = fviMain.ProductVersion;
			GC.Collect();
			return retval;
		}

		#region CreateMap

		private void createXmlMap() {
			sendActionProgress(0, 0);
			var xMap = new XmlDocument();
			XmlNode xRoot = xMap.CreateElement("assemblyCompressor");

			//Einstellungen speichern
			XmlNode xSettings = xMap.CreateElement("Settings");

			//Compression
			XmlNode xCompression = xMap.CreateElement("Compressed");
			xCompression.InnerText = _project.compressFiles.ToString(CultureInfo.InvariantCulture);
			xSettings.AppendChild(xCompression);

			//Runtime Limitation
			XmlNode xRuntimeLimitation = xMap.CreateElement("enableRuntimeLimitation");
			xRuntimeLimitation.InnerText = _project.enableRuntimeLimitation.ToString(CultureInfo.InvariantCulture);
			xSettings.AppendChild(xRuntimeLimitation);

			//ExpirationDate
			XmlNode xRuntimeLimitationDate = xMap.CreateElement("runtimeLimitationDate");
			xRuntimeLimitationDate.InnerText = _project.runtimeLimitationDate.ToString("dd.MM.yyyy", new CultureInfo("de-de"));
			xSettings.AppendChild(xRuntimeLimitationDate);

			xRoot.AppendChild(xSettings);

			//Assemblies speichern
			XmlNode xAssemblies = xMap.CreateElement("Assemblies");

			//MainAssembly
			XmlNode xMainAssembly = xMap.CreateElement("mainAssembly");

			XmlNode xMainId = xMap.CreateElement("Id");
			xMainId.InnerText = _project.mainAssembly.Id;
			xMainAssembly.AppendChild(xMainId);

			//Dependencies
			XmlNode xDependencies = xMap.CreateElement("Dependencies");
			foreach (assemblyInformation dependency in _project.referenceAssemblies) {
				XmlNode xItem = xMap.CreateElement("Item");

				XmlAttribute attName = xMap.CreateAttribute("Name");
				attName.InnerText = Path.GetFileNameWithoutExtension(dependency.Path);
				xItem.Attributes.Append(attName);

				XmlAttribute attId = xMap.CreateAttribute("Id");
				attId.InnerText = dependency.Id;
				xItem.Attributes.Append(attId);

				xDependencies.AppendChild(xItem);
			}

			xMainAssembly.AppendChild(xDependencies);
			xAssemblies.AppendChild(xMainAssembly);
			xRoot.AppendChild(xAssemblies);
			xMap.AppendChild(xRoot);

			//Speichern
			using (var writer = new StreamWriter(Path.Combine(_tempFoder, "map.xml"), false, Encoding.UTF8)) {
				xMap.Save(writer);
				writer.Flush();
			}
			sendActionProgress(0, 100);
		}

		#endregion

		#region CreateResources

		private void createResourcefile() {
			sendActionProgress(1, 0);
			using (var fsResources = new FileStream(Path.Combine(_tempFoder, "data.ac.resources"), FileMode.Create)) {
				using (var writer = new ResourceWriter(fsResources)) {
					//Map hinzufügen
					sendActionProgress(1, 1);
					writer.AddResource("map.xml", File.ReadAllBytes(Path.Combine(_tempFoder, "map.xml")));

					//MainAssembly hinzufügen
					if (_project.compressFiles) {
						writer.AddResource(_project.mainAssembly.Id, compress(File.ReadAllBytes(_project.mainAssembly.Path)));
					}
					else {
						writer.AddResource(_project.mainAssembly.Id, File.ReadAllBytes(_project.mainAssembly.Path));
					}
					sendActionProgress(1, 2);

					//Dependencies hinzufügen
					int counter = 0;
					foreach (assemblyInformation dependency in _project.referenceAssemblies) {
						if (_project.compressFiles) {
							writer.AddResource(dependency.Id, compress(File.ReadAllBytes(dependency.Path)));
						}
						else {
							writer.AddResource(dependency.Id, File.ReadAllBytes(dependency.Path));
						}
						counter++;
						sendActionProgress(1,
						                   Percent(counter, _project.referenceAssemblies.Count) - 2);
					}

					writer.Generate();
					writer.Close();
				}
			}
		}

		private byte[] compress(byte[] data) {
			byte[] bufferWrite;
			MemoryStream msSource;
			MemoryStream msDest;
			GZipStream gzCompressed;
			msSource = new MemoryStream(data);

			bufferWrite = new byte[msSource.Length];
			msSource.Read(bufferWrite, 0, bufferWrite.Length);
			msDest = new MemoryStream();

			gzCompressed = new GZipStream(msDest, CompressionMode.Compress, true);

			gzCompressed.Write(bufferWrite, 0, bufferWrite.Length);

			msSource.Close();
			gzCompressed.Close();
			msDest.Close();

			return msDest.ToArray();
		}

		#endregion

		#region CompileLoader

		private void compileLoader() {
			sendActionProgress(2, 0);
			var compiler = new CSharpCodeCompiler();

			//Verweise hinzufügen
			compiler.References.AddRange(new[] {
			                                   	"System.dll",
			                                   	"System.Drawing.dll",
			                                   	"System.Data.dll",
			                                   	"System.Windows.Forms.dll",
			                                   	"System.Xml.dll",
			                                   	"System.Management.dll"
			                                   });

			assemblyInfo asmInfo = _project.retrieveAssemblyInformation
			                       	? retrieveAssemblyinfo(_project.mainAssembly.Path)
			                       	: _project.assemblyInfo;

			compiler.codeFiles.AddRange(new[] {
			                                  	Resources.appLuncher,
			                                  	Resources.exceptionDialog,
			                                  	Resources.dateExpiredDialog,
			                                  	Resources.languageHelper,
			                                  	asmInfo.ToCSharpString()
			                                  });
			compiler.processorTarget = _project.target;
			if (!_project.useMainAssemblyIcon && File.Exists(_project.customIconPath)) {
				File.Copy(_project.customIconPath, Path.Combine(_tempFoder, "app.ico"));
				compiler.IconPath = Path.Combine(_tempFoder, "app.ico");
			}
			else {
				try {
					//Icon extrahieren und speichern
					var mIcon = new MultiIcon();
					mIcon.Load(_project.mainAssembly.Path);
					mIcon.Save(Path.Combine(_tempFoder, "app.ico"), MultiIconFormat.ICO);
					compiler.IconPath = Path.Combine(_tempFoder, "app.ico");
				}
				catch {
				}
			}


			if (_project.signAssembly && !string.IsNullOrEmpty(_project.snkPath)) {
				compiler.keyFile = _project.snkPath;
			}
			compiler.generateInMemory = false;
			compiler.generateExecutable = true;

			if (!_project.isConsoleApplication) {
				compiler.Target = Targets.Win32Exe;
			}
			else {
				compiler.Target = Targets.Win32ConsoleApplication;
			}

			compiler.destinationFile = _project.outputPath;
			compiler.embeddedResources.Add(Path.Combine(_tempFoder, "data.ac.resources"));
			compiler.compilerFinished += compiler_compilerFinished;
			compiler.Compile();
			sendActionProgress(2, 100);
		}

		private void compiler_compilerFinished(object sender, compilerFinishedEventArgs e) {
			if (!e.Success) {
				var cpError = new StringBuilder();
				foreach (CompilerError error in e.CompilerResults.Errors) {
					cpError.AppendLine(error.ErrorNumber + ": " + error.ErrorText);
				}
				throw new Exception(string.Format("Das Projekt konnte wegen folgendem Fehler(n) nicht erstellt werden\r\n{0}",
				                                  cpError));
			}
		}

		#endregion
	}
}