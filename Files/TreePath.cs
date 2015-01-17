using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Bau.Controls.Files.Events;
using Bau.Controls.Files.FilesInfo;

namespace Bau.Controls.Files
{
	/// <summary>
	/// 	Control para mostrar los directorios / archivos en un árbol
	/// </summary>
	public partial class TreePath
	{ // Constantes privadas
			private const string cnstStrEmptyNode = "##$€&&..()=??**";
		// Enumerados
			private enum enumIcons
				{ IconHardDisk = 0,
					IconFolderClosed,
					IconFolderOpen,
					IconCD,
					IconNetDisk,
					IconMyDocuments,
					IconDesktop,
					IconMyPC,
					IconFavourites,
					IconServer,
					IconDrive35,
					IconTrash,
					IconNetwork				
				}
		// Delegados
			public delegate void MoveFileHandler(object objSender, string strLastFileName, string strActualFileName);
		// Eventos
			public event EventHandler<clsFileEventArgs> PathChanged;
			public event EventHandler<clsFileEventArgs> FileDoubleClick;
			public event EventHandler<clsFileEventArgs> FileSelected;
		// Variables privadas
			private colFiles objColNodes = new colFiles();
			private string strBasePath, strPath, strMask;
			private bool blnShowFiles;
			
		public TreePath()
		{ // The InitializeComponent() call is required for Windows Forms designer support.
				InitializeComponent();
			// Inicializa las variables privadas
				strPath = "C:\\";
				strMask = "*.*";
				blnShowFiles = false;
			// Carga los directorios
				LoadTree();
		}

		/// <summary>
		/// 	Refresca el control
		/// </summary>
		public override void Refresh()
		{ // Carga el árbol si es necesario
				LoadTree();
			// Actualiza el control
				base.Refresh();
		}
		
		/// <summary>
		/// 	Carga el árbol a partir de un directorio en concreto
		/// </summary>
		public void LoadSelectedPath(string strName, string strPath)
		{ TreeNode trnNode;
			
				// Comienza las modificaciones
					trvFiles.BeginUpdate();
				// Limpia el árbol
					trvFiles.Nodes.Clear();
				// Crea un nodo para la raíz
					trnNode = trvFiles.Nodes.Add(strName);
					trnNode.ImageIndex = (int) enumIcons.IconFavourites;
					trnNode.Tag = new clsFile(strPath);
				// Carga los nodos de la raíz
					LoadTree(trnNode, (clsFile) trnNode.Tag, true);
				// Finaliza las modificaciones
					trvFiles.EndUpdate();
		}
		
		/// <summary>
		/// 	Carga el árbol con los directorios
		/// </summary>
		public void LoadTree()
		{ // Comienza las modificaciones
				trvFiles.BeginUpdate();
			// Guarda los nodos abiertos
				SaveOpenNodes();
			// Limpia el árbol
				trvFiles.Nodes.Clear();
			// Crea los nodos básicos
				if (string.IsNullOrEmpty(BasePath))
					LoadTreeWindows();
				else
					LoadTreeBasePath(BasePath);
			// Recupera los nodos abiertos
				RestoreOpenNodes();
      // Finaliza las modificaciones
      	trvFiles.EndUpdate();
		}

		/// <summary>
		///		Carga el árbol a partir de un directorio base
		/// </summary>
		private void LoadTreeBasePath(string strPath)
		{ TreeNode trnRoot = AddNode(null, new clsFile(strPath), (int) enumIcons.IconDesktop);
		
	      // Carga los archivos del nodo base
					trnRoot.Expand();
		}

