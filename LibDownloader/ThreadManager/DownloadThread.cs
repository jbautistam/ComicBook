using System;
using System.Threading;

namespace Bau.Libraries.LibDownloader.ThreadManager
{
	/// <summary>
	///		Hilo de descarga
	/// </summary>
	internal class DownloadThread : IDisposable
	{ // Variables privadas
			private Thread thrDownload = null;
			
		internal DownloadThread(DownloadManager objManager)
		{ Manager = objManager;
		}
		
		/// <summary>
		///		Comienza las descargas
		/// </summary>
		internal void Start()
		{ // Crea el hilo
				if (thrDownload == null || thrDownload.ThreadState == ThreadState.Stopped)
					thrDownload = new Thread(new ThreadStart(DownloadFeedThread));
			// Arranca el hilo
				if (!thrDownload.IsAlive)
					thrDownload.Start();
		}
		
		/// <summary>
		///		Hilo de descarga
		/// </summary>
		private void DownloadFeedThread()
		{ while (Manager.TasksCollection.Count != 0)
				{ // Lanza el evento de comienzo de descarga
						Manager.RaiseProgressDownload(new Events.DownloadEventArgs(Events.DownloadEventArgs.EventType.Start,
																																			 Manager.TasksCollection[0], 
																																			 "Inicio de la descarga de " + Manager.TasksCollection[0].LocalFileName));
					// Descarga la primera entrada
						Download(Manager.TasksCollection[0]);
						Thread.Sleep(1000);
					// Lanza el evento de finalización de descarga
						Manager.RaiseProgressDownload(new Events.DownloadEventArgs(Events.DownloadEventArgs.EventType.End,
																																			 Manager.TasksCollection[0], 
																																			 "Fin de la descarga de " + Manager.TasksCollection[0].LocalFileName));
					// Elimina la entrada de la colección
						if (Manager.TasksCollection.Count > 0)
							Manager.TasksCollection.RemoveAt(0);
				}
			// Lanza el evento de fin de descarga
				Manager.RaiseProgressDownload(new Events.DownloadEventArgs(Events.DownloadEventArgs.EventType.EndAllDownload,
																																	 null, "Fin de la descarga"));
		}

		/// <summary>
		///		Realiza la descarga de una tarea
		/// </summary>
		private void Download(Tasks.BaseDownloadTask objTask)
		{ try
				{ Downloader.DownloaderFactory.Download(Manager, objTask);
				}
			catch (Exception objException)
				{ Manager.RaiseProgressDownload(new Events.DownloadEventArgs(Events.DownloadEventArgs.EventType.Error,
																																		 objTask, "Error en la descarga\n" + objException.Message));
				}
		}
		
		/// <summary>
		///		Detiene el hilo de descarga
		/// </summary>
		public void Stop()
		{ // Si el hilo de descarga está activo lo detiene
				if (thrDownload != null && thrDownload.IsAlive)
					{ // Detiene el hilo
							thrDownload.Abort();
						// Espera hasta que el hilo termina del todo
							thrDownload.Join(3000);
						// Limpia la memoria
							thrDownload = null;
					}
		}

		/// <summary>
		///		Manager de la descarga
		/// </summary>
		internal DownloadManager Manager { get; private set; }
		
		/// <summary>
		///		Indica si se está ejecutando el hilo de descarga
		/// </summary>
		public bool IsRunning 
		{ get { return thrDownload != null && thrDownload.IsAlive; }
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
		{	if (blnDispose && thrDownload != null) 
				{	// Detiene el hilo
						Stop();
					// Libera la memoria
						thrDownload = null;
				}
		}

		/// <summary>
		///		Destructor
		/// </summary>
	  ~DownloadThread() 
	  {	Dispose(false);
		}
	}
}
