using System;
using System.Net;

namespace Bau.Libraries.LibFeeds.Process
{
	/// <summary>
	///		Clase para descarga de archivos
	/// </summary>
	internal static class WebDownload
	{
		/// <summary>
		///		Descarga un archivo
		/// </summary>
		internal static void Download(string strURL, string strFileName)
		{ Download(strURL, strFileName, null, 0, null, null);
		}
		
		/// <summary>
		///		Descarga los datos
		/// </summary>
		internal static void Download(string strURL, string strFileName, string strProxyName, int intProxyPort, 
																	string strUser, string strPassword)
		{	using (WebResponse objWebResponse = GetWebRequest(strURL, strProxyName, intProxyPort, strUser, strPassword).GetResponse())
				{ // Abre un stream de lectura sobre la respuesta HTPP
						using (System.IO.Stream stmResponse = objWebResponse.GetResponseStream())
							{	// Escribe la respuesta HTPP en un archivo
									using (System.IO.FileStream stmFile = new System.IO.FileStream(strFileName, 
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
													stmFile.Flush();
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
		private static WebRequest GetWebRequest(string strURL, string strProxyName, int intProxyPort, string strUser, string strPassword)
		{ WebRequest objWebRequest = HttpWebRequest.Create(strURL);
			
				// Asigna las credenciales si es necesario
					if (!string.IsNullOrEmpty(strUser))
						objWebRequest.Credentials = new NetworkCredential(strUser, strPassword);
				// Asigna el proxy si es necesario
					if (!string.IsNullOrEmpty(strProxyName))
						{ objWebRequest.Proxy = new WebProxy(strProxyName, intProxyPort);
						
								if (!string.IsNullOrEmpty(strUser))
									objWebRequest.Proxy.Credentials = new NetworkCredential(strUser, strPassword);
						}
					//else
					//  objWebRequest.Proxy = WebProxy.GetDefaultProxy();
				// Devuelve el WebRequest configurado
					return objWebRequest;
		}
	}
}
