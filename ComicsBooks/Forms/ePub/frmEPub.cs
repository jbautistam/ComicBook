using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibEBook;
using Bau.Libraries.LibEBook.Formats.eBook;

namespace Bau.Applications.ComicsBooks.Forms.ePub
{
	/// <summary>
	///		Formulario para mostrar un eBook
	/// </summary>
	public partial class frmEPub : WeifenLuo.WinFormsUI.Docking.DockContent, IFormAdmon<string>
	{ // Enumerados privados
			private enum KeyNode
				{ Package,
					Item
				}
		// Variables privadas
			private int intPage = -1;
			private string strTempPath = null;
			private Book objBook;
			private System.Collections.Generic.List<string> objColURLPages = new System.Collections.Generic.List<string>();
			private bool blnLoaded = false;
			
		public frmEPub()
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
			// Cambia el tag y tabs del formulario (lo hace despu�s de cambiar el temporal porque la
			// rutina de creaci�n obtiene el nombre del directorio cuando es un nuevo archivo)
				ToolTipText = TabText = Text = Path.GetFileName(IDData);
				Tag = colDockedForms.GetTag(colDockedForms.FormType.ePub, IDData);
			// Carga el c�mic e inicializa el formulario
				try
					{ // Carga el eBook
							LoadEBook(strTempPath);
							cmdShowPages.Checked = clsConfiguration.ShowPages;
							SetLayout();
						// Cambia el foco al explorador
							wbExplorer.Select();
						// A�ade el archivo a la lista de �ltimos archivos y muestra la �ltima p�gina le�da
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
		{ TreeNode trnNode, trnNodeSpine;
		
				// Cambia el cursor
					Cursor.Current = Cursors.WaitCursor;
				// Carga el libro
					objBook = new BookFactory().Load(BookFactory.BookType.ePub, IDData, strPath);
				// Carga las p�ginas
					objColURLPages = LoadPages(objBook);
				// Limpia el �rbol e inicializa las propiedades
					trvPages.Nodes.Clear();											
					trvPages.ImageList = clsListImagesUI.Images;																						
				// A�ade el nodo ra�z
					trnNode = AddNode(null, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package, objBook.Title, null, Color.Red, true);
				// A�ade las p�ginas de los �ndices
					trnNodeSpine = AddNode(trnNode, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package, "P�ginas", null, Color.Red, true);
					AddNodesToc(trnNodeSpine, objBook.Index);
				// A�ade las p�ginas de las tablas de contenido
					trnNodeSpine = AddNode(trnNode, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package, "Tablas de contenido",
																 null, Color.Red, true);
					AddNodesToc(trnNodeSpine, objBook.TableOfContent);
				// Expande los nodos
					trvPages.ExpandAll();
				// Carga el combo de p�ginas
					cboPages.Items.Clear();
					for (int intIndex = 0; intIndex < objColURLPages.Count; intIndex++)
						cboPages.Items.Add((intIndex + 1).ToString());
				// Cambia el cursor
					Cursor.Current = Cursors.Default;
		}

		/// <summary>
		///		A�ade los nodos de la tabla de contenidos
		/// </summary>
		private void AddNodesToc(TreeNode trnParent, IndexItemsCollection objColItems)
		{ foreach (IndexItem objItem in objColItems)
				{ TreeNode trnNode;
				
						// A�ade los datos del nodo
							if (string.IsNullOrEmpty(objItem.URL))
								trnNode = AddNode(trnParent, clsListImagesUI.ImagesIndex.Folder, KeyNode.Package,
																	objItem.Name, objItem.Name, Color.Blue, true);
							else
								trnNode = AddNode(trnParent, clsListImagesUI.ImagesIndex.Document, KeyNode.Item,
																	objItem.Name, GetFileName(objItem.URL), Color.Blue, false);
						// A�ade los nodos hijo
							AddNodesToc(trnNode, objItem.Items);
				}
		}
		
		/// <summary>
		///		A�ade un nodo al �rbol
		/// </summary>
		private TreeNode AddNode(TreeNode trnParent, clsListImagesUI.ImagesIndex intImage, 
														 KeyNode intType, string strTitle, string strTag, Color clrColor, bool blnBold)
		{ return trvPages.AddNode(trnParent, new Bau.Controls.Tree.TreeNodeKey((int) intType, null, strTag),
															strTitle, false, (int) intImage, clrColor, blnBold);
		}

		/// <summary>
		///		Carga las URLs de las p�ginas en una colecci�n de cadenas
		/// </summary>
		private System.Collections.Generic.List<string> LoadPages(Book objBook)
		{ System.Collections.Generic.List<string> objColURLs = new System.Collections.Generic.List<string>();
		
				// Carga las p�ginas
					foreach (IndexItem objIndex in objBook.Index)
						objColURLs.Add(GetFileName(objIndex.URL));
				// Devuelve la colecci�n de URLs
					return objColURLs;
		}

		/// <summary>
		///		Obtiene el nombre de fichero combinado con el directorio donde se encuentran las p�ginas
		/// </summary>
		private string GetFileName(string strURL)
		{ return Path.Combine(strTempPath, strURL);
		}
		
		/// <summary>
		///		Muestra una p�gina en el explorador
		/// </summary>
		private void ShowPage(Bau.Controls.Tree.TreeNodeKey objKey)
		{ if (objKey.IDType == (int) KeyNode.Item && objKey.Tag != null && objKey.Tag is string)
				{ int intPage = SearchPage(objKey.Tag as string);
				
						if (intPage >= 0)
							GoPage(intPage);
				}
		}

		/// <summary>
		///		Busca una p�gina
		/// </summary>
		private int SearchPage(string strURL)
		{ // Busca la p�gina en la colecci�n
				for (int intIndex = 0; intIndex < objColURLPages.Count; intIndex++)
					if (!string.IsNullOrEmpty(objColURLPages[intIndex]) &&
							objColURLPages[intIndex].Equals(strURL, StringComparison.CurrentCultureIgnoreCase))
						return intIndex;
			// Si ha llegado hasta aqu� es porque no ha encontrado nada
				return -1;
		} 
		
		/// <summary>
		///		Muestra una p�gina
		/// </summary>
		private void GoPage(int intNewPage)
		{	// Pasa a la p�gina indicada
		    if (intNewPage != intPage && intNewPage >= 0 && intNewPage < objColURLPages.Count)
		      { // Cambia la p�gina actual
		          intPage = intNewPage;
		        // Carga la imagen
							if (!string.IsNullOrEmpty(objColURLPages[intPage]))
								ShowPage(objColURLPages[intPage]);
		        // Guarda la �ltima p�gina le�da
		          Program.LastFiles.SetLastPage(IDData, intPage);
		      }
		  // Habilita / inhabilita los controles
		    EnableControls(intPage);
		}
		
		/// <summary>
		///		Muestra una p�gina en el explorador
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
							strFileName.EndsWith(".html", StringComparison.CurrentCultureIgnoreCase)) // ||
							// strFileName.EndsWith(".xhtml", StringComparison.CurrentCultureIgnoreCase))
						wbExplorer.Navigate(strFileName);
					else if (strFileName.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) ||
									 strFileName.EndsWith(".bmp", StringComparison.CurrentCultureIgnoreCase) ||
									 strFileName.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
						wbExplorer.Navigate(strFileName);
					else
						wbExplorer.LoadHTML(Libraries.LibHelper.Files.HelperFiles.LoadTextFile(strFileName));
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
		
