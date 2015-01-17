namespace Bau.Controls.Files
{
	partial class FilesExplorer
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

		#region Código generado por el Diseñador de componentes

		/// <summary> 
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido del método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
		this.lswFiles = new Bau.Controls.Files.ListFiles();
		this.trvPath = new Bau.Controls.Files.TreePath();
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.toolStrip1 = new System.Windows.Forms.ToolStrip();
		this.cmdBack = new System.Windows.Forms.ToolStripButton();
		this.cmdParentPath = new System.Windows.Forms.ToolStripButton();
		this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
		this.mnuIcons = new System.Windows.Forms.ToolStripDropDownButton();
		this.mnuViewDetails = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuViewList = new System.Windows.Forms.ToolStripMenuItem();
		this.mnuViewIcons = new System.Windows.Forms.ToolStripMenuItem();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		this.toolStrip1.SuspendLayout();
		this.SuspendLayout();
		// 
		// lswFiles
		// 
		this.lswFiles.Dock = System.Windows.Forms.DockStyle.Fill;
		this.lswFiles.Location = new System.Drawing.Point(0, 0);
		this.lswFiles.Mask = "*.*";
		this.lswFiles.Name = "lswFiles";
		this.lswFiles.Path = "C:\\";
		this.lswFiles.Size = new System.Drawing.Size(263, 423);
		this.lswFiles.TabIndex = 0;
		this.lswFiles.View = System.Windows.Forms.View.Details;
		this.lswFiles.FileSelected += new Bau.Controls.Files.ListFiles.FileSelectedHandler(this.lswFiles_FileSelected);
		this.lswFiles.FileDoubleClick += new Bau.Controls.Files.ListFiles.FileDoubleClickHandler(this.lswFiles_FileDoubleClick);
		this.lswFiles.PathChanged += new Bau.Controls.Files.ListFiles.PathChangedHandler(this.trvPath_PathChanged);
		// 
		// trvPath
		// 
		this.trvPath.BasePath = null;
		this.trvPath.CanEditNames = false;
		this.trvPath.Dock = System.Windows.Forms.DockStyle.Fill;
		this.trvPath.Location = new System.Drawing.Point(0, 0);
		this.trvPath.Mask = "*.*";
		this.trvPath.Name = "trvPath";
		this.trvPath.Path = null;
		this.trvPath.ShowFiles = false;
		this.trvPath.Size = new System.Drawing.Size(196, 423);
		this.trvPath.TabIndex = 1;
		this.trvPath.FileDoubleClick += new System.EventHandler<Bau.Controls.Files.Events.clsFileEventArgs>(this.lswFiles_FileDoubleClick);
		this.trvPath.PathChanged += new System.EventHandler<Bau.Controls.Files.Events.clsFileEventArgs>(this.trvPath_PathChanged);
		// 
		// splitContainer1
		// 
		this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
								| System.Windows.Forms.AnchorStyles.Left)
								| System.Windows.Forms.AnchorStyles.Right)));
		this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.splitContainer1.Location = new System.Drawing.Point(3, 27);
		this.splitContainer1.Name = "splitContainer1";
		// 
		// splitContainer1.Panel1
		// 
		this.splitContainer1.Panel1.Controls.Add(this.trvPath);
		// 
		// splitContainer1.Panel2
		// 
		this.splitContainer1.Panel2.Controls.Add(this.lswFiles);
		this.splitContainer1.Size = new System.Drawing.Size(471, 427);
		this.splitContainer1.SplitterDistance = 200;
		this.splitContainer1.TabIndex = 2;
		// 
		// toolStrip1
		// 
		this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
		this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdBack,
            this.cmdParentPath,
            this.toolStripSeparator1,
            this.mnuIcons});
		this.toolStrip1.Location = new System.Drawing.Point(0, 0);
		this.toolStrip1.Name = "toolStrip1";
		this.toolStrip1.Size = new System.Drawing.Size(477, 25);
		this.toolStrip1.TabIndex = 3;
		// 
		// cmdBack
		// 
		this.cmdBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdBack.Image = global::Bau.Controls.Files.Properties.Resources.Back;
		this.cmdBack.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdBack.Name = "cmdBack";
		this.cmdBack.Size = new System.Drawing.Size(23, 22);
		this.cmdBack.Text = "Atrás";
		this.cmdBack.Click += new System.EventHandler(this.cmdBack_Click);
		// 
		// cmdParentPath
		// 
		this.cmdParentPath.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.cmdParentPath.Image = global::Bau.Controls.Files.Properties.Resources.FolderTop;
		this.cmdParentPath.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.cmdParentPath.Name = "cmdParentPath";
		this.cmdParentPath.Size = new System.Drawing.Size(23, 22);
		this.cmdParentPath.Text = "Directorio padre";
		this.cmdParentPath.Click += new System.EventHandler(this.cmdParentPath_Click);
		// 
		// toolStripSeparator1
		// 
		this.toolStripSeparator1.Name = "toolStripSeparator1";
		this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
		// 
		// mnuIcons
		// 
		this.mnuIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
		this.mnuIcons.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewDetails,
            this.mnuViewList,
            this.mnuViewIcons});
		this.mnuIcons.Image = global::Bau.Controls.Files.Properties.Resources.ViewDetails;
		this.mnuIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
		this.mnuIcons.Name = "mnuIcons";
		this.mnuIcons.Size = new System.Drawing.Size(29, 22);
		this.mnuIcons.Text = "Vista de archivos";
		// 
		// mnuViewDetails
		// 
		this.mnuViewDetails.Image = global::Bau.Controls.Files.Properties.Resources.ViewDetails;
		this.mnuViewDetails.Name = "mnuViewDetails";
		this.mnuViewDetails.Size = new System.Drawing.Size(123, 22);
		this.mnuViewDetails.Text = "&Detalles";
		this.mnuViewDetails.Click += new System.EventHandler(this.mnuViewDetails_Click);
		// 
		// mnuViewList
		// 
		this.mnuViewList.Image = global::Bau.Controls.Files.Properties.Resources.ViewList;
		this.mnuViewList.Name = "mnuViewList";
		this.mnuViewList.Size = new System.Drawing.Size(123, 22);
		this.mnuViewList.Text = "&Lista";
		this.mnuViewList.Click += new System.EventHandler(this.mnuViewList_Click);
		// 
		// mnuViewIcons
		// 
		this.mnuViewIcons.Image = global::Bau.Controls.Files.Properties.Resources.ViewIcons;
		this.mnuViewIcons.Name = "mnuViewIcons";
		this.mnuViewIcons.Size = new System.Drawing.Size(123, 22);
		this.mnuViewIcons.Text = "&Iconos";
		this.mnuViewIcons.Click += new System.EventHandler(this.mnuViewIcons_Click);
		// 
		// FilesExplorer
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.Controls.Add(this.toolStrip1);
		this.Controls.Add(this.splitContainer1);
		this.Name = "FilesExplorer";
		this.Size = new System.Drawing.Size(477, 456);
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		this.toolStrip1.ResumeLayout(false);
		this.toolStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();

		}

		#endregion

		private ListFiles lswFiles;
		private TreePath trvPath;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton mnuIcons;
		private System.Windows.Forms.ToolStripMenuItem mnuViewDetails;
		private System.Windows.Forms.ToolStripMenuItem mnuViewList;
		private System.Windows.Forms.ToolStripMenuItem mnuViewIcons;
		private System.Windows.Forms.ToolStripButton cmdBack;
		private System.Windows.Forms.ToolStripButton cmdParentPath;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}
