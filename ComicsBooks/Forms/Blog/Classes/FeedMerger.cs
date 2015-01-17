using System;

using Bau.Applications.ComicsBooks.Classes;
using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.Atom.Transforms;
using Bau.Libraries.LibFeeds.Syndication.RDF.Data;
using Bau.Libraries.LibFeeds.Syndication.RDF.Transforms;
using Bau.Libraries.LibFeeds.Syndication.RSS.Data;
using Bau.Libraries.LibFeeds.Syndication.RSS.Transforms;

namespace Bau.Applications.ComicsBooks.Forms.Blog.Classes
{
	/// <summary>
	///		Clase de ayuda para mezclar dos archivos de Feeds
	/// </summary>
	public static class FeedMerger
	{
		/// <summary>
		///		Obtiene el nombre de archivo completo de un blog
		/// </summary>
		public static string GetBlogFileName(string strFileName)
		{ return System.IO.Path.Combine(clsConfiguration.PathBaseBlogs, strFileName);
		}

		/// <summary>
		///		Mezcla dos archivos Atom dejando en el Atom final los mismos archivos que
		///	en el inicial junto con los más modernos del destino
		/// </summary>
		public static AtomChannel Merge(string strFileLocal, string strFileDownload,
																		string strFileDeleted)
		{ return Merge(GetAtom(strFileLocal), GetAtom(strFileDownload), LoadIDs(strFileDeleted));
		}
		
		/// <summary>
		///		Obtiene un canal Atom a partir de los datos de un archivo, si es un archivo RSS lo convierte a Atom
		/// </summary>
		public static AtomChannel GetAtom(string strFileName)
		{ // Obtiene el atom a partir del archivo
				try
					{ if (System.IO.File.Exists(strFileName))
							{	AtomChannel objChannel = ParseRSS(strFileName);

									// Si no se ha cargado desde un archivo RSS, se carga desde un archivo RDF
										if (objChannel == null)
											objChannel = ParseRDF(strFileName);					
									// Si no se ha cargado desde un archivo RSS, se carga desde un archivo Atom
										if (objChannel == null)
											objChannel = AtomParser.Parse(strFileName);
									// Devuelve los datos
										return objChannel;			
							}
					}
				catch (Exception objException) 
					{ Program.Log("Error al cargar '" + strFileName + "'" + Environment.NewLine +
												objException.Message);
					}
			// Si ha llegado hasta aquí es porque desconoce el tipo de archivo
				return null;
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
				catch {}
			// Si ha llegado hasta aquí es porque no ha podido leerlo
				return null;
		}

		/// <summary>
		///		Convierte las entradas RSS
		/// </summary>
		private static void ConvertEntriesRSS(RSSChannel objRSS)
		{	foreach (RSSEntry objEntry in objRSS.Entries)
				foreach (Libraries.LibFeeds.Syndication.FeedExtensions.ExtensionBase objExtension in objEntry.Extensions)
					if (objExtension is Libraries.LibFeeds.Syndication.FeedExtensions.RSSContent.Data.RSSContentData)
						{ Libraries.LibFeeds.Syndication.FeedExtensions.RSSContent.Data.RSSContentData objContent = objExtension as Libraries.LibFeeds.Syndication.FeedExtensions.RSSContent.Data.RSSContentData;
						
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
		
		/// <summary>
		///		Carga los IDs de un  archivo de datos borrados
		/// </summary>
		private static FeedIDs LoadIDs(string strFileName)
		{ FeedIDs objDeleted = new FeedIDs();
		
				// Carga los datos
					objDeleted.Load(strFileName);
				// Devuelve el archivo
					return objDeleted;
		}
		
		/// <summary>
		///		Mezcla en un canal Atom el archivo descargado con el local menos el archivo de borrados
		/// </summary>
		private static AtomChannel Merge(AtomChannel objAtomLocal, AtomChannel objAtomDownload, 
																		 FeedIDs objIDsDeleted)
		{ AtomChannel objAtomTarget = null;

				// Si no hay archivo descargado, el destino es el local		
				// Si no hay archivo local, el destino es el descargado menos los borrados
				// Si hay archivo local y descargado el destino es el descargado menos los borrados más los
				// que no existan del local
					if (objAtomDownload != null)
						{ // Asigna al destino el archivo descargado
								objAtomTarget = objAtomDownload;
							// Borra los elementos eliminados
								RemoveDeleted(objAtomTarget, objIDsDeleted);
							// Si hay archivo local, añade los datos que no existan al final
								if (objAtomLocal != null)
									foreach (AtomEntry objEntry in objAtomLocal.Entries)
										{ AtomEntry objEntryDownload = objAtomTarget.Entries.Search(objEntry.ID);
										
												// Si no lo ha encontrado añade la entrada local
												// Si la ha encontrado añade las extensiones
													if (objEntryDownload == null)
														objAtomTarget.Entries.Add(objEntry);
													else
														objEntryDownload.Extensions.Add(objEntry.Extensions);
										}
						}
				// Devuelve el objeto Atom final
					return objAtomTarget;
		}

		/// <summary>
		///		Quita los elementos eliminados de un canal
		/// </summary>
		private static void RemoveDeleted(AtomChannel objAtomTarget, FeedIDs objIDsDeleted)
		{ if (objIDsDeleted != null)
				foreach (string strID in objIDsDeleted.ListIDs)
					objAtomTarget.Entries.Remove(strID);
		}
	}
}
