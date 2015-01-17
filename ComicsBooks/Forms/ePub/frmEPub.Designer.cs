namespace Bau.Applications.ComicsBooks.Forms.ePub
{
	partial class frmEPub
	{
		/// <summary>
		/// Variable del diseñador requerida.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén utilizando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEPub));
		this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
		this.splMain = new Bau.Controls.Split.CollapsiblePanelSplitter();
		this.trvPages = new Bau.Controls.Tree.TreeViewExtended();
		this.wbExplorer = new Bau.Controls.WebExplorer.WebExplorerExtended();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.cmdShowPages = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.cmdGoFirstPage = new System.Windows.Forms.ToolStripButton();
		this.cmdGoPreviousPage = new System.Windows.Forms.ToolStripButton();
		this.cboPages = new System.Windows.Forms.ToolStripComboBox();
		this.lblInfo = new System.Windows.Forms.ToolStripLabel();
		this.cmdGoNextPage = new System.Windows.Forms.ToolStripButton();
		this.cmdGoLastPage = new System.Windows.Forms.ToolStripButton();
		this.cmdInfo = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
		this.tableLayoutPanel1.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)(this.splMain)).BeginInit();
		this.splMain.Panel1.SuspendLayout();
		this.splMain.Panel2.SuspendLayout();
		this.splMain.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		this.SuspendLayout();
		// 
		// tableLayoutPanel1
		// 
		this.tableLayoutPanel1.ColumnCount = 1;
		this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.Controls.Add(this.splMain, 0, 1);
		this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
		this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
		this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
		this.tableLayoutPanel1.Name = "tableLayoutPanel1";
		this.tableLayoutPanel1.RowCount = 2;
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
		this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
		this.tableLayoutPanel1.Size = new System.Drawing.Size(726, 614);
		this.tableLayoutPanel1.TabIndex = 1;
		// 
		// splMain
		// 
		this.splMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.splMain.BackColorSplitter = System.Drawing.Color.Lavender;
		this.splMain.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
		this.splMain.Location = new System.Drawing.Point(3, 23);
		this.splMain.Name = "splMain";
		// 
		// splMain.Panel1
		// 
		this.splMain.Panel1.Controls.Add(this.trvPages);
		this.splMain.Panel1MinSize = 0;
		// 
		// splMain.Panel2
		// 
		this.splMain.Panel2.Controls.Add(this.wbExplorer);
		this.splMain.Panel2MinSize = 0;
		this.splMain.Size = new System.Drawing.Size(720, 588);
		this.splMain.SplitterDistance = 238;
		this.splMain.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
		this.splMain.SplitterWidth = 8;
		this.splMain.TabIndex = 4;
		// 
		// trvPages
		// 
		this.trvPages.CheckRecursive = false;
		this.trvPages.Dock = System.Windows.Forms.DockStyle.Fill;
		this.trvPages.HideSelection = false;
		this.trvPages.Location = new System.Drawing.Point(0, 0);
		this.trvPages.Name = "trvPages";
		this.trvPages.ShowNodeToolTips = true;
		this.trvPages.Size = new System.Drawing.Size(238, 588);
		this.trvPages.TabIndex = 0;
		this.trvPages.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvPages_AfterSelect);
		// 
		// wbExplorer
		// 
		this.wbExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
		this.wbExplorer.Location = new System.Drawing.Point(0, 0);
		this.wbExplorer.MinimumSize = new System.Drawing.Size(20, 20);
		this.wbExplorer.Name = "wbExplorer";
		this.wbExplorer.Size = new System.Drawing.Size(474, 588);
		this.wbExplorer.TabIndex = 0;
		// 
		// toolStrip1
		// 
		this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdShowPages,
            this.toolStripSeparator1,
            this.cmdGoFirstPage,
            this.cmdGoPreviousPage,
            this.cboPages,
            this.lblInfo,
            this.cmdGoNextPage,
            this.cmdGoLastPage,
            this.cmdInfo,
            this.toolStripSeparator3});
		this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(726, 20);
		this.toolStrip1.TabIndex = 1;
		this.toolStrip1.Text = "toolStrip1";
		// 
		// cmdShowPages
		// 
		this.cmdShowPages.Checked = true;
		this.cmdShowPages.CheckState = System.Windows.Forms.CheckState.Checked;
		this.cmdShowPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdShowPages.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.SplitVertical;
		this.cmdShowPages.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdShowPages.Name = "cmdShowPages";
		this.cmdShowPages.Size = new System.Drawing.Size(23, 17);
		this.cmdShowPages.Text = "Mostrar páginas";
		this.cmdShowPages.Click += new System.EventHandler(this.cmdShowPages_Click);
		// 
		// toolStripSeparator1
		// 
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 20);
		// 
		// cmdGoFirstPage
		// 
		this.cmdGoFirstPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdGoFirstPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowFirst;
		this.cmdGoFirstPage.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdGoFirstPage.Name = "cmdGoFirstPage";
		this.cmdGoFirstPage.Size = new System.Drawing.Size(23, 17);
		this.cmdGoFirstPage.Text = "Primera página";
		this.cmdGoFirstPage.Click += new System.EventHandler(this.cmdGoFirstPage_Click);
		// 
		// cmdGoPreviousPage
		// 
		this.cmdGoPreviousPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdGoPreviousPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLeft;
		this.cmdGoPreviousPage.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdGoPreviousPage.Name = "cmdGoPreviousPage";
		this.cmdGoPreviousPage.Size = new System.Drawing.Size(23, 17);
		this.cmdGoPreviousPage.Text = "Página anterior";
		this.cmdGoPreviousPage.Click += new System.EventHandler(this.cmdGoPreviousPage_Click);
		// 
		// cboPages
		// 
		this.cboPages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.cboPages.Name = "cboPages";
		this.cboPages.Size = new System.Drawing.Size(75, 20);
		this.cboPages.SelectedIndexChanged += new System.EventHandler(this.cboPages_SelectedIndexChanged);
		// 
		// lblInfo
		// 
		this.lblInfo.Name = "lblInfo";
		this.lblInfo.Size = new System.Drawing.Size(37, 17);
		this.lblInfo.Text = "lblInfo";
		// 
		// cmdGoNextPage
		// 
		this.cmdGoNextPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdGoNextPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowRight;
		this.cmdGoNextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdGoNextPage.Name = "cmdGoNextPage";
		this.cmdGoNextPage.Size = new System.Drawing.Size(23, 17);
		this.cmdGoNextPage.Text = "Página siguiente";
		this.cmdGoNextPage.Click += new System.EventHandler(this.cmdGoNextPage_Click);
		// 
		// cmdGoLastPage
		// 
		this.cmdGoLastPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdGoLastPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLast;
		this.cmdGoLastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdGoLastPage.Name = "cmdGoLastPage";
		this.cmdGoLastPage.Size = new System.Drawing.Size(23, 17);
		this.cmdGoLastPage.Text = "Ultima página";
		this.cmdGoLastPage.Click += new System.EventHandler(this.cmdGoLastPage_Click);
		// 
		// cmdInfo
		// 
		this.cmdInfo.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.cmdInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdInfo.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.information;
		this.cmdInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdInfo.Name = "cmdInfo";
		this.cmdInfo.Size = new System.Drawing.Size(23, 17);
		this.cmdInfo.Text = "Información";
		this.cmdInfo.Click += new System.EventHandler(this.cmdInfo_Click);
		// 
		// toolStripSeparator3
		// 
		this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
		this.toolStripSeparator3.Name = "toolStripSeparator3";
		this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
		// 
		// frmEPub
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.White;
		this.ClientSize = new System.Drawing.Size(726, 614);
		this.Controls.Add(this.tableLayoutPanel1);
		this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.Name = "frmEPub";
		this.ShowInTaskbar = false;
		this.TabText = "Ayuda";
		this.Text = "Comic";
		this.Load += new System.EventHandler(this.frmEPub_Load);
		this.Shown += new System.EventHandler(this.frmEPub_Shown);
		this.tableLayoutPanel1.ResumeLayout(false);
		this.tableLayoutPanel1.PerformLayout();
		this.splMain.Panel1.ResumeLayout(false);
		this.splMain.Panel2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)(this.splMain)).EndInit();
		this.splMain.ResumeLayout(false);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton cmdGoPreviousPage;
		private System.Windows.Forms.ToolStripButton cmdGoNextPage;
		private System.Windows.Forms.ToolStripButton cmdGoFirstPage;
		private System.Windows.Forms.ToolStripButton cmdGoLastPage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripComboBox cboPages;
		private System.Windows.Forms.ToolStripLabel lblInfo;
		private System.Windows.Forms.ToolStripButton cmdShowPages;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton cmdInfo;
		private Bau.Controls.Split.CollapsiblePanelSplitter splMain;
		private Bau.Controls.Tree.TreeViewExtended trvPages;
		private Bau.Controls.WebExplorer.WebExplorerExtended wbExplorer;
	}
}