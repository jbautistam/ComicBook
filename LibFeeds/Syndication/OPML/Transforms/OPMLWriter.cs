using System;

using Bau.Libraries.LibFeeds.Syndication.OPML.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.OPML.Transforms
{
	/// <summary>
	///		Clase para escritura de archivos OPML
	/// </summary>
	public static class OPMLWriter
	{
		/// <summary>
		///		Obtiene el XML de un canal RSS
		/// </summary>
		public static string GetXML(OPMLChannel objOpml)
		{ return GetFile(objOpml).ToString();
		}

		/// <summary>
		///		Graba los datos de un objeto OPML en un archivo XML
		/// </summary>
		public static void Save(OPMLChannel objOpml, string strFileName)
		{ new XMLWriter().Save(GetFile(objOpml), strFileName);
		}

		/// <summary>
		///		Obtiene el builder XML de un objeto Atom
		/// </summary>
		private static MLFile GetFile(OPMLChannel objOpml)
		{ MLFile objFile = new MLFile();
			MLNode objNode = objFile.Nodes.Add(OPMLConstTags.cnstStrRoot);
			MLNode objNodeHeader;
		
				// Añade la cabecera
					objNode.Attributes.Add("version", "1.1");
				// Cabecera
					objNodeHeader = objNode.Nodes.Add(OPMLConstTags.cnstStrHead);
				// Obtiene el XML de los datos
					objNodeHeader.Nodes.Add(OPMLConstTags.cnstStrTitle, objOpml.Title);
					objNodeHeader.Nodes.Add(OPMLConstTags.cnstStrDateCreated, 
																	DateTimeHelper.ToStringRfc822(objOpml.DateCreated));
					objNodeHeader.Nodes.Add(OPMLConstTags.cnstStrDateModified, 
																	DateTimeHelper.ToStringRfc822(objOpml.DateModified));
					objNodeHeader.Nodes.Add(OPMLConstTags.cnstStrOwnerName, objOpml.OwnerName);
					objNodeHeader.Nodes.Add(OPMLConstTags.cnstStrOwnerEMail, objOpml.OwnerEMail);
				// Obtiene el XML de los elementos
					AddEntries(objNode.Nodes.Add(OPMLConstTags.cnstStrBody), objOpml.Entries);
				// Devuelve los datos
					return objFile;
		}

		/// <summary>
		///		Añade los elementos al XML
		/// </summary>
		private static void AddEntries(MLNode objParent, OPMLEntriesCollection objColEntries)
		{	foreach (OPMLEntry objEntry in objColEntries)
				{ MLNode objNode = objParent.Nodes.Add(OPMLConstTags.cnstStrOutline);
				
						// Añade los atributos
							if (!string.IsNullOrEmpty(objEntry.Type))
								objNode.Attributes.Add(OPMLConstTags.cnstStrType, objEntry.Type);
							if (!string.IsNullOrEmpty(objEntry.Text))
								objNode.Attributes.Add(OPMLConstTags.cnstStrText, objEntry.Text);
							if (!string.IsNullOrEmpty(objEntry.URL))
								objNode.Attributes.Add(OPMLConstTags.cnstStrUrl, objEntry.URL);
							if (objEntry.DateCreated != DateTime.MinValue)
								objNode.Attributes.Add(OPMLConstTags.cnstStrCreated, 
																			 DateTimeHelper.ToStringRfc822(objEntry.DateCreated));
						// Nodos
							AddEntries(objNode, objEntry.Entries);
					}
		}
	}
}
