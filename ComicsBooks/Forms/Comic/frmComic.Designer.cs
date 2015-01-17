namespace Bau.Applications.ComicsBooks.Forms.Comic
{
	partial class frmComic
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmComic));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.cmdShowPages = new System.Windows.Forms.ToolStripButton();
			this.cmdShowThumb = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdGoFirstPage = new System.Windows.Forms.ToolStripButton();
			this.cmdGoPreviousPage = new System.Windows.Forms.ToolStripButton();
			this.cboPages = new System.Windows.Forms.ToolStripComboBox();
			this.lblInfo = new System.Windows.Forms.ToolStripLabel();
			this.cmdGoNextPage = new System.Windows.Forms.ToolStripButton();
			this.cmdGoLastPage = new System.Windows.Forms.ToolStripButton();
			this.cmdZoom = new System.Windows.Forms.ToolStripDropDownButton();
			this.ctxComicZoomOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuComicZoomOptionsFitWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptionsFitWidth = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptionsFitHeight = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicZoomOptions25 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions50 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions75 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions100 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions125 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions150 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions175 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoomOptions200 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicZoomOptionsMagnifier = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdInfo = new System.Windows.Forms.ToolStripButton();
			this.lblMarkAsDeleted = new System.Windows.Forms.ToolStripLabel();
			this.cmdRemovePage = new System.Windows.Forms.ToolStripButton();
			this.cmdPageDown = new System.Windows.Forms.ToolStripButton();
			this.cmdPageUp = new System.Windows.Forms.ToolStripButton();
			this.cmdNewPage = new System.Windows.Forms.ToolStripButton();
			this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdRotate = new System.Windows.Forms.ToolStripDropDownButton();
			this.ctxRotateOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuRotateLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRotateRight = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRotateNoRotation = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRotate90 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRotate180 = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRotate270 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem70 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuRotateFlipHorizontal = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuRotateFlipVertical = new System.Windows.Forms.ToolStripMenuItem();
			this.splMain = new Bau.Controls.Split.CollapsiblePanelSplitter();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lstThumbs = new Bau.Controls.ImageControls.Thumbnail.ThumbnailList();
			this.mnuComic = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuComicFirstPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPreviousPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicNextPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicLastPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicZoom = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicRotate = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicCut = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicNewPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPageUp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPageDown = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuComicSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPrintMenu = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuComicPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.trbWidthThumbs = new System.Windows.Forms.TrackBar();
			this.imgPage = new Bau.Controls.ImageControls.Picture.PictureZoom();
			this.tableLayoutPanel1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.ctxComicZoomOptions.SuspendLayout();
			this.ctxRotateOptions.SuspendLayout();
			this.splMain.Panel1.SuspendLayout();
			this.splMain.Panel2.SuspendLayout();
			this.splMain.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.mnuComic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trbWidthThumbs)).BeginInit();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.splMain, 0, 1);
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
			// toolStrip1
			// 
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdShowPages,
            this.cmdShowThumb,
            this.toolStripSeparator1,
            this.cmdGoFirstPage,
            this.cmdGoPreviousPage,
            this.cboPages,
            this.lblInfo,
            this.cmdGoNextPage,
            this.cmdGoLastPage,
            this.cmdZoom,
            this.toolStripSeparator2,
            this.cmdInfo,
            this.lblMarkAsDeleted,
            this.cmdRemovePage,
            this.cmdPageDown,
            this.cmdPageUp,
            this.cmdNewPage,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.cmdRotate});
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
			// cmdShowThumb
			// 
			this.cmdShowThumb.Checked = true;
			this.cmdShowThumb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cmdShowThumb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdShowThumb.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.PageSearch;
			this.cmdShowThumb.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdShowThumb.Name = "cmdShowThumb";
			this.cmdShowThumb.Size = new System.Drawing.Size(23, 17);
			this.cmdShowThumb.Text = "Mostrar miniatura";
			this.cmdShowThumb.Click += new System.EventHandler(this.cmdShowPages_Click);
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
			this.lblInfo.Size = new System.Drawing.Size(41, 17);
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
			// cmdZoom
			// 
			this.cmdZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdZoom.DropDown = this.ctxComicZoomOptions;
			this.cmdZoom.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Search;
			this.cmdZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdZoom.Name = "cmdZoom";
			this.cmdZoom.Size = new System.Drawing.Size(29, 17);
			this.cmdZoom.Text = "Zoom";
			// 
			// ctxComicZoomOptions
			// 
			this.ctxComicZoomOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComicZoomOptionsFitWindow,
            this.mnuComicZoomOptionsFitWidth,
            this.mnuComicZoomOptionsFitHeight,
            this.toolStripMenuItem4,
            this.mnuComicZoomOptions25,
            this.mnuComicZoomOptions50,
            this.mnuComicZoomOptions75,
            this.mnuComicZoomOptions100,
            this.mnuComicZoomOptions125,
            this.mnuComicZoomOptions150,
            this.mnuComicZoomOptions175,
            this.mnuComicZoomOptions200,
            this.toolStripMenuItem5,
            this.mnuComicZoomOptionsMagnifier});
			this.ctxComicZoomOptions.Name = "mnuComicZoomOptions";
			this.ctxComicZoomOptions.OwnerItem = this.mnuComicZoom;
			this.ctxComicZoomOptions.Size = new System.Drawing.Size(171, 280);
			// 
			// mnuComicZoomOptionsFitWindow
			// 
			this.mnuComicZoomOptionsFitWindow.Name = "mnuComicZoomOptionsFitWindow";
			this.mnuComicZoomOptionsFitWindow.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptionsFitWindow.Text = "&Ajustar a pantalla";
			this.mnuComicZoomOptionsFitWindow.Click += new System.EventHandler(this.mnuComicZoomOptionsFitWindow_Click);
			// 
			// mnuComicZoomOptionsFitWidth
			// 
			this.mnuComicZoomOptionsFitWidth.Name = "mnuComicZoomOptionsFitWidth";
			this.mnuComicZoomOptionsFitWidth.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptionsFitWidth.Text = "Ajustar a&ncho";
			this.mnuComicZoomOptionsFitWidth.Click += new System.EventHandler(this.mnuComicZoomOptionsFitWidth_Click);
			// 
			// mnuComicZoomOptionsFitHeight
			// 
			this.mnuComicZoomOptionsFitHeight.Name = "mnuComicZoomOptionsFitHeight";
			this.mnuComicZoomOptionsFitHeight.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptionsFitHeight.Text = "Ajustar a&lto";
			this.mnuComicZoomOptionsFitHeight.Click += new System.EventHandler(this.mnuComicZoomOptionsFitHeight_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(167, 6);
			// 
			// mnuComicZoomOptions25
			// 
			this.mnuComicZoomOptions25.Name = "mnuComicZoomOptions25";
			this.mnuComicZoomOptions25.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions25.Text = "25%";
			this.mnuComicZoomOptions25.Click += new System.EventHandler(this.mnuComicZoomOptions25_Click);
			// 
			// mnuComicZoomOptions50
			// 
			this.mnuComicZoomOptions50.Name = "mnuComicZoomOptions50";
			this.mnuComicZoomOptions50.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions50.Text = "50%";
			this.mnuComicZoomOptions50.Click += new System.EventHandler(this.mnuComicZoomOptions50_Click);
			// 
			// mnuComicZoomOptions75
			// 
			this.mnuComicZoomOptions75.Name = "mnuComicZoomOptions75";
			this.mnuComicZoomOptions75.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions75.Text = "75%";
			this.mnuComicZoomOptions75.Click += new System.EventHandler(this.mnuComicZoomOptions75_Click);
			// 
			// mnuComicZoomOptions100
			// 
			this.mnuComicZoomOptions100.Name = "mnuComicZoomOptions100";
			this.mnuComicZoomOptions100.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions100.Text = "100%";
			this.mnuComicZoomOptions100.Click += new System.EventHandler(this.mnuComicZoomOptions100_Click);
			// 
			// mnuComicZoomOptions125
			// 
			this.mnuComicZoomOptions125.Name = "mnuComicZoomOptions125";
			this.mnuComicZoomOptions125.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions125.Text = "125%";
			this.mnuComicZoomOptions125.Click += new System.EventHandler(this.mnuComicZoomOptions125_Click);
			// 
			// mnuComicZoomOptions150
			// 
			this.mnuComicZoomOptions150.Name = "mnuComicZoomOptions150";
			this.mnuComicZoomOptions150.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions150.Text = "150%";
			this.mnuComicZoomOptions150.Click += new System.EventHandler(this.mnuComicZoomOptions150_Click);
			// 
			// mnuComicZoomOptions175
			// 
			this.mnuComicZoomOptions175.Name = "mnuComicZoomOptions175";
			this.mnuComicZoomOptions175.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions175.Text = "175%";
			this.mnuComicZoomOptions175.Click += new System.EventHandler(this.mnuComicZoomOptions175_Click);
			// 
			// mnuComicZoomOptions200
			// 
			this.mnuComicZoomOptions200.Name = "mnuComicZoomOptions200";
			this.mnuComicZoomOptions200.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptions200.Text = "200%";
			this.mnuComicZoomOptions200.Click += new System.EventHandler(this.mnuComicZoomOptions200_Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(167, 6);
			// 
			// mnuComicZoomOptionsMagnifier
			// 
			this.mnuComicZoomOptionsMagnifier.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Search;
			this.mnuComicZoomOptionsMagnifier.Name = "mnuComicZoomOptionsMagnifier";
			this.mnuComicZoomOptionsMagnifier.Size = new System.Drawing.Size(170, 22);
			this.mnuComicZoomOptionsMagnifier.Text = "&Lupa";
			this.mnuComicZoomOptionsMagnifier.Click += new System.EventHandler(this.mnuComicZoomOptionsMagnifier_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 20);
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
			// lblMarkAsDeleted
			// 
			this.lblMarkAsDeleted.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.lblMarkAsDeleted.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblMarkAsDeleted.ForeColor = System.Drawing.Color.Red;
			this.lblMarkAsDeleted.Name = "lblMarkAsDeleted";
			this.lblMarkAsDeleted.Size = new System.Drawing.Size(119, 17);
			this.lblMarkAsDeleted.Text = "lblMarkAsDeleted    ";
			// 
			// cmdRemovePage
			// 
			this.cmdRemovePage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdRemovePage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdRemovePage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.cmdRemovePage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdRemovePage.Name = "cmdRemovePage";
			this.cmdRemovePage.Size = new System.Drawing.Size(23, 17);
			this.cmdRemovePage.Text = "Eliminar página";
			this.cmdRemovePage.Click += new System.EventHandler(this.cmdRemovePage_Click);
			// 
			// cmdPageDown
			// 
			this.cmdPageDown.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdPageDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdPageDown.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowDown;
			this.cmdPageDown.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdPageDown.Name = "cmdPageDown";
			this.cmdPageDown.Size = new System.Drawing.Size(23, 17);
			this.cmdPageDown.Text = "Bajar página";
			this.cmdPageDown.Click += new System.EventHandler(this.cmdPageDown_Click);
			// 
			// cmdPageUp
			// 
			this.cmdPageUp.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdPageUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdPageUp.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowUp;
			this.cmdPageUp.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdPageUp.Name = "cmdPageUp";
			this.cmdPageUp.Size = new System.Drawing.Size(23, 17);
			this.cmdPageUp.Text = "Subir página";
			this.cmdPageUp.Click += new System.EventHandler(this.cmdPageUp_Click);
			// 
			// cmdNewPage
			// 
			this.cmdNewPage.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.cmdNewPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdNewPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.cmdNewPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdNewPage.Name = "cmdNewPage";
			this.cmdNewPage.Size = new System.Drawing.Size(23, 17);
			this.cmdNewPage.Text = "Nueva página";
			this.cmdNewPage.Click += new System.EventHandler(this.cmdNewPage_Click);
			// 
			// toolStripLabel2
			// 
			this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripLabel2.Name = "toolStripLabel2";
			this.toolStripLabel2.Size = new System.Drawing.Size(49, 17);
			this.toolStripLabel2.Text = "Edición:";
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 20);
			// 
			// cmdRotate
			// 
			this.cmdRotate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdRotate.DropDown = this.ctxRotateOptions;
			this.cmdRotate.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateRight;
			this.cmdRotate.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdRotate.Name = "cmdRotate";
			this.cmdRotate.Size = new System.Drawing.Size(29, 17);
			this.cmdRotate.Text = "Rotación";
			// 
			// ctxRotateOptions
			// 
			this.ctxRotateOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRotateLeft,
            this.mnuRotateRight,
            this.toolStripMenuItem6,
            this.mnuRotateNoRotation,
            this.mnuRotate90,
            this.mnuRotate180,
            this.mnuRotate270,
            this.toolStripMenuItem70,
            this.mnuRotateFlipHorizontal,
            this.mnuRotateFlipVertical});
			this.ctxRotateOptions.Name = "ctxRotateOptions";
			this.ctxRotateOptions.OwnerItem = this.mnuComicRotate;
			this.ctxRotateOptions.Size = new System.Drawing.Size(185, 192);
			// 
			// mnuRotateLeft
			// 
			this.mnuRotateLeft.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateLeft;
			this.mnuRotateLeft.Name = "mnuRotateLeft";
			this.mnuRotateLeft.Size = new System.Drawing.Size(184, 22);
			this.mnuRotateLeft.Text = "Rotar a la &izquierda";
			this.mnuRotateLeft.Click += new System.EventHandler(this.mnuRotateLeft_Click);
			// 
			// mnuRotateRight
			// 
			this.mnuRotateRight.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateRight;
			this.mnuRotateRight.Name = "mnuRotateRight";
			this.mnuRotateRight.Size = new System.Drawing.Size(184, 22);
			this.mnuRotateRight.Text = "Rotar a la &derecha";
			this.mnuRotateRight.Click += new System.EventHandler(this.mnuRotateRight_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(181, 6);
			// 
			// mnuRotateNoRotation
			// 
			this.mnuRotateNoRotation.Name = "mnuRotateNoRotation";
			this.mnuRotateNoRotation.Size = new System.Drawing.Size(184, 22);
			this.mnuRotateNoRotation.Text = "&Sin rotación";
			this.mnuRotateNoRotation.Click += new System.EventHandler(this.mnuRotateNoRotation_Click);
			// 
			// mnuRotate90
			// 
			this.mnuRotate90.Name = "mnuRotate90";
			this.mnuRotate90.Size = new System.Drawing.Size(184, 22);
			this.mnuRotate90.Text = "Rotación &90 grados";
			this.mnuRotate90.Click += new System.EventHandler(this.mnuRotate90_Click);
			// 
			// mnuRotate180
			// 
			this.mnuRotate180.Name = "mnuRotate180";
			this.mnuRotate180.Size = new System.Drawing.Size(184, 22);
			this.mnuRotate180.Text = "Rotación &180 grados";
			this.mnuRotate180.Click += new System.EventHandler(this.mnuRotate180_Click);
			// 
			// mnuRotate270
			// 
			this.mnuRotate270.Name = "mnuRotate270";
			this.mnuRotate270.Size = new System.Drawing.Size(184, 22);
			this.mnuRotate270.Text = "Rotación &270 grados";
			this.mnuRotate270.Click += new System.EventHandler(this.mnuRotate270_Click);
			// 
			// toolStripMenuItem70
			// 
			this.toolStripMenuItem70.Name = "toolStripMenuItem70";
			this.toolStripMenuItem70.Size = new System.Drawing.Size(181, 6);
			// 
			// mnuRotateFlipHorizontal
			// 
			this.mnuRotateFlipHorizontal.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateFlip;
			this.mnuRotateFlipHorizontal.Name = "mnuRotateFlipHorizontal";
			this.mnuRotateFlipHorizontal.Size = new System.Drawing.Size(184, 22);
			this.mnuRotateFlipHorizontal.Text = "&Espejo horizontal";
			this.mnuRotateFlipHorizontal.Click += new System.EventHandler(this.mnuRotateFlipHorizontal_Click);
			// 
			// mnuRotateFlipVertical
			// 
			this.mnuRotateFlipVertical.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateFlip;
			this.mnuRotateFlipVertical.Name = "mnuRotateFlipVertical";
			this.mnuRotateFlipVertical.Size = new System.Drawing.Size(184, 22);
			this.mnuRotateFlipVertical.Text = "&Espejo vertical";
			this.mnuRotateFlipVertical.Click += new System.EventHandler(this.mnuRotateFlipHorizontal_Click);
			// 
			// splMain
			// 
			this.splMain.BackColorSplitter = System.Drawing.Color.Lavender;
			this.splMain.CollapseAction = Bau.Controls.Split.CollapsiblePanelSplitter.CollapseMode.CollapsePanel1;
			this.splMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splMain.Location = new System.Drawing.Point(3, 23);
			this.splMain.Name = "splMain";
			// 
			// splMain.Panel1
			// 
			this.splMain.Panel1.Controls.Add(this.tableLayoutPanel2);
			this.splMain.Panel1MinSize = 0;
			// 
			// splMain.Panel2
			// 
			this.splMain.Panel2.Controls.Add(this.imgPage);
			this.splMain.Panel2MinSize = 0;
			this.splMain.Size = new System.Drawing.Size(720, 588);
			this.splMain.SplitterDistance = 240;
			this.splMain.SplitterStyle = Bau.Controls.Split.CollapsiblePanelSplitter.VisualStyles.Mozilla;
			this.splMain.SplitterWidth = 8;
			this.splMain.TabIndex = 3;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.lstThumbs, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.trbWidthThumbs, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 588);
			this.tableLayoutPanel2.TabIndex = 1;
			// 
			// lstThumbs
			// 
			this.lstThumbs.AutoScroll = true;
			this.lstThumbs.BackColor = System.Drawing.Color.White;
			this.lstThumbs.BackColorSelected = System.Drawing.Color.LightSteelBlue;
			this.lstThumbs.ContextMenuStrip = this.mnuComic;
			this.lstThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstThumbs.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.lstThumbs.Location = new System.Drawing.Point(3, 3);
			this.lstThumbs.Mode = Bau.Controls.ImageControls.Thumbnail.ThumbnailList.ModeThumblist.Normal;
			this.lstThumbs.Name = "lstThumbs";
			this.lstThumbs.Size = new System.Drawing.Size(234, 548);
			this.lstThumbs.TabIndex = 0;
			this.lstThumbs.Text = "thumbnailList1";
			this.lstThumbs.SelectedIndexChanged += new System.EventHandler(this.lstThumbs_SelectedIndexChanged);
			// 
			// mnuComic
			// 
			this.mnuComic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComicFirstPage,
            this.mnuComicPreviousPage,
            this.mnuComicNextPage,
            this.mnuComicLastPage,
            this.mnuComicZoom,
            this.toolStripMenuItem7,
            this.mnuComicRotate,
            this.toolStripMenuItem1,
            this.mnuComicCopy,
            this.mnuComicCut,
            this.mnuComicPaste,
            this.mnuComicRemove,
            this.toolStripMenuItem2,
            this.mnuComicNewPage,
            this.mnuComicPageUp,
            this.mnuComicPageDown,
            this.toolStripMenuItem3,
            this.mnuComicSave,
            this.mnuComicPrintMenu});
			this.mnuComic.Name = "mnuComic";
			this.mnuComic.Size = new System.Drawing.Size(164, 358);
			// 
			// mnuComicFirstPage
			// 
			this.mnuComicFirstPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowFirst;
			this.mnuComicFirstPage.Name = "mnuComicFirstPage";
			this.mnuComicFirstPage.Size = new System.Drawing.Size(163, 22);
			this.mnuComicFirstPage.Text = "Primera página";
			this.mnuComicFirstPage.Click += new System.EventHandler(this.cmdGoFirstPage_Click);
			// 
			// mnuComicPreviousPage
			// 
			this.mnuComicPreviousPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLeft;
			this.mnuComicPreviousPage.Name = "mnuComicPreviousPage";
			this.mnuComicPreviousPage.Size = new System.Drawing.Size(163, 22);
			this.mnuComicPreviousPage.Text = "Página anterior";
			this.mnuComicPreviousPage.Click += new System.EventHandler(this.cmdGoPreviousPage_Click);
			// 
			// mnuComicNextPage
			// 
			this.mnuComicNextPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowRight;
			this.mnuComicNextPage.Name = "mnuComicNextPage";
			this.mnuComicNextPage.Size = new System.Drawing.Size(163, 22);
			this.mnuComicNextPage.Text = "Página siguiente";
			this.mnuComicNextPage.Click += new System.EventHandler(this.cmdGoNextPage_Click);
			// 
			// mnuComicLastPage
			// 
			this.mnuComicLastPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowLast;
			this.mnuComicLastPage.Name = "mnuComicLastPage";
			this.mnuComicLastPage.Size = new System.Drawing.Size(163, 22);
			this.mnuComicLastPage.Text = "&Ultima página";
			this.mnuComicLastPage.Click += new System.EventHandler(this.cmdGoLastPage_Click);
			// 
			// mnuComicZoom
			// 
			this.mnuComicZoom.DropDown = this.ctxComicZoomOptions;
			this.mnuComicZoom.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Search;
			this.mnuComicZoom.Name = "mnuComicZoom";
			this.mnuComicZoom.Size = new System.Drawing.Size(163, 22);
			this.mnuComicZoom.Text = "&Zoom";
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(160, 6);
			// 
			// mnuComicRotate
			// 
			this.mnuComicRotate.DropDown = this.ctxRotateOptions;
			this.mnuComicRotate.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.RotateLeft;
			this.mnuComicRotate.Name = "mnuComicRotate";
			this.mnuComicRotate.Size = new System.Drawing.Size(163, 22);
			this.mnuComicRotate.Text = "&Rotación";
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
			// 
			// mnuComicCopy
			// 
			this.mnuComicCopy.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Copy;
			this.mnuComicCopy.Name = "mnuComicCopy";
			this.mnuComicCopy.Size = new System.Drawing.Size(163, 22);
			this.mnuComicCopy.Text = "&Copiar";
			this.mnuComicCopy.Click += new System.EventHandler(this.mnuComicCopy_Click);
			// 
			// mnuComicCut
			// 
			this.mnuComicCut.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Cut;
			this.mnuComicCut.Name = "mnuComicCut";
			this.mnuComicCut.Size = new System.Drawing.Size(163, 22);
			this.mnuComicCut.Text = "&Cortar";
			this.mnuComicCut.Click += new System.EventHandler(this.mnuComicCut_Click);
			// 
			// mnuComicPaste
			// 
			this.mnuComicPaste.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Paste;
			this.mnuComicPaste.Name = "mnuComicPaste";
			this.mnuComicPaste.Size = new System.Drawing.Size(163, 22);
			this.mnuComicPaste.Text = "&Pegar";
			this.mnuComicPaste.Click += new System.EventHandler(this.mnuComicPaste_Click);
			// 
			// mnuComicRemove
			// 
			this.mnuComicRemove.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.mnuComicRemove.Name = "mnuComicRemove";
			this.mnuComicRemove.Size = new System.Drawing.Size(163, 22);
			this.mnuComicRemove.Text = "&Borrar ";
			this.mnuComicRemove.Click += new System.EventHandler(this.cmdRemovePage_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
			// 
			// mnuComicNewPage
			// 
			this.mnuComicNewPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.mnuComicNewPage.Name = "mnuComicNewPage";
			this.mnuComicNewPage.Size = new System.Drawing.Size(163, 22);
			this.mnuComicNewPage.Text = "Aña&dir página";
			this.mnuComicNewPage.Click += new System.EventHandler(this.cmdNewPage_Click);
			// 
			// mnuComicPageUp
			// 
			this.mnuComicPageUp.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowUp;
			this.mnuComicPageUp.Name = "mnuComicPageUp";
			this.mnuComicPageUp.Size = new System.Drawing.Size(163, 22);
			this.mnuComicPageUp.Text = "&Subir página";
			this.mnuComicPageUp.Click += new System.EventHandler(this.cmdPageUp_Click);
			// 
			// mnuComicPageDown
			// 
			this.mnuComicPageDown.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.ArrowDown;
			this.mnuComicPageDown.Name = "mnuComicPageDown";
			this.mnuComicPageDown.Size = new System.Drawing.Size(163, 22);
			this.mnuComicPageDown.Text = "B&ajar página";
			this.mnuComicPageDown.Click += new System.EventHandler(this.cmdPageDown_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(160, 6);
			// 
			// mnuComicSave
			// 
			this.mnuComicSave.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Save;
			this.mnuComicSave.Name = "mnuComicSave";
			this.mnuComicSave.Size = new System.Drawing.Size(163, 22);
			this.mnuComicSave.Text = "&Grabar";
			this.mnuComicSave.Click += new System.EventHandler(this.mnuComicSave_Click);
			// 
			// mnuComicPrintMenu
			// 
			this.mnuComicPrintMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuComicPrint,
            this.mnuComicPrintPreview});
			this.mnuComicPrintMenu.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.printer;
			this.mnuComicPrintMenu.Name = "mnuComicPrintMenu";
			this.mnuComicPrintMenu.Size = new System.Drawing.Size(163, 22);
			this.mnuComicPrintMenu.Text = "&Impresión";
			// 
			// mnuComicPrint
			// 
			this.mnuComicPrint.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.printer;
			this.mnuComicPrint.Name = "mnuComicPrint";
			this.mnuComicPrint.Size = new System.Drawing.Size(199, 22);
			this.mnuComicPrint.Text = "&Imprimir";
			this.mnuComicPrint.Click += new System.EventHandler(this.mnuComicPrint_Click);
			// 
			// mnuComicPrintPreview
			// 
			this.mnuComicPrintPreview.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.PageSearch;
			this.mnuComicPrintPreview.Name = "mnuComicPrintPreview";
			this.mnuComicPrintPreview.Size = new System.Drawing.Size(199, 22);
			this.mnuComicPrintPreview.Text = "&Presentación preliminar";
			this.mnuComicPrintPreview.Click += new System.EventHandler(this.mnuComicPrintPreview_Click);
			// 
			// trbWidthThumbs
			// 
			this.trbWidthThumbs.Dock = System.Windows.Forms.DockStyle.Fill;
			this.trbWidthThumbs.LargeChange = 50;
			this.trbWidthThumbs.Location = new System.Drawing.Point(3, 557);
			this.trbWidthThumbs.Maximum = 200;
			this.trbWidthThumbs.Minimum = 50;
			this.trbWidthThumbs.Name = "trbWidthThumbs";
			this.trbWidthThumbs.Size = new System.Drawing.Size(234, 28);
			this.trbWidthThumbs.SmallChange = 20;
			this.trbWidthThumbs.TabIndex = 1;
			this.trbWidthThumbs.TickFrequency = 10;
			this.trbWidthThumbs.Value = 100;
			this.trbWidthThumbs.ValueChanged += new System.EventHandler(this.trbWidthThumbs_ValueChanged);
			// 
			// imgPage
			// 
			this.imgPage.AutoScroll = true;
			this.imgPage.AutoScrollMinSize = new System.Drawing.Size(4000, 4000);
			this.imgPage.BackColor = System.Drawing.Color.White;
			this.imgPage.CanSelectRectangle = false;
			this.imgPage.ContextMenuStrip = this.mnuComic;
			this.imgPage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgPage.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
			this.imgPage.Location = new System.Drawing.Point(0, 0);
			this.imgPage.Name = "imgPage";
			this.imgPage.Picture = null;
			this.imgPage.RectangleSelected = new System.Drawing.Rectangle(0, 0, 0, 0);
			this.imgPage.Size = new System.Drawing.Size(472, 588);
			this.imgPage.TabIndex = 4;
			this.imgPage.Text = "pictureZoom1";
			this.imgPage.Zoom = 1D;
			this.imgPage.ZoomView = Bau.Controls.ImageControls.Picture.PictureZoom.ZoomMode.Normal;
			this.imgPage.StartPageReached += new System.EventHandler(this.imgPage_StartPageReached);
			this.imgPage.EndPageReached += new System.EventHandler(this.imgPage_EndPageReached);
			// 
			// frmComic
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(726, 614);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmComic";
			this.ShowInTaskbar = false;
			this.TabText = "Ayuda";
			this.Text = "Comic";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmComic_FormClosing);
			this.Load += new System.EventHandler(this.frmHelp_Load);
			this.Shown += new System.EventHandler(this.frmComic_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ctxComicZoomOptions.ResumeLayout(false);
			this.ctxRotateOptions.ResumeLayout(false);
			this.splMain.Panel1.ResumeLayout(false);
			this.splMain.Panel2.ResumeLayout(false);
			this.splMain.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.mnuComic.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trbWidthThumbs)).EndInit();
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
		private Bau.Controls.ImageControls.Thumbnail.ThumbnailList lstThumbs;
		private Bau.Controls.ImageControls.Picture.PictureZoom imgPage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton cmdShowPages;
		private System.Windows.Forms.ToolStripButton cmdShowThumb;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TrackBar trbWidthThumbs;
		private System.Windows.Forms.ToolStripLabel lblMarkAsDeleted;
		private System.Windows.Forms.ToolStripButton cmdRemovePage;
		private System.Windows.Forms.ToolStripButton cmdPageDown;
		private System.Windows.Forms.ToolStripButton cmdPageUp;
		private System.Windows.Forms.ToolStripButton cmdNewPage;
		private System.Windows.Forms.ToolStripLabel toolStripLabel2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ContextMenuStrip mnuComic;
		private System.Windows.Forms.ToolStripMenuItem mnuComicFirstPage;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPreviousPage;
		private System.Windows.Forms.ToolStripMenuItem mnuComicNextPage;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoom;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem mnuComicCopy;
		private System.Windows.Forms.ToolStripMenuItem mnuComicCut;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPaste;
		private System.Windows.Forms.ToolStripMenuItem mnuComicRemove;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPageUp;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPageDown;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem mnuComicSave;
		private System.Windows.Forms.ToolStripMenuItem mnuComicLastPage;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPrintMenu;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPrint;
		private System.Windows.Forms.ToolStripMenuItem mnuComicPrintPreview;
		private System.Windows.Forms.ContextMenuStrip ctxComicZoomOptions;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptionsFitWindow;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptionsFitWidth;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptionsFitHeight;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions25;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions50;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions75;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions100;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions125;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions150;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions175;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptions200;
		private System.Windows.Forms.ToolStripDropDownButton cmdZoom;
		private System.Windows.Forms.ToolStripMenuItem mnuComicNewPage;
		private System.Windows.Forms.ToolStripButton cmdInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem mnuComicZoomOptionsMagnifier;
		private System.Windows.Forms.ContextMenuStrip ctxRotateOptions;
		private System.Windows.Forms.ToolStripMenuItem mnuRotate90;
		private System.Windows.Forms.ToolStripMenuItem mnuRotate180;
		private System.Windows.Forms.ToolStripMenuItem mnuRotate270;
		private System.Windows.Forms.ToolStripMenuItem mnuRotateLeft;
		private System.Windows.Forms.ToolStripMenuItem mnuRotateRight;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem mnuRotateNoRotation;
		private System.Windows.Forms.ToolStripDropDownButton cmdRotate;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem mnuComicRotate;
		private System.Windows.Forms.ToolStripMenuItem mnuRotateFlipHorizontal;
		private System.Windows.Forms.ToolStripMenuItem mnuRotateFlipVertical;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem70;
		private Bau.Controls.Split.CollapsiblePanelSplitter splMain;
	}
}