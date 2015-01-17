using System;

using Bau.Controls.Files.FilesInfo;

namespace Bau.Controls.Files.Events
{
	/// <summary>
	/// 	Evento originado al realizar una acción sobre un archivo
	/// </summary>
	public class clsFileEventArgs : EventArgs
	{	// Variables privadas
			private clsFile objFile;

		public clsFileEventArgs() {}
		
		public clsFileEventArgs(clsFile objFile)
		{ this.objFile = objFile;
		}
			
		public clsFile File
		{ get { return objFile; }
			set { objFile = value; }
		}
	}
}
