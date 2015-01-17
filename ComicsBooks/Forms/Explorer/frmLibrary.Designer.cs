namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	partial class frmLibrary
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLibrary));
			this.ctxMnuExplorer = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuExplorerOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExplorerShowInfo = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuExplorerDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.trvBookmarks = new Bau.Controls.Tree.TreeViewExtended();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.mnuSortByCategory = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSortByAuthor = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxMnuExplorer.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// ctxMnuExplorer
			// 
			this.ctxMnuExplorer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExplorerOpen,
            this.mnuExplorerShowInfo,
            this.mnuExplorerDelete});
			this.ctxMnuExplorer.Name = "ctxMnuExplorer";
			this.ctxMnuExplorer.Size = new System.Drawing.Size(153, 92);
			this.ctxMnuExplorer.Opening += new System.ComponentModel.CancelEventHandler(this.ctxMnuExplorer_Opening);
			// 
			// mnuExplorerOpen
			// 
			this.mnuExplorerOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
			this.mnuExplorerOpen.Name = "mnuExplorerOpen";
			this.mnuExplorerOpen.Size = new System.Drawing.Size(152, 22);
			this.mnuExplorerOpen.Text = "&Abrir";
			this.mnuExplorerOpen.Click += new System.EventHandler(this.mnuExplorerOpen_Click);
			// 
			// mnuExplorerShowInfo
			// 
			this.mnuExplorerShowInfo.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Properties;
			this.mnuExplorerShowInfo.Name = "mnuExplorerShowInfo";
			this.mnuExplorerShowInfo.Size = new System.Drawing.Size(152, 22);
			this.mnuExplorerShowInfo.Text = "&Propiedades";
			this.mnuExplorerShowInfo.Visible = false;
			this.mnuExplorerShowInfo.Click += new System.EventHandler(this.mnuExplorerShowInfo_Click);
			// 
			// mnuExplorerDelete
			// 
			this.mnuExplorerDelete.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.mnuExplorerDelete.Name = "mnuExplorerDelete";
			this.mnuExplorerDelete.Size = new System.Drawing.Size(152, 22);
			this.mnuExplorerDelete.Text = "&Eliminar";
			this.mnuExplorerDelete.Click += new System.EventHandler(this.mnuExplorerDelete_Click);
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.trvBookmarks, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(372, 541);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// trvBookmarks
			// 
			this.trvBookmarks.CheckRecursive = false;
			this.trvBookmarks.ContextMenuStrip = this.ctxMnuExplorer;
			this.trvBookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trvBookmarks.HideSelection = false;
			this.trvBookmarks.Location = new System.Drawing.Point(0, 25);
			this.trvBookmarks.Margin = new System.Windows.Forms.Padding(0);
			this.trvBookmarks.Name = "trvBookmarks";
			this.trvBookmarks.ShowNodeToolTips = true;
			this.trvBookmarks.Size = new System.Drawing.Size(372, 516);
			this.trvBookmarks.TabIndex = 0;
			this.trvBookmarks.NodeDoubleClick += new Bau.Controls.Tree.TreeViewExtended.NodeDoubleClickHandler(this.trvBookmarks_NodeDoubleClick);
			// 
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(372, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSortByCategory,
            this.mnuSortByAuthor});
			this.toolStripButton1.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.TaskUnknown;
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(29, 22);
			this.toolStripButton1.Text = "Ordenación";
			// 
			// mnuSortByCategory
			// 
			this.mnuSortByCategory.Checked = true;
			this.mnuSortByCategory.CheckState = System.Windows.Forms.CheckState.Checked;
			this.mnuSortByCategory.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Application;
			this.mnuSortByCategory.Name = "mnuSortByCategory";
			this.mnuSortByCategory.Size = new System.Drawing.Size(137, 22);
			this.mnuSortByCategory.Text = "&Categorías";
			this.mnuSortByCategory.Click += new System.EventHandler(this.mnuSortByCategory_Click);
			// 
			// mnuSortByAuthor
			// 
			this.mnuSortByAuthor.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.WorkGroup;
			this.mnuSortByAuthor.Name = "mnuSortByAuthor";
			this.mnuSortByAuthor.Size = new System.Drawing.Size(137, 22);
			this.mnuSortByAuthor.Text = "&Autor";
			this.mnuSortByAuthor.Click += new System.EventHandler(this.mnuSortByAuthor_Click);
			// 
			// frmLibrary
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(372, 541);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLibrary";
			this.TabText = "Colección";
			this.Text = "Colección";
			this.Load += new System.EventHandler(this.frmLibrary_Load);
			this.ctxMnuExplorer.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip ctxMnuExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerOpen;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerShowInfo;
		private System.Windows.Forms.ToolStripMenuItem mnuExplorerDelete;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private Bau.Controls.Tree.TreeViewExtended trvBookmarks;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripButton1;
		private System.Windows.Forms.ToolStripMenuItem mnuSortByCategory;
		private System.Windows.Forms.ToolStripMenuItem mnuSortByAuthor;


	}
}