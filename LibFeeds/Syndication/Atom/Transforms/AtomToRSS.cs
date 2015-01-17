using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.RSS.Data;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Transforms
{
	/// <summary>
	///		Clase para conversión de archivos Atom a RSS
	/// </summary>
	public static class AtomToRSS
	{
		/// <summary>
		///		Convierte un archivo RSS en un archivo Atom
		/// </summary>
		public static RSSChannel Convert(AtomChannel objAtom)
		{ RSSChannel objRss = new RSSChannel();
		
				// Convierte los datos del canal
					objRss.Title = objAtom.Title.Content;
					objRss.Generator = objAtom.Generator.Name;
					objRss.Description = objAtom.Info.Content;
					if (objAtom.Links.Count > 0)
						objRss.Link = objAtom.Links[0].Href;
					objRss.LastBuildDate = objAtom.LastUpdated;
				// Añade las extensiones
					ConvertExtension(objAtom.Extensions, objRss.Extensions);
				// Añade las entradas
					ConvertEntries(objAtom, objRss);
				// Devuelve el objeto Atom
					return objRss;
		}

		/// <summary>
		///		Convierte las entradas Atom en entradas RSS
		/// </summary>
		private static void ConvertEntries(AtomChannel objAtom, RSSChannel objRss)
		{ foreach (AtomEntry objAtomEntry in objAtom.Entries)
				{ RSSEntry objRssEntry = new RSSEntry();
				
						// Convierte los datos de la entrada
							objRssEntry.GUID.ID = objAtomEntry.ID;
							objRssEntry.Title = objAtomEntry.Title.Content;
							objRssEntry.Content = objAtomEntry.Content.Content;
							objRssEntry.DateCreated = objAtomEntry.DatePublished;
						// Vínculos
							if (objAtomEntry.Links.Count > 0)
								objRssEntry.Link = objAtomEntry.Links[0].Href;
							foreach (AtomLink objAtomLink in objAtomEntry.Links)
								if (objAtomLink.LinkType.Equals("enclosure"))
									objRssEntry.Enclosures.Add(ConvertLink(objAtomLink));
						// Autores
							foreach (AtomPeople objAtomAuthor in objAtomEntry.Authors)
								objRssEntry.Authors.Add(new RSSAuthor(objAtomAuthor.Name));
						// Categorías
							foreach (AtomCategory objAtomCategory in objAtomEntry.Categories)
								objRssEntry.Categories.Add(new RSSCategory(objAtomCategory.Name));
						// Convierte las extensiones
							ConvertExtension(objAtomEntry.Extensions, objRssEntry.Extensions);
						// Añade la entrada al objeto Atom
							objRss.Entries.Add(objRssEntry);
				}
		}

		/// <summary>
		///		Devuelve un adjunto a partir de un vínculo
		/// </summary>
		private static RSSEnclosure ConvertLink(AtomLink objAtomLink)
		{ RSSEnclosure objEnclosure = new RSSEnclosure();
		
				// Asigna las propiedades
					objEnclosure.Url = objAtomLink.Href;
					objEnclosure.Type = objAtomLink.Type;
				// Devuelve el objeto
					return objEnclosure;
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
