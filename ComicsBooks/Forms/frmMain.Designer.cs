using System.Windows.Forms;

namespace Bau.Applications.ComicsBooks.Forms
{
	partial class frmMain
	{	// Variable necesaria para el diseñador
			private System.ComponentModel.IContainer components = null;
		// Controles
			private MenuStrip mnuMain;
			private ToolStripMenuItem mnuFiles;
			private ToolStripMenuItem mnuFilesExit;
			private ToolStripMenuItem mnuTools;
			private ToolStripMenuItem mnuToolsSeeWindow;
			private StatusStrip stbMain;
			private ToolStripStatusLabel lblStatus;
			private ToolStripMenuItem mnuSeeWindowEmpty;
			private ToolStripMenuItem mnuWindows;
			private ToolStripMenuItem mnuWindowsCloseAll;
			private ToolStripProgressBar prgProgress;
			private ToolStripContainer toolStripContainer1;
			private WeifenLuo.WinFormsUI.Docking.DockPanel dckMain;
			private ToolStripMenuItem mnuFilesNew;
			private ToolStripMenuItem mnuFilesOpen;
			private ToolStripMenuItem mnuFilesSave;
			private ToolStripMenuItem mnuEdit;
			private ToolStripMenuItem mnuHelp;
			private ToolStripMenuItem mnuEditCopy;
			private ToolStripMenuItem mnuEditCut;
			private ToolStripMenuItem mnuEditPaste;
			private ToolStripSeparator toolStripMenuItem3;
			private ToolStripMenuItem mnuEditRemove;
			private ToolStripMenuItem mnuHelpIndex;
			private ToolStripSeparator toolStripMenuItem1;
		private ToolStrip tlbFiles;
			private ToolStripButton cmdTlbOpen;
			private ToolStripButton cmdTlbSave;
			private ToolStripSeparator toolStripSeparator1;
			private ToolStripSeparator toolStripSeparator3;
			private ToolStripButton cmdTlbEditCopy;
			private ToolStripButton cmdTlbEditCut;
			private ToolStripButton cmdTlbEditPaste;
			private ToolStripSeparator toolStripSeparator2;
			private ToolStripButton cmdTlbEditRemove;
			private ToolStripSeparator toolStripSeparator5;
			private ToolStripButton cmdTlbPrint;
			private ToolStripMenuItem mnuFilesPrint;
			private ToolStripSeparator toolStripMenuItem7;
			private ToolStripSeparator toolStripMenuItem9;
			private ToolStripMenuItem mnuHelpAbout;
			private ToolStripMenuItem mnuToolsOptions;
			private ToolStripButton cmdTlbRefresh;
			private ToolStripSeparator toolStripMenuItem6;
			private ToolStripMenuItem mnuEditRefresh;
			private ToolStripMenuItem mnuFilesPageSetup;
			private ContextMenuStrip mnuChildForm;
			private ToolStripMenuItem mnuChildFormClose;
			private ToolStripMenuItem mnuChildFormExcept;			

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
			WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.mnuMain = new System.Windows.Forms.MenuStrip();
			this.mnuFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesNew = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesNewDocument = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesNewEBook = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFilesNewPage = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesOpen = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesSave = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesExport = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesExportHTML = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesExportEPub = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesImportOPML = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFilesPrint = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesPrintPreview = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuFilesPageSetup = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFilesLastFiles = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuFilesExit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEditCopy = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEditCut = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuEditPaste = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuEditRemove = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuEditRefresh = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuTools = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsSeeWindow = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuSeeWindowEmpty = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWindows = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuWindowsCloseAll = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuHelpIndex = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
			this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
			this.stbMain = new System.Windows.Forms.StatusStrip();
			this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.prgProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.tlbFiles = new System.Windows.Forms.ToolStrip();
			this.cmdTlbNew = new System.Windows.Forms.ToolStripSplitButton();
			this.cmdFilesNewFile = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdFilesNewPage = new System.Windows.Forms.ToolStripMenuItem();
			this.cmdTlbOpen = new System.Windows.Forms.ToolStripButton();
			this.cmdTlbSave = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdTlbPrint = new System.Windows.Forms.ToolStripButton();
			this.cmdPrintPreview = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdTlbRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdTlbEditCopy = new System.Windows.Forms.ToolStripButton();
			this.cmdTlbEditCut = new System.Windows.Forms.ToolStripButton();
			this.cmdTlbEditPaste = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.cmdTlbEditRemove = new System.Windows.Forms.ToolStripButton();
			this.dckMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
			this.mnuChildForm = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.mnuChildFormClose = new System.Windows.Forms.ToolStripMenuItem();
			this.mnuChildFormExcept = new System.Windows.Forms.ToolStripMenuItem();
			this.tlbRSS = new System.Windows.Forms.ToolStrip();
			this.cmdShowNoRead = new System.Windows.Forms.ToolStripButton();
			this.cmdShowRead = new System.Windows.Forms.ToolStripButton();
			this.cmdShowInteresting = new System.Windows.Forms.ToolStripButton();
			this.mnuMain.SuspendLayout();
			this.stbMain.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.tlbFiles.SuspendLayout();
			this.mnuChildForm.SuspendLayout();
			this.tlbRSS.SuspendLayout();
			this.SuspendLayout();
			// 
			// mnuMain
			// 
			this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFiles,
            this.mnuEdit,
            this.mnuTools,
            this.mnuWindows,
            this.mnuHelp});
			this.mnuMain.Location = new System.Drawing.Point(0, 0);
			this.mnuMain.MdiWindowListItem = this.mnuWindows;
			this.mnuMain.Name = "mnuMain";
			this.mnuMain.Size = new System.Drawing.Size(847, 24);
			this.mnuMain.TabIndex = 0;
			this.mnuMain.Text = "mnuMain";
			// 
			// mnuFiles
			// 
			this.mnuFiles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilesNew,
            this.mnuFilesOpen,
            this.mnuFilesSave,
            this.mnuFilesExport,
            this.mnuFilesImportOPML,
            this.toolStripMenuItem1,
            this.mnuFilesPrint,
            this.mnuFilesPrintPreview,
            this.mnuFilesPageSetup,
            this.toolStripMenuItem2,
            this.mnuFilesLastFiles,
            this.toolStripMenuItem7,
            this.mnuFilesExit});
			this.mnuFiles.Name = "mnuFiles";
			this.mnuFiles.Size = new System.Drawing.Size(55, 20);
			this.mnuFiles.Text = "&Archivo";
			// 
			// mnuFilesNew
			// 
			this.mnuFilesNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilesNewDocument,
            this.mnuFilesNewEBook,
            this.toolStripMenuItem4,
            this.mnuFilesNewPage});
			this.mnuFilesNew.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.mnuFilesNew.Name = "mnuFilesNew";
			this.mnuFilesNew.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesNew.Text = "&Nuevo";
			// 
			// mnuFilesNewDocument
			// 
			this.mnuFilesNewDocument.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewDocument;
			this.mnuFilesNewDocument.Name = "mnuFilesNewDocument";
			this.mnuFilesNewDocument.Size = new System.Drawing.Size(117, 22);
			this.mnuFilesNewDocument.Text = "&Cómic";
			this.mnuFilesNewDocument.Click += new System.EventHandler(this.mnuFilesNewDocument_Click);
			// 
			// mnuFilesNewEBook
			// 
			this.mnuFilesNewEBook.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.eBook;
			this.mnuFilesNewEBook.Name = "mnuFilesNewEBook";
			this.mnuFilesNewEBook.Size = new System.Drawing.Size(117, 22);
			this.mnuFilesNewEBook.Text = "&eBook";
			this.mnuFilesNewEBook.Click += new System.EventHandler(this.mnuFilesNewEBook_Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(114, 6);
			// 
			// mnuFilesNewPage
			// 
			this.mnuFilesNewPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.mnuFilesNewPage.Name = "mnuFilesNewPage";
			this.mnuFilesNewPage.Size = new System.Drawing.Size(117, 22);
			this.mnuFilesNewPage.Text = "&Página";
			this.mnuFilesNewPage.Click += new System.EventHandler(this.mnuFilesNewPage_Click);
			// 
			// mnuFilesOpen
			// 
			this.mnuFilesOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
			this.mnuFilesOpen.Name = "mnuFilesOpen";
			this.mnuFilesOpen.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesOpen.Text = "&Abrir";
			this.mnuFilesOpen.Click += new System.EventHandler(this.mnuFilesOpen_Click);
			// 
			// mnuFilesSave
			// 
			this.mnuFilesSave.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Save;
			this.mnuFilesSave.Name = "mnuFilesSave";
			this.mnuFilesSave.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesSave.Text = "&Guardar";
			this.mnuFilesSave.Click += new System.EventHandler(this.mnuFilesSave_Click);
			// 
			// mnuFilesExport
			// 
			this.mnuFilesExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFilesExportHTML,
            this.mnuFilesExportEPub});
			this.mnuFilesExport.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Process;
			this.mnuFilesExport.Name = "mnuFilesExport";
			this.mnuFilesExport.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesExport.Text = "&Exportar";
			// 
			// mnuFilesExportHTML
			// 
			this.mnuFilesExportHTML.Name = "mnuFilesExportHTML";
			this.mnuFilesExportHTML.Size = new System.Drawing.Size(152, 22);
			this.mnuFilesExportHTML.Text = "&HTML";
			this.mnuFilesExportHTML.Click += new System.EventHandler(this.mnuFilesExportHTML_Click);
			// 
			// mnuFilesExportEPub
			// 
			this.mnuFilesExportEPub.Name = "mnuFilesExportEPub";
			this.mnuFilesExportEPub.Size = new System.Drawing.Size(152, 22);
			this.mnuFilesExportEPub.Text = "&ePub";
			this.mnuFilesExportEPub.Click += new System.EventHandler(this.mnuFilesExportEPub_Click);
			// 
			// mnuFilesImportOPML
			// 
			this.mnuFilesImportOPML.Name = "mnuFilesImportOPML";
			this.mnuFilesImportOPML.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesImportOPML.Text = "&Importar noticias (OPML)";
			this.mnuFilesImportOPML.Click += new System.EventHandler(this.mnuFilesImportOPML_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuFilesPrint
			// 
			this.mnuFilesPrint.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.printer;
			this.mnuFilesPrint.Name = "mnuFilesPrint";
			this.mnuFilesPrint.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesPrint.Text = "&Imprimir";
			this.mnuFilesPrint.Click += new System.EventHandler(this.mnuFilesPrint_Click);
			// 
			// mnuFilesPrintPreview
			// 
			this.mnuFilesPrintPreview.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.PageSearch;
			this.mnuFilesPrintPreview.Name = "mnuFilesPrintPreview";
			this.mnuFilesPrintPreview.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesPrintPreview.Text = "&Presentación preliminar";
			this.mnuFilesPrintPreview.Click += new System.EventHandler(this.cmdPrintPreview_Click);
			// 
			// mnuFilesPageSetup
			// 
			this.mnuFilesPageSetup.Name = "mnuFilesPageSetup";
			this.mnuFilesPageSetup.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesPageSetup.Text = "&Configurar impresora ...";
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuFilesLastFiles
			// 
			this.mnuFilesLastFiles.Name = "mnuFilesLastFiles";
			this.mnuFilesLastFiles.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesLastFiles.Text = "&Ultimos archivos abiertos";
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(201, 6);
			// 
			// mnuFilesExit
			// 
			this.mnuFilesExit.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Exit;
			this.mnuFilesExit.Name = "mnuFilesExit";
			this.mnuFilesExit.Size = new System.Drawing.Size(204, 22);
			this.mnuFilesExit.Text = "&Salir";
			this.mnuFilesExit.Click += new System.EventHandler(this.mnuFilesExit_Click);
			// 
			// mnuEdit
			// 
			this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditCopy,
            this.mnuEditCut,
            this.mnuEditPaste,
            this.toolStripMenuItem3,
            this.mnuEditRemove,
            this.toolStripMenuItem6,
            this.mnuEditRefresh});
			this.mnuEdit.Name = "mnuEdit";
			this.mnuEdit.Size = new System.Drawing.Size(52, 20);
			this.mnuEdit.Text = "&Edición";
			// 
			// mnuEditCopy
			// 
			this.mnuEditCopy.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Copy;
			this.mnuEditCopy.Name = "mnuEditCopy";
			this.mnuEditCopy.Size = new System.Drawing.Size(132, 22);
			this.mnuEditCopy.Text = "&Copiar";
			this.mnuEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
			// 
			// mnuEditCut
			// 
			this.mnuEditCut.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Cut;
			this.mnuEditCut.Name = "mnuEditCut";
			this.mnuEditCut.Size = new System.Drawing.Size(132, 22);
			this.mnuEditCut.Text = "C&ortar";
			this.mnuEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
			// 
			// mnuEditPaste
			// 
			this.mnuEditPaste.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Paste;
			this.mnuEditPaste.Name = "mnuEditPaste";
			this.mnuEditPaste.Size = new System.Drawing.Size(132, 22);
			this.mnuEditPaste.Text = "&Pegar";
			this.mnuEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(129, 6);
			// 
			// mnuEditRemove
			// 
			this.mnuEditRemove.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.mnuEditRemove.Name = "mnuEditRemove";
			this.mnuEditRemove.Size = new System.Drawing.Size(132, 22);
			this.mnuEditRemove.Text = "&Eliminar";
			this.mnuEditRemove.Click += new System.EventHandler(this.mnuEditRemove_Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(129, 6);
			// 
			// mnuEditRefresh
			// 
			this.mnuEditRefresh.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Refresh;
			this.mnuEditRefresh.Name = "mnuEditRefresh";
			this.mnuEditRefresh.Size = new System.Drawing.Size(132, 22);
			this.mnuEditRefresh.Text = "Actualizar";
			this.mnuEditRefresh.Click += new System.EventHandler(this.mnuEditRefresh_Click);
			// 
			// mnuTools
			// 
			this.mnuTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuToolsSeeWindow,
            this.mnuToolsOptions});
			this.mnuTools.Name = "mnuTools";
			this.mnuTools.Size = new System.Drawing.Size(83, 20);
			this.mnuTools.Text = "&Herramientas";
			// 
			// mnuToolsSeeWindow
			// 
			this.mnuToolsSeeWindow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSeeWindowEmpty});
			this.mnuToolsSeeWindow.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Application;
			this.mnuToolsSeeWindow.Name = "mnuToolsSeeWindow";
			this.mnuToolsSeeWindow.Size = new System.Drawing.Size(144, 22);
			this.mnuToolsSeeWindow.Text = "&Ver";
			this.mnuToolsSeeWindow.DropDownOpening += new System.EventHandler(this.mnuSeeWindow_DropDownOpening);
			// 
			// mnuSeeWindowEmpty
			// 
			this.mnuSeeWindowEmpty.Name = "mnuSeeWindowEmpty";
			this.mnuSeeWindowEmpty.Size = new System.Drawing.Size(115, 22);
			this.mnuSeeWindowEmpty.Text = "Empty";
			// 
			// mnuToolsOptions
			// 
			this.mnuToolsOptions.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Properties;
			this.mnuToolsOptions.Name = "mnuToolsOptions";
			this.mnuToolsOptions.Size = new System.Drawing.Size(144, 22);
			this.mnuToolsOptions.Text = "Opciones ...";
			this.mnuToolsOptions.Click += new System.EventHandler(this.mnuToolsOptions_Click);
			// 
			// mnuWindows
			// 
			this.mnuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuWindowsCloseAll});
			this.mnuWindows.Name = "mnuWindows";
			this.mnuWindows.Size = new System.Drawing.Size(64, 20);
			this.mnuWindows.Text = "&Ventanas";
			// 
			// mnuWindowsCloseAll
			// 
			this.mnuWindowsCloseAll.Name = "mnuWindowsCloseAll";
			this.mnuWindowsCloseAll.Size = new System.Drawing.Size(146, 22);
			this.mnuWindowsCloseAll.Text = "&Cerrar todas";
			this.mnuWindowsCloseAll.Click += new System.EventHandler(this.mnuWindowsCloseAll_Click);
			// 
			// mnuHelp
			// 
			this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpIndex,
            this.toolStripMenuItem9,
            this.mnuHelpAbout});
			this.mnuHelp.Name = "mnuHelp";
			this.mnuHelp.Size = new System.Drawing.Size(50, 20);
			this.mnuHelp.Text = "A&yuda";
			// 
			// mnuHelpIndex
			// 
			this.mnuHelpIndex.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.help;
			this.mnuHelpIndex.Name = "mnuHelpIndex";
			this.mnuHelpIndex.Size = new System.Drawing.Size(148, 22);
			this.mnuHelpIndex.Text = "&Indice";
			this.mnuHelpIndex.Click += new System.EventHandler(this.mnuHelpIndex_Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(145, 6);
			// 
			// mnuHelpAbout
			// 
			this.mnuHelpAbout.Name = "mnuHelpAbout";
			this.mnuHelpAbout.Size = new System.Drawing.Size(148, 22);
			this.mnuHelpAbout.Text = "A&cerca de ...";
			this.mnuHelpAbout.Click += new System.EventHandler(this.mnuHelpAbout_Click);
			// 
			// stbMain
			// 
			this.stbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.prgProgress,
            this.lblVersion});
			this.stbMain.Location = new System.Drawing.Point(0, 523);
			this.stbMain.Name = "stbMain";
			this.stbMain.Size = new System.Drawing.Size(847, 22);
			this.stbMain.TabIndex = 2;
			// 
			// lblStatus
			// 
			this.lblStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(780, 17);
			this.lblStatus.Spring = true;
			this.lblStatus.Text = "Preparado";
			this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// prgProgress
			// 
			this.prgProgress.Name = "prgProgress";
			this.prgProgress.Size = new System.Drawing.Size(100, 16);
			this.prgProgress.Visible = false;
			// 
			// lblVersion
			// 
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(52, 17);
			this.lblVersion.Text = "lblVersion";
			// 
			// toolStripContainer1
			// 
			this.toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(847, 3);
			this.toolStripContainer1.ContentPanel.Visible = false;
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(847, 28);
			this.toolStripContainer1.TabIndex = 0;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tlbFiles);
			// 
			// tlbFiles
			// 
			this.tlbFiles.Dock = System.Windows.Forms.DockStyle.None;
			this.tlbFiles.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tlbFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdTlbNew,
            this.cmdTlbOpen,
            this.cmdTlbSave,
            this.toolStripSeparator1,
            this.cmdTlbPrint,
            this.cmdPrintPreview,
            this.toolStripSeparator5,
            this.cmdTlbRefresh,
            this.toolStripSeparator3,
            this.cmdTlbEditCopy,
            this.cmdTlbEditCut,
            this.cmdTlbEditPaste,
            this.toolStripSeparator2,
            this.cmdTlbEditRemove});
			this.tlbFiles.Location = new System.Drawing.Point(3, 0);
			this.tlbFiles.Name = "tlbFiles";
			this.tlbFiles.Size = new System.Drawing.Size(266, 25);
			this.tlbFiles.TabIndex = 0;
			this.tlbFiles.Text = "tlbMain";
			// 
			// cmdTlbNew
			// 
			this.cmdTlbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdFilesNewFile,
            this.cmdFilesNewPage});
			this.cmdTlbNew.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.cmdTlbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbNew.Name = "cmdTlbNew";
			this.cmdTlbNew.Size = new System.Drawing.Size(32, 22);
			this.cmdTlbNew.Text = "toolStripButton5";
			this.cmdTlbNew.ToolTipText = "Nuevo";
			// 
			// cmdFilesNewFile
			// 
			this.cmdFilesNewFile.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewDocument;
			this.cmdFilesNewFile.Name = "cmdFilesNewFile";
			this.cmdFilesNewFile.Size = new System.Drawing.Size(154, 22);
			this.cmdFilesNewFile.Text = "&Nuevo archivo";
			this.cmdFilesNewFile.Click += new System.EventHandler(this.mnuFilesNewDocument_Click);
			// 
			// cmdFilesNewPage
			// 
			this.cmdFilesNewPage.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.NewPage;
			this.cmdFilesNewPage.Name = "cmdFilesNewPage";
			this.cmdFilesNewPage.Size = new System.Drawing.Size(154, 22);
			this.cmdFilesNewPage.Text = "Nueva &página";
			this.cmdFilesNewPage.Click += new System.EventHandler(this.mnuFilesNewPage_Click);
			// 
			// cmdTlbOpen
			// 
			this.cmdTlbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbOpen.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Folder;
			this.cmdTlbOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbOpen.Name = "cmdTlbOpen";
			this.cmdTlbOpen.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbOpen.Text = "toolStripButton8";
			this.cmdTlbOpen.ToolTipText = "Abrir";
			this.cmdTlbOpen.Click += new System.EventHandler(this.mnuFilesOpen_Click);
			// 
			// cmdTlbSave
			// 
			this.cmdTlbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbSave.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Save;
			this.cmdTlbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbSave.Name = "cmdTlbSave";
			this.cmdTlbSave.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbSave.Text = "toolStripButton6";
			this.cmdTlbSave.ToolTipText = "Guardar";
			this.cmdTlbSave.Click += new System.EventHandler(this.mnuFilesSave_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdTlbPrint
			// 
			this.cmdTlbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbPrint.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.printer;
			this.cmdTlbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbPrint.Name = "cmdTlbPrint";
			this.cmdTlbPrint.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbPrint.Text = "Imprimir";
			this.cmdTlbPrint.ToolTipText = "Imprimir";
			this.cmdTlbPrint.Click += new System.EventHandler(this.mnuFilesPrint_Click);
			// 
			// cmdPrintPreview
			// 
			this.cmdPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdPrintPreview.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.PageSearch;
			this.cmdPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdPrintPreview.Name = "cmdPrintPreview";
			this.cmdPrintPreview.Size = new System.Drawing.Size(23, 22);
			this.cmdPrintPreview.Text = "Presentación preliminar";
			this.cmdPrintPreview.Click += new System.EventHandler(this.cmdPrintPreview_Click);
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdTlbRefresh
			// 
			this.cmdTlbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbRefresh.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Refresh;
			this.cmdTlbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbRefresh.Name = "cmdTlbRefresh";
			this.cmdTlbRefresh.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbRefresh.Text = "Actualizar";
			this.cmdTlbRefresh.Click += new System.EventHandler(this.mnuEditRefresh_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdTlbEditCopy
			// 
			this.cmdTlbEditCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbEditCopy.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Copy;
			this.cmdTlbEditCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbEditCopy.Name = "cmdTlbEditCopy";
			this.cmdTlbEditCopy.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbEditCopy.Text = "toolStripButton1";
			this.cmdTlbEditCopy.ToolTipText = "Copiar";
			this.cmdTlbEditCopy.Click += new System.EventHandler(this.mnuEditCopy_Click);
			// 
			// cmdTlbEditCut
			// 
			this.cmdTlbEditCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbEditCut.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Cut;
			this.cmdTlbEditCut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbEditCut.Name = "cmdTlbEditCut";
			this.cmdTlbEditCut.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbEditCut.Text = "toolStripButton2";
			this.cmdTlbEditCut.ToolTipText = "Cortar";
			this.cmdTlbEditCut.Click += new System.EventHandler(this.mnuEditCut_Click);
			// 
			// cmdTlbEditPaste
			// 
			this.cmdTlbEditPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbEditPaste.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Paste;
			this.cmdTlbEditPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbEditPaste.Name = "cmdTlbEditPaste";
			this.cmdTlbEditPaste.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbEditPaste.Text = "toolStripButton3";
			this.cmdTlbEditPaste.ToolTipText = "Pegar";
			this.cmdTlbEditPaste.Click += new System.EventHandler(this.mnuEditPaste_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// cmdTlbEditRemove
			// 
			this.cmdTlbEditRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdTlbEditRemove.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.Remove;
			this.cmdTlbEditRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdTlbEditRemove.Name = "cmdTlbEditRemove";
			this.cmdTlbEditRemove.Size = new System.Drawing.Size(23, 22);
			this.cmdTlbEditRemove.Text = "toolStripButton4";
			this.cmdTlbEditRemove.ToolTipText = "Borrar";
			this.cmdTlbEditRemove.Click += new System.EventHandler(this.mnuEditRemove_Click);
			// 
			// dckMain
			// 
			this.dckMain.ActiveAutoHideContent = null;
			this.dckMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.dckMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dckMain.DockBackColor = System.Drawing.SystemColors.Control;
			this.dckMain.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
			this.dckMain.Location = new System.Drawing.Point(0, 52);
			this.dckMain.Name = "dckMain";
			this.dckMain.ShowDocumentIcon = true;
			this.dckMain.Size = new System.Drawing.Size(847, 471);
			dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
			autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
			tabGradient1.EndColor = System.Drawing.SystemColors.Control;
			tabGradient1.StartColor = System.Drawing.SystemColors.Control;
			tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			autoHideStripSkin1.TabGradient = tabGradient1;
			dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
			tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
			tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
			dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
			dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
			dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
			tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
			dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
			tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
			tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
			tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
			dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
			tabGradient5.EndColor = System.Drawing.SystemColors.Control;
			tabGradient5.StartColor = System.Drawing.SystemColors.Control;
			tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
			dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
			dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
			dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
			tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
			tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
			tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
			dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
			tabGradient7.EndColor = System.Drawing.Color.Transparent;
			tabGradient7.StartColor = System.Drawing.Color.Transparent;
			tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
			dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
			dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
			dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
			this.dckMain.Skin = dockPanelSkin1;
			this.dckMain.TabIndex = 1;
			this.dckMain.ActiveContentChanged += new System.EventHandler(this.dckMain_ActiveContentChanged);
			// 
			// mnuChildForm
			// 
			this.mnuChildForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuChildFormClose,
            this.mnuChildFormExcept});
			this.mnuChildForm.Name = "mnuChildForm";
			this.mnuChildForm.Size = new System.Drawing.Size(251, 48);
			// 
			// mnuChildFormClose
			// 
			this.mnuChildFormClose.Name = "mnuChildFormClose";
			this.mnuChildFormClose.Size = new System.Drawing.Size(250, 22);
			this.mnuChildFormClose.Text = "&Cerrar";
			// 
			// mnuChildFormExcept
			// 
			this.mnuChildFormExcept.Name = "mnuChildFormExcept";
			this.mnuChildFormExcept.Size = new System.Drawing.Size(250, 22);
			this.mnuChildFormExcept.Text = "C&errar todo excepto esta ventana";
			// 
			// tlbRSS
			// 
			this.tlbRSS.Dock = System.Windows.Forms.DockStyle.None;
			this.tlbRSS.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.tlbRSS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdShowNoRead,
            this.cmdShowRead,
            this.cmdShowInteresting});
			this.tlbRSS.Location = new System.Drawing.Point(282, 24);
			this.tlbRSS.Name = "tlbRSS";
			this.tlbRSS.Size = new System.Drawing.Size(72, 25);
			this.tlbRSS.TabIndex = 4;
			this.tlbRSS.Text = "toolStrip1";
			// 
			// cmdShowNoRead
			// 
			this.cmdShowNoRead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdShowNoRead.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.EMail;
			this.cmdShowNoRead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdShowNoRead.Name = "cmdShowNoRead";
			this.cmdShowNoRead.Size = new System.Drawing.Size(23, 22);
			this.cmdShowNoRead.Text = "toolStripButton1";
			this.cmdShowNoRead.ToolTipText = "Mostrar elementos no leídos";
			this.cmdShowNoRead.Click += new System.EventHandler(this.cmdShowNoRead_Click);
			// 
			// cmdShowRead
			// 
			this.cmdShowRead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdShowRead.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.EMailOpen;
			this.cmdShowRead.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdShowRead.Name = "cmdShowRead";
			this.cmdShowRead.Size = new System.Drawing.Size(23, 22);
			this.cmdShowRead.Text = "toolStripButton2";
			this.cmdShowRead.ToolTipText = "Mostrar elementos leídos";
			this.cmdShowRead.Click += new System.EventHandler(this.cmdShowRead_Click);
			// 
			// cmdShowInteresting
			// 
			this.cmdShowInteresting.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.cmdShowInteresting.Image = global::Bau.Applications.ComicsBooks.Properties.Resources.exclamation;
			this.cmdShowInteresting.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cmdShowInteresting.Name = "cmdShowInteresting";
			this.cmdShowInteresting.Size = new System.Drawing.Size(23, 22);
			this.cmdShowInteresting.Text = "toolStripButton3";
			this.cmdShowInteresting.ToolTipText = "Mostrar elementos interesantes";
			this.cmdShowInteresting.Click += new System.EventHandler(this.cmdShowInteresting_Click);
			// 
			// frmMain
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(847, 545);
			this.Controls.Add(this.tlbRSS);
			this.Controls.Add(this.dckMain);
			this.Controls.Add(this.toolStripContainer1);
			this.Controls.Add(this.stbMain);
			this.Controls.Add(this.mnuMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.mnuMain;
			this.Name = "frmMain";
			this.Text = "ComicBook";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.frmMain_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.frmMain_DragEnter);
			this.mnuMain.ResumeLayout(false);
			this.mnuMain.PerformLayout();
			this.stbMain.ResumeLayout(false);
			this.stbMain.PerformLayout();
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.tlbFiles.ResumeLayout(false);
			this.tlbFiles.PerformLayout();
			this.mnuChildForm.ResumeLayout(false);
			this.tlbRSS.ResumeLayout(false);
			this.tlbRSS.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{	if (disposing && (components != null))
				components.Dispose();
			base.Dispose(disposing);
		}

		private ToolStripMenuItem mnuFilesPrintPreview;
		private ToolStripButton cmdPrintPreview;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripMenuItem mnuFilesLastFiles;
		private ToolStripMenuItem mnuFilesNewDocument;
		private ToolStripMenuItem mnuFilesNewPage;
		private ToolStripSplitButton cmdTlbNew;
		private ToolStripMenuItem cmdFilesNewFile;
		private ToolStripMenuItem cmdFilesNewPage;
		private ToolStripStatusLabel lblVersion;
		private ToolStripMenuItem mnuFilesExport;
		private ToolStripMenuItem mnuFilesExportHTML;
		private ToolStripMenuItem mnuFilesExportEPub;
		private ToolStripMenuItem mnuFilesImportOPML;
		private ToolStrip tlbRSS;
		private ToolStripButton cmdShowNoRead;
		private ToolStripButton cmdShowRead;
		private ToolStripButton cmdShowInteresting;
		private ToolStripMenuItem mnuFilesNewEBook;
		private ToolStripSeparator toolStripMenuItem4;
	}
}
