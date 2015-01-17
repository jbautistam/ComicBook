using System;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Datos de un vínculo para Atom
	/// </summary>
	public class AtomLink
	{ // Enumerados públicos
			public enum AtomLinkType
				{ Unknown,
					/// <summary>La propia entrada</summary>
					Self,
					/// <summary>Una URL alternativa</summary>
					Alternate,
					/// <summary>Una URL a un recurso relacionado</summary>
					Enclosure,
					/// <summary>Un documento relacionado con la entrada</summary>
					Related,
					/// <summary>La fuente de la información proporcionada en la entrada</summary>
					Via
				}
		public AtomLink() : this(null, null, null, null) {}
		
		public AtomLink(string strHref, string strRel, string strTitle, string strType) 
								: this(strHref, GetType(strRel), strTitle, strType) {}
		
		public AtomLink(string strHref, AtomLinkType intLinkType, string strTitle, string strType)
		{ Href = strHref;
			LinkType = intLinkType;
			Title = strTitle;
			Type = strType;
		}
		
		/// <summary>
		///		Obtiene el tipo de vínculo a partir de la entrada
		/// </summary>
		private static AtomLinkType GetType(string strRel)
		{ switch (strRel)
				{ case "self":
						return AtomLinkType.Self;
					case "alternate":
						return AtomLinkType.Alternate;
					case "enclosure":
							return AtomLinkType.Enclosure;
					case "related":
						return AtomLinkType.Related;
					case "via":
						return AtomLinkType.Via;
					default:
						return AtomLinkType.Self;
				}
		}
		
		/// <summary>
		///		URL
		/// </summary>
		public string Href { get; set; }
		
		/// <summary>
		///		Tipo del vínculo
		/// </summary>
		public AtomLinkType LinkType { get; set; }
		
		/// <summary>
		///		Cadena con el tipo del vínculo
		/// </summary>
		public string Rel
		{ get
				{	switch (LinkType)
						{ case AtomLinkType.Self:
								return "self";
							case AtomLinkType.Alternate:
								return "alternate";
							case AtomLinkType.Enclosure:
									return "enclosure";
							case AtomLinkType.Related:
								return "related";
							case AtomLinkType.Via:
								return "via";
							default:
								return null;
						}
				}
		}
		
		/// <summary>
		///		Título
		/// </summary>
		public string Title { get; set; }
		
		/// <summary>
		///		Tipo
		/// </summary>
		public string Type { get; set; }
	}
}
