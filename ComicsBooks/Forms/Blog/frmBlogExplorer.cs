using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.Forms;
using Bau.Applications.ComicsBooks.Classes;
using Bau.Applications.ComicsBooks.Forms.Blog.Classes;
using Bau.Libraries.LibHelper.Files;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;

namespace Bau.Applications.ComicsBooks.Forms.Blog
{
	/// <summary>
	///		Formulario con el explorador de archivos
	/// </summary>
	public partial class frmBlogExplorer : WeifenLuo.WinFormsUI.Docking.DockContent, IPluginDocument
	{ 			
		/// <summary>
		///		Ventana que muestra el árbol con el explorador
		/// </summary>
		public frmBlogExplorer()
		{	InitializeComponent();
		}

		/// <summary>
		///		Inicializa el formulario
		/// </summary>
		private void InitForm()
		{ // Crea el directorio de blogs
				Libraries.LibHelper.Files.HelperFiles.MakePath(clsConfiguration.PathBaseBlogs);
			// Asigna el manejador de eventos del archivo OPML
				Program.BlogsManager.UpdatedEntry += new OPMLManager.UpdatedEntryHandler(BlogsManager_UpdatedEntry);
				Program.BlogsManager.UpdatedChannel += new EventHandler(BlogsManager_UpdatedChannel);
			// Inicializa el árbol de archivos
				udtExplorer.LoadBlogs(clsConfiguration.OPMLFileName);
			// Carga el árbol
				RefreshForm();
		}
		
		/// <summary>
		///		Actualiza el formulario (se llama desde el programa principal)
		/// </summary>
		public void RefreshForm()
		{ udtExplorer.Refresh();
		}

		/// <summary>
		///		Comprueba si puede mostrar el menú
		/// </summary>
		private bool ShowMenu()
		{	bool blnVisibleTop = false, blnVisibleMedium = false, blnVisibleBottom = false;
		
				// Oculta los menús de la parte superior
					blnVisibleTop |= mnuExplorerNewFolder.Visible = udtExplorer.SelectedType != UC.ctlTreeBlogs.FileType.Blog;
					blnVisibleTop |= mnuExplorerNewFile.Visible = udtExplorer.SelectedType != UC.ctlTreeBlogs.FileType.Blog;
					blnVisibleTop |= mnuExplorerProperties.Visible = udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog;
					blnVisibleTop |= mnuExplorerOpen.Visible = udtExplorer.SelectedBlog != null;
					blnVisibleTop |= mnuExplorerRename.Visible = udtExplorer.SelectedBlog != null;
				// Oculta los menús intermedios
					blnVisibleMedium |= mnuExplorerDownload.Visible = udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog;
				// Oculta los menús de la parte inferior
					blnVisibleBottom |= mnuExplorerDisabled.Visible = udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog;
					blnVisibleBottom |= mnuExplorerDelete.Visible = udtExplorer.SelectedBlog != null;		
				// Muestra el título adecuado para el menú de Activar / desactivar
					if (udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog)
						{ if (udtExplorer.SelectedBlog.Enabled)
								mnuExplorerDisabled.Text = "Desactivar";
							else
								mnuExplorerDisabled.Text = "Activar";
						}
				// Oculta el separador de menús
					mnuExplorerSeparator.Visible = blnVisibleTop && (blnVisibleMedium || blnVisibleBottom);	
					mnuExplorerSeparatorEntries.Visible = blnVisibleMedium && blnVisibleBottom;
				// Devuelve el valor que indica si se deben mostrar los menús
					return blnVisibleTop || blnVisibleBottom;
		}

		/// <summary>
		///		Crea un nuevo blog
		/// </summary>
		private void OpenPropertiesBlog(DesktopFilesEntry objEntry)
		{ udtExplorer.OpenPropertiesBlog(objEntry);
		}
		
		/// <summary>
		///		Carga un blog
		/// </summary>
		private void OpenBlog(DesktopFilesEntry objBlog)
		{ frmBlogReader frmNewReader = new frmBlogReader();
		
				// Asigna las propiedades
					frmNewReader.IDData = objBlog;
					frmNewReader.Tag = "BLOG_" + objBlog.ID;
				// Muestra el formulario
					Program.MainWindow.OpenWindowDocument(frmNewReader);
		}

		/// <summary>
		///		Descarga las entradas
		/// </summary>
		private void Download()
		{ if (udtExplorer.SelectedBlog != null && udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog)
				Program.BlogsManager.StartDownload(udtExplorer.SelectedBlog);
		}
		
