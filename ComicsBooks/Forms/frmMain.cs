using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Forms.Explorer;
using Bau.Applications.ComicsBooks.Forms.Tools;
using Bau.Applications.ComicsBooks.Properties;

using Bau.Libraries.LibHelper;

namespace Bau.Applications.ComicsBooks.Forms
{
	/// <summary>
	///		Formulario principal de la aplicación
	/// </summary>
	public partial class frmMain : Form
	{ // Delegados
			private delegate void WindowCallback(); // Permite llamadas asíncronas para habilitar los botones
			private delegate void ShowProgressBarCallback(string strCaption, int intMaximum, int intValue); // Permite llamadas asíncronas para cambiar la barra de progreso
		// Variables privadas
			private string [] arrStrFileNames = null;

		public frmMain()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Muestra el formulario de splash
				ShowSplash();
			// Inicializa los controles
				lblVersion.Text = "Versión: " + Application.ProductVersion;
				cmdShowRead.Checked = clsConfiguration.ShowRead;
				cmdShowNoRead.Checked = clsConfiguration.ShowNoRead;
				cmdShowInteresting.Checked = clsConfiguration.ShowInteresting;
			// Elimina los archivos temporales
				KillTempPath();
			// Copia la plantilla inicial para los blogs
				Forms.Blog.Classes.TemplateManager.CopyFiles();
			// Añade los formularios dockables
				Program.DockedForms.Add(new clsDockedForm(new frmLibrary(), DockState.DockLeft, "Biblioteca"));
				Program.DockedForms.Add(new clsDockedForm(new frmComicsWeb(), DockState.DockLeft, "Comics Web"));
				Program.DockedForms.Add(new clsDockedForm(new frmExplorerFiles(), DockState.DockLeft, "Archivos"));
				Program.DockedForms.Add(new clsDockedForm(new Forms.Blog.frmBlogExplorer(), DockState.DockLeft, "Noticias"));
				Program.DockedForms.Add(new clsDockedForm(new frmLog(), DockState.DockBottomAutoHide, "Log"));
				Program.DockedForms.Add(new clsDockedForm(new Forms.Help.frmHelpIndex(), DockState.DockRightAutoHide, "Ayuda"));
			// Carga la configuración de los paneles
				if (!Program.DockedForms.LoadDockConfiguration(clsConfiguration.PathBaseData, dckMain))
					foreach (clsDockedForm objDockedForm in Program.DockedForms)
						objDockedForm.Show();
			// Refresca el formulario
				this.Invalidate();
			// Habilita / inhabilita los botones
				EnableButtons();
			// Carga los últimos archivos y los muestra en el menú
				LoadLastFiles();
				ShowMenuLastFiles();
			// Maximiza el formulario
				WindowState = FormWindowState.Maximized;
			// Graba el evento
				Program.Log("Inicio de sesión");
			// Carga los cómics pasados como comando
				LoadComics(FileNames);
		}

		/// <summary>
		///		Muestra el formulario de splash
		/// </summary>
		private void ShowSplash()
		{	Bau.Controls.Forms.frmSplash frmNewSplash = new Bau.Controls.Forms.frmSplash();
					
				frmNewSplash.BackGroundImage = Properties.Resources.Splash;
				frmNewSplash.Show();
		}		
		
