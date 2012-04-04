using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace assemblyCompressor.Core.subSystem {
	internal class dateExpiredDialog : Form {
		private Button btnClose;
		private PictureBox imgError;
		private Label label1;
		private Label label2;
		private Panel pnlContent;

		public dateExpiredDialog(DateTime expirationDate) {
			InitializeComponent();

			if (!Thread.CurrentThread.CurrentCulture.Name.Contains("de")) {
				label1.Text = "Application expired";
				label2.Text =
					"The Application couldn't start because it has been expired on {0}. Please Contact the Vendor to obtain an updated Version.";
				btnClose.Text = "Close";
			}

			imgError.Image = SystemIcons.Error.ToBitmap();
			label2.Text = string.Format(label2.Text, expirationDate.Date.ToLongDateString());
		}

		private void InitializeComponent() {
			label1 = new Label();
			imgError = new PictureBox();
			pnlContent = new Panel();
			btnClose = new Button();
			label2 = new Label();
			((ISupportInitialize) (imgError)).BeginInit();
			pnlContent.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
			label1.ForeColor = SystemColors.HotTrack;
			label1.Location = new Point(50, 12);
			label1.Name = "label1";
			label1.Size = new Size(296, 32);
			label1.TabIndex = 0;
			label1.Text = "Programm abgelaufen";
			label1.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// imgError
			// 
			imgError.Location = new Point(12, 12);
			imgError.Name = "imgError";
			imgError.Size = new Size(32, 32);
			imgError.TabIndex = 1;
			imgError.TabStop = false;
			// 
			// pnlContent
			// 
			pnlContent.BackColor = SystemColors.Control;
			pnlContent.Controls.Add(btnClose);
			pnlContent.Controls.Add(label2);
			pnlContent.Location = new Point(12, 50);
			pnlContent.Name = "pnlContent";
			pnlContent.Size = new Size(334, 147);
			pnlContent.TabIndex = 2;
			pnlContent.Paint += pnlContent_Paint;
			// 
			// btnClose
			// 
			btnClose.FlatStyle = FlatStyle.System;
			btnClose.Location = new Point(256, 121);
			btnClose.Name = "btnClose";
			btnClose.Size = new Size(75, 23);
			btnClose.TabIndex = 1;
			btnClose.Text = "Schließen";
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += btnClose_Click;
			// 
			// label2
			// 
			label2.Location = new Point(9, 6);
			label2.Name = "label2";
			label2.Size = new Size(312, 90);
			label2.TabIndex = 0;
			label2.Text = "Das Programm kann nicht mehr ausgeführt werden, da es am {0} abgelaufen ist. Wend" +
			              "en Sie sich an den Autor der Anwendung um eine aktualisierte Version zu beziehen" +
			              ".";
			// 
			// dateExpiredDialog
			// 
			BackColor = Color.White;
			ClientSize = new Size(358, 209);
			Controls.Add(pnlContent);
			Controls.Add(imgError);
			Controls.Add(label1);
			Font = new Font("Verdana", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((0)));
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "dateExpiredDialog";
			ShowInTaskbar = false;
			StartPosition = FormStartPosition.CenterScreen;
			Text = "assemblyCompressor";
			((ISupportInitialize) (imgError)).EndInit();
			pnlContent.ResumeLayout(false);
			ResumeLayout(false);
		}

		private void pnlContent_Paint(object sender, PaintEventArgs e) {
			try {
				using (Pen border = new Pen(SystemColors.ControlDark, 1)) {
					e.Graphics.DrawRectangle(
						border,
						new Rectangle(0, 0, pnlContent.Width - 1, pnlContent.Height - 1));
				}
			}
			catch {
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}
	}
}