﻿using System;
using System.Collections.Generic;

namespace Bau.Libraries.LibFeeds.Syndication.Atom.Data
{
	/// <summary>
	///		Colección de <see cref="AtomLink"/>
	/// </summary>
	public class AtomLinksCollection : List<AtomLink>
	{
		/// <summary>
		///		Obtiene una colección con los vínculos de un tipo
		/// </summary>
		public AtomLinksCollection Search(AtomLink.AtomLinkType intLinkType)
		{ AtomLinksCollection objColLinks = new AtomLinksCollection();
		
				// Busca en la colección
					foreach (AtomLink objLink in this)
						if (objLink.LinkType == intLinkType)
							objColLinks.Add(objLink);
				// Devuelve la colección de vínculos encontrados
					return objColLinks;
		}
	}
}
