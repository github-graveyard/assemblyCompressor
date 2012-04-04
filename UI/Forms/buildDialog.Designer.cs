namespace assemblyCompressor.UI.Forms
{
    partial class buildDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.label1 = new System.Windows.Forms.Label();
			this.prgBuild = new System.Windows.Forms.ProgressBar();
			this.bgwBuild = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Project is beeing built, please wait...";
			// 
			// prgBuild
			// 
			this.prgBuild.Location = new System.Drawing.Point(12, 32);
			this.prgBuild.Name = "prgBuild";
			this.prgBuild.Size = new System.Drawing.Size(354, 12);
			this.prgBuild.TabIndex = 1;
			// 
			// bgwBuild
			// 
			this.bgwBuild.WorkerReportsProgress = true;
			this.bgwBuild.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwBuild_DoWork);
			// 
			// buildDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(378, 53);
			this.Controls.Add(this.prgBuild);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "buildDialog";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "assemblyCompressor";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar prgBuild;
        private System.ComponentModel.BackgroundWorker bgwBuild;
    }
}