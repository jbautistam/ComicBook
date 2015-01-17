using System;
using System.Net;

namespace Bau.Libraries.LibDownloader.Downloader
{
	/// <summary>
	///		Clase de descarga por HTTP
	/// </summary>
	public class HTTPDownloader : IDownloader
	{
		public HTTPDownloader(DownloadManager objManager)
		{ Manager = objManager;
		}

		/// <summary>
		///		Descarga los datos de un archivo
		/// </summary>
		public void Download(Tasks.BaseDownloadTask objTask)
		{ if (objTask is Tasks.HTTPDownloadTask)
		    Download(objTask as Tasks.HTTPDownloadTask);
		}

		/// <summary>
		///		Descarga los datos
		/// </summary>
		private void Download(Tasks.HTTPDownloadTask objTask)
		{	using (WebResponse objWebResponse = GetWebRequest(objTask).GetResponse())
				{ // Abre un stream de lectura sobre la respuesta HTPP
						using (System.IO.Stream stmResponse = objWebResponse.GetResponseStream())
							{	// Escribe la respuesta HTPP en un archivo
									using (System.IO.FileStream stmFile = new System.IO.FileStream(objTask.LocalFileName, 
																																								 System.IO.FileMode.Create, 
																																								 System.IO.FileAccess.Write))
										{	byte [] bytBuffer = new byte[2048]; // Buffer de 2KB
											int intSize;

												// Recorre el stream de entrada grabando en el de salida
													while((intSize = stmResponse.Read(bytBuffer, 0, bytBuffer.Length) ) > 0 )
														{ // Escribe el contenido descargado en un archivo
																stmFile.Write(bytBuffer, 0, intSize);
														}
												// Cierra el archivo de salida
													stmFile.Close();
										}
								// Cierra el stream de lectura
									stmResponse.Close();
							}
					// Cierra el stream HTTP
						objWebResponse.Close();
				}
		}

		/// <summary>
		///		Obtiene un WebRequest configurado para la tarea
		/// </summary>
		private WebRequest GetWebRequest(Tasks.HTTPDownloadTask objTask)
		{ WebRequest objWebRequest = HttpWebRequest.Create(objTask.URL);
			
				// Asigna las credenciales si es necesario
					if (!string.IsNullOrEmpty(objTask.User))
						objWebRequest.Credentials = new NetworkCredential(objTask.User, objTask.Password);
				// Asigna el proxy si es necesario
					if (Manager.DefaultProxy != null && Manager.DefaultProxy.Enabled)
						{ objWebRequest.Proxy = new WebProxy(Manager.DefaultProxy.Name, Manager.DefaultProxy.Port);
						
								if (!string.IsNullOrEmpty(Manager.DefaultProxy.User))
									objWebRequest.Proxy.Credentials = new NetworkCredential(Manager.DefaultProxy.User,
																																					Manager.DefaultProxy.Password);
						}
					//else
					//  objWebRequest.Proxy = WebProxy.GetDefaultProxy();
				// Devuelve el WebRequest configurado
					return objWebRequest;
		}
		
		/// <summary>
		///		Manager de la descarga
		/// </summary>
		public DownloadManager Manager { get; set; }
	}
}