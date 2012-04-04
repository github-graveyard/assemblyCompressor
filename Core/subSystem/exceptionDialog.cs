using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace assemblyCompressor.Core.subSystem {
	internal sealed class exceptionDialog : Form {
		private readonly string _appName = string.Empty;
		private Button btnClose;
		private PictureBox imgApplication;
		private Label label1;
		private Label lblInfo;
		private Label lblTitle;
		private Panel pnlInfo;
		private Panel pnlTop;
		private ProgressBar prgSend;
		private TextBox txtStacktrace;

		public exceptionDialog(Exception ex, string applicationName) {
			try {
				InitializeComponent();

				//Read App-Icon
				try {
					imgApplication.Image = Icon.ExtractAssociatedIcon(Assembly.GetEntryAssembly().Location).ToBitmap();
				}
				catch {
					imgApplication.Image = SystemIcons.Application.ToBitmap();
				}
				pnlTop.Paint += pnlTop_Paint;

				//Localize:
				lblTitle.Text = languageHelper.getString("exceptionDialog_title");
				lblInfo.Text = string.Format(languageHelper.getString("exceptionDialog_info"),
				                             (ex.InnerException != null ? ex.InnerException.Message : ex.Message));
				btnClose.Text = languageHelper.getString("global_close");

				_appName = string.IsNullOrEmpty(applicationName) ? languageHelper.getString("global_application") : applicationName;
			}
			catch (Exception exc) {
				MessageBox.Show(exc.ToString());
			}

			txtStacktrace.Text = ex.ToString();

			foreach (Control control in Controls)
				updateVars(control);
		}

		private void updateVars(Control c) {
			c.Text = c.Text.Replace("%appname%", _appName);
			if (c.Controls.Count > 0) {
				foreach (Control control in c.Controls)
					updateVars(control);
			}
		}

		private void pnlTop_Paint(object sender, PaintEventArgs e) {
			try {
				e.Graphics.DrawLine(
					SystemPens.ControlDark,
					new Point(0, pnlTop.Height - 1),
					new Point(pnlTop.Width, pnlTop.Height - 1));
			}
			catch {
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		#region " Windows Designer Code "

		private void InitializeComponent() {
			pnlInfo = new Panel();
			txtStacktrace = new TextBox();
			label1 = new Label();
			lblInfo = new Label();
			btnClose = new Button();
			pnlTop = new Panel();
			lblTitle = new Label();
			imgApplication = new PictureBox();
			prgSend = new ProgressBar();
			pnlInfo.SuspendLayout();
			pnlTop.SuspendLayout();
			((ISupportInitialize) (imgApplication)).BeginInit();
			SuspendLayout();
			// 
			// pnlInfo
			// 
			pnlInfo.Anchor = (((((AnchorStyles.Top | AnchorStyles.Bottom)
			                     | AnchorStyles.Left)
			                    | AnchorStyles.Right)));
			pnlInfo.BackColor = SystemColors.Control;
			pnlInfo.Controls.Add(txtStacktrace);
			pnlInfo.Controls.Add(label1);
			pnlInfo.Controls.Add(lblInfo);
			pnlInfo.Controls.Add(btnClose);
			pnlInfo.Location = new Point(12, 46);
			pnlInfo.Name = "pnlInfo";
			pnlInfo.Size = new Size(384, 203);
			pnlInfo.TabIndex = 0;
			// 
			// txtStacktrace
			// 
			txtStacktrace.Location = new Point(6, 74);
			txtStacktrace.Multiline = true;
			txtStacktrace.Name = "txtStacktrace";
			txtStacktrace.ReadOnly = true;
			txtStacktrace.ScrollBars = ScrollBars.Vertical;
			txtStacktrace.Size = new Size(375, 97);
			txtStacktrace.TabIndex = 4;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
			label1.Location = new Point(3, 58);
			label1.Name = "label1";
			label1.Size = new Size(45, 13);
			label1.TabIndex = 3;
			label1.Text = "Details:";
			// 
			// lblInfo
			// 
			lblInfo.Location = new Point(3, 0);
			lblInfo.Name = "lblInfo";
			lblInfo.Size = new Size(378, 58);
			lblInfo.TabIndex = 1;
			lblInfo.Text = "%appname% musste wegen folgendem Problem beendet werden:\r\n%exceptionMessage%";
			// 
			// btnClose
			// 
			btnClose.FlatStyle = FlatStyle.System;
			btnClose.Location = new Point(294, 177);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(87, 23);
			btnClose.TabIndex = 0;
			btnClose.Text = "Schließen";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// pnlTop
			// 
			pnlTop.BackColor = Color.White;
			pnlTop.Controls.Add(lblTitle);
			pnlTop.Controls.Add(imgApplication);
			pnlTop.Dock = DockStyle.Top;
			pnlTop.Location = new Point(0, 0);
			pnlTop.Name = "pnlTop";
			pnlTop.Padding = new Padding(0, 0, 0, 1);
			pnlTop.Size = new Size(408, 40);
			pnlTop.TabIndex = 1;
			// 
			// lblTitle
			// 
			lblTitle.Dock = DockStyle.Left;
			lblTitle.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, ((0)));
			lblTitle.Location = new Point(0, 0);
			lblTitle.Name = "lblTitle";
			lblTitle.Padding = new Padding(5, 0, 0, 0);
			lblTitle.Size = new Size(362, 39);
			lblTitle.TabIndex = 3;
			lblTitle.Text = "%appname% hat ein Problem festgestellt.";
			lblTitle.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// imgApplication
			// 
			imgApplication.BackColor = Color.White;
			imgApplication.Dock = DockStyle.Right;
			imgApplication.Location = new Point(368, 0);
			imgApplication.Name = "imgApplication";
			imgApplication.Size = new Size(40, 39);
			imgApplication.SizeMode = PictureBoxSizeMode.CenterImage;
			imgApplication.TabIndex = 2;
			imgApplication.TabStop = false;
			// 
			// prgSend
			// 
			prgSend.Location = new Point(6, 40);
			prgSend.Maximum = 50;
			prgSend.Name = "prgSend";
			prgSend.Size = new Size(360, 12);
			prgSend.Style = ProgressBarStyle.Marquee;
			prgSend.TabIndex = 1;
			// 
			// exceptionDialog
			// 
			BackColor = SystemColors.Control;
			ClientSize = new Size(408, 261);
			Controls.Add(pnlTop);
			Controls.Add(pnlInfo);
			Font = SystemFonts.MessageBoxFont;
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "exceptionDialog";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "assemblyCompressor - subSystem";
			pnlInfo.ResumeLayout(false);
			pnlInfo.PerformLayout();
			pnlTop.ResumeLayout(false);
			((ISupportInitialize) (imgApplication)).EndInit();
			ResumeLayout(false);
		}

		#endregion
	}
}