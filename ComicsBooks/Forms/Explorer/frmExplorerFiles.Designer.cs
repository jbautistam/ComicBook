namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	partial class frmExplorerFiles
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
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExplorerFiles));
		this.ctxMnuExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.mnuExplorerOpen = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerRename = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
		this.mnuExplorerCopy = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerCut = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerPaste = new System.Windows.Forms.ToolStripMenuItem();
		this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
		this.mnuExplorerDelete = new System.Windows.Forms.ToolStripMenuItem();
		this.udtFiles = new Bau.Controls.Files.TreePath();
		this.ctxMnuExplorer.SuspendLayout();
		this.SuspendLayout();
		// 
		// ctxMnuExplorer
		// 
		this.ctxMnuExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExplorerOpen,
            this.mnuExplorerRename,
            this.toolStripMenuItem1,
            this.mnuExplorerCopy,
            this.mnuExplorerCut,
            this.mnuExplorerPaste,
            this.toolStripMenuItem2,
            this.mnuExplorerDelete});
		this.ctxMnuExplorer.Name = "ctxMnuExplorer";
		this.ctxMnuExplorer.Size = new System.Drawing.Size(164, 148);
		this.ctxMnuExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuExplorer_Opening);
		// 
		// mnuExplorerOpen
		// 
		this.mnuExplorerOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
		this.mnuExplorerOpen.Name = "mnuExplorerOpen";
		this.mnuExplorerOpen.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerOpen.Text = "&Abrir";
		this.mnuExplorerOpen.Click += new System.EventHandler(this.mnuExplorerOpen_Click);
		// 
		// mnuExplorerRename
		// 
		this.mnuExplorerRename.Name = "mnuExplorerRename";
		this.mnuExplorerRename.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerRename.Text = "Cambiar &nombre";
		this.mnuExplorerRename.Click += new System.EventHandler(this.mnuExplorerRename_Click);
		// 
		// toolStripMenuItem1
		// 
		this.toolStripMenuItem1.Name = "toolStripMenuItem1";
		this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
		// 
		// mnuExplorerCopy
		// 
		this.mnuExplorerCopy.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Copy;
		this.mnuExplorerCopy.Name = "mnuExplorerCopy";
		this.mnuExplorerCopy.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerCopy.Text = "&Copiar";
		this.mnuExplorerCopy.Click += new System.EventHandler(this.mnuExplorerCopy_Click);
		// 
		// mnuExplorerCut
		// 
		this.mnuExplorerCut.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Cut;
		this.mnuExplorerCut.Name = "mnuExplorerCut";
		this.mnuExplorerCut.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerCut.Text = "C&ortar";
		this.mnuExplorerCut.Click += new System.EventHandler(this.mnuExplorerCut_Click);
		// 
		// mnuExplorerPaste
		// 
		this.mnuExplorerPaste.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Paste;
		this.mnuExplorerPaste.Name = "mnuExplorerPaste";
		this.mnuExplorerPaste.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerPaste.Text = "&Pegar";
		this.mnuExplorerPaste.Click += new System.EventHandler(this.mnuExplorerPaste_Click);
		// 
		// toolStripMenuItem2
		// 
		this.toolStripMenuItem2.Name = "toolStripMenuItem2";
		this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
		// 
		// mnuExplorerDelete
		// 
		this.mnuExplorerDelete.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
		this.mnuExplorerDelete.Name = "mnuExplorerDelete";
		this.mnuExplorerDelete.Size = new System.Drawing.Size(163, 22);
		this.mnuExplorerDelete.Text = "&Eliminar";
		this.mnuExplorerDelete.Click += new System.EventHandler(this.mnuExplorerDelete_Click);
		// 
		// udtFiles
		// 
		this.udtFiles.BasePath = null;
		this.udtFiles.CanEditNames = true;
		this.udtFiles.ContextMenuStrip = this.ctxMnuExplorer;
		this.udtFiles.Dock = System.Windows.Forms.DockStyle.Fill;
		this.udtFiles.Location = new System.Drawing.Point(0, 0);
		this.udtFiles.Mask = "*.*";
		this.udtFiles.Name = "udtFiles";
		this.udtFiles.Path = null;
		this.udtFiles.ShowFiles = true;
		this.udtFiles.Size = new System.Drawing.Size(372, 541);
		this.udtFiles.TabIndex = 0;
		this.udtFiles.FileSelected += new System.EventHandler<Bau.Controls.Files.Events.clsFileEventArgs>(this.udtFiles_FileSelected);
		this.udtFiles.FileDoubleClick += new System.EventHandler<Bau.Controls.Files.Events.clsFileEventArgs>(this.udtFiles_FileDoubleClick);
		// 
		// frmExplorerFiles
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(372, 541);
		this.Controls.Add(this.udtFiles);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
		this.Name = "frmExplorerFiles";
		this.TabText = "Explorador de archivos";
		this.Text = "Explorador de archivos";
		this.Load += new System.EventHandler(this.frmPluginsExplorer_Load);
		this.ctxMnuExplorer.ResumeLayout(false);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip ctxMnuExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerRename;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerCopy;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerCut;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerPaste;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDelete;
		private Bau.Controls.Files.TreePath udtFiles;


	}
}