using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibEBook;
using Bau.Libraries.LibEBook.Formats.ePub;
using Bau.Libraries.LibEBook.Formats.ePub.Container;
using Bau.Libraries.LibEBook.Formats.ePub.OPF;
using Bau.Libraries.LibEBook.Formats.ePub.NCX;

namespace Bau.Applications.ComicsBooks.Forms.ePub
{
	/// <summary>
	///		Formulario para crear un eBook
	/// </summary>
	public partial class frmEPubCreator : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<string>
	{ // Enumerados privados
			private enum KeyNode
				{ Package,
					Item
				}
		// Variables privadas
			private int intPage = -1;
			private string strTempPath = null;
			private System.Collections.Generic.List<string> objColURLPages = new System.Collections.Generic.List<string>();
			private bool blnLoaded = false;
			
		public frmEPubCreator()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{	// Inicializa las etiquetas de la pantalla (por los posibles errores)
				lblInfo.Text = "";
			// Crea el directorio intermedio
				CreateTempPath();
			// Cambia el tag y tabs del formulario (lo hace después de cambiar el temporal porque la
			// rutina de creación obtiene el nombre del directorio cuando es un nuevo archivo)
				ToolTipText = TabText = Text = Path.GetFileName(IDData);
				Tag = colDockedForms.GetTag(colDockedForms.FormType.ePub, IDData);
			// Carga el cómic e inicializa el formulario
				try
					{ // Carga el eBook
							LoadEBook(strTempPath);
							cmdShowPages.Checked = clsConfiguration.ShowPages;
							SetLayout();
						// Cambia el foco al explorador
							wbExplorer.Select();
						// Añade el archivo a la lista de últimos archivos y muestra la última página leída
							GoPage(Program.LastFiles.GetLastPage(IDData));
						// Indica que se ha cargado correctamente
							blnLoaded = true;
					}
				catch (Exception objException)
					{	Helper.ShowMessage(this, "Error al cargar el archivo\n" + objException.Message);
					}
		}
		
		/// <summary>
		///		Crea el directorio temporal
		/// </summary>
		private void CreateTempPath()
		{ // Si lo que se le pasa no es un nombre de directorio
				if (!string.IsNullOrEmpty(IDData))
					{ // Obtiene el nombre del directorio temporal
							strTempPath = Bau.Libraries.LibHelper.Files.HelperFiles.GetConsecutivePath(Program.GetTempPath(), 
																																												 Path.GetFileNameWithoutExtension(IDData));
						// Crea el directorio temporal
							Bau.Libraries.LibHelper.Files.HelperFiles.MakePath(strTempPath);
					}
		}
		
		/// <summary>
		///		Carga el eBook
		/// </summary>
		private void LoadEBook(string strPath)
		{ ePubEBook objBook;
		
				// Cambia el cursor
					Cursor.Current = Cursors.WaitCursor;
				// Carga el libro
					objBook = new BookFactory().Load(IDData, strPath);
				// Carga las páginas
					objColURLPages = LoadPages(objBook);
				// Limpia el árbol e inicializa las propiedades
					trvPages.Nodes.Clear();											
					trvPages.ImageList = clsListImagesUI.Images;																						
				// Muestra las páginas en el árbol
					foreach (RootFile objRootFile in objBook.Container.RootFiles)
						foreach (OPFPackage objPackage in objRootFile.Packages)
							{ TreeNode trnNode = AddNode(null, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package, 
																					 objPackage.Metadata.Title, null, Color.Red, true);
								TreeNode trnNodeSpine = AddNode(trnNode, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package,
																								"Páginas", null, Color.Red, true);
								int intPage = 1;
																							
										// Añade las páginas
											foreach (ItemRef objItemRef in objPackage.Spine)
												{ Item objItem = objPackage.Manifest.Search(objItemRef.IDRef);
												
														if (objItem != null)
															{ // Añade el nodo con la página
																	AddNode(trnNodeSpine, clsListImagesUI.ImagesIndex.Document,
																					KeyNode.Item, "Capítulo " + intPage,
																					GetPageFileName(objRootFile, objItem.URL), Color.Black, false);
																// Incrementa el número de página
																	intPage++;
															}
												}
										// Añade los elementos de la tabla de contenidos
											AddNodesToc(trnNode, objRootFile, objPackage);
							}
				// Expande los nodos
					trvPages.ExpandAll();
				// Carga el combo de páginas
					cboPages.Items.Clear();
					for (int intIndex = 0; intIndex < objColURLPages.Count; intIndex++)
					  cboPages.Items.Add((intIndex + 1).ToString());
				// Cambia el cursor
					Cursor.Current = Cursors.Default;
		}