				// Muestra / oculta el control de p�gina
					splMain.Panel1Collapsed = !cmdShowPages.Checked;
					if (blnColapsed && !splMain.Panel1Collapsed)
						if (clsConfiguration.WidthSplitter != 0)
							splMain.SplitterDistance = clsConfiguration.WidthSplitter;
						else
							splMain.SplitterDistance = 238;
				// Guarda los datos de configuraci�n
					clsConfiguration.ShowPages = cmdShowPages.Checked;
		}
	
		/// <summary>
		///		Imprime el c�mic
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
		///		Graba el archivo ePub
		/// </summary>
		private	void Save()
		{ string strFileName = Helper.GetFileNameSave("eBooks (*.ePub)|*.ePub|Todos los archivos (*.*)|*.*");
		
				if (!string.IsNullOrEmpty(strFileName))
					try
						{ // Cambia las URLs de las p�ginas
								foreach (PageFile objPage in objBook.Files)
									objPage.FileName = GetAbsoluteURL(objPage.FileName);
							// Cambia las URLs del �ndice								
								SetURLIndex(objBook.Index);
								SetURLIndex(objBook.TableOfContent);
							// Graba el libro como ePub
								new BookFactory().Save(BookFactory.BookType.ePub, objBook, strFileName);
							// Mensaje
								Helper.ShowMessage(this, "Se ha finalizado la grabaci�n del archivo");
						}
					catch (Exception objException)
						{ Helper.ShowMessage(this, "Error en la grabaci�n del eBook\n" + objException.Message);
						}
		}

		/// <summary>
		///		Cambia las URLs del �ndice
		/// </summary>
		private void SetURLIndex(IndexItemsCollection objColIndex)
		{ foreach (IndexItem objIndex in objColIndex)
				{ // Cambia la URL
						if (!string.IsNullOrEmpty(objIndex.URL))
							objIndex.URL = GetAbsoluteURL(objIndex.URL);
					// Cambia la URL de los hijos
						SetURLIndex(objIndex.Items);
				}
		}
		
		/// <summary>
		///		Obtiene la URL absoluta de una p�gina
		/// </summary>
		private string GetAbsoluteURL(string strURL)
		{ if (strURL.StartsWith(strTempPath, StringComparison.CurrentCultureIgnoreCase))
				return strURL;
			else
				return Path.Combine(strTempPath, strURL);
		}
		
		/// <summary>
		///		Abre el formulario de informaci�n
		/// </summary>
		private void OpenFormInfo()
		{ 
			//frmComicInfo frmNewComic = new frmComicInfo();
		
			//  // Asigna las propiedades
			//    frmNewComic.FileName = objComicBook.FileName;
			//    frmNewComic.Info = objComicBook.Info;
			//  // Muestra el formulario
			//    frmNewComic.ShowDialog();
			//  // Indica si se ha modificado y en su caso a�ade el c�mic a la biblioteca
			//    if (frmNewComic.DialogResult == DialogResult.OK)
			//      { // A�ade el c�mic a la biblioteca
			//          Program.ComicsLibrary.AddComicInfo(objComicBook.Info);
			//        // Indica que no se ha modificado
			//          blnUpdated = true;
			//      }
		}
		
		/// <summary>
		///		Ejecuta una acci�n desde el men� principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Save:
							Save();
						break;
					case clsEnums.TypeAction.Print:
					case clsEnums.TypeAction.PrintPreview:
					case clsEnums.TypeAction.PrintWithDialog:
							Print(intAction);
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acci�n
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Save:
					case clsEnums.TypeAction.Print:
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