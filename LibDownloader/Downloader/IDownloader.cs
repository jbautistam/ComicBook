using System;

namespace Bau.Libraries.LibDownloader.Downloader
{
	/// <summary>
	///		Interface de las clases de descarga
	/// </summary>
	public interface IDownloader
	{
		/// <summary>
		///		Método de descarga
		/// </summary>
		void Download(Tasks.BaseDownloadTask objTask);
	}
}
