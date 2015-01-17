using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Controls.Tree;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;
using Bau.Libraries.LibHelper.Files;

namespace Bau.Applications.ComicsBooks.Forms.Blog.UC
{
	/// <summary>
	///		Control con los árboles de archivos
	/// </summary>
	public partial class ctlTreeBlogs : UserControl
	{ // Enumerados públicos
			public enum FileType
				{ Unknown,
					Folder,
					Blog
				}
		// Delegados privados
			private delegate void WindowCallback(); // Permite llamadas asíncronas para actualizar el árbol
		// Delegados públicos
			public delegate void RemoveNodeRequiredHandler(object objSender, TreeNode trnNode);
			public delegate void DoubleClickBlogHandler(object objSender, DesktopFilesEntry objBlog);
		// Eventos públicos
			public event RemoveNodeRequiredHandler RemoveNodeRequired;
			public event DoubleClickBlogHandler DoubleClickBlog;
			
		public ctlTreeBlogs()
		{ // Inicializa los componentes
				InitializeComponent();
		}
		
		/// <summary>
		///		Limpia el árbol
		/// </summary>
		public void Clear()
		{ // Actualiza el árbol
				Refresh();
		}
		
		/// <summary>
		///		Añade un directorio a la lista
		/// </summary>
		public void LoadBlogs(string strFileName)
		{ // Carga los blogs
				Program.BlogsManager.Load(strFileName);
			// Actualiza el árbol
				Refresh();
		}
		
		/// <summary>
		///		Actualiza el árbol
		/// </summary>
		public new void Refresh()
		{ // Comprueba que se le llame desde el mismo hilo de ejecución antes de actualizar
				if (this.InvokeRequired)
					{	WindowCallback fncCallback = new WindowCallback(Refresh);
					
					    Invoke(fncCallback);
					}
				else
					{	// Comienza la edición del árbol
							trvFiles.BeginUpdate();
						// Graba los nodos abiertos
							trvFiles.SaveOpenNodes();
						// Limpia el árbol
							trvFiles.Nodes.Clear();
						// Inicializa las propiedades
							trvFiles.ImageList = ComicsBooks.Classes.clsListImagesUI.Images;
							trvFiles.LabelEdit = true;
						// Ordena las entradas
							Program.BlogsManager.Channel.Entries.Sort();
						// Añade los nodos raíz
							LoadNodes(null, Program.BlogsManager.Channel.Entries);
						// Actualiza los nodos abiertos
							trvFiles.RestoreOpenNodes();
						// Finaliza la edición del árbol
							trvFiles.EndUpdate();
						// Llama al método base
							base.Refresh();
					}
		}

		/// <summary>
		///		Carga los nodos del árbol
		/// </summary>
		private void LoadNodes(TreeNode trnParent, DesktopFilesEntriesCollection objColEntries)
		{ foreach (DesktopFilesEntry objEntry in objColEntries)
				{ TreeNode trnNode = AddNode(trnParent, objEntry);
				
						// Carga los nodos hijo
							LoadNodes(trnNode, objEntry.Entries);
				}
		}
		
