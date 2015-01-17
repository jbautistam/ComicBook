using System;
using System.Collections.Generic;

using Bau.Libraries.LibMarkupLanguage;

namespace Bau.Libraries.LibFeeds.Syndication.FeedExtensions
{
	/// <summary>
	///		Colección de <see cref="ExtensionParserBase"/>
	/// </summary>
	internal class ExtensionParsersCollection : List<ExtensionParserBase>
	{
		/// <summary>
		///		Añade un elemento al diccionario
		/// </summary>
		internal void Add(string strXMLNameSpace, string strPrefix)
		{ if (!Exists(strXMLNameSpace))
				{ ExtensionParserBase objParser = GetParser(strPrefix);
				
						if (objParser != null)
							Add(GetParser(strPrefix));
				}
		}

		/// <summary>
		///		Obtiene el parser del espacio de nombres
		/// </summary>
		private ExtensionParserBase GetParser(string strPrefix)
		{ // Busca el parser entre los conocidos
				switch (strPrefix)
					{ case Yahoo.YahooMediaConstTags.cnstStrXMLDefaultPrefix:
							return new Yahoo.Transforms.YahooMediaParser(Yahoo.YahooMediaConstTags.cnstStrXMLDefaultNameSpace, strPrefix);
						case Desktop.FeedDesktopConstTags.cnstStrXMLPrefix:
							return new Desktop.Transforms.FeedDesktopParser(Desktop.FeedDesktopConstTags.cnstStrXMLDefaultNameSpace, 
																															strPrefix);
						case RSSContent.RSSContentConstTags.cnstStrXMLDefaultPrefix:
							return new RSSContent.Transforms.RSSContentParser(RSSContent.RSSContentConstTags.cnstStrXMLDefaultNameSpace,
																																strPrefix);
					}
			// Si ha llegado hasta aquí es porque no ha encontrado ningún parser conocido
				return null;
		}
		
		/// <summary>
		///		Obtiene el parser asociado a un nodo XML
		/// </summary>
		internal ExtensionParserBase GetParser(MLNode objNode)
		{ ExtensionParserBase objParser;
		
				// Añade el elemento de extensión a la colección (siempre, para que se añada el espacio de
				// nombres si no existía
					LoadNameSpaces(objNode);
				// Obtiene el parser
					objParser = GetParser(objNode.Prefix);
				// Devuelve el parser
					return objParser;
		}		
		
		/// <summary>
		///		Inicializa el diccionario a partir de un nodo raíz
		/// </summary>
		internal void LoadNameSpaces(MLNode objNode)
		{	foreach (MLNameSpace objNameSpace in objNode.NameSpaces)
				Add(objNameSpace.NameSpace, objNameSpace.Prefix);
		}


		/// <summary>
		///		Obtiene el parser asociado a un espacio de nombres
		/// </summary>
		private ExtensionParserBase Search(string strXMLNameSpace)
		{	// Recorre las entradas del diccionario
				foreach (ExtensionParserBase objItem in this)
					if (objItem.NameSpace.Equals(strXMLNameSpace, StringComparison.CurrentCultureIgnoreCase))
						return objItem;
			// Si ha llegado hasta aquí es porque no ha encontrado nada
				return null;
		}

		/// <summary>
		///		Comprueba si existe un espacio de nombre en el diccionario
		/// </summary>
		private bool Exists(string strXMLNameSpace)
		{ return Search(strXMLNameSpace) != null;
		}
	}
}
