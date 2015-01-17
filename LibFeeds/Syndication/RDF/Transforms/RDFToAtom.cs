using System;

using Bau.Libraries.LibFeeds.Syndication.Atom.Data;
using Bau.Libraries.LibFeeds.Syndication.RDF.Data;

namespace Bau.Libraries.LibFeeds.Syndication.RDF.Transforms
{
	/// <summary>
	///		Clase para conversión de archivos RDF a Atom
	/// </summary>
	public static class RDFToAtom
	{
		/// <summary>
		///		Convierte un archivo RDF en un archivo Atom
		/// </summary>
		public static AtomChannel Convert(RDFChannel objRDF)
		{ AtomChannel objAtom = new AtomChannel();
		
				// Convierte los datos del canal
					objAtom.ID = new Guid().ToString();
					objAtom.Title = ConvertText(objRDF.Title);
					objAtom.Info = ConvertText(objRDF.Description);
					objAtom.Subtitle = ConvertText("");
					objAtom.Links.Add(ConvertLink(objRDF.Link, AtomLink.AtomLinkType.Self));
				// Añade las extensiones
					ConvertExtension(objRDF.Extensions, objAtom.Extensions);
				// Añade las entradas
					ConvertEntries(objRDF, objAtom);
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
		///		Convierte las entradas RDF en entradas Atom
		/// </summary>
		private static void ConvertEntries(RDFChannel objRDF, AtomChannel objAtom)
		{ foreach (RDFEntry objRDFEntry in objRDF.Entries)
				{ AtomEntry objAtomEntry = new AtomEntry();
				
						// Convierte los datos de la entrada
							objAtomEntry.ID = objRDFEntry.ID;
							objAtomEntry.Title = ConvertText(objRDFEntry.Title);
							objAtomEntry.Content = ConvertText(objRDFEntry.Content);
						// Vínculos
							objAtomEntry.Links.Add(ConvertLink(objRDFEntry.Link, AtomLink.AtomLinkType.Self));
						// Convierte las extensiones
							ConvertExtension(objRDFEntry.Extensions, objAtomEntry.Extensions);
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
		///		Convierte las extensiones
		/// </summary>
		private static void ConvertExtension(FeedExtensions.ExtensionsCollection objRDFExtensions, 
																				 FeedExtensions.ExtensionsCollection objAtomExtensions)
		{	foreach (FeedExtensions.ExtensionBase objExtension in objRDFExtensions)
				objAtomExtensions.Add(objExtension);					
		}
	}
}
