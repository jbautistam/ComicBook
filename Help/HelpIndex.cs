using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Controls.Help
{
	/// <summary>
	///		Control con el �ndice de la ayuda
	/// </summary>
	public partial class HelpIndex : UserControl
	{ // Delegados p�blicos
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
		{ // Inicializa la lista de im�genes
				imlHelp.Images.Clear();
				imlHelp.Images.Add(Properties.Resources.Folder);
				imlHelp.Images.Add(Properties.Resources.Page);
			// Inicializa las propiedades del �rbol
				trvHelp.ImageList = imlHelp;
		}
		
		/// <summary>
		///		Carga el �rbol de ayuda
		/// </summary>
		public void LoadPages(string strPath, string strExtensionHelpFile)
		{ // Inicializa el control
				InitControl();
			// Carga las p�ginas
				if (System.IO.Directory.Exists(strPath))
					{	string [] arrStrFiles = System.IO.Directory.GetFiles(strPath, "*." + strExtensionHelpFile);

							// Carga los archivos
								objColHelp.Clear();
								foreach (string strFile in arrStrFiles)
									try
										{	objColHelp.Load(strFile);
										}
									catch {}
							// Limpia el �rbol
								trvHelp.Nodes.Clear();
							// Muestra las ayudas en el �rbol
								foreach (HelpPages.HelpPage objPage in objColHelp)
									LoadTree(null, objPage);
					}
		}
		
		/// <summary>
		///		Carga el �rbol de ayuda de una p�gina
		/// </summary>
		private void LoadTree(TreeNode trnParent, HelpPages.HelpPage objPage)
		{ TreeNode trnHelp;
		
				// A�ade el nodo
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
				// Carga las p�ginas hijo
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
