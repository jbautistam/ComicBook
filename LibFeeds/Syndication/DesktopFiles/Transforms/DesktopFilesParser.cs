using System;

using Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Data;
using Bau.Libraries.LibMarkupLanguage;
using Bau.Libraries.LibMarkupLanguage.Services.XML;
using Bau.Libraries.LibMarkupLanguage.Tools;

namespace Bau.Libraries.LibFeeds.Syndication.DesktopFiles.Transforms
{
	/// <summary>
	///		Intérprete de un archivo Desktop
	/// </summary>
	public static class DesktopFilesParser
	{
		/// <summary>
		///		Interpreta un archivo
		/// </summary>
		public static DesktopFilesChannel Parse(string strFileName)
		{ DesktopFilesChannel objDesktop = null;
			MLFile objFile = new XMLParser().Load(strFileName);
		
				// Lee los datos
					foreach (MLNode objNode in objFile.Nodes)
						if (objNode.Name == DesktopFilesConstTags.cnstStrRoot)
							{ // Crea el objeto
									objDesktop = new DesktopFilesChannel();
								// Carga los datos
									foreach (MLNode objMLDesktop in objNode.Nodes)
										switch (objMLDesktop.Name)
											{ case DesktopFilesConstTags.cnstStrTitle:
														objDesktop.Title = objMLDesktop.Value;
													break;
												case DesktopFilesConstTags.cnstStrDateCreated:
														objDesktop.DateCreated = objMLDesktop.GetValue(DateTime.Now);
													break;
												case DesktopFilesConstTags.cnstStrDateModified:
														objDesktop.DateModified = objMLDesktop.GetValue(DateTime.Now);
													break;
												case DesktopFilesConstTags.cnstStrOutline:
														objDesktop.Entries.Add(ParseEntry(objMLDesktop));
													break;
											}
								}
				// Devuelve los datos del canal
					return objDesktop;
		}
		
		/// <summary>
		///		Interpreta una entrada a partir de un nodo XML
		/// </summary>
		private static DesktopFilesEntry ParseEntry(MLNode objNode)
		{ DesktopFilesEntry objEntry = new DesktopFilesEntry();
		
				// Lee los atributos
					objEntry.Text = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrText);
					objEntry.LocalFileName = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrFileName);
					objEntry.NumberNotRead = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrNotRead, 0);
					objEntry.Enabled = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrEnabled, true);
					objEntry.URL = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrUrl);
					objEntry.User = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrUser);
					objEntry.Password = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrPassword);
					objEntry.DateCreated = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrCreated, DateTime.Now);
					objEntry.DateLastRead = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrLastRead, DateTime.MinValue);
					objEntry.DateLastUpdated = objNode.Attributes.GetValue(DesktopFilesConstTags.cnstStrLastUpdate,
																																 DateTime.Now);
				// Lee las entradas
					foreach (MLNode objChild in objNode.Nodes)
						if (objChild.Name == DesktopFilesConstTags.cnstStrOutline)
							objEntry.Entries.Add(ParseEntry(objChild));
				// Devuelve la entrada
					return objEntry;
		}
	}
}
