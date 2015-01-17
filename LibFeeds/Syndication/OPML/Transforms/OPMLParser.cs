using System;

using Bau.Libraries.LibFeeds.Syndication.OPML.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.OPML.Transforms
{
	/// <summary>
	///		Intérprete de un archivo OPML
	/// </summary>
	public static class OPMLParser
	{
		/// <summary>
		///		Interpreta un archivo
		/// </summary>
		public static OPMLChannel Parse(string strFileName)
		{ OPMLChannel objOPML = null;
			MLFile objFile = new XMLParser().Load(strFileName);
			
				// Lee los datos
					foreach (MLNode objNode in objFile.Nodes)
						if (objNode.Name == OPMLConstTags.cnstStrRoot)
							{ // Crea el objeto
									objOPML = new OPMLChannel();
								// Carga los datos
									foreach (MLNode objOpml in objNode.Nodes)
										switch (objOpml.Name)
											{ case OPMLConstTags.cnstStrHead:
														ParseHead(objOpml.Nodes, objOPML);
													break;
												case OPMLConstTags.cnstStrBody:
														ParseEntries(objOpml.Nodes, objOPML.Entries);
													break;
											}
							}
				// Devuelve los datos del canal
					return objOPML;
		}

		/// <summary>
		///		Interpreta las cabeceras de un archivo OPML
		/// </summary>
		private static void ParseHead(MLNodesCollection objColNodes, OPMLChannel objOPML)
		{ foreach (MLNode objNode in objColNodes)
				switch (objNode.Name)
					{ case OPMLConstTags.cnstStrTitle:
								objOPML.Title = objNode.Value;
							break;
						case OPMLConstTags.cnstStrDateCreated:
								objOPML.DateCreated = objNode.GetValue(DateTime.Now);
							break;
						case OPMLConstTags.cnstStrDateModified:
								objOPML.DateModified = objNode.GetValue(DateTime.Now);
							break;
						case OPMLConstTags.cnstStrOwnerName:
								objOPML.OwnerName = objNode.Value;
							break;
						case OPMLConstTags.cnstStrOwnerEMail:
								objOPML.OwnerEMail = objNode.Value;
							break;
					}
		}

		/// <summary>
		///		Interpreta las entradas de un archivo XML
		/// </summary>
		private static void ParseEntries(MLNodesCollection objColNodes, OPMLEntriesCollection objColEntries)
		{ foreach (MLNode objNode in objColNodes)
				switch (objNode.Name)
					{ case OPMLConstTags.cnstStrOutline:
								objColEntries.Add(ParseEntry(objNode));
							break;
					}
		}
		
		/// <summary>
		///		Interpreta una entrada a partir de un nodo XML
		/// </summary>
		private static OPMLEntry ParseEntry(MLNode objNode)
		{ OPMLEntry objEntry = new OPMLEntry();
		
				// Lee los atributos
					objEntry.Type = objNode.Attributes.GetValue(OPMLConstTags.cnstStrType);
					objEntry.Title = objNode.Attributes.GetValue(OPMLConstTags.cnstStrTitleEntry);
					objEntry.Text = objNode.Attributes.GetValue(OPMLConstTags.cnstStrText);
					objEntry.URL = objNode.Attributes.GetValue(OPMLConstTags.cnstStrUrl);
					if (string.IsNullOrEmpty(objEntry.URL))
						objEntry.URL = objNode.Attributes.GetValue(OPMLConstTags.cnstStrXMLUrl);
					objEntry.DateCreated = objNode.Attributes.GetValue(OPMLConstTags.cnstStrCreated, DateTime.Now);
				// Lee las entradas
					ParseEntries(objNode.Nodes, objEntry.Entries);
				// Devuelve la entrada
					return objEntry;
		}
	}
}