		/// <summary>
		///		Añade un nodo al árbol con un directorio
		/// </summary>
		private TreeNode AddNode(TreeNode trnParent, DesktopFilesEntry objEntry)
		{ ComicsBooks.Classes.clsListImagesUI.ImagesIndex intIcon = ComicsBooks.Classes.clsListImagesUI.ImagesIndex.Folder;
			FileType intFileType = FileType.Folder;
			Color clrNode = Color.FromKnownColor(KnownColor.Blue);
			TreeNodeKey objKey;
			int intNumberNotRead = objEntry.CountNotRead(), intIndex = 0;
			string strText;
			
				// Si es un blog ...
					if (!string.IsNullOrEmpty(objEntry.URL))
						{ // Cambia el icono y tipo de archivo
								intIcon = ComicsBooks.Classes.clsListImagesUI.ImagesIndex.Document;
								intFileType = FileType.Blog;
							// Cambia el color del nodo
								if (!objEntry.Enabled)
									clrNode = Color.FromKnownColor(KnownColor.GrayText);
								else if (ComicsBooks.Classes.clsConfiguration.MarkNotUpdatesInterval != 0 &&
												 objEntry.DateLastUpdated < DateTime.Now.AddDays(-ComicsBooks.Classes.clsConfiguration.MarkNotUpdatesInterval))
									clrNode = Color.FromKnownColor(KnownColor.Red);
								else
									clrNode = Color.FromKnownColor(KnownColor.Black);
						}
				// Calcula el índice
					if (trnParent != null)
						intIndex = (trnParent.Level + 1) * 1000000 + (trnParent.Index + 1) * 10000 + trnParent.Nodes.Count + 1;
					else
						intIndex += trvFiles.Nodes.Count + 1;
				// Asigna el nombre de directorio / archivo al nodo
					objKey = new TreeNodeKey((int) intFileType, intIndex);
					objKey.Tag = objEntry;
				// Obtiene el texto
					if (intNumberNotRead == 0)
						strText = objEntry.Text;
					else
						strText = objEntry.Text + " (" + intNumberNotRead.ToString() + ")";
				// Añade el nodo y lo devuelve
					return trvFiles.AddNode(trnParent, objKey, strText, false,
																	(int) intIcon, clrNode, intNumberNotRead > 0);
		}

		/// <summary>
		///		Crea una nueva carpeta
		/// </summary>
		internal void NewFolder()
		{ TreeNode trnNode = trvFiles.SelectedNode;
			string strName = Bau.Controls.Forms.Helper.ShowInputMessage("Nueva categoría", 
																																	"Introduzca el nombre de la categoría",
																																	null);
		
				if (!string.IsNullOrEmpty(strName))
					{	DesktopFilesEntry objEntry = new DesktopFilesEntry();
						
							// Asigna los datos a la entrada
								objEntry.Text = strName;
							// Añade el nodo al árbol
								AddNode(trnNode, objEntry);
							// Graba el archivo
								Save();
							// Actualiza el árbol
								Refresh();
					}
		}

		/// <summary>
		///		Abre el formulario de propiedades del blog
		/// </summary>
		internal void OpenPropertiesBlog(DesktopFilesEntry objEntry)
		{ TreeNode trnNode = trvFiles.SelectedNode;
			frmPropertiesBlog frmNewProperties = new frmPropertiesBlog();
		
				// Asigna las propiedades
					frmNewProperties.Channel = Program.BlogsManager.Channel;
					frmNewProperties.Entry = objEntry;
				// Muestra el formulario
					frmNewProperties.ShowDialog();
				// Graba el archivo y actualiza el árbol
					if (frmNewProperties.DialogResult == DialogResult.OK)
						{ // Añade el nodo
								if (objEntry == null)
									AddNode(trnNode, frmNewProperties.Entry);
								//else
								//  SelectedBlog = frmNewProperties.Entry;
							// Graba el archivo y actualiza el árbol
								Save();
							// Actualiza el árbol
								Refresh();
						}
		}		
		/// <summary>
		///		Elimina el nodo seleccionado
		/// </summary>
		internal void DeleteSelectedNode()
		{ if (SelectedBlog != null)
				{ // Elimina los archivos
						DeleteFiles(SelectedBlog);
					// Elimina el elemento
						trvFiles.Nodes.Remove(trvFiles.SelectedNode);
					// Graba los datos
						Save();
					// Actualiza el árbol
						Refresh();
				}
		}

