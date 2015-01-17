using System;

namespace Bau.Libraries.LibDownloader.Downloader
{
	/// <summary>
	///		Factory para los objetos de descarga
	/// </summary>
	internal static class DownloaderFactory
	{
		/// <summary>
		///		Obtiene una instancia del objeto que realiza la descarga
		/// </summary>
		internal static IDownloader GetInstance(DownloadManager objManager, Tasks.BaseDownloadTask objTask)
		{ // Busca si la tarea es de algún tipo definido
				if (objTask is Tasks.HTTPDownloadTask)
					return new HTTPDownloader(objManager);
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				throw new NotImplementedException("No se reconoce la tarea");
		}
		
		/// <summary>
		///		Descarga un archivo
		/// </summary>
		internal static void Download(DownloadManager objManager, Bau.Libraries.LibDownloader.Tasks.BaseDownloadTask objTask)
		{ GetInstance(objManager, objTask).Download(objTask);
		}
	}
}
