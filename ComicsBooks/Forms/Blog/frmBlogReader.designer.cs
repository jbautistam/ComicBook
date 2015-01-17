namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	partial class frmBlogReader
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
		this.mnuEntry = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.mnuEntrySetRead = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuEntrySetNotRead = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuEntrySetInteresting = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuEntrySeparator = new System.Windows.Forms.ToolStripSeparator();
		this.mnuEntryDelete = new System.Windows.Forms.ToolStripMenuItem();
		this.panel1 = new System.Windows.Forms.Panel();
		this.lblBlog = new System.Windows.Forms.Label();
		this.lswEntries = new Bau.Controls.List.ListViewExtended();
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.collapsiblePanelSplitter1 = new Bau.Controls.Split.CollapsiblePanelSplitter();
		this.wbExplorer = new Bau.Controls.WebExplorer.WebExplorerExtended();
		this.tmrMarkRead = new System.Windows.Forms.Timer(this.components);
		this.tmrSelectedChanged = new System.Windows.Forms.Timer(this.components);
		this.tmrStopWindowsOpen = new System.Windows.Forms.Timer(this.components);
		this.mnuEntry.SuspendLayout();
		this.panel1.SuspendLayout();
		this.tableLayoutPanel1.SuspendLayout();
		this.collapsiblePanelSplitter1.Panel1.SuspendLayout();
		this.collapsiblePanelSplitter1.Panel2.SuspendLayout();
		this.collapsiblePanelSplitter1.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuEntry
		// 
		this.mnuEntry.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEntrySetRead,
            this.mnuEntrySetNotRead,
            this.mnuEntrySetInteresting,
            this.mnuEntrySeparator,
            this.mnuEntryDelete});
		this.mnuEntry.Name = "mnuEntry";
		this.mnuEntry.Size = new System.Drawing.Size(205, 98);
		this.mnuEntry.Opening += new System.ComponentModel.CancelEventHandler(this.mnuEntry_Opening);
		// 
		// mnuEntrySetRead
		// 
		this.mnuEntrySetRead.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.EMailOpen;
		this.mnuEntrySetRead.Name = "mnuEntrySetRead";
		this.mnuEntrySetRead.Size = new System.Drawing.Size(204, 22);
		this.mnuEntrySetRead.Text = "Marcar como &leído";
		this.mnuEntrySetRead.Click += new System.EventHandler(this.mnuEntrySetRead_Click);
		// 
		// mnuEntrySetNotRead
		// 
		this.mnuEntrySetNotRead.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.EMail;
		this.mnuEntrySetNotRead.Name = "mnuEntrySetNotRead";
		this.mnuEntrySetNotRead.Size = new System.Drawing.Size(204, 22);
		this.mnuEntrySetNotRead.Text = "Marcar como &no leído";
		this.mnuEntrySetNotRead.Click += new System.EventHandler(this.mnuEntrySetNotRead_Click);
		// 
		// mnuEntrySetInteresting
		// 
		this.mnuEntrySetInteresting.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.exclamation;
		this.mnuEntrySetInteresting.Name = "mnuEntrySetInteresting";
		this.mnuEntrySetInteresting.Size = new System.Drawing.Size(204, 22);
		this.mnuEntrySetInteresting.Text = "Marcar como &interesante";
		this.mnuEntrySetInteresting.Click += new System.EventHandler(this.mnuEntrySetInteresting_Click);
		// 
		// mnuEntrySeparator
		// 
		this.mnuEntrySeparator.Name = "mnuEntrySeparator";
		this.mnuEntrySeparator.Size = new System.Drawing.Size(201, 6);
		// 
		// mnuEntryDelete
		// 
		this.mnuEntryDelete.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
		this.mnuEntryDelete.Name = "mnuEntryDelete";
		this.mnuEntryDelete.Size = new System.Drawing.Size(204, 22);
		this.mnuEntryDelete.Text = "&Eliminar";
		this.mnuEntryDelete.Click += new System.EventHandler(this.mnuEntryDelete_Click);
		// 
		// panel1
		// 
		this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
		this.panel1.Controls.Add(this.lblBlog);
		this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.panel1.Location = new System.Drawing.Point(0, 0);
		this.panel1.Margin = new System.Windows.Forms.Padding(0);
		this.panel1.Name = "panel1";
		this.panel1.Size = new System.Drawing.Size(847, 37);
		this.panel1.TabIndex = 0;
		// 
		// lblBlog
		// 
		this.lblBlog.AutoSize = true;
		this.lblBlog.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.lblBlog.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
		this.lblBlog.Location = new System.Drawing.Point(12, 8);
		this.lblBlog.Name = "lblBlog";
		this.lblBlog.Size = new System.Drawing.Size(74, 24);
		this.lblBlog.TabIndex = 0;
		this.lblBlog.Text = "lblBlog";
		// 
		// lswEntries
		// 
		this.lswEntries.ContextMenuStrip = this.mnuEntry;
		this.lswEntries.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lswEntries.FullRowSelect = true;
		this.lswEntries.HideSelection = false;
		this.lswEntries.Location = new System.Drawing.Point(0, 0);
		this.lswEntries.Name = "lswEntries";
		this.lswEntries.SelectedKey = null;
		this.lswEntries.Size = new System.Drawing.Size(841, 190);
		this.lswEntries.TabIndex = 0;
		this.lswEntries.UseCompatibleStateImageBehavior = false;
		this.lswEntries.View = System.Windows.Forms.View.Details;
		this.lswEntries.SelectedIndexChanged += new System.EventHandler(this.lswEntries_SelectedIndexChanged);
		this.lswEntries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lswEntries_KeyDown);
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.collapsiblePanelSplitter1, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(847, 554);
		this.tableLayoutPanel1.TabIndex = 0;
		// 
		// collapsiblePanelSplitter1
		// 
		this.collapsiblePanelSplitter1.BackColorSplitter = System.Drawing.Color.FromArgb(((int) (((byte) (192)))), ((int) (((byte) (192)))), ((int) (((byte) (255)))));
		this.collapsiblePanelSplitter1.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
		this.collapsiblePanelSplitter1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.collapsiblePanelSplitter1.Location = new System.Drawing.Point(3, 40);
		this.collapsiblePanelSplitter1.Name = "collapsiblePanelSplitter1";
		this.collapsiblePanelSplitter1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		// 
		// collapsiblePanelSplitter1.Panel1
		// 
		this.collapsiblePanelSplitter1.Panel1.Controls.Add(this.lswEntries);
		this.collapsiblePanelSplitter1.Panel1MinSize = 0;
		// 
		// collapsiblePanelSplitter1.Panel2
		// 
		this.collapsiblePanelSplitter1.Panel2.Controls.Add(this.wbExplorer);
		this.collapsiblePanelSplitter1.Panel2MinSize = 0;
		this.collapsiblePanelSplitter1.Size = new System.Drawing.Size(841, 511);
		this.collapsiblePanelSplitter1.SplitterDistance = 190;
		this.collapsiblePanelSplitter1.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
		this.collapsiblePanelSplitter1.SplitterWidth = 8;
		this.collapsiblePanelSplitter1.TabIndex = 1;
		// 
		// wbExplorer
		// 
		this.wbExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wbExplorer.Location = new System.Drawing.Point(0, 0);
		this.wbExplorer.MinimumSize = new System.Drawing.Size(20, 20);
		this.wbExplorer.Name = "wbExplorer";
		this.wbExplorer.Size = new System.Drawing.Size(841, 313);
		this.wbExplorer.TabIndex = 0;
		this.wbExplorer.ChangeStatus += new System.EventHandler(this.wbExplorer_ChangeStatus);
		this.wbExplorer.ChangeProgress += new System.EventHandler<Bau.Controls.WebExplorer.WebExplorerProgressEventArgs>(this.wbExplorer_ChangeProgress);
		this.wbExplorer.ChangeNavigationStatus += new System.EventHandler<Bau.Controls.WebExplorer.WebExplorerNavigationEventArgs>(this.wbExplorer_ChangeNavigationStatus);
		this.wbExplorer.JavaScriptFunctionCalled += new System.EventHandler<Bau.Controls.WebExplorer.WebExplorerJavaScriptFunctionEventArgs>(this.wbExplorer_JavaScriptFunctionCalled);
		// 
		// tmrMarkRead
		// 
		this.tmrMarkRead.Tick += new System.EventHandler(this.tmrMarkRead_Tick);
		// 
		// tmrSelectedChanged
		// 
		this.tmrSelectedChanged.Tick += new System.EventHandler(this.tmrSelectedChanged_Tick);
		// 
		// tmrStopWindowsOpen
		// 
		this.tmrStopWindowsOpen.Tick += new System.EventHandler(this.tmrStopWindowsOpen_Tick);
		// 
		// frmBlogReader
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(847, 554);
		this.Controls.Add(this.tableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
		this.Name = "frmBlogReader";
		this.Text = "frmBlogReader";
		this.Load += new System.EventHandler(this.frmBlogReader_Load);
		this.Shown += new System.EventHandler(this.frmBlogReader_Shown);
		this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBlogReader_FormClosing);
		this.mnuEntry.ResumeLayout(false);
		this.panel1.ResumeLayout(false);
		this.panel1.PerformLayout();
		this.tableLayoutPanel1.ResumeLayout(false);
		this.collapsiblePanelSplitter1.Panel1.ResumeLayout(false);
		this.collapsiblePanelSplitter1.Panel2.ResumeLayout(false);
		this.collapsiblePanelSplitter1.ResumeLayout(false);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ContextMenuStrip mnuEntry;
		private System.Windows.Forms.ToolStripMenuItem mnuEntrySetRead;
		private System.Windows.Forms.ToolStripSeparator mnuEntrySeparator;
		private System.Windows.Forms.ToolStripMenuItem mnuEntryDelete;
		private System.Windows.Forms.ToolStripMenuItem mnuEntrySetNotRead;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label lblBlog;
		private Bau.Controls.List.ListViewExtended lswEntries;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private Bau.Controls.Split.CollapsiblePanelSplitter collapsiblePanelSplitter1;
		private Bau.Controls.WebExplorer.WebExplorerExtended wbExplorer;
		private System.Windows.Forms.ToolStripMenuItem mnuEntrySetInteresting;
		private System.Windows.Forms.Timer tmrMarkRead;
		private System.Windows.Forms.Timer tmrSelectedChanged;
		private System.Windows.Forms.Timer tmrStopWindowsOpen;
	}
}