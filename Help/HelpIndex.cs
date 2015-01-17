using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Controls.Help
{
	/// <summary>
	///		Control con el índice de la ayuda
	/// </summary>
	public partial class HelpIndex : UserControl
	{ // Delegados públicos
			public delegate void PageClickHandler(object objSender, HelpPages.HelpPage objPage);
		// Eventos
			public event PageClickHandler PageClick;
		// Enumerados privados
			private enum ImageKey
				{ Folder,
					Page
				}
		// Variables privadas
			HelpPages.HelpPagesCollection objColHelp = new HelpPages.HelpPagesCollection();
			
		public HelpIndex()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Inicializa el control
		/// </summary>
		private void InitControl()
		{ // Inicializa la lista de imágenes
				imlHelp.Images.Clear();
				imlHelp.Images.Add(Properties.Resources.Folder);
				imlHelp.Images.Add(Properties.Resources.Page);
			// Inicializa las propiedades del árbol
				trvHelp.ImageList = imlHelp;
		}
		
		/// <summary>
		///		Carga el árbol de ayuda
		/// </summary>
		public void LoadPages(string strPath, string strExtensionHelpFile)
		{ // Inicializa el control
				InitControl();
			// Carga las páginas
				if (System.IO.Directory.Exists(strPath))
					{	string [] arrStrFiles = System.IO.Directory.GetFiles(strPath, "*." + strExtensionHelpFile);

							// Carga los archivos
								objColHelp.Clear();
								foreach (string strFile in arrStrFiles)
									try
										{	objColHelp.Load(strFile);
										}
									catch {}
							// Limpia el árbol
								trvHelp.Nodes.Clear();
							// Muestra las ayudas en el árbol
								foreach (HelpPages.HelpPage objPage in objColHelp)
									LoadTree(null, objPage);
					}
		}
		
		/// <summary>
		///		Carga el árbol de ayuda de una página
		/// </summary>
		private void LoadTree(TreeNode trnParent, HelpPages.HelpPage objPage)
		{ TreeNode trnHelp;
		
				// Añade el nodo
					if (trnParent == null)
						trnHelp = trvHelp.Nodes.Add(objPage.Description);
					else
						trnHelp = trnParent.Nodes.Add(objPage.Description);
				// Asigna las propiedades
					trnHelp.Tag = objPage;
					if (objPage.Pages.Count == 0)
						trnHelp.ImageIndex = (int) ImageKey.Page;
					else
						trnHelp.ImageIndex = (int) ImageKey.Folder;
					trnHelp.SelectedImageIndex = trnHelp.ImageIndex;
				// Carga las páginas hijo
					foreach (HelpPages.HelpPage objChildPage in objPage.Pages)
						LoadTree(trnHelp, objChildPage);
		}
		
		/// <summary>
		///		Lanza el evento de abrir la ayuda
		/// </summary>
		private void RaiseEvent(HelpPages.HelpPage objPage)
		{ if (!string.IsNullOrEmpty(objPage.FileName) && PageClick != null)
				PageClick(this, objPage);
		}

		private void trvHelp_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{ if (e.Node != null && e.Node.Tag is HelpPages.HelpPage)
				RaiseEvent(e.Node.Tag as HelpPages.HelpPage);
		}
	}
}
