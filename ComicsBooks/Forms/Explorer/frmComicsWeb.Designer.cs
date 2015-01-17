namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	partial class frmComicsWeb
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComicsWeb));
			this.ctxMnuExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuExplorerOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExplorerShowInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExplorerDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.trvComics = new Bau.Controls.Tree.TreeViewExtended();
			this.ctxMnuExplorer.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctxMnuExplorer
			// 
			this.ctxMnuExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExplorerOpen,
            this.mnuExplorerShowInfo,
            this.mnuExplorerDelete});
			this.ctxMnuExplorer.Name = "ctxMnuExplorer";
			this.ctxMnuExplorer.Size = new System.Drawing.Size(145, 70);
			this.ctxMnuExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuExplorer_Opening);
			// 
			// mnuExplorerOpen
			// 
			this.mnuExplorerOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
			this.mnuExplorerOpen.Name = "mnuExplorerOpen";
			this.mnuExplorerOpen.Size = new System.Drawing.Size(144, 22);
			this.mnuExplorerOpen.Text = "&Abrir";
			this.mnuExplorerOpen.Click += new System.EventHandler(this.mnuExplorerOpen_Click);
			// 
			// mnuExplorerShowInfo
			// 
			this.mnuExplorerShowInfo.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Properties;
			this.mnuExplorerShowInfo.Name = "mnuExplorerShowInfo";
			this.mnuExplorerShowInfo.Size = new System.Drawing.Size(144, 22);
			this.mnuExplorerShowInfo.Text = "&Propiedades";
			this.mnuExplorerShowInfo.Visible = false;
			// 
			// mnuExplorerDelete
			// 
			this.mnuExplorerDelete.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.mnuExplorerDelete.Name = "mnuExplorerDelete";
			this.mnuExplorerDelete.Size = new System.Drawing.Size(144, 22);
			this.mnuExplorerDelete.Text = "&Eliminar";
			this.mnuExplorerDelete.Click += new System.EventHandler(this.mnuExplorerDelete_Click);
			// 
			// trvComics
			// 
			this.trvComics.CheckRecursive = false;
			this.trvComics.ContextMenuStrip = this.ctxMnuExplorer;
			this.trvComics.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvComics.HideSelection = false;
			this.trvComics.Location = new System.Drawing.Point(0, 0);
			this.trvComics.Margin = new System.Windows.Forms.Padding(0);
			this.trvComics.Name = "trvComics";
			this.trvComics.ShowNodeToolTips = true;
			this.trvComics.Size = new System.Drawing.Size(372, 541);
			this.trvComics.TabIndex = 0;
			this.trvComics.NodeDoubleClick += new Bau.Controls.Tree.TreeViewExtended.NodeDoubleClickHandler(this.trvBookmarks_NodeDoubleClick);
			// 
			// frmComicsWeb
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 541);
			this.Controls.Add(this.trvComics);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmComicsWeb";
			this.TabText = "Comics Web";
			this.Text = "Comics Web";
			this.Load += new System.EventHandler(this.frmLibrary_Load);
			this.ctxMnuExplorer.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip ctxMnuExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDelete;
		private Bau.Controls.Tree.TreeViewExtended trvComics;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerShowInfo;


	}
}