		/// <summary>
		///		Elimina los archivos de la entrada
		/// </summary>
		private void DeleteFiles(DesktopFilesEntry objEntry)
		{ // Elimina los archivos hijo
				if (objEntry.Entries.Count > 0)
					foreach (DesktopFilesEntry objChild in objEntry.Entries)
						DeleteFiles(objChild);
			// Elimina los archivos
				if (!objEntry.IsFolder)
					{	HelperFiles.KillFile(Path.Combine(clsConfiguration.PathBaseBlogs, objEntry.LocalFileName));
						HelperFiles.KillFile(Path.Combine(clsConfiguration.PathBaseBlogs, objEntry.LocalFileNameDeleted));
						HelperFiles.KillFile(Path.Combine(clsConfiguration.PathBaseBlogs, objEntry.LocalFileNameDownload));
					}
		}

		/// <summary>
		///		Cambia el nombre de un archivo
		/// </summary>
		private bool RenameFile(TreeNode trnNode, string strNewName)
		{ bool blnRename = false;
		
				if (!string.IsNullOrEmpty(strNewName))
					{ Bau.Controls.Tree.TreeNodeKey objKey = trvFiles.GetKey(trnNode);
					
							if (objKey != null && objKey.Tag != null && objKey.Tag is DesktopFilesEntry)
								{ // Cambia el nombre de la entrada
										(objKey.Tag as DesktopFilesEntry).Text = strNewName;
									// Cambia el nombre del árbol
										trnNode.Text = strNewName;
									// Graba los datos
										Save();
									// Indica que se ha renombrado
										blnRename = true;
								}
					}
				// Devuelve el valor que indica si se ha renombrado
					return blnRename;
		}
		
		/// <summary>
		///		Comienza la edición del nodo seleccionado
		/// </summary>
		public void BeginEditFileName()
		{	if (trvFiles.SelectedNode != null)
				trvFiles.SelectedNode.BeginEdit();
		}

		/// <summary>
		///		Modifica el estado de Activo / Inactivo de una entrada
		/// </summary>
		public void UpdateEntryEnabled()
		{	if (SelectedType == UC.ctlTreeBlogs.FileType.Blog)
				{ // Cambia el estado de la entrada
						SelectedBlog.Enabled = !SelectedBlog.Enabled;
					// Graba las entradas
						Save();
					// Actualiza el árbol
						Refresh();
				}
		}

		/// <summary>
		///		Mueve / copia un nodo
		/// </summary>
		private void MoveNode(TreeViewExtendedDropEventArgs evnDrop)
		{ if (evnDrop.DroppedItem.GetDataPresent("System.Windows.Forms.TreeNode", false))
				{ TreeNode trnSource = evnDrop.DroppedItem.GetData("System.Windows.Forms.TreeNode") as TreeNode;

						if (trnSource != null && trnSource.TreeView == trvFiles)
							{	bool blnCanMove = true;
							
									// Copia el elemento
										if (evnDrop.Node == null) // ... siempre se puede mover o copiar sobre el raíz
											trvFiles.Nodes.Add((TreeNode) trnSource.Clone());
										else
											{ TreeNodeKey	objKeyTarget = trvFiles.GetKey(evnDrop.Node);
												TreeNodeKey	objKeySource = trvFiles.GetKey(trnSource);

													// Sólo se puede mover sobre una carpeta
														if (objKeyTarget.IDType == (int) FileType.Folder &&
																(!evnDrop.Node.FullPath.StartsWith(trnSource.FullPath, 
																																	 StringComparison.CurrentCultureIgnoreCase) ||
																 objKeySource.IDType != (int) FileType.Folder))
															{ // Expande el nodo para cargar sus hijos
																	evnDrop.Node.Expand();
																// Y añade el nodo movido / copiado
																	evnDrop.Node.Nodes.Add((TreeNode) trnSource.Clone());
																// Expande el nodo donde se cuelga
																	evnDrop.Node.Expand();
															}
														else
															blnCanMove = false;
											}
									// Elimina el elemento inicial y graba
										if (blnCanMove)
											{ // Elimina el elemento inicial (aunque sea una copia porque no tiene sentido
												// tener los mismos blog dos veces)
													trnSource.Remove();
												// Graba el blog
													Save();
											}
							}
				}
		}
				
