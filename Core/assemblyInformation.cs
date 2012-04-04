using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace assemblyCompressor.Core {
	[Serializable]
	public class assemblyInformation {
		private Assembly _assembly;

		public assemblyInformation() {
			Id = Guid.NewGuid().ToString();
		}

		public assemblyInformation(string path)
			: this() {
			Path = path;

			//Quick and dirty way to check if the File is an .NET Assembly or not.
			//TODO: Implement better solution
			_assembly = Assembly.Load(File.ReadAllBytes(path));
		}

		/// <summary>Gets or Sets the complete Path of the Assembly</summary>
		public string Path { get; set; }

		/// <summary>Returns an unique ID for this Dependency.</summary>
		public string Id { get; set; }

		/// <summary>Returns the Assembly as TreeNode.</summary>
		public TreeNode toTreeNode() {
			return toTreeNode(string.Empty);
		}

		/// <summary>Returns the Assembly as TreeNode</summary>
		/// <param name="nodeKey">A custom Name for the Nodetitle.</param>
		public TreeNode toTreeNode(string nodeKey) {
			if (_assembly == null) {
				_assembly = Assembly.LoadFile(Path);
			}
			var node = new TreeNode {
			                        	Tag = Id,
			                        	Text = _assembly.GetName().Name,
			                        	Name = string.IsNullOrEmpty(nodeKey) ? Id : nodeKey,
			                        	ImageKey = "assembly",
			                        	SelectedImageKey = "assembly"
			                        };

			//Assembly-Information
			var tnVersion = new TreeNode(string.Format("Version: {0}", _assembly.GetName().Version)) {
			                                                                                         	Name = "Version",
																										ImageKey = "Version",
																										SelectedImageKey = "Version"
			                                                                                         };
			node.Nodes.Add(tnVersion);

			var tnPbkt =
				new TreeNode(string.Format("PublicKeyToken: {0}", getPublicKeyToken(_assembly.GetName().GetPublicKeyToken()))) {
				                                                                                        	Name = "pbkt",
				                                                                                        	ImageKey = "pbkt",
				                                                                                        	SelectedImageKey = "pbkt"
				                                                                                        };
			node.Nodes.Add(tnPbkt);

			var tnFolder = new TreeNode(string.Format("Pfad: {0}", Path)) {
			                                                              	Name = "folder",
																			ImageKey = "folder",
																			SelectedImageKey = "folder"
			                                                              };
			node.Nodes.Add(tnFolder);


			return node;
		}

		private string getPublicKeyToken(byte[] pbkt) {
			var sbPbkt = new StringBuilder();
			if (pbkt.Length > 0) {
				foreach (byte b in pbkt)
					sbPbkt.Append(b.ToString("X2"));
				return sbPbkt.ToString();
			}
			return "null";
		}
	}
}