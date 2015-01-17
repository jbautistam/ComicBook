namespace Bau.Applications.ComicsBooks.Forms.Tools
{
	partial class frmLog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLog));
			this.tlbLog = new System.Windows.Forms.ToolStrip();
			this.cmdTlbSave = new System.Windows.Forms.ToolStripButton();
			this.cmdTlbClear = new System.Windows.Forms.ToolStripButton();
			this.rtfLog = new Bau.Controls.TextBox.ExRichTextBox();
			this.tlbLog.SuspendLayout();
			this.SuspendLayout();
			// 
			// tlbLog
			// 
			this.tlbLog.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tlbLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdTlbSave,
            this.cmdTlbClear});
			this.tlbLog.Location = new System.Drawing.Point(0, 0);
			this.tlbLog.Name = "tlbLog";
			this.tlbLog.Size = new System.Drawing.Size(422, 25);
			this.tlbLog.TabIndex = 0;
			this.tlbLog.Text = "toolStrip1";
			// 
			// cmdTlbSave
			// 
			this.cmdTlbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbSave.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Save;
			this.cmdTlbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbSave.Name = "cmdTlbSave";
			this.cmdTlbSave.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbSave.Text = "toolStripButton2";
			this.cmdTlbSave.ToolTipText = "Guardar";
			this.cmdTlbSave.Click += new System.EventHandler(this.cmdTlbSave_Click);
			// 
			// cmdTlbClear
			// 
			this.cmdTlbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbClear.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.cmdTlbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbClear.Name = "cmdTlbClear";
			this.cmdTlbClear.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbClear.Text = "toolStripButton1";
			this.cmdTlbClear.ToolTipText = "Limpiar";
			this.cmdTlbClear.Click += new System.EventHandler(this.cmdTlbClear_Click);
			// 
			// rtfLog
			// 
			this.rtfLog.BackColor = System.Drawing.Color.White;
			this.rtfLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.rtfLog.HighlightColor = Bau.Controls.TextBox.RtfColor.White;
			this.rtfLog.Location = new System.Drawing.Point(0, 25);
			this.rtfLog.Name = "rtfLog";
			this.rtfLog.ReadOnly = true;
			this.rtfLog.Size = new System.Drawing.Size(422, 191);
			this.rtfLog.TabIndex = 1;
			this.rtfLog.Text = "";
			this.rtfLog.TextColor = Bau.Controls.TextBox.RtfColor.Black;
			// 
			// frmLog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(422, 216);
			this.Controls.Add(this.rtfLog);
			this.Controls.Add(this.tlbLog);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLog";
			this.TabText = "Log";
			this.Text = "Log";
			this.Load += new System.EventHandler(this.frmLog_Load);
			this.tlbLog.ResumeLayout(false);
			this.tlbLog.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ToolStrip tlbLog;
		private System.Windows.Forms.ToolStripButton cmdTlbClear;
		private Bau.Controls.TextBox.ExRichTextBox rtfLog;
		private System.Windows.Forms.ToolStripButton cmdTlbSave;
	}
}