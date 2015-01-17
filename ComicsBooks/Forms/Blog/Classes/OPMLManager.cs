using System;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibDownloader;
using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.Atom.Transforms;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;
using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Transforms;
using Bau.Libraries.LibFeeds.Syndication.OPML.Data;
using Bau.Libraries.LibFeeds.Syndication.OPML.Transforms;
using Bau.Libraries.LibFeeds.Syndication.FeedExtensions.Desktop.Transforms;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Manager de los archivos OPML
	/// </summary>
	public class OPMLManager : IDisposable
	{ // Delegados públicos
			public delegate void UpdatedEntryHandler(OPMLManager objManager, DesktopFilesEntry objEntry);
		// Eventos públicos
			public event UpdatedEntryHandler UpdatedEntry;
			public event EventHandler UpdatedChannel;
		// Variables privadas
			private DownloadManager objDownloadManager = new DownloadManager();
			private System.Threading.Timer tmrTimer;
			private DateTime dtmLastDownload;
	
		public OPMLManager()
		{ // Inicializa el canal
				Channel = null;
			// Inicializa la variable con la hora de última descarga
				dtmLastDownload = DateTime.MinValue;
			// Configura el administrador de descarga
				InitDownloadManager();
		}
	
		/// <summary>
		///		Configura el administrador de descarga
		/// </summary>
		public void InitDownloadManager()
		{ // Crea el objeto de proxy
				objDownloadManager.DefaultProxy = new Bau.Libraries.LibDownloader.Proxy.ProxyParameters();
			// Le pasa los valores
				objDownloadManager.DefaultProxy.Enabled = clsConfiguration.UseProxy;
				objDownloadManager.DefaultProxy.Name = clsConfiguration.ProxyIP;
				objDownloadManager.DefaultProxy.Port = clsConfiguration.ProxyPort;
				objDownloadManager.DefaultProxy.User = clsConfiguration.ProxyUser;
				objDownloadManager.DefaultProxy.Password = clsConfiguration.ProxyPassword;
			// Inicializa los manejadores de eventos
				objDownloadManager.ProgressDownload += new DownloadManager.ProgressDownloadHandler(objDownloadManager_ProgressDownload);
		}
		
		/// <summary>
		///		Carga el árbol con los blogs del archivo
		/// </summary>
		public void Load(string strFileName)
		{	// Guarda el nombre de archivo
				FileName = strFileName;
			// Carga la lista de blogs
				try
					{	Channel = DesktopFilesParser.Parse(strFileName);		
					}
				catch (Exception objException)
					{ Program.Log("Error al cargar el archivo OPML\n" + objException.Message);
					}
			// Si no se ha cargado nada, se crea un nuevo canal
				if (Channel == null)
					Channel = new DesktopFilesChannel();
			// Inicializa el temporizador de descarga
				InitTimer();
		}
		
		/// <summary>
		///		Inicializa el temporizador
		/// </summary>
		private void InitTimer()
		{	// Detiene el temporizador anterior
				StopTimer();
			// Crea un nuevo temporizador
				tmrTimer = new System.Threading.Timer(tmrTimer_Tick, null, 30000, 60000);
		}
		
		/// <summary>
		///		Detiene el temporizador 
		/// </summary>
		private void StopTimer()
		{	if (tmrTimer != null)
				tmrTimer.Dispose();
			tmrTimer = null;
		}
			
		/// <summary>
		///		Carga un archivo OPML
		/// </summary>
		public bool Import(string strFileName)
		{ OPMLChannel objOpmlChannel = OPMLParser.Parse(strFileName);
		
				if (objOpmlChannel != null)
					{	DesktopFilesChannel objDesktopChannel = OPMLToDesktopFiles.Convert(objOpmlChannel);
						
							// Añade las entradas del archivo OPML
								Channel.Entries.Add(objDesktopChannel.Entries);
							// Graba el archivo
								Save();
							// Indica que se debe actualizar
								RaiseEventUpdatedChannel();
							// Indica que se ha importado correctamente
								return true;
					}
				else
					return false;
		}

		/// <summary>
		///		Añade las entradas OPML a las categorías
		/// </summary>
		private void AddOpmlEntries(DesktopFilesEntry objParent, OPMLEntriesCollection objColOpmlEntries)
		{ foreach (OPMLEntry objOpmlEntry in objColOpmlEntries)
				{	DesktopFilesEntry objEntry = new DesktopFilesEntry();
				
						// Asigna las propiedades
							objEntry.Text = objOpmlEntry.Title;
							if (string.IsNullOrEmpty(objEntry.Text))
								objEntry.Text = objOpmlEntry.Text;
							objEntry.URL = objOpmlEntry.URL;
							objEntry.NumberNotRead = 0;
						// Añade la entrada
							if (objParent == null)
								Channel.Entries.Add(objEntry);
							else
								objParent.Entries.Add(objEntry);
						// Añade las entradas OPML hijas
							AddOpmlEntries(objEntry, objOpmlEntry.Entries);
					}
		}
		
		/// <summary>
		///		Graba el archivo OPML
		/// </summary>
		public void Save()
		{ DesktopFilesWriter.Save(Channel, FileName);
		}
		
		/// <summary>
		///		Carga los datos en el manager de descargas
		/// </summary>
		private void LoadDownloadManager()
		{ // Limpia el manager de descargas
				objDownloadManager.TasksCollection.Clear();
			// Añade las tareas de descarga con las URLs de los blogs
				LoadDownloadManager(Channel.Entries);
			// Añade la tarea al log
				Program.Log("Comienza la descarga de blogs ...");
			// Inicializa el gestor de descargas
				objDownloadManager.Start();
		}
		
		/// <summary>
		///		Carga el manager de descargas con las URLs de los archivos a descargar
		/// </summary>
		private void LoadDownloadManager(DesktopFilesEntriesCollection objColEntries)
		{ // Añade las tareas con las URLs
				foreach (DesktopFilesEntry objEntry in objColEntries)
					{ // Añade la tarea de descarga
							if (!string.IsNullOrEmpty(objEntry.URL) && objEntry.Enabled)
								Download(objEntry);
						// Añade sus descargas hija
							LoadDownloadManager(objEntry.Entries);
					}
		}

		/// <summary>
		///		Descarga una entrada
		/// </summary>
		private void Download(DesktopFilesEntry objEntry)
		{	if (!string.IsNullOrEmpty(objEntry.URL) && objEntry.Enabled)
				objDownloadManager.AddHTTPTask(objEntry.ID, objEntry.URL, 
																			 FeedMerger.GetBlogFileName(objEntry.LocalFileNameDownload),
																			 objEntry.User, objEntry.Password);
		}

		/// <summary>
		///		Descarga una entrada
		/// </summary>
		public void StartDownload(DesktopFilesEntry objEntry)
		{	// Añade la entrada de descarga
				Download(objEntry);
			// Inicializa el gestor de descargas
				objDownloadManager.Start();
		}
		
		/// <summary>
		///		Manejador del evento que lanza el Manager de descarga cuando comienza / termina de descargar un archivo 
		///	(o todos los archivos)
		/// </summary>
		private void objDownloadManager_ProgressDownload(DownloadManager objDownloader, 
																										 Bau.Libraries.LibDownloader.Events.DownloadEventArgs objEventArgs)
		{ switch (objEventArgs.TypeEvent)
				{ case Bau.Libraries.LibDownloader.Events.DownloadEventArgs.EventType.Start:
							// Log
								Program.Log(objEventArgs.Message);
							// Muestra el estado
								Program.MainWindow.ShowPanelStatus(objEventArgs.Message);
						break;
					case Bau.Libraries.LibDownloader.Events.DownloadEventArgs.EventType.End:
							// Interpreta el archivo y lo mezcla con el anterior
								TreatDownload(objEventArgs.Task.ID);
							// Log
								Program.Log(objEventArgs.Message);
							// Indica que ha terminado
								Program.MainWindow.ShowPanelStatus(objEventArgs.Message);
						break;
					case Bau.Libraries.LibDownloader.Events.DownloadEventArgs.EventType.EndAllDownload:
							// Log
								Program.Log("Se han finalizado todas las descargas de blogs");
							// Lanza el evento de modificación de canal para que se recargue el árbol
								RaiseEventUpdatedChannel();
							// Limpia la etiqueta de estado
								Program.MainWindow.ShowPanelStatus(null);
							// Inicia de nuevo el temporizador
								InitTimer();
						break;
					case Bau.Libraries.LibDownloader.Events.DownloadEventArgs.EventType.Error:
							Program.Log(objEventArgs.Message);
						break;
				}
		}

		/// <summary>
		///		Trata el archivo descargado
		/// </summary>
		private void TreatDownload(string strID)
		{ DesktopFilesEntry objEntry = Channel.Entries.Search(strID);
		
				if (objEntry != null)
					{ AtomChannel objChannel = FeedMerger.Merge(FeedMerger.GetBlogFileName(objEntry.LocalFileName), 
																											FeedMerger.GetBlogFileName(objEntry.LocalFileNameDownload),
																											FeedMerger.GetBlogFileName(objEntry.LocalFileNameDeleted));
																																															 
							// Si se ha obtenido datos, los graba y avisa de la modificación
								if (objChannel != null)
									{ // Graba el archivo
											AtomWriter.Save(objChannel, FeedMerger.GetBlogFileName(objEntry.LocalFileName));
										// Cuenta los no leídos
											objEntry.NumberNotRead = FeedDesktopHelper.CountNotRead(objChannel);
											objEntry.DateLastUpdated = FeedDesktopHelper.GetLastUpdated(objChannel);
										// Avisa de la modificación
										//	RaiseEventUpdated(objEntry);
									}
							// Borra el archivo descargado
								Libraries.LibHelper.Files.HelperFiles.KillFile(FeedMerger.GetBlogFileName(objEntry.LocalFileNameDownload));
					}
		}

		/// <summary>
		///		Modifica el número de elementos no leídos
		/// </summary>
		internal void UpdateNumberNotRead(DesktopFilesEntry objEntryUpdated, int intNumberNotRead)
		{ DesktopFilesEntry objEntry = Channel.Entries.Search(objEntryUpdated.ID);
		
				// Si se ha modificado el número de entradas
					if (objEntry != null && objEntry.NumberNotRead != intNumberNotRead)
						{ // Ajusta el número de elementos leídos
								objEntry.NumberNotRead = intNumberNotRead;
							// Graba el archivo
								Save();
							// Avisa de la modificación
								RaiseEventUpdated(objEntry);
						}
		}

		/// <summary>
		///		Avisa de la modificación de una entrada
		/// </summary>
		private void RaiseEventUpdated(DesktopFilesEntry objEntry)
		{ if (UpdatedEntry != null)
				UpdatedEntry(this, objEntry);
		}

		/// <summary>
		///		Avisa de la modificación del canal
		/// </summary>
		private void RaiseEventUpdatedChannel()
		{ if (UpdatedChannel != null)
				UpdatedChannel(this, EventArgs.Empty);
		}

		/// <summary>
		///		Manejador de eventos del temporizador
		/// </summary>
		private void tmrTimer_Tick(object objStateInfo)
		{ if (!objDownloadManager.IsRunning && clsConfiguration.DownloadBlogsAuto &&
					(dtmLastDownload == DateTime.MinValue ||
					 (DateTime.Now - dtmLastDownload).TotalMinutes > clsConfiguration.DownloadInterval))
				{	// Detiene el temporizador
						StopTimer();
					// Inicializa el manager de descargas
						LoadDownloadManager();
					// Guarda la hora de última descarga
						dtmLastDownload = DateTime.Now;
				}
			else
				InitTimer();
		}
		
		/// <summary>
		///		Nombre de archivo
		/// </summary>
		public string FileName { get; private set; }
		
		/// <summary>
		///		Archivo OPML
		/// </summary>
		public DesktopFilesChannel Channel { get; private set; }

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
		{	if (blnDispose && objDownloadManager != null) 
				{	// Detiene el hilo
						objDownloadManager.Stop();
					// Detiene el temporizador
						if (tmrTimer != null)
							tmrTimer.Dispose();
					// Quita el manejador de eventos
						objDownloadManager.ProgressDownload -= objDownloadManager_ProgressDownload;
					// Libera la memoria
						objDownloadManager = null;
				}
		}

	  ~OPMLManager() 
	  {	Dispose(false);
		}
	}
}