		/// <summary>
		///		Habilita / inhabilita los botones
		/// </summary>
		public void EnableButtons()
		{	// InvokeRequired compara el ID del hilo llamante con el ID del hilo creador, si son diferentes devuelve True
				if (this.InvokeRequired)
					{	WindowCallback fncCallback = new WindowCallback(EnableButtons);
					
					    Invoke(fncCallback);
					}
				else
					{	// Inhabilita los menús
							mnuFilesNewPage.Enabled = mnuFilesOpen.Enabled = mnuFilesSave.Enabled = 
																				mnuFilesPageSetup.Enabled = mnuFilesPrint.Enabled = 
																				mnuFilesPrintPreview.Enabled = false;
							mnuEditCopy.Enabled = mnuEditCut.Enabled = mnuEditPaste.Enabled = mnuEditRemove.Enabled = false;
							mnuEditRefresh.Enabled = false;
							mnuFilesExport.Enabled = mnuFilesExportHTML.Enabled = mnuFilesExportEPub.Enabled = false;
						// Oculta las barras de herramientas
							tlbRSS.Visible = false;
						// Habilita los botones adecuados dependiendo del interface del documento
							if (dckMain.ActiveContent != null && dckMain.ActiveContent is IPluginDocument)
								{ // Habilita los menús
										mnuFilesNewPage.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.NewPage);
										mnuFilesOpen.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Open);
										mnuFilesSave.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Save);
										mnuFilesExportHTML.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.ExportHTML);
										mnuFilesExportEPub.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.ExportEPub);
										mnuFilesExport.Enabled = mnuFilesExportHTML.Enabled || mnuFilesExportEPub.Enabled;
										mnuFilesPageSetup.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.PrintWithDialog);
										mnuFilesPrint.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Print);
										mnuFilesPrintPreview.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.PrintPreview);
										mnuEditCopy.Enabled = mnuEditCut.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Copy);
										mnuEditPaste.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Paste);
										mnuEditRemove.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Remove);
										mnuEditRefresh.Enabled = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.Refresh);
									// Habilita la barra de herramientas de lectura de blogs
										tlbRSS.Visible = ((IPluginDocument) dckMain.ActiveContent).CanExecuteAction(clsEnums.TypeAction.ShowBlogItems);
								}
						// Habilita los botones de la barra de herramientas
							cmdFilesNewPage.Enabled = mnuFilesNewPage.Enabled;
							cmdTlbOpen.Enabled = mnuFilesOpen.Enabled;
							cmdTlbSave.Enabled = mnuFilesSave.Enabled;
							cmdTlbPrint.Enabled = mnuFilesPrint.Enabled;
							cmdPrintPreview.Enabled = mnuFilesPrintPreview.Enabled;
							cmdTlbEditCopy.Enabled = mnuEditCopy.Enabled;
							cmdTlbEditCut.Enabled = mnuEditCut.Enabled;
							cmdTlbEditPaste.Enabled = mnuEditPaste.Enabled;
							cmdTlbEditRemove.Enabled = mnuEditRemove.Enabled;
							cmdTlbRefresh.Enabled = mnuEditRefresh.Enabled;
					}	
		}
	
		/// <summary>
		///		Carga los últimos archivos
		/// </summary>
		private void LoadLastFiles()
		{ try
				{ Program.LastFiles.Load(Application.StartupPath);
				}
			catch (Exception objException) 
				{ Program.Log("Error al cargar los últimos archivos abiertos\n" + objException.Message); 
				}
		}
		
		/// <summary>
		///		Añade un archivo a la colección de últimos archivos cargados
		/// </summary>
		internal void AddLastFile(string strLastFile)
		{ // Añade el archivo
				Program.LastFiles.Add(strLastFile, DateTime.Now);
			// Carga los últimos archivos en el menú
				ShowMenuLastFiles();
		}

		/// <summary>
		///		Abre los cómics pasados como parámetros desde Windows
		/// </summary>
		private void LoadComics(string [] arrStrFileNames)
		{ // Carga los cómics
				foreach (string strFileName in arrStrFileNames)
					if (File.Exists(strFileName))
						Program.DockedForms.OpenForm(strFileName);
			// Limpia la lista de cómics
				arrStrFileNames = null;
		}
		
		/// <summary>
		///		Carga los últimos archivos en el menú
		/// </summary>
		private void ShowMenuLastFiles()
		{ // Elimina los elementos del menú
				if (mnuFilesLastFiles.DropDown != null)
					mnuFilesLastFiles.DropDown.Items.Clear();
			// Crea los elementos del menú
				for (int intIndex = Program.LastFiles.Count - 1; intIndex >= 0; intIndex--)
					{ ToolStripMenuItem objMenu = new ToolStripMenuItem(Path.GetFileName(Program.LastFiles[intIndex].FileName));
					
							// En el tag guarda el objeto
								objMenu.Tag = Program.LastFiles[intIndex];
							// Añade el manejador de eventos
								objMenu.Click += new EventHandler(mnuLastFiles_Click);
							// Añade el menú
								mnuFilesLastFiles.DropDown.Items.Add(objMenu);
					}
		}
	
		/// <summary>
		///		Añade los nombres de las ventanas laterales al menú de Ver | Ventanas
		/// </summary>
		private void AddMenuSeeWindows(ToolStripMenuItem mnuSeeWindow)
		{ ToolStripMenuItem mnuItem;
		
				// Borra los elementos
					mnuSeeWindow.DropDownItems.Clear();
				// Recorre los formularios que se muestran como ventanas dock
					foreach (clsDockedForm objForm in Program.DockedForms)
						{ // Crea un nuevo elemento de menú
								mnuItem = new ToolStripMenuItem();
							// Asigna las propiedades del menú
								mnuItem.Text = objForm.MenuName;
								mnuItem.Checked = objForm.Visible;
								mnuItem.Tag = objForm;
							// Asigna el manejador de eventos
								mnuItem.Click += new EventHandler(mnuSeeWindowDock_Click);
							// Añade el elemento al menú
								mnuSeeWindow.DropDownItems.Add(mnuItem);
						}
		}
		
		/// <summary>
		///		Crea un nuevo archivo de cómics
		/// </summary>
		private void NewFile()
		{ Program.DockedForms.OpenFormAdmon<string>(colDockedForms.FormType.Comic, null);
		}
		
		/// <summary>
		///		Abre el formulario de creación de un eBook
		/// </summary>
		private void NewEBook()
		{ Program.DockedForms.OpenFormAdmon<string>(colDockedForms.FormType.ePubCreator, null);
		}

		/// <summary>
		///		Llama al documento abierto para que ejecute una acción
		/// </summary>
		private void ExecuteAction(clsEnums.TypeAction intAction)
		{ if (dckMain.ActiveContent != null && dckMain.ActiveContent is IPluginDocument)
				((IPluginDocument) dckMain.ActiveContent).ExecuteAction(intAction);
		}
		
		
		/// <summary>
		///		Muestra un mensaje en el panel de información
		/// </summary>
		public void ShowPanelStatus(string strMessage)
		{ lblStatus.Text = strMessage;
		}

		/// <summary>
		///		Actualiza los menús y barras de herramientas
		/// </summary>
		public void RefreshWindow()
		{	// Habilita los botones
				EnableButtons();
		}
		
		/// <summary>
		///		Abre el formulario de configuración
		/// </summary>
		private void OpenFormConfiguration()
		{ Forms.Tools.frmConfiguration frmNewConfiguration = new Forms.Tools.frmConfiguration();
		
				// Abre el formulario
					frmNewConfiguration.ShowDialog();
		}
		
		/// <summary>
		///		Abre una ventana de documento
		/// </summary>
		internal void OpenWindowDocument(DockContent frmDocument)
		{ Form frmWindow = FindForm((string) frmDocument.Tag);
		
				// Si no ha encontrado nada, abre un nuevo documento
					if (frmWindow == null)
						OpenChildWindow(frmDocument.Text, frmDocument);
					else
						frmWindow.Activate();
		}		

		/// <summary>
		///		Abre el formulario "Acerca de ..."
		/// </summary>
		private void OpenFormAbout()
		{ (new Forms.Tools.frmAbout()).ShowDialog();
		}
		
		/// <summary>
		///		Importa los datos de un archivo OPML
		/// </summary>
		private void ImportOPML()
		{ string strFileName = Bau.Controls.Forms.Helper.GetFileNameOpen("Archivos OPML (*.opml)|*.opml|Archivos XML (*.xml)|*.xml|Todos los archivos (*.*)|*.*");
		
				if (!string.IsNullOrEmpty(strFileName) && System.IO.File.Exists(strFileName))
					try
						{	if (!Program.BlogsManager.Import(strFileName))
								Bau.Controls.Forms.Helper.ShowMessage(this, "No se ha podido importar el archivo.\nCompruebe el formato");
							else
								Bau.Controls.Forms.Helper.ShowMessage(this, "Archivo importado correctamente");
						}
					catch (Exception objException)
						{ Bau.Controls.Forms.Helper.ShowMessage(this, "Error al importar el archivo" + Environment.NewLine + 
																													objException.Message);
						}
		}
		
		/// <summary>
		///		Activa un documento
		/// </summary>
		internal bool ActivateDocument(string strID)
		{	Form frmWndDocument = FindForm(strID);
			bool blnActivate = false;
		
				// Si se ha encontrado una ventana con ese ID, se activa
					if (frmWndDocument != null)
						{ // Activa la ventana
								frmWndDocument.Activate();
							// Indica que se ha activado
								blnActivate = true;
						}
				// Devuelve el valor que indica si se ha activado
					return blnActivate;
		}
				
		/// <summary>
		/// 	Abre una ventana hijo en el cuerpo de la ventana principal
		/// </summary>
		private void OpenChildWindow(string strTitle, DockContent frmChildWindow)
		{	// Cambia el título del documento
				frmChildWindow.Text = strTitle;
				frmChildWindow.TabText = frmChildWindow.Text;
				frmChildWindow.ToolTipText = frmChildWindow.Text;
			// Cambia el menú contextual
				frmChildWindow.ContextMenuStrip = mnuChildForm;
			// Muestra el formulario
				frmChildWindow.Show(dckMain);
		}
		
		/// <summary>
		///		Busca un formulario entre los formularios abiertos
		/// </summary>
		internal Form FindForm(string strID)
		{	Form frmFound = null;

				// Busca el formulario con ese ID
					if (dckMain.DocumentStyle == DocumentStyle.SystemMdi)
						{	foreach (Form frmGeneral in MdiChildren)
								if ((string) frmGeneral.Tag == strID)
									frmFound = frmGeneral;
						}
					else
						{	foreach (IDockContent dckContent in dckMain.Documents)
								if ((string) ((Form) dckContent).Tag == strID)
									frmFound = (Form) dckContent;
						}
				// Devuelve el formulario encontrado
					return frmFound;
		}		
			
		/// <summary>
		///		Muestra la barra de progreso
		/// </summary>
		public void ShowProgressBar(string strCaption, int intMaximum, int intValue)
		{ // InvokeRequired compara el ID del hilo llamante con el ID del hilo creador, si son diferentes devuelve True
				if (this.InvokeRequired)
					{	ShowProgressBarCallback fncCallback = new ShowProgressBarCallback(ShowProgressBar);
					
							Invoke(fncCallback, new object[] { strCaption, intMaximum, intValue });
					}
				else
					{	// Muestra / oculta la barra de progreso
							prgProgress.Visible = (intMaximum > intValue);
						// Inicializa la barra
							lblStatus.Text = strCaption;
							prgProgress.Maximum = intMaximum;
							prgProgress.Minimum = 0;
							if (intValue < intMaximum)
								prgProgress.Value = intValue;
							else if (intMaximum > 0)
								prgProgress.Value = intMaximum - 1;
						// Actualiza la ventana
							Application.DoEvents();
						// Oculta la barra
							if (!prgProgress.Visible)
								HideProgressBar();
					}
		}	

		/// <summary>
		///		Oculta la barra de progreso
		/// </summary>
		internal void HideProgressBar()
		{ // InvokeRequired compara el ID del hilo llamante con el ID del hilo creador, si son diferentes devuelve True
				if (this.InvokeRequired)
					{	WindowCallback fncCallback = new WindowCallback(HideProgressBar);
					
							Invoke(fncCallback);
					}
				else
					{	prgProgress.Visible = false;
						lblStatus.Text = "Preparado";
					}
		}

		/// <summary>
		///		Cierra todas las ventanas
		/// </summary>
		private void CloseAllWindows()
		{	if (dckMain.DocumentStyle == DocumentStyle.SystemMdi)
				foreach (Form frmGeneral in MdiChildren)
					frmGeneral.Close();
			else
				{ IDockContent [] arrObjDocuments = dckMain.DocumentsToArray();
						
						for (int intIndex = 0; intIndex < arrObjDocuments.Length; intIndex++)
							arrObjDocuments[intIndex].DockHandler.Close();
				}
		}
		
		/// <summary>
		///		Elimina el directorio temporal
		/// </summary>
		private void KillTempPath()
		{ Bau.Libraries.LibHelper.Files.HelperFiles.KillPath(Program.GetTempPath());
		}
				
		/// <summary>
		///		Graba la configuración
		/// </summary>
		private void SaveConfiguration()
		{ // Graba los últimos archivos
				Program.LastFiles.Save(Application.StartupPath);
			// Graba la configuración principal
				clsConfiguration.Save();
			// Graba los parámetros de apertura de las ventanas
				Program.DockedForms.SaveConfiguration(clsConfiguration.PathBaseData, dckMain);
		}
		
		/// <summary>
		/// 	Sale de la aplicación
		/// </summary>
		private void ExitApp()
		{	// Guarda la configuración
				SaveConfiguration();
			// Cierra el administrador de blogs
				Program.BlogsManager.Dispose();
			//Close();
			//Application.Exit();
		}

		public DockPanel DockPanelMain
		{ get { return dckMain; }
		}	

		public string [] FileNames
		{ get { return arrStrFileNames; }
			set { arrStrFileNames = value; }
		}
		
		/// <summary>
		///		Manejador del evento de los menús de paneles
		/// </summary>
		private void mnuSeeWindowDock_Click(object sender, EventArgs e)
		{ ToolStripMenuItem mnuItem = (ToolStripMenuItem) sender;
		
				if (mnuItem.Tag != null && mnuItem.Tag is clsDockedForm)
					{ if (((clsDockedForm) mnuItem.Tag).Visible)
							((clsDockedForm) mnuItem.Tag).Close();
						else
							((clsDockedForm) mnuItem.Tag).Show();
					}
		}		
		
		/// <summary>
		///		Manejador del evento de los últimos archivos cargados
		/// </summary>
		private void mnuLastFiles_Click(object sender, EventArgs e)
		{ if (sender is ToolStripMenuItem)
				{ ToolStripMenuItem objMenu = (sender as ToolStripMenuItem);
				
						if (objMenu.Tag != null && objMenu.Tag is Classes.ComicFiles.clsComicFile)
							{ Classes.ComicFiles.clsComicFile objComic = objMenu.Tag as Classes.ComicFiles.clsComicFile;
								
									if (objComic != null)
										{	// Abre el archivo
												Program.DockedForms.OpenForm(objComic.FileName);
											// Añade el archivo a la colección de menús
												AddLastFile(objComic.FileName);
										}
							}
				}
		} 
		
		private void mnuFilesExit_Click(object sender, EventArgs e)
		{ Close();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{	InitForm();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{ ExitApp();
		}
		
		private void mnuSeeWindow_DropDownOpening(object sender, EventArgs e)
		{ AddMenuSeeWindows(mnuToolsSeeWindow);
		}

		private void mnuWindowsCloseAll_Click(object sender, EventArgs e)
		{ CloseAllWindows();
		}

		private void dckMain_ActiveContentChanged(object sender, EventArgs e)
		{	EnableButtons();
		}

		private void mnuFilesOpen_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void mnuFilesSave_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Save);
		}

		private void mnuFilesPrint_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Print);
		}

		private void mnuEditCopy_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Copy);
		}

		private void mnuEditCut_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Cut);
		}

		private void mnuEditPaste_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Paste);
		}

		private void mnuEditRemove_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void mnuEditProperties_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Update);
		}

		private void mnuEditRefresh_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Refresh);
		}

		private void mnuHelpAbout_Click(object sender, EventArgs e)
		{ OpenFormAbout();
		}

		private void mnuHelpIndex_Click(object sender, EventArgs e)
		{ Program.DockedForms.OpenFormAdmon(colDockedForms.FormType.Help, "1");
		}

		private void mnuToolsOptions_Click(object sender, EventArgs e)
		{ OpenFormConfiguration();
		}

		private void frmMain_DragEnter(object sender, DragEventArgs e)
		{ // Si realmente es un arvhivo
				if(e.Data.GetDataPresent(DataFormats.FileDrop, false))
					e.Effect = DragDropEffects.All;
		}

		private void frmMain_DragDrop(object sender, DragEventArgs e)
		{	string[] arrStrFiles = (string[]) e.Data.GetData(DataFormats.FileDrop);

				// Recorre los archivos abriendo los cómics
					foreach (string strFile in arrStrFiles)
						Program.DockedForms.OpenForm(strFile);
		}

		private void cmdPrintPreview_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.PrintPreview);
		}

		private void mnuFilesNewDocument_Click(object sender, EventArgs e)
		{ NewFile();
		}

		private void mnuFilesNewPage_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.NewPage);
		}

		private void mnuFilesExportHTML_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.ExportHTML);
		}

		private void mnuFilesExportEPub_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.ExportEPub);
		}

		private void mnuFilesImportOPML_Click(object sender, EventArgs e)
		{ ImportOPML();
		}

		private void cmdShowNoRead_Click(object sender, EventArgs e)
		{ clsConfiguration.ShowNoRead = cmdShowNoRead.Checked;
			ExecuteAction(clsEnums.TypeAction.ShowBlogItems);
		}

		private void cmdShowRead_Click(object sender, EventArgs e)
		{ clsConfiguration.ShowRead = cmdShowRead.Checked;
			ExecuteAction(clsEnums.TypeAction.ShowBlogItems);
		}

		private void cmdShowInteresting_Click(object sender, EventArgs e)
		{ clsConfiguration.ShowInteresting = cmdShowInteresting.Checked;
			ExecuteAction(clsEnums.TypeAction.ShowBlogItems);
		}

		private void mnuFilesNewEBook_Click(object sender, EventArgs e)
		{ NewEBook();
		}
	}
}