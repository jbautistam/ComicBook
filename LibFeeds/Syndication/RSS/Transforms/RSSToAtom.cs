using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.RSS.Data;

namespace Bau.Libraries.LibFeeds.Syndication.RSS.Transforms
{
	/// <summary>
	///		Clase para conversión de archivos RSS a Atom
	/// </summary>
	public static class RSSToAtom
	{
		/// <summary>
		///		Convierte un archivo RSS en un archivo Atom
		/// </summary>
		public static AtomChannel Convert(RSSChannel objRSS)
		{ AtomChannel objAtom = new AtomChannel();
		
				// Convierte los datos del canal
					objAtom.ID = new Guid().ToString();
					objAtom.Title = ConvertText(objRSS.Title);
					objAtom.Generator = ConvertGenerator(objRSS.Generator);
					objAtom.ConvertLineBreaks = true;
					objAtom.Info = ConvertText(objRSS.Description);
					objAtom.Subtitle = ConvertText("");
					objAtom.Links.Add(ConvertLink(objRSS.Link, AtomLink.AtomLinkType.Self));
					objAtom.LastUpdated = objRSS.LastBuildDate;
					objAtom.Icon = objRSS.Logo.Url;
					objAtom.Logo = objRSS.Logo.Url;
				// Añade las extensiones
					ConvertExtension(objRSS.Extensions, objAtom.Extensions);
				// Añade las entradas
					ConvertEntries(objRSS, objAtom);
				// Devuelve el objeto Atom
					return objAtom;
		}

		/// <summary>
		///		Convierte un texto a Atom
		/// </summary>
		private static AtomText ConvertText(string strText)
		{ return new AtomText("escaped", "text/html", strText);
		}

		/// <summary>
		///		Convierte un generador a Atom
		/// </summary>
		private static AtomGenerator ConvertGenerator(string strGenerator)
		{ return new AtomGenerator(null, null, strGenerator);
		}

		/// <summary>
		///		Convierte las entradas RSS en entradas Atom
		/// </summary>
		private static void ConvertEntries(RSSChannel objRSS, AtomChannel objAtom)
		{ foreach (RSSEntry objRssEntry in objRSS.Entries)
				{ AtomEntry objAtomEntry = new AtomEntry();
				
						// Convierte los datos de la entrada
							objAtomEntry.ID = objRssEntry.ID;
							objAtomEntry.Title = ConvertText(objRssEntry.Title);
							objAtomEntry.Content = ConvertText(objRssEntry.Content);
							objAtomEntry.DateIssued = objRssEntry.DateCreated;
							objAtomEntry.DateCreated = objRssEntry.DateCreated;
							objAtomEntry.DateModified = objRssEntry.DateCreated;
							objAtomEntry.DateUpdated = objRssEntry.DateCreated;
							objAtomEntry.DatePublished = objRssEntry.DateCreated;
						// Vínculos
							objAtomEntry.Links.Add(ConvertLink(objRssEntry.Link, AtomLink.AtomLinkType.Self));
							foreach (RSSEnclosure objRssEnclosure in objRssEntry.Enclosures)
								objAtomEntry.Links.Add(ConvertLink(objRssEnclosure));
						// Autores
							foreach (RSSAuthor objRssAuthor in objRssEntry.Authors)
								objAtomEntry.Authors.Add(ConvertAuthor(objRssAuthor));
						// Categorías
							foreach (RSSCategory objRssCategory in objRssEntry.Categories)
								objAtomEntry.Categories.Add(ConvertCategory(objRssCategory));
						// Convierte las extensiones
							ConvertExtension(objRssEntry.Extensions, objAtomEntry.Extensions);
						// Añade la entrada al objeto Atom
							objAtom.Entries.Add(objAtomEntry);
				}
		}

		/// <summary>
		///		Convierte un vínculo a Atom
		/// </summary>
		private static AtomLink ConvertLink(string strUrl, AtomLink.AtomLinkType intLinkType)
		{ return new AtomLink(strUrl, intLinkType, null, null);
		}

		/// <summary>
		///		Convierte un adjunto
		/// </summary>
		private static AtomLink ConvertLink(RSSEnclosure objRssEnclosure)
		{ return new AtomLink(objRssEnclosure.Url, AtomLink.AtomLinkType.Enclosure, null, objRssEnclosure.Type);
		}

		/// <summary>
		///		Convierte los datos de una persona
		/// </summary>
		private static AtomPeople ConvertAuthor(RSSAuthor objRssAuthor)
		{ AtomPeople objPeople = new AtomPeople();
		
				// Pasa los datos
					objPeople.Name = objRssAuthor.Name;
				// Devuelve los datos de la persona
					return objPeople;
		}

		/// <summary>
		///		Convierte una categoría
		/// </summary>
		private static AtomCategory ConvertCategory(RSSCategory objRssCategory)
		{ return new AtomCategory(objRssCategory.Text);
		}

		/// <summary>
		///		Convierte las extensiones
		/// </summary>
		private static void ConvertExtension(FeedExtensions.ExtensionsCollection objRSSExtensions, 
																				 FeedExtensions.ExtensionsCollection objAtomExtensions)
		{	foreach (FeedExtensions.ExtensionBase objExtension in objRSSExtensions)
				objAtomExtensions.Add(objExtension);					
		}
	}
}
