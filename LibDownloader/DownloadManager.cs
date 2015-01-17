using System;
using System.Threading;

namespace Bau.Libraries.LibDownloader
{
	/// <summary>
	///		Manager de la descarga
	/// </summary>
	public class DownloadManager : IDisposable
	{ // Delegados públicos
			public delegate void ProgressDownloadHandler(DownloadManager objDownloader,  Events.DownloadEventArgs objEventArgs);
		// Eventos públicos
			public event ProgressDownloadHandler ProgressDownload;
		// Variables privadas
			private ThreadManager.DownloadThread objThreadDownload = null;

		public DownloadManager()
		{ TasksCollection = new Tasks.BaseDownloadTasksCollection();
		}
		
		/// <summary>
		///		Añade una tarea HTPP
		/// </summary>
		public void AddHTTPTask(string strID, string strURL, string strLocalFileName, string strUser, string strPassword)
		{ Tasks.HTTPDownloadTask objTask = new Tasks.HTTPDownloadTask(strURL, strUser, strPassword);
				
				// Asigna las propiedades a la tarea
					objTask.ID = strID;
					objTask.LocalFileName = strLocalFileName;
				// Añade la tarea a la colección
					TasksCollection.Add(objTask);
		}

		/// <summary>
		///		Comienza las descargas
		/// </summary>
		public void Start()
		{ // Crea el hilo de descarga
				if (objThreadDownload == null)
					objThreadDownload = new ThreadManager.DownloadThread(this);
			// Arranca el hilo de descarga
				objThreadDownload.Start();
		}
		
		/// <summary>
		///		Detiene el hilo de descarga
		/// </summary>
		public void Stop()
		{ if (objThreadDownload != null)
				{ // Detiene el hilo de descarga
						objThreadDownload.Stop();
					// Limpia la memoria
						objThreadDownload = null;
				}
		}
		
		/// <summary>
		///		Lanza el evento de progreso en la descarga
		/// </summary>
		internal void RaiseProgressDownload(Events.DownloadEventArgs objEventArgs)
		{ // Lanza el evento de descarga
				if (ProgressDownload != null)
					ProgressDownload(this, objEventArgs);
			// Si el evento es de finalización, detiene el hilo
				if (objEventArgs.TypeEvent == Events.DownloadEventArgs.EventType.EndAllDownload)
					Stop();
		}
		
		/// <summary>
		///		Libera la memoria del objeto y cierra los hilos
		/// </summary>
		public void Dispose() 
		{	Dispose(true);
			GC.SuppressFinalize(this);
		}
	
		/// <summary>
		///		Libera la memoria del objeto y cierra los hilos
		/// </summary>
		private void Dispose(bool blnDispose) 
		{	if (blnDispose && objThreadDownload != null) 
				{	// Detiene el hilo
						objThreadDownload.Stop();
					// Libera la memoria
						objThreadDownload = null;
				}
		}

		/// <summary>
		///		Destructor
		/// </summary>
	  ~DownloadManager() 
	  {	Dispose(false);
		}
		
		/// <summary>
		///		Parámetros del proxy
		/// </summary>
		public Proxy.ProxyParameters DefaultProxy { get; set; }
		
		/// <summary>
		///		Tareas a descargar
		/// </summary>
		public Tasks.BaseDownloadTasksCollection TasksCollection { get; private set; }
		
		/// <summary>
		///		Indica si se está ejecutando el hilo de descarga
		/// </summary>
		public bool IsRunning 
		{ get { return objThreadDownload != null && objThreadDownload.IsRunning; }
		}
	}
}