		/// <summary>
		///		Graba el archivo
		/// </summary>
		public void Save()
		{ // Limpia las entradas del canal
				Program.BlogsManager.Channel.Entries.Clear();
			// Añade las entradas
				GetChannelEntries(Program.BlogsManager.Channel.Entries, trvFiles.Nodes);
			// Graba el archivo
				Program.BlogsManager.Save();
		}

		/// <summary>
		///		Añade las entradas del canal guardades en los nodos
		/// </summary>
		private void GetChannelEntries(DesktopFilesEntriesCollection objColEntries, 
																	 TreeNodeCollection trnNodesCollection)
		{ foreach (TreeNode trnNode in trnNodesCollection)
				{ TreeNodeKey objKey = trvFiles.GetKey(trnNode);
				
						if (objKey != null && objKey.Tag != null && objKey.Tag is DesktopFilesEntry)
							{ DesktopFilesEntry objEntry = new DesktopFilesEntry(); 
								DesktopFilesEntry objTreeEntry = (objKey.Tag as DesktopFilesEntry);
								
									// Asigna los datos de la entrada del árbol
										objEntry.DateCreated = objTreeEntry.DateCreated;
										objEntry.DateLastRead = objTreeEntry.DateLastRead;
										objEntry.DateLastUpdated = objTreeEntry.DateLastUpdated;
										objEntry.Description = objTreeEntry.Description;
										objEntry.Enabled = objTreeEntry.Enabled;
										objEntry.LocalFileName = objTreeEntry.LocalFileName;
										objEntry.NumberNotRead = objTreeEntry.NumberNotRead;
										objEntry.Password = objTreeEntry.Password;
										objEntry.Text = objTreeEntry.Text;
										objEntry.URL = objTreeEntry.URL;
										objEntry.User = objTreeEntry.User;
									// Añade la entrada a la colección
										objColEntries.Add(objEntry);
									// Añade los nodos hijo a las entradas
										if (trnNode.Nodes.Count > 0)
											GetChannelEntries(objEntry.Entries, trnNode.Nodes);
							}
				}
		}
		
		/// <summary>
		///		Elemento seleccionado
		/// </summary>
		public FileType SelectedType
		{ get 
				{ Bau.Controls.Tree.TreeNodeKey objKey = trvFiles.GetKey(trvFiles.SelectedNode);
				
						if (objKey == null)
							return FileType.Unknown;
						else
							return (FileType) objKey.IDType;
				}
		}
		
		/// <summary>
		///		Elemento seleccionado
		/// </summary>
		public DesktopFilesEntry SelectedBlog
		{ get 
				{ // Obtiene el blog del nodo				
						if (trvFiles.SelectedNode != null)
							{ TreeNodeKey objKey = trvFiles.GetKey(trvFiles.SelectedNode);
									
									if (objKey.Tag is DesktopFilesEntry)
										return objKey.Tag as DesktopFilesEntry; 
							}
					// Devuelve el blog localizado
						return null;
				}
		}

		private void trvFiles_NodeDelete(object objSender, TreeViewExtendedEventArgs evnArgs)
		{ if (RemoveNodeRequired != null)
				RemoveNodeRequired(this, trvFiles.SelectedNode);
		}

		private void trvFiles_NodeDoubleClick(object objSender, TreeViewExtendedEventArgs evnArgs)
		{ if (DoubleClickBlog != null && SelectedBlog != null)
				DoubleClickBlog(this, SelectedBlog);
		}

		private void trvFiles_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{ e.CancelEdit = !RenameFile(e.Node, e.Label);
		}

		private void trvFiles_DropItem(object objSender, TreeViewExtendedDropEventArgs evnDrop)
		{ MoveNode(evnDrop);
		}
	}
}
