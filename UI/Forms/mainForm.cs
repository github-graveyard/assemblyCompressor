using System;
using System.IO;
using System.Windows.Forms;
using assemblyCompressor.Core;
using assemblyCompressor.Properties;
using assemblyCompressor.UI.Controls;
using updateSystemDotNet.appEventArgs;
using System.Drawing;

namespace assemblyCompressor.UI.Forms {
	internal partial class mainForm : Form {
		private Project _project = new Project();

		public mainForm() {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;

			tvAssemblies.AfterSelect += tvAssemblies_AfterSelect;
			tvAssemblies.KeyDown += tvAssemblies_KeyDown;

			txtMainAssembly.DragDrop += txtMainAssembly_DragDrop;
			txtMainAssembly.DragEnter += txtMainAssembly_DragEnter;

			Shown += mainForm_Shown;

			updController.updateInstallerStarted += updController_updateInstallerStarted;
			updController.checkForUpdatesCompleted += updController_checkForUpdatesCompleted;
			updController.updateFound += updController_updateFound;

			imglAssemblies.Images.Add("version", Resources.version);
			imglAssemblies.Images.Add("dependency", Resources.dependency);
			imglAssemblies.Images.Add("assembly", Resources.assembly);
			imglAssemblies.Images.Add("pbkt", Resources.pbkt);
			imglAssemblies.Images.Add("folder", Resources.folder_16px);

			var settingsPane = new ucSettings {Name = "settings", currentProject = _project};
			settingsPane.reloadSettings();
			ctpSettings.Controls.Add(settingsPane);

			var aboutPane = new ucAbout {Name = "about"};
			ctpAbout.Controls.Add(aboutPane);

			toolStrip1.Renderer = new nativeRenderer(ToolbarTheme.Toolbar);
			Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
		}

		private void tvAssemblies_KeyDown(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Delete &&
			    tvAssemblies.SelectedNode != null &&
			    tvAssemblies.SelectedNode.Tag != null &&
			    tvAssemblies.SelectedNode.Name != "root") {
				_project.referenceAssemblies.Remove(tvAssemblies.SelectedNode.Tag.ToString());
				tvAssemblies.Nodes.Remove(tvAssemblies.SelectedNode);
			}
		}