		/// <summary>
		///		Carga el árbol Windows, es decir, con los nodos de Escritorio, Mis documentos y Mi PC
		/// </summary>
		private void LoadTreeWindows()
		{ int intIndexIcon = (int) enumIcons.IconFolderClosed;
			TreeNode trnDesktop, trnNode;
			
				// Crea un nodo para el escritorio
					trnDesktop = trvFiles.Nodes.Add("Escritorio");
					trnDesktop.ImageIndex = (int) enumIcons.IconDesktop;
					trnDesktop.Tag = new clsFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop));
				// Crea un nodo para Mis Documentos
					AddNode(trnDesktop, new clsFile(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)),
					        (int) enumIcons.IconMyDocuments);
				// Crea un nodo para Mi PC
					trnNode = trnDesktop.Nodes.Add("Mi PC");
					trnNode.ImageIndex = (int) enumIcons.IconMyPC;
				// Crea un nodo para las unidades
	        foreach (DriveInfo drvDisk in DriveInfo.GetDrives())
		        { // Obtiene el icono a partir del tipo de unidad
			        	switch (drvDisk.DriveType)
				        	{ case DriveType.CDRom:
			        					intIndexIcon = (int) enumIcons.IconCD;
				        			break;
				        		case DriveType.Fixed:
				        				intIndexIcon = (int) enumIcons.IconHardDisk;
				        			break;
				        		case DriveType.Network:
				        				intIndexIcon = (int) enumIcons.IconNetDisk;
				        			break;
				        		case DriveType.Ram:
				        				intIndexIcon = (int) enumIcons.IconDesktop;
				        			break;
				        		case DriveType.Removable:
				        				intIndexIcon = (int) enumIcons.IconDrive35;
				        			break;
				        		case DriveType.Unknown:
				        				intIndexIcon = (int) enumIcons.IconFolderClosed;
				        			break;
				        		default:
				        				intIndexIcon = (int) enumIcons.IconFolderClosed;
				        			break;
				        	}
		        	// Agrega el nodo
		        		AddNode(trnNode, new clsFile(drvDisk.Name), intIndexIcon);
		        }
	      // Carga los archivos del escritorio
	      	LoadTree(trnDesktop, new clsFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), false);
				// Expande el nodo del escritorio
      		trnDesktop.Expand();
		}
		
		/// <summary>
		/// 	Carga el árbol de un directorio (recursiva)
		/// </summary>
		private void LoadTree(TreeNode trnParent, clsFile objFile, bool blnRemoveChildNodes)
		{ colFiles objColFiles = new colFiles();
			
				// Comienza la modificación
					trvFiles.BeginUpdate();
				// Limpia los nodos hijo
					if (blnRemoveChildNodes)
						trnParent.Nodes.Clear();
				// Carga los datos del directorio
					if (objFile.IsDirectory)
						{ // Carga los archivos
								objColFiles.Load(objFile.FullName, strMask);
							// Recorre los directorios creando los nodos
								foreach (clsFile objFileIterator in objColFiles)
									if (objFileIterator.IsDirectory)
										AddNode(trnParent, objFileIterator, (int) enumIcons.IconFolderClosed);
							// Recorre los archivos creando los nodos (lo hace después de los directorios)
								if (blnShowFiles)
									foreach (clsFile objFileIterator in objColFiles)
										if (!objFileIterator.IsDirectory)
											AddNode(trnParent, objFileIterator, -1);
						}
				// Finaliza la modificación
					trvFiles.EndUpdate();
		}
		
		/// <summary>
		/// 	Agrega un nodo al árbol
		/// </summary>
		private TreeNode AddNode(TreeNode trnParent, clsFile objFile, int intIndexIcon)
		{ TreeNode trnNode;
			
				// Agrega el nodo
					if (trnParent == null) // ... si se inserta sobre la raíz
						trnNode = trvFiles.Nodes.Add(objFile.Name != "" ? objFile.Name : objFile.FullName);
					else
						trnNode = trnParent.Nodes.Add(objFile.Name != "" ? objFile.Name : objFile.FullName);
				// Le quita la barra del final
					if (trnNode.Text.EndsWith("\\"))
						trnNode.Text = trnNode.Text.Substring(0, trnNode.Text.Length - 1);
				// Asigna el objeto al tag del nodo
					trnNode.Tag = objFile;
				// Si es un directorio le añade un nodo hijo vacío
					if (objFile.IsDirectory)
						trnNode.Nodes.Add(cnstStrEmptyNode);
					else // ... cambia el icono
						{ if (objFile.Icon != null && 
						      (intIndexIcon = imlIcons.Images.IndexOfKey(objFile.HandleIcon.ToString())) == -1)
						    { // Añade el icono
						    		imlIcons.Images.Add(objFile.HandleIcon.ToString(), objFile.Icon);
						    	// Obtiene el índice
						    		intIndexIcon = imlIcons.Images.IndexOfKey(objFile.HandleIcon.ToString());
						    }
						}
				// Asigna el índice del icono al elemento de la lista
					if (intIndexIcon >= 0)
						{	trnNode.ImageIndex = intIndexIcon;
							trnNode.SelectedImageIndex = intIndexIcon;
						}
				// Devuelve el nodo que se acaba de crear
					return trnNode;
		}
		
		/// <summary>
		/// 	Abre el árbol hasta encontrar determinado nodo
		/// </summary>
		private void SelectPath(string strPath)
		{ string [] arrStrPath = strPath.Split('\\');
			string strNewPath = "";
			
				// Expande los nodos del árbol
					foreach (string strPart in arrStrPath)
						{ // Añade la parte del directorio
								strNewPath = System.IO.Path.Combine(strNewPath, strPart);
							// Expande el nodo
								Expand(strNewPath, trvFiles.Nodes);
						}
			//TreeNodeCollection trnCollection;
			//TreeNode trnNext = null;
			
			//// Si realmente existe el directorio ...
			//  if (Directory.Exists(strPath))
			//    {	// Mientras que no haya encontrado el directorio ...
			//        while (!blnFound)
			//          { // Obtiene la colección de nodos sobre las que debe buscar
			//              if (trnNext == null)
			//                trnCollection = trvFiles.Nodes;
			//              else
			//                trnCollection = trnNext.Nodes;
			//            // Recorre la colección comprobando si lo ha encontrado
			//              foreach (TreeNode trnNode in trnCollection)
			//                { if (strPath.Equals(((clsFile) trnNode.Tag).FullName, StringComparison.CurrentCultureIgnoreCase))
			//                    { // Selecciona el nodo
			//                        trvFiles.SelectedNode = trnNode;
			//                      // Indica que se ha encontrado el directorio
			//                        blnFound = true;
			//                    }
			//                  if (strPath.StartsWith(((clsFile) trnNode.Tag).FullName, StringComparison.CurrentCultureIgnoreCase))
			//                    { trnNode.Expand();
			//                      trnNext = trnNode;
			//                    }
			//                }
			//          }
			//    }
		}
		
		/// <summary>
		///		Recorre los nodos expandiendo el que se corresponde con el directorio
		/// </summary>
		private bool Expand(string strPath, TreeNodeCollection trnColNodes)
		{ bool blnFound = false;
		
				// Recorre los nodos buscando el directorio
					foreach (TreeNode trnNode in trnColNodes)
						{ // Expande el nodo
								trnNode.Expand();
							// Comprueba si es el directorio buscado
								if (trnNode.Tag is clsFile && 
										(trnNode.Tag as clsFile).FullName.Equals(strPath, StringComparison.CurrentCultureIgnoreCase))
									{ // Selecciona el nodo
											trvFiles.SelectedNode = trnNode;
										// Indica que lo ha encontrado
											blnFound = true;
									}
						}
				// Si no lo ha encontrado, busca en los nodos hijo
					if (!blnFound)
						foreach (TreeNode trnNode in trnColNodes)
							if (!blnFound)
								blnFound = Expand(strPath, trnNode.Nodes);
				// Devuelve el valor que indica si lo ha encontrado
					return blnFound;
		}
		
		/// <summary>
		/// 	Obtiene el nodo que se encuentra en una posición de ratón (pasando antes las
		/// 	coordenadas de pantalla a coordenadas de cliente)
		/// </summary>
		private TreeNode GetNodeAt(int intScreenX, int intScreenY)
		{ return trvFiles.GetNodeAt(trvFiles.PointToClient(new Point(intScreenX, intScreenY)));
		}
		
		/// <summary>
		/// 	Realiza el movimiento / copia de archivos / directorios
		/// </summary>
		private void MoveFiles(TreeNode trnSource, TreeNode trnTarget, DragDropEffects intEffect)
		{ if (trnTarget != null && trnSource != null && !trnSource.Equals(trnTarget) && 
			    !ContainsNode(trnSource, trnTarget))
				{ // Si el nodo destino es un archivo, se mueve o copia sobre el padre
			    	if (!((clsFile) trnTarget.Tag).IsDirectory)
			    		trnTarget = trnTarget.Parent;
			    // Comprueba si el destino es un nodo nulo (nunca debería pasar, pero por si acaso)
				    if (trnTarget != null)
					    {	// Realiza el movimiento o la copia
									if (intEffect == DragDropEffects.Move)
										{	// Mueve el archivo
												((clsFile) trnSource.Tag).Move(((clsFile) trnTarget.Tag).FullName);
											// Elimina el nodo origen
												trnSource.Remove();
										}
									else if (intEffect == DragDropEffects.Copy)
										((clsFile) trnSource.Tag).Copy(((clsFile) trnTarget.Tag).FullName);
								// Carga el árbol del nodo destino
									LoadTree(trnTarget, (clsFile) trnTarget.Tag, true);
								// Expande el nodo destino
									trnTarget.Expand();
					    }
				}
		}
		
		/// <summary>
		/// 	Comprueba si un nodo contiene un segundo nodo
		/// </summary>
    private bool ContainsNode(TreeNode trnParent, TreeNode trnChild)
    {	// Comprueba si el nodo hijo es padre del segundo nodo
        if (trnChild.Parent == null) 
        	return false;
        if (trnChild.Parent.Equals(trnParent)) 
        	return true;
      // Llama recursivamente a la función utilizando el padre del nodo supuestamente hijo
      	return ContainsNode(trnParent, trnChild.Parent);
    }
		
    /// <summary>
    /// 	Cambia el nombre de un archivo o directorio
    /// </summary>
    private bool RenameFile(TreeNode trnNode, string strNewName)
    { clsFile objFile = (clsFile) trnNode.Tag;
    	bool blnCancel = true; // ... Indica que se cancela la modificación

    		// Cambia el nombre del archivo
    			try
	    			{	// Cambia el nombre del archivo / directorio
				    		objFile.Rename(strNewName);
				    	// Recarga los nodos hijo
				    		if (objFile.IsDirectory)
				    			LoadTree(trnNode, objFile, true);
				    	// Si ha llegado hasta aquí es porque todo ha ido bien
				    		blnCancel = false;
	    			}
    			catch {}
	    	// Devuelve el valor que indica si todo ha ido correctamente
	    		return blnCancel;
    }
		
		/// <summary>
		/// 	Trata el evento producido cuando se expande un nodo
		/// </summary>
		private void TreatNodeExpand(TreeNode trnNode)
		{ if (trnNode.Nodes.Count == 1 && trnNode.Nodes[0].Text == cnstStrEmptyNode)
				{ // Borra los hijos del nodo
						trnNode.Nodes.Clear();
					// Añade los directorios hijos de este directorio
						LoadTree(trnNode, (clsFile) trnNode.Tag, true);
				}
		}
	
		/// <summary>
		/// 	Trata el evento generado cuando se selecciona un nodo
		/// </summary>
		private void TreatNodeSelected(TreeNode trnNode)
		{ clsFile objFile = (clsFile) trnNode.Tag;
			
				if (objFile != null)
					{ if (objFile.IsDirectory && PathChanged != null)
							{ // Almacena el directorio
									strPath = objFile.FullName;
								// Lanza el evento
									PathChanged(this, new clsFileEventArgs(objFile));
							}
						if (FileSelected != null)
							FileSelected(this, new clsFileEventArgs(objFile));
					}	
		}
		
		/// <summary>
		/// 	Trata el evento generado al pulsar dos veces sobre un nodo
		/// </summary>
		private void TreatNodeDoubleClick(TreeNode trnNode)
		{ clsFile objFile = (clsFile) trnNode.Tag;
			
				if (objFile != null && !objFile.IsDirectory && FileDoubleClick != null)
					FileDoubleClick(this, new clsFileEventArgs(objFile));
		}
		
		/// <summary>
		///		Obtiene el archivo seleccionado en el nodo
		/// </summary>
		private clsFile GetSelectedFile()
		{ clsFile objFile = null;
		
				// Obtiene el archivo seleccionado	
					if (trvFiles.SelectedNode != null && trvFiles.SelectedNode.Tag != null && trvFiles.SelectedNode.Tag is clsFile)
						objFile = trvFiles.SelectedNode.Tag as clsFile;
				// Devuelve el archivo
					return objFile;
		}

		/// <summary>
		///		Renombra el archivo
		/// </summary>
		public void Rename()
		{ if (trvFiles.SelectedNode != null)
				trvFiles.SelectedNode.BeginEdit();
		}

		/// <summary>
		///		Copia el archivo o directorio seleccionado
		/// </summary>
		public void Copy()
		{ AddFileToBuffer(FilesManager.ActionCopy.Copy);
		}

		/// <summary>
		///		Corta el archivo o directorio seleccionado
		/// </summary>
		public void Cut()
		{ AddFileToBuffer(FilesManager.ActionCopy.Cut);
		}

		/// <summary>
		///		Añade el archivo al buffer
		/// </summary>
		private void AddFileToBuffer(FilesManager.ActionCopy intAction)
		{ clsFile objFile = GetSelectedFile();
		
				if (objFile != null)
					{ // Limpia los archivos del buffer
							FilesManager.Clear();
						// Añade el archivo al buffer
							FilesManager.Add(objFile);
						// Cambia la acción
							FilesManager.Action = intAction;
					}
		}
		
		/// <summary>
		///		Corta / pega los archivos seleccionados
		/// </summary>
		public void Paste()
		{ if (!string.IsNullOrEmpty(Path))
				{ // Copia los archivos
						FilesManager.Paste(Path);
					// Actualiza
						Refresh();
				}
		}

		/// <summary>
		///		Elimina un archivo / directorio
		/// </summary>
		public void KillFile()
		{ if (!string.IsNullOrEmpty(Path))
				{ // Elimina el archivo
						FilesManager.Kill(Path);
					// Actualiza
						trvFiles.SelectedNode.Remove();
				}
		}
		
		/// <summary>
		///		Guarda los nodos abiertos
		/// </summary>
		public void SaveOpenNodes()
		{ // Limpia la colección
				objColNodes.Clear();
			// Recorre los nodos almacenando los nodos abiertos
				SaveOpenNodes(trvFiles.Nodes);
		}
		
		/// <summary>
		///		Graba recursivamente los nodos abiertos
		/// </summary>
		private void SaveOpenNodes(TreeNodeCollection trnNodeCollection)
		{	foreach (TreeNode trnNode in trnNodeCollection)
				if (trnNode.Tag != null && trnNode.IsExpanded)
					{	// Añade la clave del nodo a la colección
							objColNodes.Add(trnNode.Tag as clsFile);
						// Graba los nodos hijos abiertos
							SaveOpenNodes(trnNode.Nodes);
					}
		}
		
		/// <summary>
		///		Recupera los nodos abiertos
		/// </summary>
		public void RestoreOpenNodes()
		{	TreeNode trnNode;
			
				foreach (clsFile objNodeKey in objColNodes)
					if (objNodeKey != null)
						{	// Busca el nodo (puede que se haya eliminado el elemento que lo representa)
								trnNode = SearchNode(trvFiles.Nodes, objNodeKey);
							// Lanza el evento de apertura de nodos
								if (trnNode != null && !trnNode.IsExpanded)
									trnNode.Expand();
						}
		}
		
		/// <summary>
		///		Busca recursivamente por los nodos del árbol
		/// </summary>
		private TreeNode SearchNode(TreeNodeCollection objColNodes, clsFile objFile)
		{ TreeNode trnNodeFound = null;
		
				// Recorre los nodos buscando el seleccionado
					foreach (TreeNode trnNode in objColNodes)
						if (trnNodeFound == null)
							{ if (trnNode.Tag != null && trnNode.Tag is clsFile)
									System.Diagnostics.Debug.WriteLine((trnNode.Tag as clsFile).FullName);
								else
									System.Diagnostics.Debug.WriteLine("--- " + trnNode.Text);
								if (trnNode.Tag != null && trnNode.Tag is clsFile && (trnNode.Tag as clsFile).FullName == objFile.FullName)
									trnNodeFound = trnNode;
								else
									trnNodeFound = SearchNode(trnNode.Nodes, objFile);
							}
				// Devuelve el nodo
					return trnNodeFound;
		}

		/// <summary>
		///		Directorio base
		/// </summary>
		public string BasePath 
		{ get { return strBasePath; }
			set { strBasePath = value;  }
		}
		
		public string Mask
		{ get { return strMask; }
			set { strMask = value; }
		}
		
		public bool ShowFiles
		{ get { return blnShowFiles; }
			set { blnShowFiles = value; }
		}
		
		public bool CanEditNames
		{ get { return trvFiles.LabelEdit;}
			set { trvFiles.LabelEdit = value; }
		}

		/// <summary>
		///		Directorio / archivo seleccionado
		/// </summary>		
		public string Path
		{ get 
				{	clsFile objFile = GetSelectedFile();
				
						if (objFile != null)
							return objFile.FullName;
						else
							return null; 
				}
			set 
				{ 
					//if (value != Path)
					//  SelectPath(value); 
				}
		}
	}
}
