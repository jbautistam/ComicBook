using System;

namespace Bau.Libraries.LibDownloader.Tasks
{
	/// <summary>
	///		Tarea de descarga HTTP
	/// </summary>
	public class HTTPDownloadTask : BaseDownloadTask
	{
		public HTTPDownloadTask(string strURL) : this(strURL, null, null) {}
		
		public HTTPDownloadTask(string strURL, string strUser, string strPassword)
		{ URL = strURL;
			User = strUser;
			Password = strPassword;
		}
		
		/// <summary>
		///		URL de la descarga
		/// </summary>
		public string URL { get; set; }
		
		/// <summary>
		///		Usuario con permisos para descarga
		/// </summary>
		public string User { get; set; }
		
		/// <summary>
		///		Contraseña para la descarga
		/// </summary>
		public string Password { get; set; }
	}
}
