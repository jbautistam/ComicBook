using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using Bau.Controls.Files.Events;
using Bau.Controls.Files.FilesInfo;

namespace Bau.Controls.Files
{
	/// <summary>
	/// 	Control que muestra una lista de archivos de un directorio
	/// </summary>
	public partial class ListFiles
	{ // Delegados
			public delegate void PathChangedHandler(object objSender, clsFileEventArgs objFileEvent);
			public delegate void FileDoubleClickHandler(object objSender, clsFileEventArgs objFileEvent);
			public delegate void FileSelectedHandler(object objSender, clsFileEventArgs objFileEvent);
		// Eventos
			public event PathChangedHandler PathChanged;
			public event FileDoubleClickHandler FileDoubleClick;
			public event FileSelectedHandler FileSelected;
		// Variables privadas
			private string strPath, strMask;
			private colFiles objColFiles = new colFiles();
		
		public ListFiles()
		{	// The InitializeComponent() call is required for Windows Forms designer support.
				InitializeComponent();
			// Inicializa las variables
				strPath = "C:\\";
				strMask = "*.*";
			// Inicializa los objetos
				LoadFiles();
			// Vista en modo detalle
				View = View.Details;
		}

		/// <summary>
		/// 	Carga la colección de archivos
		/// </summary>
		private void LoadFiles()
		{	objColFiles.Clear();
			objColFiles.Load(Path, Mask);
		}
		
		/// <summary>
		/// 	Refresca el control
		/// </summary>
		public override void Refresh()
		{ ListViewItem lviItem;
			int intIndexIcon;

				// Comienza la modificación de la lista
					lswFiles.BeginUpdate();
				// Añade la lista de imágenes
					lswFiles.SmallImageList = imlIcons;
					lswFiles.LargeImageList = imlIcons;
				// Limpia la lista
					lswFiles.Clear();
				// Añade las cabeceras
					lswFiles.AddColumn(200, "Nombre");
					lswFiles.AddColumn(100, "Tipo");
					lswFiles.AddColumn(100, "Tamaño", Bau.Controls.Files.List.ListViewExtended.ListViewColumnType.Number);
					lswFiles.AddColumn(100, "F. Creación", Bau.Controls.Files.List.ListViewExtended.ListViewColumnType.Date);
					lswFiles.AddColumn(100, "F. Modificación", Bau.Controls.Files.List.ListViewExtended.ListViewColumnType.Date);
				// Recorre la colección de archivos añadiéndolo al listView y los iconos a la lista
					LoadFiles();
					foreach (clsFile objFile in objColFiles)
						{ // Añade el archivo a la lista
								lviItem =	lswFiles.Items.Add(objFile.Name);
								lviItem.SubItems.Add(objFile.Type);
								if (!objFile.IsDirectory)
									lviItem.SubItems.Add(objFile.Size.ToString());
								else
									lviItem.SubItems.Add("");
								lviItem.SubItems.Add(objFile.DateCreated.ToShortDateString());
								lviItem.SubItems.Add(objFile.DateModified.ToShortDateString());
								lviItem.Tag = objFile;
							// Añade el icono a la lista de imágenes
								if (!objFile.IsDirectory)
									{ // Si realmente tenemos algún icono
											if (objFile.Icon != null)
												{	// Obtiene el índice del icono
														if ((intIndexIcon = imlIcons.Images.IndexOfKey(objFile.HandleIcon.ToString())) == -1)
													    { // Añade el icono
													    		imlIcons.Images.Add(objFile.HandleIcon.ToString(), objFile.Icon);
													    	// Obtiene el índice
													    		intIndexIcon = imlIcons.Images.IndexOfKey(objFile.HandleIcon.ToString());
													    }
													// Asigna el índice del icono al elemento de la lista
														if (intIndexIcon >= 0)
													   	lviItem.ImageIndex = intIndexIcon;
												}
									}
								else
									lviItem.ImageIndex = 0;
						}
					lswFiles.View = View.Details;
				// Finaliza la modificación de la vista
					lswFiles.EndUpdate();
				// Llama a la base
					base.Refresh();
		}
		
		/// <summary>
		/// 	Maneja el evento de doble click sobre la lista
		/// </summary>
		private void TreatEventDoubleClick(ListViewItem lviItem)
		{ clsFileEventArgs objEvent = new clsFileEventArgs();
			
				if (lviItem != null)
					{	// Asigna el archivo al evento
							objEvent.File = (clsFile) lviItem.Tag;
						// Si es un directorio, cambia el directorio seleccionado, si no, manda el evento de doble click
							if (objEvent.File.IsDirectory)
								{ // Cambia el directorio actual refrescando la vista
										Path = objEvent.File.FullName;
									// Lanza el evento de cambio de directorio
										if (PathChanged != null)
											PathChanged(this, objEvent);
								}
							else if (FileDoubleClick != null) // ... lanza el evento
									FileDoubleClick(this, objEvent);
					}
		}
		
		/// <summary>
		///		Trata el evento de archivo seleccionado
		/// </summary>
		private void TreatEventFileSelected(ListViewItem lsiItem)
		{ if (lsiItem != null && lsiItem.Tag is clsFile && FileSelected != null)
				FileSelected(this, new clsFileEventArgs(lsiItem.Tag as clsFile));
		}
		
		public string Path
		{ get { return strPath; }
			set
				{ // Asigna el valor
						strPath = value;
					// Carga los archivos
						LoadFiles();
					// Refresca el control
						Refresh();
				}
		}
		
		public string Mask
		{ get { return strMask; }
			set { strMask = value; }
		}
		
		public View View
		{ get { return lswFiles.View; }
			set { lswFiles.View = View; }
		}

		public FilesInfo.clsFile SelectedFile		
		{ get 
				{ // Devuelve el archivo seleccionado
						if (lswFiles.SelectedItems.Count > 0 && (lswFiles.SelectedItems[0].Tag is clsFile))
							return lswFiles.SelectedItems[0].Tag as clsFile; 
					// Si ha llegado hasta aquí es porque no había nada seleccionado
						return null;
				}
		}
		
		public FilesInfo.colFiles SelectedFiles
		{ get
				{ FilesInfo.colFiles objColFiles = new colFiles();
				
					// Copia en la colección los archivos seleccionados
						foreach (ListViewItem lsiItem in lswFiles.SelectedItems)
							if (lsiItem.Tag is clsFile)
								objColFiles.Add(lsiItem.Tag as clsFile);
					// Devuelve la colección
						return objColFiles;
				}
		}
		
		private void lswFiles_ItemDoubleClick(object objSender, ListViewItem lsiItem)
		{ TreatEventDoubleClick(lsiItem);
		}

		private void lswFiles_SelectedIndexChanged(object sender, EventArgs e)
		{ if (lswFiles.SelectedItems.Count > 0)
				TreatEventFileSelected(lswFiles.SelectedItems[0]);
		}
	}
}