		private void txtMainAssembly_DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) {
				e.Effect = DragDropEffects.Copy;
			}
			else {
				e.Effect = DragDropEffects.None;
			}
		}

		private void txtMainAssembly_DragDrop(object sender, DragEventArgs e) {
			var data = e.Data.GetData(DataFormats.FileDrop) as string[];
			if (data.Length > 0 && File.Exists(data[0])) {
				if (data[0].EndsWith(".exe")) {
					txtMainAssembly.Text = data[0];
					initializeNewAssembly(data[0]);
				}
			}
		}

		private void mainForm_Shown(object sender, EventArgs e) {
			btnUpdates.Enabled = false;
			updController.checkForUpdatesAsync();
		}

		private void updController_updateInstallerStarted(object sender, updateInstallerStartedEventArgs e) {
			Close();
		}

		private void tvAssemblies_AfterSelect(object sender, TreeViewEventArgs e) {
			btnRemoveAssembly.Enabled = (e.Node.Tag != null && e.Node.Name != "root");
		}

		private void btnChooseMainAssembly_Click(object sender, EventArgs e) {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = ".NET Assemblies|*.exe";
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					txtMainAssembly.Text = dlg.FileName;
					initializeNewAssembly(dlg.FileName);
				}
			}
		}

		private void initializeNewAssembly(string mainAssemblyPath) {
			var parser = new assemblyParser(mainAssemblyPath);

			_project = new Project();
			(ctpSettings.Controls["settings"] as ucSettings).currentProject = _project;
			(ctpSettings.Controls["settings"] as ucSettings).reloadSettings();
			_project.mainAssembly = new assemblyInformation(mainAssemblyPath);
			_project.assemblyInfo = Compiler.retrieveAssemblyinfo(mainAssemblyPath);
			addMainAssembly(_project.mainAssembly);

			if (
				MessageBox.Show(this, "Would you like to detect the Dependencies automatically?","assemblyCompressor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes) {
				foreach (assemblyInformation asmInfo in parser.getDependencies()) {
					if (!_project.referenceAssemblies.ContainsPath(asmInfo.Path)) {
						_project.referenceAssemblies.Add(asmInfo);
						addDependency(asmInfo);
					}
				}
			}
		}

		private void btnAddAssembly_Click(object sender, EventArgs e) {
			if (tvAssemblies.Nodes.ContainsKey("root")) {
				using (var dlg = new OpenFileDialog()) {
					dlg.Filter = ".NET Assemblies|*.exe;*.dll";
					if (dlg.ShowDialog(this) == DialogResult.OK) {
						if (!_project.referenceAssemblies.ContainsPath(dlg.FileName)) {
							var dependency = new assemblyInformation(dlg.FileName);
							_project.referenceAssemblies.Add(dependency);
							addDependency(dependency);
						}
					}
				}
			}
			else {
				MessageBox.Show(this, "Please choose the Mainassembly before you start adding dependencies.",
				                  "assemblyCompressor",
				                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private void btnRemoveAssembly_Click(object sender, EventArgs e) {
			if (tvAssemblies.SelectedNode.Tag != null) {
				_project.referenceAssemblies.Remove(tvAssemblies.SelectedNode.Tag.ToString());
				tvAssemblies.Nodes.Remove(tvAssemblies.SelectedNode);
			}
		}

		private void tsSave_Click(object sender, EventArgs e) {
			saveProject();
		}

		private bool saveProject() {
			if (_project != null) {
				using (var dlg = new SaveFileDialog()) {
					dlg.Filter = "XML Files|*.xml";
					if (dlg.ShowDialog(this) == DialogResult.OK) {
						Project.Save(dlg.FileName, _project);
						return true;
					}
				}
			}
			return false;
		}

		private void btnUpdates_Click(object sender, EventArgs e) {
			if (updController.checkForUpdatesDialog(this) == DialogResult.OK &&
			    updController.showUpdateDialog(this) == DialogResult.OK) {
					switch (MessageBox.Show(this, "Would you like to Save the Project before you apply the Update?", "assemblyCompressor", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)) {
						case DialogResult.Cancel:
							return;
						case DialogResult.Yes:
							if (!saveProject()) {
								return;
							}
							break;
					}
				if (updController.downloadUpdatesDialog(this) == DialogResult.OK) {
					updController.applyUpdate();
				}
			}
		}

		private void tsOpen_Click(object sender, EventArgs e) {
			openProject();
		}

		private void tsBuild_Click(object sender, EventArgs e) {
			if (validateProject()) {
				if (new buildDialog(_project).ShowDialog(this) == DialogResult.OK) {
					MessageBox.Show(this, "The Project has been successfully built!", "assemblyCompressor", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e) {
			throw new ArgumentException();
		}

		#region " Methods "

		private void openProject() {
			using (var dlg = new OpenFileDialog()) {
				dlg.Filter = "Xml Files|*.xml";
				if (dlg.ShowDialog(this) == DialogResult.OK) {
					openProject(dlg.FileName);
				}
			}
		}

		private void openProject(string path) {
			_project = Project.Load(path);

			addMainAssembly(_project.mainAssembly);
			txtMainAssembly.Text = _project.mainAssembly.Path;
			foreach (assemblyInformation asmInfo in _project.referenceAssemblies) {
				if(File.Exists(asmInfo.Path))
					addDependency(asmInfo);
			}

			(ctpSettings.Controls["settings"] as ucSettings).currentProject = _project;
			(ctpSettings.Controls["settings"] as ucSettings).reloadSettings();
		}

		private void addMainAssembly(assemblyInformation mainAssembly) {
			//TreeView leeren
			tvAssemblies.Nodes.Clear();

			tvAssemblies.Nodes.Add(mainAssembly.toTreeNode("root"));
			var depends = new TreeNode("Dependencies")
			              {Name = "dependencies", ImageKey = "dependency", SelectedImageKey = "dependency"};
			tvAssemblies.Nodes["root"].Nodes.Add(depends);
		}

		private void addDependency(assemblyInformation dependency) {
			tvAssemblies.Nodes["root"].Nodes["dependencies"].Nodes.Add(dependency.toTreeNode());
		}

		private bool validateProject() {
			const string messageboxTitle = "assemblyCompressor";
			if (_project.mainAssembly == null) {
				MessageBox.Show(this, "Error: You have to select a Mainassembly.", messageboxTitle, MessageBoxButtons.OK,
				                  MessageBoxIcon.Exclamation);
				return false;
			}
			if (string.IsNullOrEmpty(_project.outputPath)) {
				MessageBox.Show(this, "Error: You have to select an Outputdirectory.", messageboxTitle, MessageBoxButtons.OK,
				                  MessageBoxIcon.Exclamation);
				return false;
			}
			return true;
		}

		#endregion

		#region " Updates "

		private void updController_updateFound(object sender, updateFoundEventArgs e) {
			if (updController.showUpdateDialog(this) == DialogResult.OK &&
			    updController.downloadUpdatesDialog(this) == DialogResult.OK) {
				updController.applyUpdate();
			}
		}

		private void updController_checkForUpdatesCompleted(object sender, checkForUpdatesCompletedEventArgs e) {
			btnUpdates.Enabled = true;
		}

		#endregion
	}
}