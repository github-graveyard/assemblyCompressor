using System.Windows.Forms;
using codeCompiler;
using System.Drawing;

namespace assemblyCompressor.UI.Forms {
	internal partial class assemblyInfoDialog : Form {
		public assemblyInfoDialog(assemblyInfo asmInfo) {
			InitializeComponent();
			base.Font = SystemFonts.MessageBoxFont;
			txtTitle.Text = asmInfo.assemblyTitle;
			txtDescription.Text = asmInfo.assemblyDescription;
			txtCompany.Text = asmInfo.assemblyCompany;
			txtProduct.Text = asmInfo.assemblyProduct;
			txtCopyright.Text = asmInfo.assemblyCopyright;
			txtTrademark.Text = asmInfo.assemblyTrademark;
			txtVersion.Text = asmInfo.Version;
		}

		public assemblyInfo getAssemblyInfo {
			get {
				var retval = new assemblyInfo {
				                              	assemblyTitle = txtTitle.Text,
				                              	assemblyDescription = txtDescription.Text,
				                              	assemblyCompany = txtCompany.Text,
				                              	assemblyProduct = txtProduct.Text,
				                              	assemblyCopyright = txtCopyright.Text,
				                              	assemblyTrademark = txtTrademark.Text,
				                              	Version = txtVersion.Text
				                              };


				return retval;
			}
		}
	}
}