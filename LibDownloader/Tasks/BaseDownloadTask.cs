using System;

namespace Bau.Libraries.LibDownloader.Tasks
{
	/// <summary>
	///		Base de las tareas de descarga
	/// </summary>
	public abstract class BaseDownloadTask
	{ // Variables privadas
			private string strID;
		
		public BaseDownloadTask()
		{ LastDownload = null;
		}	
		
		/// <summary>
		///		ID de la tarea
		/// </summary>
		public string ID 
		{ get 
				{ // Asigna el ID si no está definido
						if (string.IsNullOrEmpty(strID))
							strID = Guid.NewGuid().ToString();
					// Devuelve el ID
						return strID;
				}
			set { strID = value; }
		}
		
		/// <summary>
		///		Nombre del archivo local
		/// </summary>
		public string LocalFileName { get; set; }
		
		/// <summary>
		///		Fecha y hora de última descarga
		/// </summary>
		public DateTime? LastDownload { get; set; }
	}
}