		/// <summary>
		///		Añade los nodos de la tabla de contenidos
		/// </summary>
		private void AddNodesToc(TreeNode trnParent, RootFile objRootFile, OPFPackage objPackage)
		{ if (objPackage.TablesOfContents.Count > 0 && objPackage.TablesOfContents.ExistsNavPoints())
				{	TreeNode trnNodeTOC = AddNode(trnParent, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package,
																				"Tabla de contenido", null, Color.Red, true);

						// Añade los elementos de la tabla de contenidos
							foreach (NCXFile objNCX in objPackage.TablesOfContents)
								{ TreeNode trnNCX = AddNode(trnNodeTOC, clsListImagesUI.ImagesIndex.Folder, 
																						KeyNode.Package, objNCX.Title, objNCX.ID,
																						Color.Navy, true);
								
										AddNavPoints(trnNCX, objRootFile, objNCX.Pages);
								}
				}
		}

		/// <summary>
		///		Carga las URLs de las páginas en una colección de cadenas
		/// </summary>
		private System.Collections.Generic.List<string> LoadPages(ePubEBook objBook)
		{ System.Collections.Generic.List<string> objColURLs = new System.Collections.Generic.List<string>();
		
				// Carga las páginas
					foreach (RootFile objRootFile in objBook.Container.RootFiles)
						foreach (OPFPackage objPackage in objRootFile.Packages)
							foreach(ItemRef objItemRef in objPackage.Spine)
								{ Item objItem = objPackage.Manifest.Search(objItemRef.IDRef);
								
										if (objItem != null)
											objColURLs.Add(GetPageFileName(objRootFile, objItem.URL));
								}
				// Devuelve la colección de URLs
					return objColURLs;
		}

		/// <summary>
		///		Obtiene el nombre de archivo de un navPoint
		/// </summary>
		private string GetPageFileName(RootFile objRootFile, string strURL)
		{ return Path.Combine(strTempPath, 
													Path.Combine(Path.GetDirectoryName(objRootFile.URL), strURL));
		}
		
		/// <summary>
		///		Añade un nodo al árbol
		/// </summary>
		private TreeNode AddNode(TreeNode trnParent, clsListImagesUI.ImagesIndex intImage, 
														 KeyNode intType, string strTitle, string strTag, Color clrColor, bool blnBold)
		{ return trvPages.AddNode(trnParent, new Bau.Controls.Tree.TreeNodeKey((int) intType, null, strTag),
															strTitle, false, (int) intImage, clrColor, blnBold);
		}
		
		/// <summary>
		///		Añade las páginas al árbol
		/// </summary>
		private void AddNavPoints(TreeNode trnParent, RootFile objRootFile, NavPointsCollection objColNavPoints)
		{ foreach (NavPoint objNavPoint in objColNavPoints)
				{ TreeNode trnNode = AddNode(trnParent, clsListImagesUI.ImagesIndex.Document, 
																		 KeyNode.Item, objNavPoint.Title,
																		 GetPageFileName(objRootFile, objNavPoint.URL), Color.Black, false);
																							
						if (objNavPoint.Pages.Count > 0)
							AddNavPoints(trnNode, objRootFile, objNavPoint.Pages);
				}
		}

		/// <summary>
		///		Muestra una página en el explorador
		/// </summary>
		private void ShowPage(Bau.Controls.Tree.TreeNodeKey objKey)
		{ if (objKey.IDType == (int) KeyNode.Item && objKey.Tag != null && objKey.Tag is string)
				{ int intPage = SearchPage(objKey.Tag as string);
				
						if (intPage > 0)
							GoPage(intPage);
				}
		}

		/// <summary>
		///		Busca una página
		/// </summary>
		private int SearchPage(string strURL)
		{ // Busca la página en la colección
				for (int intIndex = 0; intIndex < objColURLPages.Count; intIndex++)
					if (objColURLPages[intIndex].Equals(strURL, StringComparison.CurrentCultureIgnoreCase))
						return intIndex;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return -1;
		} 
		
		/// <summary>
		///		Muestra una página
		/// </summary>
		private void GoPage(int intNewPage)
		{	// Pasa a la página indicada
		    if (intNewPage != intPage && intNewPage >= 0 && intNewPage < objColURLPages.Count)
		      { // Cambia la página actual
		          intPage = intNewPage;
		        // Carga la imagen
							ShowPage(objColURLPages[intPage]);
		        // Guarda la última página leída
		          Program.LastFiles.SetLastPage(IDData, intPage);
		      }
		  // Habilita / inhabilita los controles
		    EnableControls(intPage);
		}
		
		/// <summary>
		///		Muestra una página en el explorador
		/// </summary>
		private void ShowPage(string strFileName)
		{ int intIndex = strFileName.IndexOf("#");
			string strAnchor = "";
			
				// Quita el anchor
					if (intIndex > 0)
						{ strAnchor = strFileName.Substring(intIndex + 1);
							strFileName = strFileName.Substring(0, intIndex);
						}
				// Abre el archivo
					if (strFileName.EndsWith(".htm", StringComparison.CurrentCultureIgnoreCase) ||
							strFileName.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase) ||
							strFileName.EndsWith(".xhtml", StringComparison.CurrentCultureIgnoreCase))
						wbExplorer.Navigate(strFileName);
					else if (strFileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
									 strFileName.EndsWith(".bmp", StringComparison.CurrentCultureIgnoreCase) ||
									 strFileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
						wbExplorer.Navigate(strFileName);
					else
						wbExplorer.LoadHTML(Bau.Libraries.LibHelper.Files.HelperFiles.LoadTextFile(strFileName));
		}
			
