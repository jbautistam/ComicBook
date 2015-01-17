using System;

namespace Bau.Libraries.LibDownloader.Events
{ 
	/// <summary>
	///		Argumento de los eventos de descarga
	/// </summary>
	[Serializable]
	public class DownloadEventArgs : EventArgs
	{ // Enumerados públicos
			public enum EventType
				{ Unknown,
					Start,
					Progress,
					End,
					EndAllDownload,
					Error
				}
				
		public DownloadEventArgs(EventType intEventType, Tasks.BaseDownloadTask objTask, string strMessage)
		{	TypeEvent = intEventType;
			Task = objTask;
			Message = strMessage;
		}
		
		/// <summary>
		///		Tipo del evento
		/// </summary>
		public EventType TypeEvent { get; private set; }
		
		/// <summary>
		///		Tarea
		/// </summary>
		public Tasks.BaseDownloadTask Task { get; private set; }
		
		/// <summary>
		///		Mensaje
		/// </summary>
		public string Message { get; private set; }
	}
}
