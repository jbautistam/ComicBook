using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Classes.ComicWeb;

namespace Bau.Applications.ComicsBooks.Forms.Explorer
{
	/// <summary>
	///		Formulario con los maracadores
	/// </summary>
	public partial class frmComicsWeb : WeifenLuo.WinFormsUI.Docking.DockContent, IPluginDocument
	{ // Enumerados privados
			private	enum KeyTree
				{ WebComic,
					File
				}
				
		public frmComicsWeb()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ LoadTree();
		}
		
		/// <summary>
		///		Actualiza el formulario (se llama desde el programa principal)
		/// </summary>
		public void RefreshForm()
		{ LoadTree();
		}

		/// <summary>
		///		Carga el árbol
		/// </summary>
		private void LoadTree()
		{ // Carga la colección de cómics
				Program.ComicsWeb.Load(clsConfiguration.FileComicsWeb);
			// Guarda los nodos abiertos y limpia el árbol
				trvComics.SaveOpenNodes();
				trvComics.Nodes.Clear();
			// Añade la lista de imágenes
				trvComics.ImageList = Classes.clsListImagesUI.Images;
			// Carga los nodos
				foreach (clsComicWeb objComic in Program.ComicsWeb)
					trvComics.AddNode(null, new Bau.Controls.Tree.TreeNodeKey((int) KeyTree.WebComic, 1, objComic),
														objComic.Name, false, (int) clsListImagesUI.ImagesIndex.Document);			
			// Recupera los nodos abiertos
				trvComics.RestoreOpenNodes();
		}
		
		/// <summary>
		///		Obtiene el cómic seleccionado
		/// </summary>
		private clsComicWeb GetSelectedComic()
		{ Bau.Controls.Tree.TreeNodeKey objNodeKey = trvComics.GetKey(trvComics.SelectedNode);
		
				// Obtiene el nombre del cómic
					if (objNodeKey != null && objNodeKey.IDType == (int) KeyTree.WebComic && objNodeKey.Tag != null &&
							objNodeKey.Tag is clsComicWeb)
						return objNodeKey.Tag as clsComicWeb;
				// Devuelve el cómic
					return null;
		}
		
		/// <summary>
		///		Abre el cómic del nodo seleccionado
		/// </summary>
		private void OpenSelectedNode()
		{ clsComicWeb objComic = GetSelectedComic();
		
				if (objComic != null)
					Program.DockedForms.OpenFormAdmon(colDockedForms.FormType.ComicWeb, objComic.ID);
		}
		
		/// <summary>
		///		Comprueba si puede mostrar el menú
		/// </summary>
		private bool ShowMenu()
		{ return GetSelectedComic() != null;
		}
			
		/// <summary>
		///		Ejecuta una acción del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	switch (intAction)
				{ case clsEnums.TypeAction.Open:
							OpenSelectedNode();
						break;
					case clsEnums.TypeAction.Remove:
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Open:
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

		private void ctxMnuExplorer_Opening(object sender, CancelEventArgs e)
		{ e.Cancel = !ShowMenu();
		}

		private void mnuExplorerOpen_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void trvBookmarks_NodeDoubleClick(object objSender, Bau.Controls.Tree.TreeViewExtendedEventArgs evnArgs)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void mnuExplorerDelete_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}
	}
}