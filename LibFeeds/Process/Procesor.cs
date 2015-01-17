using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.Atom.Transforms;
using Bau.Libraries.LibFeeds.Syndication.RDF.Data;
using Bau.Libraries.LibFeeds.Syndication.RDF.Transforms;
using Bau.Libraries.LibFeeds.Syndication.RSS.Data;
using Bau.Libraries.LibFeeds.Syndication.RSS.Transforms;

namespace Bau.Libraries.LibFeeds.Process
{
	/// <summary>
	///		Procesador para descarga de archivos RSS
	/// </summary>
	public static class Procesor
	{
		/// <summary>
		///		Obtiene un canal Atom a partir de los datos de un archivo, si es un archivo RSS o RDF lo convierte a Atom
		/// </summary>
		public static AtomChannel Download(string strURL)
		{ AtomChannel objChannel = null;

				// Descarga el archivo
					try
						{ string strFileName = System.IO.Path.GetTempFileName();
					
								// Decarga el archivo
									WebDownload.Download(strURL, strFileName);
								// Carga los datos
									if (System.IO.File.Exists(strFileName))
										objChannel = Load(strFileName);
								// Elimina el archivo
									System.IO.File.Delete(strFileName);
						}
					catch {}
				// Si ha llegado hasta aquí es porque desconoce el tipo de archivo
					return objChannel;
		}		

		/// <summary>
		///		Carga los datos de un archivo Atom
		/// </summary>
		public static AtomChannel Load(string strFileName)
		{ AtomChannel objChannel = ParseRSS(strFileName);

				// Si no se ha cargado desde un archivo RSS, se carga desde un archivo RDF
					if (objChannel == null)
						objChannel = ParseRDF(strFileName);					
				// Si no se ha cargado desde un archivo RSS, se carga desde un archivo Atom
					if (objChannel == null)
						objChannel = AtomParser.Parse(strFileName);
				// Devuelve los datos
					return objChannel;
		}
		
		/// <summary>
		///		Interpreta un archivo RSS
		/// </summary>
		private static AtomChannel ParseRSS(string strFileName)
		{ // Carga el archivo RSS
				try
					{	RSSChannel objRSS = RSSParser.Parse(strFileName);
					
							if (objRSS != null)
								{ // Obtiene el contenido codificado
										ConvertEntriesRSS(objRSS);
									// Convierte el archivo RSS en un archivo Atom
										return RSSToAtom.Convert(objRSS);
								}
					}
				catch (Exception objException) 
					{ System.Diagnostics.Debug.WriteLine(objException.Message);
					}
			// Si ha llegado hasta aquí es porque no ha podido leerlo
				return null;
		}

		/// <summary>
		///		Convierte las entradas RSS
		/// </summary>
		private static void ConvertEntriesRSS(RSSChannel objRSS)
		{	foreach (RSSEntry objEntry in objRSS.Entries)
				foreach (Syndication.FeedExtensions.ExtensionBase objExtension in objEntry.Extensions)
					if (objExtension is Syndication.FeedExtensions.RSSContent.Data.RSSContentData)
						{ Syndication.FeedExtensions.RSSContent.Data.RSSContentData objContent = objExtension as Syndication.FeedExtensions.RSSContent.Data.RSSContentData;
						
								if (objContent != null)
									objEntry.Content = objContent.ContentEncoded;
						}
		}

		/// <summary>
		///		Interpreta un archivo RDF
		/// </summary>
		private static AtomChannel ParseRDF(string strFileName)
		{ // Carga el archivo RDF
				try
					{	RDFChannel objRDF = RDFParser.Parse(strFileName);
					
							if (objRDF != null)
								return RDFToAtom.Convert(objRDF);
					}
				catch {}
			// Si ha llegado hasta aquí es porque no ha podido leerlo
				return null;
		}
	}
}
