using System;

using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Transforms
{
	/// <summary>
	///		Clase para escritura de archivos OPML
	/// </summary>
	public static class DesktopFilesWriter
	{
		/// <summary>
		///		Obtiene el XML de un canal DesktopFiles
		/// </summary>
		public static string GetXML(DesktopFilesChannel objDesktop)
		{ return GetFile(objDesktop).ToString();
		}

		/// <summary>
		///		Graba los datos de un objeto OPML en un archivo XML
		/// </summary>
		public static void Save(DesktopFilesChannel objDesktop, string strFileName)
		{ new XMLWriter().Save(GetFile(objDesktop), strFileName);
		}

		/// <summary>
		///		Obtiene el builder XML de un objeto Atom
		/// </summary>
		private static MLFile GetFile(DesktopFilesChannel objDesktop)
		{ MLFile objFile = new MLFile();
			MLNode objNode = objFile.Nodes.Add(DesktopFilesConstTags.cnstStrRoot);
		
				// Añade los atributos de la cabecera
					objNode.Attributes.Add("version", "1.0");
				// Obtiene el XML de los datos
					objNode.Nodes.Add(DesktopFilesConstTags.cnstStrTitle, objDesktop.Title);
					objNode.Nodes.Add(DesktopFilesConstTags.cnstStrDateCreated, 
														DateTimeHelper.ToStringRfc822(objDesktop.DateCreated));
					objNode.Nodes.Add(DesktopFilesConstTags.cnstStrDateModified, 
														DateTimeHelper.ToStringRfc822(objDesktop.DateModified));
				// Obtiene el XML de los elementos
					AddEntries(objNode, objDesktop.Entries);
				// Devuelve los datos
					return objFile;
		}

		/// <summary>
		///		Añade los elementos al XML
		/// </summary>
		private static void AddEntries(MLNode objParent, DesktopFilesEntriesCollection objColEntries)
		{	foreach (DesktopFilesEntry objEntry in objColEntries)
				{ MLNode objNode = objParent.Nodes.Add(DesktopFilesConstTags.cnstStrOutline);
				
						// Atributos
							if (!string.IsNullOrEmpty(objEntry.Text))
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrText, objEntry.Text);
							if (!string.IsNullOrEmpty(objEntry.LocalFileName))
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrFileName, objEntry.LocalFileName);
							if (objEntry.NumberNotRead > 0)
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrNotRead, objEntry.NumberNotRead);
							if (!objEntry.Enabled)
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrEnabled, objEntry.Enabled);
							if (!string.IsNullOrEmpty(objEntry.URL))
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrUrl, objEntry.URL);
							if (!string.IsNullOrEmpty(objEntry.User))
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrUser, objEntry.User);
							if (!string.IsNullOrEmpty(objEntry.Password))
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrPassword, objEntry.Password);
							if (objEntry.DateCreated != DateTime.MinValue)
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrCreated, 
																			 DateTimeHelper.ToStringRfc822(objEntry.DateCreated));
							if (objEntry.DateLastRead != DateTime.MinValue)
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrLastRead, 
																			 DateTimeHelper.ToStringRfc822(objEntry.DateLastRead));
							if (objEntry.DateLastUpdated != DateTime.MinValue)
								objNode.Attributes.Add(DesktopFilesConstTags.cnstStrLastUpdate, 
																			 DateTimeHelper.ToStringRfc822(objEntry.DateLastUpdated));
					// Nodos
						AddEntries(objNode, objEntry.Entries);
				}
		}
	}
}