		/// <summary>
		///		Borra un archivo / directorio
		/// </summary>
		private void DeleteFile()
		{ UC.ctlTreeBlogs.FileType intIDType = udtExplorer.SelectedType;
		
				switch (intIDType)
					{ case UC.ctlTreeBlogs.FileType.Folder:
								if (Bau.Controls.Forms.Helper.ShowQuestion(this, "¿Desea eliminar esta categoría?"))
									udtExplorer.DeleteSelectedNode();
							break;
						case UC.ctlTreeBlogs.FileType.Blog:
								if (Bau.Controls.Forms.Helper.ShowQuestion(this, "¿Desea eliminar este blog?"))
									udtExplorer.DeleteSelectedNode();
							break;
					}	
		}
				
		/// <summary>
		///		Ejecuta una acción del programa principal
		/// </summary>
		public void ExecuteAction(clsEnums.TypeAction intAction)
		{	switch (intAction)
				{	case clsEnums.TypeAction.Open:
							if (udtExplorer.SelectedBlog != null)
								OpenBlog(udtExplorer.SelectedBlog);
					  break;
					case clsEnums.TypeAction.NewFolder:
							udtExplorer.NewFolder();
						break;
					case clsEnums.TypeAction.NewFile:
							OpenPropertiesBlog(null);
						break;
					case clsEnums.TypeAction.Update:
							if (udtExplorer.SelectedBlog == null)
								Helper.ShowMessage(this, "Seleccione el blog");
							else
								OpenPropertiesBlog(udtExplorer.SelectedBlog);
						break;				
					case clsEnums.TypeAction.Rename:
							udtExplorer.BeginEditFileName();
						break;
					case clsEnums.TypeAction.Refresh:
							udtExplorer.Refresh();
						break;
					case clsEnums.TypeAction.Remove:
							DeleteFile();
						break;
				}
		}

		/// <summary>
		///		Comprueba si el formulario puede realizar una acción
		/// </summary>
		public bool CanExecuteAction(clsEnums.TypeAction intAction)
		{ switch (intAction)
				{ case clsEnums.TypeAction.Remove:
						return udtExplorer.SelectedType != UC.ctlTreeBlogs.FileType.Unknown;
					case clsEnums.TypeAction.NewFile:
						return udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Folder ||
									 udtExplorer.SelectedBlog == null;
					case clsEnums.TypeAction.Open:
						return udtExplorer.SelectedBlog != null;
					case clsEnums.TypeAction.Update:
						return udtExplorer.SelectedType == UC.ctlTreeBlogs.FileType.Blog ||
										udtExplorer.SelectedBlog != null;
					case clsEnums.TypeAction.Refresh:
						return true;
					default:
						return false;
				}
		}

		/// <summary>
		///		Identificador del documento
		/// </summary>
		public string TagDocument
		{ get { return "BLOG_EXPLORER"; }
		}
		
		private void frmPluginsExplorer_Load(object sender, EventArgs e)
		{ InitForm();
		}

		private void mnuExplorerOpen_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void mnuExplorerRename_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Rename);
		}

		private void mnuExplorerNewFolder_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.NewFolder);
		}

		private void mnuExplorerNewFile_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.NewFile);
		}

		private void mnuExplorerDelete_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void ctxMnuExplorer_Opening(object sender, CancelEventArgs e)
		{ e.Cancel = !ShowMenu();
		}

		private void udtExplorer_RemoveNodeRequired(object objSender, TreeNode trnNode)
		{ ExecuteAction(clsEnums.TypeAction.Remove);
		}

		private void udtExplorer_DoubleClickFile(object objSender, DesktopFilesEntry objEntry)
		{ ExecuteAction(clsEnums.TypeAction.Open);
		}

		private void mnuExplorerDisabled_Click(object sender, EventArgs e)
		{ udtExplorer.UpdateEntryEnabled();
		}

		private void mnuExplorerProperties_Click(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Update);
		}

		/// <summary>
		///		Trata el evento de modificación de una entrada del archivo OPML
		/// </summary>
		private void BlogsManager_UpdatedEntry(OPMLManager objManager, DesktopFilesEntry objEntry)
		{ ExecuteAction(clsEnums.TypeAction.Refresh);
		}
		
		/// <summary>
		///		Trata el evento de modificación del canal de entradas
		/// </summary>
		private void BlogsManager_UpdatedChannel(object sender, EventArgs e)
		{ ExecuteAction(clsEnums.TypeAction.Refresh);
		}

		private void mnuExplorerDownload_Click(object sender, EventArgs e)
		{ Download();
		}
	}
}