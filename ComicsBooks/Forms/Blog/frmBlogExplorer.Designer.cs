namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	partial class frmBlogExplorer
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBlogExplorer));
		this.ctxMnuExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.mnuExplorerNewFolder = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerNewFile = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerProperties = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerOpen = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerRename = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerSeparator = new System.Windows.Forms.ToolStripSeparator();
		this.mnuExplorerDownload = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerSeparatorEntries = new System.Windows.Forms.ToolStripSeparator();
		this.mnuExplorerDisabled = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuExplorerDelete = new System.Windows.Forms.ToolStripMenuItem();
		this.udtExplorer = new Bau.Applications.ComicsBooks.Forms.Blog.UC.ctlTreeBlogs();
		this.ctxMnuExplorer.SuspendLayout();
		this.SuspendLayout();
		// 
		// ctxMnuExplorer
		// 
		this.ctxMnuExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExplorerNewFolder,
            this.mnuExplorerNewFile,
            this.mnuExplorerProperties,
            this.mnuExplorerOpen,
            this.mnuExplorerRename,
            this.mnuExplorerSeparator,
            this.mnuExplorerDownload,
            this.mnuExplorerSeparatorEntries,
            this.mnuExplorerDisabled,
            this.mnuExplorerDelete});
		this.ctxMnuExplorer.Name = "ctxMnuExplorer";
		this.ctxMnuExplorer.Size = new System.Drawing.Size(165, 192);
		this.ctxMnuExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuExplorer_Opening);
		// 
		// mnuExplorerNewFolder
		// 
		this.mnuExplorerNewFolder.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
		this.mnuExplorerNewFolder.Name = "mnuExplorerNewFolder";
		this.mnuExplorerNewFolder.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerNewFolder.Text = "Nueva ca&tegoría";
		this.mnuExplorerNewFolder.Click += new System.EventHandler(this.mnuExplorerNewFolder_Click);
		// 
		// mnuExplorerNewFile
		// 
		this.mnuExplorerNewFile.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewDocument;
		this.mnuExplorerNewFile.Name = "mnuExplorerNewFile";
		this.mnuExplorerNewFile.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerNewFile.Text = "N&uevo blog";
		this.mnuExplorerNewFile.Click += new System.EventHandler(this.mnuExplorerNewFile_Click);
		// 
		// mnuExplorerProperties
		// 
		this.mnuExplorerProperties.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Properties;
		this.mnuExplorerProperties.Name = "mnuExplorerProperties";
		this.mnuExplorerProperties.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerProperties.Text = "&Propiedades";
		this.mnuExplorerProperties.Click += new System.EventHandler(this.mnuExplorerProperties_Click);
		// 
		// mnuExplorerOpen
		// 
		this.mnuExplorerOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
		this.mnuExplorerOpen.Name = "mnuExplorerOpen";
		this.mnuExplorerOpen.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerOpen.Text = "&Abrir";
		this.mnuExplorerOpen.Click += new System.EventHandler(this.mnuExplorerOpen_Click);
		// 
		// mnuExplorerRename
		// 
		this.mnuExplorerRename.Name = "mnuExplorerRename";
		this.mnuExplorerRename.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerRename.Text = "Cambiar &nombre";
		this.mnuExplorerRename.Click += new System.EventHandler(this.mnuExplorerRename_Click);
		// 
		// mnuExplorerSeparator
		// 
		this.mnuExplorerSeparator.Name = "mnuExplorerSeparator";
		this.mnuExplorerSeparator.Size = new System.Drawing.Size(161, 6);
		// 
		// mnuExplorerDownload
		// 
		this.mnuExplorerDownload.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Process;
		this.mnuExplorerDownload.Name = "mnuExplorerDownload";
		this.mnuExplorerDownload.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerDownload.Text = "&Descargar";
		this.mnuExplorerDownload.Click += new System.EventHandler(this.mnuExplorerDownload_Click);
		// 
		// mnuExplorerSeparatorEntries
		// 
		this.mnuExplorerSeparatorEntries.Name = "mnuExplorerSeparatorEntries";
		this.mnuExplorerSeparatorEntries.Size = new System.Drawing.Size(161, 6);
		// 
		// mnuExplorerDisabled
		// 
		this.mnuExplorerDisabled.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.AddNodeSibling;
		this.mnuExplorerDisabled.Name = "mnuExplorerDisabled";
		this.mnuExplorerDisabled.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerDisabled.Text = "&Inhabilitar";
		this.mnuExplorerDisabled.Click += new System.EventHandler(this.mnuExplorerDisabled_Click);
		// 
		// mnuExplorerDelete
		// 
		this.mnuExplorerDelete.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
		this.mnuExplorerDelete.Name = "mnuExplorerDelete";
		this.mnuExplorerDelete.Size = new System.Drawing.Size(164, 22);
		this.mnuExplorerDelete.Text = "&Eliminar";
		this.mnuExplorerDelete.Click += new System.EventHandler(this.mnuExplorerDelete_Click);
		// 
		// udtExplorer
		// 
		this.udtExplorer.ContextMenuStrip = this.ctxMnuExplorer;
		this.udtExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.udtExplorer.Location = new System.Drawing.Point(0, 0);
		this.udtExplorer.Name = "udtExplorer";
		this.udtExplorer.Size = new System.Drawing.Size(372, 541);
		this.udtExplorer.TabIndex = 1;
		this.udtExplorer.DoubleClickBlog += new Bau.Applications.ComicsBooks.Forms.Blog.UC.ctlTreeBlogs.DoubleClickBlogHandler(this.udtExplorer_DoubleClickFile);
		this.udtExplorer.RemoveNodeRequired += new Bau.Applications.ComicsBooks.Forms.Blog.UC.ctlTreeBlogs.RemoveNodeRequiredHandler(this.udtExplorer_RemoveNodeRequired);
		// 
		// frmBlogExplorer
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(372, 541);
		this.Controls.Add(this.udtExplorer);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
		this.Name = "frmBlogExplorer";
		this.TabText = "Blogs";
		this.Text = "Blogs";
		this.Load += new System.EventHandler(this.frmPluginsExplorer_Load);
		this.ctxMnuExplorer.ResumeLayout(false);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip ctxMnuExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerRename;
		private System.Windows.Forms.ToolStripSeparator mnuExplorerSeparator;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDelete;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerNewFolder;
		private Bau.Applications.ComicsBooks.Forms.Blog.UC.ctlTreeBlogs udtExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerNewFile;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDisabled;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerProperties;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDownload;
		private System.Windows.Forms.ToolStripSeparator mnuExplorerSeparatorEntries;


	}
}