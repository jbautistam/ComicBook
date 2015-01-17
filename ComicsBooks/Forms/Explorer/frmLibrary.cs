using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;

namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	/// <summary>
	///		Formulario con los maracadores
	/// </summary>
	public partial class frmLibrary : WeifenLuo.WinFormsUI.Docking.DockContent, IPluginDocument
	{ // Enumerados privados
			private	enum KeyTree
				{ Category,
					File
				}
				
		public frmLibrary()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // A�ade la rutina de manejo de eventos de modificaci�n de la biblioteca
				Program.ComicsLibrary.Updated += new EventHandler(ComicsLibrary_Updated);
			// Carga el �rbol
				LoadTree();
		}
		
		/// <summary>
		///		Actualiza el formulario (se llama desde el programa principal)
		/// </summary>
		public void RefreshForm()
		{ LoadTree();
		}

		/// <summary>
		///		Carga el �rbol
		/// </summary>
		private void LoadTree()
		{ // Carga la librer�a
				Program.ComicsLibrary.Load();
			// Guarda los nodos abiertos y limpia el �rbol
				trvBookmarks.SaveOpenNodes();
				trvBookmarks.Nodes.Clear();
			// A�ade la lista de im�genes
				trvBookmarks.ImageList = Classes.clsListImagesUI.Images;
			// Dependiendo de la ordenaci�n
				if (mnuSortByCategory.Checked)
					LoadNodes("Category", "Sin categor�as");
				else
					LoadNodes("Author", "Sin autor");
			// Recupera los nodos abiertos
				trvBookmarks.RestoreOpenNodes();
		}
		
		/// <summary>
		///		Carga los nodos del �rbol dependiendo del tipo de ordenaci�n
		/// </summary>
		private void LoadNodes(string strParameterName, string strTitleUndefined)
		{ Bau.Libraries.LibCollector.Collector.ParameterValuesCollection objColParameterValues;
		
				// Obtiene la colecci�n de valores a presentar en el �rbol
					objColParameterValues = Program.ComicsLibrary.GetParameterValues(strParameterName);
				// Muestra la coleccci�n de categor�as en el �rbol
					foreach (Bau.Libraries.LibCollector.Collector.ParameterValue objParameterValue in objColParameterValues)
						AddCategory(strParameterName, objParameterValue.ID, objParameterValue.Value);
				// A�ade un nodo para los c�mics sin categor�a
					AddCategory(strParameterName, null, strTitleUndefined);
		}
		
		/// <summary>
		///		A�ade una categor�a y todos los c�mics asociados con esa categor�a
		/// </summary>
		private void AddCategory(string strParameterName, string strIDParameterValue, string strParameterValue)
		{ Libraries.LibCollector.Collector.LibraryItemsCollection objColComics;
			TreeNode trnNode;
			
				// A�ade el nodo con la categor�a
					trnNode = trvBookmarks.AddNode(null, (int) KeyTree.Category, 1, strParameterValue, false, 
																				 (int) clsListImagesUI.ImagesIndex.Folder, Color.Red);
				// Carga los c�mics correspondientes a esa categor�a
					objColComics = Program.ComicsLibrary.SearchByParameter(strParameterName, strIDParameterValue);
				// A�ade los c�mics que tienen esa categor�a
					foreach (Bau.Libraries.LibCollector.Collector.LibraryItem objComic in objColComics)
						{ Bau.Controls.Tree.TreeNodeKey objNodeKey = new Bau.Controls.Tree.TreeNodeKey((int) KeyTree.File, 1);
						
								// A�ade al tag de la clave el nombre de archivo
									objNodeKey.Tag = objComic.FileName;
								// A�ade el nodo
									trvBookmarks.AddNode(trnNode, objNodeKey, System.IO.Path.GetFileName(objComic.FileName), false,
																			 (int) clsListImagesUI.ImagesIndex.Document); 
						}
		}

		/// <summary>
		///		Abre el c�mic seleccionado en el �rbol
		/// </summary>
		private void OpenSelectedComic()
		{ string strComic = GetSelectedComic();
		
				if (!string.IsNullOrEmpty(strComic))
					Program.DockedForms.OpenFormAdmon(colDockedForms.FormType.Comic, strComic);
		}

		/// <summary>
		///		Abre el formulario con la informaci�n del c�mic
		/// </summary>
		private void OpenSelectedInfo()
		{ string strComic = GetSelectedComic();
		
				if (!string.IsNullOrEmpty(strComic))
					{ Libraries.LibCollector.Collector.LibraryItem objComicParameters = Program.ComicsLibrary.Comics[strComic];
					
							if (objComicParameters == null)
								Bau.Controls.Forms.Helper.ShowMessage(this, "No se puede encontrar la informaci�n del c�mic");
							else
								{ Libraries.LibComicsBooks.Definition.ComicInfo objComicInfo = new Libraries.LibComicsBooks.Definition.ComicInfo();
								
										// Pasa los datos de los par�metros a la informaci�n del c�mic
											objComicInfo.ComicFileName = strComic;
											objComicInfo.Title = Program.ComicsLibrary.SearchValue(objComicParameters, "Title");
											objComicInfo.Summary = Program.ComicsLibrary.SearchValue(objComicParameters, "Summary");
											objComicInfo.Notes = Program.ComicsLibrary.SearchValue(objComicParameters, "Notes");
											objComicInfo.Serie = Program.ComicsLibrary.SearchValue(objComicParameters, "Serie");
											objComicInfo.Number = Program.ComicsLibrary.SearchValue(objComicParameters, "Number");
											objComicInfo.NumberTotal = Program.ComicsLibrary.SearchValue(objComicParameters, "NumberTotal");
											objComicInfo.DatePublish = Program.ComicsLibrary.SearchValue(objComicParameters, "DatePublish");
											objComicInfo.Genre = Program.ComicsLibrary.SearchValue(objComicParameters, "Genre");
											objComicInfo.Author = Program.ComicsLibrary.SearchValue(objComicParameters, "Author");
											objComicInfo.Editorial = Program.ComicsLibrary.SearchValue(objComicParameters, "Editorial");
											objComicInfo.Drawer = Program.ComicsLibrary.SearchValue(objComicParameters, "Drawer");
											objComicInfo.Editor = Program.ComicsLibrary.SearchValue(objComicParameters, "Editor");
											objComicInfo.Categories = Program.ComicsLibrary.SearchValue(objComicParameters, "Category");
										// Abre el formulario de par�metros del c�mic
											OpenFormComicInfo(objComicInfo);
								}
					}
		}
		
		/// <summary>
		///		Abre el formulario con la informaci�n del c�mic
		/// </summary>
		private void OpenFormComicInfo(Libraries.LibComicsBooks.Definition.ComicInfo objComicInfo)
		{ Comic.frmComicInfo frmNewComicInfo = new Comic.frmComicInfo();
		
				// Asigna las propiedades
					frmNewComicInfo.Info = objComicInfo;
				// Abre el formulario
					frmNewComicInfo.ShowDialog();
		}
		
		/// <summary>
		///		Elimina el c�mic seleccionado en el �rbol
		/// </summary>
		private void RemoveSelectedComic()
		{ string strComic = GetSelectedComic();
		
				if (!string.IsNullOrEmpty(strComic))
					{ // Elimina el archivo
							if (System.IO.File.Exists(strComic) &&
									Bau.Controls.Forms.Helper.ShowQuestion(this, "�Desea eliminar tambi�n el archivo?"))
								Bau.Libraries.LibHelper.Files.HelperFiles.KillFile(strComic);
						// Elimina el c�mic de la biblioteca
							Program.ComicsLibrary.Remove(strComic);
						// Recarga el �rbol
							LoadTree();
					}
		}
		
		/// <summary>
		///		Obtiene el c�mic seleccionado
		/// </summary>
		private string GetSelectedComic()
		{ string strComic = null;
			Bau.Controls.Tree.TreeNodeKey objNodeKey = trvBookmarks.GetKey(trvBookmarks.SelectedNode);
		
				// Obtiene el nombre del c�mic
					if (objNodeKey != null && objNodeKey.IDType == (int) KeyTree.File && objNodeKey.Tag != null)
						strComic = objNodeKey.Tag.ToString();
				// Devuelve el nombre del c�mic
					return strComic;
		}
		
		/// <summary>
		///		Comprueba si puede mostrar el men�
		/// </summary>
		private bool ShowMenu()
		{ return !string.IsNullOrEmpty(GetSelectedComic());
		}
				
		/// <summary>
		///		Ejecuta una acci�n del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	switch (intAction)
				{ case clsEnums.TypeAction.Open:
							OpenSelectedComic();
						break;
					case clsEnums.TypeAction.Update:
							OpenSelectedInfo();
						break;
					case clsEnums.TypeAction.Remove:
							RemoveSelectedComic();
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acci�n
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Open:
					// case clsEnums.TypeAction.Update:
					case clsEnums.TypeAction.Remove:
					case clsEnums.TypeAction.Refresh:
						return true;
					default:
						return false;
				}
		}
		
		private void frmLibrary_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void ComicsLibrary_Updated(object sender, EventArgs e)
		{ RefreshForm();
		}

		private void ctxMnuExplorer_Opening(object sender, CancelEventArgs e)
		{ e.Cancel = !ShowMenu();
		}

		private void mnuExplorerOpen_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void trvBookmarks_NodeDoubleClick(object objSender, Bau.Controls.Tree.TreeViewExtendedEventArgs evnArgs)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void mnuExplorerShowInfo_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Update);
		}

		private void mnuExplorerDelete_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void mnuSortByCategory_Click(object sender, EventArgs e)
		{ // Selecciona la forma de ordenaci�n
				mnuSortByAuthor.Checked = false;
				mnuSortByCategory.Checked = true;
			// Recarga
				LoadTree();
		}

		private void mnuSortByAuthor_Click(object sender, EventArgs e)
		{ // Selecciona la forma de ordenaci�n
				mnuSortByAuthor.Checked = true;
				mnuSortByCategory.Checked = false;
			// Recarga
				LoadTree();
		}
	}
}