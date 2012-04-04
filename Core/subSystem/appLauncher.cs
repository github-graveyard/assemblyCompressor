using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace assemblyCompressor.Core.subSystem {
	internal class appLauncher {
		[STAThread]
		private static void Main(string[] args) {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			try {
				using (applicationContext context = new applicationContext(args)) {
					Environment.Exit(context.executeApplication());
				}
			}
			catch (Exception ex) {
				using (exceptionDialog exDlg = new exceptionDialog(ex, string.Empty)) {
					exDlg.ShowDialog();
					Environment.Exit(-99);
				}
			}
		}
	}

	internal class applicationContext : IDisposable {
		#region " SubClasses "

		private class subSystemSettings {
			private string _mainId = string.Empty;
			private Dictionary<string, string> _references = new Dictionary<string, string>();
			private bool _isCompressed;
			private bool _enableRuntimeLimitation;
			private DateTime _runtimeLimitationDate;

			/// <summary>
			/// Returns if the Resourcefiles are compressed or not.
			/// </summary>
			public bool isCompressed { get { return _isCompressed; } set { _isCompressed = value; } }

			/// <summary>Dictionary with all embedded References. They will be used on-demand.</summary>
			public Dictionary<string, string> References {
				get { return _references; }
				set { _references = value; }
			}

			/// <summary>Returns the ID of the Mainassembly.</summary>
			public string mainId {
				get { return _mainId; }
				set { _mainId = value; }
			}

			/// <summary>Returns true if the Runtime is limited by Date. It like the "Best before" for Apps.</summary>
			public bool enableRuntimeLimitation { get { return _enableRuntimeLimitation; } set { _enableRuntimeLimitation = value; } }

			/// <summary>Returns the expirationdate.</summary>
			public DateTime runtimeLimitationDate { get { return _runtimeLimitationDate; } set { _runtimeLimitationDate = value; } }
		}

		#endregion

		#region Private Fields

		private readonly string[] _arguments;
		private ResourceManager _resourceManager;
		private subSystemSettings _settings;

		#endregion

		public applicationContext(string[] args) {
			_arguments = args;
			readSettings();
		}

		#region " Helpermethods "

		/// <summary>
		/// Liest Daten aus dem Resourcenpaket des Loaders aus.
		/// </summary>
		/// <param name="Id">Die ID der Daten in der Resourcendatei.</param>
		/// <returns></returns>
		public byte[] readData(string Id) {
			if (_resourceManager == null) {
				_resourceManager = new ResourceManager("data.ac", Assembly.GetExecutingAssembly());
			}

			byte[] data = (_resourceManager.GetObject(Id) as byte[]);

			if (_settings.isCompressed && !Id.Equals("map.xml")) {
				data = decompress(data);
			}

			return data;
		}

		/// <summary>
		/// Dekomprimiert ein Bytearray.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		private byte[] decompress(byte[] data) {
			byte[] bufferWrite;
			MemoryStream msSource;
			MemoryStream msDest;
			GZipStream gzDecompressed;
			msSource = new MemoryStream(data);
			gzDecompressed = new GZipStream(msSource, CompressionMode.Decompress, true);

			bufferWrite = new byte[4];
			msSource.Position = (int) msSource.Length - 4;
			msSource.Read(bufferWrite, 0, 4);
			msSource.Position = 0;
			int bufferLength = BitConverter.ToInt32(bufferWrite, 0);

			byte[] buffer = new byte[bufferLength + 100];
			int readOffset = 0;
			int totalBytes = 0;

			while (true) {
				int bytesRead = gzDecompressed.Read(buffer, readOffset, 100);

				if (bytesRead == 0)
					break;

				readOffset += bytesRead;
				totalBytes += bytesRead;
			}

			msDest = new MemoryStream();
			msDest.Write(buffer, 0, totalBytes);

			msSource.Close();
			gzDecompressed.Close();
			msDest.Close();

			return msDest.ToArray();
		}

		#endregion

		#region " Settings auslesen "

		/// <summary>
		/// Ließt sie Einstellungen und Abhängigkeiten aus der Map.xml aus den Resourcen der Anwendung.
		/// </summary>
		private void readSettings() {
			_settings = new subSystemSettings();

			using (MemoryStream msXml = new MemoryStream(readData("map.xml"))) {
				using (StreamReader reader = new StreamReader(msXml, Encoding.UTF8)) {
					XmlDocument xMap = new XmlDocument();
					xMap.Load(reader);

					//Einstellungen auslesen
					_settings.isCompressed = bool.Parse(xMap.SelectSingleNode("assemblyCompressor/Settings/Compressed").InnerText);

					//MainAssembly auslesen
					_settings.mainId = xMap.SelectSingleNode("assemblyCompressor/Assemblies/mainAssembly/Id").InnerText;

					_settings.enableRuntimeLimitation =
						bool.Parse(xMap.SelectSingleNode("assemblyCompressor/Settings/enableRuntimeLimitation").InnerText);

					_settings.runtimeLimitationDate = DateTime.Parse(
						xMap.SelectSingleNode("assemblyCompressor/Settings/runtimeLimitationDate").InnerText, new CultureInfo("de-de"));


					//Dependencies auslesen
					foreach (XmlNode dependency in xMap.SelectNodes("assemblyCompressor/Assemblies/mainAssembly/Dependencies/Item")) {
						if (!_settings.References.ContainsKey(dependency.Attributes["Name"].InnerText)) {
							_settings.References.Add(
								dependency.Attributes["Name"].InnerText,
								dependency.Attributes["Id"].InnerText
								);
						}
					}

					xMap = null;
				}
			}
		}

		#endregion

		#region IDisposable Members

		public void Dispose() {
			_settings.References.Clear();
			_settings.References = null;
			_resourceManager = null;
		}

		#endregion

		public int executeApplication() {
			string appName = string.Empty;
			try {
				//Exceptionevents abonieren
				Application.ThreadException += Application_ThreadException;
				AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

				//Resolveevents abonieren
				AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
				AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_AssemblyResolve;
				AppDomain.CurrentDomain.ResourceResolve += CurrentDomain_AssemblyResolve;
				AppDomain.CurrentDomain.TypeResolve += CurrentDomain_AssemblyResolve;

				if (_settings.enableRuntimeLimitation && DateTime.Now >= _settings.runtimeLimitationDate) {
					using (dateExpiredDialog dexDialog = new dateExpiredDialog(_settings.runtimeLimitationDate)) {
						dexDialog.ShowDialog();
					}
				}
				else {
					Assembly assemblyMain = Assembly.Load(readData(_settings.mainId));
					appName = assemblyMain.GetName().Name;
					MethodInfo methodInfoMain = assemblyMain.EntryPoint;
					ParameterInfo[] parameterInfoArguments = methodInfoMain.GetParameters();

					object[] oaArs = null;
					if (parameterInfoArguments.Length > 0) {
						oaArs = new object[] {_arguments};
					}

					object objRetVal = methodInfoMain.Invoke(null, oaArs);
					if (objRetVal != null) {
						int result = 0;
						int.TryParse(objRetVal.ToString(), out result);
						return result;
					}
				}
				return 0;
			}
			catch (Exception ex) //Fehler abfangen und Errordialog anzeigen
			{
				using (
					exceptionDialog exDlg = new exceptionDialog(ex, appName)) {
					exDlg.ShowDialog();
				}
				return -99; //Fehlercode zurückgeben
			}
		}

		#region " Resolveevent "

		private Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args) {
			foreach (KeyValuePair<string,string> item in _settings.References) {
				if (args.Name.Contains(item.Key)) {
					return Assembly.Load(readData(item.Value));
				}
			}
			return null;
		}

		#endregion

		#region " Exceptionevents "

		private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
			throw (e.ExceptionObject as Exception);
		}

		private void Application_ThreadException(object sender, ThreadExceptionEventArgs e) {
			throw e.Exception;
		}

		#endregion
	}

	#region " Branding "

	public sealed class PoweredByAssemblyCompressor {
		public const string Website = "http://maximiliankrauss.net";
	}

	#endregion
}