		/// <summary>
		///		Habilita / inhabilita los controles
		/// </summary>
		private void EnableControls(int intPage)
		{	cmdGoFirstPage.Enabled = cmdGoPreviousPage.Enabled = intPage > 0;
			cmdGoLastPage.Enabled = cmdGoNextPage.Enabled = intPage < objColURLPages.Count - 1;
			cboPages.SelectedIndex = intPage;
			lblInfo.Text = " de " + objColURLPages.Count.ToString();
		}
		
		/// <summary>
		///		Cambia el aspecto del formulario
		/// </summary>
		private void SetLayout()
		{ bool blnColapsed = splMain.Panel1Collapsed;
		
				// Muestra / oculta el control de página
					splMain.Panel1Collapsed = !cmdShowPages.Checked;
					if (blnColapsed && !splMain.Panel1Collapsed)
						if (clsConfiguration.WidthSplitter != 0)
							splMain.SplitterDistance = clsConfiguration.WidthSplitter;
						else
							splMain.SplitterDistance = 238;
				// Guarda los datos de configuración
					clsConfiguration.ShowPages = cmdShowPages.Checked;
		}
	
		/// <summary>
		///		Imprime el cómic
		/// </summary>
		private void Print(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Print:
							wbExplorer.ShowPrintDialog();
						break;
					case clsEnums.TypeAction.PrintWithDialog:
							wbExplorer.ShowPageSetupDialog();
						break;
					case clsEnums.TypeAction.PrintPreview:
							wbExplorer.ShowPrintPreviewDialog();
						break;
				}
		}

		/// <summary>
		///		Abre el formulario de información
		/// </summary>
		private void OpenFormInfo()
		{ 
			//frmComicInfo frmNewComic = new frmComicInfo();
		
			//  // Asigna las propiedades
			//    frmNewComic.FileName = objComicBook.FileName;
			//    frmNewComic.Info = objComicBook.Info;
			//  // Muestra el formulario
			//    frmNewComic.ShowDialog();
			//  // Indica si se ha modificado y en su caso añade el cómic a la biblioteca
			//    if (frmNewComic.DialogResult == DialogResult.OK)
			//      { // Añade el cómic a la biblioteca
			//          Program.ComicsLibrary.AddComicInfo(objComicBook.Info);
			//        // Indica que no se ha modificado
			//          blnUpdated = true;
			//      }
		}
		
		/// <summary>
		///		Ejecuta una acción desde el menú principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
							Print(intAction);
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
						return true;
					default:
						return false;
				}
		}

		/// <summary>
		///		Rutina de tratamiento del evento Changed de los controles
		/// </summary>
		public void Changed(object sender, EventArgs e)
		{ // ... no hace nada, se crea para soportar el interface
		}

		/// <summary>
		///		Nombre del archivo ePub
		/// </summary>
		public string IDData { get; set; }

		private void frmEPub_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void frmEPub_Shown(object sender, EventArgs e)
		{ if (!blnLoaded)
				Close();
		}

		private void cmdGoPreviousPage_Click(object sender, EventArgs e)
		{ GoPage(intPage - 1);
		}

		private void cmdGoNextPage_Click(object sender, EventArgs e)
		{ GoPage(intPage + 1);
		}

		private void cmdGoFirstPage_Click(object sender, EventArgs e)
		{ GoPage(0);
		}

		private void cmdGoLastPage_Click(object sender, EventArgs e)
		{ GoPage(cboPages.Items.Count - 1);
		}

		private void cboPages_SelectedIndexChanged(object sender, EventArgs e)
		{ GoPage(cboPages.SelectedIndex);
		}

		private void cmdShowPages_Click(object sender, EventArgs e)
		{	// Cambia el checked
				((ToolStripButton) sender).Checked = !((ToolStripButton) sender).Checked;
			// Cambia el aspecto del formulario
				SetLayout();
		}

		private void cmdInfo_Click(object sender, EventArgs e)
		{ OpenFormInfo();
		}

		private void splMain_SplitterMoved(object sender, SplitterEventArgs e)
		{ clsConfiguration.WidthSplitter = splMain.SplitterDistance;
		}

		private void trvPages_AfterSelect(object sender, TreeViewEventArgs e)
		{ if (e.Node != null && e.Node.Tag != null)
				{ Bau.Controls.Tree.TreeNodeKey objKey = trvPages.GetKey(e.Node);
				
						if (objKey != null)
							ShowPage(objKey);
				}
		}
	}
}