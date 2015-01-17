using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Bau.Controls.Files
{
	/// <summary>
	///		Control de explorador de archivos
	/// </summary>
	public partial class FilesExplorer : UserControl
	{ // Eventos
			public event ListFiles.PathChangedHandler PathChanged;
			public event ListFiles.FileDoubleClickHandler FileDoubleClick;
			public event ListFiles.FileSelectedHandler FileSelected;
		// Variables privadas
			private System.Collections.Generic.List<string> arrStrPaths = new System.Collections.Generic.List<string>();
			private FilesInfo.clsFile objSelectedFile = null;
			
		public FilesExplorer()
		{	InitializeComponent();
		}
		
		/// <summary>
		///		Añade un directorio a la cola
		/// </summary>
		private void AddQueuePath(string strPath)
		{ if (!string.IsNullOrEmpty(strPath) && 
							(arrStrPaths.Count == 0 || 
							 !arrStrPaths[arrStrPaths.Count - 1].Equals(strPath, StringComparison.CurrentCultureIgnoreCase)))
				{	// Añade el directorio a la cola
						arrStrPaths.Add(strPath);
					// Si tiene más de diez directorios, elimina el primero
						if (arrStrPaths.Count > 10)
							arrStrPaths.RemoveAt(0);
				}
			// Habilita / inhabilita los controles
				EnableControls();
		}
		
		/// <summary>
		///		Obtiene el último directorio de la cola
		/// </summary>
		private string GetQueuePath()
		{ string strPath = null;
		
				// Obtiene el último directorio
					if (arrStrPaths.Count > 0)
						{ // Obtiene el último directorio
								strPath = arrStrPaths[arrStrPaths.Count - 1];
							// Elimina el último directorio
								arrStrPaths.RemoveAt(arrStrPaths.Count - 1);
							// Habilita / inhabilita los controles
								EnableControls();
						}
				// Devuelve el último directorio
					return strPath;
		}

		/// <summary>
		///		Pasa a la lista de copia los archivos seleccionados
		/// </summary>
		private void GetBufferFiles(FilesManager.ActionCopy intNewAction)
		{ // Limpia el buffer de archivos a copiar
				FilesManager.Clear();
			// Rellena la lista de archivos a copiar
				foreach (FilesInfo.clsFile objFile in lswFiles.SelectedFiles)
					FilesManager.Add(objFile);
			// Indica la acción
				FilesManager.Action = intNewAction;	
		}
		
		/// <summary>
		///		Comienza el proceso de copiar archivos
		/// </summary>
		public void Copy()
		{ GetBufferFiles(FilesManager.ActionCopy.Copy);
		}

		/// <summary>
		///		Comienza el proceso de cortar archivos
		/// </summary>
		public void Cut()
		{ GetBufferFiles(FilesManager.ActionCopy.Cut);
		}
		
		/// <summary>
		///		Pega los archivos
		/// </summary>
		public void Paste()
		{ if (FilesManager.Action != FilesManager.ActionCopy.Unknown)
				{	// Copia / mueve los archivos
						FilesManager.Paste(Path);
					// Recarga los archivos
						lswFiles.Refresh();
				}
		}
		
		/// <summary>
		///		Cambia el nombre del archivo
		/// </summary>
		public void Rename()
		{	throw new Exception("No implementado");
		}

		/// <summary>
		///		Borra el archivo seleccionado
		/// </summary>
		public void KillFile()
		{ if (SelectedFile != null)
				{ // Elimina el archivo o directorio
						FilesManager.Kill(SelectedFile.FullName);
					// Actualiza
						trvPath.Refresh();
						lswFiles.Refresh();
				}
		}
		
		/// <summary>
		///		Habilita / inhabilita los controles
		/// </summary>
		private void EnableControls()
		{	cmdBack.Enabled = arrStrPaths.Count > 0;
		}
		
		public string Mask
		{ get { return lswFiles.Mask; }
			set 
				{ lswFiles.Mask = value;
					trvPath.Mask = value;
				}
		}

		public string Path
		{ get { return lswFiles.Path; }
			set
				{ // Asigna el directorio al árbol (no lo hace en el siguiente if porque puede que venga del evento del árbol)
						if (trvPath.Path != value)
							trvPath.Path = value;
					// Asigna el directorio a la lista (no lo hace en el if anterior porque puede que venga del evento de la lista)
						if (lswFiles.Path != value)
							{ // Añade el directorio a la lista
									AddQueuePath(value);
								// Asigna el directorio a la lista
									lswFiles.Path = value;
							}
				}
		}
		
		public View View
		{ get { return lswFiles.View; }
			set { lswFiles.View = value; }
		}

		public FilesInfo.clsFile SelectedFile		
		{ get { return objSelectedFile; }
			private set { objSelectedFile = value; }
		}

		/// <summary>
		///		Indica si debe mostrar o no los archivos en el árbol
		/// </summary>
		[Description("Indica si debe mostrar o no los archivos en el árbol"), DefaultValue(false)]
		public bool ShowFiles
		{ get { return trvPath.ShowFiles; }
			set { trvPath.ShowFiles = value; }
		}		
		
		private void trvPath_PathChanged(object objSender, Bau.Controls.Files.Events.clsFileEventArgs objFileEvent)
		{ // Cambia el archivo seleccionado y el directorio
				SelectedFile = objFileEvent.File;
				Path = objFileEvent.File.FullName;
			// Lanza el evento de cambio de directorio
				if (PathChanged != null)
					PathChanged(this, objFileEvent);
		}

		private void lswFiles_FileDoubleClick(object objSender, Bau.Controls.Files.Events.clsFileEventArgs objFileEvent)
		{ if (FileDoubleClick != null)
				FileDoubleClick(this, objFileEvent);
		}

		private void lswFiles_FileSelected(object objSender, Bau.Controls.Files.Events.clsFileEventArgs objFileEvent)
		{ // Cambia el archivo seleccionado
				SelectedFile = objFileEvent.File;
			// Lanza el evento de selección de archivo
				if (FileSelected != null)
					FileSelected(this, objFileEvent);
		}

		private void mnuViewDetails_Click(object sender, EventArgs e)
		{ lswFiles.View = View.Details;
		}

		private void mnuViewList_Click(object sender, EventArgs e)
		{ lswFiles.View = View.List;
		}

		private void mnuViewIcons_Click(object sender, EventArgs e)
		{ lswFiles.View = View.SmallIcon;
		}

		private void cmdParentPath_Click(object sender, EventArgs e)
		{ if (!string.IsNullOrEmpty(lswFiles.Path))
				Path = System.IO.Path.GetDirectoryName(lswFiles.Path);
		}

		private void cmdBack_Click(object sender, EventArgs e)
		{ string strPath = GetQueuePath();
		
				if (!string.IsNullOrEmpty(strPath))
					Path = strPath;
		}
	}
}
